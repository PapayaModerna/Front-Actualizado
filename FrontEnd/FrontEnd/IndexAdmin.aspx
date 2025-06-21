<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="FrontEnd.IndexAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .banner-negro {
            background-color: #000;
            width: 100%;
            padding: 15px 0 15px 40px;
        }

        .bienvenida-container {
            font-family: 'Roboto', sans-serif;
        }

        #bienvenida {
            font-size: 2.5rem;
            font-weight: bold;
            color: #fff;
            overflow: hidden;
            white-space: nowrap;
            animation: typing 2.5s steps(39, end) forwards;
            letter-spacing: 2px;
        }

        @keyframes typing {
            from { width: 0; opacity: 0; }
            to { width: 100%; opacity: 1; }
        }

        .carrusel-container {
            width: 100%;
            overflow: hidden;
            margin-top: 30px;
            height: 320px;
        }

        .carrusel-slide {
            display: flex;
            width: calc(100% * 2);
            animation: slideCarrusel 20s infinite;
            transition: transform 1s ease-in-out;
        }

        .carrusel-slide img {
            width: 100%;
            flex: 0 0 100%;
            height: 320px;
            object-fit: cover;
        }

        @keyframes slideCarrusel {
            0%, 40%   { transform: translateX(0%); }
            50%, 90%  { transform: translateX(-100%); }
            100%      { transform: translateX(0%); }
        }

        .tabla-libros-container {
            margin: 40px auto;
            width: 80%;
            max-width: 900px;
        }

        .tabla-libros {
            width: 100%;
            border-collapse: collapse;
            font-family: 'Roboto', sans-serif;
            background-color: white;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 0 10px rgba(0,0,0,0.05);
        }

        .tabla-libros thead {
            background-color: #343a40;
            color: white;
        }

        .tabla-libros th,
        .tabla-libros td {
            padding: 14px 20px;
            text-align: left;
            font-size: 1rem;
        }

        .tabla-libros tbody tr {
            transition: background-color 0.2s ease;
            cursor: pointer;
        }

        .tabla-libros tbody tr:hover {
            background-color: #f1f1f1;
        }
        .buscador-container {
            margin: 40px 0 20px 40px;
            position: relative;
            width: calc(100% - 80px);
            max-width: 1200px;
        }

        .input-buscador {
            width: 100%;
            padding: 14px 50px 14px 16px;
            border: 2px solid #ccc;
            border-radius: 30px;
            font-size: 1rem;
            outline: none;
            transition: border 0.3s ease;
            box-sizing: border-box;
        }

        .btn-buscador {
            position: absolute;
            top: 50%;
            right: 20px;
            transform: translateY(-50%);
            background: none;
            border: none;
            color: #333;
            font-size: 1.2rem;
            cursor: pointer;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="banner-negro">
        <div class="bienvenida-container">
            <h1 id="bienvenida"></h1>
        </div>
    </div>

    <div class="carrusel-container">
        <div class="carrusel-slide">
            <img src="Images/biblio_carrusel.jpeg" alt="Imagen 1" />
            <img src="Images/carrusel_biblio_02.jpg" alt="Imagen 2" />
        </div>
    </div>    
    
    <div class="buscador-container">
        <asp:TextBox ID="txtBuscar" runat="server" CssClass="input-buscador" 
            placeholder="Buscar libros disponibles..." AutoPostBack="true" 
            OnTextChanged="txtBuscar_TextChanged" />
        <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn-buscador" OnClick="btnBuscar_Click">
            <i class="fas fa-search"></i>
        </asp:LinkButton>
    </div>

    <asp:UpdatePanel ID="UpdatePanelLibros" runat="server">
        <ContentTemplate>
            <div class="tabla-libros-container">
                <table class="tabla-libros">
                    <thead>
                        <tr>
                            <th>ID</th>
                            <th>Título</th>
                        </tr>
                    </thead>
                    <tbody>
                        <asp:Repeater ID="rptLibros" runat="server">
                            <ItemTemplate>
                                <tr onclick="irDetalle('<%# Eval("idMaterial") %>')">
                                    <td><%# string.Format("{0:000}", Eval("idMaterial")) %></td>
                                    <td><%# Eval("titulo") %></td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <script>
        document.addEventListener("DOMContentLoaded", function () {
            const mensaje = "BIENVENIDO A TU SISTEMA DE BIBLIOTECAS";
            const bienvenida = document.getElementById("bienvenida");
            let index = 0;

            function escribirLetra() {
                if (index < mensaje.length) {
                    bienvenida.textContent += mensaje.charAt(index);
                    index++;
                    setTimeout(escribirLetra, 80);
                }
            }

            escribirLetra();
        });

        function irDetalle(id) {
            window.location.href = 'DetalleLibro.aspx?id=' + id;
        }
    </script>
</asp:Content>
