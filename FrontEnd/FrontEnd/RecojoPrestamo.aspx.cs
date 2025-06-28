using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.EjemplarWS;
using FrontEnd.MaterialWS;
using FrontEnd.PersonaWS;
using FrontEnd.PrestamoEjemplarWS;
using FrontEnd.PrestamoWS;

namespace FrontEnd
{
    public partial class RecojoPrestamo : System.Web.UI.Page
    {
        private PrestamoWSClient prestamoWSClient;
        private PersonaWSClient personaWSClient;
        private PrestamoEjemplarWSClient prestamoEjemplarWSClient;
        private EjemplarWSClient ejemplarWSClient;
        private MaterialWSClient materialWSClient;

        private List<FrontEnd.PrestamoWS.prestamosDTO> prestamos;

        protected void Page_Init(object sender, EventArgs e)
        {
            prestamoWSClient = new PrestamoWSClient();
            personaWSClient = new PersonaWSClient();
            prestamoEjemplarWSClient = new PrestamoEjemplarWSClient();
            ejemplarWSClient = new EjemplarWSClient();
            materialWSClient = new MaterialWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (Session["prestamos"] != null)
                {
                    prestamos = (List<FrontEnd.PrestamoWS.prestamosDTO>)Session["prestamos"];
                }
            }
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string codigoBuscado = txtCodigo.Text.Trim();
            if (string.IsNullOrEmpty(codigoBuscado)) return;

            try
            {
                var personas = personaWSClient.listarPersonas();
                var personaEncontrada = personas.FirstOrDefault(p => p.codigo == codigoBuscado);
                if (personaEncontrada != null)
                {
                    txtNombres.Text = $"{personaEncontrada.nombre} {personaEncontrada.paterno}";
                    prestamos = prestamoWSClient.listarPrestamosSolicitadosPorPersona(personaEncontrada.idPersona).ToList();
                    Session["prestamos"] = prestamos;
                    DateTime fechaActual = DateTime.Now.Date;
                    DateTime fechaLimite = fechaActual.AddDays(-2).Date;


                    var prestamo = prestamos.FirstOrDefault(p => p.fechaSolicitud.Date >= fechaLimite && p.fechaSolicitud.Date <= fechaActual);

                    if (prestamo != null)
                    {
                        txtFecha.Text = prestamo.fechaSolicitud.ToString("yyyy-MM-dd");
                        var ejemplaresPrestamos = prestamoWSClient.listarEjemplaresSolicitadosPorPersona(personaEncontrada.idPersona);
                        var titulosMateriales = new List<string>();
                        foreach (var ejemplar in ejemplaresPrestamos)
                        {
                            if (ejemplar.material != null)
                            {
                                var material = materialWSClient.obtenerPorId(ejemplar.material.idMaterial);

                                if (material != null)
                                {
                                    titulosMateriales.Add(material.titulo);
                                }
                            }
                        }
                        txtEjemplares.Text = string.Join(", ", titulosMateriales);
                    }
                    else
                    {
                        txtFecha.Text = "No encontrado";
                        txtEjemplares.Text = "No hay ejemplares que mostrar";
                    }
                }
                else
                {
                    txtNombres.Text = "No encontrado";
                }
            }
            catch (Exception ex)
            {
                txtNombres.Text = "Error";
                txtFecha.Text = "Error";
                txtEjemplares.Text = ex.Message;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "hideLoading", "hideLoading();", true);

        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrestamosPrincipalAdmin.aspx");
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Session["prestamos"] != null)
            {
                prestamos = (List<FrontEnd.PrestamoWS.prestamosDTO>)Session["prestamos"];
            }
            if (prestamos != null && prestamos.Count > 0)
            {
                var prestamoMasAntiguo = prestamos.OrderBy(p => p.fechaSolicitud).FirstOrDefault();
                if (prestamoMasAntiguo != null)
                {
                    prestamoWSClient.recogerPrestamo(prestamoMasAntiguo.idPrestamo);
                    Response.Redirect("~/PrestamosPrincipalAdmin.aspx");
                }
                else
                {
                    txtFecha.Text = "No se encontró un préstamo válido para registrar.";
                    txtEjemplares.Text = "No hay ejemplares que mostrar.";
                }
            }
            else
            {
                txtFecha.Text = "No se encontró el préstamo para registrar.";
            }
        }
    }
}