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
    public class CampanhaContatoRepository : RepositoryBase<CAMPANHA_CONTATO>, ICampanhaContatoRepository
    {
        public CAMPANHA_CONTATO CheckExist(CAMPANHA_CONTATO item)
        {
            IQueryable<CAMPANHA_CONTATO> query = Db.CAMPANHA_CONTATO;
            query = query.Where(p => p.CAMP_CD_ID == item.CAMP_CD_ID);
            query = query.Where(p => p.CONT_CD_ID == item.CONT_CD_ID);
            return query.FirstOrDefault();
        }

        public CAMPANHA_CONTATO GetItemById(Int32 id)
        {
            IQueryable<CAMPANHA_CONTATO> query = Db.CAMPANHA_CONTATO;
            query = query.Where(p => p.CACT_CD_ID == id);
            return query.FirstOrDefault();
        }

    }
}
 