<%@ Page Title="" Language="C#" MasterPageFile="~/UserBiblio.Master" AutoEventWireup="true" CodeBehind="EjemplaresMaterialUser.aspx.cs" Inherits="FrontEnd.EjemplaresMaterialUser"EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://fonts.googleapis.com/css2?family=Roboto:wght@400;500;700&display=swap" rel="stylesheet" />
     <link href="<%= ResolveUrl("~/Content/EjemplaresMaterialUser.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">

        <div class="title-container">
            <asp:Label ID="lblTituloObra" runat="server" class="material-title" />
        </div>

        <!-- Sección de Sede Sur -->
        <div class="sede-section mb-5">
            <div class="d-flex justify-content-between align-items-center mb-2">
                <h3 class="sede-title">Sede Sur</h3>
            </div>
            <div class="sede-box">
                <asp:Repeater ID="rptSedeSur" runat="server" OnItemDataBound="rptEjemplares_ItemDataBound">
                    <ItemTemplate>
                        <div class="ejemplar-item">
                            <div class="ejemplar-card">
                                <!-- Botón para pedir ejemplar -->
                                <asp:Button ID="btnPedirEjemplarSur" runat="server" CssClass="btn btn-primary" Text="Pedir" OnClick="btnPedirEjemplar_Click" CommandArgument='<%# Eval("idEjemplar") %>' />
                                <label>
                                    <p><strong>CODIGO DE EJEMPLAR:</strong> <asp:Label ID="lblCodigoEjemplar" runat="server" /></p>
                                    <p><strong>UBICACION EN SEDE:</strong> <asp:Label ID="lblUbicacionSede" runat="server" /></p>
                                    <p><strong>ID EJEMPLAR:</strong> <asp:Label ID="lblIdEjemplar" runat="server" Text='<%# Eval("idEjemplar") %>' /></p>
                                </label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lblNoEjemplaresSedeSur" runat="server" Text="Sin ejemplares disponibles" Visible="false" CssClass="no-ejemplares-msg" />
            </div>
        </div>

        <!-- Sección de Sede Norte -->
        <div class="sede-section mb-5">
            <div class="d-flex justify-content-between align-items-center mb-2">
                <h3 class="sede-title">Sede Norte</h3>
            </div>
            <div class="sede-box">
                <asp:Repeater ID="rptSedeNorte" runat="server" OnItemDataBound="rptEjemplares_ItemDataBound">
                    <ItemTemplate>
                        <div class="ejemplar-item">
                            <div class="ejemplar-card">
                                <!-- Botón para pedir ejemplar -->
                                <asp:Button ID="btnPedirEjemplarNorte" runat="server" CssClass="btn btn-primary" Text="Pedir" OnClick="btnPedirEjemplar_Click" CommandArgument='<%# Eval("idEjemplar") %>' />
                                <label>
                                    <p><strong>CODIGO DE EJEMPLAR:</strong> <asp:Label ID="lblCodigoEjemplar" runat="server" /></p>
                                    <p><strong>UBICACION EN SEDE:</strong> <asp:Label ID="lblUbicacionSede" runat="server" /></p>
                                    <p><strong>ID EJEMPLAR:</strong> <asp:Label ID="lblIdEjemplar" runat="server" Text='<%# Eval("idEjemplar") %>' /></p>
                                </label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lblNoEjemplaresSedeNorte" runat="server" Text="Sin ejemplares disponibles" Visible="false" CssClass="no-ejemplares-msg" />
            </div>
        </div>

        <!-- Sección de Sede Central -->
        <div class="sede-section mb-5">
            <div class="d-flex justify-content-between align-items-center mb-2">
                <h3 class="sede-title">Sede Central</h3>
            </div>
            <div class="sede-box">
                <asp:Repeater ID="rptSedeCentral" runat="server" OnItemDataBound="rptEjemplares_ItemDataBound">
                    <ItemTemplate>
                        <div class="ejemplar-item">
                            <div class="ejemplar-card">
                                <!-- Botón para pedir ejemplar -->
                                <asp:Button ID="btnPedirEjemplarCentral" runat="server" CssClass="btn btn-primary" Text="Pedir" OnClick="btnPedirEjemplar_Click" CommandArgument='<%# Eval("idEjemplar") %>' />
                                <label>
                                    <p><strong>CODIGO DE EJEMPLAR:</strong> <asp:Label ID="lblCodigoEjemplar" runat="server" /></p>
                                    <p><strong>UBICACION EN SEDE:</strong> <asp:Label ID="lblUbicacionSede" runat="server" /></p>
                                    <p><strong>ID EJEMPLAR:</strong> <asp:Label ID="lblIdEjemplar" runat="server" Text='<%# Eval("idEjemplar") %>' /></p>
                                </label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Label ID="lblNoEjemplaresSedeCentro" runat="server" Text="Sin ejemplares disponibles" Visible="false" CssClass="no-ejemplares-msg" />
            </div>
        </div>

        <!-- Botón de Solicitar Préstamo -->
        <div class="d-flex justify-content-end mt-4">
            <asp:Button ID="btnSolicitarPrestamo" runat="server" CssClass="btn btn-success btn-lg" Text="Solicitar Préstamo" OnClick="btnSolicitarPrestamo_Click" />
        </div>
    </div>
</asp:Content>
