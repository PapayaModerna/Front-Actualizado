<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginBiblio.aspx.cs" Inherits="FrontEnd.LoginBiblio" %>

<!DOCTYPE html>

<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>MyHolyLib - Login</title>
    <!-- Bootstrap 5 -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Boxicons -->
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="Content/login.css" rel="stylesheet">
    <!-- JQuery -->
    <script src="https://code.jquery.com/jquery-3.7.1.min.js"></script>

</head>
<body>
<form id="form1" runat="server">
        <div class="container-fluid vh-100 d-flex p-0" style="font-family: 'Roboto Mono', monospace;">
            <!-- Panel Izquierdo -->
            <div class="d-none d-md-flex flex-column justify-content-center align-items-center text-white col-md-6 position-relative"
                style="background-color: #000; border-top-right-radius: 100px; border-bottom-right-radius: 100px;">
                <h2 class="fw-bold fs-1">MyHolyLib</h2>
                <h1 class="fs-3 mb-3">Bienvenido</h1>
                <img src="Images/Logo.png" alt="Logo" class="position-absolute bottom-0 start-0 m-4" style="width: 7em; height: auto;">
            </div>
            
           <!-- Panel Derecho -->
           <div class="col-12 col-md-6 d-flex justify-content-center align-items-center p-4">
            
               <!-- Formulario de Inicio de Sesión -->
                <asp:Panel ID="pnlLogin" runat="server" CssClass="form-box login-panel" style="width: 100%; max-width: 500px;">
                    <h1 class="fw-bold text-center mb-4">Inicio de Sesión</h1>
                    <div class="mb-3 position-relative">
                      <asp:TextBox ID="txtLoginCodigo" runat="server" CssClass="form-control pe-5" Placeholder="Correo"
                        TextMode="Email" ClientIDMode="Static"  />
                      <i class="bx bxs-envelope position-absolute end-0 top-50 translate-middle-y me-3"></i>
                    </div>
                    <div class="mb-3 position-relative">
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"  />
                        <i class="bx bxs-lock-alt position-absolute end-0 top-50 translate-middle-y me-3 toggle-password" style="cursor: pointer;"></i>
                    </div>
                    <div class="mb-3 d-flex align-items-center justify-content-center gap-2">
                      <span class="m-0">¿Olvidaste la contraseña?</span>
                      <a href="#" id="reset-password-btn" class="text-decoration-none text-dark fw-semibold">Reestablecer</a>
                    </div>
                    <asp:Button ID="btnLogin" runat="server" Text="Iniciar Sesión" CssClass="btn btn-dark w-100" OnClick="btnLogin_Click" />
                    <asp:Label ID="lblMensaje" runat="server" CssClass="alert alert-danger mt-3 d-none" Visible="false"></asp:Label>

                </asp:Panel>

                <!-- Formulario para Reestablecer la contraseña -->
                <asp:Panel ID="pnlReset" runat="server" CssClass="form-box reset-panel w-100 d-none mt-5" style="max-width: 500px;">
                    <h1 class="fw-bold text-center mb-4">Reestablecer Contraseña</h1>
                    <div class="mb-3 position-relative">
                        <asp:TextBox ID="txtIdPersona" runat="server" CssClass="form-control pe-5" Placeholder="ID Persona" />
                    </div>
                    <div class="mb-3 position-relative">
                        <asp:TextBox ID="txtNuevaContrasena" runat="server" CssClass="form-control pe-5" TextMode="Password" Placeholder="Nueva Contraseña" />
                        <i class="bx bxs-lock-alt position-absolute end-0 top-50 translate-middle-y me-3 toggle-password" style="cursor: pointer;"></i>
                    </div>
                    <asp:Label ID="lblConfirmacion" runat="server" CssClass="alert alert-success d-none mt-2" Visible="false" />
                    <asp:Button ID="btnReset" runat="server" Text="Reestablecer Contrasenha" CssClass="btn btn-dark w-100 mb-3" OnClick="btnReset_Click" />
                    <button type="button" class="btn btn-outline-secondary w-100 back-to-login">Volver</button>
                </asp:Panel>
            </div>
        </div>

        <asp:HiddenField ID="hfMostrarLoader" runat="server" Value="false" />

    <div id="loginLoader" class="d-none position-fixed top-0 start-0 w-100 h-100 bg-white bg-opacity-75 d-flex justify-content-center align-items-center" style="z-index: 1050;">
      <div class="spinner-border text-dark" role="status">
        <span class="visually-hidden">Cargando...</span>
      </div>
    </div>
    </form>
    <!-- Scripts -->
    <script src='<%= ResolveUrl("~/Scripts/login.js") %>'></script>

</body>
</html>
