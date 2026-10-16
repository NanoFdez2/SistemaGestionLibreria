using SistemaGestionLibreria.Services.DTO.Autor;
using SistemaGestionLibreria.Services.Interfaces;
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
    public partial class frmAutores : Form
    {
        private readonly IAutorServicio _autorServicio;
        private AutorUpdateDto? _autorUpdateDto;
        public frmAutores(IAutorServicio autorServicio)
        {
            _autorServicio = autorServicio;
            InitializeComponent();
        }

        public void SetTipo(AutorUpdateDto autorUpdateDto)
        {
            _autorUpdateDto = autorUpdateDto;
        }

        private void frmAutores_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private bool _esEdicion = false;
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_autorUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = false;

            }
            else
            {
                txtNombre.Text = _autorUpdateDto.Nombre;
                txtApellido.Text = _autorUpdateDto.Apellido;
                txtNacionalidad.Text = _autorUpdateDto.Nacionalidad;
                txtFechaNac.Text = _autorUpdateDto.FechaDeNacimiento.ToString("dd/MM/yyyy");
                chkActivo.Checked = _autorUpdateDto.Activo;
                chkActivo.Enabled = true;
                _esEdicion = true;
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

                        var _autorCreateDto = new AutorCreateDto();
                        _autorCreateDto.Nombre = txtNombre.Text;
                        _autorCreateDto.Apellido = txtApellido.Text;
                        _autorCreateDto.Nacionalidad = txtNacionalidad.Text;
                        _autorCreateDto.FechaDeNacimiento = DateTime.Parse(txtFechaNac.Text);
                        var resultadoAgregar = _autorServicio.Agregar(_autorCreateDto);
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
                        if (_autorUpdateDto is null)
                        {
                            _autorUpdateDto = new AutorUpdateDto();
                        }
                        _autorUpdateDto.Nombre = txtNombre.Text;
                        _autorUpdateDto.Apellido = txtApellido.Text;
                        _autorUpdateDto.Nacionalidad = txtNacionalidad.Text;
                        _autorUpdateDto.FechaDeNacimiento = DateTime.Parse(txtFechaNac.Text);
                        _autorUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _autorServicio
                            .Editar(_autorUpdateDto);
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

        private void InicializarControles()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtNacionalidad.Clear();
            txtFechaNac.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = false;
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNombre, "El nombre es requerido");

            }
            if (string.IsNullOrEmpty(txtApellido.Text))
            {
                valido = false;
                errorProvider1.SetError(txtApellido, "El apellido es requerido");

            }

            if (string.IsNullOrEmpty(txtNacionalidad.Text))
            {
                valido = false;
                errorProvider1.SetError(txtNacionalidad, "La nacionalidad es requerida");

            }

            if(string.IsNullOrEmpty(txtFechaNac.Text))
            {
                valido = false;
                errorProvider1.SetError(txtFechaNac, "La fecha de nacimiento es requerida");
            }
            else
            {
                if (!DateTime.TryParse(txtFechaNac.Text, out DateTime fechaNacimiento))
                {
                    valido = false;
                    errorProvider1.SetError(txtFechaNac, "La fecha de nacimiento no es válida");
                }
                else if (fechaNacimiento > DateTime.Now)
                {
                    valido = false;
                    errorProvider1.SetError(txtFechaNac, "La fecha de nacimiento no puede ser mayor a la fecha actual");
                }
            }
            return valido;
        }
    }
}
