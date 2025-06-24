using FrontEnd.NivelInglesWS;
using FrontEnd.PersonaWS;
using FrontEnd.PrestamoWS;
using FrontEnd.SedeWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class ModificarUsuarioAdmin : System.Web.UI.Page
    {
        private PersonaWSClient personaWSClient = new PersonaWSClient();
        private NivelInglesWSClient nivelInglesWSClient = new NivelInglesWSClient();
        private SedeWSClient sedeWSClient = new SedeWSClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCombos();
                int idPersona;
                if (int.TryParse(Request.QueryString["id"], out idPersona))
                {
                    hfIdPersona.Value = idPersona.ToString();
                    CargarUsuario(idPersona);
                }
                else
                {
                    MostrarError("ID de usuario no válido.");
                }
            }
        }

        private void CargarCombos()
        {
            // Tipos de Persona (enum)
            ddlTipoPersona.Items.Clear();
            foreach (var value in Enum.GetValues(typeof(PersonaWS.tipoPersona)))
            {
                var enumValue = (PersonaWS.tipoPersona)value;
                string text = enumValue.ToString().Replace("_", " ");
                ddlTipoPersona.Items.Add(new ListItem(text, ((int)enumValue).ToString()));
            }

            // Turnos (enum)
            ddlTurno.Items.Clear();
            foreach (var value in Enum.GetValues(typeof(PersonaWS.turnos)))
            {
                var enumValue = (PersonaWS.turnos)value;
                ddlTurno.Items.Add(new ListItem(enumValue.ToString(), ((int)enumValue).ToString()));
            }

            // Niveles de Inglés (desde WS)
            ddlNivelIngles.DataSource = nivelInglesWSClient.listarNiveles();
            ddlNivelIngles.DataTextField = "descripcion";
            ddlNivelIngles.DataValueField = "idNivel";
            ddlNivelIngles.DataBind();

            // Sedes (desde WS)
            ddlSede.DataSource = sedeWSClient.listarSedes();
            ddlSede.DataTextField = "nombre";
            ddlSede.DataValueField = "idSede";
            ddlSede.DataBind();
        }

        private void CargarUsuario(int idPersona)
        {
            var usuario = personaWSClient.obtenerPersona(idPersona);
            if (usuario == null)
            {
                MostrarError("Usuario no encontrado.");
                return;
            }

            txtCodigo.Text = usuario.codigo;
            txtNombre.Text = usuario.nombre;
            txtPaterno.Text = usuario.paterno;
            txtMaterno.Text = usuario.materno;
            txtDireccion.Text = usuario.direccion;
            txtTelefono.Text = usuario.telefono;
            txtCorreo.Text = usuario.correo;
            txtContrasenha.Attributes["value"] = usuario.contrasenha;
            ddlTipoPersona.SelectedValue = ((int)usuario.tipo).ToString();
            ddlTurno.SelectedValue = ((int)usuario.turno).ToString();
            if (usuario.fechaContratoInicio != DateTime.MinValue)
                txtFechaContratoInicio.Text = usuario.fechaContratoInicio.ToString("yyyy-MM-dd");
            else
                txtFechaContratoInicio.Text = "";

            if (usuario.fechaContratoFinal != DateTime.MinValue)
                txtFechaContratoFinal.Text = usuario.fechaContratoFinal.ToString("yyyy-MM-dd");
            else
                txtFechaContratoFinal.Text = "";
            if (usuario.deuda != 0)
                txtDeuda.Text = usuario.deuda.ToString("0.00");
            else
                txtDeuda.Text = "";
            if (usuario.fechaSancionFinal != DateTime.MinValue)
                txtFechaSancionFinal.Text = usuario.fechaSancionFinal.ToString("yyyy-MM-dd");
            else
                txtFechaSancionFinal.Text = "";
            chkVigente.Checked = usuario.vigente;
            ddlNivelIngles.SelectedValue = usuario.nivel?.idNivel.ToString();
            ddlSede.SelectedValue = usuario.sede?.idSede.ToString();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int idPersona;
            if (!int.TryParse(hfIdPersona.Value, out idPersona))
            {
                MostrarError("ID de usuario no válido.");
                return;
            }

            try
            {
                var usuario = new PersonaWS.personasDTO
                {
                    idPersona = idPersona,
                    codigo = txtCodigo.Text.Trim(),
                    nombre = txtNombre.Text.Trim(),
                    paterno = txtPaterno.Text.Trim(),
                    materno = txtMaterno.Text.Trim(),
                    direccion = txtDireccion.Text.Trim(),
                    telefono = txtTelefono.Text.Trim(),
                    correo = txtCorreo.Text.Trim(),
                    contrasenha = txtContrasenha.Text,
                    tipo = (PersonaWS.tipoPersona)Enum.Parse(typeof(PersonaWS.tipoPersona), ddlTipoPersona.SelectedValue),
                    turno = (PersonaWS.turnos)Enum.Parse(typeof(PersonaWS.turnos), ddlTurno.SelectedValue),
                    fechaContratoInicio = string.IsNullOrEmpty(txtFechaContratoInicio.Text) ? DateTime.MinValue : DateTime.Parse(txtFechaContratoInicio.Text),
                    fechaContratoFinal = string.IsNullOrEmpty(txtFechaContratoFinal.Text) ? DateTime.MinValue : DateTime.Parse(txtFechaContratoFinal.Text),
                    deuda = string.IsNullOrEmpty(txtDeuda.Text) ? 0 : double.Parse(txtDeuda.Text),
                    fechaSancionFinal = string.IsNullOrEmpty(txtFechaSancionFinal.Text) ? DateTime.MinValue : DateTime.Parse(txtFechaSancionFinal.Text),
                    vigente = chkVigente.Checked,
                    nivel = new PersonaWS.nivelesInglesDTO { idNivel = int.Parse(ddlNivelIngles.SelectedValue) },
                    sede = new PersonaWS.sedesDTO { idSede = int.Parse(ddlSede.SelectedValue) }
                };

                int idNivel = int.Parse(ddlNivelIngles.SelectedValue);
                int idSede = int.Parse(ddlSede.SelectedValue);

                int actualizado = personaWSClient.modificarPersona(usuario.idPersona,usuario.codigo,usuario.nombre,usuario.paterno,usuario.materno,usuario.direccion,
                    usuario.telefono,usuario.correo,usuario.contrasenha,usuario.tipo,usuario.turno,usuario.fechaContratoInicio,usuario.fechaContratoFinal,
                    usuario.deuda,usuario.fechaSancionFinal,usuario.vigente,idNivel,idSede);

                if (actualizado==1)
                    MostrarExito("Usuario actualizado correctamente.");
                else
                    MostrarError("No se pudo actualizar el usuario.");
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar: " + ex.Message);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("UsuariosAdmin.aspx");
        }

        private void MostrarExito(string mensaje)
        {
            pnlSuccess.Visible = true;
            pnlError.Visible = false;
            lblSuccess.Text = "✅ " + mensaje;
        }

        private void MostrarError(string mensaje)
        {
            pnlSuccess.Visible = false;
            pnlError.Visible = true;
            lblError.Text = "❌ " + mensaje;
        }
    }
}