<%@ Page Title="" Language="C#" MasterPageFile="~/AdminBiblio.Master" AutoEventWireup="true" CodeBehind="EjemplaresMaterialAdmin.aspx.cs" Inherits="FrontEnd.EjemplaresMaterialAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%= ResolveUrl("~/Content/DetalleLibros.css") %>" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container-fluid">
        <div class="row justify-content-center">
            <!-- Detalle del material y ejemplares -->
            <div class="col-md-8 mx-auto">
                <div class="detalle-libro-container">
                    <h4 class="mb-4">Ejemplares del Material</h4>

                    <div class="mb-2">
                        <strong>ID Material:</strong> <asp:Label ID="lblIdMaterial" runat="server" CssClass="ms-2" />
                    </div>
                    <div class="mb-2">
                        <strong>Título:</strong> <asp:Label ID="lblTitulo" runat="server" CssClass="ms-2" />
                    </div>
                    <div class="mb-4">
                        <strong>Editorial:</strong> <asp:Label ID="lblEditorial" runat="server" CssClass="ms-2" />
                    </div>

                    <h5 class="mb-3">Lista de Ejemplares</h5>
                    <asp:GridView ID="gvEjemplares" runat="server" CssClass="table table-striped" AutoGenerateColumns="false">
                        <Columns>
                            <asp:BoundField DataField="idEjemplar" HeaderText="ID Ejemplar" />
                            <asp:BoundField DataField="fechaAdquisicion" HeaderText="Fecha de Adquisición" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="Disponible" HeaderText="Disponible" />
                            <asp:BoundField DataField="ubicacion" HeaderText="Ubicación" />
                            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
                            <asp:BoundField DataField="Sede" HeaderText="Sede" />
                        </Columns>
                    </asp:GridView>
                    <asp:Label ID="lblSinEjemplares" runat="server" Text="No hay ejemplares para este material." Visible="false" CssClass="text-danger" />

                    <!-- Botón Volver -->
                    <div class="w-100 d-flex justify-content-center gap-2 mt-4">
                        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn-volver" OnClick="btnVolver_Click" />
                        <asp:Button ID="btnAgregarEjemplar" runat="server" Text="Agregar Ejemplar" CssClass="btn-volver" OnClick="btnAgregarEjemplar_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>