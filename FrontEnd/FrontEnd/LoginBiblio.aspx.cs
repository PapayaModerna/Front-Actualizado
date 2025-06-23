using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.PersonaWS;
namespace FrontEnd
{
    public partial class LoginBiblio : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string identificador = txtLoginCodigo.Text.Trim();
            string password = txtPassword.Text;
            try
            {
                PersonaWSClient cliente = new PersonaWSClient();
                PersonaWS.personasDTO persona = cliente.obtenerPersonaPorCredenciales(identificador, password);

                if (persona != null)
                {
                    // Guarda el objeto completo (opcional)
                    Session["usuario"] = persona;

                    // Guarda los campos individuales
                    Session["idPersona"] = persona.idPersona;
                    Session["codigo"] = persona.codigo;
                    Session["nombre"] = persona.nombre;
                    Session["paterno"] = persona.paterno;
                    Session["materno"] = persona.materno;
                    Session["direccion"] = persona.direccion;
                    Session["telefono"] = persona.telefono;
                    Session["correo"] = persona.correo;
                    Session["tipo"] = persona.tipo;
                    Session["turno"] = persona.turno;
                    Session["fechaContratoInicio"] = persona.fechaContratoInicio;
                    Session["fechaContratoFinal"] = persona.fechaContratoFinal;
                    Session["deuda"] = persona.deuda;
                    Session["fechaSancionFinal"] = persona.fechaSancionFinal;
                    Session["vigente"] = persona.vigente;
                    Session["idNivel"] = persona.nivel != null ? persona.nivel.idNivel : 0;
                    Session["idSede"] = persona.sede != null ? persona.sede.idSede : 0;

                    hfMostrarLoader.Value = "true";

                    if (persona.tipo == tipoPersona.ADMINISTRADOR)
                        Session["redireccion"] = "~/IndexAdmin.aspx";
                    else
                        Session["redireccion"] = "~/IndexUser.aspx";
                    Response.Redirect("~/Loader.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    lblMensaje.Text = "Correo o contraseña incorrectos.";
                    lblMensaje.CssClass = "alert alert-danger mt-3";
                    lblMensaje.Visible = true;


                }
            }
            catch (Exception ex)
            {
                if (ex.Message != null && ex.Message.Contains("Verifica correo"))
                {
                    lblMensaje.Text = "Correo o contraseña incorrectos. Intenta nuevamente.";
                    lblMensaje.CssClass = "alert alert-danger mt-3";
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error inesperado. Por favor, vuelve a intentarlo más tarde.";
                    lblMensaje.CssClass = "alert alert-warning mt-3";
                }

                lblMensaje.Visible = true;
            }
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                string idPersona = txtIdPersona.Text.Trim();
                int id = Convert.ToInt32(idPersona);
                string nuevaContra = txtNuevaContrasena.Text.Trim();

                var clientePersona = new PersonaWS.PersonaWSClient();

                int exito = clientePersona.modificarContrasenha(id, nuevaContra); // Asume true si fue exitoso

                if (exito == 1)
                {
                    lblConfirmacion.Text = "Contraseña modificada correctamente.";
                    lblConfirmacion.CssClass = "alert alert-success mt-2";
                    lblConfirmacion.Visible = true;
                }
                else
                {
                    lblConfirmacion.Text = "Error al cambiar la contraseña.";
                    lblConfirmacion.CssClass = "alert alert-danger mt-2";
                    lblConfirmacion.Visible = true;
                }

            }
            catch (Exception ex)
            {
                string mensaje = ex.Message?.ToLower();

                if (mensaje != null && mensaje.Contains("usuario activo"))
                {
                    lblMensaje.Text = "No se puede cambiar la contraseña a un usuario no activo.";
                }
                else
                {
                    lblMensaje.Text = "Ocurrió un error inesperado al cambiar la contraseña. Intenta nuevamente.";
                }

                lblMensaje.CssClass = "alert alert-danger mt-2";
                lblMensaje.Visible = true;

            }
        }
    }
}