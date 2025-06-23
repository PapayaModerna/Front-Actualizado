<%@ Page Title="" Language="C#" MasterPageFile="~/UserBiblio.Master" AutoEventWireup="true" CodeBehind="RecursosUser.aspx.cs" Inherits="FrontEnd.RecursosUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <style>
        .carousel-row {
            margin-bottom: 3rem;
        }

        .carousel-container {
            position: relative;
        }

        .slider-wrapper {
            display: flex;
            justify-content: center;
            overflow-x: hidden;
            padding-left: 1rem;
            padding-right: 1rem;
            padding-bottom: 15px;
            gap: 1.2rem;
        }

        .slide-item {
            flex: 0 0 23%;
            max-width: 265px;
            min-width: 220px;
            margin-right: 0;
        }
        
        .card {
            transition: transform .18s, box-shadow .18s;
            box-shadow: 0 4px 12px 0 rgba(31, 38, 135, 0.10);
        }

        .card:hover {
            transform: scale(1.025);
            box-shadow: 0 8px 18px rgba(31,38,135,0.13);
        }

        .carousel-nav {
            position: absolute;
            top: 50%;
            transform: translateY(-50%);
            z-index: 10;
            background-color: rgba(255, 255, 255, 0.8);
            border: 1px solid #ccc;
            border-radius: 50%;
            width: 40px;
            height: 40px;
            cursor: pointer;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .carousel-nav:hover {
            background-color: white;
        }
        .carousel-nav.prev-btn {
            left: -20px;
        }
        .carousel-nav.next-btn {
            right: -20px;
        }

        .carousel-nav[disabled] {
            cursor: not-allowed;
            opacity: 0.5;
        }

        /* Estilos de la tarjeta (reutilizados y ajustados) */
        .card-img-top-custom { height: 400px; object-fit: cover; width: 100%; }
        .card-availability { position: absolute; top: 0; left: 0; width: 100%; background-color: rgba(0, 0, 0, 0.6); color: white; padding: 8px; text-align: center; font-weight: bold; }
        .card-body-custom { padding: 1rem; }
        .card-title-custom { font-size: 1.1rem; font-weight: bold; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; }
        .card-author { font-size: 0.9rem; color: #6c757d; white-space: nowrap; overflow: hidden; text-overflow: ellipsis; }
        .card-footer-custom { background-color: transparent; border-top: none; padding: 0 1rem 1rem 1rem; display: flex; justify-content: space-between; align-items: center; }

        /* --- ESTILOS PARA EL CONTENEDOR EXPANDIBLE --- */
        .details-expander {
            max-height: 0;
            overflow: hidden;
            border-radius: 1rem; /* Bordes suaves */
            background-color: transparent;
            /* Transición suave para todas las propiedades animadas */
            transition: max-height 0.4s ease-out, padding 0.4s ease-out, margin-top 0.4s ease-out;
        }

        .details-expander.open {
            max-height: 600px; /* Altura máxima para la animación */
            padding: 2.5rem 6.5rem; /* Aumentado padding horizontal para más "aire" a los lados */
            margin-top: 1.5rem; /* Espacio superior para separarlo de la fila de libros */
            background-color: #f8f9fa;
            border: 1px solid #e9ecef;
        }

        .details-content {
            display: flex;
            gap: 2.5rem;
            opacity: 0;
            transition: opacity 0.3s ease-in-out 0.2s;
        }
        
        .details-expander.open .details-content {
            opacity: 1;
        }

        .details-content-left {
            flex: 1;
            margin-left: 4rem;
        }

        .details-content-left h3 {
             margin-top: 0;
             font-size: 1.8rem;
        }

        .details-content-right {
            flex: 0 0 35%;
            max-width: 300px;
            margin-right: 4rem;
        }

        .details-content-right img {
            width: 100%;
            height: auto;
            border-radius: 8px;
            box-shadow: 0 6px 15px rgba(0,0,0,0.15);
        }

        .close-details-btn {
            position: absolute;
            top: -1rem;
            right: 0;
            background: none;
            border: none;
            font-size: 2rem;
            cursor: pointer;
            line-height: 1;
            color: #555;
            z-index: 10;
        }

        /* --- DARK MODE STYLES --- */
        html.dark-mode h3,
        html.dark-mode .carousel-row > .d-flex > a {
            color: #dee2e6;
        }
        
        html.dark-mode .carousel-row > .d-flex > a:hover {
             color: #fff;
        }

        html.dark-mode .card {
            background-color: #2b3035;
            border-color: #495057;
        }

        html.dark-mode .card-title-custom,
        html.dark-mode .card-text a {
             color: #dee2e6;
        }
        
        html.dark-mode .card-author {
            color: #adb5bd;
        }
        
        html.dark-mode .details-expander.open {
            background-color: #2b3035; /* Color distinto al fondo, igual a las tarjetas */
            border-color: #495057; /* Mismo borde que las tarjetas */
        }

        html.dark-mode .details-content-left h3,
        html.dark-mode .details-content-left p {
            color: #e0e0e0;
        }

        html.dark-mode .details-content-left p strong {
            color: #f8f9fa;
        }

        html.dark-mode .close-details-btn {
            color: #adb5bd;
        }

        /* --- BUSCADOR ANIMADO CON GRADIENTE --- */
        .buscador-animado {
            width: 100%;
            display: flex;
            justify-content: center;
            align-items: center;
        }
        .buscador-gradient-border {
            background: linear-gradient(90deg, #1e3c72, #232526);
            padding: 6px;
            border-radius: 1rem;
            transition: box-shadow 0.3s;
            box-shadow: 0 4px 24px 0 rgba(31, 38, 135, 0.10);
            width: 720px;
            max-width: 98vw;
        }
        .buscador-contenedor {
            background: white;
            border-radius: 1.2rem;
            display: flex;
            flex-direction: column;
            align-items: stretch;
            transition: height 0.35s cubic-bezier(.4,1.3,.6,1), min-height 0.35s cubic-bezier(.4,1.3,.6,1);
            width: 720px;
            min-height: 3.5rem;
            height: 3.5rem;
            overflow: hidden;
            position: relative;
        }
        .buscador-contenedor.focused {
            min-height: 7.2rem;
            height: 7.2rem;
        }
        .buscador-input-row {
            display: flex;
            align-items: center;
            width: 100%;
            height: 3.5rem;
            padding: 0 1.2rem;
        }
        .buscador-input {
            border: none;
            outline: none;
            background: transparent;
            font-size: 1.25rem;
            padding: 0.7rem 0.5rem;
            width: 100%;
            transition: width 0.3s;
        }
        .buscador-input::placeholder {
            color: #6c63ff;
            opacity: 0.7;
            font-weight: 500;
        }
        .buscador-btn {
            background: #7c5cff;
            color: #fff;
            border: none;
            border-radius: 0.8rem;
            width: 7.2rem;
            height: 2.5rem;
            display: flex;
            align-items: center;
            justify-content: center;
            margin-left: 1.2rem;
            font-size: 1.1rem;
            font-weight: 600;
            box-shadow: 0 2px 8px rgba(108,99,255,0.13);
            transition: background 0.2s, box-shadow 0.2s;
            cursor: pointer;
            gap: 0.5rem;
        }
        .buscador-btn:disabled {
            background: #bdbdbd;
            cursor: not-allowed;
        }
        .buscador-btn i {
            margin-right: 0.4rem;
        }
        .buscador-etiquetas {
            display: flex;
            gap: 2.5rem;
            justify-content: center;
            align-items: center;
            height: 3.5rem;
            margin-top: 0.2rem;
            transition: opacity 0.2s;
        }
        .buscador-chip {
            background: #f3f0ff;
            color: #6c63ff;
            border-radius: 1.2rem;
            padding: 0.7rem 2.5rem;
            font-size: 1.15rem;
            cursor: pointer;
            border: 1.5px solid transparent;
            transition: background 0.2s, color 0.2s, border 0.2s;
            user-select: none;
            font-weight: 500;
        }
        .buscador-chip.active {
            background: #6c63ff;
            color: #fff;
            border-color: #6c63ff;
        }
        .buscador-contenedor:not(.focused) .buscador-etiquetas {
            display: none !important;
        }
        .buscador-contenedor.focused .buscador-etiquetas {
            display: flex !important;
        }
        @media (max-width: 900px) {
            .buscador-gradient-border {
                width: 98vw;
                min-width: 0;
                max-width: 100vw;
            }
            .buscador-contenedor {
                width: 100vw;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        <!-- BUSCADOR -->
        <div class="row mb-4">
            <div class="col-12 d-flex justify-content-center">
                <form id="formBuscador" class="buscador-animado" autocomplete="off" onsubmit="return false;">
                    <div class="buscador-gradient-border">
                        <div class="buscador-contenedor">
                            <div class="buscador-input-row">
                                <input type="text" id="txtBusqueda" class="buscador-input" placeholder="¿Qué deseas buscar?" />
                                <button type="submit" class="buscador-btn"><i class="fas fa-search"></i></button>
                            </div>
                            <div class="buscador-etiquetas" style="display:none;">
                                <span class="buscador-chip active" data-tipo="tema">Tema</span>
                                <span class="buscador-chip" data-tipo="creador">Creador</span>
                            </div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
        <div class="row mb-4" id="resultadosBusquedaContainer" style="display:none;">
            <div class="col-12 col-md-10 offset-md-1">
                <div id="resultadosBusqueda"></div>
            </div>
        </div>
        <!-- FIN BUSCADOR -->
        
        <!-- Sección Nivel Básico -->
        <div class="carousel-row">
            <div class="d-flex justify-content-between align-items-center mb-2">
                <h3>Nivel Básico</h3>
                <a href="#">Ver más &gt;</a>
            </div>
            <div class="slider-wrapper">
                <asp:Repeater ID="rptBasico" runat="server" OnItemDataBound="rptMateriales_ItemDataBound">
                    <ItemTemplate>
                        <div class="slide-item">
                            <div id="bookCard" runat="server" class="card h-100 position-relative book-card" style="cursor:pointer;"
                                data-book-id='<%# Eval("idMaterial") %>'
                                data-titulo='<%# Eval("titulo") %>'
                                data-edicion='<%# Eval("edicion") %>'
                                data-anio='<%# Eval("anioPublicacion") %>'
                                data-portada-path='<%# Eval("portada") %>'
                                data-disponibles='<%# Eval("disponiblesFisicos") %>'
                            >
                                <asp:Panel ID="pnlAvailability" runat="server" CssClass="card-availability">
                                     <asp:Label ID="lblAvailability" runat="server"></asp:Label>
                                </asp:Panel>
                                <asp:Image ID="imgPortada" runat="server" CssClass="card-img-top-custom" />
                                <div class="card-body card-body-custom">
                                    <h5 class="card-title card-title-custom" title='<%# Eval("titulo") %>'><%# Eval("titulo") %></h5>
                                    <p class="card-author">by <asp:Label ID="lblAuthor" runat="server" Text="Desconocido"></asp:Label></p>
                                    <p class="card-text small"><a id="lnkDetalle" runat="server" class="text-primary" href="#">Ver detalle</a></p>
                                </div>
                                <div class="card-footer-custom">
                                     <asp:Button ID="btnBorrow" runat="server" CssClass="btn btn-primary btn-sm" Text="BORROW" />
                                     <a href="#" class="btn btn-light btn-sm"><i class="fas fa-bookmark"></i></a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="details-expander"></div>
        </div>

        <!-- Sección Nivel Intermedio -->
        <div class="carousel-row">
            <div class="d-flex justify-content-between align-items-center mb-2">
                <h3>Nivel Intermedio</h3>
                <a href="#">Ver más &gt;</a>
            </div>
            <div class="slider-wrapper">
                <asp:Repeater ID="rptIntermedio" runat="server" OnItemDataBound="rptMateriales_ItemDataBound">
                     <ItemTemplate>
                        <div class="slide-item">
                            <div class="card h-100 position-relative book-card" style="cursor:pointer;"
                                data-book-id='<%# Eval("idMaterial") %>'
                                data-titulo='<%# Eval("titulo") %>'
                                data-edicion='<%# Eval("edicion") %>'
                                data-anio='<%# Eval("anioPublicacion") %>'
                                data-portada-path='<%# Eval("portada") %>'
                                data-editorial='<%# Eval("editorial") != null ? Eval("editorial.nombre") : "N/A" %>'
                                data-nivel='<%# Eval("nivel") != null ? Eval("nivel.descripcion") : "N/A" %>'
                                data-disponibles='<%# Eval("disponiblesFisicos") %>'
                            >
                                <asp:Panel ID="pnlAvailability" runat="server" CssClass="card-availability">
                                     <asp:Label ID="lblAvailability" runat="server"></asp:Label>
                                </asp:Panel>
                                <asp:Image ID="imgPortada" runat="server" CssClass="card-img-top-custom" />
                                <div class="card-body card-body-custom">
                                    <h5 class="card-title card-title-custom" title='<%# Eval("titulo") %>'><%# Eval("titulo") %></h5>
                                    <p class="card-author">by <asp:Label ID="lblAuthor" runat="server" Text="Desconocido"></asp:Label></p>
                                    <p class="card-text small">
                                    <asp:LinkButton ID="lnkDetalle" runat="server"
                                    CssClass="text-primary"
                                    Text="Ver detalle"
                                    OnClick="lnkDetalle_Click" />
                                </div>
                                <div class="card-footer-custom">
                                     <asp:Button ID="btnBorrow" runat="server" CssClass="btn btn-primary btn-sm" Text="BORROW" />
                                     <a href="#" class="btn btn-light btn-sm"><i class="fas fa-bookmark"></i></a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
             <div class="details-expander"></div>
        </div>

        <!-- Sección Nivel Avanzado -->
        <div class="carousel-row">
            <div class="d-flex justify-content-between align-items-center mb-2">
                <h3>Nivel Avanzado</h3>
                <a href="#">Ver más &gt;</a>
            </div>
            <div class="slider-wrapper">
                <asp:Repeater ID="rptAvanzado" runat="server" OnItemDataBound="rptMateriales_ItemDataBound">
                     <ItemTemplate>
                        <div class="slide-item">
                            <div class="card h-100 position-relative book-card" style="cursor:pointer;"
                                data-book-id='<%# Eval("idMaterial") %>'
                                data-titulo='<%# Eval("titulo") %>'
                                data-edicion='<%# Eval("edicion") %>'
                                data-anio='<%# Eval("anioPublicacion") %>'
                                data-portada-path='<%# Eval("portada") %>'
                                data-editorial='<%# Eval("editorial") != null ? Eval("editorial.nombre") : "N/A" %>'
                                data-nivel='<%# Eval("nivel") != null ? Eval("nivel.descripcion") : "N/A" %>'
                                data-disponibles='<%# Eval("disponiblesFisicos") %>'
                            >
                                <asp:Panel ID="pnlAvailability" runat="server" CssClass="card-availability">
                                     <asp:Label ID="lblAvailability" runat="server"></asp:Label>
                                </asp:Panel>
                                <asp:Image ID="imgPortada" runat="server" CssClass="card-img-top-custom" />
                                <div class="card-body card-body-custom">
                                    <h5 class="card-title card-title-custom" title='<%# Eval("titulo") %>'><%# Eval("titulo") %></h5>
                                    <p class="card-author">by <asp:Label ID="lblAuthor" runat="server" Text="Desconocido"></asp:Label></p>
                                    <p class="card-text small">
                                    <a id="lnkDetalle" runat="server" class="text-primary" href="#">Ver detalle</a></p>
                                </div>
                                <div class="card-footer-custom">
                                        <asp:Button ID="btnBorrow" runat="server" CssClass="btn btn-primary btn-sm" Text="BORROW" />
                                        <a href="#" class="btn btn-light btn-sm"><i class="fas fa-bookmark"></i></a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:Button ID="btnTestFueraRepeater" runat="server" 
            Text="🚀 TEST AGREGAR ID 2 AL CARRITO"
            CssClass="btn btn-danger mt-3"
            OnClick="btnTestFueraRepeater_Click" />
             <div class="details-expander"></div>
        </div>
    </div>
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const bookCards = document.querySelectorAll('.book-card');

            function closeExpander(expander) {
                if (expander.classList.contains('open')) {
                    expander.classList.remove('open');
                    expander.addEventListener('transitionend', () => {
                        if (!expander.classList.contains('open')) {
                            expander.innerHTML = '';
                        }
                    }, { once: true });
                }
            }

            bookCards.forEach(card => {
                card.addEventListener('click', function(e) {
                    if (e.target.closest('button') || e.target.closest('a')) return;

                    const carouselRow = card.closest('.carousel-row');
                    const detailsExpander = carouselRow.querySelector('.details-expander');
                    const bookId = card.dataset.bookId;
                    const isAlreadyOpen = detailsExpander.classList.contains('open') && detailsExpander.dataset.bookId === bookId;

                    // Siempre cerrar cualquier panel abierto
                    document.querySelectorAll('.details-expander.open').forEach(closeExpander);

                    // Si el panel que se acaba de cerrar no era el que corresponde a este clic, ábrelo.
                    if (!isAlreadyOpen) {
                        const data = card.dataset;
                        const disponibilityText = parseInt(data.disponibles) > 0 ? `DISPONIBLE (${data.disponibles})` : 'NO DISPONIBLE';
                        const borrowButtonDisabled = parseInt(data.disponibles) > 0 ? '' : 'disabled';
                        const borrowButtonClass = parseInt(data.disponibles) > 0 ? 'btn-primary' : 'btn-secondary';
                        const imgUrl = card.querySelector('.card-img-top-custom').src;

                        const detailsHtml = `
                            <div class="details-content" style="position: relative;">
                                <button type="button" title="Cerrar" class="close-details-btn">&times;</button>
                                <div class="details-content-left">
                                    <h3>${data.titulo}</h3>
                                    <p><strong>Creadores:</strong> <span class="creadores-placeholder">Cargando...</span></p>
                                    <p><strong>Editorial:</strong> ${data.editorial || 'N/A'}</p>
                                    <p><strong>Edición:</strong> ${data.edicion || 'N/A'}</p>
                                    <p><strong>Año:</strong> ${data.anio || 'N/A'}</p>
                                    <p><strong>Nivel:</strong> ${data.nivel || 'N/A'}</p>
                                    <p><strong>Disponibilidad:</strong> ${disponibilityText}</p>
                                    <div style="margin-top: 2rem;">
                                        <button type="button" class="btn ${borrowButtonClass} btn-sm" ${borrowButtonDisabled}>BORROW</button>
                                        <a href="javascript:void(0);" class="btn btn-light btn-sm"><i class="fas fa-bookmark"></i></a>
                                    </div>
                                </div>
                                <div class="details-content-right">
                                    <img src="${imgUrl}" alt="Portada de ${data.titulo}" />
                                </div>
                            </div>`;
                        
                        detailsExpander.innerHTML = detailsHtml;
                        detailsExpander.dataset.bookId = bookId;
                        
                        detailsExpander.querySelector('.close-details-btn').addEventListener('click', () => closeExpander(detailsExpander));
                        
                        // --- AJAX call to get creators ---
                        fetch('RecursosUser.aspx/ObtenerCreadores', {
                            method: 'POST',
                            headers: { 'Content-Type': 'application/json; charset=utf-8' },
                            body: JSON.stringify({ idMaterial: bookId })
                        })
                        .then(response => response.json())
                        .then(data => {
                            const placeholder = detailsExpander.querySelector('.creadores-placeholder');
                            if (placeholder) {
                                placeholder.textContent = data.d || 'N/A';
                            }
                        })
                        .catch(error => {
                            const placeholder = detailsExpander.querySelector('.creadores-placeholder');
                            if (placeholder) {
                                placeholder.textContent = 'No se pudo cargar la información.';
                            }
                            console.error('Error fetching creators:', error);
                        });

                        setTimeout(() => {
                            detailsExpander.classList.add('open');
                            detailsExpander.scrollIntoView({ behavior: 'smooth', block: 'center' });
                        }, 10);
                    }
                });
            });

            // --- BUSCADOR ANIMADO ---
            const formBuscador = document.getElementById('formBuscador');
            const buscadorContenedor = formBuscador.querySelector('.buscador-contenedor');
            const input = document.getElementById('txtBusqueda');
            const etiquetas = buscadorContenedor.querySelector('.buscador-etiquetas');
            const chips = buscadorContenedor.querySelectorAll('.buscador-chip');
            const btn = buscadorContenedor.querySelector('.buscador-btn');
            let tipoBusqueda = 'titulo';

            // Expansión visual al enfocar
            input.addEventListener('focus', function () {
                buscadorContenedor.classList.add('focused');
                etiquetas.style.display = 'flex';
                btn.style.display = 'flex';
            });
            // Colapsar si pierde foco y no hay texto
            input.addEventListener('blur', function () {
                setTimeout(() => {
                    if (!input.value.trim()) {
                        buscadorContenedor.classList.remove('focused');
                        etiquetas.style.display = 'none';
                        btn.style.display = 'none';
                    }
                }, 120);
            });
            // Selección de tipo de búsqueda
            chips.forEach(chip => {
                chip.addEventListener('click', function () {
                    chips.forEach(c => c.classList.remove('active'));
                    this.classList.add('active');
                    tipoBusqueda = this.dataset.tipo;
                });
            });
            // Habilitar/deshabilitar botón
            input.addEventListener('input', function () {
                btn.disabled = !this.value.trim();
            });
            // Submit
            formBuscador.addEventListener('submit', function (e) {
                e.preventDefault();
                const texto = input.value.trim();
                if (!texto) return;
                // --- Lógica de búsqueda AJAX ---
                const resultadosContainer = document.getElementById('resultadosBusquedaContainer');
                const resultadosDiv = document.getElementById('resultadosBusqueda');
                const seccionesNiveles = document.querySelectorAll('.carousel-row');
                resultadosDiv.innerHTML = '<div class="text-center py-4"><span class="spinner-border"></span> Buscando...</div>';
                resultadosContainer.style.display = 'block';
                seccionesNiveles.forEach(sec => sec.style.display = 'none');
                fetch('RecursosUser.aspx/BuscarMateriales', {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json; charset=utf-8' },
                    body: JSON.stringify({ texto, tipo: tipoBusqueda })
                })
                .then(r => r.json())
                .then(data => {
                    resultadosDiv.innerHTML = data.d || '<div class="alert alert-warning">No se encontraron resultados.</div>';
                })
                .catch(() => {
                    resultadosDiv.innerHTML = '<div class="alert alert-danger">Error al buscar materiales.</div>';
                });
            });
            // Restaurar secciones si se borra el texto
            input.addEventListener('input', function () {
                if (!this.value.trim()) {
                    const resultadosContainer = document.getElementById('resultadosBusquedaContainer');
                    const resultadosDiv = document.getElementById('resultadosBusqueda');
                    const seccionesNiveles = document.querySelectorAll('.carousel-row');
                    resultadosContainer.style.display = 'none';
                    resultadosDiv.innerHTML = '';
                    seccionesNiveles.forEach(sec => sec.style.display = '');
                }
            });
            // --- FIN BUSCADOR ANIMADO ---
        });
    </script>
</asp:Content>
