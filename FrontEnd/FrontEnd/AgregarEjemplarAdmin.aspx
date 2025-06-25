<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="AgregarEjemplarAdmin.aspx.cs" Inherits="FrontEnd.AgregarEjemplarAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/InsertarMaterial.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="main-title">
        Inserte los detalles del nuevo ejemplar
    </div>

    <asp:Panel ID="pnlSuccess" runat="server" CssClass="success-message-modificar-usuario" Visible="false">
        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" CssClass="error-message-modificar-usuario" Visible="false">
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </asp:Panel>

    <div class="form-container">
        <div class="grid">
            <!-- Sede y Ubicación -->
            <div class="form-group">
                <label for="ddlSede" class="form-label">Sede:</label>
                <asp:DropDownList ID="ddlSede" runat="server" CssClass="form-control" />

                <label for="txtUbicacion" class="form-label">Ubicación:</label>
                <asp:TextBox ID="txtUbicacion" runat="server" placeholder="Ingrese la ubicación" CssClass="form-control" />
            </div>

            <!-- Tipo y Fecha de Adquisición -->
            <div class="form-group">
                <label for="ddlTipo" class="form-label">Tipo de Ejemplar:</label>
                <asp:DropDownList ID="ddlTipo" runat="server" CssClass="form-control" />

                <label for="txtFechaAdquisicion" class="form-label">Fecha de Adquisición:</label>
                <asp:TextBox ID="txtFechaAdquisicion" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
        </div>

        <!-- Disponible -->
        <div class="form-group">
            <label for="chkDisponible" class="form-label">Disponible:</label>
            <asp:CheckBox ID="chkDisponible" runat="server" />
        </div>

        <!-- Formato Digital (opcional) -->
        <div class="form-group">
            <label for="ddlFormatoDigital" class="form-label">Formato Digital (si aplica):</label>
            <asp:DropDownList ID="ddlFormatoDigital" runat="server" CssClass="form-control" />
        </div>

        

        <div class="d-flex justify-content-center gap-3 align-items-center">
            <asp:Button ID="btnVolver" runat="server" CssClass="btn custom-btn" Text="Volver" OnClick="btnVolver_Click" />
            <asp:Button ID="btnAgregar" runat="server" CssClass="btn custom-btn" Text="Agregar Ejemplar" OnClick="btnAgregar_Click" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>