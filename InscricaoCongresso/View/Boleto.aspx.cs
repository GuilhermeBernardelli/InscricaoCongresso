using InscricaoCongresso.Control;
using InscricaoCongresso.Model;
using NReco.ImageGenerator;
using System;
using System.Drawing.Printing;
using System.Web;
using System.Web.UI.WebControls;

namespace InscricaoCongresso.View
{
    public partial class Boleto : System.Web.UI.Page
    {
        BOLETOS boleto = new BOLETOS();
        CEDENTES cedente = new CEDENTES();
        CONTAS conta = new CONTAS();
        VALORES valor = new VALORES();
        INSCRITOS inscritos = new INSCRITOS();
        Controle controle = new Controle();
        ENDERECOS endereco = new ENDERECOS();
        LOGRADOUROS logradouro = new LOGRADOUROS();
        PAISES pais = new PAISES();
        CIDADES cidade = new CIDADES();
        ESTADOS estado = new ESTADOS();

        public static System.Drawing.Color preto = System.Drawing.Color.Black;
        public static System.Drawing.Color branco = System.Drawing.Color.White;

        public static string codBarras = "";
        public static string linhaDigitavel = "";
        public static int idPagador = 0;
        public static string navegador = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                HttpBrowserCapabilities browser = Request.Browser;
                navegador = browser.Browser;
            } 
            idPagador = Convert.ToInt32(Session["pagador"]);
            codBarras = Session["codBarras"].ToString();
            linhaDigitavel = (Session["boleto"]).ToString();

            boleto = controle.pesquisaBoletoUsuario(idPagador);
            inscritos = controle.pesquisaInscritosId(idPagador);
            cedente = controle.pesquisaCedente("IAMSPE");
            valor = controle.pesquisaValorPorId(boleto.idValor);
            conta = controle.pesquisaContaPorId(cedente.idConta);
                        
            string auxiliar = "";
            foreach (char value in linhaDigitavel)
            {
                auxiliar += value;
                if (auxiliar.Length == 5 || auxiliar.Length == 17)
                {
                    auxiliar += ".";
                }
                else if (auxiliar.Length == 11 || auxiliar.Length == 24 || auxiliar.Length == 30 || auxiliar.Length == 37 || auxiliar.Length == 39)
                {
                    auxiliar += " ";
                }              
            }
            //"03399.01233 45600.000009 00000.001024 3 68420000018300"
            //preenchimento das labels sem tratamento nas bases de dados ou páginas anteriores
            lblAceite1.Text = "S";
            lblEspecieDoc.Text = "DM";
            lblQnt.Text = "1";
            
            //preenchimento das labels com tratamento ou formatação anterior a renderização nesta página
            lblLinhaDigitavel.Text = lblLinhaDigitavel1.Text = auxiliar;
            lblAgeCodBen.Text = lblAgeCodBen1.Text = conta.agenciaNumero + "/" + cedente.codigoCedente;
            lblCPF_CNPJ.Text = Convert.ToUInt64(cedente.cnpjCedente).ToString(@"00\.000\.000\/0000\-00");
            lblNumBanco.Text = lblNumBanco1.Text = Convert.ToUInt64(conta.codigoBanco).ToString(@"000\-0");
            lblNossoNum.Text = lblNossoNum1.Text = Convert.ToUInt64(boleto.nossoNumero).ToString(@"000000000000\-0");
            lblNumDocumento.Text = lblNumDocumento1.Text = Convert.ToUInt64(boleto.numeroDocumento).ToString(@"00000000");
            lblPagadorRodape.Text = inscritos.nome + " - CPF/CNPJ: " + Convert.ToUInt64(inscritos.cpf).ToString(@"000\.000\.000\-00");
            lblPagador.Text = inscritos.nome + " - " + Convert.ToUInt64(inscritos.cpf).ToString(@"000\.000\.000\-00");
            lblBeneficiarioRodape.Text = cedente.nomeCedente + " - " + cedente.cnpjCedente;
            //VALOR DIGITO 19 NÃO IDENTIFICADO O PORQUE OU MÉTODO DE USO
            lblCarteira.Text = conta.carteira.ToString() + "-19";
            
