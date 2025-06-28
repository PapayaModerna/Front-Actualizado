using FrontEnd.EjemplarWS;
using FrontEnd.SedeWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class AgregarEjemplarAdmin : System.Web.UI.Page
    {
        private EjemplarWSClient ejemplarWSClient;
        private SedeWSClient sedeWSClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            ejemplarWSClient = new EjemplarWSClient();
            sedeWSClient = new SedeWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSedes();
                CargarTipos();
                CargarFormatosDigitales();
                // Si recibes la sede por query string, puedes seleccionarla por defecto:
                string sedeQS = Request.QueryString["sede"];
                if (!string.IsNullOrEmpty(sedeQS))
                {
                    var item = ddlSede.Items.FindByValue(sedeQS);
                    if (item != null)
                        ddlSede.SelectedValue = sedeQS;
                }
            }
        }

        private void CargarSedes()
        {
            var sedes = sedeWSClient.listarSedes();
            ddlSede.DataSource = sedes;
            ddlSede.DataTextField = "nombre";
            ddlSede.DataValueField = "idSede";
            ddlSede.DataBind();
        }

        private void CargarTipos()
        {
            // Asumiendo que el enum TipoEjemplar está disponible en el proxy
            ddlTipo.Items.Clear();
            foreach (var tipo in Enum.GetValues(typeof(EjemplarWS.tipoEjemplar)))
            {
                ddlTipo.Items.Add(new ListItem(tipo.ToString(), ((int)tipo).ToString()));
            }
        }

        private void CargarFormatosDigitales()
        {
            // Si FormatoDigital es un enum, lo cargas igual que TipoEjemplar
            ddlFormatoDigital.Items.Clear();
            foreach (var formato in Enum.GetValues(typeof(EjemplarWS.formatoDigital)))
            {
                ddlFormatoDigital.Items.Add(new ListItem(formato.ToString(), ((int)formato).ToString()));
            }
            // Si el ejemplar no es digital, puedes dejar la opción vacía
            ddlFormatoDigital.Items.Insert(0, new ListItem("-- No aplica --", ""));
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int idMaterial = int.Parse(Request.QueryString["id"]);
                int idSede = int.Parse(ddlSede.SelectedValue);
                string ubicacion = txtUbicacion.Text.Trim();
                bool disponible = chkDisponible.Checked;
                DateTime fechaAdquisicion = DateTime.Parse(txtFechaAdquisicion.Text);
                var tipo = (EjemplarWS.tipoEjemplar)Enum.Parse(typeof(EjemplarWS.tipoEjemplar), ddlTipo.SelectedValue);
                EjemplarWS.formatoDigital formatoDigital = EjemplarWS.formatoDigital.PDF; // Usa el valor por defecto que tenga sentido
                if (!string.IsNullOrEmpty(ddlFormatoDigital.SelectedValue))
                {
                    formatoDigital = (EjemplarWS.formatoDigital)Enum.Parse(typeof(EjemplarWS.formatoDigital), ddlFormatoDigital.SelectedValue);
                }

                // Llama al método del servicio
                int insertado=ejemplarWSClient.insertarEjemplar(
                    fechaAdquisicion,
                    disponible,
                    tipo,
                    formatoDigital, // Puede ser null si no aplica
                    ubicacion,
                    idSede,
                    idMaterial
                );

                if (insertado >= 1)
                    MostrarExito("Ejemplar insertado correctamente.");
                else
                    MostrarError("No se pudo insertar el ejemplar.");
            }
            catch (Exception ex)
            {
                MostrarError("Error al actualizar: " + ex.Message);
            }
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

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            // Vuelve a la página de ejemplares del material
            string idMaterial = Request.QueryString["id"];
            string sede = Request.QueryString["sede"];
            if (!string.IsNullOrEmpty(sede))
                Response.Redirect($"EjemplaresMaterialAdmin.aspx?id={idMaterial}&sede={sede}");
            else
                Response.Redirect($"EjemplaresMaterialAdmin.aspx?id={idMaterial}");
        }
    }
}