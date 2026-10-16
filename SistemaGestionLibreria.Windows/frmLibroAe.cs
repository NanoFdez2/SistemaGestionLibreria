using SistemaGestionLibreria.Entities.Enums;
using SistemaGestionLibreria.Services.DTO.Libro;
using SistemaGestionLibreria.Services.Interfaces;
using SistemaGestionLibreria.Windows.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml.XPath;

namespace SistemaGestionLibreria.Windows
{
    public partial class frmLibroAe : Form
    {
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        private LibroUpdateDto? _libroDto;
        private readonly ILibroServicio _libroServicio;
        private readonly ITemaServicio _temaServicio;
        private readonly IEditorialServicio _editorialServicio;
        private bool _esEdicion = false;
        public bool ConcurrencyConflict { get; private set; }

        public frmLibroAe(ILibroServicio libroServicio, ITemaServicio temaServicio, IEditorialServicio editorialServicio)
        {
            InitializeComponent();
            _libroServicio = libroServicio;
            _temaServicio = temaServicio;
            _editorialServicio = editorialServicio;
        }

        public void SetLibro(LibroUpdateDto? libroEditDto)
        {
            _libroDto = libroEditDto;
        }

        public LibroUpdateDto? GetLibro()
        {
            return _libroDto;
        }

        private void frmLibroAe_Load(object sender, EventArgs e)
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboTemas(cboTemas);
            CargarDatosComboEditoriales(cboEditorial);
            if (_libroDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = true;
            }
            else
            {
                txtNombreLibro.Text = _libroDto.Titulo;
                cboTemas.SelectedValue = _libroDto.TemasId;
                cboEditorial.SelectedValue = _libroDto.EditorialId;
                txtPrecio.Text = _libroDto.Precio.ToString();
                chkActivo.Checked = _libroDto.Activo;
                _esEdicion = true;

            }
        }

        private void CargarDatosComboTemas(ComboBox cboTemas)
        {
            var resultadoConsulta = _temaServicio
                            .ObtenerDatosCombo(TemaDefault.Seleccione);
            cboTemas.DataSource = resultadoConsulta.Value;
            cboTemas.DisplayMember = "Nombre";
            cboTemas.ValueMember = "TemaId";
            cboTemas.SelectedIndex = 0;
        }

        private void CargarDatosComboEditoriales(ComboBox cboEditorial)
        {
            try
            {
                var resultadoConsulta = _editorialServicio.ObtenerTodos();
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    return;
                }

                if (resultadoConsulta.Value == null || resultadoConsulta.Value.Count == 0)
                {
                    MessageBox.Show("No hay editoriales disponibles. Cree una primero.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Crear una copia list para modificar
                var editoriales = new List<SistemaGestionLibreria.Services.DTO.Editorial.EditorialListDto>(resultadoConsulta.Value);

                // Agregar opción "Seleccione" al principio
                editoriales.Insert(0, new SistemaGestionLibreria.Services.DTO.Editorial.EditorialListDto 
                { 
                    EditorialId = 0, 
                    Nombre = "Seleccione" 
                });

                cboEditorial.DataSource = editoriales;
                cboEditorial.DisplayMember = "Nombre";
                cboEditorial.ValueMember = "EditorialId";
                cboEditorial.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar editoriales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                try
                {
                    if (!_esEdicion)
                    {

                        var libroCreateDto = new LibroCreateDto();
                        libroCreateDto.Titulo = txtNombreLibro.Text;
                        libroCreateDto.ISBN = txtISBN.Text;
                        libroCreateDto.Descripcion = txtDescripcion.Text;
                        libroCreateDto.Precio = decimal.Parse(txtPrecio.Text);
                        libroCreateDto.AnioPublicacion = dtpAñoPublicacion.Value.Year;
                        libroCreateDto.Stock = txtStock.Text == "" ? 0 : int.Parse(txtStock.Text);
                        libroCreateDto.Activo = chkActivo.Checked;
                        int? editorialId = null;
                        if (cboEditorial.SelectedIndex > 0 && cboEditorial.SelectedItem is SistemaGestionLibreria.Services.DTO.Editorial.EditorialListDto editorial)
                        {
                            editorialId = editorial.EditorialId > 0 ? editorial.EditorialId : (int?)null;
                        }
                        libroCreateDto.EditorialId = editorialId;

                        var resultadoAgregar = _libroServicio.Agregar(libroCreateDto);
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
                        if (_libroDto is null)
                        {
                            _libroDto = new LibroUpdateDto();
                        }
                        _libroDto.Titulo = txtNombreLibro.Text;
                        _libroDto.ISBN = txtISBN.Text;
                        _libroDto.Descripcion = txtDescripcion.Text;
                        _libroDto.Precio = decimal.Parse(txtPrecio.Text);
                        _libroDto.AnioPublicacion = dtpAñoPublicacion.Value.Year;
                        _libroDto.Stock = txtStock.Text == "" ? 0 : int.Parse(txtStock.Text);
                        _libroDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _libroServicio
                            .Editar(_libroDto);
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
                    MessageBox.Show($"Error: {ex.Message}\n\nInner Exception: {ex.InnerException?.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InicializarControles()
        {
            txtNombreLibro.Clear();
            txtISBN.Clear();
            txtPrecio.Clear();
            txtDescripcion.Clear();
            dtpAñoPublicacion.Value = DateTime.Now;
            txtStock.Clear();
            cboEditorial.SelectedIndex = 0;
            cboTemas.SelectedIndex = 0;
            chkActivo.Checked = true;
            chkActivo.Enabled = true;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrWhiteSpace(txtNombreLibro.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombreLibro, "El nombre es requerido");
            }
            if(string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "La descripción es requerida");
            }
            else if (txtNombreLibro.Text.Length > 100)
            {
                valido = false;
                errorProvider1.SetError(txtNombreLibro, "El nombre debe tener no más de 100 caracteres");
            }
            if (txtISBN.Text.Length > 250)
            {
                valido = false;
                errorProvider1.SetError(txtISBN, "El ISBN no puede tener más de 250 caracteres");
            }
            if (cboTemas.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboTemas, "Debe seleccionar un tipo de libro");
            }
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtPrecio, "Precio no válido o fuera de rango");
            }
            if (cboEditorial.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboEditorial, "Debe seleccionar una editorial");
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
