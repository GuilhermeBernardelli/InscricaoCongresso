using InscricaoCongresso.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InscricaoCongresso.Control
{
    public class Controle : DbContext
    {
        Repository entity = new Repository();
        public void atualizar()
        {
            entity.salvarAlterações();
        }

        public void adicionarTrabalho(TRABALHOS trabalho)
        {
            entity.salvarTrabalho(trabalho);
        }

        public void adicionarAutor(AUTORES autor)
        {
            entity.salvarAutor(autor);
        }

        public void adicionarInscricao(INSCRITOS inscricao)
        {
            entity.salvarInscricao(inscricao);
        }

        public void adicionarEndereco(ENDERECOS endereco)
        {
            entity.salvarEndereco(endereco);
        }

        public void adicionarBoleto(BOLETOS boleto)
        {
            entity.salvarBoleto(boleto);
        }

        public INSCRITOS pesquisaInscritosId(int id)
        {
            int pesquisa = id;
            return entity.selectInscritosPorId(pesquisa);
        }

        public int idTrabalhoPorTitulo(string titulo)
        {
            int id;
            string nome = titulo;
            id = entity.pesquisaIdTrabalhoNome(nome);
            return id; 
        }



        public List<AUTORES> autoresIdtrabalho(int valor)
        {
            int idTrabalho = valor;            
            return entity.pesquisaAutoresTrabalhoID(idTrabalho);
        }

        public List<CIDADES> pesquisaCidades(int estado)
        {
            int pesquisa = estado;
            return entity.selectCidades(pesquisa);
        }

        public BOLETOS pesquisaBoletoUsuario(int userId)
        {
            int Id = userId;
            return entity.selectBoletoUser(Id);
        }

        public INSCRITOS pesquisaInscritos(string cpf)
        {
            string pesquisa = cpf;
            return entity.selectInscritos(pesquisa);
        }

        public List<LOGRADOUROS> pesquisaLogradouros()
        {
            return entity.selectLogradouros();
        }

        public List<PAISES> pesquisaPaises()
        {
            return entity.selectPaises();
        }

        public List<ESTADOS> pesquisaEstados()
        {
            return entity.selectEstados();
        }

        public ENDERECOS pesquisaIdEndereco(string endereco, string numero)
        {
            string nome = endereco;
            string num = numero;
            return entity.pesquisaEnderecoPorNomeNum(nome, num);
        }

        public CEDENTES pesquisaCedente(string nome)
        {
            string empresa = nome;
            return entity.selectCedente(empresa);
        }

        public int pesquisaBoletoAtualNum()
        {
            return entity.selectBoletoAtualNum();
        }

        public CONTAS pesquisaContaPorId(int idConta)
        {
            int id = idConta;
            return entity.selectConta(id);
        }

        public VALORES pesquisaValorPorId(int valor)
        {
            int id = valor;
            return entity.selectValor(id);
        }

        public ENDERECOS pesquisaEnderecoPorId(int idEndereco)
        {
            int id = idEndereco;
            return entity.selectEndereco(id);
        }

        public LOGRADOUROS pesquisaLogradouroId(int idLogradouro)
        {
            int id = idLogradouro;
            return entity.selectLogradouro(id);
        }

        public CIDADES pesquisaCidadeId(int idCidade)
        {
            int id = idCidade;
            return entity.selectCidade(id);
        }

        public ESTADOS pesquisaEstadoId(int idEstado)
        {
            int id = idEstado;
            return entity.selectEstado(id);
        }

        public PAISES pesquisaPaisId(int idPaises)
        {
            int id = idPaises;
            return entity.selectPais(id);
        }
    }
}