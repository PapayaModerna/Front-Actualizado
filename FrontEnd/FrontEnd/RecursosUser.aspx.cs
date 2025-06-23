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

        [WebMethod]
        public static string ObtenerCreadores(int idMaterial)
        {
            try
            {
                var wsClient = new MaterialWSClient();
                var creadores = wsClient.listarCreadoresPorMaterial(idMaterial);

                if (creadores != null && creadores.Any())
                {
                    return string.Join(", ", creadores.Select(c =>
                        !string.IsNullOrEmpty(c.seudonimo) ? c.seudonimo : $"{c.nombre} {c.paterno}".Trim()
                    ));
                }
                return "N/A";
            }
            catch (Exception)
            {
                // En un caso real, aquí se debería registrar el error.
                return "No se pudo cargar la información.";
            }
        }

        [WebMethod]
        public static string BuscarMateriales(string texto, string tipo)
        {
            try
            {
                var wsClient = new MaterialWSClient();
                int limite = 12; // cantidad máxima de resultados
                int pagina = 1;
                var materiales = tipo == "autor"
                    ? wsClient.listarPorAutor(texto, limite, pagina)
                    : wsClient.listarMaterialPorTitulo(texto, limite, pagina);

                if (materiales == null || materiales.Length == 0)
                {
                    return "<div class='alert alert-warning'>No se encontraron resultados para la búsqueda.</div>";
                }

                // Generar HTML de resultados
                var html = "<div class='row g-3'>";
                foreach (var mat in materiales)
                {
                    var portada = !string.IsNullOrEmpty(mat.portada) ? mat.portada : "portadaprueba.jpg";
                    var editorial = mat.editorial != null && !string.IsNullOrEmpty(mat.editorial.nombre) ? mat.editorial.nombre : "N/A";
                    var nivel = mat.nivel != null && !string.IsNullOrEmpty(mat.nivel.descripcion) ? mat.nivel.descripcion : "N/A";
                    var disponibles = mat.disponiblesFisicos;
                    var disponible = disponibles > 0;
                    var disponibilidad = disponible ? $"DISPONIBLE ({disponibles})" : "NO DISPONIBLE";
                    var btnClass = disponible ? "btn-primary" : "btn-secondary";
                    var btnDisabled = disponible ? "" : "disabled";
                    html += $@"
                    <div class='col-12 col-md-6 col-lg-4'>
                        <div class='card h-100 position-relative'>
                            <div class='card-availability'>{disponibilidad}</div>
                            <img src='Images/Portadas/{portada}' class='card-img-top card-img-top-custom' alt='Portada de {mat.titulo}' />
                            <div class='card-body card-body-custom'>
                                <h5 class='card-title card-title-custom' title='{mat.titulo}'>{mat.titulo}</h5>
                                <p class='card-author'>Editorial: {editorial}</p>
                                <p class='card-author'>Nivel: {nivel}</p>
                                <p class='card-author'>Año: {mat.anioPublicacion}</p>
                            </div>
                            <div class='card-footer-custom'>
                                <button class='btn {btnClass} btn-sm' {btnDisabled}>BORROW</button>
                                <a href='#' class='btn btn-light btn-sm'><i class='fas fa-bookmark'></i></a>
                            </div>
                        </div>
                    </div>";
                }
                html += "</div>";
                return html;
            }
            catch (Exception ex)
            {
                return $"<div class='alert alert-danger'>Error al buscar materiales: {HttpUtility.HtmlEncode(ex.Message)}</div>";
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            materialwsClient = new MaterialWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCatalogosPorNivel();
            }
        }

        private void CargarCatalogosPorNivel()
        {
            try
            {
                // Mostrar solo los primeros 4 materiales para cada nivel
                const int limite = 6;
                const int pagina = 1;

                // Nivel Básico
                var basicos = materialwsClient.listarTodosPaginadoBasico(limite, pagina).Take(4).ToList();
                rptBasico.DataSource = basicos;
                rptBasico.DataBind();

                // Nivel Intermedio
                var intermedios = materialwsClient.listarTodosPaginadoIntermedio(limite, pagina).Take(4).ToList();
                rptIntermedio.DataSource = intermedios;
                rptIntermedio.DataBind();

                // Nivel Avanzado
                var avanzados = materialwsClient.listarTodosPaginadoAvanzado(limite, pagina).Take(4).ToList();
                rptAvanzado.DataSource = avanzados;
                rptAvanzado.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar la excepción, quizás mostrando un mensaje general
                Response.Write("<script>alert('Error al cargar los catálogos: " + ex.Message + "');</script>");
            }
        }

        protected void rptMateriales_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var material = (MaterialWS.materialesDTO)e.Item.DataItem;

                var card = (System.Web.UI.HtmlControls.HtmlGenericControl)e.Item.FindControl("bookCard");
                if (card != null)
                {
                    // --- Nivel ---
                    var nivelDesc = "N/A";
                    if (material.nivel != null && !string.IsNullOrEmpty(material.nivel.descripcion))
                    {
                        nivelDesc = material.nivel.descripcion;
                    }
                    card.Attributes["data-nivel"] = nivelDesc;

                    // --- Editorial ---
                    var editorialNombre = "N/A";
                    if (material.editorial != null && !string.IsNullOrEmpty(material.editorial.nombre))
                    {
                        editorialNombre = material.editorial.nombre;
                    }
                    card.Attributes["data-editorial"] = editorialNombre;
                }

                // --- Disponibilidad ---
                var lblAvailability = (Label)e.Item.FindControl("lblAvailability");
                int disponibles = material.disponiblesFisicos;
                bool disponible = disponibles > 0;
                lblAvailability.Text = disponible ? $"DISPONIBLE ({disponibles})" : "NO DISPONIBLE";

                // --- Cover Image ---
                var imgPortada = (Image)e.Item.FindControl("imgPortada");
                imgPortada.ImageUrl = ResolveUrl("~/Images/Portadas/" + material.portada);
                imgPortada.AlternateText = material.titulo;

                // --- Botón BORROW ---
                var btnBorrow = (Button)e.Item.FindControl("btnBorrow");
                if (!disponible)
                {
                    btnBorrow.Enabled = false;
                    btnBorrow.CssClass = "btn btn-secondary btn-sm";
                }
                else
                {
                    btnBorrow.Enabled = true;
                    btnBorrow.CssClass = "btn btn-primary btn-sm";
                }
            }

        }
        protected void btnTestFueraRepeater_Click(object sender, EventArgs e)
        {
            var carrito = Session["CarritoEjemplares"] as List<int> ?? new List<int>();

            if (true)
            {
                carrito.Add(61);
                Session["CarritoEjemplares"] = carrito;

                // Actualiza contador de carrito en el master
                var master = this.Master as UserBiblio;
                master?.ActualizarCantidadCarrito();

                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('ID 2 agregado al carrito');", true);
            }
        }
        protected void lnkDetalle_Click(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica para mostrar detalle del ejemplar.
            // Por ahora, puedes poner solo un debug o redireccionamiento:
            Response.Write("<script>alert('Se hizo clic en Ver detalle');</script>");
        }
    }
}