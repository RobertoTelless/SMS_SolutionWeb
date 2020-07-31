using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using ModelServices.Interfaces.Repositories;
using EntitiesServices.Work_Classes;
using System.Data.Entity;

namespace DataServices.Repositories
{
    public class ClubeRepository : RepositoryBase<CLUBE>, IClubeRepository
    {
        public CLUBE CheckExist(CLUBE cat)
        {
            IQueryable<CLUBE> query = Db.CLUBE;
            query = query.Where(p => p.CLUB_NM_NOME == cat.CLUB_NM_NOME);
            query = query.Where(p => p.UF_CD_ID == cat.UF_CD_ID);
            return query.FirstOrDefault();
        }

        public CLUBE GetItemById(Int32 id)
        {
            IQueryable<CLUBE> query = Db.CLUBE;
            query = query.Where(p => p.CLUB_CD_ID == id);
            return query.FirstOrDefault();
        }

        public List<CLUBE> GetAllItensAdm()
        {
            IQueryable<CLUBE> query = Db.CLUBE;
            return query.ToList();
        }

        public List<CLUBE> GetAllItens()
        {
            IQueryable<CLUBE> query = Db.CLUBE.Where(p => p.CLUB_IN_ATIVO == 1);
            return query.ToList();
        }

    }
}
 