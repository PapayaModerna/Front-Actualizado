using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.PersonaWS;

namespace FrontEnd
{
    public partial class DetallesAdmin : System.Web.UI.Page
    {
        private PersonaWSClient personaWSClient;
        protected void Page_Init(object sender, EventArgs e)
        {
            personaWSClient = new PersonaWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUserData(); // Cargar los datos de la persona
            }
        }
        private void LoadUserData()
        {
            var persona = (PersonaWS.personasDTO)Session["usuario"];

            if (persona != null)
            {
                lblInicialUsuario.Text = persona.nombre.Substring(0, 1);
                lblNombreCompleto.Text = persona.nombre + " " + persona.paterno + " " + persona.materno;

                txtNombre.Text = persona.nombre;
                txtCodigo.Text = persona.codigo;
                txtApellido1.Text = persona.paterno;
                txtApellido2.Text = persona.materno;
                txtCorreo.Text = persona.correo;
                txtTelefono.Text = persona.telefono;
                txtDireccion.Text = persona.direccion;
                txtTurno.Text = persona.turno.ToString();
                txtFechaContratoInicio.Text = persona.fechaContratoInicio.ToString("yyyy-MM-dd");  // Formato de fecha
                txtFechaContratoFin.Text = persona.fechaContratoFinal.ToString("yyyy-MM-dd");
            }
            else
            {
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/LoginBiblio.aspx");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string personId = Request.QueryString["id"];
            int idPerson = int.Parse(personId);
            var persona = personaWSClient.obtenerPersona(idPerson);

            if (persona != null)
            {
                persona.direccion = txtDireccion.Text;
                persona.telefono = txtTelefono.Text;
                persona.correo = txtCorreo.Text;
                persona.contrasenha = txtPassword.Text;

                int exito = personaWSClient.modificarPersona(
                    persona.idPersona,
                    persona.codigo,
                    persona.nombre,
                    persona.paterno,
                    persona.materno,
                    persona.direccion,
                    persona.telefono,
                    persona.correo,
                    persona.contrasenha,
                    persona.tipo,
                    persona.turno,
                    persona.fechaContratoInicio,
                    persona.fechaContratoFinal,
                    persona.deuda,
                    persona.fechaSancionFinal,
                    persona.vigente,
                    1,
                    persona.sede.idSede
                );

                if (exito > 0)
                {
                    Response.Redirect("IndexAdmin.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error al guardar los datos.');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Persona no encontrada.');", true);
            }
        }

        protected void btnCambiarClave_Click(object sender, EventArgs e)
        {

        }
    }
}