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
                pnlTotales.Visible = false;
                pnlAtrasados.Visible = false;
                pnlSolicitados.Visible = false;
                pnlNoCulminados.Visible = false;
                pnlCulminados.Visible = false;
            }
        }
        protected void btnBuscarTotales_Click(object sender, EventArgs e)
        {
            try
            {
                var prestamosWS = prestamoWSClient.listarPrestamosPaginado(10, 1);

                var lista = prestamosWS.Select(p => new {
                    idPrestamo = p.idPrestamo.ToString("D3"),
                    FechaSolicitud = p.fechaSolicitudSpecified ? p.fechaSolicitud.ToString("yyyy-MM-dd") : "Sin fecha",
                    FechaPrestamo = p.fechaPrestamoSpecified ? p.fechaPrestamo.ToString("yyyy-MM-dd") : "Sin fecha",
                    FechaDevolucion = p.fechaDevolucionSpecified ? p.fechaDevolucion.ToString("yyyy-MM-dd") : "Sin fecha",
                    IdPersona = p.persona?.idPersona.ToString() ?? "Sin persona"
                }).ToList();

                rptTotales.DataSource = lista;
                rptTotales.DataBind();
                pnlTotales.Visible = true;
            }
            catch (Exception ex)
            {
                pnlTotales.Visible = false;
            }
        }
        protected void btnBuscarAtrasados_Click(object sender, EventArgs e)
        {
            var lista = new List<dynamic>
            {
                new { ID = "201", Libro = "Préstamo atrasado A" },
                new { ID = "202", Libro = "Préstamo atrasado B" }
            };
            rptAtrasados.DataSource = lista;
            rptAtrasados.DataBind();
            pnlAtrasados.Visible = true;
        }

        protected void btnBuscarSolicitados_Click(object sender, EventArgs e)
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
        }
    }
}