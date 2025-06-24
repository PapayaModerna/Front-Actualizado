<%@ Page Title="Préstamos Activos" Language="C#" MasterPageFile="~/UserPerfilVista.Master" AutoEventWireup="true" CodeBehind="PrestamosUser.aspx.cs" Inherits="FrontEnd.PrestamosUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PerfilContent" runat="server">
    <h3 class="mb-4">Préstamos Activos</h3>
    <asp:GridView ID="gvPrestamosActivos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" EmptyDataText="No tienes préstamos activos.">
        <Columns>
            <asp:BoundField DataField="idPrestamo" HeaderText="ID Préstamo" />
            <asp:BoundField DataField="fechaSolicitud" HeaderText="Fecha Solicitud" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="fechaPrestamo" HeaderText="Fecha Préstamo" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="fechaDevolucion" HeaderText="Fecha Devolución" DataFormatString="{0:dd/MM/yyyy}" />
        </Columns>
    </asp:GridView>
</asp:Content>
