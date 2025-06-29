<%@ Page Title="" Language="C#" MasterPageFile="~/UserBiblio.Master" AutoEventWireup="true" CodeBehind="RecursosUser.aspx.cs" Inherits="FrontEnd.RecursosUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css" />
    <style>
        body {
            font-family: 'Roboto', sans-serif;
        }

        h1 {
            font-size: 1.5rem;
            text-align: left;
            margin-left: 20px;
            margin-bottom: 20px;
            color: #333;
        }

        html.dark-mode h1 {
            color: white;
        }

        .buscador-animado {
            width: 100%;
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding-left: 20px;
            margin-bottom: 30px;
        }

        .buscador-contenedor {
            background: white;
            border-radius: 1.2rem;
            display: flex;
            flex-direction: row;
            align-items: center;
            width: 100%;
            max-width: 800px;
            height: 3.5rem;
            overflow: hidden;
            position: relative;
            border: 1px solid #ccc;
            padding: 5px 15px;
        }

        .buscador-input {
            border: none;
            outline: none;
            background: transparent;
            font-size: 1.25rem;
            padding: 0.7rem 0.5rem;
            width: 70%;
        }

        .buscador-btn {
            background: #7c5cff;
            color: #fff;
            border: none;
            border-radius: 0.8rem;
            width: auto;
            height: 2.5rem;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 1.1rem;
            font-weight: 600;
            cursor: pointer;
            padding: 0 15px;
        }

        .buscador-ddls {
            display: flex;
            justify-content: flex-end;
            gap: 10px;
            padding-right: 20px;
            width: 30%;
        }

        .buscador-ddls select {
            font-size: 1rem;
            padding: 0.5rem;
            border-radius: 1rem;
            border: 1px solid #ccc;
            background-color: #fff;
            width: 100%;
        }

        #resultadosBusquedaContainer {
            display: flex;
            justify-content: center;
            flex-wrap: wrap;
            gap: 20px;
        }

        .card {
            display: flex;
            flex-direction: row;
            width: 22rem;
            margin: 10px;
            padding: 15px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            border-radius: 10px;
            overflow: hidden;
            transition: transform 0.3s ease;
        }

        .card:hover {
            transform: scale(1.05);
        }

        .card-img-top {
            max-width: 120px;
            max-height: 180px;
            object-fit: cover;
            margin-right: 15px;
        }

        .card-body {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: flex-start;
            flex-grow: 1;
        }

        .card-title {
            font-size: 1.2rem;
            font-weight: bold;
            margin-bottom: 10px;
        }

        .card-text {
            margin-bottom: 5px;
        }

        .btn {
            margin-top: 10px;
        }

        .paginacion {
            display: flex;
            justify-content: center;
            margin-top: 20px;
        }

        .paginacion .btn {
            background-color: #7c5cff;
            color: white;
            border: none;
            padding: 10px 20px;
            margin: 0 5px;
            font-weight: 600;
            cursor: pointer;
            border-radius: 5px;
        }

        .paginacion .btn:hover {
            background-color: #6a47e3;
        }

        .paginacion .btn:disabled {
            background-color: #ddd;
            cursor: not-allowed;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        <div class="row mb-4">
            <div class="col-12 d-flex justify-content-start">
                <h1>Inventario de Biblioteca</h1>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-12 d-flex justify-content-between">
                <form id="formBuscador" class="buscador-animado" autocomplete="off" method="post">
                    <div class="buscador-contenedor">
                        <asp:TextBox ID="txtBusqueda" runat="server" class="buscador-input" placeholder="Buscar..." />
                        <asp:Button ID="btnBuscar" runat="server" CssClass="buscador-btn" Text="Buscar" OnClick="realizarBusqueda" />
                        <div class="buscador-ddls">
                            <asp:DropDownList ID="ddlTemas" runat="server" class="form-control"></asp:DropDownList>
                            <asp:DropDownList ID="ddlAutor" runat="server" class="form-control"></asp:DropDownList>
                            <asp:DropDownList ID="ddlNivel" runat="server" class="form-control"></asp:DropDownList>
                        </div>
                    </div>
                </form>
            </div>
        </div>

        <div id="resultadosBusquedaContainer" runat="server" class="row" style="display:none;">
            <div class="col-12 d-flex flex-wrap">
                <asp:Repeater ID="rptResultados" runat="server">
                    <ItemTemplate>
                        <div class="card" style="width: 18rem; margin: 10px; display: flex; flex-direction: column; justify-content: space-between;">
                            <img src='<%# ResolveUrl("~/Images/Portadas/portadaprueba.jpg") %>' class="card-img-top" alt="Imagen del material">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("titulo") %></h5>
                                <p class="card-text">Editorial ID: <%# Eval("editorial.idEditorial") %></p>
                                <p class="card-text">Año de Publicación: <%# Eval("anioPublicacion") %></p>
                                <a href='<%# "DetalleRecurso.aspx?idMaterial=" + Eval("idMaterial") %>' class="btn btn-primary">Ver detalles</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <div class="paginacion">
                    <asp:Repeater ID="rptPaginacion" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPagina" runat="server" CommandArgument='<%# Eval("NumeroPagina") %>' OnClick="lnkPagina_Click" CssClass="btn btn-light">
                                <%# Eval("NumeroPagina") %>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
