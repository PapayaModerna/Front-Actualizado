using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class PerfilUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPersona"] == null)
                {
                    Response.Redirect("LoginBiblio.aspx");
                    return;
                }
                //lblIdPersona.Text = Session["idPersona"]?.ToString();
                lblCodigo.Text = Session["codigo"]?.ToString();
                lblNombre.Text = Session["nombre"]?.ToString();
                lblPaterno.Text = Session["paterno"]?.ToString();
                lblMaterno.Text = Session["materno"]?.ToString();
                lblDireccion.Text = Session["direccion"]?.ToString();
                lblTelefono.Text = Session["telefono"]?.ToString();
                lblCorreo.Text = Session["correo"]?.ToString();
                lblTipo.Text = Session["tipo"]?.ToString();
                lblTurno.Text = Session["turno"]?.ToString();
                lblFechaInicio.Text = Session["fechaContratoInicio"]?.ToString();
                lblFechaFinal.Text = Session["fechaContratoFinal"]?.ToString();
                lblDeuda.Text = Session["deuda"]?.ToString();
                lblSancion.Text = Session["fechaSancionFinal"]?.ToString();
                lblVigente.Text = Session["vigente"]?.ToString();
                lblIdNivel.Text = Session["idNivel"]?.ToString();
                lblIdSede.Text = Session["idSede"]?.ToString();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            // Lógica para editar el perfil (por implementar)
        }

        protected void btnCambiarPassword_Click(object sender, EventArgs e)
        {
            // Lógica para cambiar la contraseña (por implementar)
        }
    }
}