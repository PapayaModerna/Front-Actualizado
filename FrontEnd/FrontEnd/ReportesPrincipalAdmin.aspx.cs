using FrontEnd.ReporteGeneralWS;
using FrontEnd.SedeWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class ReportesAdmin : System.Web.UI.Page
    {
        private SedeWSClient sedeWSClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            sedeWSClient = new SedeWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
                CargarAnios();
                CargarMeses();
            }
        }

        private void CargarSedes()
        {
            var sedes = sedeWSClient.listarSedes();
            ddlSede.DataSource = sedes;
            ddlSede.DataTextField = "nombre";
            ddlSede.DataValueField = "idSede";
            ddlSede.DataBind();

            ddlSede.Items.Insert(0, new ListItem("Todas las sedes", "0"));
        }

        private void CargarAnios()
        {
            ddlAnho.Items.Clear();
            int anhoActual = DateTime.Now.Year;
            for (int anho = anhoActual; anho >= anhoActual - 24; anho--)
            {
                ddlAnho.Items.Add(new ListItem(anho.ToString(), anho.ToString()));
            }
        }

        private void CargarMeses()
        {
            ddlMes.Items.Clear();
            ddlMes.Items.Add(new ListItem("Todos los meses", "0"));
            for (int mes = 1; mes <= 12; mes++)
            {
                ddlMes.Items.Add(new ListItem(mes.ToString("D2"), mes.ToString()));
            }
        }

        protected void btnGenerarReporteGeneral_Click(object sender, EventArgs e)
        {
            int sedeId = int.Parse(ddlSede.SelectedValue);
            int anho = int.Parse(ddlAnho.SelectedValue);
            int mes = int.Parse(ddlMes.SelectedValue);

            var reporteWSClient = new ReporteGeneralWSClient();
            byte[] reporte = reporteWSClient.reporteGeneral(sedeId, anho, mes);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=ReporteGeneral.pdf");
            Response.BinaryWrite(reporte);
            Response.End();
        }

        protected void btnMaterialesMasSolicitados_Click(object sender, EventArgs e)
        {
            int sedeId = int.Parse(ddlSede.SelectedValue);
            int anho = int.Parse(ddlAnho.SelectedValue);
            int mes = int.Parse(ddlMes.SelectedValue);

            var reporteWSClient = new ReporteGeneralWSClient();
            byte[] reporte = reporteWSClient.reporteMaterialesSolicitados(sedeId, anho, mes);

            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=MaterialesMasSolicitados.pdf");
            Response.BinaryWrite(reporte);
            Response.End();
        }
    }
}