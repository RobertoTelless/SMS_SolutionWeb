using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using System.Data.Entity;
using CrossCutting;

namespace DataServices.Repositories
{
    public class GrupoRepository : RepositoryBase<GRUPO>, IGrupoRepository
    {
        public GRUPO CheckExist(GRUPO grupo, Int32? idAss)
        {
            IQueryable<GRUPO> query = Db.GRUPO;
            query = query.Where(p => p.GRUP_NM_NOME == grupo.GRUP_NM_NOME);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.FirstOrDefault();
        }

        public GRUPO GetItemById(Int32 id)
        {
            IQueryable<GRUPO> query = Db.GRUPO;
            query = query.Where(p => p.GRUP_CD_ID == id);
            query = query.Include(p => p.GRUPO_CONTATO);
            return query.FirstOrDefault();
        }

        public List<GRUPO> GetAllItens(Int32? idAss)
        {
            IQueryable<GRUPO> query = Db.GRUPO.Where(p => p.GRUP_IN_ATIVO == 1);
            query = query.Include(p => p.GRUPO_CONTATO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<GRUPO> GetAllItensAdm(Int32? idAss)
        {
            IQueryable<GRUPO> query = Db.GRUPO;
            query = query.Include(p => p.GRUPO_CONTATO);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<GRUPO> ExecuteFilter(String nome, Int32? idAss)
        {
            List<GRUPO> lista = new List<GRUPO>();
            IQueryable<GRUPO> query = Db.GRUPO;
            if (!String.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.GRUP_NM_NOME.Contains(nome));
            }
            if (query != null)
            {
                query = query.Where(p => p.ASSI_CD_ID == idAss);
                query = query.OrderBy(a => a.GRUP_NM_NOME);
                lista = query.ToList<GRUPO>();
            }
            return lista;
        }
    }
}
