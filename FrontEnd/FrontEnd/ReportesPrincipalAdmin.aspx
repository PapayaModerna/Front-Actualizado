<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="ReportesPrincipalAdmin.aspx.cs" Inherits="FrontEnd.ReportesAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    <h4 class="mb-4">Reportes</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <title>Reportes Administrativos</title>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div style="margin: 40px;">
        <div style="margin-bottom: 20px;">
            <asp:Label ID="lblSede" runat="server" Text="Sede:" AssociatedControlID="ddlSede" />
            <asp:DropDownList ID="ddlSede" runat="server" />
            &nbsp;&nbsp;
            <asp:Label ID="lblAnho" runat="server" Text="Año:" AssociatedControlID="ddlAnho" />
            <asp:DropDownList ID="ddlAnho" runat="server" />
            &nbsp;&nbsp;
            <asp:Label ID="lblMes" runat="server" Text="Mes:" AssociatedControlID="ddlMes" />
            <asp:DropDownList ID="ddlMes" runat="server" />
        </div>
        <asp:Button ID="btnGenerarReporteGeneral" runat="server" Text="Generar Reporte General" OnClick="btnGenerarReporteGeneral_Click" CssClass="btn btn-primary" />
        &nbsp;
        <asp:Button ID="btnMaterialesMasSolicitados" runat="server" Text="Materiales Más Solicitados" OnClick="btnMaterialesMasSolicitados_Click" CssClass="btn btn-secondary" />
    </div>
</asp:Content>