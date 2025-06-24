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
            if (IsPostBack)
            {
                // Recuperamos los ejemplares prestados desde la sesión si es un postback
                if (Session["ejemplaresPrestados"] != null)
                {
                    ejemplaresPrestados = (List<FrontEnd.PrestamoWS.ejemplaresDTO>)Session["ejemplaresPrestados"];
                }

                // Recuperamos los ejemplares seleccionados desde la sesión
                List<int> ejemplaresSeleccionados = (List<int>)Session["ejemplaresSeleccionados"];

                if (ejemplaresPrestados != null && ejemplaresPrestados.Count > 0)
                {
                    // Iteramos a través de los ejemplares para generar los CheckBox
                    foreach (var ejemplar in ejemplaresPrestados)
                    {
                        var material = materialWSClient.obtenerPorId(ejemplar.material.idMaterial);
                        if (material != null)
                        {
                            CheckBox cbEjemplar = new CheckBox
                            {
                                Text = $"Ejemplar: {material.titulo}",
                                ID = "cb" + ejemplar.idEjemplar
                            };

                            // Asignamos el valor del ID del ejemplar para poder identificarlo
                            cbEjemplar.Attributes["data-id"] = ejemplar.idEjemplar.ToString();

                            // Verificamos si el ejemplar está en la lista de seleccionados
                            if (ejemplaresSeleccionados != null && ejemplaresSeleccionados.Contains(ejemplar.idEjemplar))
                            {
                                cbEjemplar.Checked = true; // Marcamos el CheckBox si está seleccionado
                            }

                            Panel pnlEjemplar = new Panel();
                            pnlEjemplar.Controls.Add(cbEjemplar);
                            phEjemplares.Controls.Add(pnlEjemplar);
                        }
                    }
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (sender == btnBuscar)
            {
                int codigo;

                if (int.TryParse(txtCodigo.Text.Trim(), out codigo))
                {
                    try
                    {
                        var prestamo = prestamoWSClient.obtenerPrestamo(codigo);

                        if (prestamo != null)
                        {
                            txtFechaSolicitud.Text = prestamo.fechaSolicitud.ToShortDateString();
                            txtFechaDevolucion.Text = prestamo.fechaDevolucion.ToShortDateString();

                            var persona = personaWSClient.obtenerPersona(prestamo.persona.idPersona);

                            if (persona != null)
                            {
                                string nombreCompleto = $"{persona.nombre} {persona.paterno} {persona.materno}";
                                txtNombres.Text = $"Código: {persona.codigo} - {nombreCompleto}";
                                ejemplaresPrestados = prestamoWSClient.listarEjemplaresPrestadosPorPersona(prestamo.persona.idPersona).ToList();
                                Session["ejemplaresPrestados"] = ejemplaresPrestados;

                                // Guardamos los ejemplares seleccionados en la sesión
                                List<int> ejemplaresSeleccionados = new List<int>();

                                phEjemplares.Controls.Clear();

                                if (ejemplaresPrestados != null && ejemplaresPrestados.Count > 0)
                                {
                                    foreach (var ejemplar in ejemplaresPrestados)
                                    {
                                        var material = materialWSClient.obtenerPorId(ejemplar.material.idMaterial);
                                        if (material != null)
                                        {
                                            CheckBox cbEjemplar = new CheckBox
                                            {
                                                Text = $"Ejemplar: {material.titulo}",
                                                ID = "cb" + ejemplar.idEjemplar
                                            };

                                            // Asignamos el valor del ID del ejemplar para poder identificarlo
                                            cbEjemplar.Attributes["data-id"] = ejemplar.idEjemplar.ToString();

                                            // Agregamos el ID del ejemplar a la lista de seleccionados
                                            ejemplaresSeleccionados.Add(ejemplar.idEjemplar);

                                            Panel pnlEjemplar = new Panel();
                                            pnlEjemplar.Controls.Add(cbEjemplar);

                                            phEjemplares.Controls.Add(pnlEjemplar);
                                        }
                                    }

                                    // Guardamos los ejemplares seleccionados en la sesión
                                    Session["ejemplaresSeleccionados"] = ejemplaresSeleccionados;
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
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Session["ejemplaresPrestados"] != null)
            {
                ejemplaresPrestados = (List<FrontEnd.PrestamoWS.ejemplaresDTO>)Session["ejemplaresPrestados"];
            }

            if (ejemplaresPrestados != null && ejemplaresPrestados.Count > 0)
            {
                var ejemplaresSeleccionados = new List<int>();
                foreach (Control control in phEjemplares.Controls)
                {
                    if (control is Panel pnl && pnl.Controls[0] is CheckBox cbEjemplar && cbEjemplar.Checked)
                    {
                        // Recuperamos el ID del ejemplar desde el atributo personalizado 'data-id'
                        var ejemplarId = int.Parse(cbEjemplar.Attributes["data-id"]);
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
                        Response.Redirect("PrestamosPrincipalAdmin.aspx");
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
            txtCodigo.Text = "";
            txtFechaSolicitud.Text = "";
            txtFechaDevolucion.Text = "";
            txtNombres.Text = "";

            foreach (Control control in phEjemplares.Controls)
            {
                if (control is Panel pnl && pnl.Controls[0] is CheckBox cbEjemplar)
                {
                    cbEjemplar.Checked = false;
                }
            }
        }
    }
}
