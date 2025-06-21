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
        private const int CantidadPagina = 10;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialWSClient = new MaterialWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Filtro"] = "";
                ViewState["PaginaActual"] = 1;
                CargarLibros(1);
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ViewState["Filtro"] = txtBuscar.Text.Trim();
            ViewState["PaginaActual"] = 1;
            CargarLibros(1);
        }
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ViewState["Filtro"] = txtBuscar.Text.Trim();
            ViewState["PaginaActual"] = 1;
            CargarLibros(1);
        }
        protected void lnkPagina_Click(object sender, EventArgs e)
        {
            int paginaSeleccionada = int.Parse(((LinkButton)sender).CommandArgument);
            ViewState["PaginaActual"] = paginaSeleccionada;
            CargarLibros(paginaSeleccionada);
        }

        private void CargarLibros(int pagina)
        {
            string filtro = ViewState["Filtro"].ToString();
            List<materialesDTO> libros;
            int total = 0;

            if (!string.IsNullOrEmpty(filtro))
            {
                var todos = materialWSClient.listarMaterialPorCaracteres(filtro, 1000, 1);
                total = todos.Length;
                libros = todos.Skip((pagina - 1) * CantidadPagina).Take(CantidadPagina).ToList();
            }
            else
            {
                libros = materialWSClient.listarMaterialesPaginado(CantidadPagina, pagina).ToList();
                total = materialWSClient.contarMateriales();
            }

            rptLibros.DataSource = libros;
            rptLibros.DataBind();

            CargarPaginacion(total);
        }
        private void CargarPaginacion(int totalMateriales)
        {
            int totalPaginas = (int)Math.Ceiling((double)totalMateriales / CantidadPagina);
            var paginas = Enumerable.Range(1, totalPaginas)
                                    .Select(n => new { NumeroPagina = n })
                                    .ToList();

            rptPaginacion.DataSource = paginas;
            rptPaginacion.DataBind();
        }
    }
}