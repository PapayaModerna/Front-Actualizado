<%@ Page Title="" Language="C#" MasterPageFile="~/UserBiblio.Master" AutoEventWireup="true" CodeBehind="RecursosUser.aspx.cs" Inherits="FrontEnd.RecursosUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .card-img-top-custom {
            height: 300px;
            object-fit: cover;
            width: 100%;
        }
        .card-availability {
            position: absolute;
            top: 0;
            left: 0;
            width: 100%;
            background-color: rgba(0, 0, 0, 0.6);
            color: white;
            padding: 8px;
            text-align: center;
            font-weight: bold;
        }
        .card-body-custom {
            padding: 1rem;
        }
        .card-title-custom {
            font-size: 1.1rem;
            font-weight: bold;
        }
        .card-author {
            font-size: 0.9rem;
            color: #6c757d;
        }
        .card-footer-custom {
            background-color: transparent;
            border-top: none;
            padding: 0 1rem 1rem 1rem;
            display: flex;
            justify-content: space-between;
            align-items: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h1 class="mb-4">Resources Catalog</h1>
        <asp:Repeater ID="rptMateriales" runat="server" OnItemDataBound="rptMateriales_ItemDataBound">
            <HeaderTemplate>
                <div class="row row-cols-1 row-cols-md-2 row-cols-lg-3 g-4">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100 position-relative">
                        <asp:Panel ID="pnlAvailability" runat="server" CssClass="card-availability">
                             <asp:Label ID="lblAvailability" runat="server"></asp:Label>
                        </asp:Panel>
                        <asp:Image ID="imgPortada" runat="server" CssClass="card-img-top-custom" />
                        <div class="card-body card-body-custom">
                            <h5 class="card-title card-title-custom"><%# Eval("titulo") %></h5>
                            <p class="card-author">by <asp:Label ID="lblAuthor" runat="server" Text="Desconocido"></asp:Label></p>
                            <p class="card-text"><i class="fas fa-book"></i> EBOOK</p>
                        </div>
                        <div class="card-footer-custom">
                             <a href='DetallesRecurso.aspx?id=<%# Eval("idMaterial") %>' class="btn btn-primary">BORROW</a>
                             <a href="#" class="btn btn-light"><i class="fas fa-bookmark"></i></a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>

        <div class="d-flex justify-content-center mt-4">
            <asp:Button ID="btnPrev" runat="server" Text="Anterior" CssClass="btn btn-secondary me-2" OnClick="btnPrev_Click" />
            <asp:Label ID="lblPageNumber" runat="server" Text="Página 1" CssClass="align-self-center"></asp:Label>
            <asp:Button ID="btnNext" runat="server" Text="Siguiente" CssClass="btn btn-secondary ms-2" OnClick="btnNext_Click" />
        </div>
    </div>
</asp:Content>
