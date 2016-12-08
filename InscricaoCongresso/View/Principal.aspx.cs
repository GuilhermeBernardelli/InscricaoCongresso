﻿using InscricaoCongresso.Control;
using InscricaoCongresso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;

namespace InscricaoCongresso.View
{
    public partial class Principal : System.Web.UI.Page
    {
        /*
         * BLOCO DE VARIAVEIS DE MANUTENÇÃO
         * fazem parte das regras de negócio e devem ser atualizadas conforme a necessidade
         */

        //variaveis que devem ser alteradas para conter a faixa de valores válidos para o nosso número
        //variável inicio somente é utilizada na ausencia de outros boletos na base de dados, logo, será alterada unicamente antes desta execução
        public static int inicioNossoNum = 1;
        //variável fim da faixa está intimamente ligada ao alerta da faixa e deverá sofrer atualização caso haja adição de nova faixa de valores
        public static int fimNossoNum = 1000;
        //inteiro para definir faltando quantos números para estourar a faixa será disparado um email 
        //solicitando nova faixa de valores para o nosso número
        public int alertaFaixa = 10;

        /*
         * BLOCO DE VARIAVEIS DE COMUNICAÇÃO
         * dados referentes a saída de email's do sistema e dados do destino destes email's
         */

        //aqui deverá ser incluso um cliente smtp + porta de email, um email válido e a senha deste email
        public static string clienteSmtp = "smtp.notes.na.collabserv.com";
        public static int port = 25;
        public static string emailEmissor = "XXXXXXX@iamspe.sp.gov.br";
        public static string password = "Senha do emissor";
        //incluir aqui o email do responsável por manter o sistema e resolver problemas
        public static string emailReceptor = "guilhermeprezia@iamspe.sp.gov.br";
        
        /*
         * BLOCO DE VARIAVEIS DO SISTEMA
         * fazem parte do funcionamento do core e não devem sofrer alteração 
         */

        //variaveis boleanas para identificar inclusão de cadastro ou endereço pré-existente
        public static bool novo = true;
        public static bool novoEndereco = true;
        //variaveis tipo texto que armazenam respectivamente o idioma, o digito geral de 
        //verificação do código de barras e da linha digitavel do boleto e a própria linha digitavel
        public static string idioma = "BR", dac = "", linhaDigitavel;
        //data utilizada como padrão nos boletos para gerar o fator de vencimento
        public static DateTime dataBase = new DateTime(1997, 10, 07);
        // a configuração da data de vencimento deve ser incluida aqui no formato AAAA, MM, dddd
        public static DateTime vencimento = new DateTime(2017, 07, 01);
        //variaveis numéricas inteiras para armazenar respectivamente o nosso número e o número do documento do boleto
        public static int nossoNum, numDocumento;
        //chamada da classe de controle e dos tipos gerados para armazenamento na base de dados
        Controle controle = new Controle();
        TRABALHOS trabalho = new TRABALHOS();
        AUTORES autor = new AUTORES();
        INSCRITOS inscricao = new INSCRITOS();
        ENDERECOS endereco = new ENDERECOS();
        static BOLETOS boleto = new BOLETOS();
        //Arrays de obejtos da base de dados
        List<AUTORES> autoresTrabalho = new List<AUTORES>();
        static List<ESTADOS> estados = new List<ESTADOS>();
        static List<PAISES> paises = new List<PAISES>();
        static List<CIDADES> cidades = new List<CIDADES>();
        static List<LOGRADOUROS> logradouros = new List<LOGRADOUROS>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //declaração de contador para atribuição dinamica do indice dos objetos adicionados as 
            //drop down lists alimentadas pela base já no load da aplicação
            int count;
            //rotina executada no primeiro load da página
            if (!IsPostBack)
            {                                
                //na ausencia de valores na tabela boleto o sistema entende que deve assumir o primeiro valor da faixa
                if (controle.pesquisaBoletoAtualNum() == 0)
                {
                    numDocumento = nossoNum = inicioNossoNum;
                }
                //verifica se os valores ainda estão dentro do limitado pela faixa
                else if (controle.pesquisaBoletoAtualNum() >= fimNossoNum)
                {
                    string alertMessage1 = "";
                    if (idioma.Equals("BR"))
                    {
                        alertMessage1 = "Houve algum problema na geração do boleto, Um e-mail foi enviado para resolver o problema, tente novamente mais tarde";
                    }
                    else if (idioma.Equals("ES"))
                    {
                        alertMessage1 = "Hubo un problema en la generación del boleto, Un correo electrónico fue enviado a resolver el problema, por favor intente de nuevo más tarde";
                    }
                    else if (idioma.Equals("EN"))
                    {
                        alertMessage1 = "There was a problem with payment ticket generation, an email was sent to solve the issue, please try again later";
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage1 + "')", true);


                    //cria uma mensagem
                    MailMessage mail = new MailMessage();

                    //define os endereços
                    mail.From = new MailAddress(emailEmissor);
                    mail.To.Add(emailReceptor);

                    //define o conteúdo
                    mail.Subject = "Ultrapassada faixa nosso número";
                    mail.Body = "Houve o estouro da faixa de valores disponíveis para o nosso números.\n Favor solicitar junto ao banco por remessa nova faixa\n"
                         + "Ao faze-lo atualize a variável fimNossoNum deste sistema.\n\n\nObrigado, atenciosamente.\n\n  Sistema de cadastro, inscrição e pagamento";

                    SmtpClient smtp = new SmtpClient(clienteSmtp, port);
                    smtp.EnableSsl = true;
                    NetworkCredential cred = new NetworkCredential(emailEmissor, password);
                    smtp.Credentials = cred;

                    // inclui as credenciais
                    smtp.UseDefaultCredentials = true;
                    //envia a mensagem
                    smtp.Send(mail);
                }
                //caso o nosso número esteja dentro da faixa inicia a rotina a seguir
                else
                {
                    //Atribui o valor seguinte ao atual ao numero do documento e ao nosso número 
                    numDocumento = nossoNum = controle.pesquisaBoletoAtualNum() + 1;
                }
                //valida se o limite de nosso número atingiu o valor definido para alerta
                if(nossoNum + alertaFaixa >= fimNossoNum)
                {
                    //caso o valor atinja o ponto critico a cada novo boleto será disparado novo email
                    //cria uma mensagem
                    MailMessage mail = new MailMessage();

                    //define os endereços
                    mail.From = new MailAddress(emailEmissor);
                    mail.To.Add(emailReceptor);

                    //define o conteúdo
                    mail.Subject = "Ultrapassada quantidade estipulada para alerta";
                    mail.Body = "Atualmente o sistema esta à "+ (fimNossoNum - nossoNum) + " valores de estourar.\n" 
                        + "Verifique a possibilidade de enviar remessa solicitando nova faixa de boletos.\n" 
                        + "Ao faze-lo atualize a variável fimNossoNum deste sistema.\n\n\nObrigado, atenciosamente.\n\n  Sistema de cadastro, inscrição e pagamento";

                    SmtpClient smtp = new SmtpClient(clienteSmtp, port);
                    smtp.EnableSsl = true;
                    NetworkCredential cred = new NetworkCredential(emailEmissor, password);
                    smtp.Credentials = cred;

                    // inclui as credenciais
                    smtp.UseDefaultCredentials = true;
                    //envia a mensagem
                    smtp.Send(mail);
                }

                //pesquisa pelos tipos  de logradouros cadastrados na tabela LOGRADOUROS da base de dados
                logradouros = controle.pesquisaLogradouros();
                
                //reinicia o contador de indice
                //count = 1;

                //adiciona o primeiro item estático ao indice na posição 0
                ddlLogradouro.TabIndex.Equals(0);
                ddlLogradouro.Items.Add("-------");
                //interação condicionada a quantidade de elementos retornados na pesquisa anterior
                foreach (LOGRADOUROS value in logradouros)
                {
                    //atribui o indice do elemento e o valor do objeto composta pela sigla, - e descrição do tipo de logradouro

                    //ddlLogradouro.TabIndex.Equals(count);

                    ddlLogradouro.Items.Add(value.siglaLogradouro + " - " + value.descLogradouro);
                    
                    //incrementa o indice
                    //count++;
                }
                //pesquisa na base pelos estados cadastrados
                estados = controle.pesquisaEstados();
                
                //reinicia o contador de indice
                //count = 1;
                
                //adiciona o primeiro item estático ao indice na posição 0
                ddlEstado.TabIndex.Equals(0);
                ddlEstado.Items.Add("-------");
                //interação condicionada a quantidade de elementos retornados na pesquisa anterior
                foreach (ESTADOS value in estados)
                {
                    //retira o valor padrão para estrangeiros da lista
                    if (value.id != 1)
                    {
                        //atribui o indice do elemento e o valor do objeto composta pela sigla, - e nome do estado
                        //ddlEstado.TabIndex.Equals(count);

                        ddlEstado.Items.Add(value.siglaEstado + " - " + value.nomeEstado);
                        
                        //incrementa o indice
                        //count++;
                    }
                }
                //pesquisa pelos estados cadastrados
                paises = controle.pesquisaPaises();
                
                //reinicia o contador
                //count = 1;
                
                //adiciona o primeiro item estático ao indice na posição 0
                ddlPaises.TabIndex.Equals(0);
                ddlPaises.Items.Add("-------");
                //interação condicionada a quantidade de elementos retornados na pesquisa anterior
                foreach (PAISES value in paises)
                {
                    if (!value.siglaPais.Equals("BRA"))
                    {
                        //atribui o indice do elemento e o valor do objeto composta pela sigla, - e nome do país
                        //ddlPaises.TabIndex.Equals(count);

                        ddlPaises.Items.Add(value.siglaPais + " - " + value.nomePais);
                        
                        //incrementa o indice
                        //count++;
                    }
                }
            }           

        }

