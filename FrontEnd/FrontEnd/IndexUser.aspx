﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UserBiblio.Master" AutoEventWireup="true" CodeBehind="IndexUser.aspx.cs" Inherits="FrontEnd.IndexUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="alert alert-info mb-4" role="alert">
    </div>
    <div class="card">
        <div class="card-header bg-primary text-white">
            Libros disponibles
        </div>
        <ul class="list-group list-group-flush">
            <li class="list-group-item">Cambiar - Cambiar</li>
            <li class="list-group-item">Don Quijote de la Mancha - Miguel de Cervantes</li>
            <li class="list-group-item">Rayuela - Julio Cortázar</li>
            <li class="list-group-item">La sombra del viento - Carlos Ruiz Zafón</li>
            <li class="list-group-item">El amor en los tiempos del cólera - Gabriel García Márquez</li>
        </ul>
    </div>
</asp:Content>
