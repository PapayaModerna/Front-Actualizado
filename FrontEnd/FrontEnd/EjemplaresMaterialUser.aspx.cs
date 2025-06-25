using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.EjemplarWS;
using FrontEnd.MaterialWS;
using FrontEnd.PersonaWS;

namespace FrontEnd
{
    public partial class EjemplaresMaterialUser : System.Web.UI.Page
    {
        private int materialId;
        private MaterialWSClient materialWSClient;
        private EjemplarWSClient ejemplarWSClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            materialWSClient = new MaterialWSClient();
            ejemplarWSClient = new EjemplarWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string idMaterial = Request.QueryString["idMaterial"];
            if (!string.IsNullOrEmpty(idMaterial))
            {
                materialId = int.Parse(idMaterial);
                CargarEjemplaresPorSede(materialId);
                ObtenerTituloMaterial(materialId);
            }
            else
            {
                Response.Write("<script>alert('No se encontró el ID del material.');</script>");
            }
        }

        private void ObtenerTituloMaterial(int materialId)
        {
            var material = materialWSClient.obtenerPorId(materialId);

            if (material != null)
            {
                lblTituloObra.Text = material.titulo;
            }
            else
            {
                lblTituloObra.Text = "Material no encontrado";
            }
        }

        private void CargarEjemplaresPorSede(int materialId)
        {
            var ejemplaresSedeCentral = ejemplarWSClient.listarFisicosDisponiblesPorMaterialYSede(materialId, 1);
            var ejemplaresSedeNorte = ejemplarWSClient.listarFisicosDisponiblesPorMaterialYSede(materialId, 2);
            var ejemplaresSedeSur = ejemplarWSClient.listarFisicosDisponiblesPorMaterialYSede(materialId, 3);

            // Actualiza las secciones de las sedes
            ActualizarRepeater(rptSedeNorte, ejemplaresSedeNorte, lblNoEjemplaresSedeNorte, 2);
            ActualizarRepeater(rptSedeSur, ejemplaresSedeSur, lblNoEjemplaresSedeSur, 3);
            ActualizarRepeater(rptSedeCentral, ejemplaresSedeCentral, lblNoEjemplaresSedeCentro, 1);
        }

        private void ActualizarRepeater(Repeater repeater, EjemplarWS.ejemplaresDTO[] ejemplares, Label lblNoEjemplares, int sedeId)
        {
            if (ejemplares != null && ejemplares.Length > 0)
            {
                repeater.DataSource = ejemplares;
                repeater.DataBind();
                lblNoEjemplares.Visible = false;
            }
            else
            {
                repeater.DataSource = null;
                repeater.DataBind();
                lblNoEjemplares.Visible = true;
            }
        }

        protected void rptEjemplares_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var ejemplar = (EjemplarWS.ejemplaresDTO)e.Item.DataItem;
                var lblCodigoEjemplar = (Label)e.Item.FindControl("lblCodigoEjemplar");
                var lblUbicacionSede = (Label)e.Item.FindControl("lblUbicacionSede");

                if (lblCodigoEjemplar != null && lblUbicacionSede != null)
                {
                    lblCodigoEjemplar.Text = ejemplar.idEjemplar.ToString();
                    lblUbicacionSede.Text = ejemplar.ubicacion;
                }
            }
        }

        protected void btnPedirEjemplar_Click(object sender, EventArgs e)
        {
            List<int> ejemplaresSeleccionados = new List<int>();
            Button btn = (Button)sender;

            int idEjemplar = Convert.ToInt32(btn.CommandArgument);
            var ejemplar = ejemplarWSClient.obtenerEjemplar(idEjemplar);

            int sedeSeleccionada = -1;
            bool sedeCorrecta = false;

            var carrito = Session["CarritoEjemplares"] as List<int> ?? new List<int>();

            if (carrito.Count > 0)
            {
                int sedeDelPrimerEjemplar = ejemplarWSClient.obtenerEjemplar(carrito[0]).sede.idSede;

                if (ejemplar.sede.idSede == sedeDelPrimerEjemplar)
                {
                    sedeSeleccionada = ejemplar.sede.idSede;
                    sedeCorrecta = true;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('No puedes seleccionar ejemplares de distintas sedes.');", true);
                    return;
                }
            }
            else
            {
                sedeSeleccionada = ejemplar.sede.idSede;
                sedeCorrecta = true;
            }

            if (sedeCorrecta)
            {
                ejemplaresSeleccionados.Add(idEjemplar);

                var tipoUsuario = ObtenerTipoUsuario();
                int maxEjemplares = (tipoUsuario == tipoPersona.ESTUDIANTE) ? 3 : 5;

                if (carrito.Count + ejemplaresSeleccionados.Count <= maxEjemplares)
                {
                    carrito.AddRange(ejemplaresSeleccionados);
                    Session["CarritoEjemplares"] = carrito;

                    var master = this.Master as UserBiblio;
                    master?.ActualizarCantidadCarrito();

                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Ejemplares añadidos al carrito.');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Excedes el número máximo de ejemplares que puedes añadir al carrito.');", true);
                }
            }
        }

        private void ProcesarEjemplaresEnSede(Repeater repeater, List<int> ejemplaresSeleccionados)
        {
            foreach (RepeaterItem item in repeater.Items)
            {
                Button btnPedir = (Button)item.FindControl("btnPedirEjemplarSur");  // O el nombre correcto según la sede
                if (btnPedir != null)
                {
                    if (btnPedir.CommandArgument != null)
                    {
                        int idEjemplar = Convert.ToInt32(btnPedir.CommandArgument);
                        ejemplaresSeleccionados.Add(idEjemplar);
                    }
                }
            }
        }
        protected void btnSolicitarPrestamo_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Botón 'Solicitar Préstamo' clickeado.");
        }

        private bool ValidarSedeSeleccionada(List<int> ejemplaresSeleccionados, ref int sedeSeleccionada)
        {
            bool sedeCorrecta = true;
            foreach (int idEjemplar in ejemplaresSeleccionados)
            {
                var ejemplar = ejemplarWSClient.obtenerEjemplar(idEjemplar);
                if (sedeSeleccionada == -1)
                {
                    sedeSeleccionada = ejemplar.sede.idSede; // Asigna la sede del primer ejemplar
                }
                else if (ejemplar.sede.idSede != sedeSeleccionada)
                {
                    sedeCorrecta = false;
                    break;
                }
            }
            return sedeCorrecta;
        }

        private tipoPersona ObtenerTipoUsuario()
        {
            if (Session["tipo"] != null)
            {
                return (tipoPersona)Session["tipo"];
            }
            else
            {
                Response.Redirect("LoginBiblio.aspx");
                return tipoPersona.ESTUDIANTE; // Valor por defecto
            }
        }
    }
}
