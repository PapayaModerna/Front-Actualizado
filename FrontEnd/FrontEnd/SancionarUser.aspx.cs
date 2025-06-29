using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.EjemplarWS;
using FrontEnd.MaterialWS;
using FrontEnd.PersonaWS;
using FrontEnd.PrestamoWS;
using FrontEnd.SancionWS;

namespace FrontEnd
{
    public partial class SancionarUser : System.Web.UI.Page
    {
        private PrestamoWSClient prestamoWSClient;
        private PersonaWSClient personaWSClient;
        private SancionWSClient sancionWSClient;

        protected void Page_Init(object sender, EventArgs e)
        {
            prestamoWSClient = new PrestamoWSClient();
            personaWSClient = new PersonaWSClient();
            sancionWSClient= new SancionWSClient();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int idUsuario;

                if (int.TryParse(Request.QueryString["idUsuario"], out idUsuario))
                {
                    var usuario = personaWSClient.obtenerPersona(idUsuario);

                    if (usuario != null)
                    {
                        lblCodigoUsuario.Text = usuario.codigo;
                        lblNombreUsuario.Text = usuario.nombre;

                        LlenarTiposDeSancion();

                        txtFechaHoy.Text = DateTime.Now.ToShortDateString();
                    }
                }   
            }
        }
        private void LlenarTiposDeSancion()
        {
            var tiposSancion = new List<ListItem>
            {
                new ListItem("DAÑO", ((int)tipoSancion.DANHO).ToString()),
                new ListItem("PERDIDA", ((int)tipoSancion.PERDIDA).ToString()),
                new ListItem("EXCEPCION", ((int)tipoSancion.EXCEPCION).ToString())
            };

            ddlTipoSancion.DataSource = tiposSancion;
            ddlTipoSancion.DataTextField = "Text"; 
            ddlTipoSancion.DataValueField = "Value";  
            ddlTipoSancion.DataBind();

            ddlTipoSancion.Items.Insert(0, new ListItem("Seleccionar Tipo de Sanción", ""));
        }
        protected void calendarDuracionSancion_SelectionChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = calendarDuracionSancion.SelectedDate;
        }
        protected void btnRegistrarSancion_Click(object sender, EventArgs e)
        {
            int tipoSancionValor = Convert.ToInt32(ddlTipoSancion.SelectedValue);
            tipoSancion tipoSancion = (tipoSancion)tipoSancionValor;
            string descripcion = txtDescripcion.Text;
            double monto = Convert.ToDouble(txtMontoSancion.Text);
            int idPrestamo= Convert.ToInt32(txtCodigoPrestamo.Text);
            DateTime fechaSancion = DateTime.Now;
            DateTime duracionSancion = calendarDuracionSancion.SelectedDate;

            sancionWSClient.insertarSancion(tipoSancion,fechaSancion,monto, duracionSancion,descripcion,idPrestamo);

            Response.Redirect("UsuariosAdmin.aspx");
        }
    }
}