        //altera a visualização de acordo com o estado do checkbox que indica a apresentação de trabalho academico no evento
        protected void chkTrabalho_CheckedChanged(object sender, EventArgs e)
        {
            //caso o checkbox seja marcado
            if (chkTrabalho.Checked)
            {
                pnlTrabalho.Visible = true;
                pnlAdicionar.Visible = true;
            }
            //caso o checkbox seja desmarcado
            else
            {
                pnlTrabalho.Visible = false;
                pnlAdicionar.Visible = false;
            }
        }

        //função responsável por armazenar e gerar os dados do boleto para renderização
        private void gerarBoleto()
        {
            try
            {
                //cria uma nova instancia do objeto boleto
                boleto = new BOLETOS();
                //salva na base esta instancia
                controle.adicionarBoleto(boleto);

                //atribui as chaves estrangeiras correspondentes ao sacado, cedente e valor, respectivamente
                boleto.idInscritos = controle.pesquisaInscritos(txtCPF.Text).id;
                boleto.idCedente = 1;
                boleto.idValor = 1;

                //rotinas para tratamento dos campos de data de emissão e vencimento
                string formatedEmissao = DateTime.Today.ToString("dd/MM/yyyy");
                boleto.dataEmissao = formatedEmissao;
                string formatedVencimento = vencimento.ToString("dd/MM/yyyy");
                boleto.dataVencimento = formatedVencimento;

                //preenchimento de campos estáticos padrão
                boleto.localPagamento = "QUALQUER BANCO ATÉ O VENCIMENTO";
                boleto.especieDocumento = "R$";

                //Campo de informações a critério do cedente cada linha está limitada a 100 caracteres, 
                //sendo que cada linha corresponde a uma unica linha também no boleto
                boleto.informacoesL1 = "";
                boleto.informacoesL2 = "";
                boleto.informacoesL3 = "";
                boleto.informacoesL4 = "";
                boleto.informacoesL5 = "";
                boleto.informacoesL6 = "";
                boleto.informacoesL7 = "";
                boleto.informacoesL8 = "";
                boleto.informacoesL9 = "";
                boleto.informacoesL10 = "";

                //atribuido o valor das variáveis tratadas no inicio da aplicação
                boleto.nossoNumero = nossoNum;
                boleto.numeroDocumento = numDocumento;

                //chamada dos métudos que geram o códgo de barras e a linha digitável de acordo com os dados da base
                boleto.codigoBarras = geraCodigoBarras();
                boleto.linhaDigitavel = geraLinhaDigitavel();

                //associação entre os valores do boleto e variaveis de sessão para serem passadas como parametro para a próxima página
                Session["pagador"] = boleto.idInscritos;
                Session["boleto"] = boleto.linhaDigitavel;
                Session["codBarras"] = boleto.codigoBarras;

                //salva as alterações no boleto na base de dados
                controle.atualizar();

                //chama a página de renderização do boleto
                Response.Redirect("Boleto.aspx");
            }
            //na impossibilidade de gerar o boleto por qualquer exceção haverá a chamada das instruções a seguir
            catch
            {
                //define a mensagem como vazia
                string alertMessage1 = "";
                //indentifica o idioma da mensagem e altera de acordo com este
                if (idioma.Equals("BR"))
                {
                    alertMessage1 = "Houve algum problema na geração do boleto, envie um email para "+ emailReceptor;
                }
                else if (idioma.Equals("ES"))
                {
                    alertMessage1 = "Hubo un problema en la generación del boleto, envía un correo electrónico a "+ emailReceptor;
                }
                else if (idioma.Equals("EN"))
                {
                    alertMessage1 = "There was a problem with payment ticket generation, send an email to " + emailReceptor;
                }
                //envia em um box de alerta para o usuário a mensagem no idioma correspondente
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage1 + "')", true);
            }
        }

        //função que gera a string que representa o código de barras a ser renderizado
        private string geraCodigoBarras()
        {
            //inclusão do código do banco na primeira sessão do codigo de barras
            string codBarraP1 = "", codBarraP2 = "", codAux = "";

            CEDENTES cedente = controle.pesquisaCedente("IAMSPE");
            //copia em um vetor de caracteres os 3 primeiros caracteres referentes ao código do banco 
            CONTAS contaCedente = controle.pesquisaContaPorId(cedente.idConta);
            char[] codigobanco = contaCedente.codigoBanco.ToCharArray();
            //adiciona a string esses 3 caracteres nas primeiras posições
            for (int i = 0; i < 3; i++)
            {
                codBarraP1 = codBarraP1 + codigobanco[i].ToString();
            }
            //adiciona ao código de barras, na posição 4, o código da moeda corrente, 9 = real
            //conclui a parte 1 do código de barras, esta na composição final ficará anterior ao digito de verificação geral o DAC
            codBarraP1 = codBarraP1 + "9";
            //devolve o calculo em dias da diferença entre vencimento e database, este resultado é o fator de vencimento
            TimeSpan dias = vencimento - dataBase;
            //formata o valor a ser pago alterando ele para uma string com 10 digitos
            VALORES valorBoleto = controle.pesquisaValorPorId(1);
            // a função formata valor recebe como parametros um inteiro que representa o tamanho do retorno e uma string de entrada a sofrer alteração
            //tem como parametro de saída uma nova string
            string valor10Digitos = formataValor(10, (valorBoleto.valor).ToString());
            //formata o numero do codigo cedente            
            string nossoNum13Digitos = formataValor(13, nossoNum.ToString());
            //concatena diversas saídas para criar a parte 2 do código de barras, esta é, na composição final, posterior ao digito verificador geral o DAC
            codBarraP2 = (dias.Days).ToString() + valor10Digitos + "9" + cedente.codigoCedente + nossoNum13Digitos + "0" + contaCedente.carteira.ToString();
            //concatena em uma variavel auxiliar a parte 1 e 2 do código de barras
            codAux = codBarraP1 + codBarraP2;
            //envia à função de calculo do DAC esta string auxiliar, o retorno desta é unicamente um caracter, string, que representa um número de 0 à 9, o DAC
            dac = calculoModulo11(codAux);
            //cria a string referente ao código de barras, composta pela parte 1, digito verificador e parte 2
            string codBarra = codBarraP1 + dac + codBarraP2;
            //retorna esta string
            return codBarra;
        }
        //função para formatação de strings, recebe como parametros uma string numérica e adiciona 0 a frente dela até um tamanho definido pelo usuário
        private string formataValor(int tamanho, string valorEntrada)
        {
            //instancia a string de saída com vazio
            string valorFormatado = "";
            //cria um array de caracteres com tamanho igual ao parametro passado pela função
            char[] valor = new char[tamanho];
            //cria um contador inteiro igual a tamanho - 1
            int count = tamanho - 1;
            //atribui um contador de virgulas iniciado em 0, pela lógica empregada no sistema as virgulas deverão ser desprezadas
            int virgulas = 0;
            //cria e instancia um array de caracteres com o parametro passado pela função
            char[] aux = valorEntrada.ToCharArray();

            //percorre o vetor aux do último ao primeiro elemento
            for (int i = aux.Count() - 1; i >= 0; i--)
            {
                //verifica se o valor do vetor não é uma virgula
                if (!aux[i].Equals(','))
                {
                    //não sendo uma virgula, atribui ao vetor valor e decrementa o contador do tamanho
                    valor[count--] = aux[i];
                }
                //se o valor for uma virgula incrementa o contador de virgulas
                else
                {
                    virgulas++;
                }
            }
            //percorre o vetor valor da posição do contador de tamanho somado as virguals subtraidas do tamanho total preenchendo-o com 0s
            for (int i = 0; i < ((tamanho + virgulas) - aux.Count()); i++)
            {
                valor[count--] = '0';
            }
            //converte o vetor em string novamente e atribui o valor ao retorno                       
            for (int i = 0; i < tamanho; i++)
            {
                valorFormatado = valorFormatado + valor[i].ToString();
            }
            //retorna o valor formatado
            return valorFormatado;
        }

        private string geraLinhaDigitavel()
        {
            //inclusão do código do banco na primeira sessão da linha digitável
            string linhaDigitavelP1 = "";

            CEDENTES cedente = controle.pesquisaCedente("IAMSPE");
            CONTAS conta = controle.pesquisaContaPorId(cedente.idConta);
            VALORES valorBoleto = controle.pesquisaValorPorId(1);
            //copia em um vetor de caracteres os 3 primeiros caracteres referentes ao código do banco 
            char[] codigobanco = (conta.codigoBanco).ToCharArray();
            //adiciona a string linha digitavel esses 3 caracteres nas primeiras posições
            for (int i = 0; i < 3; i++)
            {
                linhaDigitavelP1 = linhaDigitavelP1 + codigobanco[i].ToString();
            }
            //adiciona a linha digitavel, na posição 4, o código da moeda corrente, 9 = real e o campo fixo = 9
            linhaDigitavelP1 = linhaDigitavelP1 + "99";

            //copia em um vetor de caracteres os caracteres referentes a conta do beneficiário
            char[] codCedente = (cedente.codigoCedente).ToCharArray();
            //adiciona a string linha digitavel os primeiros 4 caracteres da conta do beneficiário
            for (int i = 0; i < 4; i++)
            {
                linhaDigitavelP1 = linhaDigitavelP1 + codCedente[i].ToString();
            }

            string div1 = calculoModulo10(linhaDigitavelP1);

            string linhaDigitavelP2 = "";
            //adiciona a string linha digitavel esses 3 últimos caracteres restantes
            for (int i = 4; i < 7; i++)
            {
                linhaDigitavelP2 = linhaDigitavelP2 + codCedente[i].ToString();
            }
            string nossoNum13Digitos = formataValor(13, nossoNum.ToString());
            //copia em um vetor de caracteres os caracteres referentes ao nosso numero
            char[] nossoNumArray = nossoNum13Digitos.ToCharArray();

            //adiciona a string linha digitavel os primeiros 7 caracteres do nosso numero
            for (int i = 0; i < 7; i++)
            {
                linhaDigitavelP2 = linhaDigitavelP2 + nossoNumArray[i].ToString();
            }

            string div2 = calculoModulo10(linhaDigitavelP2);

            string linhaDigitavelP3 = "";
            for (int i = 7; i < 13; i++)
            {
                linhaDigitavelP3 = linhaDigitavelP3 + nossoNumArray[i].ToString();
            }
            linhaDigitavelP3 = linhaDigitavelP3 + "0" + (cedente.CONTAS.carteira).ToString();

            string div3 = calculoModulo10(linhaDigitavelP3);

            string valorBoleto10Digitos = formataValor(10, (valorBoleto.valor).ToString());
            TimeSpan dias = vencimento - dataBase;

            string linhaDigitavelP4 = (dias.Days).ToString() + valorBoleto10Digitos;

            //instancia final da linha digitavel
            string linhaDigitavel = linhaDigitavelP1 + div1 + linhaDigitavelP2 + div2 + linhaDigitavelP3 + div3 + dac + linhaDigitavelP4;
            return linhaDigitavel;
        }

        private string calculoModulo10(string valor)
        {
            string digito = "";

            int calculo = 0, count = 2;
            char[] aux = valor.ToCharArray();
            for (int i = aux.Count() - 1; i >= 0; i--)
            {
                if (count % 2 == 0)
                {
                    count--;
                    int auxValue = Convert.ToInt32(aux[i].ToString()) * 2;
                    if (auxValue >= 10)
                    {
                        auxValue = auxValue - 9;
                    }
                    calculo = calculo + auxValue;
                }
                else
                {
                    count++;
                    calculo = calculo + Convert.ToInt32(aux[i].ToString());
                }
            }
            int divisao;
            divisao = calculo / 10;
            calculo = calculo - (divisao * 10);
            digito = (10 - calculo).ToString();
            return digito;
        }

        private string calculoModulo11(string Numero)
        {
            string digitoVerificador = "";
            char[] Num = Numero.ToCharArray();
            int calculo = 0, count = 0;
            for (int i = Num.Count() - 1; i >= 0; i--)
            {
                calculo = calculo + (Convert.ToInt32(Num[i].ToString()) * (count + 2));
                count++;
                if (count > 7)
                {
                    count = 0;
                }
            }
            int divisao;
            calculo = calculo * 10;
            divisao = calculo / 11;
            calculo = calculo - (divisao * 11);
            if (calculo == 1 || calculo == 0)
            {
                digitoVerificador = "1";
            }
            else
            {
                digitoVerificador = (11 - calculo).ToString();
            }
            return digitoVerificador;
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
            lblComplemento.Text = "Complemento : ";
            lblBairro.Text = "Bairro : ";
            lblCep.Text = "CEP : ";
            lblEndereco.Text = "Endereço : ";
            lblNumeral.Text = "Número : ";
            lblPaises.Text = "Selecione o País : ";
            lblCidade.Text = "Cidade : ";
            lblUF.Text = "UF : ";

            pnlForm.GroupingText = "Dados pessoais";
            pnlAutores.GroupingText = "Autor(es)";
            pnlTrabalho.GroupingText = "Trabalho acadêmico";
            pnlProfissional.GroupingText = "Dados profissionais/acadêmicos";
            pnlEndereco.GroupingText = "Dados de endereço";

            btnAdicionar.Text = "(+) Outro autor";
            btnGerar.Text = "Gerar Boleto de Pagamento";

            chkTrabalho.Text = "Sim";
            chkEstrangeiro.Text = "Residente no exterior";

            lblTelefone1.Text = "Telefone principal : ";
            lblTelefone2.Text = "Telefone secundário : ";
            lblCelular.Text = "Celular : ";
            lblAviso.Text = "Para 2ª via, preencher o campo CPF e clicar no botão \"Gerar Boleto de Pagamento\"";
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
            lblResumo.Text = "Abstract : ";
            lblSituacaoFormacao.Text = "Current situation of the studies : ";
            lblLocalTrabalho.Text = "Work/Study place : ";
            lblArea.Text = "Professional area : ";
            lblBairro.Text = "Neighborhood : ";
            lblCep.Text = "Zip code : ";
            lblEndereco.Text = "Address : ";
            lblNumeral.Text = "Number : ";
            lblPaises.Text = "Select your Country : ";
            lblCidade.Text = "City : ";
            lblUF.Text = "State : ";
            lblComplemento.Text = "Complement : ";

            pnlForm.GroupingText = "Personal data";
            pnlAutores.GroupingText = "Author(s)";
            pnlTrabalho.GroupingText = "Academic work";
            pnlProfissional.GroupingText = "Professional/Academic data";
            pnlEndereco.GroupingText = "Address data";

            btnGerar.Text = "Generate Payment Ticket";
            btnAdicionar.Text = "(+) Other author";

            chkTrabalho.Text = "Yes";
            chkEstrangeiro.Text = "Lives outside of Brazil";

            lblTelefone1.Text = "Main phone : ";
            lblTelefone2.Text = "Secondary phone : ";
            lblCelular.Text = "Cell phone : ";
            lblAviso.Text = "For 2nd way, fill in the Passport field and click on the button \"Generate Payment Ticket\"";

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
            lblBairro.Text = "Barrio : ";
            lblCep.Text = "Código postal : ";
            lblEndereco.Text = "Dirección : ";
            lblNumeral.Text = "Número : ";
            lblPaises.Text = "Seleccionar el País : ";
            lblCidade.Text = "Ciudad : ";
            lblUF.Text = "Estado : ";
            lblComplemento.Text = "Complemento : ";

            pnlForm.GroupingText = "Datos personales";
            pnlAutores.GroupingText = "Autor(es)";
            pnlTrabalho.GroupingText = "Trabajo académico";
            pnlProfissional.GroupingText = "Datos profesionales/académicos";
            pnlEndereco.GroupingText = "Datos de dirección";

            btnAdicionar.Text = "(+) Otro autor";
            btnGerar.Text = "Generar el pago de Boleto";

            chkTrabalho.Text = "Sí";
            chkEstrangeiro.Text = "Vive fuera de Brasil";


            lblTelefone1.Text = "Teléfono principal : ";
            lblTelefone2.Text = "Teléfono secundário : ";
            lblCelular.Text = "Celular : ";
            lblAviso.Text = "Para la segunda vía, complete el campo Pasaporte y haga clic en el botón \"Generar el Pago de Boleto\"";

        }
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            //Aviso geral realizado na inclusão de autores
            string alertMessage = "";
            if (idioma.Equals("BR"))
            {
                alertMessage = "AVISO: Todos os autores que desejem estar presentes no evento deverão realizar e efetuar o pagamento de suas incrições individuais";
            }
            else if (idioma.Equals("ES"))
            {
                alertMessage = "ADVERTENCIA: Todos los autores que deseen asistir al evento deben realizar y efectuar el pago de sus registros individuales";
            }
            else if (idioma.Equals("EN"))
            {
                alertMessage = "WARNING: All authors wishing to be present at the event must make and pay their individual registration";
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage + "')", true);


            if (txtTituloTrabalho.Text.Equals("") || txtTrabalhoResumo.Text.Equals(""))
            {
                string alertMessage1 = "";
                if (idioma.Equals("BR"))
                {
                    alertMessage1 = "Antes do cadastro de autores é necessário o preenchimento do titulo e resumo";
                }
                else if (idioma.Equals("ES"))
                {
                    alertMessage1 = "Antes de que el registro de los autores, se requiere el título y el resumen";
                }
                else if (idioma.Equals("EN"))
                {
                    alertMessage1 = "Before registering authors it is necessary to fill in the title and abstract";
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage1 + "')", true);
            }
            else if (novo)
            {
                if (controle.idTrabalhoPorTitulo(txtTituloTrabalho.Text.ToUpper()) == 0)
                {
                    controle.adicionarTrabalho(trabalho);
                    trabalho.titulo = txtTituloTrabalho.Text.ToUpper();
                    trabalho.resumo = txtTrabalhoResumo.Text.ToUpper();
                    novo = false;
                    txtTrabalhoAutores.Text = txtSobrenomeAutor.Text.ToUpper() + ", " + txtNomeAutor.Text.ToUpper() + " " + txtNomeMeioAutor.Text.ToUpper();
                }
                else
                {
                    string alertMessage2 = "";
                    if (idioma.Equals("BR"))
                    {
                        alertMessage2 = "Já existe um trabalho com este titulo, cadastrado por outro usuário";
                    }
                    else if (idioma.Equals("ES"))
                    {
                        alertMessage2 = "Ya hay un trabajo con este título, publicado por otro usuario";
                    }
                    else if (idioma.Equals("EN"))
                    {
                        alertMessage2 = "Already exists a work with this title, included by another user";
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage2 + "')", true);
                }
            }
            else
            {
                txtTrabalhoAutores.Text = "";

                txtTituloTrabalho.Enabled = false;
                txtTrabalhoResumo.Enabled = false;

                controle.adicionarAutor(autor);
                autor.idTrabalho = controle.idTrabalhoPorTitulo(txtTituloTrabalho.Text.ToUpper());
                int ID = Convert.ToInt32(autor.idTrabalho);
                autor.nomeAutor = txtNomeAutor.Text.ToUpper();
                autor.nomesMeioAutor = txtNomeMeioAutor.Text.ToUpper();
                autor.sobrenomeAutor = txtSobrenomeAutor.Text.ToUpper();
                controle.atualizar();

                pnlAutor.Controls.Remove(lblAutorSobrenome);
                pnlAutor.Controls.Remove(txtSobrenomeAutor);
                pnlAutor.Controls.Remove(lblAutorNome);
                pnlAutor.Controls.Remove(txtNomeAutor);
                pnlAutor.Controls.Remove(lblAutorNomeMeio);
                pnlAutor.Controls.Remove(txtNomeMeioAutor);

                functionNovoAutor();
                autoresTrabalho = controle.autoresIdtrabalho(ID);

                foreach (AUTORES value in autoresTrabalho)
                {
                    txtTrabalhoAutores.Text = txtTrabalhoAutores.Text + value.sobrenomeAutor + ", " + value.nomeAutor + " " + value.nomesMeioAutor + "\n";
                }
            }
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
            txtSobrenomeAutor = new TextBox()
            {
                ID = "txtSobrenomeAutor",
                Width = 156
            };
            pnlAutor.Controls.Add(txtSobrenomeAutor);
            pnlAutor.Controls.Add(new LiteralControl("&nbsp;&nbsp;"));

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
            txtNomeAutor = new TextBox()
            {
                ID = "txtNomeAutor",
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
            txtNomeMeioAutor = new TextBox()
            {
                ID = "txtNomeMeioAutor",
                Width = 156
            };
            pnlAutor.Controls.Add(txtNomeMeioAutor);
        }

        protected void btnGerar_Click(object sender, EventArgs e)
        {
            /*HttpBrowserCapabilities browser = Request.Browser;
            string s = browser.Browser;*/

            //verifica a existencia de cadastro do usuário
            if (controle.pesquisaInscritos(txtCPF.Text) != null)
            {
                //verifica a existencia de boleto caso o usuário já cadastrado
                boleto = controle.pesquisaBoletoUsuario(controle.pesquisaInscritos(txtCPF.Text).id);
                //caso não haja boleto para usuário já cadastrado 
                if (boleto == null)
                {
                    //gera o boleto para este usuário
                    gerarBoleto();
                }
                //havendo boleto cadastrado para este usuário atribui os valores devidos as variaveis de sessão 
                //e chama a renderização do boleto em tela
                else
                {
                    Session["pagador"] = boleto.idInscritos;
                    Session["boleto"] = boleto.linhaDigitavel;
                    Session["codBarras"] = boleto.codigoBarras;

                    Response.Redirect("Boleto.aspx");
                }

            }
            //Verifica se o usuário que esta gerando o boleto necessita do cadastro de trabalho para apresentação
            if (chkTrabalho.Checked)
            {
                //tenta adicionar um trabalho na base
                try
                {
                    //verifica se já foi feita a inclusão do trabalho na base
                    if (novo)
                    {
                        //cria novo trabalho
                        controle.adicionarTrabalho(trabalho);
                        //altera o status da variavel de verificação de inclusão de trabalho
                        novo = false;
                    }
                    //atualiza os valores do trabalho na base
                    trabalho.titulo = txtTituloTrabalho.Text.ToUpper();
                    trabalho.resumo = txtTrabalhoResumo.Text.ToUpper();
                    //salva esse trabalho na base de dados
                    controle.atualizar();
                }
                //resposta ao usuário na impossibilidade de adicionar um projeto na base
                catch
                {
                    string alertMessage1 = "";
                    //seleção da resposta para cada um dos idiomas utilizados pelo sistema
                    if (idioma.Equals("BR"))
                    {
                        alertMessage1 = "Houve um problema para salvar seu trabalho, entre em contato com os administradores";
                    }
                    else if (idioma.Equals("ES"))
                    {
                        alertMessage1 = "Hubo un problema al guardar su trabajo, contacta los administradores";
                    }
                    else if (idioma.Equals("EN"))
                    {
                        alertMessage1 = "There was a problem saving your work, contact the administrators";
                    }
                    //chamada de resposta em tela por pop up
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage1 + "')", true);
                }
                //tentativa de adicionar autor e associar ao trabalho salvo
                try
                {
                    //verifica o preenchimento obrigatório dos campos de sobrenome e nome do autor
                    if (txtSobrenomeAutor.Text.Equals("") || txtNomeAutor.Text.Equals(""))
                    {
                        //verifica a existencia de ao menos um autor no titulo do trabalho, entra nesta rotina caso não haja associação
                        if (controle.autoresIdtrabalho(controle.idTrabalhoPorTitulo(txtTituloTrabalho.Text)).Count == 0)
                        {
                            //string com a mensagem ao usuário e rotina para verificar idioma selecionado pelo usuário
                            string alertMessage2 = "";
                            if (idioma.Equals("BR"))
                            {
                                alertMessage2 = "Obrigatório associar o trabalho ao menos a um autor, preencha os campos sobrenome e nome";
                            }
                            else if (idioma.Equals("ES"))
                            {
                                alertMessage2 = "Es necesario asociar el trabajo a al menos un autor, rellene los campos de nombre y apellido";
                            }
                            else if (idioma.Equals("EN"))
                            {
                                alertMessage2 = "It is mandatory to associate the work with at least one author, fill the fields surname and given name";
                            }
                            //chamada de pop up com a mensagem de obrigatoriedade de associação entre autor e titulo
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage2 + "')", true);
                        }

                    }
                    //identificado que os campos de identificação de autor estão preenchidos segue a rotina abaixo
                    else
                    {
                        controle.adicionarAutor(autor);
                        autor.idTrabalho = controle.idTrabalhoPorTitulo(txtTituloTrabalho.Text);
                        autor.nomeAutor = txtNomeAutor.Text.ToUpper();
                        autor.nomesMeioAutor = txtNomeMeioAutor.Text.ToUpper();
                        autor.sobrenomeAutor = txtSobrenomeAutor.Text.ToUpper();
                        controle.atualizar();
                    }
                }
                catch
                {
                    string alertMessage2 = "";
                    if (idioma.Equals("BR"))
                    {
                        alertMessage2 = "Houve algum problema para associar este autor e salvar, por favor entre em contato com um administrador";
                    }
                    else if (idioma.Equals("ES"))
                    {
                        alertMessage2 = "Hubo un problema al asociar este autor y guardar, por favor, póngase en contacto con un administrador";
                    }
                    else if (idioma.Equals("EN"))
                    {
                        alertMessage2 = "There was a problem linking this author and saving, please contact an administrator";
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage2 + "')", true);
                }
            }

            //verifica se já existe valor de endereço associado ao usuário
            if (novoEndereco && (controle.pesquisaIdEndereco(txtEndereco.Text, txtNumeral.Text)) == null)
            {
                //Inicio da rotina de captura de endereço
                try
                {

                    if (chkEstrangeiro.Checked)
                    {
                        if (ddlPaises.SelectedIndex == 0)
                        {
                            string alertMessage2 = "";
                            if (idioma.Equals("BR"))
                            {
                                alertMessage2 = "Para residentes no exterior a seleção do país é obrigatória";
                            }
                            else if (idioma.Equals("ES"))
                            {
                                alertMessage2 = "Para los residentes en el extranjero la selección del país es obligatorio";
                            }
                            else if (idioma.Equals("EN"))
                            {
                                alertMessage2 = "For foreign residents the country selection is mandatory";
                            }
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage2 + "')", true);
                        }
                        else
                        {
                            controle.adicionarEndereco(endereco);
                            endereco.idLogradouro = 7;
                            endereco.nomeEndereco = (txtEndereco.Text + ", " + txtCidade.Text).ToUpper();
                            endereco.numeroEndereco = txtNumeral.Text;
                            endereco.complemento = txtComplemento.Text.ToUpper();
                            endereco.bairro = txtBairro.Text.ToUpper();
                            endereco.idPaises = ddlPaises.SelectedIndex;
                            endereco.idCidade = 1;
                            endereco.cep = txtCEP.Text;
                            controle.atualizar();
                            novoEndereco = false;
                        }
                    }
                    else
                    {

                        controle.adicionarEndereco(endereco);
                        endereco.idLogradouro = ddlLogradouro.SelectedIndex;
                        endereco.nomeEndereco = txtEndereco.Text.ToUpper();
                        endereco.numeroEndereco = txtNumeral.Text;
                        endereco.complemento = txtComplemento.Text.ToUpper();
                        endereco.bairro = txtBairro.Text.ToUpper();
                        endereco.idPaises = 1;
                        endereco.idCidade = ddlCidade.SelectedIndex + 1;
                        endereco.cep = txtCEP.Text;
                        if (ddlCidade.SelectedIndex == 0)
                        {
                            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('A seleção de cidade é obrigatória')", true);
                        }
                        else
                        {
                            controle.atualizar();
                            novoEndereco = false;
                        }
                    }
                }
                catch
                {
                    string alertMessage3 = "";
                    if (idioma.Equals("BR"))
                    {
                        alertMessage3 = "Houve algum problema para salvar os dados de endereço do usuário, todos os dados são obrigatórios";
                    }
                    else if (idioma.Equals("ES"))
                    {
                        alertMessage3 = "Hubo un problema al guardar los datos de dirección de usuario, Se requiere todos los datos";
                    }
                    else if (idioma.Equals("EN"))
                    {
                        alertMessage3 = "There was a problem saving user address data, All data is mandatory";
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage3 + "')", true);
                }
            }
            else
            {
                novoEndereco = false;
            }

            try
            {
                controle.adicionarInscricao(inscricao);
                //associa a inscrição ao endereço cadastrado, caso haja um
                if (!novoEndereco)
                {
                    inscricao.idEndereco = controle.pesquisaIdEndereco(txtEndereco.Text, txtNumeral.Text).id;
                }
                //associa a inscrição ao trabalho cadastrado, caso haja um
                if (!novo)
                {
                    inscricao.idTrabalho = controle.idTrabalhoPorTitulo(txtTituloTrabalho.Text);
                }

                inscricao.nome = txtNome.Text;
                inscricao.cpf = txtCPF.Text;
                inscricao.rg_rne = txtRG.Text;
                inscricao.nacionalidade = txtNacional.Text;
                inscricao.areaProfissional = txtArea.Text.ToUpper();
                inscricao.infoProfissional = txtLocal.Text.ToUpper();
                inscricao.situacaoAcademica = txtSituacao.Text.ToUpper();
                if (chkTrabalho.Checked)
                {
                    inscricao.palestrante = true;
                }
                else
                {
                    inscricao.palestrante = false;
                }
                inscricao.email = txtEmail.Text;
                inscricao.telefone1 = txtTelefone1.Text;
                inscricao.telefone2 = txtTelefone2.Text;
                inscricao.celular = txtCelular.Text;
                
                inscricao.dataNascimento = Convert.ToDateTime(txtNascimento.Text);
                controle.atualizar();
                gerarBoleto();

            }
            catch
            {
                string alertMessage4 = "";
                if (idioma.Equals("BR"))
                {
                    alertMessage4 = "Houve algum problema para salvar os dados do usuário, todos os dados são obrigatórios, o formato do campo data deve ser DD/MM/AAAA";
                }
                else if (idioma.Equals("ES"))
                {
                    alertMessage4 = "Hubo un problema al guardar los datos de usuario, se requiere todos los datos, el formato de campo de fecha debe ser DD/MM/AAAA";
                }
                else if (idioma.Equals("EN"))
                {
                    alertMessage4 = "There was a problem saving user data, All data is mandatory, the date field format must be DD / MM / YYYY";
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage4 + "')", true);
            }

        }

        protected void ValidaNome(object sender, EventArgs e)
        {
            //Valida se o campo Nome possuí no minimo 8 digitos, se contem espaço, e se não possuí digitos numéricos
            if (txtNome.Text.Length < 8 || !txtNome.Text.Contains(" ") || txtNome.Text.Where(c => char.IsNumber(c)).Count() > 0)
            {
                txtNome.Text = "";
                string alertMessage = "";
                if (idioma.Equals("BR"))
                {
                    alertMessage = "Nome com formato inválido, este campo não deve conter números, deve possuir entre 8 e 50 caracteres e ser composto pelo nome completo ou abreviado";
                }
                else if (idioma.Equals("ES"))
                {
                    alertMessage = "Nombre con formato incorrecto, este campo no debe contener números, debe tener entre 8 y 50 caracteres y debe ser compuesta por el nombre completo o abreviado";
                }
                else if (idioma.Equals("EN"))
                {
                    alertMessage = "Invalid format name, this field must not contain numbers, must be between 8 and 50 characters long and must consist of the full or abbreviated name";
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage + "')", true);
            }
            else
            {
                txtNome.Text = txtNome.Text.ToUpper();
            }
        }

        protected void ValidaCPF(object sender, EventArgs e)
        {

            //remove do valor digitado qualque espaço, . ou - 
            string[] aux = txtCPF.Text.Split('.', '-', ' ');
            txtCPF.Text = "";
            foreach (string value in aux)
            {
                txtCPF.Text = txtCPF.Text + value;
            }

            string alertMessage = "";

            //valida primeiramente se o usuário é brasileiro
            if (idioma.Equals("BR"))
            {
                //Valida se o campo CPF possuí 11 digitos, e se não possuí letras
                if (txtCPF.Text.Length != 11 || txtCPF.Text.Where(c => !char.IsNumber(c)).Count() > 0)
                {
                    txtCPF.Text = "";
                    alertMessage = "CPF com formato inválido, este campo deve conter somente números e possuir 11 caracteres.";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage + "')", true);
                }
                //passando pelas condições anteriores é efetuado o teste do digito verificador para CPF
                else
                {
                    if (!calculaDigitoCPF(txtCPF.Text))
                    {
                        txtCPF.Text = "";
                        alertMessage = "CPF com formato inválido,não aprovado na validação do digito verificador";
                        ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage + "')", true);
                    }
                }
            }
            else
            {
                if (txtCPF.Text.Length < 6)
                {
                    if (idioma.Equals("ES"))
                    {
                        alertMessage = "Pasaporte con formato incorrecto, este campo no debe tener mas de 6 caracteres";
                    }
                    else if (idioma.Equals("EN"))
                    {
                        alertMessage = "Invalid format passport, this field must be more then 6 characters long";
                    }
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage + "')", true);
                }
            }
        }

        private bool calculaDigitoCPF(string cpf)
        {
            char[] validador = cpf.ToCharArray();
            int calculo = 0, count = 10;
            //inicio da rotina pra validação do digito 10 do CPF
            for(int i = 0; i < 9; i++)
            {
                calculo = calculo + (Convert.ToInt32(validador[i].ToString()) * count);
                count--;
            }
            int divisão = calculo / 11;
            divisão = calculo - (divisão * 11);
            if(divisão < 2)
            {
                if(validador[9]!= '0')
                {
                    return false;
                }
            }
            else
            {
                divisão = 11 - divisão;
                if (validador[9] != Convert.ToChar(divisão.ToString()))
                {
                    return false;
                }
            }
            //inicio da rotina para a validação do digito final do CPF
            calculo = 0;
            count = 11;
            for (int i = 0; i < 10; i++)
            {
                calculo = calculo + (Convert.ToInt32(validador[i].ToString()) * count);
                count--;
            }
            divisão = calculo / 11;
            divisão = calculo - (divisão * 11);
            if (divisão < 2)
            {
                if (validador[10] != '0')
                {
                    return false;
                }
            }
            else
            {
                divisão = 11 - divisão;
                if (validador[10] != Convert.ToChar(divisão.ToString()))
                {
                    return false;
                }
            }
            return true;
        }

        protected void ValidaNacionalidade(object sender, EventArgs e)
        {
            if(txtNacional.Text.Length < 3)
            {
                txtNacional.Text = "";
                string alertMessage1 = "";
                if (idioma.Equals("BR"))
                {
                    alertMessage1 = "O campo nacionalidade deve possuir no minimo a abreviatura do país de origem com 3 caracteres";
                }
                else if (idioma.Equals("ES"))
                {
                    alertMessage1 = "El campo de la nacionalidad debe tener al menos la abreviatura del país de origen con 3 caracteres";
                }
                else if (idioma.Equals("EN"))
                {
                    alertMessage1 = "The nationality field must have at least the abbreviation of the country of origin with 3 characters";
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage1 + "')", true);
            }
            else
            {
                txtNacional.Text = txtNacional.Text.ToUpper();
            }
        }

        protected void txtCEP_TextChanged(object sender, EventArgs e)
        {
            //remove do valor digitado qualque espaço, . ou - 
            string[] aux = txtCEP.Text.Split('.', '-', ' ');
            txtCEP.Text = "";
            foreach (string value in aux)
            {
                txtCEP.Text = txtCEP.Text + value;
            }

            string alertMessage = "";

            //valida primeiramente se o usuário é residente no Brasil
            if (ddlPaises.SelectedIndex==1)
            {
                //Valida se o campo CEP possuí 8 digitos, e se não possuí letras
                if (txtCEP.Text.Length != 8 || txtCEP.Text.Where(c => !char.IsNumber(c)).Count() > 0)
                {
                    txtCEP.Text = "";
                    alertMessage = "CEP inválido, este campo deve conter somente números e possuir 8 caracteres.";
                    ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage + "')", true);
                }
            }
            //Para estrangeiros ou residentes fora do país o campo 
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void txtTelefone1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtTelefone2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtCelular_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtRG_TextChanged(object sender, EventArgs e)
        {
            if (txtRG.Text.Length < 9)
            {
                txtRG.Text = "";
                string alertMessage = "";
                if (idioma.Equals("BR"))
                {
                    alertMessage = "O campo RG/RNE deve possuir no minimo 9 caracteres, se necessário complete com zeros";
                }
                else if (idioma.Equals("ES"))
                {
                    alertMessage = "El campo identidad debe tener al menos 9 caracteres, si completa necesaria con ceros ";
                }
                else if (idioma.Equals("EN"))
                {
                    alertMessage = "The ID field must have at least 9 characters, if necessary complete with zeros";
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage + "')", true);
            }
            else
            {
                txtRG.Text = txtRG.Text.ToUpper();
            }
        }

        protected void chkEstrangeiro_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEstrangeiro.Checked)
            {
                ddlPaises.Visible = true;
                lblPaises.Visible = true;
                txtCidade.Visible = true;
                ddlCidade.Visible = false;
                ddlEstado.Enabled = false;
                ddlLogradouro.Enabled = false;
            }
            else
            {
                ddlPaises.Visible = false;
                lblPaises.Visible = false;
                txtCidade.Visible = false;
                ddlCidade.Visible = true;
                ddlEstado.Enabled = true;
                ddlLogradouro.Enabled = true;
            }
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //limpa a drop down list de cidades
            ddlCidade.Items.Clear();

            if (ddlEstado.SelectedIndex == 0)
            {
                string alertMessage1 = "";
                if (idioma.Equals("BR"))
                {
                    alertMessage1 = "A seleção de um item é obrigatória";
                }
                else if (idioma.Equals("ES"))
                {
                    alertMessage1 = "Al seleccionar un elemento se requiere";
                }
                else if (idioma.Equals("EN"))
                {
                    alertMessage1 = "Selecting an item is required";
                }
                ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + alertMessage1 + "')", true);
                ddlCidade.Items.Clear();
                ddlCidade.Enabled = false;
            }
            //valida se houve alteração na drop down list de estado
            else
            {
                //se houve seleção de estado habilita a seleção de cidade
                ddlCidade.Enabled = true;
                //pesquisa pelas cidades cadastradas na base de dados compativeis com o estado selecionado
                cidades = controle.pesquisaCidades(ddlEstado.SelectedIndex + 1);

                //reinicia o contador do indice
                //count = 1;


                //adiciona o primeiro item estático ao indice na posição 0
                ddlCidade.TabIndex.Equals(0);
                ddlCidade.Items.Add("-------");
                //interação condicionada a quantidade de elementos retornados na pesquisa anterior
                foreach (CIDADES value in cidades)
                {
                    //exclui da lista o padrão para estrangeiros
                    if (value.id != 1)
                    {
                        // atribui o indice do elemento e o valor do objeto como sendo o nome da cidade
                        //ddlCidade.TabIndex.Equals(count);

                        ddlCidade.Items.Add(value.nomeCidade);

                        //incrementa o indice
                        //count++;
                    }
                }
            }

        }

    }
}