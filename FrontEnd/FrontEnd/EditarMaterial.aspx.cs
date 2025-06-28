using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FrontEnd.MaterialWS;
using FrontEnd.EditorialWS;
using System.Collections;

namespace FrontEnd
{
    public partial class EditarMaterial : System.Web.UI.Page
    {
        private MaterialWSClient materialwsClient;
        private EditorialWSClient editorialwsClient;

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
            //  ddlEditorial.Items.Insert(0, new ListItem("Seleccione una editorial", "0"));

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            materialwsClient = new MaterialWSClient();
            editorialwsClient = new EditorialWSClient();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var material = Session["MaterialSeleccionado"] as MaterialWS.materialesDTO;

                if (material != null)
                {
                    hfIdMaterial.Value = material.idMaterial.ToString();
                    LoadMaterial(material);
                }
                else
                {
                    Response.Write("<script>alert('ID de material no válido en sesión');</script>");
                    Response.Redirect("IndexAdmin.aspx");
                }
                ListarEditoriales();
                LlenarAnioPublicacion();
            }
        }

        private void LoadMaterial(MaterialWS.materialesDTO material)
        {
            try
            {
                if (material != null)
                {
                    txtTitulo.Text = material.titulo;
                    txtEdicion.Text = material.edicion;
                    chkVigente.Checked = material.vigente;
                    ddlAnioPublicacion.Items.Clear();
                    if (material.anioPublicacion != 0) 
                    {
                        ddlAnioPublicacion.Items.Add(new ListItem(material.anioPublicacion.ToString(), material.anioPublicacion.ToString()));
                    }

                    ddlEditorial.Items.Clear();
                    if (material.editorial != null)
                    {
                        ddlEditorial.Items.Add(new ListItem(material.editorial.nombre, material.editorial.idEditorial.ToString()));
                    }

                    ddlNivel.SelectedValue = material.nivel.nivel.ToString();

                    // Establecer la portada actual (si existe)
                    //if (!string.IsNullOrEmpty(material.portada))
                    //{
                    // Usamos el FileUpload, no necesitamos txtPortada
                    // Puedes configurar la ruta de la portada para previsualizarla, si es necesario
                    //}
                    hiddenPortadaAnterior.Value = material.portada;
                }
                else
                {
                    Response.Write("<script>alert('No se encontró el material');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error al cargar los detalles: " + ex.Message + "');</script>");
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("IndexAdmin.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int materialId = 0;
            var material = new MaterialWS.materialesDTO();

            material.nivel = new MaterialWS.nivelesInglesDTO();
            material.editorial = new MaterialWS.editorialesDTO();

            try
            {
                materialId = Convert.ToInt32(hfIdMaterial.Value);
                string titulo = txtTitulo.Text;
                string edicion = txtEdicion.Text;
                int anioPublicacion = Convert.ToInt32(ddlAnioPublicacion.SelectedValue);
                bool vigente = chkVigente.Checked;
                int idEditorial = Convert.ToInt32(ddlEditorial.SelectedValue);
                string portada = string.Empty;

                if (fileUploadPortada.HasFile)
                {
                    if (fileUploadPortada.FileBytes.Length > 1024 * 1024)
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
                    string fileName = $"{materialId}_{DateTime.Now.Ticks}{extension}";
                    string filePath = Path.Combine(Server.MapPath("~/Images/Portadas/"), fileName);

                    fileUploadPortada.SaveAs(filePath);
                    portada = $"~/Images/Portadas/{fileName}";
                }
                else
                {
                    portada = hiddenPortadaAnterior.Value;
                }
                material.idMaterial = materialId;
                material.idMaterialSpecified = true;
                material.titulo = titulo;

                material.edicion = edicion;

                material.anioPublicacion = anioPublicacion;
                material.anioPublicacionSpecified = true;

                material.portada = portada;

                material.vigente = vigente;
                material.vigenteSpecified = true;

                material.nivel.idNivel = 1;


                material.editorial.idEditorial = idEditorial;
                material.editorial.idEditorialSpecified = true;

                Response.Write("<script>alert('IdEditorial'+ material.editorial.idEditorial);</script>");

                var result = materialwsClient.modificarMaterial(material);

                if (result > 0)
                {
                    Response.Write("<script>alert('Material actualizado exitosamente');</script>");
                    Response.Redirect("IndexAdmin.aspx");
                }
                else
                {
                    Response.Write("<script>alert('No se pudo actualizar el material');</script>");
                }
            }
            catch (Exception ex)
            {
                string mensaje = $"Error al actualizar el material con ID {material.idMaterial}: {ex.Message}";
                Response.Write("<script>alert('" + mensaje.Replace("'", "\\'") + "');</script>");
            }
        }
    }
}