using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.PersonaWS;

namespace FrontEnd
{
    public partial class AdminBiblio : System.Web.UI.MasterPage
    {
        public string BodyCssClass { get; set; } = "default-body";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("LoginBiblio.aspx");
            }
            if (Session["usuario"] != null && !IsPostBack)
            {
                var persona = (personasDTO)Session["usuario"];
                lblNombreMaster.InnerText = persona.nombre + " " + persona.paterno;
                string inicial = persona.nombre.Substring(0, 1).ToUpper();
                lblInicial.InnerText = inicial;
            }
        }
    }
}