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
    public class CampanhaGrupoRepository : RepositoryBase<CAMPANHA_GRUPO>, ICampanhaGrupoRepository
    {
        public CAMPANHA_GRUPO CheckExist(CAMPANHA_GRUPO item)
        {
            IQueryable<CAMPANHA_GRUPO> query = Db.CAMPANHA_GRUPO;
            query = query.Where(p => p.CAMP_CD_ID == item.CAMP_CD_ID);
            query = query.Where(p => p.GRUP_CD_ID == item.GRUP_CD_ID);
            return query.FirstOrDefault();
        }

        public CAMPANHA_GRUPO GetItemById(Int32 id)
        {
            IQueryable<CAMPANHA_GRUPO> query = Db.CAMPANHA_GRUPO;
            query = query.Where(p => p.CAGR_CD_ID == id);
            return query.FirstOrDefault();
        }

    }
}
 