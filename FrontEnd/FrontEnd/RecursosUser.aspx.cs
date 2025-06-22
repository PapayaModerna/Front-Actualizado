using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;

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
    }
}