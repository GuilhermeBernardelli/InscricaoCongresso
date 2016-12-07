<%@ Page Title="" Language="C#" MasterPageFile="~/View/nova.Master" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="InscricaoCongresso.View.Principal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="~/CSS/StyleSheet.css">
    <style type="text/css">

        .auto-style1 {
            width: 10px;
            height: 60px;
        }
        .auto-style2 {
            width: 70%;
        }
        .auto-style3 {
            margin-top: 15px;
        }
        .auto-style4 {
            margin-left: 0px;
        }
        .auto-style5 {
            margin-top: 4px;
        }
        .auto-style6 {
            margin-top: 0px;
        }
        .auto-style9 {
        margin-top: 2px;
    }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="auto-style2">
        <asp:Panel ID="Panel1" runat="server" HorizontalAlign="Right">
            <asp:Label ID="lblIdioma" runat="server" Font-Bold="True" ForeColor="#006600" Height="22px" Text="Idiomas : " Width="145px"></asp:Label>
            &nbsp;&nbsp;<asp:ImageButton ID="btnPortugues" runat="server" ImageUrl="~/Image/icoBR.jpg" Width="25px" OnClick="btnPortugues_Click" />
            <asp:ImageButton ID="btnEspanol" runat="server" ImageUrl="~/Image/icoES.jpg" Width="25px" OnClick="btnEspanol_Click" />
            <asp:ImageButton ID="btnIngles" runat="server" ImageUrl="~/Image/icoEN.jpg" Width="25px" OnClick="btnIngles_Click" />
        </asp:Panel>
        <asp:Panel ID="pnlTopo" runat="server" Height="94px">
            <asp:Label ID="lblTitulo" runat="server" CssClass="preenchimento" Font-Bold="True" Font-Names="Verdana" Font-Size="XX-Large" Text="REALIZAR INSCRIÇÃO" Width="100%" Height="42px" ForeColor="#006600"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lblAviso" runat="server" Text="Para 2ª via, preencher o campo CPF e clicar no botão &quot;Gerar Boleto de Pagamento&quot;"></asp:Label>
            <br />
            </asp:Panel>
        <asp:Panel ID="pnlForm" runat="server" Height="138px" Width="100%" HorizontalAlign="Left" BorderColor="#006600" GroupingText="Dados pessoais">
            <br />
&nbsp;<asp:Label ID="lblNome" runat="server" Text="Nome : "></asp:Label>
            <asp:TextBox ID="txtNome" runat="server" Width="483px" AutoPostBack="True" OnTextChanged="ValidaNome"></asp:TextBox>
&nbsp;
            <asp:Label ID="lblCpf" runat="server" Text="CPF : "></asp:Label>
            <asp:TextBox ID="txtCPF" runat="server" Width="168px" AutoPostBack="True" OnTextChanged="ValidaCPF"></asp:TextBox>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblRgRne" runat="server" Text="RG/RNE : "></asp:Label>
            <asp:TextBox ID="txtRG" runat="server" Width="140px"></asp:TextBox>
&nbsp;
            <asp:Label ID="lblNascimento" runat="server" Text="Data de nascimento : "></asp:Label>
            <asp:TextBox ID="txtNascimento" runat="server" Width="140px" TextMode="DateTime"></asp:TextBox>
&nbsp;
            <asp:Label ID="lblNacionalidade" runat="server" Text="Nacionalidade : "></asp:Label>
            <asp:TextBox ID="txtNacional" runat="server" Width="150px" AutoPostBack="True" OnTextChanged="ValidaNacionalidade"></asp:TextBox>
            <br />
            <br />
            
        </asp:Panel>
        
        <asp:Panel ID="pnlEndereco" runat="server" Height="335px" Width="100%" CssClass="auto-style9" GroupingText="Dados de endereço" HorizontalAlign="Left" >
            <br />
            &nbsp;<asp:CheckBox ID="chkEstrangeiro" runat="server" Text="Residente no exterior" TextAlign="Left" OnCheckedChanged="chkEstrangeiro_CheckedChanged" AutoPostBack="True" />
            &nbsp;
            <asp:Label ID="lblPaises" runat="server" Text="Selecione o País : " Visible="False"></asp:Label>
            <asp:DropDownList ID="ddlPaises" runat="server" CssClass="auto-style4" Height="19px" Width="220px" Visible="False" AutoPostBack="True">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblEndereco" runat="server" Text="Endereço : "></asp:Label>
            <asp:DropDownList ID="ddlLogradouro" runat="server" Height="19px" Width="70px" AutoPostBack="True">
            </asp:DropDownList>
            &nbsp;<asp:TextBox ID="txtEndereco" runat="server" Width="460px"></asp:TextBox>
            &nbsp;<asp:Label ID="lblNumeral" runat="server" Text="Número : "></asp:Label>
