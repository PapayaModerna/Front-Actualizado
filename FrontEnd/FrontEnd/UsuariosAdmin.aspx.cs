using FrontEnd.PersonaWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FrontEnd
{
    public partial class UsuariosAdmin : System.Web.UI.Page
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
                rptUsuarios.DataSource = null;
                rptUsuarios.DataBind();
                lblSinResultadosUsuarios.Visible = false;
                rptPaginacionUsuarios.DataSource = null;
                rptPaginacionUsuarios.DataBind();
            }
        }

        protected void txtBuscarUsuarios_TextChanged(object sender, EventArgs e)
        {
            ViewState["PaginaActualUsuarios"] = 1;
            CargarUsuarios(1, txtBuscarUsuarios.Text.Trim());
        }

        protected void btnBuscarUsuarios_Click(object sender, EventArgs e)
        {
            ViewState["PaginaActualUsuarios"] = 1;
            CargarUsuarios(1, txtBuscarUsuarios.Text.Trim());
        }

        protected void lnkPaginaUsuarios_Click(object sender, EventArgs e)
        {
            int pagina = int.Parse(((LinkButton)sender).CommandArgument);
            ViewState["PaginaActualUsuarios"] = pagina;
            CargarUsuarios(pagina, txtBuscarUsuarios.Text.Trim());
        }

        private void CargarUsuarios(int pagina, string filtro)
        {
            try
            {
                var usuariosWS = personaWSClient.listarPersonasPaginado(10, pagina); // Trae todos los usuarios de la página

                // Divide el filtro en palabras, ignora espacios extra y mayúsculas/minúsculas
                var palabras = (filtro ?? "")
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(p => p.Trim().ToLower())
                    .ToArray();

                var lista = usuariosWS
                    .Where(u =>
                        palabras.Length == 0 ||
                        palabras.All(palabra =>
                            (u.codigo ?? "").ToLower().Contains(palabra) ||
                            (u.nombre ?? "").ToLower().Contains(palabra) ||
                            (u.paterno ?? "").ToLower().Contains(palabra) ||
                            (u.materno ?? "").ToLower().Contains(palabra)
                        )
                    )
                    .Select(u => new
                    {
                        idPersona = u.idPersona,
                        codigo = u.codigo,
                        nombre = u.nombre,
                        paterno = u.paterno,
                        materno = u.materno,
                        tipo = u.tipo
                    })
                    .ToList();

                rptUsuarios.DataSource = lista;
                rptUsuarios.DataBind();

                lblSinResultadosUsuarios.Visible = lista.Count == 0;

                var paginas = Enumerable.Range(1, 5).Select(i => new { NumeroPagina = i }).ToList();
                rptPaginacionUsuarios.DataSource = paginas;
                rptPaginacionUsuarios.DataBind();
            }
            catch
            {
                rptUsuarios.DataSource = null;
                rptUsuarios.DataBind();
                lblSinResultadosUsuarios.Visible = true;
            }
        }

        protected void btnSancionar_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            string idPersona = btn.CommandArgument;
            Response.Redirect($"SancionarUser.aspx?id={idPersona}");
        }
    }
}