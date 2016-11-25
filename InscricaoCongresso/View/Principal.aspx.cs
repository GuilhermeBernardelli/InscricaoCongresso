using InscricaoCongresso.Control;
using InscricaoCongresso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscricaoCongresso.View
{
    public partial class Principal : System.Web.UI.Page
    {
        public static bool novo = true;
        public static string idioma = "BR";
        public static string linhaDigitavel;
        Controle controle = new Controle();
        TRABALHOS trabalho = new TRABALHOS();
        AUTORES autor = new AUTORES();
        INSCRITOS inscricao = new INSCRITOS();
        ENDERECOS endereco = new ENDERECOS();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void chkTrabalho_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrabalho.Checked)
            {
                pnlTrabalho.Visible = true;
                pnlAdicionar.Visible = true;
            }
            else
            {
                pnlTrabalho.Visible = false;
                pnlAdicionar.Visible = false;
            }
        }
              
        protected void btnGerar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                controle.adicionarTrabalho(trabalho);
                novo = false;
            }
            trabalho.titulo = txtTituloTrabalho.Text;
            trabalho.resumo = txtTrabalhoResumo.Text;
            controle.atualizar();

            controle.adicionarAutor(autor);
            autor.idTrabalho = controle.idTrabalhoPorTitulo(txtTituloTrabalho.Text);
            autor.nomeAutor = txtNomeAutor.Text;
            autor.nomesMeioAutor = txtNomeMeioAutor.Text;
            autor.sobrenomeAutor = txtSobrenomeAutor.Text;

            gerarBoleto();

            controle.adicionarEndereco(endereco);
            endereco.nomeEndereco = ;
            endereco.numeroEndereco = ;

            controle.atualizar();
            controle.adicionarInscricao(inscricao);
            
            controle.atualizar();
            //chama a renderização do código de barras a partir do parametro de inscrição
            Session["boleto"] = inscricao.id;
            Response.Redirect("boleto.aspx");
            
        }

        private void gerarBoleto()
        {
            
        }

        protected void btnPortugues_Click(object sender, ImageClickEventArgs e)
        {
            idioma = "BR";

            lblCpf.Text = "CPF : ";
            lblIdioma.Text = "Idiomas : ";
            lblNascimento.Text = "Data de nascimento : ";
            lblNacionalidade.Text = "Nacionalidade : ";
            lblNome.Text = "Nome : ";
            lblRgRne.Text = "RG/RNE : ";
            lblTitulo.Text = "REALIZAR INSCRIÇÃO";
            lblTrabalho.Text = "Irá apresentar trabalho acadêmico?";
            lblAutorNome.Text = "Nome : ";
            lblAutorNomeMeio.Text = "Nome do meio : ";
            lblAutorSobrenome.Text = "Sobrenome : ";
            lblListaAutores.Text = "Autores associados : ";
            lblNomeTrabalho.Text = "Titulo do trabalho: ";
            lblResumo.Text = "Resumo : ";
            lblSituacaoFormacao.Text = "Situação atual dos estudos : ";
            lblLocalTrabalho.Text = "Local de trabalho/estudo : ";
            lblArea.Text = "Área profissional : ";
                        
            pnlForm.GroupingText = "Dados pessoais";
            pnlAutores.GroupingText = "Autor(es)";
            pnlTrabalho.GroupingText = "Trabalho acadêmico";
            pnlProfissional.GroupingText = "Dados profissionais/acadêmicos";

            btnAdicionar.Text = "(+) Outro autor";
            btnGerar.Text = "Gerar Boleto de Pagamento";

            chkTrabalho.Text = "Sim";

        }

        protected void btnIngles_Click(object sender, ImageClickEventArgs e)
        {
            idioma = "EN";

            lblCpf.Text = "Passport : ";
            lblIdioma.Text = "Languages : ";
            lblNascimento.Text = "Born date : ";
            lblNacionalidade.Text = "Nationality : ";
            lblNome.Text = "Name : ";
            lblRgRne.Text = "ID Num. : ";
            lblTitulo.Text = "ENTRY REGISTRATION";
            lblTrabalho.Text = "Will you show academic work?";
            lblAutorNome.Text = "Given name : ";
            lblAutorNomeMeio.Text = "Middle name : ";
            lblAutorSobrenome.Text = "Surname : ";
            lblListaAutores.Text = "Associated authors : ";
            lblNomeTrabalho.Text = "Work name : ";
            lblResumo.Text = "Resume : ";
            lblSituacaoFormacao.Text = "Current situation of the studies : ";
            lblLocalTrabalho.Text = "Work/Study place : ";
            lblArea.Text = "Professional area : ";
            
            pnlForm.GroupingText = "Personal data";
            pnlAutores.GroupingText = "Author(s)";
            pnlTrabalho.GroupingText = "Academic work";
            pnlProfissional.GroupingText = "Professional/Academic datas";

            btnGerar.Text = "Generate Payment Ticket";            
            btnAdicionar.Text = "(+) Other author";

            chkTrabalho.Text = "Yes";

        }

        protected void btnEspanol_Click(object sender, ImageClickEventArgs e)
        {
            idioma = "ES";

            lblCpf.Text = "Pasaporte : ";
            lblIdioma.Text = "Lenguas : ";
            lblNascimento.Text = "Fecha de nacimiento : ";
            lblNacionalidade.Text = "Nacionalidad : ";
            lblNome.Text = "Nombre : ";
            lblRgRne.Text = "Indentidad : ";
            lblTitulo.Text = "REALIZAR EL REGISTRO";
            lblTrabalho.Text = "Presentará trabajo académico?";
            lblAutorNome.Text = "Nombre : ";
            lblAutorNomeMeio.Text = "Segundo nombre : ";
            lblAutorSobrenome.Text = "Apellido : ";
            lblListaAutores.Text = "Autores asociados : ";
            lblNomeTrabalho.Text = "Titulo del trabajo: ";
            lblResumo.Text = "El resumen : ";
            lblSituacaoFormacao.Text = "Situación actual de los estudios : ";
            lblLocalTrabalho.Text = "Lugar de trabajo/estudio : ";
            lblArea.Text = "Área profesional : ";

            pnlForm.GroupingText = "Datos personales";
            pnlAutores.GroupingText = "Autor(es)";
            pnlTrabalho.GroupingText = "Trabajo académico";
            pnlProfissional.GroupingText = "Datos profesionales/académicos";

            btnAdicionar.Text = "(+) Otro autor";
            btnGerar.Text = "Generar el pago de Boleto";

            chkTrabalho.Text = "Sí";

        }
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (novo)
            {
                controle.adicionarTrabalho(trabalho);
                novo = false;
            }
            trabalho.titulo = txtTituloTrabalho.Text;
            trabalho.resumo = txtTrabalhoResumo.Text;
            controle.atualizar();

            controle.adicionarAutor(autor);
            autor.idTrabalho = controle.idTrabalhoPorTitulo(txtTituloTrabalho.Text);
            autor.nomeAutor = txtNomeAutor.Text;
            autor.nomesMeioAutor = txtNomeMeioAutor.Text;
            autor.sobrenomeAutor = txtSobrenomeAutor.Text;
            
            pnlAutor.Controls.Remove(lblAutorSobrenome);
            pnlAutor.Controls.Remove(txtSobrenomeAutor);
            pnlAutor.Controls.Remove(lblAutorNome);
            pnlAutor.Controls.Remove(txtNomeAutor);
            pnlAutor.Controls.Remove(lblAutorNomeMeio);
            pnlAutor.Controls.Remove(txtNomeMeioAutor);

            functionNovoAutor();
            txtTrabalhoAutores.Controls.Add(new LiteralControl("\n"));
            txtTrabalhoAutores.Text = txtTrabalhoAutores.Text + txtSobrenomeAutor.Text + ", " + txtNomeAutor.Text + " " + txtNomeMeioAutor.Text;

        }

        public void functionNovoAutor()
        {
            
            Label lblAutorSobrenome = new Label();
            if (idioma.Equals("BR"))
            {
                lblAutorSobrenome.Text = "Sobrenome : ";
            }
            else if (idioma.Equals("EN"))
            {
                lblAutorSobrenome.Text = "Surname : ";
            }
            else if (idioma.Equals("ES"))
            {
                lblAutorSobrenome.Text = "Apellido : ";
            }
            pnlAutor.Controls.Add(lblAutorSobrenome);            
            TextBox txtSobrenomeAutor = new TextBox()
            {
                Width = 156
            };
            pnlAutor.Controls.Add(txtSobrenomeAutor);
            pnlAutor.Controls.Add(new LiteralControl ("&nbsp;&nbsp;"));

            Label lblAutorNome = new Label();
            if (idioma.Equals("BR"))
            {
                lblAutorNome.Text = "Nome : ";
            }
            else if (idioma.Equals("EN"))
            {
                lblAutorNome.Text = "Given name : ";
            }
            else if (idioma.Equals("ES"))
            {
                lblAutorNome.Text = "Nombre : ";
            }
            pnlAutor.Controls.Add(lblAutorNome);
            pnlAutor.Controls.Add(new LiteralControl("&nbsp;"));
            TextBox txtNomeAutor = new TextBox()
            {
                Width = 156
            };
            pnlAutor.Controls.Add(txtNomeAutor);
            pnlAutor.Controls.Add(new LiteralControl("&nbsp;"));

            Label lblAutorNomeMeio = new Label()
            {
                Width = 121
            };
            if (idioma.Equals("BR"))
            {
                lblAutorNomeMeio.Text = "Nome do meio : ";
            }
            else if (idioma.Equals("EN"))
            {
                lblAutorNomeMeio.Text = "Middle name : ";
            }
            else if (idioma.Equals("ES"))
            {
                lblAutorNomeMeio.Text = "Segundo Nombre : ";
            }
            pnlAutor.Controls.Add(lblAutorNomeMeio);
            pnlAutor.Controls.Add(new LiteralControl("&nbsp;"));
            TextBox txtNomeMeioAutor = new TextBox()
            {
                Width = 156
            };
            pnlAutor.Controls.Add(txtNomeMeioAutor);
        }

        
    }
}