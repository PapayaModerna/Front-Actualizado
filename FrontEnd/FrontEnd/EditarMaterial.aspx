<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="EditarMaterial.aspx.cs" Inherits="FrontEnd.EditarMaterial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/EditarMaterial.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="main-title">
    Modifique los detalles del material
    </div>

    <div class="form-container">
        <div class="grid">
            <!-- Título y Edición -->
            <div class="form-group">
                <label for="titulo" class="form-label">Título:</label>
                <asp:TextBox ID="txtTitulo" runat="server" placeholder="Ingrese el título del material" class="form-control" />

                <label for="edicion" class="form-label">Edición:</label>
                <asp:TextBox ID="txtEdicion" runat="server" placeholder="Ingrese la edición" class="form-control" />
            </div>

            <!-- Año de publicación y Editorial -->
            <div class="form-group">
                <label for="anioPublicacion" class="form-label">Año de Publicación:</label>
                <asp:DropDownList ID="ddlAnioPublicacion" runat="server" class="form-control">
                </asp:DropDownList>

                <label for="editorial" class="form-label">Editorial:</label>
                <asp:DropDownList ID="ddlEditorial" runat="server" class="form-control">
                </asp:DropDownList>
            </div>
        </div>

        <!-- Portada -->
        <div class="form-group">
            <label for="portada" class="form-label">Portada:</label>
            
            <div class="upload-area" id="uploadArea">
                <div class="upload-icon">📁</div>
                <div class="upload-text">Arrastra y suelta la imagen aquí</div>
                <div class="upload-subtext">o haz clic para seleccionar archivo</div>
                <div class="upload-subtext">Formatos soportados: JPG, PNG, GIF (máx. 5MB)</div>
            </div>
           
            
            
            <asp:FileUpload ID="fileUploadPortada" runat="server" CssClass="file-upload-hidden" accept="image/*" />
            <asp:HiddenField ID="hiddenPortadaAnterior" runat="server" />
            <asp:Literal ID="litDebug" runat="server" />
            <div class="progress-bar" id="progressBar">
                <div class="progress-fill" id="progressFill"></div>
            </div>
        
            <div class="preview-area" id="previewArea">
                <asp:Image ID="imgPreview" runat="server" CssClass="preview-image" />
                <div class="preview-info" id="previewInfo"></div>
            </div>
        </div>

        <!-- Nivel de inglés y Vigente -->
        <div class="grid">
            <div class="form-group">
                <label for="nivelIngles" class="form-label">Nivel de Inglés:</label>
                <asp:DropDownList ID="ddlNivel" runat="server" class="form-control">
                    <asp:ListItem Text="Básico" Value="1" />
                    <asp:ListItem Text="Intermedio" Value="2" />
                    <asp:ListItem Text="Avanzado" Value="3" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="vigente" class="form-label">Vigente:</label>
                <asp:CheckBox ID="chkVigente" runat="server" />
            </div>
        </div>

        <!-- Mensajes de estado -->
        <div class="success-message" id="successMessage">
            ✅ Material actualizado correctamente
        </div>
    
        <div class="error-message" id="errorMessage">
            ❌ Error al procesar la solicitud
        </div>

        <!-- Botones -->
        <div class="d-flex justify-content-center gap-3 align-items-center">
            <asp:Button ID="btnVolver" runat="server" CssClass="btn custom-btn" Text="Volver a Principal" OnClick="btnVolver_Click" />
            <asp:Button ID="btnActualizar" runat="server" CssClass="btn custom-btn" Text="Actualizar Material" OnClick="btnActualizar_Click" />
        </div>


    </div>
    <asp:HiddenField ID="hfIdMaterial" runat="server" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="server">
    <script>

    class MaterialManager {
    constructor() {
        this.initializeElements();
        this.attachEventListeners();
        this.selectedFile = null;
    }

    initializeElements() {
        this.uploadArea = document.getElementById('uploadArea');
        this.fileInput = document.getElementById('<%= fileUploadPortada.ClientID %>');
        this.previewImage = document.getElementById('<%= imgPreview.ClientID %>');
        this.previewArea = document.getElementById('previewArea');
        this.previewInfo = document.getElementById('previewInfo');
        this.progressBar = document.getElementById('progressBar');
        this.progressFill = document.getElementById('progressFill');
        this.successMessage = document.getElementById('successMessage');
        this.errorMessage = document.getElementById('errorMessage');
    }

    attachEventListeners() {
        this.uploadArea.addEventListener('click', () => this.fileInput.click());
        this.uploadArea.addEventListener('dragover', this.handleDragOver.bind(this));
        this.uploadArea.addEventListener('dragleave', this.handleDragLeave.bind(this));
        this.uploadArea.addEventListener('drop', this.handleDrop.bind(this));
        this.fileInput.addEventListener('change', this.handleFileSelect.bind(this));
    }

    handleDragOver(e) {
        e.preventDefault();
        this.uploadArea.classList.add('dragover');
    }

    handleDragLeave(e) {
        e.preventDefault();
        this.uploadArea.classList.remove('dragover');
    }

    handleDrop(e) {
        e.preventDefault();
        this.uploadArea.classList.remove('dragover');

        const files = e.dataTransfer.files;
        if (files.length > 0) {
            this.processFile(files[0]);
        }
    }

    handleFileSelect(e) {
        const file = e.target.files[0];
        if (file) {
            this.processFile(file);
        }
    }

    processFile(file) {
        if (!this.validateFile(file)) {
            return;
        }

        this.selectedFile = file;
        this.showPreview(file);
        this.uploadArea.style.display = 'none';
    }

    validateFile(file) {
        const allowedTypes = ['image/jpeg', 'image/png', 'image/gif'];
        if (!allowedTypes.includes(file.type)) {
            this.showError('Tipo de archivo no soportado. Use JPG, PNG o GIF.');
            return false;
        }

        const maxSize = 5 * 1024 * 1024;
        if (file.size > maxSize) {
            this.showError('El archivo es demasiado grande. Máximo 5MB.');
            return false;
        }

        return true;
    }

    showPreview(file) {
        const reader = new FileReader();

        reader.onload = (e) => {
            this.previewImage.src = e.target.result;
            this.previewInfo.innerHTML = `
                        <strong>Archivo:</strong> ${file.name}<br>
                        <strong>Tamaño:</strong> ${this.formatFileSize(file.size)}<br>
                        <strong>Tipo:</strong> ${file.type}
                    `;
            this.previewArea.style.display = 'block';
        };

        reader.readAsDataURL(file);
    }

    formatFileSize(bytes) {
        if (bytes === 0) return '0 Bytes';
        const k = 1024;
        const sizes = ['Bytes', 'KB', 'MB', 'GB'];
        const i = Math.floor(Math.log(bytes) / Math.log(k));
        return parseFloat((bytes / Math.pow(k, i)).toFixed(2)) + ' ' + sizes[i];
    }

    showError(message) {
        this.errorMessage.textContent = '❌ ' + message;
        this.errorMessage.style.display = 'block';
        this.successMessage.style.display = 'none';
        setTimeout(() => {
            this.errorMessage.style.display = 'none';
        }, 5000);
    }
}

// Inicializar cuando el DOM esté listo
document.addEventListener('DOMContentLoaded', () => {
    const manager = new MaterialManager();

});
</script>
</asp:Content>
