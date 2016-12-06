using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InscricaoCongresso.Model
{
    public class Repository
    {
        DbEntities entityModel = new DbEntities();
        public void salvarAlterações()
        {
            entityModel.SaveChanges();
        }

        public void salvarTrabalho(TRABALHOS trabalho)
        {
            entityModel.TRABALHOS.Add(trabalho);
        }

        public void salvarAutor(AUTORES autor)
        {
            entityModel.AUTORES.Add(autor);
        }

        public void salvarInscricao(INSCRITOS inscricao)
        {
            entityModel.INSCRITOS.Add(inscricao);
        }

        public void salvarEndereco(ENDERECOS endereco)
        {
            entityModel.ENDERECOS.Add(endereco);
        }

        public void salvarBoleto(BOLETOS boleto)
        {
            entityModel.BOLETOS.Add(boleto);
        }

        public int pesquisaIdTrabalhoNome(string titulo)
        {
            return (from trabalhos in entityModel.TRABALHOS
                    where (trabalhos.titulo.Equals(titulo))
                    select trabalhos.id).SingleOrDefault();            
        }   

        public int selectBoletoAtualNum(int id)
        {
            return (from boletos in entityModel.BOLETOS
                    where (boletos.idInscritos == id)
                    select boletos.nossoNumero).SingleOrDefault();
        }     

        public ENDERECOS pesquisaEnderecoPorNomeNum(string nome, string num)
        {
            return (from endereco in entityModel.ENDERECOS
                    where (endereco.nomeEndereco.Equals(nome)
                    && endereco.numeroEndereco.Equals(num))
                    select endereco).SingleOrDefault();
        }

        public BOLETOS selectBoletoUser(int id)
        {
            return (from boletos in entityModel.BOLETOS
                    where (boletos.idInscritos == id)
                    select boletos).SingleOrDefault();
        }

        public List<AUTORES> pesquisaAutoresTrabalhoID(int idTrabalho)
        {
            return(from autores in entityModel.AUTORES
                    where (autores.idTrabalho == idTrabalho)
                    select autores).ToList();
        }

        public INSCRITOS selectInscritos(string pesquisa)
        {
            return (from inscritos in entityModel.INSCRITOS
                    where (inscritos.cpf.Equals(pesquisa))
                    select (inscritos)).SingleOrDefault();
        }

        public List<CIDADES> selectCidades(int idEstado)
        {

            return (from cidades in entityModel.CIDADES
                    where(cidades.idEstado == idEstado)
                    select cidades).ToList();
        }

        public List<LOGRADOUROS> selectLogradouros()
        {
            return (from logradouros in entityModel.LOGRADOUROS
                    select (logradouros)).ToList();
        }

        public List<PAISES> selectPaises()
        {
            return (from paises in entityModel.PAISES
                    select (paises)).ToList();
        }

        public CONTAS selectConta(int id)
        {
            return (from contas in entityModel.CONTAS
                    where (contas.id == id)
                    select (contas)).SingleOrDefault();
        }

        public VALORES selectValor(int id)
        {
            return (from valores in entityModel.VALORES
                    where (valores.id == id)
                    select (valores)).SingleOrDefault();
        }

        public CEDENTES selectCedente(string empresa)
        {
            return (from cedentes in entityModel.CEDENTES
                    where (cedentes.nomeCedente.Equals(empresa))
                    select (cedentes)).SingleOrDefault();
        }

        public List<ESTADOS> selectEstados()
        {
            return (from estados in entityModel.ESTADOS
                    select (estados)).ToList();
        }        
    }
}