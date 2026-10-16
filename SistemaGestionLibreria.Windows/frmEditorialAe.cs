using SistemaGestionLibreria.Services.DTO.Editorial;
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
    public partial class frmEditorialAe : Form
    {
        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }
        private EditorialUpdateDto? _editorialUpdateDto;
        private readonly IEditorialServicio _editorialServicio;
        private bool _esEdicion = false;
        public frmEditorialAe(IEditorialServicio editorialServicio)
        {
            InitializeComponent();
            _editorialServicio = editorialServicio;
        }

        public frmEditorialAe()
        {
            InitializeComponent();
        }

        public void SetEditorial(EditorialUpdateDto? editorialEditDto)
        {
            _editorialUpdateDto = editorialEditDto;
        }

        public EditorialUpdateDto GetEditorial()
        {
            return _editorialUpdateDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_editorialUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = true;

            }
            else
            {
                txtPais.Text = _editorialUpdateDto.PaisDeOrigen;
                txtEditorial.Text = _editorialUpdateDto.Nombre;
                chkActivo.Checked = _editorialUpdateDto.Activo ?? false;
                chkActivo.Enabled = true;
                _esEdicion = true;
            }
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

                        var _tipoCreateDto = new EditorialCreateDto();
                        _tipoCreateDto.Nombre = txtEditorial.Text;
                        _tipoCreateDto.PaisDeOrigen = txtPais.Text;
                        _tipoCreateDto.Activo = chkActivo.Checked;
                        var resultadoAgregar = _editorialServicio.Agregar(_tipoCreateDto);
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
                        if (_editorialUpdateDto is null)
                        {
                            _editorialUpdateDto = new EditorialUpdateDto();
                        }
                        // Preservar EditorialId y RowVersion
                        var editorialId = _editorialUpdateDto.EditorialId;
                        var rowVersion = _editorialUpdateDto.RowVersion;

                        _editorialUpdateDto.Nombre = txtEditorial.Text;
                        _editorialUpdateDto.PaisDeOrigen = txtPais.Text;
                        _editorialUpdateDto.Activo = chkActivo.Checked;

                        // Restaurar valores críticos
                        _editorialUpdateDto.EditorialId = editorialId;
                        _editorialUpdateDto.RowVersion = rowVersion;

                        var resultadoEditar = _editorialServicio
                            .Editar(_editorialUpdateDto);
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
            txtEditorial.Clear();
            txtPais.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = true;
            txtEditorial.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtEditorial.Text))
            {
                valido = false;
                errorProvider1.SetError(txtEditorial, "El nombre es requerido");

            }
            if(string.IsNullOrEmpty(txtPais.Text))
            {
                valido = false;
                errorProvider1.SetError(txtPais, "El país de origen es requerido");
            }
            return valido;
        }
    }
}
