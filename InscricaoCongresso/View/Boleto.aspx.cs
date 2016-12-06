﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscricaoCongresso.View
{
    public partial class Boleto : System.Web.UI.Page
    {
        public string codBarras = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //codBarras = Session["boleto"].ToString();
            //functionCodeBar(codBarras);
            
            lblLinhaDigitavel.Text = lblLinhaDigitavel1.Text = "23792.37205 60037.106394 74008.145000 3 69940000000000";
            functionCodeBar("23793699400000000002372060037106397400814500");
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
            System.Web.UI.WebControls.Image barragrossa = new System.Web.UI.WebControls.Image();
            barragrossa.ImageUrl = "~/Image/p.png";
            Label pretoGrosso = new Label()
            {
                Width = 4                
            };
            pretoGrosso.Controls.Add(barragrossa);
            pnlCodeBar.Controls.Add(pretoGrosso);
        }

        public void functionPretoFino()
        {
            System.Web.UI.WebControls.Image barrafina = new System.Web.UI.WebControls.Image();
            barrafina.ImageUrl = "~/Image/p_f.png";
            Label pretoFino = new Label()
            {
                Width = 2
            };
            pretoFino.Controls.Add(barrafina);
            pnlCodeBar.Controls.Add(pretoFino);
        }
        public void functionBrancoGrosso()
        {
            System.Web.UI.WebControls.Image brancogrosso = new System.Web.UI.WebControls.Image();
            brancogrosso.ImageUrl = "~/Image/b.png";
            Label brancoGrosso = new Label()
            {
                Width = 4
            };
            brancoGrosso.Controls.Add(brancogrosso);
            pnlCodeBar.Controls.Add(brancoGrosso);
        }

        public void functionBrancoFino()
        {
            System.Web.UI.WebControls.Image brancafina = new System.Web.UI.WebControls.Image();
            brancafina.ImageUrl = "~/Image/b_f.png";
            Label brancoFino = new Label()
            {
                Width = 2
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
           

        }

    }
}