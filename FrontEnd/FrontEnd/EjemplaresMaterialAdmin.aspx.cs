using FrontEnd.EjemplarWS;
using FrontEnd.MaterialWS;
using FrontEnd.SedeWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class EjemplaresMaterialAdmin : System.Web.UI.Page
    {
        private MaterialWSClient materialWSClient;
        private EjemplarWSClient ejemplarWSClient;
        private SedeWSClient sedeWSClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialWSClient = new MaterialWSClient();
            ejemplarWSClient = new EjemplarWSClient();
            sedeWSClient = new SedeWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDetalleMaterial();
                CargarEjemplares();
            }
        }

        private void CargarDetalleMaterial()
        {
            string idStr = Request.QueryString["id"];
            if (int.TryParse(idStr, out int idMaterial))
            {
                var material = materialWSClient.obtenerPorId(idMaterial);
                if (material != null)
                {
                    lblIdMaterial.Text = material.idMaterial.ToString("000");
                    lblTitulo.Text = material.titulo;
                    lblEditorial.Text = material.editorial != null ? material.editorial.nombre : "-";
                }
                else
                {
                    lblTitulo.Text = "Material no encontrado";
                }
            }
            else
            {
                lblTitulo.Text = "ID inválido";
            }
        }

        private void CargarEjemplares()
        {
            string idStr = Request.QueryString["id"];
            string sedeStr = Request.QueryString["sede"];
            int idMaterial;
            int idSede;

            if (int.TryParse(idStr, out idMaterial))
            {
                EjemplarWS.ejemplaresDTO[] ejemplares = null;

                if (!string.IsNullOrEmpty(sedeStr) && int.TryParse(sedeStr, out idSede) && idSede > 0)
                {
                    ejemplares = ejemplarWSClient.listarFisicosDisponiblesPorMaterialYSede(idMaterial, idSede);
                }
                else
                {
                    ejemplares = ejemplarWSClient.listarEjemplaresDisponiblesPorMaterial(idMaterial);
                }

                if (ejemplares != null && ejemplares.Length > 0)
                {
                    var ejemplaresGrid = ejemplares.Select(e => new
                    {
                        e.idEjemplar,
                        e.fechaAdquisicion,
                        Disponible = e.disponible ? "Sí" : "No",
                        e.ubicacion,
                        Tipo = e.tipo != null ? e.tipo.ToString() : "-",
                        Sede = e.sede != null ? e.sede.nombre : "-"
                    }).ToList();

                    gvEjemplares.DataSource = ejemplaresGrid;
                    gvEjemplares.DataBind();
                    lblSinEjemplares.Visible = false;
                }
                else
                {
                    gvEjemplares.DataSource = null;
                    gvEjemplares.DataBind();
                    lblSinEjemplares.Visible = true;
                }
            }
            else
            {
                lblSinEjemplares.Text = "ID de material no válido.";
                lblSinEjemplares.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            // Vuelve al detalle del libro, manteniendo la sede si existe
            string idMaterial = Request.QueryString["id"];
            string sede = Request.QueryString["sede"];
            if (!string.IsNullOrEmpty(sede))
                Response.Redirect($"DetalleLibrosAdmin.aspx?id={idMaterial}&sede={sede}");
            else
                Response.Redirect($"DetalleLibrosAdmin.aspx?id={idMaterial}");
        }

        protected void btnAgregarEjemplar_Click(object sender, EventArgs e)
        {
            // Redirige a la página de agregar ejemplar, pasando el id del material y la sede si corresponde
            string idMaterial = Request.QueryString["id"];
            string sede = Request.QueryString["sede"];
            if (!string.IsNullOrEmpty(sede))
                Response.Redirect($"AgregarEjemplarAdmin.aspx?id={idMaterial}&sede={sede}");
            else
                Response.Redirect($"AgregarEjemplarAdmin.aspx?id={idMaterial}");
        }
    }
}