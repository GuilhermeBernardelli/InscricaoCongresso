<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="InscricaoCongresso.View.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
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
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Panel ID="Panel1" runat="server" Height="232px">
                <asp:TextBox ID="TextBox1" runat="server" Width="491px"></asp:TextBox>
                <asp:Button ID="btnGerar" runat="server" Text="Gerar" Width="134px" OnClick="btnGerar_Click" />
                <asp:Panel ID="pnlCodeBar" runat="server" Height="60px" HorizontalAlign="Left" class="panel">
                </asp:Panel>
            </asp:Panel>

        </div>
    </form>
</body>
</html>