&nbsp;<asp:TextBox ID="txtNumeral" runat="server" Width="42px"></asp:TextBox>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblBairro" runat="server" Text="Bairro : "></asp:Label>
            <asp:TextBox ID="txtBairro" runat="server" Width="200px"></asp:TextBox>
            &nbsp; &nbsp;<asp:Label ID="lblCidade" runat="server" Text="Cidade : "></asp:Label>
            <asp:DropDownList ID="ddlCidade" runat="server" Height="19px" Width="145px" AutoPostBack="True" Enabled="False">
            </asp:DropDownList>
            <asp:TextBox ID="txtCidade" runat="server" Visible="False" Width="243px"></asp:TextBox>
            &nbsp;<asp:Label ID="lblUF" runat="server" Text="UF : "></asp:Label>
            <asp:DropDownList ID="ddlEstado" runat="server" Height="19px" Width="70px" AutoPostBack="True" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblCep" runat="server" Text="CEP : "></asp:Label>
            <asp:TextBox ID="txtCEP" runat="server" Width="145px"></asp:TextBox>
            &nbsp;
            <asp:Label ID="lblComplemento" runat="server" Text="Complemento : "></asp:Label>
            <asp:TextBox ID="txtComplemento" runat="server" Width="352px"></asp:TextBox>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblEmail" runat="server" Text="Email : "></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" Width="607px"></asp:TextBox>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblTelefone1" runat="server" Text="Telefone principal : "></asp:Label>
            <asp:TextBox ID="txtTelefone1" runat="server" Width="210px"></asp:TextBox>
            &nbsp;<asp:Label ID="lblTelefone2" runat="server" Text="Telefone secundário : "></asp:Label>
            <asp:TextBox ID="txtTelefone2" runat="server" Width="210px"></asp:TextBox>
            &nbsp;<br />
            <br />
            &nbsp;<asp:Label ID="lblCelular" runat="server" Text="Celular : "></asp:Label>
            <asp:TextBox ID="txtCelular" runat="server" Width="210px"></asp:TextBox>
            <br />
            <br />
            
            
            
        </asp:Panel>
        <asp:Panel ID="pnlProfissional" runat="server" HorizontalAlign="Left" GroupingText="Dados profissionais/acadêmicos" Height="192px" CssClass="auto-style6">
                &nbsp;
                <br />
                &nbsp;<asp:Label ID="lblArea" runat="server" Text="Área profissional : "></asp:Label>
                <asp:TextBox ID="txtArea" runat="server" Width="213px"></asp:TextBox>
&nbsp;<asp:Label ID="lblLocalTrabalho" runat="server" Text="Local de trabalho/estudo : "></asp:Label>
                <asp:TextBox ID="txtLocal" runat="server" Width="252px"></asp:TextBox>
                <br />
                <br />
                &nbsp;<asp:Label ID="lblSituacaoFormacao" runat="server" Text=" Situação atual dos estudos : "></asp:Label>
                <asp:TextBox ID="txtSituacao" runat="server" Width="587px"></asp:TextBox>
                <br />
                &nbsp;<br />&nbsp;<asp:Label ID="lblTrabalho" runat="server" Text="Irá apresentar trabalho acadêmico ?"></asp:Label>
                <br />
                &nbsp;&nbsp;&nbsp;
                <asp:CheckBox ID="chkTrabalho" runat="server" AutoPostBack="True" OnCheckedChanged="chkTrabalho_CheckedChanged" Text="Sim" TextAlign="Left" />
                <br />
            <br />
        </asp:Panel>
        <asp:Panel ID="pnlTrabalho" runat="server" Height="381px" CssClass="left" Visible="False" GroupingText="Trabalho acadêmico" HorizontalAlign="Left" style="margin-top: 0px">
            <br />
            &nbsp;<asp:Label ID="lblNomeTrabalho" runat="server" Text="Titulo do trabalho : " ></asp:Label>
            <asp:TextBox ID="txtTituloTrabalho" runat="server" Width="630px" CausesValidation="True" ValidateRequestMode="Enabled"></asp:TextBox>
            <br />
            <br />
            &nbsp;<asp:Label ID="lblResumo" runat="server" Text="Resumo : "></asp:Label>
            <asp:TextBox ID="txtTrabalhoResumo" runat="server" Height="52px" TextMode="MultiLine" Width="707px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />&nbsp;&nbsp;<asp:Label ID="lblListaAutores" runat="server" Text="Autores associados : "></asp:Label>
            <asp:TextBox ID="txtTrabalhoAutores" runat="server" Height="43px" TextMode="MultiLine" Width="636px" ReadOnly="True"></asp:TextBox>
            <br />
            <br />
            <asp:Panel ID="pnlAutores" runat="server" GroupingText="Autor(es)" Height="149px">
            
                <asp:Panel ID="pnlAdicionar" runat="server" Height="33px" HorizontalAlign="Right" Visible="False" CssClass="auto-style5">
            <asp:Button ID="btnAdicionar" runat="server" Text="(+) Outro autor" CssClass="auto-style4" Width="112px" OnClick="btnAdicionar_Click" Height="22px" />
            
            </asp:Panel>
                <asp:Panel ID="pnlAutor" runat="server" HorizontalAlign="Center">
                    <asp:Label ID="lblAutorSobrenome" runat="server" Text="Sobrenome : "></asp:Label>
                    <asp:TextBox ID="txtSobrenomeAutor" runat="server" Width="156px"></asp:TextBox>
                    &nbsp;<asp:Label ID="lblAutorNome" runat="server" Text="Nome : " ></asp:Label>
                    <asp:TextBox ID="txtNomeAutor" runat="server" Width="156px"></asp:TextBox>
                    <asp:Label ID="lblAutorNomeMeio" runat="server" Text="Nome do meio : " Width="121px"></asp:Label>
                    <asp:TextBox ID="txtNomeMeioAutor" runat="server" Width="156px"></asp:TextBox>
                </asp:Panel>
            <br />
            <br />
                </asp:Panel>
            
        </asp:Panel>
        
        <asp:Panel ID="pnlButton" runat="server" Height="67px" Width="100%" CssClass="auto-style6" >
            
            
            
            <asp:Button ID="btnGerar" runat="server" Text="Gerar Boleto de Pagamento" Width="198px" Height="35px" CssClass="auto-style3" OnClick="btnGerar_Click" />
        </asp:Panel>
    </div>
</asp:Content>
