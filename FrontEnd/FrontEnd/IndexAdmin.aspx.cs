using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;
using FrontEnd.SedeWS;
using FrontEnd.EjemplarWS;
namespace FrontEnd
{
    public partial class IndexAdmin : System.Web.UI.Page
    {
        private MaterialWSClient materialWSClient;
        private SedeWSClient sedeWSClient;
        private EjemplarWSClient ejemplarWSClient;
        private const int CantidadPagina = 10;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialWSClient = new MaterialWSClient();
            sedeWSClient = new SedeWSClient();
            ejemplarWSClient= new EjemplarWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["Filtro"] = "";
                ViewState["PaginaActual"] = 1;
                ViewState["MostrarTabla"] = false;
                CargarSedes();
                actualizarTituloSede();
                int totalLibros = materialWSClient.contarMateriales();
                int totalEjemplares=0;
                int[] sedesIds = { 1, 2, 3 };
                foreach (int sedeId in sedesIds)
                {
                    var ejemplaresPorSede = ejemplarWSClient.contarTotalPorSede(sedeId);
                    totalEjemplares += ejemplaresPorSede;
                }
                lblCantidadLibros.Text = $"{totalLibros} Libros";
                lblCantidadEjemplares.Text = $"{totalEjemplares} Ejemplares físicos y digitales";
            }
            else
            {
                if ((bool)ViewState["MostrarTabla"])
                {
                    int paginaActual = (int)ViewState["PaginaActual"];
                    CargarLibros(paginaActual);
                }
            }
        }
        protected void ddlSedes_SelectedIndexChanged(object sender, EventArgs e)
        {
            actualizarTituloSede();
            int idSede = int.Parse(ddlSedes.SelectedValue);
            int totalLibros = 0;
            int totalEjemplares = 0;
            if (idSede == 0)
            {
                totalLibros = materialWSClient.contarMateriales();
                int[] sedesIds = { 1, 2, 3 };
                foreach (int sedeId in sedesIds)
                {
                    var ejemplaresPorSede = ejemplarWSClient.contarTotalPorSede(sedeId);
                    totalEjemplares += ejemplaresPorSede;
                }
            }
            else
            {
                totalLibros = materialWSClient.contarMaterialesPorSede(idSede);
                totalEjemplares = ejemplarWSClient.contarTotalPorSede(idSede);
            }
            lblCantidadLibros.Text = $"{totalLibros} Libros";
            lblCantidadEjemplares.Text = $"{totalEjemplares} Ejemplares físicos y digitales";
            ViewState["PaginaActual"] = 1;
            ViewState["MostrarTabla"] = false;
            rptLibros.DataSource = null;
            rptLibros.DataBind();
            lblSinResultados.Visible = false;

            rptPaginacion.DataSource = null;
            rptPaginacion.DataBind();
        }
        private void actualizarTituloSede()
        {
            string sedeSeleccionada = ddlSedes.SelectedItem.Text;

            if (!string.IsNullOrEmpty(sedeSeleccionada) && sedeSeleccionada.ToLower().Contains("general"))
                lblTituloSede.Text = "Sede General";
            else
                lblTituloSede.Text = "Sede: " + sedeSeleccionada;
        }
        private void CargarSedes()
        {
            var sedes = sedeWSClient.listarSedes(); 
            ddlSedes.DataSource = sedes;
            ddlSedes.DataTextField = "nombre";   
            ddlSedes.DataValueField = "idSede";      
            ddlSedes.DataBind();

            ddlSedes.Items.Insert(0, new ListItem("Todas las sedes", "0")); 
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ViewState["Filtro"] = txtBuscar.Text.Trim();
            ViewState["PaginaActual"] = 1;
            ViewState["MostrarTabla"] = true;
            CargarLibros(1);
        }
        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ViewState["Filtro"] = txtBuscar.Text.Trim();
            ViewState["PaginaActual"] = 1;
            ViewState["MostrarTabla"] = true;
            CargarLibros(1);
        }
        protected void lnkPagina_Click(object sender, EventArgs e)
        {
            int paginaSeleccionada = int.Parse(((LinkButton)sender).CommandArgument);
            ViewState["PaginaActual"] = paginaSeleccionada;
            ViewState["MostrarTabla"] = true;
            CargarLibros(paginaSeleccionada);
        }

        private void CargarLibros(int pagina)
        {
            string filtro = ViewState["Filtro"].ToString();
            int idSede = int.Parse(ddlSedes.SelectedValue);
            bool porTitulo = !string.IsNullOrEmpty(filtro);
            Session["idSede"] = idSede;

            List<FrontEnd.MaterialWS.materialesDTO> libros;
            int total = 0;

            if (idSede == 0)
            {
                if (porTitulo)
                {
                    var todos = materialWSClient.listarMaterialPorTitulo(filtro, 1000, 1);
                    if (todos != null)
                    {
                        total = todos.Length;
                        libros = todos.Skip((pagina - 1) * CantidadPagina).Take(CantidadPagina).ToList();
                    }
                    else
                    {
                        total = 0;
                        libros = new List<FrontEnd.MaterialWS.materialesDTO>();
                    }
                }
                else
                {
                    libros = materialWSClient.listarMaterialesPaginado(CantidadPagina, pagina).ToList();
                    total = materialWSClient.contarMateriales();
                }
            }
            else 
            {
                var todos = materialWSClient.listarMaterialesPorTituloParcialPaginado(filtro,idSede, 1000, 1);
                if (todos != null)
                {
                    total = todos.Length;
                    libros = todos.Skip((pagina - 1) * CantidadPagina).Take(CantidadPagina).ToList();
                }
                else
                {
                    total = 0;
                    libros = new List<FrontEnd.MaterialWS.materialesDTO>();
                }
            }
            rptLibros.DataSource = libros;
            rptLibros.DataBind();
            lblSinResultados.Visible = (libros.Count == 0);
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