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
    public class MensagemGrupoRepository : RepositoryBase<MENSAGEM_GRUPO>, IMensagemGrupoRepository
    {
        public MENSAGEM_GRUPO CheckExist(MENSAGEM_GRUPO item)
        {
            IQueryable<MENSAGEM_GRUPO> query = Db.MENSAGEM_GRUPO;
            query = query.Where(p => p.MENS_CD_ID == item.MENS_CD_ID);
            query = query.Where(p => p.GRUP_CD_ID == item.GRUP_CD_ID);
            return query.FirstOrDefault();
        }

        public MENSAGEM_GRUPO GetItemById(Int32 id)
        {
            IQueryable<MENSAGEM_GRUPO> query = Db.MENSAGEM_GRUPO;
            query = query.Where(p => p.MEGR_CD_ID == id);
            return query.FirstOrDefault();
        }

    }
}
 