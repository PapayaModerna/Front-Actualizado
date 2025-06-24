<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="RecojoPrestamo.aspx.cs" Inherits="FrontEnd.RecojoPrestamo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            font-family: 'Roboto', sans-serif;
        }
        .button-container {
            margin-top: 30px;
            text-align: right;
            display: flex;
            justify-content: flex-end;
            gap: 15px;
        }

        .btn {
            padding: 12px 24px;
            font-size: 16px;
            cursor: pointer;
            border-radius: 8px;
            transition: background-color 0.3s ease, transform 0.2s ease;
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.1);
            font-family: 'Roboto', sans-serif;
        }

        .btn-success {
            background-color: #28a745;
            border: 1px solid #28a745;
            color: white;
        }
        .btn-success:hover {
            background-color: #218838;
            transform: scale(1.05);
        }

        .btn-secondary {
            background-color: #6c757d;
            border: 1px solid #6c757d;
            color: white;
        }
        .btn-secondary:hover {
            background-color: #5a6268;
            transform: scale(1.05);
        }

        .btn-lg {
            font-size: 16px;
            padding: 12px 24px;
        }

        /* Loader Styles */
        .loader-container {
            display: none;
            align-items: center;
            justify-content: center;
            margin-left: 10px;
            font-size: 16px;
            color: #28a745;
        }

        .spinner {
            border: 8px solid #f3f3f3; /* Light gray */
            border-top: 8px solid #28a745; /* Green */
            border-radius: 50%;
            width: 24px;
            height: 24px;
            margin-right: 10px;
            animation: spin 2s linear infinite;
        }

        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <h4 style="font-weight: bold; font-size: 36px; color: #6c757d; margin-bottom: 30px;">Formulario de Recojo de Préstamo</h4>

    <div class="form-row" style="margin-bottom: 20px;">
        <label><strong>CÓDIGO:</strong></label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" />
    </div>

    <div class="form-row" style="margin-bottom: 20px;">
        <!-- Botón Buscar y Loader dentro del mismo contenedor -->
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-success btn-lg" OnClick="btnBuscar_Click" OnClientClick="showLoading();" />
        
        <!-- Contenedor para el loader junto al botón Buscar -->
        <div id="loaderContainer" class="loader-container">
            <div class="spinner"></div>
            <span>Buscando usuario...</span>
        </div>
    </div>

    <div class="form-row" style="margin-bottom: 20px;">
        <label><strong>NOMBRES:</strong></label>
        <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" />
    </div>

    <div class="form-row" style="margin-bottom: 20px;">
        <label><strong>FECHA SOLICITUD:</strong></label>
        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" />
    </div>

    <div class="form-row" style="margin-bottom: 20px;">
        <label><strong>EJEMPLAR(ES):</strong></label>
        <asp:TextBox ID="txtEjemplares" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>
    
    <div class="button-container">
        <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-success btn-lg" OnClick="btnRegistrar_Click" style="margin-right: 20px;" />
        <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary btn-lg" OnClick="btnRegresar_Click" />
    </div>
   <script type="text/javascript">
       function showLoading() {
           document.getElementById("loaderContainer").style.display = "flex";  
       }

       function hideLoading() {
           document.getElementById("loaderContainer").style.display = "none";
       }
   </script>
</asp:Content>
