using Microsoft.Extensions.DependencyInjection;
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
    public partial class frmEditoriales : Form
    {
        private readonly IServiceProvider _serviceProvider;

        private BindingSource _bindingSource = new BindingSource();
        private ServicioMensajes _servicioMensajes = new ServicioMensajes();
        private EstadoNavegacion _estado = new(10);
        private string campoOrdenar = "Nombre";
        private bool esAscendente = true;
        private bool? filtroActivo = null;
        private string? textoBuscar = null;


        public frmEditoriales(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            dgvDatos.DataSource = _bindingSource;
        }

        private void tsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmEditoriales_Load(object sender, EventArgs e)
        {
            RecargarGrilla();

        }

        private void RecargarGrilla()
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var tipoBombonesServicio = scope.ServiceProvider
                    .GetRequiredService<IEditorialServicio>();

                try
                {
                    int paginaSolicitada = _estado.PaginaActual;

                    var resultadoConsulta = tipoBombonesServicio
                        .ObtenerPagina(
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
                        resultadoConsulta = tipoBombonesServicio
                            .ObtenerPagina(
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

                    if (dgvDatos.Columns.Count == 0 && resultado.Items.Count > 0)
                    {
                        dgvDatos.AutoGenerateColumns = true;
                    }

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
        private void ActualizarNavegacion()
        {
            lblCantidad.Text = _estado.TextoRegistros();
            lblPaginas.Text = _estado.TextoPaginas();

            btnPrimero.Enabled = _estado.PuedeIrAnterior();
            btnAnterior.Enabled = _estado.PuedeIrAnterior();
            btnSiguiente.Enabled = _estado.PuedeIrSiguiente();
            btnUltimo.Enabled = _estado.PuedeIrSiguiente();

        }

        private void activoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = true;
            tsbFiltrar.BackColor = Color.Orange;
            ActualizarInformacion();

        }

        private void ActualizarInformacion()
        {
            _estado.PaginaActual = 1;
            RecargarGrilla();
        }

        private void noActivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filtroActivo = false;
            tsbFiltrar.BackColor = Color.Orange;
            ActualizarInformacion();

        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                using (frmEditorialAe frm = scope.ServiceProvider.GetRequiredService<frmEditorialAe>())
                {
                    frm.Text = "Nuevo Editorial";
                    frm.ShowDialog();
                    if (frm.DataChanged)
                    {
                        var nuevoId = frm.UltimoId;
                        bool sePuedeVer = filtroActivo is null || filtroActivo == true;
                        if (sePuedeVer)
                        {
                            var tipoServicio = scope.ServiceProvider
                                .GetRequiredService<IEditorialServicio>();
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
                                .Cast<EditorialListDto>()
                                .FirstOrDefault(tp => tp.EditorialId == nuevoId);
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
            EditorialListDto tipoListDto = (EditorialListDto)_bindingSource.Current;
            using (var scope = _serviceProvider.CreateScope())
            {
                var tipoBombonServicio = scope.ServiceProvider
                        .GetRequiredService<IEditorialServicio>();
                var resultadoConsulta = tipoBombonServicio.ObtenerParaBorrar(tipoListDto.EditorialId);
                if (resultadoConsulta.IsFailure)
                {
                    ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                    return;

                }
                var tipoDeleteDto = resultadoConsulta.Value;
                if (!_servicioMensajes.Confirmar($"¿Desea borrar el tipo {tipoListDto.Nombre}?")) return;
                try
                {
                    var resultadoEliminacion = tipoBombonServicio
                        .Borrar(tipoDeleteDto!);
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
            var tipoListDto = (EditorialListDto)_bindingSource.Current;
            var seleccionadoId = tipoListDto.EditorialId;
            using (var scope = _serviceProvider.CreateScope())
            {
                try
                {
                    var tipoBombonesServicio = scope.ServiceProvider
                .GetRequiredService<IEditorialServicio>();
                    var resultadoConsulta = tipoBombonesServicio
                        .ObtenerParaEditar(tipoListDto.EditorialId);
                    if (resultadoConsulta.IsFailure)
                    {
                        ErrorHelper.MostrarErrores(resultadoConsulta.Errors);
                        return;
                    }
                    var editorialEditDto = resultadoConsulta.Value;
                    using (frmEditorialAe frm = scope.ServiceProvider
                        .GetRequiredService<frmEditorialAe>())
                    {
                        frm.Text = "Editar Editorial";
                        frm.SetEditorial(editorialEditDto);
                        frm.ShowDialog();
                        var editorialEditado = frm.GetEditorial();
                        if (editorialEditado is null) return;
                        bool sePuedeVer = filtroActivo is null ||
                            filtroActivo == editorialEditado.Activo;

                        if (sePuedeVer)
                        {
                            var resultadoPagina = tipoBombonesServicio
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
                                .Cast<EditorialListDto>()
                                .FirstOrDefault(tb => tb.EditorialId == seleccionadoId);
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

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            filtroActivo = null;
            textoBuscar = null;
            txtBuscar.Text = string.Empty;
            tsbFiltrar.BackColor = SystemColors.Control;
            tsbBuscar.BackColor = SystemColors.Control;

            ActualizarInformacion();
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
    }
}
