<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Boleto.aspx.cs" Inherits="InscricaoCongresso.View.Boleto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/CSS/StyleSheet.css">
    <title></title>
    <style type="text/css">
        .pnlCodeBar {            
            margin-left: 10px;
            position:absolute;
            z-index: 4;            
        }
        .auto-style3 {
            width: 1185px;
            height: 1464px;
        }
        .auto-style4 {
            position: absolute;
            left: 11px;
            top: 15px;
            height: 1468px;
            bottom: -569px;
            width: 1095px;
            margin-left: 0px;
        }
        .auto-style5 {
            margin-left: 10px;
            position: absolute;
            z-index: 4;
            left: 14px;
            top: 15px;
            height: 1445px;
            width: 1123px;
        }
        .auto-style6 {
            margin-left: 0px;
        }
        .auto-style7 {
            height: 58px;
            margin-left: 9px;
            margin-top: 0px;
            align-items:center
        }
        .auto-style8 {
            width: 232px;
            height: 100%;
            margin-top: 2px;
        }
        .auto-style9 {
            height: 45px;
            margin-left: 9px;
            width: 1054px;
            margin-top: 9px;
        }
        .auto-style10 {
            margin-left: 5px;
            margin-top: 0px;
        }
        .auto-style11 {
            text-align: center;
            margin-left: 6px;
        }
        .auto-style12 {
            text-align: center;
            margin-left: 8px;
        }
        .auto-style13 {
            margin-left: 9px;
        }
        .auto-style14 {
            margin-top: 0px;
        }
        .auto-style15 {
            margin-top: 0px;
            margin-left: 8px;
        }
        .auto-style16 {
            margin-left: 14px;
        }
        .auto-style17 {
            text-align: right;
            margin-top: 0px;
        }
        .auto-style18 {
            margin-top: 2px;
            margin-left: 9px;
        }
        .auto-style19 {
            margin-top: 0px;
            margin-left: 0px;
        }
    </style>
</head>
<body class="body">
    <div class="auto-style3">
        <img src="../Image/BoletoBase.png" class="auto-style4"/>
        <form id="form1" runat="server" class="auto-style5">
            <asp:Panel ID="pnlTopo" runat="server" Height="320px">
            </asp:Panel>
            <div class="auto-style7">
                <img alt="" class="auto-style8" src="../Image/Santander.png" />&nbsp;&nbsp;                
                <asp:Label ID="lblNumBanco" runat="server" Width="75px" Font-Bold="True" Font-Size="X-Large" CssClass="auto-style10" Font-Names="Arial" Height="67%">033-7</asp:Label>
            &nbsp;&nbsp;
                <asp:Label ID="lblLinhaDigitavel" text="03399.12388 79800.000006 00111.201026 4 37690001113500" runat="server" Width="701px" Font-Bold="True" Font-Size="X-Large" Font-Names="Arial" CssClass="auto-style17" Height="67%" ></asp:Label>
            </div>
            <div class="auto-style9">
                &nbsp;
                <asp:Label ID="lblT_Beneficiario" runat="server" Text="Beneficiário" Font-Size="Small" Font-Names="Arial" Height="20px" CssClass="auto-style14" Width="476px"></asp:Label>
               
                
                <asp:Label ID="lblT_AgencCodBenef" runat="server" Text="Agência/Código do Beneficiário" Font-Size="Small" Font-Names="Arial" Height="20px" Width="202px"></asp:Label>
                <asp:Label ID="lblT_Especie" runat="server" Text="Espécie" Font-Size="Small" Font-Names="Arial" Height="20px" Width="55px"></asp:Label>
                &nbsp;<asp:Label ID="lblT_Qnt" runat="server" Text="Quantidade" Font-Size="Small" Font-Names="Arial" Height="20px" Width="80px"></asp:Label>
                <asp:Label ID="lblT_NossoNum" runat="server" Text="Nosso número" Font-Size="Small" Font-Names="Arial" Height="20px" CssClass="auto-style6"></asp:Label>
                <br />
                &nbsp;&nbsp;
                <asp:Label ID="lblBeneficiario" runat="server" Text="Guilherme Bernardelli Prezia Rodrigues" Font-Size="Large" Font-Names="Arial" Width="463px" Height="23px"></asp:Label>
                
                <asp:Label ID="lblAgencCodBenef" runat="server" Text="4042/1238798" Font-Size="Large" Font-Names="Arial" Width="194px" Height="23px" CssClass="preenchimento"></asp:Label>
                <asp:Label ID="lblEspecie" runat="server" Text="R$" Font-Size="Large" Font-Names="Arial" Width="57px" Height="23px" CssClass="auto-style11"></asp:Label>
                <asp:Label ID="lblQnt" runat="server" Text="1" Font-Size="Large" Font-Names="Arial" Width="64px" Height="23px" CssClass="auto-style12"></asp:Label>
                <asp:Label ID="lblNossoNum" runat="server" Text="0000000000111-2" Font-Size="Large" Font-Names="Arial" Width="197px" Height="23px" CssClass="auto-style13"></asp:Label>
                </div>
            <div class="auto-style18">
                <asp:Label ID="lblT_NumDocumento" runat="server" Text="Número do documento" Font-Size="Small" Font-Names="Arial" Height="23px" CssClass="auto-style15" Width="308px"></asp:Label>


                <asp:Label ID="lblT_CNPJ" runat="server" Text="CPF/CNPJ" Font-Size="Small" Font-Names="Arial" Height="23px" CssClass="auto-style19" Width="189px"></asp:Label>


                <br />
                <asp:Label ID="lblNumDocumento" runat="server" Text="00000111" Font-Size="Large" Font-Names="Arial" Width="299px" Height="25px" CssClass="auto-style16"></asp:Label>
            </div> 
            
            
            
            <asp:Panel ID="pnlCodeBar" runat="server" Height="90px" Width="911px" CssClass="auto-style6" >
            </asp:Panel>
        </form>
    </div>
</body>
</html>
