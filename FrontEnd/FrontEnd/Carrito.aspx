<%@ Page Title="" Language="C#" MasterPageFile="~/UserBiblio.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="FrontEnd.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btnEliminarTodos {
            background-color: #dc3545; /* Color rojo */
            color: white; /* Texto blanco */
            font-size: 18px; /* Tamaño de fuente */
            padding: 12px 24px; /* Espaciado dentro del botón */
            border: none; /* Sin borde */
            border-radius: 50px; /* Bordes redondeados */
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1); /* Sombra suave */
            cursor: pointer; /* Cambia el cursor cuando el mouse pasa sobre el botón */
            transition: background-color 0.3s, transform 0.3s; /* Transición para el hover */
        }

        .btnEliminarTodos:hover {
            background-color: #c82333; /* Color más oscuro al pasar el mouse */
            transform: scale(1.05); /* Efecto de aumento al pasar el mouse */
        }
    </style>
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
    <asp:Button ID="btnEliminarTodos" runat="server" Text="Eliminar Todos" 
                CssClass="btn btn-danger" OnClick="btnEliminarTodos_Click" />
    <asp:Button ID="btnSolicitarPrestamo" runat="server" Text="Solicitar Préstamo"
    CssClass="btn btn-success" OnClick="btnSolicitarPrestamo_Click" />
</asp:Content>
