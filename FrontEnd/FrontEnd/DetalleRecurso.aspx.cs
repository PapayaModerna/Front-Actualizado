using System;
using FrontEnd.MaterialWS;
using FrontEnd.TemaWS;
using FrontEnd.NivelInglesWS;
using FrontEnd.EditorialWS;
using FrontEnd.CreadorWS;

namespace FrontEnd
{
    public partial class DetalleRecurso : System.Web.UI.Page
    {
        private MaterialWSClient materialswsClient;
        private NivelInglesWSClient nivelIngleswsClient;
        private EditorialWSClient editorialwsClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialswsClient = new MaterialWSClient();
            nivelIngleswsClient = new NivelInglesWSClient();
            editorialwsClient = new EditorialWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idMaterial = Request.QueryString["idMaterial"];
                if (!string.IsNullOrEmpty(idMaterial))
                {
                    var material = materialswsClient.obtenerPorId(Convert.ToInt32(idMaterial));

                    detalleTitulo.Text = material.titulo;
                    detalleAnio.Text = material.anioPublicacion.ToString();
                    detalleEditorial.Text = editorialwsClient.obtenerEditorial(material.editorial.idEditorial).nombre;
                    /*detalleCreador.Text = string.IsNullOrEmpty(material.creador) ? "Anónimo" : material.creador;*/
                    /*detalleNivel.Text = nivelIngleswsClient.obtenerNivelPorId(material.nivel.idNivel).nivel;*/
                    detalleStock.Text = materialswsClient.contarDisponiblesFisicosPorMaterial(Convert.ToInt32(idMaterial)) > 0 ? "Disponible" : "No disponible";
                }
            }
        }
        protected void btnVerEjemplares_Click(object sender, EventArgs e)
        {
            string idMaterial = Request.QueryString["idMaterial"];

            string script = $"window.location.href='EjemplaresMaterialUser.aspx?idMaterial={idMaterial}';";
            ClientScript.RegisterStartupScript(this.GetType(), "redirect", script, true);
        }
    }
}