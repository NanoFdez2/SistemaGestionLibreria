using Microsoft.Extensions.DependencyInjection;
using SistemaGestionLibreria.Services.DTO.DetallePack;
using SistemaGestionLibreria.Services.DTO.Libro;
using SistemaGestionLibreria.Services.DTO.Pack;
using SistemaGestionLibreria.Services.Interfaces;
using SistemaGestionLibreria.Windows.Clases;
using SistemaGestionLibreria.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaGestionLibreria.Windows
{
    public partial class frmPackAe : Form
    {
        private PackUpdateDto? _packDto;
        private EditorPack _editorPack = null!;
        private BindingSource _bindingSource = new BindingSource();
        private readonly IPackServicio _packServicio;
        private readonly ILibroServicio _libroServicio;
        private readonly IServiceProvider _serviceProvider;
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();
        private bool _esEdicion = false;
        public frmPackAe(IPackServicio packServicio, ILibroServicio libroServicio, IServiceProvider serviceProvider)
        {
            _packServicio = packServicio;
            _libroServicio = libroServicio;
            _serviceProvider = serviceProvider;
            InitializeComponent();
            dgvDatos.DataSource = _bindingSource;
        }

        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_packDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;
                InicializarEditor();
            }
            else
            {
                txtNombrePack.Text = _packDto.Titulo;
                chkActivo.Checked = _packDto.Activo;
                _esEdicion = true;
                _editorPack = new EditorPack(_packDto);
                MostrarDatos(_editorPack.ObtenerResumen());
            }
        }

        private void InicializarEditor()
        {
            _packDto = new PackUpdateDto();
            _editorPack = new EditorPack(_packDto);
            MostrarDatos(_editorPack.ObtenerResumen());
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {

                        var packCreateDto = new PackCreateDto();
                        packCreateDto.Titulo = txtNombrePack.Text;
                        packCreateDto.Descripcion = txtDescripcion.Text;
                        packCreateDto.CantidadLibros = int.Parse(lblCantidad.Text);
                        packCreateDto.Activo = chkActivo.Checked;
                        packCreateDto.Stock = int.Parse(nudStock.Text);
                        packCreateDto.Detalles = _editorPack.ObtenerResumen().Detalles.ToList();
                        lblCantidad.Text = _bindingSource.Count.ToString();
                        var resultadoAgregar = _packServicio.Agregar(packCreateDto);
                        if (resultadoAgregar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoAgregar.Errors);
                            return;
                        }
                        DataChanged = true;
                        UltimoId = resultadoAgregar.Value;
                        var respuestaAgregarOtro = MessageBox.Show("Registro agregado\n¿Desea agregar otro?",
                                "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                        if (respuestaAgregarOtro == DialogResult.No)
                        {
                            DialogResult = DialogResult.OK;
                        }
                        InicializarControles();

                    }
                    else
                    {
                        if (_packDto is null)
                        {
                            _packDto = new PackUpdateDto();
                        }
                        _packDto.Titulo = txtNombrePack.Text;
                        _packDto.Descripcion = txtDescripcion.Text;
                        _packDto.Activo = chkActivo.Checked;
                        _packDto.CantidadLibros = int.Parse(lblCantidad.Text);
                        _packDto.Detalles = _editorPack.ObtenerResumen().Detalles.ToList();

                        var resultadoEditar = _packServicio
                            .Editar(_packDto);
                        if (resultadoEditar.IsConcurrencyConflict)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);

                            ConcurrencyConflict = true;
                            DialogResult = DialogResult.Cancel;

                            Close();
                            return;
                        }
                        if (resultadoEditar.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoEditar.Errors);
                            return;
                        }
                        DataChanged = true;
                        MessageBox.Show("Registro editado satisfactoriamente",
                            "Mensaje",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public PackUpdateDto? GetPack()
        {
            return _packDto;
        }

        public void SetPack(PackUpdateDto? packDto)
        {
            _packDto = packDto;
        }


        private void InicializarControles()
        {
            txtNombrePack.Clear();
            txtDescripcion.Clear();
            lblCantidad.Text = "0";
            nudStock.Value = 0;
            lblPrecio.Text = "0";
            chkActivo.Checked = true;
            chkActivo.Enabled = true;
            txtNombrePack.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtNombrePack.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombrePack, "El nombre es requerido");
            }
            else if (txtNombrePack.Text.Length > 100)
            {
                valido = false;
                errorProvider1.SetError(txtNombrePack, "El nombre debe tener no más de 100 caracteres");
            }
            if (txtDescripcion.Text.Length > 250)
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "La descripción no puede tener más de 250 caracteres");
            }
            if (nudStock.Value <= 0)
            {
                valido = false;
                errorProvider1.SetError(nudStock, "El stock no puede ser negativo");
            }

            if (_editorPack.ObtenerResumen().Detalles.Count < 2)
            {
                valido = false;
                MessageBox.Show("El pack debe contener al menos dos libros diferentes", 
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return valido;
        }

        private void btnAgregarLibro_Click(object sender, EventArgs e)
        {
            using (var frm = _serviceProvider.GetRequiredService<frmManejoPackLibro>())
            {
                frm.Text = "Nuevo Detalle";
                if (frm.ShowDialog() == DialogResult.Cancel) return;
                var (libro, cantidad) = frm.GetDatos();
                if (libro is null) return;
                try
                {
                    _editorPack.AgregarLibro(libro, cantidad);
                    MostrarDatos(_editorPack.ObtenerResumen());
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MostrarDatos((IReadOnlyCollection<DetallePackDto> Detalles, int Cantidad, decimal Precio, bool Activo) value)
        {
            txtNombrePack.Text = _packDto?.Titulo ?? string.Empty;
            txtDescripcion.Text = _packDto?.Descripcion ?? string.Empty;
            nudStock.Value = _packDto?.Stock ?? 0;
            lblCantidad.Text = value.Cantidad.ToString();
            lblPrecio.Text = value.Precio.ToString();
            chkActivo.Checked = value.Activo;
            _bindingSource.DataSource = value.Detalles.ToList();
            _bindingSource.ResetBindings(false);
        }

        private void btnEliminarLibro_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current is DetallePackDto detalle)
            {
                var resultado = MessageBox.Show($"¿Desea eliminar el libro {detalle.Titulo}?",
                    "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (resultado == DialogResult.No) return;
                try
                {
                    _editorPack.EliminarLibro(detalle.LibroId);
                    MostrarDatos(_editorPack.ObtenerResumen());
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditarLibro_Click(object sender, EventArgs e)
        {
            
        }
    }
}
