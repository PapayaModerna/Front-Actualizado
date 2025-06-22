using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.PrestamoWS;
namespace FrontEnd
{
    public partial class PrestamosPrincipalAdmin : System.Web.UI.Page
    {
        private PrestamoWSClient prestamoWSClient;
        protected void Page_Init(object sender, EventArgs e)
        {
            prestamoWSClient = new PrestamoWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rptTotales.DataSource = null;
                rptTotales.DataBind();
                lblSinResultadosTotales.Visible = false;
                rptPaginacionTotales.DataSource = null;
                rptPaginacionTotales.DataBind();

                rptAtrasados.DataSource = null;
                rptAtrasados.DataBind();
                lblSinResultadosAtrasados.Visible = false;
                rptPaginacionAtrasados.DataSource = null;
                rptPaginacionAtrasados.DataBind();

                rptSolicitados.DataSource = null;
                rptSolicitados.DataBind();
                lblSinResultadosSolicitados.Visible = false;
                rptPaginacionSolicitados.DataSource = null;
                rptPaginacionSolicitados.DataBind();
            }
        }
        protected void txtBuscarTotales_TextChanged(object sender, EventArgs e)
        {
            ViewState["PaginaActualTotales"] = 1;
            CargarPrestamosTotales(1, txtBuscarTotales.Text.Trim());
        }
        protected void lnkPaginaTotales_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int pagina = int.Parse(btn.CommandArgument);
            ViewState["PaginaActualTotales"] = pagina;
            CargarPrestamosTotales(pagina, txtBuscarTotales.Text.Trim());
        }
        protected void btnBuscarTotales_Click(object sender, EventArgs e)
        {
            ViewState["PaginaActualTotales"] = 1;
            CargarPrestamosTotales(1, txtBuscarTotales.Text.Trim());
        }
        private void CargarPrestamosTotales(int pagina,string filtro)
        {
            try
            {
                var prestamosWS = prestamoWSClient.listarPrestamosPaginado(10, pagina);

                var lista = prestamosWS
                    .Select(p => new
                    {
                        idPrestamo = p.idPrestamo,
                        fechaSolicitud = p.fechaSolicitudSpecified ? p.fechaSolicitud.ToString("yyyy-MM-dd") : "Sin fecha",
                        fechaPrestamo = p.fechaPrestamoSpecified ? p.fechaPrestamo.ToString("yyyy-MM-dd") : "Sin fecha",
                        fechaDevolucion = p.fechaDevolucionSpecified ? p.fechaDevolucion.ToString("yyyy-MM-dd") : "Sin fecha",
                        Estado = prestamoWSClient.obtenerEstadoPrestamo(p.idPrestamo) ?? "Desconocido"
                    })
                    .ToList();

                rptTotales.DataSource = lista;
                rptTotales.DataBind();

                lblSinResultadosTotales.Visible = lista.Count == 0;

                // Paginación ficticia simple (ejemplo)
                var paginas = Enumerable.Range(1, 5).Select(i => new { NumeroPagina = i }).ToList();
                rptPaginacionTotales.DataSource = paginas;
                rptPaginacionTotales.DataBind();
            }
            catch (Exception)
            {
                rptTotales.DataSource = null;
                rptTotales.DataBind();
                lblSinResultadosTotales.Visible = true;
            }
        }
        protected void txtBuscarAtrasados_TextChanged(object sender, EventArgs e)
        {
            ViewState["PaginaActualAtrasados"] = 1;
            CargarPrestamosAtrasados(1);
        }
        protected void btnBuscarAtrasados_Click(object sender, EventArgs e)
        {
            ViewState["PaginaActualAtrasados"] = 1;
            CargarPrestamosAtrasados(1);
        }

        protected void lnkPaginaAtrasados_Click(object sender, EventArgs e)
        {
            int pagina = int.Parse(((LinkButton)sender).CommandArgument);
            ViewState["PaginaActualAtrasados"] = pagina;
            CargarPrestamosAtrasados(pagina);
        }

        private void CargarPrestamosAtrasados(int pagina)
        {
            try
            {
                var prestamos = prestamoWSClient.listarPrestamosPorEstadoPaginado(estadoPrestamoEjemplar.ATRASADO, 10, pagina);

                var lista = prestamos
                    .Select(p => new
                    {
                        idPrestamo = p.idPrestamo,
                        fechaSolicitud = p.fechaSolicitudSpecified ? p.fechaSolicitud.ToString("yyyy-MM-dd") : "Sin fecha",
                        fechaPrestamo = p.fechaPrestamoSpecified ? p.fechaPrestamo.ToString("yyyy-MM-dd") : "Sin fecha",
                        fechaDevolucion = p.fechaDevolucionSpecified ? p.fechaDevolucion.ToString("yyyy-MM-dd") : "Sin fecha",
                    })
                    .ToList();

                rptAtrasados.DataSource = lista;
                rptAtrasados.DataBind();
                lblSinResultadosAtrasados.Visible = lista.Count == 0;

                var paginas = Enumerable.Range(1, 5).Select(i => new { NumeroPagina = i }).ToList();
                rptPaginacionAtrasados.DataSource = paginas;
                rptPaginacionAtrasados.DataBind();
            }
            catch
            {
                rptAtrasados.DataSource = null;
                rptAtrasados.DataBind();
                lblSinResultadosAtrasados.Visible = true;
            }
        }

        protected void txtBuscarSolicitados_TextChanged(object sender, EventArgs e)
        {
            ViewState["PaginaActualSolicitados"] = 1;
            CargarPrestamosSolicitados(1);
        }

        protected void btnBuscarSolicitados_Click(object sender, EventArgs e)
        {
            ViewState["PaginaActualSolicitados"] = 1;
            CargarPrestamosSolicitados(1);
        }

        protected void lnkPaginaSolicitados_Click(object sender, EventArgs e)
        {
            int pagina = int.Parse(((LinkButton)sender).CommandArgument);
            ViewState["PaginaActualSolicitados"] = pagina;
            CargarPrestamosSolicitados(pagina);
        }

        private void CargarPrestamosSolicitados(int pagina)
        {
            try
            {
                var prestamos = prestamoWSClient.listarPrestamosPorEstadoPaginado(estadoPrestamoEjemplar.SOLICITADO, 10, pagina);

                var lista = prestamos
                    .Select(p => new
                    {
                        idPrestamo = p.idPrestamo,
                        fechaSolicitud = p.fechaSolicitudSpecified ? p.fechaSolicitud.ToString("yyyy-MM-dd") : "Sin fecha",
                        fechaPrestamo = p.fechaPrestamoSpecified ? p.fechaPrestamo.ToString("yyyy-MM-dd") : "Sin fecha",
                        fechaDevolucion = p.fechaDevolucionSpecified ? p.fechaDevolucion.ToString("yyyy-MM-dd") : "Sin fecha",
                    })
                    .ToList();

                rptSolicitados.DataSource = lista;
                rptSolicitados.DataBind();
                lblSinResultadosSolicitados.Visible = lista.Count == 0;

                var paginas = Enumerable.Range(1, 5).Select(i => new { NumeroPagina = i }).ToList();
                rptPaginacionSolicitados.DataSource = paginas;
                rptPaginacionSolicitados.DataBind();
            }
            catch
            {
                rptSolicitados.DataSource = null;
                rptSolicitados.DataBind();
                lblSinResultadosSolicitados.Visible = true;
            }
        }

        /*protected void btnBuscarSolicitados_Click(object sender, EventArgs e)
        {
            var lista = new List<dynamic>
            {
                new { ID = "301", Libro = "Solicitud nueva" },
                new { ID = "302", Libro = "Pendiente revisión" }
            };
            rptSolicitados.DataSource = lista;
            rptSolicitados.DataBind();
            pnlSolicitados.Visible = true;
        }

        protected void btnBuscarNoCulminados_Click(object sender, EventArgs e)
        {
            var lista = new List<dynamic>
            {
                new { ID = "401", Libro = "En renovación" },
                new { ID = "402", Libro = "Entrega parcial" }
            };
            rptNoCulminados.DataSource = lista;
            rptNoCulminados.DataBind();
            pnlNoCulminados.Visible = true;
        }

        protected void btnBuscarCulminados_Click(object sender, EventArgs e)
        {
            var lista = new List<dynamic>
            {
                new { ID = "501", Libro = "Devuelto sin observaciones" },
                new { ID = "502", Libro = "Culminado correctamente" }
            };
            rptCulminados.DataSource = lista;
            rptCulminados.DataBind();
            pnlCulminados.Visible = true;
        }*/
    }
}