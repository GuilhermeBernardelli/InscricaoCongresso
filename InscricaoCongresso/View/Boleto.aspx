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
            left: -12px;
            top: 15px;
            height: 1566px;
            bottom: -727px;
            width: 1110px;
            margin-left: 0px;
        }
        .auto-style5 {
            margin-left: 10px;
            position: absolute;
            z-index: 4;
            left: -6px;
            top: 15px;
            height: 1445px;
            width: 1143px;
        }
        .auto-style6 {
            margin-left: 0px;
        }
        .auto-style7 {
            height: 58px;
            margin-left: 9px;
            margin-top: 14px;
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
            width: 1085px;
            margin-top: 10px;
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
        .auto-style19 {
            margin-top: 0px;
            margin-left: 0px;
        }
        .auto-style21 {
            text-align: center;
            margin-left: 0px;
        }
        .auto-style23 {
            margin-top: 0px;
            margin-left: 3px;
        }
        .auto-style25 {
            margin-left: 14px;
            height: 38px;
            margin-top: 6px;
        }
        .auto-style27 {
            margin-top: 0px;
            margin-left: 113px;
        }
        .auto-style28 {
            margin-top: 0px;
            margin-left: 23px;
        }
        .auto-style29 {
            height: 117px;
            margin-top: 10px;
        }
        .auto-style30 {
            margin-top: 0px;
            margin-left: 12px;
        }
        .auto-style31 {
            margin-top: 10px;
            margin-left: 9px;
            height: 48px;
        }
        .auto-style32 {
            margin-top: 7px;
            margin-left: 9px;
            height: 48px;
        }
        .auto-style33 {
            margin-left: 6px;
        }
        .auto-style37 {
            float: left;
            height: 251px;
            width: 287px;
            margin-left: 0px;
            margin-top: 5px;
        }
        .auto-style38 {
            float: left;
            height: 237px;
            width: 768px;
            margin-left: 11px;
            margin-top: 5px;
        }
        .auto-style39 {
            margin-left: 11px;
        }
        .auto-style40 {
            margin-left: 14px;
            height: 105px;
            margin-top: 27px;
        }
        .auto-style41 {
            margin-top: 0px;
            margin-left: 111px;
        }
        .auto-style42 {
            margin-top: 0px;
            margin-left: 739px;
        }
        .auto-style43 {
            margin-top: 0px;
            margin-left: 7px;
        }
        .auto-style44 {
            height: 59px;
            margin-left: 9px;
            margin-top: 0px;
            align-items: center;
        }
        .auto-style45 {
            margin-top: 5px;
            margin-left: 9px;
            height: 47px;
        }
        .auto-style46 {
            margin-top: 15px;
            margin-left: 3px;
        }
        .auto-style47 {
            margin-top: 6px;
            margin-left: 9px;
            height: 47px;
        }
        .auto-style48 {
            margin-top: 4px;
            margin-left: 9px;
            height: 47px;
        }
        .auto-style49 {
            margin-top: 5px;
            margin-left: 9px;
            height: 51px;
        }
        </style>
</head>
<body class="body">
    <div class="auto-style3">
        <img src="../Image/BoletoBase.png" class="auto-style4"/>
        <form id="form1" runat="server" class="auto-style5">
            <asp:Panel ID="pnlTopo" runat="server" Height="343px" Width="1140px">
            </asp:Panel>
            <div class="auto-style44">
                <img alt="" class="auto-style8" src="../Image/Santander.png" />&nbsp;&nbsp;                
                <asp:Label ID="lblNumBanco" runat="server" Width="84px" Font-Bold="True" Font-Size="X-Large" CssClass="auto-style10" Font-Names="Arial" Height="67%"></asp:Label>
            &nbsp;&nbsp;
                <asp:Label ID="lblLinhaDigitavel" runat="server" Width="701px" Font-Bold="True" Font-Size="X-Large" Font-Names="Arial" CssClass="auto-style17" Height="67%" ></asp:Label>
            </div>
            <div class="auto-style9">
                &nbsp;
                <asp:Label ID="lblT_Beneficiario" runat="server" Text="Beneficiário" Font-Size="Small" Font-Names="Arial" Height="20px" CssClass="auto-style14" Width="479px"></asp:Label>
               
                
                <asp:Label ID="lblT_AgeCodBen0" runat="server" Text="Agência/Código do Beneficiário" Font-Size="Small" Font-Names="Arial" Height="20px" Width="211px"></asp:Label>
                <asp:Label ID="lblT_Especie" runat="server" Text="Espécie" Font-Size="Small" Font-Names="Arial" Height="20px" Width="54px"></asp:Label>
                &nbsp;<asp:Label ID="lblT_Qnt" runat="server" Text="Quantidade" Font-Size="Small" Font-Names="Arial" Height="20px" Width="78px"></asp:Label>
                <asp:Label ID="lblT_NossoNum" runat="server" Text="Nosso número" Font-Size="Small" Font-Names="Arial" Height="20px" CssClass="auto-style6"></asp:Label>
                <br />
                &nbsp;&nbsp;
                <asp:Label ID="lblBeneficiario" runat="server" Font-Size="Large" Font-Names="Arial" Width="467px" Height="21px"></asp:Label>
                
                <asp:Label ID="lblAgeCodBen" runat="server" Font-Size="Large" Font-Names="Arial" Width="200px" Height="21px" CssClass="preenchimento"></asp:Label>
                <asp:Label ID="lblEspecie" runat="server" Font-Size="Large" Font-Names="Arial" Width="55px" Height="21px" CssClass="auto-style11"></asp:Label>
                <asp:Label ID="lblQnt" runat="server" Font-Size="Large" Font-Names="Arial" Width="70px" Height="21px" CssClass="auto-style12"></asp:Label>
                <asp:Label ID="lblNossoNum" runat="server" Font-Size="Large" Font-Names="Arial" Width="176px" Height="21px" CssClass="auto-style13"></asp:Label>
                </div>
            <div class="auto-style47">
                <asp:Label ID="lblT_NumDocumento" runat="server" Text="Número do documento" Font-Size="Small" Font-Names="Arial" Height="21px" CssClass="auto-style15" Width="311px"></asp:Label>


                <asp:Label ID="lblT_CPF_CNPJ" runat="server" Text="CPF/CNPJ" Font-Size="Small" Font-Names="Arial" Height="21px" CssClass="auto-style19" Width="224px"></asp:Label>


                <asp:Label ID="lblT_Vencimento" runat="server" Text="Vencimento" Font-Size="Small" Font-Names="Arial" Height="21px" CssClass="auto-style19" Width="221px"></asp:Label>


                <asp:Label ID="lblT_ValorDocumento" runat="server" Text="Valor do documento" Font-Size="Small" Font-Names="Arial" Height="21px" CssClass="auto-style19" Width="224px"></asp:Label>


                <br />
                <asp:Label ID="lblNumDocumento" runat="server" Font-Size="Large" Font-Names="Arial" Width="286px" Height="22px" CssClass="auto-style16"></asp:Label>
                                
                <asp:Label ID="lblCPF_CNPJ" runat="server" Font-Size="Large" Font-Names="Arial" Width="230px" Height="22px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblVencimento" runat="server" Font-Size="Large" Font-Names="Arial" Width="231px" Height="22px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblValorDocumento" runat="server" Font-Size="Large" Font-Names="Arial" Width="304px" Height="22px" CssClass="auto-style21"></asp:Label>
                </div>
            
            
            
            <div class="auto-style45">
                <asp:Label ID="lblT_Descontos" runat="server" Text="(-) Descontos/Abatimentos" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style23" Width="187px"></asp:Label>


                <asp:Label ID="lblT_Deducoes" runat="server" Text="(-) Outras deduções" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="189px"></asp:Label>


                <asp:Label ID="lblT_Mora" runat="server" Text="(+) Mora/Multa" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="189px"></asp:Label>


                <asp:Label ID="lblT_Acrecimos" runat="server" Text="(+) Outros acréscimos" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="188px"></asp:Label>


                <asp:Label ID="lblT_Valor" runat="server" Text="(=) Valor cobrado" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="184px"></asp:Label>


                <br />
                                
                <asp:Label ID="lblDescontos" runat="server" Font-Size="Large" Font-Names="Arial" Width="175px" Height="23px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblDeducoes" runat="server" Font-Size="Large" Font-Names="Arial" Width="193px" Height="23px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblMulta" runat="server" Font-Size="Large" Font-Names="Arial" Width="196px" Height="23px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblAcrescimo" runat="server" Font-Size="Large" Font-Names="Arial" Width="194px" Height="23px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblValorCobrado" runat="server" Font-Size="Large" Font-Names="Arial" Width="304px" Height="23px" CssClass="auto-style21"></asp:Label>
                </div>
            
            
            <div class="auto-style25">
                <asp:Label ID="lblT_Pagador" runat="server" Text="Pagador" Font-Size="Small" Font-Names="Arial" Height="34%" CssClass="auto-style14" Width="85px"></asp:Label>


                
                <asp:Label ID="lblPagador" runat="server" Font-Size="Small" Font-Names="Arial" Height="34%" CssClass="auto-style28" Width="664px"></asp:Label>


                
                <br />


                
                <asp:Label ID="lblEndPagador" runat="server" Font-Size="Small" Font-Names="Arial" Height="34%" CssClass="auto-style27" Width="666px"></asp:Label>


                
            </div>
            
            
            <div class="auto-style29">
                <asp:Label ID="lblDemonstrativo" runat="server" Text="Demonstrativo" Font-Size="Small" Font-Names="Arial" Height="42px" CssClass="auto-style30" Width="910px"></asp:Label>
                <asp:Label ID="lblAutenticacaoMecanica" runat="server" Text="Autenticação mecânica" Font-Size="Small" Font-Names="Arial" Height="47px" CssClass="auto-style30" Width="153px"></asp:Label>
                <br />
                <br />
                <br />
                <br />
                <asp:Label ID="lblAutenticacaoMecanica0" runat="server" Text="Corte na linha pontilhada" Font-Size="Small" Font-Names="Arial" Height="16px" CssClass="auto-style17" Width="1048px"></asp:Label>
            </div>
            <asp:Panel ID="Panel1" runat="server" Height="38px"></asp:Panel>
            <div class="auto-style7">
                <img alt="" class="auto-style8" src="../Image/Santander.png" />&nbsp;&nbsp;                
                <asp:Label ID="lblNumBanco1" runat="server" Width="84px" Font-Bold="True" Font-Size="X-Large" CssClass="auto-style10" Font-Names="Arial" Height="67%"></asp:Label>
            &nbsp;&nbsp;
                <asp:Label ID="lblLinhaDigitavel1" runat="server" Width="701px" Font-Bold="True" Font-Size="X-Large" Font-Names="Arial" CssClass="auto-style17" Height="67%" ></asp:Label>
            </div>
           <div class="auto-style31">
                <asp:Label ID="lblT_Local" runat="server" Text="Local de pagamento" Font-Size="Small" Font-Names="Arial" Height="23px" CssClass="auto-style15" Width="763px"></asp:Label>


                <asp:Label ID="lblT_Vencimento1" runat="server" Text="Vencimento" Font-Size="Small" Font-Names="Arial" Height="23px" CssClass="auto-style19" Width="224px"></asp:Label>


                <br />
                <asp:Label ID="lblLocal" runat="server" Font-Size="Large" Font-Names="Arial" Width="760px" Height="23px" CssClass="auto-style16"></asp:Label>
                                
                <asp:Label ID="lblVencimento1" runat="server" Font-Size="Large" Font-Names="Arial" Width="285px" Height="23px" CssClass="auto-style21"></asp:Label>
                </div> 
            <div class="auto-style32">
                <asp:Label ID="lblT_Beneficiario1" runat="server" Text="Beneficiário" Font-Size="Small" Font-Names="Arial" Height="22px" CssClass="auto-style15" Width="763px"></asp:Label>


                <asp:Label ID="lblT_AgenCodBen" runat="server" Text="Agência/Código do Beneficiário" Font-Size="Small" Font-Names="Arial" Height="22px" CssClass="auto-style19" Width="224px"></asp:Label>


                <br />
                <asp:Label ID="lblBeneficiario1" runat="server" Font-Size="Large" Font-Names="Arial" Width="760px" Height="23px" CssClass="auto-style16"></asp:Label>
                                
                <asp:Label ID="lblAgeCodBen1" runat="server" Font-Size="Large" Font-Names="Arial" Width="285px" Height="23px" CssClass="auto-style21"></asp:Label>
                </div>
             <div class="auto-style48">
                <asp:Label ID="lblT_DataDocumento1" runat="server" Text="Data do documento" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style23" Width="182px"></asp:Label>


                <asp:Label ID="lblT_NumDocumento1" runat="server" Text="Nº documento" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="279px"></asp:Label>


                <asp:Label ID="lblT_EspecieDoc" runat="server" Text="Espécie doc." Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="106px"></asp:Label>


                <asp:Label ID="lblT_Aceite1" runat="server" Text="Aceite" Font-Size="Small" Font-Names="Arial" Height="20px" Width="54px"></asp:Label>


                <asp:Label ID="lblT_DataProc" runat="server" Text="Data processamento" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="132px"></asp:Label>


                <asp:Label ID="lblT_NossoNumero1" runat="server" Text="Nosso número" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="184px"></asp:Label>


                <br />
                                
                <asp:Label ID="lblDataDocumento1" runat="server" Font-Size="Large" Font-Names="Arial" Width="179px" Height="21px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblNumDocumento1" runat="server" Font-Size="Large" Font-Names="Arial" Width="272px" Height="21px" CssClass="auto-style33"></asp:Label>
                                
                <asp:Label ID="lblEspecieDoc" runat="server" Font-Size="Large" Font-Names="Arial" Width="101px" Height="21px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblAceite1" runat="server" Font-Size="Large" Font-Names="Arial" Width="64px" Height="21px" CssClass="auto-style11"></asp:Label>
                                
                <asp:Label ID="lblDataProc" runat="server" Font-Size="Large" Font-Names="Arial" Width="120px" Height="21px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblNossoNum1" runat="server" Font-Size="Large" Font-Names="Arial" Width="291px" Height="21px" CssClass="auto-style21"></asp:Label>
                </div>
            <div class="auto-style49">
                <asp:Label ID="lblT_UsoBanco" runat="server" Text="Uso do banco" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style23" Width="182px"></asp:Label>


                <asp:Label ID="lblT_Carteira" runat="server" Text="Carteira" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="91px"></asp:Label>


                <asp:Label ID="lblT_Especie1" runat="server" Text="Espécie" Font-Size="Small" Font-Names="Arial" Height="20px" Width="81px"></asp:Label>


                <asp:Label ID="lblT_Qnt1" runat="server" Text="Quantidade" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="99px"></asp:Label>


                <asp:Label ID="lblT_Valor1" runat="server" Text="Valor" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="297px"></asp:Label>


                <asp:Label ID="lblT_ValorDoc" runat="server" Text="(=) Valor documento" Font-Size="Small" Font-Names="Arial" Height="19px" CssClass="auto-style19" Width="184px"></asp:Label>


                <br />
                                
                <asp:Label ID="lblUsoBanco" runat="server" Font-Size="Large" Font-Names="Arial" Width="179px" Height="23px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblCarteira" runat="server" Font-Size="Large" Font-Names="Arial" Width="91px" Height="23px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblEspecie1" runat="server" Font-Size="Large" Font-Names="Arial" Width="62px" Height="23px" CssClass="auto-style11"></asp:Label>
                                
                <asp:Label ID="lblQnt1" runat="server" Font-Size="Large" Font-Names="Arial" Width="118px" Height="23px" CssClass="auto-style21"></asp:Label>
                                
                <asp:Label ID="lblValor1" runat="server" Font-Size="Large" Font-Names="Arial" Width="288px" Height="23px" CssClass="auto-style33"></asp:Label>
                                
                <asp:Label ID="lblValorDocumento1" runat="server" Font-Size="Large" Font-Names="Arial" Width="288px" Height="23px" CssClass="auto-style21"></asp:Label>
                </div>
            <div class="auto-style38">
                                
                <asp:Label ID="lblInstrucoes" runat="server" Text="Instruções(Instruções de responsabilidade do Beneficiário. Qualquer dúvida sobre este boleto, contate o beneficiário)" Font-Size="Small" Font-Names="Arial" Width="100%" Height="19px" CssClass="auto-style14"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha1" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha2" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha3" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha4" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha5" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha6" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha7" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha8" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha9" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
                <asp:Label ID="lblInstrucoesLinha10" runat="server" Font-Size="Small" Font-Names="Arial" Width="98%" Height="19px" CssClass="auto-style39"></asp:Label>
                                
                <br />
                                
            </div>
            <div class="auto-style37">
                <asp:Label ID="lblT_Abatimento1" runat="server" Text="(-) Descontos/Abatimentos" Font-Size="Small" Font-Names="Arial" Height="23px" CssClass="auto-style43" Width="182px"></asp:Label>
                <br />
                <asp:Label ID="lblDescontos1" runat="server" Font-Size="Large" Font-Names="Arial" Width="288px" Height="26px" CssClass="auto-style21"></asp:Label>
                <br />
                <asp:Label ID="lblT_Deducoes1" runat="server" CssClass="auto-style43" Font-Names="Arial" Font-Size="Small" Height="23px" Text="(-) Outras deduções" Width="182px"></asp:Label>
                <br />
                <asp:Label ID="lblDeducoes1" runat="server" CssClass="auto-style21" Font-Names="Arial" Font-Size="Large" Height="26px" Width="288px"></asp:Label>
                <br />
                <asp:Label ID="lblT_Mora1" runat="server" CssClass="auto-style43" Font-Names="Arial" Font-Size="Small" Height="22px" Text="(+) Mora/Multa" Width="182px"></asp:Label>
                <br />
                <asp:Label ID="lblMulta1" runat="server" CssClass="auto-style21" Font-Names="Arial" Font-Size="Large" Height="27px" Width="288px"></asp:Label>
                <br />
                <asp:Label ID="lblT_Acrescimo1" runat="server" CssClass="auto-style43" Font-Names="Arial" Font-Size="Small" Height="22px" Text="(+) Outros acréscimos" Width="182px"></asp:Label>
                <br />
                <asp:Label ID="lblAcrescimo1" runat="server" CssClass="auto-style21" Font-Names="Arial" Font-Size="Large" Height="25px" Width="288px"></asp:Label>                
                <br />
                <asp:Label ID="lblT_ValorCob1" runat="server" CssClass="auto-style43" Font-Names="Arial" Font-Size="Small" Height="22px" Text="(=) Valor cobrado" Width="182px"></asp:Label>
                <br />
                <asp:Label ID="lblValorCobrado1" runat="server" CssClass="auto-style21" Font-Names="Arial" Font-Size="Large" Height="25px" Width="288px"></asp:Label>                
            </div>
            
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <div class="auto-style40">
                <asp:Label ID="lblT_Rodape" runat="server" Text="Pagador" Font-Size="Small" Font-Names="Arial" Height="26px" Width="56px"></asp:Label>


                
                <br />


                
                <asp:Label ID="lblPagadorRodape" runat="server" Font-Size="Small" Font-Names="Arial" Height="22px" CssClass="auto-style41" Width="664px"></asp:Label>


                
                <br />


                
                <asp:Label ID="lblEndPagadorRodape" runat="server" Font-Size="Small" Font-Names="Arial" Height="24px" CssClass="auto-style27" Width="666px"></asp:Label>


                
                <br />


                
                <asp:Label ID="lblCodBaixa" runat="server" Text="Cód. baixa" Font-Size="Small" Font-Names="Arial" Height="21px" CssClass="auto-style42" Width="154px"></asp:Label>


                
                <br />


                
                <asp:Label ID="lblT_Sacador" runat="server" Text="Sacador/Avalista" Font-Size="Small" Font-Names="Arial" Height="16px" CssClass="auto-style19" Width="111px"></asp:Label>


                
                <asp:Label ID="lblBeneficiarioRodape" runat="server" Font-Size="Small" Font-Names="Arial" Height="16px" CssClass="auto-style19" Width="647px"></asp:Label>


                
                <asp:Label ID="lblAutenticacao" runat="server" Text="Autenticação mecânica - Ficha de Compensação" Font-Size="Small" Font-Names="Arial" Height="16px" CssClass="auto-style19" Width="313px"></asp:Label>


                
            </div>
            <asp:Panel ID="pnlCodeBar" runat="server" Height="89px" Width="1037px" CssClass="auto-style46" >
            </asp:Panel>
            <asp:Panel ID="pnlEnd" runat="server" Height="16px" Width="1060px" CssClass="auto-style43" >
                <asp:Label ID="lblCorte" runat="server" Text="Corte na linha pontilhada" Font-Size="Small" Font-Names="Arial" Height="16px" CssClass="auto-style17" Width="1044px"></asp:Label>
            </asp:Panel>

        </p>
    
            <!--script language="JavaScript">
                window.matchMedia("min-width:2000px")
                window.print()
            </script-->
        </form>
    </div>

    

</body>
</html>
