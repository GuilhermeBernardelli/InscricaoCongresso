<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boleto.aspx.cs" Inherits="InscricaoCongresso.View.Boleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            margin-left: 10px;
        }
        .auto-style3 {
            width: 1100px;
            height: 1454px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="pnlBoleto" runat="server" Height="1357px">
            &nbsp;<img alt="" class="auto-style3" src="../Image/BoletoBase.png" /></asp:Panel>
        <asp:Panel ID="pnlCodeBar" runat="server" Height="90px" Width="911px" CssClass="auto-style2">
        </asp:Panel>
    </form>
</body>
</html>
