<%@ Page Title="" Language="C#" MasterPageFile="~/UserBiblio.Master" AutoEventWireup="true" CodeBehind="IndexUser.aspx.cs" Inherits="FrontEnd.IndexUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Banner de anuncios -->
    <div class="alert alert-info mb-4" role="alert">
        <!-- Aquí puedes colocar anuncios importantes para los usuarios -->
    </div>
    <!-- Lista de libros disponibles -->
    <div class="card">
        <div class="card-header bg-primary text-white">
            Libros disponibles
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item">Cien años de soledad - Gabriel García Márquez</li>
            <li class="list-group-item">Don Quijote de la Mancha - Miguel de Cervantes</li>
            <li class="list-group-item">Rayuela - Julio Cortázar</li>
            <li class="list-group-item">La sombra del viento - Carlos Ruiz Zafón</li>
            <li class="list-group-item">El amor en los tiempos del cólera - Gabriel García Márquez</li>
        </ul>
    </div>
</asp:Content>
