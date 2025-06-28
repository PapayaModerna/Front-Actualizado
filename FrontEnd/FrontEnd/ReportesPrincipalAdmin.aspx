<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="ReportesPrincipalAdmin.aspx.cs" Inherits="FrontEnd.ReportesAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="server">
    <h4 class="mb-4">Reportes</h4>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/DetalleLibros.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <div class="col-md-6 mx-auto">
                <div class="detalle-libro-container text-center py-5">
                    <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphScripts" runat="server">
</asp:Content>
