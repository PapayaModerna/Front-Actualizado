using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.EditorialWS;
using FrontEnd.MaterialWS;
using FrontEnd.CreadorWS;

namespace FrontEnd
{
    public partial class InsertarMaterial : System.Web.UI.Page
    {
        
        private List<CreadorWS.creadoresDTO> CreadoresDisponibles
        {
            get => ViewState["CreadoresDisponibles"] as List<CreadorWS.creadoresDTO> ?? new List<CreadorWS.creadoresDTO>();
            set => ViewState["CreadoresDisponibles"] = value;
        }
        
        private List<int> CreadoresInsertados
        {
            get => ViewState["CreadoresInsertados"] as List<int> ?? new List<int>();
            set => ViewState["CreadoresInsertados"] = value;
        }

        private List<TemaWS.temasDTO> TemasDisponibles
        {
            get => ViewState["TemasDisponibles"] as List<TemaWS.temasDTO> ?? new List<TemaWS.temasDTO>();
            set => ViewState["TemasDisponibles"] = value;
        }

        private List<int> TemasSeleccionados
        {
            get => ViewState["TemasSeleccionados"] as List<int> ?? new List<int>();
            set => ViewState["TemasSeleccionados"] = value;
        }

        private void ListarTemas()
        {
            var temaCliente = new TemaWS.TemaWSClient();
            var temas = temaCliente.listarTemas().ToList();
            TemasDisponibles = temas;

            ddlTemas.DataSource = temas.Select(t => new
            {
                t.idTema,
                nombreCompleto = $"{t.categoria} - {t.descripcion}"
            }).ToList();

            ddlTemas.DataTextField = "nombreCompleto";
            ddlTemas.DataValueField = "idTema";
            ddlTemas.DataBind();
            ddlTemas.Items.Insert(0, new ListItem("Seleccione un tema", "0"));
        }
        private void LlenarAnioPublicacion()
        {
            int currentYear = DateTime.Now.Year;

            // Agregar los años al DropDownList
            for (int i = 1900; i <= currentYear; i++)
            {
                ddlAnioPublicacion.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        private void ListarEditoriales()
        {
            var editorialCliente = new EditorialWS.EditorialWSClient();
            FrontEnd.EditorialWS.editorialesDTO[] editoriales = editorialCliente.listarEditoriales();
            ArrayList editorialList = new ArrayList();
            foreach (var editorial in editoriales)
            {
                editorialList.Add(new { editorial.idEditorial, editorial.nombre });
            }
            ddlEditorial.DataSource = editorialList;
            ddlEditorial.DataTextField = "nombre";
            ddlEditorial.DataValueField = "idEditorial";
            ddlEditorial.DataBind();
            ddlEditorial.Items.Insert(0, new ListItem("Seleccione una editorial", "0"));

        }
        
        private void ListarCreadores()
        {
            var creadorCliente = new CreadorWS.CreadorWSClient();
            var creadores = creadorCliente.listarCreadores().ToList(); // guardamos toda la lista
            CreadoresDisponibles = creadores;

            ddlCreadores.DataSource = creadores.Select(c => new
            {
                c.idCreador,
                nombreCompleto = $"{c.nombre} {c.paterno} {c.materno}"
            }).ToList();

            ddlCreadores.DataTextField = "nombreCompleto";
            ddlCreadores.DataValueField = "idCreador";
            ddlCreadores.DataBind();
            ddlCreadores.Items.Insert(0, new ListItem("Seleccione un creador", "0"));
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
          
                LlenarAnioPublicacion();
                ListarEditoriales();
                ddlCreadores.Items.Insert(0, new ListItem("Seleccione un creador", "0"));
                ddlTemas.Items.Insert(0, new ListItem("Seleccione un tema", "0"));
                //ListarCreadores();
                // ListarTemas();

            }
            MostrarCreadoresInsertados();
            MostrarTemasInsertados();

        }

        protected void btnCargarCreadores_Click(object sender, EventArgs e)
        {
            ListarCreadores();
            btnCargarCreadores.Visible = false;
        }

        protected void btnCargarTemas_Click(object sender, EventArgs e)
        {
            ListarTemas();
            btnCargarTemas.Visible = false;
        }

        private void MostrarCreadoresInsertados()
        {
            panelCreadoresInsertados.Controls.Clear();
            

            foreach (int id in CreadoresInsertados)
            {
                
                var creador = CreadoresDisponibles.FirstOrDefault(c => c.idCreador == id);
                if (creador == null)
                {
                    continue;
                }

                string nombreCompleto = $"{creador.nombre} {creador.paterno} {creador.materno}";


                var contenedor = new Panel { CssClass = "badge bg-creador text-white p-2 rounded d-flex align-items-center" };
                contenedor.Controls.Add(new Literal { Text = nombreCompleto });
                var btnEliminar = new Button
                {
                    Text = "✖",
                    CssClass = "btn btn-sm btn-outline-light ms-2",
                    CommandArgument = id.ToString()
                };
                btnEliminar.Click += btnEliminarCreador_Click;

                contenedor.Controls.Add(btnEliminar);
                panelCreadoresInsertados.Controls.Add(contenedor);
                            }
            
        }
        
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexAdmin.aspx");
        }

        protected void btnEliminarCreador_Click(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            int id = int.Parse(boton.CommandArgument);

            var lista = CreadoresInsertados;
            lista.Remove(id);
            CreadoresInsertados = lista;

            MostrarCreadoresInsertados();
        }
        protected void btnAgregarCreador_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlCreadores.SelectedValue);
            if (id == 0) return;

