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

        public int pesquisaIdTrabalhoNome(string titulo)
        {
            return (from trabalhos in entityModel.TRABALHOS
                    where (trabalhos.titulo.Equals(titulo))
                    select trabalhos.id).SingleOrDefault();            
        }

       
    }
}