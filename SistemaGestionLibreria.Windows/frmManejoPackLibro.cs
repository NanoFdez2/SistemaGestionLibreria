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

namespace SistemaGestionLibreria.Windows
{
    public partial class frmManejoPackLibro : Form
    {
        private readonly ILibroServicio _libroServicio;
        private LibroComboDto? _libroSeleccionado;
        private int _cantidadLibros;
        public frmManejoPackLibro(ILibroServicio libroServicio)
        {
            _libroServicio = libroServicio;
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarDatosComboLibros(cboLibros);

        }

        public (LibroComboDto, int) GetDatos()
        {
            return (_libroSeleccionado, _cantidadLibros);
        }

        private void CargarDatosComboLibros(ComboBox cboLibros)
        {
            var respuestaConsulta = _libroServicio
                            .ObtenerDatosCombo(LibroDefault.Seleccione, false);
            if (respuestaConsulta.IsFailure)
            {
                ErrorHelper.MostrarErrores(respuestaConsulta.Errors);
                return;
            }
            var listaCbo = respuestaConsulta.Value!;
            cboLibros.DataSource = listaCbo;
            cboLibros.DisplayMember = "NombreLibro";
            cboLibros.ValueMember = "LibroId";
            cboLibros.SelectedIndex = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                _libroSeleccionado = (LibroComboDto)cboLibros.SelectedItem;
                _cantidadLibros = int.Parse(txtCantidad.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (cboLibros.SelectedIndex == 0)
            {
                valido = false;
                errorProvider1.SetError(cboLibros, "Debe seleccionar un libro");
            }
            if (!int.TryParse(txtCantidad.Text, out _cantidadLibros) || _cantidadLibros <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtCantidad, "Debe ingresar una cantidad válida mayor a cero");
            }

            return valido;
        }
    }
}
