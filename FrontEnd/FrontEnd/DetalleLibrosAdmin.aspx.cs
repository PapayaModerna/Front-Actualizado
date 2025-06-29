using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;
using FrontEnd.EjemplarWS;

namespace FrontEnd
{
    public partial class DetalleLibrosAdmin : System.Web.UI.Page
    {
        private MaterialWSClient materialWSClient;
        private EjemplarWSClient ejemplarWSClient;
        int cantidadEjemplaresDisponibles;
        int cantidadNoDisponible;
        int cantidadEjemplares;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialWSClient = new MaterialWSClient();
            ejemplarWSClient = new EjemplarWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDetalle();
                
            }
        }
        private void CargarDetalle()
        {
            string idStr = Request.QueryString["id"];
            if (int.TryParse(idStr, out int id))
            {
                var libro = materialWSClient.obtenerPorId(id);
                var editorialCliente = new EditorialWS.EditorialWSClient();
                

                if (libro != null)
                {
                    lblId.Text = libro.idMaterial.ToString("000");
                    lblTitulo.Text = libro.titulo;
                    lblAnio.Text = libro.anioPublicacion.ToString() ?? "-";
                    lblEdicion.Text = libro.edicion ?? "-";
                    var editorial = editorialCliente.obtenerEditorial(libro.editorial.idEditorial);
                    libro.editorial.nombre = editorial.nombre;
                    lblEditorial.Text = libro.editorial != null ? editorial.nombre : "-";
                    var creadores = materialWSClient.listarCreadoresPorMaterial(id);
                    lblCreadores.Text = (creadores != null && creadores.Length > 0)
                        ? string.Join(", ", creadores.Select(c => c.nombre))
                        : "-";

                    var temas = materialWSClient.listarTemasPorMaterial(id);
                    lblTemas.Text = (temas != null && temas.Length > 0)
                        ? string.Join(", ", temas.Select(t => t.descripcion))
                        : "-";
                    Session["MaterialSeleccionado"] = libro;
                    int idSede = Convert.ToInt32(Session["idSede"]);
                    if(idSede != 0)
                    {
                        cantidadEjemplaresDisponibles = ejemplarWSClient.contarEjemplaresDisponiblesPorMaterialYSede(libro.idMaterial, idSede);
                        cantidadNoDisponible = ejemplarWSClient.contarEjemplaresNoDisponiblesPorMaterialYSede(libro.idMaterial, idSede);
                        cantidadEjemplares = cantidadEjemplaresDisponibles + cantidadNoDisponible;
                    }
                    else
                    {
                        cantidadEjemplaresDisponibles = ejemplarWSClient.contarDisponiblesPorMaterial(libro.idMaterial);
                        cantidadEjemplares = ejemplarWSClient.contarTotalPorMaterial(libro.idMaterial);
                        int cantidadNoDisponible = cantidadEjemplares - cantidadEjemplaresDisponibles;
                    }
                        
                    lblEjemplaresTotales.Text = cantidadEjemplares.ToString();
                    lblEjemplaresDisponibles.Text = cantidadEjemplaresDisponibles.ToString();
                    lblEjemplaresNoDisponibles.Text = cantidadNoDisponible.ToString();
                    imgPortada.ImageUrl = libro.portada ?? "~/Images/Portadas/portadaprueba.jpg";
                }
                else
                {
                    lblTitulo.Text = "Libro no encontrado";
                }
            }
            else
            {
                lblTitulo.Text = "ID inválido";
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexAdmin.aspx");
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("EditarMaterial.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarMaterial.aspx");
        }

        protected void btnEjemplares_Click(object sender, EventArgs e)
        {
            // Obtener el ID del material
            string idMaterial = lblId.Text;

            // Obtener el ID de la sede desde la query string (si fue pasada desde IndexAdmin)
            string idSede = Request.QueryString["sede"];

            // Redirigir pasando ambos parámetros
            if (!string.IsNullOrEmpty(idSede))
                Response.Redirect($"EjemplaresMaterialAdmin.aspx?id={idMaterial}&sede={idSede}");
            else
                Response.Redirect($"EjemplaresMaterialAdmin.aspx?id={idMaterial}");
        }

    }
}