            var lista = CreadoresInsertados;

            if (lista.Contains(id)) return;

            lista.Add(id);

            CreadoresInsertados = lista;
            MostrarCreadoresInsertados();
        }

        protected void btnAgregarTema_Click(object sender, EventArgs e)
        {
            int id = int.Parse(ddlTemas.SelectedValue);
            if (id == 0) return;

            var lista = TemasSeleccionados;
            if (!lista.Contains(id))
                lista.Add(id);

            TemasSeleccionados = lista;
            MostrarTemasInsertados();
        }

        private void MostrarTemasInsertados()
        {
            panelTemasInsertados.Controls.Clear();

            foreach (int id in TemasSeleccionados)
            {
                var tema = TemasDisponibles.FirstOrDefault(t => t.idTema == id);
                if (tema == null) continue;

                string texto = $"{tema.categoria} - {tema.descripcion}";

                var contenedor = new Panel { CssClass = "badge bg-creador text-white p-2 rounded d-flex align-items-center" };
                contenedor.Controls.Add(new Literal { Text = texto });

                var btnEliminar = new Button
                {
                    Text = "✖",
                    CssClass = "btn btn-sm btn-outline-light ms-2",
                    CommandArgument = id.ToString()
                };
                btnEliminar.Click += btnEliminarTema_Click;

                contenedor.Controls.Add(btnEliminar);
                panelTemasInsertados.Controls.Add(contenedor);
            }
        }

        protected void btnEliminarTema_Click(object sender, EventArgs e)
        {
            var boton = (Button)sender;
            int id = int.Parse(boton.CommandArgument);

            var lista = TemasSeleccionados;
            lista.Remove(id);
            TemasSeleccionados = lista;

            MostrarTemasInsertados();
        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            var material = new MaterialWS.materialesDTO
            {
                nivel = new MaterialWS.nivelesInglesDTO(),
                editorial = new MaterialWS.editorialesDTO()
            };

            try
            {
                string titulo = txtTitulo.Text;
                string edicion = txtEdicion.Text;
                int anioPublicacion = Convert.ToInt32(ddlAnioPublicacion.SelectedValue);
                bool vigente = chkVigente.Checked;
                int idEditorial = Convert.ToInt32(ddlEditorial.SelectedValue);
                string portada = string.Empty;

                if (fileUploadPortada.HasFile)
                {
                    if (fileUploadPortada.FileBytes.Length > 1024 * 1024) // Limitar a 1MB
                    {
                        Response.Write("<script>alert('El archivo es demasiado grande. Máximo 1MB.');</script>");
                        return;
                    }

                    using (var img = System.Drawing.Image.FromStream(fileUploadPortada.PostedFile.InputStream))
                    {
                        int width = img.Width;
                        int height = img.Height;
                        double ratio = (double)height / width;

                        if (ratio < 1.45 || ratio > 1.65)
                        {
                            Response.Write("<script>alert('La imagen debe tener una proporción cercana a 2:3 (ejemplo: 500x750 píxeles)');</script>");
                            return;
                        }
                    }
                    fileUploadPortada.PostedFile.InputStream.Position = 0;
                    string extension = Path.GetExtension(fileUploadPortada.FileName).ToLower();
                    string fileName = $"nuevo_{DateTime.Now.Ticks}{extension}";
                    string filePath = Path.Combine(Server.MapPath("~/Images/Portadas/"), fileName);
                    fileUploadPortada.SaveAs(filePath);
                    portada = $"~/Images/Portadas/{fileName}";
                }
                else
                {
                    portada = hiddenPortadaAnterior.Value;
                }

                material.titulo = titulo;
                material.edicion = edicion;
                material.anioPublicacion = anioPublicacion;
                material.anioPublicacionSpecified = true;
                material.vigente = vigente;
                material.vigenteSpecified = true;
                material.portada = portada;
                material.nivel.idNivel = Convert.ToInt32(ddlNivel.SelectedValue);
                material.editorial.idEditorial = idEditorial;
                material.editorial.idEditorialSpecified = true;

                var listaCreadores = CreadoresInsertados.Select(id => new MaterialWS.creadoresDTO
                {
                    idCreador = id,
                    idCreadorSpecified = true
                }).ToArray();

                var listaTemas = TemasSeleccionados.Select(id => new MaterialWS.temasDTO
                {
                    idTema = id,
                    idTemaSpecified = true
                }).ToArray();

                if (listaCreadores.Length == 0)
                {
                    Response.Write("<script>alert('Debe seleccionar al menos un creador.');</script>");
                    return;
                }

                if (listaTemas.Length == 0)
                {
                    Response.Write("<script>alert('Debe seleccionar al menos un tema.');</script>");
                    return;
                }

                var materialCliente = new MaterialWS.MaterialWSClient();
                var result = materialCliente.insertarMaterial(material, listaCreadores, listaTemas);

                if (result > 0)
                {
                    Response.Write("<script>alert('✅ Material insertado correctamente');</script>");
                    Response.Redirect("IndexAdmin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('❌ No se pudo insertar el material');</script>");
                }
            }
            catch (Exception ex)
            {
                string mensaje = $"Error al insertar el material: {ex.Message}";
                Response.Write("<script>alert('" + mensaje.Replace("'", "\\'") + "');</script>");
            }
        }
    }
}