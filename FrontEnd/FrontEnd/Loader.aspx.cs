using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class Loader : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["redireccion"] == null)
            {
                Response.Redirect("~/LoginBiblio.aspx");
                return;
            }
            if (!IsPostBack)
            {
                string destino = Session["redireccion"].ToString();
                hfRedireccion.Value = ResolveUrl(destino); // Convierte "~" a ruta válida
            }
        }
    }
}