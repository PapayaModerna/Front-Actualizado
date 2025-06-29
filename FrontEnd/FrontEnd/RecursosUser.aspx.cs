using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;
using FrontEnd.EjemplarWS;
using FrontEnd.PrestamoWS;

namespace FrontEnd
{
    public partial class RecursosUser : System.Web.UI.Page
    {
        private MaterialWSClient materialwsClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialwsClient = new MaterialWSClient();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDDLS();
            }
        }

        private void LlenarDDLS()
        {
           /* List<Material> temas = materialwsClient.listarNombresTemas();
            ddlTemas.DataSource = temas;
            ddlTemas.DataTextField = "Titulo";  
            ddlTemas.DataValueField = "Id";    
            ddlTemas.DataBind();
            ddlTemas.Items.Insert(0, new ListItem("Temas", ""));

            List<Material> autores = materialwsClient.listarNombresAutores();
            ddlAutor.DataSource = autores;
            ddlAutor.DataTextField = "Titulo";  
            ddlAutor.DataValueField = "Id";    
            ddlAutor.DataBind();
            ddlAutor.Items.Insert(0, new ListItem("Autores", ""));

            List<string> niveles = materialwsClient.listarNiveles(); 
            ddlNivel.DataSource = niveles;
            ddlNivel.DataBind();
            ddlNivel.Items.Insert(0, new ListItem("Niveles", ""));*/
        }

        protected void realizarBusqueda()
        {
            /*int idSede = Convert.ToInt32(ddlAutor.SelectedValue == "" ? "-1" : ddlAutor.SelectedValue);
            int idTema = Convert.ToInt32(ddlTemas.SelectedValue == "" ? "-1" : ddlTemas.SelectedValue);
            int idNivel = Convert.ToInt32(ddlNivel.SelectedValue == "" ? "-1" : ddlNivel.SelectedValue);

            string filtro = txtBusqueda.Text.Trim();
            if (string.IsNullOrEmpty(filtro)) filtro = "";

            int cantPag = 10; 
            int pag = 1; 

            var resultados = materialwsClient.buscadorUsuario(idSede, idTema, idNivel, filtro, cantPag, pag);

            if (resultados != null && resultados.Length > 0)
            {
                resultadosBusquedaContainer.Visible = true;
                resultadosBusqueda.DataSource = resultados;
                resultadosBusqueda.DataBind();
            }
            else
            {
                resultadosBusquedaContainer.Visible = false;
            }*/
        }

        [WebMethod]
        public static string BuscarMateriales(string texto, string tipo, string autor, string tema, string nivel)
        {
            string c="a";
            return c;
        }

        protected void btnBorrow_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string idMaterial = btn.CommandArgument;
            string script = $"window.location.href='EjemplaresMaterialUser.aspx?idMaterial={idMaterial}';";
            ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);
        }
    }
}
