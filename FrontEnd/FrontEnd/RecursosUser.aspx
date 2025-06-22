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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        
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
        });
    </script>
</asp:Content>
