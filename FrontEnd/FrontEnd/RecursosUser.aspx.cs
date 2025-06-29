using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;
using FrontEnd.CreadorWS;
using FrontEnd.TemaWS;
using FrontEnd.NivelInglesWS;
using System.Diagnostics;

namespace FrontEnd
{
    public partial class RecursosUser : System.Web.UI.Page
    {
        private MaterialWSClient materialwsClient;
        private CreadorWSClient creadorwsClient;
        private TemaWSClient temawsClient;
        private NivelInglesWSClient nivelIngleswsClient;

        private const int CantidadPagina = 10;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialwsClient = new MaterialWSClient();
            creadorwsClient = new CreadorWSClient();
            temawsClient = new TemaWSClient();
            nivelIngleswsClient = new NivelInglesWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDDLS();
                ViewState["Filtro"] = "";
                ViewState["PaginaActual"] = 1;
                CargarResultados(1);
            }
        }
        protected void realizarBusqueda(object sender, EventArgs e)
        {
            CargarResultados(1); 
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            ViewState["Filtro"] = txtBusqueda.Text.Trim();
            ViewState["PaginaActual"] = 1;
            CargarResultados(1);
        }

        private void LlenarDDLS()
        {
            var temas = temawsClient.listarNombresTemas();
            ddlTemas.Items.Clear();
            ddlTemas.Items.Insert(0, new ListItem("Temas", ""));
            foreach (var tema in temas)
            {
                ListItem item = new ListItem(tema.descripcion, tema.idTema.ToString());
                ddlTemas.Items.Add(item);
            }

            var autores = creadorwsClient.listarNombresAutores();
            ddlAutor.Items.Clear();
            ddlAutor.Items.Insert(0, new ListItem("Autores", ""));
            foreach (var autor in autores)
            {
                ListItem item = new ListItem(autor.seudonimo, autor.idCreador.ToString());
                ddlAutor.Items.Add(item);
            }

            var niveles = nivelIngleswsClient.listarNombresNiveles();
            ddlNivel.Items.Clear();
            ddlNivel.Items.Insert(0, new ListItem("Niveles", ""));
            foreach (var nivel in niveles)
            {
                ListItem item = new ListItem(nivel.nivel.ToString(), nivel.idNivel.ToString());
                ddlNivel.Items.Add(item);
            }
        }

        protected void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ViewState["Filtro"] = txtBusqueda.Text.Trim();
            ViewState["PaginaActual"] = 1;
            CargarResultados(1);
        }

        protected void CargarResultados(int pagina)
        {
            int idTema = string.IsNullOrEmpty(ddlTemas.SelectedValue) ? -1 : Convert.ToInt32(ddlTemas.SelectedValue);
            int idAutor = string.IsNullOrEmpty(ddlAutor.SelectedValue) ? -1 : Convert.ToInt32(ddlAutor.SelectedValue);
            int idNivel = string.IsNullOrEmpty(ddlNivel.SelectedValue) ? -1 : Convert.ToInt32(ddlNivel.SelectedValue);

            string filtro = string.IsNullOrWhiteSpace(txtBusqueda.Text) ? "" : txtBusqueda.Text.Trim();

            int totalPorPagina = materialwsClient.contarMaterialesUsuario(idTema, idAutor, idNivel, filtro);
            int totalPaginas = (int)Math.Ceiling((double)totalPorPagina / CantidadPagina);
            var paginas = Enumerable.Range(1, totalPaginas)
                                    .Select(n => new { NumeroPagina = n })
                                    .ToList();

            rptPaginacion.DataSource = paginas;
            rptPaginacion.DataBind();

            var resultados = materialwsClient.buscarMaterialesUsuario(idTema, idAutor, idNivel, filtro, CantidadPagina, pagina);
            if (resultados != null && resultados.Length > 0)
            {
                resultadosBusquedaContainer.Visible = true;
                resultadosBusquedaContainer.Style["display"] = "block";
                rptResultados.DataSource = resultados;
                rptResultados.DataBind();
            }
            else
            {
                resultadosBusquedaContainer.Visible = false;
            }
        }

        protected void lnkPagina_Click(object sender, EventArgs e)
        {
            int paginaSeleccionada = int.Parse(((LinkButton)sender).CommandArgument);
            ViewState["PaginaActual"] = paginaSeleccionada;
            CargarResultados(paginaSeleccionada);
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
