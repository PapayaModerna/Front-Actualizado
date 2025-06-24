<%@ Page Title="" Language="C#" MasterPageFile="~/UserBiblio.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="FrontEnd.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">Carrito de Préstamo</h2>

    <asp:Repeater ID="rptCarrito" runat="server">
        <HeaderTemplate>
            <table class="table table-bordered">
                <thead>
                    <tr>
                        <th>ID del Ejemplar</th>
                    </tr>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
                    <tr>
                        <td><%# Container.DataItem %></td>
                    </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>
        </FooterTemplate>
    </asp:Repeater>

    <asp:Label ID="lblVacio" runat="server" Text="No hay ejemplares en el carrito." CssClass="text-muted" Visible="false" />
    <asp:Button ID="btnSolicitarPrestamo" runat="server" Text="Solicitar Préstamo"
    CssClass="btn btn-success" OnClick="btnSolicitarPrestamo_Click" />
</asp:Content>
