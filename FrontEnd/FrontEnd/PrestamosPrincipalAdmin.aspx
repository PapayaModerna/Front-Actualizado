<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="PrestamosPrincipalAdmin.aspx.cs" Inherits="FrontEnd.PrestamosPrincipalAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/PrestamosAdmin.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="banner-negro">
        <div class="bienvenida-container">
            <h1 id="bienvenida"></h1>
        </div>
    </div>

    <!-- 🔁 SECCIÓN GENERAL PARA CADA CATEGORÍA -->
    
    <%-- PRÉSTAMOS TOTALES --%>
    <div class="tabla-libros-container">
        <h2 class="lbl-seccion">PRÉSTAMOS TOTALES</h2>
        <asp:UpdatePanel ID="updTotales" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarTotales" runat="server" CssClass="input-buscador" placeholder="Buscar préstamo..." />
                    <asp:LinkButton ID="btnBuscarTotales" runat="server" CssClass="btn-buscador" OnClick="btnBuscarTotales_Click">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>
                <asp:Panel ID="pnlTotales" runat="server" Visible="false">
                    <table class="tabla-libros">
                        <thead><tr><th>ID</th><th>Libro</th></tr></thead>
                        <tbody>
                            <asp:Repeater ID="rptTotales" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ID") %></td>
                                        <td><%# Eval("Libro") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%-- PRÉSTAMOS ATRASADOS --%>
    <div class="tabla-libros-container">
        <h2 class="lbl-seccion">PRÉSTAMOS ATRASADOS</h2>
        <asp:UpdatePanel ID="updAtrasados" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarAtrasados" runat="server" CssClass="input-buscador" placeholder="Buscar préstamo..." />
                    <asp:LinkButton ID="btnBuscarAtrasados" runat="server" CssClass="btn-buscador" OnClick="btnBuscarAtrasados_Click">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>
                <asp:Panel ID="pnlAtrasados" runat="server" Visible="false">
                    <table class="tabla-libros">
                        <thead><tr><th>ID</th><th>Libro</th></tr></thead>
                        <tbody>
                            <asp:Repeater ID="rptAtrasados" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ID") %></td>
                                        <td><%# Eval("Libro") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%-- PRÉSTAMOS SOLICITADOS --%>
    <div class="tabla-libros-container">
        <h2 class="lbl-seccion">PRÉSTAMOS SOLICITADOS</h2>
        <asp:UpdatePanel ID="updSolicitados" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarSolicitados" runat="server" CssClass="input-buscador" placeholder="Buscar préstamo..." />
                    <asp:LinkButton ID="btnBuscarSolicitados" runat="server" CssClass="btn-buscador" OnClick="btnBuscarSolicitados_Click">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>
                <asp:Panel ID="pnlSolicitados" runat="server" Visible="false">
                    <table class="tabla-libros">
                        <thead><tr><th>ID</th><th>Libro</th></tr></thead>
                        <tbody>
                            <asp:Repeater ID="rptSolicitados" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ID") %></td>
                                        <td><%# Eval("Libro") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%-- PRÉSTAMOS NO CULMINADOS --%>
    <div class="tabla-libros-container">
        <h2 class="lbl-seccion">PRÉSTAMOS NO CULMINADOS</h2>
        <asp:UpdatePanel ID="updNoCulminados" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarNoCulminados" runat="server" CssClass="input-buscador" placeholder="Buscar préstamo..." />
                    <asp:LinkButton ID="btnBuscarNoCulminados" runat="server" CssClass="btn-buscador" OnClick="btnBuscarNoCulminados_Click">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>
                <asp:Panel ID="pnlNoCulminados" runat="server" Visible="false">
                    <table class="tabla-libros">
                        <thead><tr><th>ID</th><th>Libro</th></tr></thead>
                        <tbody>
                            <asp:Repeater ID="rptNoCulminados" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ID") %></td>
                                        <td><%# Eval("Libro") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <%-- PRÉSTAMOS CULMINADOS --%>
    <div class="tabla-libros-container">
        <h2 class="lbl-seccion">PRÉSTAMOS CULMINADOS</h2>
        <asp:UpdatePanel ID="updCulminados" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarCulminados" runat="server" CssClass="input-buscador" placeholder="Buscar préstamo..." />
                    <asp:LinkButton ID="btnBuscarCulminados" runat="server" CssClass="btn-buscador" OnClick="btnBuscarCulminados_Click">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>
                <asp:Panel ID="pnlCulminados" runat="server" Visible="false">
                    <table class="tabla-libros">
                        <thead><tr><th>ID</th><th>Libro</th></tr></thead>
                        <tbody>
                            <asp:Repeater ID="rptCulminados" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("ID") %></td>
                                        <td><%# Eval("Libro") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            const mensaje = "HISTORIAL DE PRÉSTAMOS DEL SISTEMA";
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
    </script>

</asp:Content>
