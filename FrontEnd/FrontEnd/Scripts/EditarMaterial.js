class MaterialManager {
    constructor() {
        this.initializeElements();
        this.attachEventListeners();
        this.selectedFile = null;
    }

    initializeElements() {
        this.uploadArea = document.getElementById('uploadArea');
        this.fileInput = document.getElementById(serverIDs.fileUploadPortada);
        this.previewImage = document.getElementById(serverIDs.imgPreview);
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

    manager.uploadArea.addEventListener('click', () => {
        console.log("Intentando abrir el explorador de archivos...");
        manager.fileInput.click();
    });
});