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

        public int idTrabalhoPorTitulo(string titulo)
        {
            int id;
            string nome = titulo;
            id = entity.pesquisaIdTrabalhoNome(nome);
            return id; 
        }
                
    }
}