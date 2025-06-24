<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="DetalleLibrosAdmin.aspx.cs" Inherits="FrontEnd.DetalleLibrosAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/DetalleLibros.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container-fluid">
    <div class="row align-items-start">
        <!-- Detalle del libro -->
        <div class="col-md-8">
            <div class="detalle-libro-container">
            <h4 class="mb-4">Detalle del Libro</h4>

            <div class="mb-2">
                <strong>ID:</strong> <asp:Label ID="lblId" runat="server" CssClass="ms-2" />
            </div>
            <div class="mb-2">
                <strong>Título:</strong> <asp:Label ID="lblTitulo" runat="server" CssClass="ms-2" />
            </div>
            <div class="mb-2">
                <strong>Editorial:</strong> <asp:Label ID="lblEditorial" runat="server" CssClass="ms-2" />
            </div>
            <div class="mb-2">
                <strong>Año:</strong> <asp:Label ID="lblAnio" runat="server" CssClass="ms-2" />
            </div>
            <div class="mb-2">
                <strong>Edición:</strong> <asp:Label ID="lblEdicion" runat="server" CssClass="ms-2" />
            </div>
            <div class="mb-2">
                <strong>Creadores:</strong> <asp:Label ID="lblCreadores" runat="server" CssClass="ms-2" />
            </div>
            <div class="mb-4">
                <strong>Temas:</strong> <asp:Label ID="lblTemas" runat="server" CssClass="ms-2" />
            </div>

            <!-- Botones -->
            <div class="d-flex flex-wrap gap-2">
                <!-- Línea 1: Editar, Eliminar, Ver Ejemplares -->
                <div class="d-flex flex-wrap justify-content-center gap-2 w-100">
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn-volver" OnClick="btnEditar_Click" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-volver" OnClick="btnEliminar_Click" />
                    <asp:Button ID="btnEjemplares" runat="server" Text="Ver Ejemplares" CssClass="btn-volver" OnClick="btnEjemplares_Click" />
                </div>

                <!-- Línea 2: Volver (centrado) -->
                <div class="w-100 d-flex justify-content-center mt-2">
                    <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-volver" OnClick="btnVolver_Click" />
                </div>
            </div>

            </div>
        </div>

        <!-- Imagen de la portada -->
        <div class="col-md-4 text-center">
            <asp:Image ID="imgPortada" runat="server" CssClass="img-fluid portada-img mt-3 mt-md-0" />
        </div>
    </div>
    
        
</asp:Content>
