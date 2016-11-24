<%@ Page Title="" Language="C#" MasterPageFile="~/View/nova.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="InscricaoCongresso.View.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 10px;
            height: 60px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="105px" Width="744px">
        <asp:Label ID="lblTitulo" runat="server" Text="REALIZAR INSCRIÇÃO E GERAR BOLETO" Font-Bold="True" Font-Names="Arial" Font-Size="XX-Large" Width="100%"></asp:Label>
        <asp:Panel ID="Panel3" runat="server" Height="24px">
        </asp:Panel>
    </asp:Panel>
<asp:Panel ID="Panel2" runat="server" Height="47px" Width="746px">
    <asp:Button ID="btnGerar" runat="server" Text="Gerar Boleto" Width="134px" />
</asp:Panel>
</asp:Content>
