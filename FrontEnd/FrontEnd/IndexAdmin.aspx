    <%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="IndexAdmin.aspx.cs" Inherits="FrontEnd.IndexAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/IndexAdmin.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="banner-negro">
        <div class="bienvenida-container">
            <h1 id="bienvenida"></h1>
        </div>
    </div>

    <div class="seccion-admin">
        <div class="admin-left">
            <asp:Label ID="lblTituloSede" runat="server" Text="Sede General" style="display:block; font-size:2rem; font-weight:900; color:white; margin-bottom:10px; line-height:1.2;"/>
            <p class="lbl-seccion"> </p>
            <p class="lbl-seccion">Libros disponibles</p>
            <p class="lbl-seccion">Ejemplares de libros en el sistema</p>
        </div>
        <div class="admin-center">
            <asp:DropDownList ID="ddlSedes" runat="server" CssClass="ddl-sedes" AutoPostBack="true" OnSelectedIndexChanged="ddlSedes_SelectedIndexChanged"/>
            <asp:Label ID="lblCantidadLibros" runat="server" CssClass="lbl-dato-libro" />
            <asp:Label ID="lblCantidadEjemplares" runat="server" CssClass="lbl-dato-libro" />
        </div>
        <div class="admin-logo">
            <img src="images/myholylogo.png" alt="Logo Biblioteca">
        </div>
    </div>   

    <asp:UpdatePanel ID="UpdatePanelLibros" runat="server">
        <ContentTemplate>
            <div class="buscador-container">
                <asp:TextBox ID="txtBuscar" runat="server" CssClass="input-buscador"
                    placeholder="Buscar libros disponibles..." AutoPostBack="true"
                    OnTextChanged="txtBuscar_TextChanged" />
                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="btn-buscador"
                    OnClick="btnBuscar_Click" CausesValidation="false" UseSubmitBehavior="false">
                    <i class="fas fa-search"></i>
                </asp:LinkButton>
            </div>
            <div class="tabla-libros-container" style="position: relative;">
                <div id="loaderTabla" class="loader-overlay" style="display: none;">
                    <div class="spinner"></div>
                </div>
                <asp:Label ID="lblSinResultados" runat="server" CssClass="lbl-sin-resultados" Visible="false" Text="No hay resultados para esta búsqueda."></asp:Label>
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
            <div class="paginacion" style="text-align: center; margin-top: 20px;">
                <asp:Repeater ID="rptPaginacion" runat="server">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkPagina" runat="server" Text='<%# Eval("NumeroPagina") %>' 
                            CommandArgument='<%# Eval("NumeroPagina") %>' 
                            OnClick="lnkPagina_Click"
                            CssClass='<%# (int)Eval("NumeroPagina") == (int)ViewState["PaginaActual"] ? "btn-pagina activa" : "btn-pagina" %>'>
                        </asp:LinkButton>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="txtBuscar" EventName="TextChanged" />
        </Triggers>
    </asp:UpdatePanel>

    <script type="text/javascript">
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
            window.location.href = 'DetalleLibrosAdmin.aspx?id=' + id;
        }

        // Loader control via ScriptManager
        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(function () {
            document.getElementById('loaderTabla').style.display = 'flex';
        });

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            document.getElementById('loaderTabla').style.display = 'none';
        });
    </script>
</asp:Content>
