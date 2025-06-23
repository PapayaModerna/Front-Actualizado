using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
	public partial class UserBiblio : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                ActualizarCantidadCarrito();
            }
        }
        public void ActualizarCantidadCarrito()
        {
            var carrito = Session["CarritoEjemplares"] as List<int>;
            int cantidad = carrito != null ? carrito.Count : 0;
            lblCantidadCarrito.Text = cantidad.ToString();
            lblCantidadCarrito.Visible = cantidad > 0;
        }
    }
}