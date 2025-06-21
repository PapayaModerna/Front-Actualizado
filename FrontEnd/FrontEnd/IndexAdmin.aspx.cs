using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;
namespace FrontEnd
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        private MaterialWSClient materialWSClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialWSClient = new MaterialWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarLibros(1);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltrarLibros();
        }
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLibros(); // Ambos métodos llaman a esta función
        }
        private void FiltrarLibros()
        {
            string filtro = txtBuscar.Text.Trim();

            if (!string.IsNullOrEmpty(filtro))
            {
                var resultado = materialWSClient.listarMaterialPorCaracteres(filtro, 10, 1);
                rptLibros.DataSource = resultado;
                rptLibros.DataBind();
            }
            else
            {
                CargarLibros(1);
            }
        }
        private void CargarLibros(int pagina)
        {
            var libros = materialWSClient.listarMaterialesPaginado(10, pagina);
            rptLibros.DataSource = libros;
            rptLibros.DataBind();
        }
    }
}