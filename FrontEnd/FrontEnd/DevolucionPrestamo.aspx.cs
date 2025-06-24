using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.PrestamoWS;
using FrontEnd.PersonaWS;
using FrontEnd.MaterialWS;

namespace FrontEnd
{
    public partial class DevolucionPrestamo : System.Web.UI.Page
    {
        private PrestamoWSClient prestamoWSClient;
        private PersonaWSClient personaWSClient;
        private MaterialWSClient materialWSClient;
        private List<FrontEnd.PrestamoWS.ejemplaresDTO> ejemplaresPrestados;

        protected void Page_Init(object sender, EventArgs e)
        {
            prestamoWSClient = new PrestamoWSClient();
            personaWSClient = new PersonaWSClient();
            materialWSClient = new MaterialWSClient();
          
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            int codigo; 

            if (int.TryParse(txtCodigo.Text.Trim(), out codigo))
            {
                try
                {
                    var prestamo = prestamoWSClient.obtenerPrestamo(codigo);

                    if (prestamo != null)
                    {
                        txtFechaSolicitud.Text = prestamo.fechaSolicitud.ToShortDateString(); // Fecha de solicitud
                        txtFechaDevolucion.Text = prestamo.fechaDevolucion.ToShortDateString(); // Fecha de devolución

                        var persona = personaWSClient.obtenerPersona(prestamo.persona.idPersona);

                        if (persona != null)
                        {
                            string nombreCompleto = $"{persona.nombre} {persona.paterno} {persona.materno}";
                            txtNombres.Text = $"Código: {persona.codigo} - {nombreCompleto}";
                            ejemplaresPrestados = prestamoWSClient.listarEjemplaresPrestadosPorPersona(prestamo.persona.idPersona).ToList();
                            phEjemplares.Controls.Clear();
                            var titulosMateriales = new List<string>();
                            if (ejemplaresPrestados != null && ejemplaresPrestados.Count > 0)
                            {
                                foreach (var ejemplar in ejemplaresPrestados)
                                {
                                    var material = materialWSClient.obtenerPorId(ejemplar.material.idMaterial);
                                    if (material != null)
                                    {
                                        titulosMateriales.Add(material.titulo);

                                        CheckBox cbEjemplar = new CheckBox
                                        {
                                            Text = $"Ejemplar: {material.titulo}", 
                                            ID = "cb" + ejemplar.idEjemplar 
                                        };

                                        Panel pnlEjemplar = new Panel();
                                        pnlEjemplar.Controls.Add(cbEjemplar);

                                        phEjemplares.Controls.Add(pnlEjemplar);
                                    }
                                }
                            }
                            else
                            {
                                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontraron ejemplares para esta persona.');", true);
                            }
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Persona no encontrada.');", true);
                        }
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Prestamo no encontrado.');", true);
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al buscar el préstamo: " + ex.Message + "');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor ingrese un código para buscar.');", true);
            }
        }
        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ejemplaresPrestados != null && ejemplaresPrestados.Count > 0)
            {
                var ejemplaresSeleccionados = new List<int>();
                foreach (Control control in phEjemplares.Controls)
                {
                    if (control is Panel pnl && pnl.Controls[0] is CheckBox cbEjemplar && cbEjemplar.Checked)
                    {
                        var ejemplarId = int.Parse(cbEjemplar.ID.Substring(2)); // ID del ejemplar (ejemplo: "cb123")
                        ejemplaresSeleccionados.Add(ejemplarId);
                    }
                }
                if (ejemplaresSeleccionados.Count > 0)
                {
                    try
                    {
                        int idPrestamo = int.Parse(txtCodigo.Text.Trim());
                        int[] ejemplaresArray = ejemplaresSeleccionados.ToArray();
                        prestamoWSClient.devolverPrestamo(idPrestamo, ejemplaresArray);
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Devolución registrada correctamente.');", true);
                        LimpiarCampos();
                    }
                    catch (Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Error al registrar la devolución: " + ex.Message + "');", true);
                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Por favor, seleccione al menos un ejemplar para devolver.');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('No se encontraron ejemplares para esta persona.');", true);
            }
        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("PrestamosPrincipalAdmin.aspx");
        }
        private void LimpiarCampos()
        {
        }
    }
}