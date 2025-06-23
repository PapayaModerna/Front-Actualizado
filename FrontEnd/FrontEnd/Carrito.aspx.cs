using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.EjemplarWS;
using FrontEnd.PrestamoWS;
using FrontEnd.PersonaWS;
namespace FrontEnd
{
    public partial class Carrito : System.Web.UI.Page
    {
        private EjemplarWSClient ejemplarwsClient;
        private PersonaWSClient personawsClient;
        private PrestamoWSClient prestamowsClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            ejemplarwsClient = new EjemplarWSClient();
            personawsClient = new PersonaWSClient();
            prestamowsClient = new PrestamoWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            var carritoIds = Session["CarritoEjemplares"] as List<int>;
            if (carritoIds != null && carritoIds.Count > 0)
            {
                var ejemplares = new List<int>();

                foreach (int id in carritoIds)
                {
                    ejemplares.Add(id);
                }

                rptCarrito.DataSource = ejemplares;
                rptCarrito.DataBind();
                lblVacio.Visible = false;
            }
            else
            {
                rptCarrito.DataSource = null;
                rptCarrito.DataBind();
                lblVacio.Visible = true;
            }
        }
        protected void btnSolicitarPrestamo_Click(object sender, EventArgs e)
        {
            var carrito = Session["CarritoEjemplares"] as List<int>;
            int idPersona = 7;

            if (carrito != null && carrito.Count > 0)
            {
                try
                {
                    prestamowsClient.solicitarPrestamo(idPersona, carrito.ToArray());

                    // Limpia el carrito
                    Session["CarritoEjemplares"] = new List<int>();

                    // Actualiza visual
                    CargarCarrito();

                    // Notifica al usuario
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Préstamo solicitado correctamente.');", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert", $"alert('Error: {ex.Message}');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('El carrito está vacío.');", true);
            }
        }
    }
}