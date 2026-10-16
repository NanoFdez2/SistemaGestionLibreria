using SistemaGestionLibreria.Services.DTO.Pack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SistemaGestionLibreria.Windows
{
    public partial class frmDetallePack : Form
    {
        private PackDetailDto _packDto = null!;
        private BindingSource _bindingSource = new BindingSource();


        public frmDetallePack()
        {
            InitializeComponent();
            dgvDatos.DataSource = _bindingSource;
        }

        public void SetPack(PackDetailDto packDto)
        {
            _packDto = packDto;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmDetallePack_Load(object sender, EventArgs e)
        {
            MostrarDatos(_packDto);
        }

        private void MostrarDatos(object cajaDto)
        {
            txtNombrePack.Text = _packDto.Titulo;
            txtDescripcion.Text = _packDto.Descripcion;
            txtStock.Text = _packDto.Stock.ToString();
            txtCantidadLibros.Text = _packDto.CantidadLibros.ToString();
            txtPrecio.Text = _packDto.Precio.ToString("C2");
            chkActivo.Checked = _packDto.Activo;
            _bindingSource.DataSource = _packDto.Detalles;
            _bindingSource.ResetBindings(false);
        }
    }
}