            //pesquisa para tratamento para representação do endereço no boleto
            endereco = controle.pesquisaEnderecoPorId(inscritos.idEndereco);
            //tratamento para endereços no Brasil
            if (endereco.idPaises == 1)
            {
                logradouro = controle.pesquisaLogradouroId(endereco.idLogradouro);
                cidade = controle.pesquisaCidadeId(endereco.idCidade);
                estado = controle.pesquisaEstadoId(cidade.idEstado);

                lblEndPagador.Text = lblEndPagadorRodape.Text = logradouro.siglaLogradouro + endereco.nomeEndereco + ", " + endereco.numeroEndereco + " - " + endereco.cep + " - " + cidade.nomeCidade + "/" + estado.siglaEstado;
            }
            //tratamento para endereços fora do país
            else
            {
                pais = controle.pesquisaPaisId(Convert.ToInt32(endereco.idPaises));
                lblEndPagador.Text = lblEndPagadorRodape.Text = endereco.nomeEndereco + ", " + endereco.numeroEndereco + " - " + endereco.cep + " - " + cidade.nomeCidade + " - " + pais.nomePais;
            }

            //preenchimento das labels sem tratamento ou préviamente tratadas 
            lblBeneficiario.Text = lblBeneficiario1.Text = cedente.nomeCedente;
            lblDeducoes.Text = lblDeducoes1.Text = boleto.abatimento.ToString();
            lblDescontos.Text = lblDescontos1.Text = boleto.descontos.ToString();
            lblEspecie.Text = lblEspecie1.Text = boleto.especieDocumento;
            lblAcrescimo.Text = lblAcrescimo1.Text = boleto.acrescimo.ToString();
            lblMulta.Text = lblMulta1.Text = boleto.multa.ToString();
            lblValorDocumento.Text = lblValorDocumento1.Text = valor.valor.ToString();
            lblLocal.Text = boleto.localPagamento;
            lblVencimento.Text = lblVencimento1.Text = boleto.dataVencimento;
            lblDataDocumento1.Text = boleto.dataEmissao;
                      
            //contrução do campo de informações
            lblInstrucoesLinha1.Text = boleto.informacoesL1;
            lblInstrucoesLinha2.Text = boleto.informacoesL2;
            lblInstrucoesLinha3.Text = boleto.informacoesL3;
            lblInstrucoesLinha4.Text = boleto.informacoesL4;
            lblInstrucoesLinha5.Text = boleto.informacoesL5;
            lblInstrucoesLinha6.Text = boleto.informacoesL6;
            lblInstrucoesLinha7.Text = boleto.informacoesL7;
            lblInstrucoesLinha8.Text = boleto.informacoesL8;
            lblInstrucoesLinha9.Text = boleto.informacoesL9;
            lblInstrucoesLinha10.Text = boleto.informacoesL10;

