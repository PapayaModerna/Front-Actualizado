<%@ Page Title="Mi Perfil" Language="C#" MasterPageFile="~/UserPerfilVista.Master" AutoEventWireup="true" 
    CodeBehind="PerfilUser.aspx.cs" Inherits="FrontEnd.PerfilUser" %>

<asp:Content ID="ContentProfile" ContentPlaceHolderID="PerfilContent" runat="server">
    <div class="card shadow-sm">
        <div class="card-header bg-primary text-white">
            <h4 class="mb-0"><i class='bx bx-id-card'></i> Información del Perfil</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <!-- Columna izquierda -->
                <div class="col-md-6">
                    <div class="mb-4">
                        <h5 class="border-bottom pb-2"><i class='bx bx-user'></i> Datos Personales</h5>
                        <dl class="row mt-3">
                            <dt class="col-sm-5">Código:</dt>
                            <dd class="col-sm-7"><asp:Label ID="lblCodigo" runat="server" CssClass="fw-normal" /></dd>
                            
                            <dt class="col-sm-5">Nombre completo:</dt>
                            <dd class="col-sm-7">
                                <asp:Label ID="lblNombre" runat="server" CssClass="fw-normal" /> 
                                <asp:Label ID="lblPaterno" runat="server" CssClass="fw-normal" /> 
                                <asp:Label ID="lblMaterno" runat="server" CssClass="fw-normal" />
                            </dd>
                            
                            <dt class="col-sm-5">Contacto:</dt>
                            <dd class="col-sm-7">
                                <div><asp:Label ID="lblTelefono" runat="server" CssClass="fw-normal" /></div>
                                <div><asp:Label ID="lblCorreo" runat="server" CssClass="fw-normal" /></div>
                            </dd>
                            
                            <dt class="col-sm-5">Dirección:</dt>
                            <dd class="col-sm-7"><asp:Label ID="lblDireccion" runat="server" CssClass="fw-normal" /></dd>
                        </dl>
                    </div>
                </div>
                
                <!-- Columna derecha -->
                <div class="col-md-6">
                    <div class="mb-4">
                        <h5 class="border-bottom pb-2"><i class='bx bx-book'></i> Datos Académicos</h5>
                        <dl class="row mt-3">
                            <dt class="col-sm-5">Tipo de usuario:</dt>
                            <dd class="col-sm-7"><asp:Label ID="lblTipo" runat="server" CssClass="fw-normal" /></dd>
                            
                            <dt class="col-sm-5">Turno:</dt>
                            <dd class="col-sm-7"><asp:Label ID="lblTurno" runat="server" CssClass="fw-normal" /></dd>
                            
                            <dt class="col-sm-5">Nivel/Sede:</dt>
                            <dd class="col-sm-7">
                                <asp:Label ID="lblIdNivel" runat="server" CssClass="fw-normal" /> /
                                <asp:Label ID="lblIdSede" runat="server" CssClass="fw-normal" />
                            </dd>
                            
                            <dt class="col-sm-5">Periodo:</dt>
                            <dd class="col-sm-7">
                                <asp:Label ID="lblFechaInicio" runat="server" CssClass="fw-normal" /> al
                                <asp:Label ID="lblFechaFinal" runat="server" CssClass="fw-normal" />
                            </dd>
                        </dl>
                    </div>
                    
                    <div class="mb-4">
                        <h5 class="border-bottom pb-2"><i class='bx bx-info-circle'></i> Estado Actual</h5>
                        <dl class="row mt-3">
                            <dt class="col-sm-5">Situación:</dt>
                            <dd class="col-sm-7">
                                <span class="badge bg-<%= lblVigente.Text == "Sí" ? "success" : "danger" %>">
                                    <asp:Label ID="lblVigente" runat="server" />
                                </span>
                            </dd>
                            
                            <dt class="col-sm-5">Deuda pendiente:</dt>
                            <dd class="col-sm-7">
                                <span class="badge bg-<%= lblDeuda.Text == "0" ? "success" : "warning" %>">
                                    <asp:Label ID="lblDeuda" runat="server" />
                                </span>
                            </dd>
                            
                            <dt class="col-sm-5">Sanción hasta:</dt>
                            <dd class="col-sm-7">
                                <asp:Label ID="lblSancion" runat="server" CssClass="fw-normal" />
                            </dd>
                        </dl>
                    </div>
                </div>
            </div>
            
            <!-- Botones de acción -->
            <div class="d-flex justify-content-end mt-4 gap-2">
                <asp:Button ID="btnEditar" runat="server" Text="Editar Perfil" 
                    CssClass="btn btn-outline-primary px-4" OnClick="btnEditar_Click" />
                <asp:Button ID="btnCambiarPassword" runat="server" Text="Cambiar Contraseña" 
                    CssClass="btn btn-outline-secondary px-4" OnClick="btnCambiarPassword_Click" />
            </div>
        </div>
    </div>
</asp:Content>