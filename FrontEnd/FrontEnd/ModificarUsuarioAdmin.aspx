<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="ModificarUsuarioAdmin.aspx.cs" Inherits="FrontEnd.ModificarUsuarioAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/EditarMaterial.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="main-title">
    Modifique los datos del usuario
    </div>
    <asp:Panel ID="pnlSuccess" runat="server" CssClass="success-message-modificar-usuario" Visible="false">
        <asp:Label ID="lblSuccess" runat="server"></asp:Label>
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" CssClass="error-message-modificar-usuario" Visible="false">
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </asp:Panel>
    <div class="form-container">
        <div class="grid">
            <div class="form-group">
                <label class="form-label">Código:</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" MaxLength="20" />
                
                <label class="form-label">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" />
                
                <label class="form-label">Apellido Paterno:</label>
                <asp:TextBox ID="txtPaterno" runat="server" CssClass="form-control" MaxLength="50" />
                
                <label class="form-label">Apellido Materno:</label>
                <asp:TextBox ID="txtMaterno" runat="server" CssClass="form-control" MaxLength="50" />
                
                <label class="form-label">Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" MaxLength="100" />
            </div>
            <div class="form-group">
                <label class="form-label">Teléfono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="20" />
                
                <label class="form-label">Correo:</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" MaxLength="100" />
                
                <label class="form-label">Contraseña:</label>
                <asp:TextBox ID="txtContrasenha" runat="server" CssClass="form-control" TextMode="Password" MaxLength="50" />
                
                <label class="form-label">Tipo de Usuario:</label>
                <asp:DropDownList ID="ddlTipoPersona" runat="server" CssClass="form-control" />
                
                <label class="form-label">Turno:</label>
                <asp:DropDownList ID="ddlTurno" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="grid">
            <div class="form-group">
                <label class="form-label">Fecha Contrato Inicio:</label>
                <asp:TextBox ID="txtFechaContratoInicio" runat="server" CssClass="form-control" TextMode="Date" />
                
                <label class="form-label">Fecha Contrato Final:</label>
                <asp:TextBox ID="txtFechaContratoFinal" runat="server" CssClass="form-control" TextMode="Date" />
                
                <label class="form-label">Deuda:</label>
                <asp:TextBox ID="txtDeuda" runat="server" CssClass="form-control" TextMode="Number" />
                
                <label class="form-label">Fecha Sanción Final:</label>
                <asp:TextBox ID="txtFechaSancionFinal" runat="server" CssClass="form-control" TextMode="Date" />
            </div>
            <div class="form-group">
                <label class="form-label">Vigente:</label>
                <asp:CheckBox ID="chkVigente" runat="server" CssClass="form-check-input" />
                
                <label class="form-label">Nivel de Inglés:</label>
                <asp:DropDownList ID="ddlNivelIngles" runat="server" CssClass="form-control" />
                
                <label class="form-label">Sede:</label>
                <asp:DropDownList ID="ddlSede" runat="server" CssClass="form-control" />
            </div>
        </div>
        <div class="d-flex justify-content-center gap-3 align-items-center">
            <asp:Button ID="btnVolver" runat="server" CssClass="btn custom-btn" Text="Volver" OnClick="btnVolver_Click" />
            <asp:Button ID="btnActualizar" runat="server" CssClass="btn custom-btn" Text="Actualizar Usuario" OnClick="btnActualizar_Click" />
        </div>
        <asp:HiddenField ID="hfIdPersona" runat="server" />
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>