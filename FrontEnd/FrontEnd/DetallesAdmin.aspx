<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="DetallesAdmin.aspx.cs" Inherits="FrontEnd.DetallesAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/DetallesPersona.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="profile-section">
        <!-- Header: Avatar, Nombre y Cerrar sesión -->
        <div class="profile-header d-flex align-items-center justify-content-between mb-4">
            <div class="d-flex align-items-center">
                <div class="avatar-circle me-3">
                    <asp:Label ID="lblInicialUsuario" runat="server" CssClass="initial-label" />
                </div>
                <div class="profile-name">
                    <strong><asp:Label ID="lblNombreCompleto" runat="server" /></strong>
                </div>
            </div>
            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger btn-logout" Text="Cerrar sesión" OnClick="btnLogout_Click" />
        </div>

        <!-- Información personal (solo lectura) -->
        <h4 class="mt-2 mb-5"><strong>Información personal:</strong></h4>
        <div class="row mb-3">
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Nombre</strong></h5>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="True" />
            </div>
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Código</strong></h5>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>

        <div class="row mt-2 mb-4">
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Primer apellido</strong></h5>
                <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control" ReadOnly="True" />
            </div>
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Segundo apellido</strong></h5>
                <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>

        <!-- Información adicional (turno y fechas de contrato) -->
        <h4 class="mt-5 mb-5"><strong>Información adicional:</strong></h4>
        <div class="row mb-3">
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Turno</strong></h5>
                <asp:TextBox ID="txtTurno" runat="server" CssClass="form-control" ReadOnly="True" />
            </div>
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Fecha de inicio del contrato</strong></h5>
                <asp:TextBox ID="txtFechaContratoInicio" runat="server" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Fecha de fin del contrato</strong></h5>
                <asp:TextBox ID="txtFechaContratoFin" runat="server" CssClass="form-control" ReadOnly="True" />
            </div>
        </div>

        <!-- Información de cuenta (editable) -->
        <h4 class="mt-5 mb-5"><strong>Información de cuenta:</strong></h4>
        <div class="row mb-3">
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Correo</strong></h5>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-6">
                <h5 class="form-label mb-3"><strong>Teléfono</strong></h5>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-md-6">
                <h5 for="direccion" class="form-label mb-3"><strong>Dirección</strong></h5>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" />
            </div>
            <div class="col-md-6">
                <h5 for="nuevaContrasena" class="form-label mb-3"><strong>Nueva contraseña</strong></h5>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
            </div>
        </div>

        <div class="col-12 d-flex justify-content-center">
            <asp:Button ID="btnGuardarCambios" runat="server" CssClass="btn btn-success btn-guardar" Text="Guardar cambios" OnClick="btnGuardar_Click" />
        </div>
    </div>
</asp:Content>

