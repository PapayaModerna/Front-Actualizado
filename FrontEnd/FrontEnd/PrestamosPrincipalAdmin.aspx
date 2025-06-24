<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="PrestamosPrincipalAdmin.aspx.cs" Inherits="FrontEnd.PrestamosPrincipalAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/PrestamosAdmin.css") %>" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .botones-container {
            display: flex;
            justify-content: space-between;
            margin-bottom: 20px;
            margin-top: 40px;
        }

        .btn-recojo {
            background-color: #388E3C;  /* Verde */
            color: white;
            padding: 15px 30px;
            font-size: 18px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            width: 48%; 
            text-align: center;
        }

        .btn-recojo:hover {
            background-color: #2c6f2f; 
        }

        .btn-devolucion {
            background-color: #D32F2F; 
            color: white;
            padding: 15px 30px;
            font-size: 18px;
            border: none;
            border-radius: 8px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            width: 48%; 
            text-align: center;
        }

        .btn-devolucion:hover {
            background-color: #c12d2d; 
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">

    <div class="banner-negro">
        <div class="bienvenida-container">
            <h1 id="bienvenida"></h1>
        </div>
    </div>
    <div class="botones-container">
        <asp:Button ID="btnRecojoPrestamo" runat="server" Text="Recojo Préstamo" CssClass="btn-recojo" OnClientClick="window.location.href='RecojoPrestamo.aspx'; return false;" />
        <asp:Button ID="btnDevolucionPrestamo" runat="server" Text="Devolución Préstamo" CssClass="btn-devolucion" OnClientClick="window.location.href='DevolucionPrestamo.aspx'; return false;" />
    </div>
    <!--  SOLO PRÉSTAMOS TOTALES -->
    <div class="tabla-libros-container" style="position: relative;">
        <h2 class="lbl-seccion">PRÉSTAMOS TOTALES</h2>
        <asp:UpdatePanel ID="updTotales" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarTotales" runat="server" CssClass="input-buscador"
                        placeholder="Buscar préstamo..." AutoPostBack="true"
                        OnTextChanged="txtBuscarTotales_TextChanged" />
                    <asp:LinkButton ID="btnBuscarTotales" runat="server" CssClass="btn-buscador"
                        OnClick="btnBuscarTotales_Click" CausesValidation="false" UseSubmitBehavior="false">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>

                <div class="tabla-libros-container" style="position: relative;">
                    <div id="loaderTablaTotales" class="loader-overlay" style="display: none;">
                        <div class="spinner"></div>
                    </div>
                    <asp:Label ID="lblSinResultadosTotales" runat="server" CssClass="lbl-sin-resultados" Visible="false"
                        Text="No hay resultados para esta búsqueda." />
                    <table class="tabla-libros">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Fecha Solicitud</th>
                                <th>Fecha Préstamo</th>
                                <th>Fecha Devolución</th>
                                <th>Estado</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptTotales" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idPrestamo", "{0:000}") %></td>
                                        <td><%# Eval("fechaSolicitud") %></td>
                                        <td><%# Eval("fechaPrestamo") %></td>
                                        <td><%# Eval("fechaDevolucion") %></td>
                                        <td><%# Eval("Estado") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div class="paginacion" style="text-align: center; margin-top: 20px;">
                    <asp:Repeater ID="rptPaginacionTotales" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPaginaTotales" runat="server"
                                Text='<%# Eval("NumeroPagina") %>'
                                CommandArgument='<%# Eval("NumeroPagina") %>'
                                OnClick="lnkPaginaTotales_Click"
                                CssClass='<%# (int)Eval("NumeroPagina") == (int)ViewState["PaginaActualTotales"] ? "btn-pagina activa" : "btn-pagina" %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscarTotales" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="txtBuscarTotales" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <!--  atrasados -->
    <div class="tabla-libros-container" style="position: relative; margin-top: 60px;">
        <h2 class="lbl-seccion">PRÉSTAMOS ATRASADOS</h2>
        <asp:UpdatePanel ID="updAtrasados" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarAtrasados" runat="server" CssClass="input-buscador"
                        placeholder="Buscar préstamo..." AutoPostBack="true"
                        OnTextChanged="txtBuscarAtrasados_TextChanged" />
                    <asp:LinkButton ID="btnBuscarAtrasados" runat="server" CssClass="btn-buscador"
                        OnClick="btnBuscarAtrasados_Click" CausesValidation="false" UseSubmitBehavior="false">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>

                <div class="tabla-libros-container" style="position: relative;">
                    <div id="loaderTablaAtrasados" class="loader-overlay" style="display: none;">
                        <div class="spinner"></div>
                    </div>
                    <asp:Label ID="lblSinResultadosAtrasados" runat="server" CssClass="lbl-sin-resultados" Visible="false"
                        Text="No hay resultados para esta búsqueda." />
                    <table class="tabla-libros">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Fecha Solicitud</th>
                                <th>Fecha Préstamo</th>
                                <th>Fecha Devolución</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptAtrasados" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idPrestamo", "{0:000}") %></td>
                                        <td><%# Eval("fechaSolicitud") %></td>
                                        <td><%# Eval("fechaPrestamo") %></td>
                                        <td><%# Eval("fechaDevolucion") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div class="paginacion" style="text-align: center; margin-top: 20px;">
                    <asp:Repeater ID="rptPaginacionAtrasados" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPaginaAtrasados" runat="server"
                                Text='<%# Eval("NumeroPagina") %>'
                                CommandArgument='<%# Eval("NumeroPagina") %>'
                                OnClick="lnkPaginaAtrasados_Click"
                                CssClass='<%# (int)Eval("NumeroPagina") == (int)ViewState["PaginaActualAtrasados"] ? "btn-pagina activa" : "btn-pagina" %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscarAtrasados" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="txtBuscarAtrasados" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
    <!--  solicitados -->
    <div class="tabla-libros-container" style="position: relative; margin-top: 60px;">
        <h2 class="lbl-seccion">PRÉSTAMOS SOLICITADOS</h2>
        <asp:UpdatePanel ID="updSolicitados" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarSolicitados" runat="server" CssClass="input-buscador"
                        placeholder="Buscar préstamo..." AutoPostBack="true"
                        OnTextChanged="txtBuscarSolicitados_TextChanged" />
                    <asp:LinkButton ID="btnBuscarSolicitados" runat="server" CssClass="btn-buscador"
                        OnClick="btnBuscarSolicitados_Click" CausesValidation="false" UseSubmitBehavior="false">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>

                <div class="tabla-libros-container" style="position: relative;">
                    <div id="loaderTablaSolicitados" class="loader-overlay" style="display: none;">
                        <div class="spinner"></div>
                    </div>
                    <asp:Label ID="lblSinResultadosSolicitados" runat="server" CssClass="lbl-sin-resultados" Visible="false"
                        Text="No hay resultados para esta búsqueda." />
                    <table class="tabla-libros">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Fecha Solicitud</th>
                                <th>Fecha Préstamo</th>
                                <th>Fecha Devolución</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptSolicitados" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idPrestamo", "{0:000}") %></td>
                                        <td><%# Eval("fechaSolicitud") %></td>
                                        <td><%# Eval("fechaPrestamo") %></td>
                                        <td><%# Eval("fechaDevolucion") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div class="paginacion" style="text-align: center; margin-top: 20px;">
                    <asp:Repeater ID="rptPaginacionSolicitados" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPaginaSolicitados" runat="server"
                                Text='<%# Eval("NumeroPagina") %>'
                                CommandArgument='<%# Eval("NumeroPagina") %>'
                                OnClick="lnkPaginaSolicitados_Click"
                                CssClass='<%# (int)Eval("NumeroPagina") == (int)ViewState["PaginaActualSolicitados"] ? "btn-pagina activa" : "btn-pagina" %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscarSolicitados" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="txtBuscarSolicitados" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <!-- NO CULMINADOS -->
    <div class="tabla-libros-container" style="position: relative; margin-top: 60px;">
        <h2 class="lbl-seccion">PRÉSTAMOS NO CULMINADOS</h2>
        <asp:UpdatePanel ID="updNoCulminados" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarNoCulminados" runat="server" CssClass="input-buscador"
                        placeholder="Buscar préstamo..." AutoPostBack="true"
                        OnTextChanged="txtBuscarNoCulminados_TextChanged" />
                    <asp:LinkButton ID="btnBuscarNoCulminados" runat="server" CssClass="btn-buscador"
                        OnClick="btnBuscarNoCulminados_Click" CausesValidation="false" UseSubmitBehavior="false">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>

                <div class="tabla-libros-container" style="position: relative;">
                    <div id="loaderTablaNoCulminados" class="loader-overlay" style="display: none;">
                        <div class="spinner"></div>
                    </div>
                    <asp:Label ID="lblSinResultadosNoCulminados" runat="server" CssClass="lbl-sin-resultados" Visible="false"
                        Text="No hay resultados para esta búsqueda." />
                    <table class="tabla-libros">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Fecha Solicitud</th>
                                <th>Fecha Préstamo</th>
                                <th>Fecha Devolución</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptNoCulminados" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idPrestamo", "{0:000}") %></td>
                                        <td><%# Eval("fechaSolicitud") %></td>
                                        <td><%# Eval("fechaPrestamo") %></td>
                                        <td><%# Eval("fechaDevolucion") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div class="paginacion" style="text-align: center; margin-top: 20px;">
                    <asp:Repeater ID="rptPaginacionNoCulminados" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPaginaNoCulminados" runat="server"
                                Text='<%# Eval("NumeroPagina") %>'
                                CommandArgument='<%# Eval("NumeroPagina") %>'
                                OnClick="lnkPaginaNoCulminados_Click"
                                CssClass='<%# (int)Eval("NumeroPagina") == (int)ViewState["PaginaActualNoCulminados"] ? "btn-pagina activa" : "btn-pagina" %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscarNoCulminados" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="txtBuscarNoCulminados" EventName="TextChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <!--  culminados -->
    <div class="tabla-libros-container" style="position: relative; margin-top: 60px;">
        <h2 class="lbl-seccion">PRÉSTAMOS ENTREGADOS</h2>
        <asp:UpdatePanel ID="updCulminados" runat="server">
            <ContentTemplate>
                <div class="buscador-container">
                    <asp:TextBox ID="txtBuscarCulminados" runat="server" CssClass="input-buscador"
                        placeholder="Buscar préstamo..." AutoPostBack="true"
                        OnTextChanged="txtBuscarCulminados_TextChanged" />
                    <asp:LinkButton ID="btnBuscarCulminados" runat="server" CssClass="btn-buscador"
                        OnClick="btnBuscarCulminados_Click" CausesValidation="false" UseSubmitBehavior="false">
                        <i class="fas fa-search"></i>
                    </asp:LinkButton>
                </div>

                <div class="tabla-libros-container" style="position: relative;">
                    <div id="loaderTablaCulminados" class="loader-overlay" style="display: none;">
                        <div class="spinner"></div>
                    </div>
                    <asp:Label ID="lblSinResultadosCulminados" runat="server" CssClass="lbl-sin-resultados" Visible="false"
                        Text="No hay resultados para esta búsqueda." />
                    <table class="tabla-libros">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Fecha Solicitud</th>
                                <th>Fecha Préstamo</th>
                                <th>Fecha Devolución</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rptCulminados" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idPrestamo", "{0:000}") %></td>
                                        <td><%# Eval("fechaSolicitud") %></td>
                                        <td><%# Eval("fechaPrestamo") %></td>
                                        <td><%# Eval("fechaDevolucion") %></td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>

                <div class="paginacion" style="text-align: center; margin-top: 20px;">
                    <asp:Repeater ID="rptPaginacionCulminados" runat="server">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkPaginaCulminados" runat="server"
                                Text='<%# Eval("NumeroPagina") %>'
                                CommandArgument='<%# Eval("NumeroPagina") %>'
                                OnClick="lnkPaginaCulminados_Click"
                                CssClass='<%# (int)Eval("NumeroPagina") == (int)ViewState["PaginaActualCulminados"] ? "btn-pagina activa" : "btn-pagina" %>'>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnBuscarCulminados" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="txtBuscarCulminados" EventName="TextChanged" />
            </Triggers>
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

        Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(function (sender, args) {
            const el = args.get_postBackElement();
            if (el) {
                // Loader para Totales
                if (el.id.endsWith("btnBuscarTotales") || el.id.endsWith("txtBuscarTotales") || el.id.endsWith("lnkPaginaTotales")) {
                    const loaderTotales = document.getElementById("loaderTablaTotales");
                    if (loaderTotales) loaderTotales.style.display = "flex";
                }

                // Loader para Atrasados
                if (el.id.endsWith("btnBuscarAtrasados") || el.id.endsWith("txtBuscarAtrasados") || el.id.endsWith("lnkPaginaAtrasados")) {
                    const loaderAtrasados = document.getElementById("loaderTablaAtrasados");
                    if (loaderAtrasados) loaderAtrasados.style.display = "flex";
                }
                // Loader para Solicitados
                if (el.id.endsWith("btnBuscarSolicitados") || el.id.endsWith("txtBuscarSolicitados") || el.id.endsWith("lnkPaginaSolicitados")) {
                    const loaderSolicitados = document.getElementById("loaderTablaSolicitados");
                    if (loaderSolicitados) loaderSolicitados.style.display = "flex";
                }
                if (el.id.endsWith("btnBuscarNoCulminados") || el.id.endsWith("txtBuscarNoCulminados") || el.id.endsWith("lnkPaginaNoCulminados")) {
                    const loaderNoCulminados = document.getElementById("loaderTablaNoCulminados");
                    if (loaderNoCulminados) loaderNoCulminados.style.display = "flex";
                }
                if (el.id.endsWith("btnBuscarCulminados") || el.id.endsWith("txtBuscarCulminados") || el.id.endsWith("lnkPaginaCulminados")) {
                    const loaderCulminados = document.getElementById("loaderTablaCulminados");
                    if (loaderCulminados) loaderCulminados.style.display = "flex";
                }
            }
        });

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            const loader = document.getElementById("loaderTablaTotales");
            if (loader) loader.style.display = "none";
            const loaderAtrasados = document.getElementById("loaderTablaAtrasados");
            if (loaderAtrasados) loaderAtrasados.style.display = "none";
            const loaderSolicitados = document.getElementById("loaderTablaSolicitados");
            if (loaderSolicitados) loaderSolicitados.style.display = "none";
            const loaderNoCulminados = document.getElementById("loaderTablaNoCulminados");
            if (loaderNoCulminados) loaderNoCulminados.style.display = "none";
            const loaderCulminados = document.getElementById("loaderTablaCulminados");
            if (loaderCulminados) loaderCulminados.style.display = "none";
        });
    </script>

</asp:Content>
