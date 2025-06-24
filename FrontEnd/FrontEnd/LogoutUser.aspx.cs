using System;

namespace FrontEnd
{
    public partial class LogoutUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Limpia todas las variables de sesión del usuario
            Session.Remove("idPersona");
            Session.Remove("codigo");
            Session.Remove("nombre");
            Session.Remove("paterno");
            Session.Remove("materno");
            Session.Remove("direccion");
            Session.Remove("telefono");
            Session.Remove("correo");
            Session.Remove("tipo");
            Session.Remove("turno");
            Session.Remove("fechaContratoInicio");
            Session.Remove("fechaContratoFinal");
            Session.Remove("deuda");
            Session.Remove("fechaSancionFinal");
            Session.Remove("vigente");
            Session.Remove("idNivel");
            Session.Remove("idSede");
            Session.Remove("usuario");
            Session.Remove("redireccion");
            Session.Clear();
            Session.Abandon();
            Response.Redirect("LoginBiblio.aspx");
        }
    }
} 