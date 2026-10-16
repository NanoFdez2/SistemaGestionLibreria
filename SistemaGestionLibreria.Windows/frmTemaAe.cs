using SistemaGestionLibreria.Services.DTO.Tema;
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
    public partial class frmTemaAe : Form
    {
        private TemaUpdateDto? _temaUpdateDto;
        private readonly ITemaServicio _temaServicio;
        private bool _esEdicion = false;

        public frmTemaAe(ITemaServicio temaServicio)
        {
            _temaServicio = temaServicio;
            InitializeComponent();
        }

        public int UltimoId { get; private set; }
        public bool DataChanged { get; private set; }
        public bool ConcurrencyConflict { get; private set; }


        public TemaUpdateDto GetTema()
        {
            return _temaUpdateDto;
        }

        public void SetTema(TemaUpdateDto? tipoEditDto)
        {
            _temaUpdateDto = tipoEditDto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_temaUpdateDto is null)
            {
                chkActivo.Checked = true;
                chkActivo.Enabled = true;

            }
            else
            {
                txtTema.Text = _temaUpdateDto.Nombre;
                txtDescripcion.Text = _temaUpdateDto.Descripcion;
                chkActivo.Checked = _temaUpdateDto.Activo;
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

                        var _tipoCreateDto = new TemaCreateDto();
                        _tipoCreateDto.Nombre = txtTema.Text;
                        _tipoCreateDto.Descripcion = txtDescripcion.Text;
                        _tipoCreateDto.Activo = chkActivo.Checked;
                        var resultadoAgregar = _temaServicio.Agregar(_tipoCreateDto);
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
                        if (_temaUpdateDto is null)
                        {
                            _temaUpdateDto = new TemaUpdateDto();
                        }
                        _temaUpdateDto.Nombre = txtTema.Text;
                        _temaUpdateDto.Descripcion = txtDescripcion.Text;
                        _temaUpdateDto.Activo = chkActivo.Checked;

                        var resultadoEditar = _temaServicio
                            .Editar(_temaUpdateDto);
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
            txtTema.Clear();
            txtDescripcion.Clear();
            chkActivo.Checked = true;
            chkActivo.Enabled = true;
            txtTema.Focus();
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtTema.Text))
            {
                valido = false;
                errorProvider1.SetError(txtTema, "El nombre es requerido");

            }
            if(string.IsNullOrEmpty(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "La descripción es requerida");
            }
            return valido;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }
    }
}