            //chamada para a renderização do código de barras
            //numeração de código de barras valido para testes do leitor bancário
            codBarras = "23791699400000000002372060037106397400814500";
            functionCodeBar(codBarras);
            btnPrint_Click(sender, e);
        }
        public void functionCodeBar(string numero)
        {
            //renderiza a representação de indicador de inicio do código de barras
            functionPretoFino();
            functionBrancoFino();
            functionPretoFino();
            functionBrancoFino();
            //renderiza do a porção numérica do código de barras a partir do parametro
            funcaoConverter(numero);
            //renderiza a representação de indicador de fim do código de barras
            functionPretoGrosso();
            functionBrancoFino();
            functionPretoFino();
        }
        public void functionPretoGrosso()
        {
            Image barragrossa = new Image();
            barragrossa.ImageUrl = "~/Image/p.png";            
            Label pretoGrosso = new Label();
            //alteração na imagem renderizada para atender ao padrão do IE
            if (navegador.Equals("IE"))
            {
                barragrossa.Width = 5;
                barragrossa.Height = 90;
                pretoGrosso = new Label()
                {                    
                    Width = 5,
                    Height = 90
                };
            }
            //imagem sem alteração para os demais navegadores
            else
            {
                pretoGrosso = new Label()
                {
                    Width = 4,
                    Height = 90
                };
            }
            pretoGrosso.Controls.Add(barragrossa);
            pnlCodeBar.Controls.Add(pretoGrosso);
        }

        public void functionPretoFino()
        {
            System.Web.UI.WebControls.Image barrafina = new System.Web.UI.WebControls.Image();
            barrafina.ImageUrl = "~/Image/p_f.png";
            Label pretoFino = new Label()
            {
                Width = 2,
                Height = 90
            };
            pretoFino.Controls.Add(barrafina);
            pnlCodeBar.Controls.Add(pretoFino);
        }
        public void functionBrancoGrosso()
        {
            System.Web.UI.WebControls.Image brancogrosso = new System.Web.UI.WebControls.Image();
            brancogrosso.ImageUrl = "~/Image/b.png";
            Label brancoGrosso = new Label();
            if (navegador.Equals("IE"))
            {
                brancoGrosso = new Label()
                {
                    Width = 5,
                    Height = 90
                };
            }
            else
            {
                brancoGrosso = new Label()
                {
                    Width = 4,
                    Height = 90
                };
            }
            brancoGrosso.Controls.Add(brancogrosso);
            pnlCodeBar.Controls.Add(brancoGrosso);
        }

        public void functionBrancoFino()
        {
            System.Web.UI.WebControls.Image brancafina = new System.Web.UI.WebControls.Image();
            brancafina.ImageUrl = "~/Image/b_f.png";
            Label brancoFino = new Label()
            {
                Width = 2,
                Height = 90
            };
            brancoFino.Controls.Add(brancafina);
            pnlCodeBar.Controls.Add(brancoFino);
        }

        public void funcaoRenderizar(string valor)
        {
            int count = 0;
            char[] numeros = valor.ToCharArray();
            string[] pares = new string[99];
            for (int i = 0; i < numeros.Length; i++)
            {
                if (i % 2 == 0)
                {
                    string numero = numeros[i].ToString();
                    pares[count] = numero;
                }
                else
                {
                    pares[count] = pares[count] + numeros[i].ToString();
                    if (Convert.ToInt32(pares[count]) <= 49)
                    {
                        pares[count] = (Convert.ToInt32(pares[count]) + 48).ToString();
                    }
                    else
                    {
                        pares[count] = (Convert.ToInt32(pares[count]) + 142).ToString();
                    }
                    funcaoConverter(pares[count]);
                    count++;
                }
            }

        }

        public void funcaoConverter(string valor)
        //public string[] funcaoConverter(string valor)
        {
            char[] numeros = valor.ToCharArray();
            string convertido = "", digito1 = "", digito2 = "";
            int count = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i].Equals('0'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "00110";
                    }
                    else
                    {
                        digito2 = "00110";
                    }
                }
                else if (numeros[i].Equals('1'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "10001";
                    }
                    else
                    {
                        digito2 = "10001";
                    }
                }
                else if (numeros[i].Equals('2'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "01001";
                    }
                    else
                    {
                        digito2 = "01001";
                    }
                }
                else if (numeros[i].Equals('3'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "11000";
                    }
                    else
                    {
                        digito2 = "11000";
                    }
                }
                else if (numeros[i].Equals('4'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "00101";
                    }
                    else
                    {
                        digito2 = "00101";
                    }
                }
                else if (numeros[i].Equals('5'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "10100";
                    }
                    else
                    {
                        digito2 = "10100";
                    }
                }
                else if (numeros[i].Equals('6'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "01100";
                    }
                    else
                    {
                        digito2 = "01100";
                    }
                }
                else if (numeros[i].Equals('7'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "00011";
                    }
                    else
                    {
                        digito2 = "00011";
                    }
                }
                else if (numeros[i].Equals('8'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "10010";
                    }
                    else
                    {
                        digito2 = "10010";
                    }
                }
                else if (numeros[i].Equals('9'))
                {
                    if (i % 2 == 0)
                    {
                        digito1 = "01010";
                    }
                    else
                    {
                        digito2 = "01010";
                    }
                }
                if (i % 2 != 0)
                {
                    convertido = convertido + functionIntercalar(digito1, digito2);
                }
                count++;
            }
            functionRenderiza(convertido);
        }

        private string functionIntercalar(string digito1, string digito2)
        {
            char[] aux1 = digito1.ToCharArray();
            char[] aux2 = digito2.ToCharArray();
            string auxiliar = "";
            for (int i = 0; i < 5; i++)
            {
                auxiliar = auxiliar + digito1[i].ToString() + digito2[i].ToString();
            }
            return auxiliar;
        }

        public void functionRenderiza(string convertido)
        {
            char[] binarios = convertido.ToCharArray();
            //string[] convertido = new string[99];
            for (int i = 0; i < binarios.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (binarios[i].Equals('0'))
                    {
                        functionPretoFino();
                    }
                    else
                    {
                        functionPretoGrosso();
                    }

                }
                else
                {
                    if (binarios[i].Equals('0'))
                    {
                        functionBrancoFino();
                    }
                    else
                    {
                        functionBrancoGrosso();
                    }
                }
            }
        }


        protected void btnPrint_Click(object sender, EventArgs e)
        {            
            Response.Write("<script>window.print();</script>");
        }   
        public void print_this(object sender, PrintPageEventArgs ev)
        {/*
            // Draw a picture.
            ev.Graphics.DrawImage(, ev.Graphics.VisibleClipBounds);

            // Indicate that this is the last page to print.
            ev.HasMorePages = false;*/
        }               
    }
}