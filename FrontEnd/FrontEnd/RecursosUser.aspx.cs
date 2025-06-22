using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;

namespace FrontEnd
{
    public partial class RecursosUser : System.Web.UI.Page
    {
        private MaterialWSClient materialWSClient;
        private const int PageSize = 9;

        private int CurrentPage
        {
            get { return ViewState["CurrentPage"] == null ? 1 : (int)ViewState["CurrentPage"]; }
            set { ViewState["CurrentPage"] = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            materialWSClient = new MaterialWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarMateriales();
            }
        }

        private void CargarMateriales()
        {
            try
            {
                MaterialWS.materialesDTO[] materialesArray = materialWSClient.listarMaterialesPaginado(PageSize, CurrentPage);
                List<MaterialWS.materialesDTO> materiales = materialesArray.ToList();
                rptMateriales.DataSource = materiales;
                rptMateriales.DataBind();

                lblPageNumber.Text = "Página " + CurrentPage;
                btnPrev.Enabled = CurrentPage > 1;
                btnNext.Enabled = materiales.Count == PageSize;

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al cargar los materiales: " + ex.Message + "');</script>");
            }
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                CargarMateriales();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPage++;
            CargarMateriales();
        }

        protected void rptMateriales_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var material = (MaterialWS.materialesDTO)e.Item.DataItem;

                // --- Disponibilidad ---
                /*var lblAvailability = (Label)e.Item.FindControl("lblAvailability");
                var ejemplares = materialWSClient.listarEjemplaresMaterial(material.idMaterial, 1, 1);
                if (ejemplares != null && ejemplares.Length > 0)
                {
                    lblAvailability.Text = "AVAILABLE";
                }
                else
                {
                    lblAvailability.Text = "NOT AVAILABLE";
                }*/

                
                var lblAuthor = (Label)e.Item.FindControl("lblAuthor");
                var creadores = materialWSClient.listarCreadoresPorMaterial(material.idMaterial);
                var primerCreador = creadores[0];
                lblAuthor.Text = $"{primerCreador.nombre} {primerCreador.paterno}";

                var imgPortada = (Image)e.Item.FindControl("imgPortada");
                imgPortada.ImageUrl = ResolveUrl("~/Images/Portadas/" + material.portada);
                imgPortada.AlternateText = material.titulo;
            }
        }
    }
}