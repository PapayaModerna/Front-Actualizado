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
}

.buscador-gradient-border {
    background: linear-gradient(90deg, #1e3c72, #232526);
    padding: 6px;
    border-radius: 1rem;
    transition: box-shadow 0.3s;
    box-shadow: 0 4px 24px 0 rgba(31, 38, 135, 0.10);
    width: 100%;
    max-width: 100%;
}

.buscador-contenedor {
    background: white;
    border-radius: 1.2rem;
    display: flex;
    flex-direction: row;
    align-items: center;
    width: 100%;
    max-width: 100%;
    min-height: 3.5rem;
    height: 3.5rem;
    overflow: hidden;
    position: relative;
    border: 1px solid #ccc; 
}

.buscador-input-row {
    display: flex;
    align-items: center;
    width: 100%;
    height: 3.5rem;
    padding: 0 1.2rem;
}

.buscador-input {
    border: none;
    outline: none;
    background: transparent;
    font-size: 1.25rem;
    padding: 0.7rem 0.5rem;
    width: 100%;
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
    margin-left: 1.2rem;
    font-size: 1.1rem;
    font-weight: 600;
    cursor: pointer;
    padding: 0 10px; 
}

.buscador-ddls {
    display: flex;
    justify-content: flex-end;
    gap: 10px;
    padding-right: 20px;
}

.buscador-ddls select {
    font-size: 1rem;
    padding: 0.5rem;
    border-radius: 1rem;
    border: 1px solid #ccc;
    background-color: #fff;
    width: 110px; 
}

.buscador-ddls select option {
    font-size: 1rem;
}

html.dark-mode .buscador-gradient-border {
    background: linear-gradient(90deg, #232526, #414345);
}

html.dark-mode .buscador-contenedor {
    background-color: #2b3035;
    border-color: #495057;
}

html.dark-mode .buscador-btn {
    background-color: #7c5cff;
}

.buscador-ddls select {
    color: #333;
}

html.dark-mode .buscador-ddls select {
    background-color: #495057;
    color: #fff;
}
html.dark-mode {
    background-color: #1e1e1e;
    color: white;
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
                        <button type="submit" class="buscador-btn" runat="server" Text="Buscar" OnClick="realizarBusqueda">
                            <i class="fas fa-search"></i>
                        </button>

                        <div class="buscador-ddls">
                            <asp:DropDownList ID="ddlTemas" runat="server" class="form-control">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlAutor" runat="server" class="form-control">
                            </asp:DropDownList>
                            <asp:DropDownList ID="ddlNivel" runat="server" class="form-control">
                            </asp:DropDownList>
                        </div>
                    </div>
                </form>
            </div>
        </div>

        <div id="resultadosBusquedaContainer" class="row" style="display:none;">
            <div class="col-12">
                <asp:Repeater ID="rptResultados" runat="server">
                    <ItemTemplate>
                        <div class="card" style="width: 18rem; margin: 10px;">
                            <img src="~/images/default.jpg" class="card-img-top" alt="Imagen del material">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("titulo") %></h5>
                                <p class="card-text">Editorial: <%# Eval("idEditorial") %></p>
                                <p class="card-text">Año Publicación: <%# Eval("anhoPublicacion") %></p>
                                <a href="#" class="btn btn-primary">Ver detalles</a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
