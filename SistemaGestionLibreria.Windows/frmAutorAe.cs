using Microsoft.Extensions.DependencyInjection;
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
    public partial class frmAutorAe : Form
    {
        private readonly IServiceProvider _serviceProvider;
        private BindingSource _bindingSource = new BindingSource();
        private EstadoNavegacion _estado = new(10);
        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        private bool? filtroActivo = null;
        private string? textoBuscar = null;
        private AutorUpdateDto? _autorUpdateDto;
        public bool DataChanged { get; private set; }


        public frmAutorAe(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            dgvDatos.DataSource = _bindingSource;
            Load += FrmAutorAe_Load;
        }

        private void FrmAutorAe_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var clienteListDto = (AutorListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                var clienteServicio = scope.ServiceProvider
                        .GetRequiredService<IAutorServicio>();
                var dr = MessageBox.Show($"¿Desea borrar el autor {clienteListDto.Apellido}, {clienteListDto.Nombre}?",
                    "Confirmar Borrado", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);
                if (dr == DialogResult.No) return;
                try
                {
                    var resultadoEliminacion = clienteServicio
                        .Borrar(clienteListDto.AutorId!);
                    if (resultadoEliminacion.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoEliminacion.Errors);
                        return;

                    }
                    MessageBox.Show("Registro eliminado satisfactoriamente",
                        "Mensaje",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RecargarGrilla();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var autorServicio = scope.ServiceProvider
                    .GetRequiredService<IAutorServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = autorServicio
                        .ObtenerPaginado(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroActivo,
                            textoBuscar);

                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;

                    // Actualizamos cantidad y páginas.
                    _estado.Actualizar(resultado.CantidadRegistros);

                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = autorServicio
                            .ObtenerPaginado(
                                _estado.PaginaActual,
                                _estado.RegistrosPorPagina,
                                campoOrdenar,
                                esAscendente,
                                filtroActivo,
                                textoBuscar);

                        if (resultadoConsulta.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                            return;
                        }

                        resultado = resultadoConsulta.Value!;

                        // Actualizamos nuevamente por seguridad.
                        _estado.Actualizar(resultado.CantidadRegistros);
                    }

                    _bindingSource.DataSource = resultado.Items;

                    lblCantidad.Text = _estado.TextoRegistros();
                    lblPaginas.Text = _estado.TextoPaginas();

                    btnPrimero.Enabled = _estado.PuedeIrAnterior();
                    btnAnterior.Enabled = _estado.PuedeIrAnterior();
                    btnSiguiente.Enabled = _estado.PuedeIrSiguiente();
                    btnUltimo.Enabled = _estado.PuedeIrSiguiente();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmAutores frm = scope.ServiceProvider.GetRequiredService<frmAutores>())
                {
                    frm.Text = "Nuevo Autor";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        RecargarGrilla();
                    }

                }
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var clienteListDto = (AutorListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var clienteServicio = scope.ServiceProvider
                .GetRequiredService<IAutorServicio>();
                    var resultadoConsulta = clienteServicio
                        .ObtenerParaEditar(clienteListDto.AutorId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var clienteEditDto = resultadoConsulta.Value;
                    using (frmAutores frm = scope.ServiceProvider
                        .GetRequiredService<frmAutores>())
                    {
                        frm.Text = "Editar Autor";
                        frm.SetTipo(clienteEditDto);
                        frm.ShowDialog();
                        if (frm.DataChanged)//VER ACÁ PROBLEMA SI NO SE ACTUALIZA LA GRILLA
                        {
                            RecargarGrilla();
                        }

                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetTipo(AutorUpdateDto? autorUpdateDto)
        {
            _autorUpdateDto = autorUpdateDto;
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroActivo = null;
            textoBuscar = null;
            txtBuscar.Text = string.Empty;
            _estado.PaginaActual = 1;
            tsbFiltrar.BackColor = SystemColors.Control;
            RecargarGrilla();
        }

        private void tsbFiltrar_Click(object sender, EventArgs e)
        {
            using (var menu = new ContextMenuStrip())
            {
                menu.Items.Add("Todos", null, (s, e) =>
                {
                    filtroActivo = null;
                    _estado.PaginaActual = 1;
                    RecargarGrilla();
                });

                menu.Items.Add("Activos", null, (s, e) =>
                {
                    filtroActivo = true;
                    _estado.PaginaActual = 1;
                    RecargarGrilla();
                });

                menu.Items.Add("Inactivos", null, (s, e) =>
                {
                    filtroActivo = false;
                    _estado.PaginaActual = 1;
                    RecargarGrilla();
                });
                //CONSULTAR FRAN TEMA DE POSICIONES
                var toolStripDropDownButton = sender as ToolStripButton;
                if (toolStripDropDownButton?.Owner is ToolStrip toolStrip)
                {
                    var point = toolStrip.PointToScreen(new System.Drawing.Point(toolStripDropDownButton.Bounds.Left, toolStripDropDownButton.Bounds.Bottom));
                    menu.Show(point);
                }
            }
        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            textoBuscar = txtBuscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(textoBuscar))
            {
                textoBuscar = null;
            }
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void btnPrimero_Click(object sender, EventArgs e)
        {

        }
    }
}
