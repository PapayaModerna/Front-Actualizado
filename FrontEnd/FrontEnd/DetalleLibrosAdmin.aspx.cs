using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;

namespace FrontEnd
{
    public partial class DetalleLibrosAdmin : System.Web.UI.Page
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
            Response.Redirect("EjemplaresMaterial.aspx");
        }

    }
}