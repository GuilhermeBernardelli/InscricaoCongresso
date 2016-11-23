<%@ Page Title="" Language="C#" MasterPageFile="~/View/Layout.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="InscricaoCongresso.View.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 10px;
            height: 60px;
        }
        .auto-style2 {
            width: 3px;
            height: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Height="232px">
        <asp:TextBox ID="TextBox1" runat="server" Width="491px"></asp:TextBox>
        <asp:Button ID="btnGerar" runat="server" Text="Gerar" Width="134px" OnClick="btnGerar_Click" />
        <asp:Panel ID="pnlCodeBar" runat="server" Height="60px">
        </asp:Panel>
    </asp:Panel>
</asp:Content>
