<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="UsuariosAdmin.aspx.cs" Inherits="FrontEnd.UsuariosAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/PrestamosAdmin.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="banner-negro">
        <div class="bienvenida-container">
            <h1 id="bienvenida"></h1>
        </div>
    </div>

    <div class="tabla-libros-container" style="position: relative;">
        <h2 class="lbl-seccion">USUARIOS DEL SISTEMA</h2>
        <asp:UpdatePanel ID="updUsuarios" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarUsuarios" runat="server" CssClass="input-buscador"
                        placeholder="Buscar usuario..." AutoPostBack="true"
                        OnTextChanged="txtBuscarUsuarios_TextChanged" />
                    <asp:LinkButton ID="btnBuscarUsuarios" runat="server" CssClass="btn-buscador"
                        OnClick="btnBuscarUsuarios_Click" CausesValidation="false" UseSubmitBehavior="false">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>

                <div class="tabla-libros-container" style="position: relative;">
                    <div id="loaderTablaUsuarios" class="loader-overlay" style="display: none;">
                        <div class="spinner"></div>
                    </div>
                    <asp:Label ID="lblSinResultadosUsuarios" runat="server" CssClass="lbl-sin-resultados" Visible="false"
                        Text="No hay resultados para esta búsqueda." />
                    <table class="tabla-libros">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Código</th>
                                <th>Nombre</th>
                                <th>Paterno</th>
                                <th>Materno</th>
                                <th>Tipo</th>
                                <th>Acciones</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptUsuarios" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idPersona") %></td>
                                        <td><%# Eval("codigo") %></td>
                                        <td><%# Eval("nombre") %></td>
                                        <td><%# Eval("paterno") %></td>
                                        <td><%# Eval("materno") %></td>
                                        <td><%# Eval("tipo") %></td>
                                        <td>
                                            <a href='ModificarUsuarioAdmin.aspx?id=<%# Eval("idPersona") %>' class="btn btn-primary btn-sm">
                                                <i class="fas fa-edit"></i> Editar
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div class="paginacion" style="text-align: center; margin-top: 20px;">
                    <asp:Repeater ID="rptPaginacionUsuarios" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPaginaUsuarios" runat="server"
                                Text='<%# Eval("NumeroPagina") %>'
                                CommandArgument='<%# Eval("NumeroPagina") %>'
                                OnClick="lnkPaginaUsuarios_Click"
                                CssClass='<%# (int)Eval("NumeroPagina") == (int)ViewState["PaginaActualUsuarios"] ? "btn-pagina activa" : "btn-pagina" %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscarUsuarios" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="txtBuscarUsuarios" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const mensaje = "LISTADO DE USUARIOS DEL SISTEMA";
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

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(function (sender, args) {
            const el = args.get_postBackElement();
            if (el) {
                if (el.id.endsWith("btnBuscarUsuarios") || el.id.endsWith("txtBuscarUsuarios") || el.id.endsWith("lnkPaginaUsuarios")) {
                    const loaderUsuarios = document.getElementById("loaderTablaUsuarios");
                    if (loaderUsuarios) loaderUsuarios.style.display = "flex";
                }
            }
        });

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            const loaderUsuarios = document.getElementById("loaderTablaUsuarios");
            if (loaderUsuarios) loaderUsuarios.style.display = "none";
        });
    </script>

</asp:Content>