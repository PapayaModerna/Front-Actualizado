<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Loader.aspx.cs" Inherits="FrontEnd.Loader" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8" />
    <title>Cargando...</title>
    <style>
        body {
            margin: 0;
            background-color: #2c2c2c;
            font-family: 'Segoe UI', sans-serif;
            height: 100vh;
            display: flex;
            justify-content: center;
            align-items: center;
            animation: fadeIn 1s ease-in-out;
        }
        .contenedor-loader {
            text-align: center;
            opacity: 0;
            animation: aparecer 1.5s ease-in-out forwards;
        }

        .spinner {
            border: 6px solid #555;
            border-top: 6px solid #fff;
            border-radius: 50%;
            width: 60px;
            height: 60px;
            margin: 0 auto 20px;
            animation: spin 1s linear infinite;
        }

        @keyframes spin {
            0% { transform: rotate(0deg); }
            100% { transform: rotate(360deg); }
        }
        @keyframes fadeIn {
            from { opacity: 0; }
            to { opacity: 1; }
        }

        @keyframes aparecer {
            to { opacity: 1; }
        }

        @keyframes fadeText {
            from { opacity: 0; transform: translateY(10px); }
            to { opacity: 1; transform: translateY(0); }
        }

        .mensaje {
            font-size: 1.2rem;
            color: #fff;
            opacity: 0;
            animation: fadeText 1.5s ease-in-out forwards;
            animation-delay: 0.8s;
        }
    </style>
    <script type="text/javascript">
        setTimeout(function () {
            const destino = document.getElementById("hfRedireccion").value;
            window.location.href = destino;
        }, 2000); // Redirige después de 2 segundos
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="spinner"></div>
        <div class="mensaje">Cargando tu biblioteca virtual...</div>
        <asp:HiddenField ID="hfRedireccion" runat="server" />
    </form>
</body>
</html>
