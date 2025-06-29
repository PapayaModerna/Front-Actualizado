<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="SancionarUser.aspx.cs" Inherits="FrontEnd.SancionarUser" %>
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

        .form-row {
            margin-bottom: 20px;
        }

        /* Styles for the Loader */
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
    <h4 style="font-weight: bold; font-size: 36px; color: #6c757d; margin-bottom: 30px;">Formulario de Sanción de Usuario</h4>

    <div class="form-row">
        <label><strong>CÓDIGO DE USUARIO:</strong></label>
        <asp:Label ID="lblCodigoUsuario" runat="server" CssClass="form-control" />
    </div>

    <div class="form-row">
        <label><strong>NOMBRE DEL USUARIO:</strong></label>
        <asp:Label ID="lblNombreUsuario" runat="server" CssClass="form-control" />
    </div>

    <div class="form-row">
        <label><strong>TIPO DE SANCIÓN:</strong></label>
        <asp:DropDownList ID="ddlTipoSancion" runat="server" CssClass="form-control">
        </asp:DropDownList>
    </div>

    <div class="form-row">
        <label><strong>FECHA DE HOY:</strong></label>
        <asp:TextBox ID="txtFechaHoy" runat="server" CssClass="form-control" Text='<%# DateTime.Now.ToShortDateString() %>' ReadOnly="true" />
    </div>

    <div class="form-row">
        <label><strong>MONTO DE SANCIÓN:</strong></label>
        <asp:TextBox ID="txtMontoSancion" runat="server" CssClass="form-control" />
    </div>

    <div class="form-row">
        <label><strong>DURACIÓN DE LA SANCIÓN:</strong></label>
        <asp:Calendar ID="calendarDuracionSancion" runat="server" CssClass="form-control" 
                      SelectionMode="Day" 
                      OnSelectionChanged="calendarDuracionSancion_SelectionChanged" />
    </div>

    <div class="form-row">
        <label><strong>DESCRIPCIÓN:</strong></label>
        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
    </div>

    <div class="form-row">
        <label><strong>CÓDIGO DE PRÉSTAMO:</strong></label>
        <asp:TextBox ID="txtCodigoPrestamo" runat="server" CssClass="form-control" />
    </div>

    <div class="button-container">
        <asp:Button ID="btnRegistrarSancion" runat="server" Text="Registrar Sanción" CssClass="btn btn-success btn-lg" OnClick="btnRegistrarSancion_Click" />
    </div>

    <div id="loaderContainer" class="loader-container">
        <div class="spinner"></div>
        <span>Registrando sanción...</span>
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

