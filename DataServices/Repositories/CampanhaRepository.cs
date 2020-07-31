using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using System.Data.Entity;
using CrossCutting;

namespace DataServices.Repositories
{
    public class CampanhaRepository : RepositoryBase<CAMPANHA>, ICampanhaRepository
    {
        public CAMPANHA CheckExist(CAMPANHA campanha, Int32? idAss)
        {
            IQueryable<CAMPANHA> query = Db.CAMPANHA;
            query = query.Where(p => p.CAMP_NM_NOME == campanha.CAMP_NM_NOME);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.FirstOrDefault();
        }

        public CAMPANHA GetItemById(Int32 id)
        {
            IQueryable<CAMPANHA> query = Db.CAMPANHA;
            query = query.Where(p => p.CAMP_CD_ID == id);
            query = query.Include(p => p.CAMPANHA_CONTATO);
            return query.FirstOrDefault();
        }

        public List<CAMPANHA> GetAllItens(Int32? idAss)
        {
            IQueryable<CAMPANHA> query = Db.CAMPANHA.Where(p => p.CAMP_IN_ATIVO == 1);
            query = query.Include(p => p.CAMPANHA_CONTATO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<CAMPANHA> GetAllItensAdm(Int32? idAss)
        {
            IQueryable<CAMPANHA> query = Db.CAMPANHA;
            query = query.Include(p => p.CAMPANHA_CONTATO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<CAMPANHA> ExecuteFilter(String nome, String descricao, Int32? idAss)
        {
            List<CAMPANHA> lista = new List<CAMPANHA>();
            IQueryable<CAMPANHA> query = Db.CAMPANHA;
            if (!String.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.CAMP_NM_NOME.Contains(nome));
            }
            if (!String.IsNullOrEmpty(descricao))
            {
                query = query.Where(p => p.CAMP_DS_DESCRICAO.Contains(descricao));
            }
            if (query != null)
            {
                query = query.Where(p => p.ASSI_CD_ID == idAss);
                query = query.OrderBy(a => a.CAMP_NM_NOME);
                lista = query.ToList<CAMPANHA>();
            }
            return lista;
        }
    }
}
