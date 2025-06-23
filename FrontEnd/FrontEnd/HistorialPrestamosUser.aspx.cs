using System;
using System.Web.UI;
using FrontEnd.PrestamoWS;

namespace FrontEnd
{
    public partial class HistorialPrestamosUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPersona"] == null)
                {
                    Response.Redirect("LoginBiblio.aspx");
                    return;
                }
                int idPersona = Convert.ToInt32(Session["idPersona"]);
                var ws = new PrestamoWSClient();
                var prestamos = ws.listarPrestamosPorPersona(idPersona);
                gvHistorialPrestamos.DataSource = prestamos;
                gvHistorialPrestamos.DataBind();
            }
        }
    }
}
