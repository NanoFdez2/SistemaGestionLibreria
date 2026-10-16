using Microsoft.Extensions.DependencyInjection;
using SistemaGestionLibreria.Services.DTO.Pack;
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
    public partial class frmPack : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();
        private EstadoNavegacion _estado = new(10);
        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        private bool? filtroActivo = null;
        private string? textoBuscar = null;
        private int? temaFiltroId = null; 


        public frmPack(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void frmPack_Load(object sender, EventArgs e)
        {
            CargarTemas();
            RecargarGrilla();

        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var cajaServicio = scope.ServiceProvider
                    .GetRequiredService<IPackServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = cajaServicio
                        .ObtenerPaginado(
                            paginaSolicitada,
                            _estado.RegistrosPorPagina,
                            campoOrdenar,
                            esAscendente,
                            filtroActivo,
                            textoBuscar,
                            temaFiltroId);

                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }

                    var resultado = resultadoConsulta.Value!;

                    _estado.Actualizar(resultado.CantidadRegistros);

                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = cajaServicio
                            .ObtenerPaginado(
                                _estado.PaginaActual,
                                _estado.RegistrosPorPagina,
                                campoOrdenar,
                                esAscendente,
                                filtroActivo,
                                textoBuscar,
                                temaFiltroId);

                        if (resultadoConsulta.IsFailure)
                        {
                            ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                            return;
                        }

                        resultado = resultadoConsulta.Value!;

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
                    _servicioMensajes.Error(ex.Message);
                }
            }
        }

        private void activoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            ActualizarInformacion();

        }

        private void noActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
            ActualizarInformacion();

        }

        private void ActualizarInformacion()
        {
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }
            PackListDto packListDto = (PackListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                var packServicio = scope.ServiceProvider
                        .GetRequiredService<IPackServicio>();
                var resultadoConsulta = packServicio.ObtenerParaBorrar(packListDto.ProductoId);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    return;

                }
                var packDeleteDto = resultadoConsulta.Value;
                if (!_servicioMensajes.Confirmar($"¿Desea borrar el bombón {packListDto.Titulo}?")) return;
                if (packDeleteDto is null) return;
                try
                {
                    var resultadoEliminacion = packServicio
                        .Borrar(packDeleteDto);
                    if (resultadoEliminacion.IsConcurrencyConflict)
                    {
                        ErrorHelper.MostrarErrores(resultadoEliminacion.Errors);
                        RecargarGrilla();
                        return;

                    }
                    if (resultadoEliminacion.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoEliminacion.Errors);
                        return;

                    }
                    _servicioMensajes.Informacion("Registro eliminado satisfactoriamente");
                    RecargarGrilla();
                }
                catch (Exception ex)
                {

                    _servicioMensajes.Error(ex.Message);
                }
            }

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmPackAe frm = scope.ServiceProvider.GetRequiredService<frmPackAe>())
                {
                    frm.Text = "Nuevo Libro";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;
                        bool sePuedeVer = filtroActivo is null || filtroActivo == true;
                        if (sePuedeVer)
                        {
                            var tipoServicio = scope.ServiceProvider
                                .GetRequiredService<IPackServicio>();
                            var resultado = tipoServicio.ObtenerPaginaRegistro(nuevoId, _estado.RegistrosPorPagina);
                            if (resultado.IsFailure)
                            {
                                ErrorHelper.MostrarErrores(resultado.Errors);
                                return;
                            }
                            _estado.PaginaActual = resultado.Value;
                        }
                        RecargarGrilla();
                        if (sePuedeVer)
                        {
                            var nuevoTipo = _bindingSource.List
                                .Cast<PackListDto>()
                                .FirstOrDefault(b => b.ProductoId == nuevoId);
                            if (nuevoTipo is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(nuevoTipo);

                        }
                        else
                        {
                            _servicioMensajes.Advertencia("Los registros agregados no se pueden mostrar\npor condición de filtro o búsqueda");
                        }
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
            var packListDto = (PackListDto)_bindingSource.Current;
            var seleccionadoId = packListDto.ProductoId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var packServicio = scope.ServiceProvider
                .GetRequiredService<IPackServicio>();
                    var resultadoConsulta = packServicio
                        .ObtenerParaEditar(packListDto.ProductoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var packEditDto = resultadoConsulta.Value;
                    using (frmPackAe frm = scope.ServiceProvider
                        .GetRequiredService<frmPackAe>())
                    {
                        frm.Text = "Editar Pack";
                        frm.SetPack(packEditDto);
                        frm.ShowDialog();
                        var packEditado = frm.GetPack();
                        if (packEditado is null) return;
                        bool sePuedeVer = filtroActivo is null ||
                            filtroActivo == packEditado.Activo;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = packServicio
                                .ObtenerPaginaRegistro(seleccionadoId, _estado.RegistrosPorPagina,
                                filtroActivo);
                            if (resultadoConsulta.IsFailure)
                            {
                                ErrorHelper.MostrarErrores(resultadoPagina.Errors);
                                return;
                            }
                            _estado.PaginaActual = resultadoPagina.Value;
                        }

                        if (frm.ConcurrencyConflict)//si hubo concurrencia se recarga la grilla
                        {
                            RecargarGrilla();
                        }
                        if (frm.DataChanged)//si cambiaron los datos se recarga la grilla
                        {
                            RecargarGrilla();
                        }
                        if (sePuedeVer)
                        {
                            var registroEditado = _bindingSource.List
                                .Cast<PackListDto>()
                                .FirstOrDefault(tb => tb.ProductoId == seleccionadoId);
                            if (registroEditado is null) return;
                            _bindingSource.Position = _bindingSource.IndexOf(registroEditado);

                        }
                        else
                        {
                            MessageBox.Show("El registro editado no se puede mostrar\npor condición de filtro o búsqueda",
                                "Advertencia",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

        private void btnPrimero_Click(object sender, EventArgs e)
        {
            _estado.PrimeraPagina();
            RecargarGrilla();

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            _estado.PaginaAnterior();
            RecargarGrilla();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _estado.PaginaSiguiente();
            RecargarGrilla();

        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            _estado.UltimaPagina();
            RecargarGrilla();

        }

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                MessageBox.Show("Debe poner un texto para efectuar la búsqueda",
                    "Advertencia",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            textoBuscar = txtBuscar.Text;
            tsbBuscar.BackColor = Color.Orange;
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var packListDto = (PackListDto)_bindingSource.Current;
            var seleccionadoId = packListDto.ProductoId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var packServicio = scope.ServiceProvider
                .GetRequiredService<IPackServicio>();
                    var resultadoConsulta = packServicio
                        .ObtenerPackConDetalle(packListDto.ProductoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var packDto = resultadoConsulta.Value;
                    if (packDto is null) return;
                    using (frmDetallePack frm = scope.ServiceProvider
                        .GetRequiredService<frmDetallePack>())
                    {
                        frm.Text = "Detalle del Pack";
                        frm.SetPack(packDto);
                        frm.ShowDialog();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroActivo = null;
            textoBuscar = null;
            tsbBuscar.BackColor = SystemColors.Control;

            ActualizarInformacion();

        }

        private void CargarTemas()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var temaServicio = scope.ServiceProvider
                    .GetRequiredService<ITemaServicio>();

                try
                {
                    var resultado = temaServicio.ObtenerTodos();

                    if (resultado.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultado.Errors);
                        return;
                    }

                    tsCboTemas.Items.Clear();
                    tsCboTemas.Items.Add("-- Todos los temas --");

                    foreach (var tema in resultado.Value!)
                    {
                        tsCboTemas.Items.Add(tema.Nombre);
                    }

                    tsCboTemas.SelectedIndex = 0;
                    tsCboTemas.SelectedIndexChanged += TsCboTemas_SelectedIndexChanged;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void TsCboTemas_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tsCboTemas.SelectedIndex > 0)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var temaServicio = scope.ServiceProvider
                        .GetRequiredService<ITemaServicio>();

                    var temasResult = temaServicio.ObtenerTodos();

                    if (temasResult.IsSuccess && tsCboTemas.SelectedIndex - 1 < temasResult.Value!.Count)
                    {
                        temaFiltroId = temasResult.Value![tsCboTemas.SelectedIndex - 1].TemaId;
                    }
                }
            }
            else
            {
                temaFiltroId = null;
            }

            _estado.PaginaActual = 1;
            RecargarGrilla();
        }
    }
}
