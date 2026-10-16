using Microsoft.Extensions.DependencyInjection;
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
    public partial class frmLibro : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();
        private EstadoNavegacion _estado = new(10);
        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        private bool? filtroActivo = null;
        private string? textoBuscar = null;
        public frmLibro(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            InitializeComponent();
            dgvDatos.DataSource = _bindingSource;
        }

        private void frmLibro_Load(object sender, EventArgs e)
        {
            RecargarGrilla();
        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var bombonServicio = scope.ServiceProvider
                    .GetRequiredService<ILibroServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = bombonServicio
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

                    _estado.Actualizar(resultado.CantidadRegistros);

                    if (_estado.PaginaActual != paginaSolicitada)
                    {
                        resultadoConsulta = bombonServicio
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

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmLibroAe frm = scope.ServiceProvider.GetRequiredService<frmLibroAe>())
                {
                    frm.Text = "Nuevo Tipo de Libro";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;
                        bool sePuedeVer = filtroActivo is null || filtroActivo == true;
                        if (sePuedeVer)
                        {
                            var tipoServicio = scope.ServiceProvider
                                .GetRequiredService<ILibroServicio>();
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
                                .Cast<LibroListDto>()
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

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                _servicioMensajes.Advertencia("Debe seleccionar una fila");
                return;
            }
            LibroListDto libroListDto = (LibroListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                var libroServicio = scope.ServiceProvider
                        .GetRequiredService<ILibroServicio>();
                var resultadoConsulta = libroServicio.ObtenerParaBorrar(libroListDto.ProductoId);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    return;

                }
                var libroDeleteDto = resultadoConsulta.Value;
                if (!_servicioMensajes.Confirmar($"¿Desea borrar el libro {libroListDto.Titulo}?")) return;
                if (libroDeleteDto is null) return;
                try
                {
                    var resultadoEliminacion = libroServicio
                        .Borrar(libroDeleteDto);
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

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (_bindingSource.Current == null)
            {
                MessageBox.Show("Debe seleccionar una fila de la grilla",
                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var libroListDto = (LibroListDto)_bindingSource.Current;
            var seleccionadoId = libroListDto.ProductoId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var libroServicio = scope.ServiceProvider
                .GetRequiredService<ILibroServicio>();
                    var resultadoConsulta = libroServicio
                        .ObtenerParaEditar(libroListDto.ProductoId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var libroEditDto = resultadoConsulta.Value;
                    using (frmLibroAe frm = scope.ServiceProvider
                        .GetRequiredService<frmLibroAe>())
                    {
                        frm.Text = "Editar Libro";
                        frm.SetLibro(libroEditDto);
                        frm.ShowDialog();
                        var libroEditado = frm.GetLibro();
                        if (libroEditado is null) return;
                        bool sePuedeVer = filtroActivo is null ||
                            filtroActivo == libroEditado.Activo;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = libroServicio
                                .ObtenerPaginaRegistro(seleccionadoId, _estado.RegistrosPorPagina,
                                filtroActivo);
                            if (resultadoPagina.IsFailure)
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
                                .Cast<LibroListDto>()
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

        private void tsbBuscar_Click(object sender, EventArgs e)
        {
            textoBuscar = txtBuscar.Text.Trim();
            if (string.IsNullOrWhiteSpace(textoBuscar))
            {
                textoBuscar = null;
            }
            tsbBuscar.BackColor = Color.Orange;
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroActivo = null;
            textoBuscar = null;
            txtBuscar.Text = string.Empty;
            tsbBuscar.BackColor = SystemColors.Control;
            toolStripLabel1.BackColor = SystemColors.Control;

            ActualizarInformacion();
        }

        private void activoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            toolStripLabel1.BackColor = Color.Orange;
            ActualizarInformacion();
        }

        private void noActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
            toolStripLabel1.BackColor = Color.Orange;
            ActualizarInformacion();
        }

        private void ActualizarInformacion()
        {
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void tsbDetalles_Click(object sender, EventArgs e)
        {

        }
    }
}
