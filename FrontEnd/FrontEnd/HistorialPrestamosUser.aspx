<%@ Page Title="Historial de Préstamos" Language="C#" MasterPageFile="~/UserPerfilVista.Master" AutoEventWireup="true" CodeBehind="HistorialPrestamosUser.aspx.cs" Inherits="FrontEnd.HistorialPrestamosUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="PerfilContent" runat="server">
    <h3 class="mb-4">Historial de Préstamos</h3>
    <asp:GridView ID="gvHistorialPrestamos" runat="server" CssClass="table table-striped" AutoGenerateColumns="false" EmptyDataText="No tienes préstamos registrados.">
        <Columns>
            <asp:BoundField DataField="idPrestamo" HeaderText="ID Préstamo" />
            <asp:BoundField DataField="fechaSolicitud" HeaderText="Fecha Solicitud" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="fechaPrestamo" HeaderText="Fecha Préstamo" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="fechaDevolucion" HeaderText="Fecha Devolución" DataFormatString="{0:dd/MM/yyyy}" />
        </Columns>
    </asp:GridView>
</asp:Content>
