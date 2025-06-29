<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleRecurso.aspx.cs" Inherits="FrontEnd.DetalleRecurso" MasterPageFile="~/UserBiblio.Master" %>    <asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
        <style>
            body {
                font-family: 'Roboto', sans-serif;
                background-color: #f2f4f8;
            }
        
            html.dark-mode {
                background-color: #121212;
                color: white;
            }

            .detalle-container {
                display: flex;
                justify-content: center;
                align-items: center;
                flex-direction: column;
                padding: 2rem;
            }

            .detalle-card {
                background-color: #fff;
                border-radius: 1rem;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
                width: 80%;
                max-width: 800px;
                padding: 2rem;
                margin: 1rem;
            }

            .detalle-card h1 {
                font-size: 3rem;
                color: #333;
                text-align: center;
                margin-bottom: 1rem;
            }

            .detalle-card img {
                width: 150px;
                height: 220px;
                margin: 0 auto;
                display: block;
                border-radius: 10px;
            }

            .detalle-info {
                margin-top: 1.5rem;
                font-size: 1.1rem;
            }

            .detalle-info p {
                margin: 0.5rem 0;
                font-weight: bold;
            }

            .detalle-info span {
                font-weight: normal;
            }

            .detalle-btns {
                margin-top: 2rem;
                display: flex;
                justify-content: space-between;
                width: 100%;
            }

            .detalle-btns a {
                text-align: center;
                background-color: #7c5cff;
                color: white;
                padding: 1rem 2rem;
                border-radius: 1rem;
                text-decoration: none;
                font-weight: 600;
                width: 48%;
                text-transform: uppercase;
            }

            .detalle-btns a:hover {
                background-color: #6a47e3;
            }

            .detalle-btns .btn-return {
                background-color: #bbb;
            }

            .detalle-btns .btn-return:hover {
                background-color: #999;
            }

            html.dark-mode .detalle-card {
                background-color: #2b3035;
                box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
            }

            html.dark-mode .detalle-card h1 {
                color: white;
            }

            html.dark-mode .detalle-info {
                color: white;
            }
        </style>
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="detalle-container">
        <div class="detalle-card">
            <h1><asp:Label ID="detalleTitulo" runat="server" CssClass="card-title" /></h1>
            <asp:Image ID="detalleImagen" runat="server" Width="150" Height="220" CssClass="card-img-top" />

            <div class="detalle-info">
                <p>Año de Publicación: <span><asp:Label ID="detalleAnio" runat="server" /></span></p>
                <p>Editorial: <span><asp:Label ID="detalleEditorial" runat="server" /></span></p>
                <p>Creador: <span><asp:Label ID="detalleCreador" runat="server" /></span></p>
                <p>Nivel de Inglés: <span><asp:Label ID="detalleNivel" runat="server" /></span></p>
                <p>Disponibilidad: <span><asp:Label ID="detalleStock" runat="server" /></span></p>
            </div>
            <div class="detalle-btns">
                <asp:Button ID="btnVerEjemplares" runat="server" Text="Ver Ejemplares" CssClass="btn-primary" OnClick="btnVerEjemplares_Click" />
                <a href="RecursosUser.aspx" class="btn-return">Regresar</a>
            </div>
        </div>
    </div>
</asp:Content>

