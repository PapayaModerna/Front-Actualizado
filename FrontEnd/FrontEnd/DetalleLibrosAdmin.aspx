<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="DetalleLibrosAdmin.aspx.cs" Inherits="FrontEnd.DetalleLibrosAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/DetalleLibros.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="detalle-libro-container">
        <div class="detalle-titulo">Detalle del Libro</div>
        <div class="detalle-item">
            <span class="detalle-label">ID:</span>
            <span class="detalle-valor"><asp:Label ID="lblId" runat="server" /></span>
        </div>
        <div class="detalle-item">
            <span class="detalle-label">Título:</span>
            <span class="detalle-valor"><asp:Label ID="lblTitulo" runat="server" /></span>
        </div>
        <div class="detalle-item">
            <span class="detalle-label">Editorial:</span>
            <span class="detalle-valor"><asp:Label ID="lblEditorial" runat="server" /></span>
        </div>
        <div class="detalle-item">
            <span class="detalle-label">Año:</span>
            <span class="detalle-valor"><asp:Label ID="lblAnio" runat="server" /></span>
        </div>
        <div class="detalle-item">
            <span class="detalle-label">Edicion:</span>
            <span class="detalle-valor"><asp:Label ID="lblEdicion" runat="server" /></span>
        </div>
        <div class="detalle-item">
            <span class="detalle-label">Creadores:</span>
            <span class="detalle-valor"><asp:Label ID="lblCreadores" runat="server" /></span>
        </div>
        <div class="detalle-item">
            <span class="detalle-label">Temas:</span>
            <span class="detalle-valor"><asp:Label ID="lblTemas" runat="server" /></span>
        </div>
        <div style="margin-top:30px; display:flex; gap:10px;">
            <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-volver" OnClick="btnVolver_Click" />
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn-volver" OnClick="btnEditar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn-volver" OnClick="btnEliminar_Click" />
            <asp:Button ID="btnEjemplares" runat="server" Text="Ver Ejemplares" CssClass="btn-volver" OnClick="btnEjemplares_Click" />
        </div>
    </div>
</asp:Content>
