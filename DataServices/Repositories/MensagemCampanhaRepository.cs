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
    public class MensagemCampanhaRepository : RepositoryBase<MENSAGEM_CAMPANHA>, IMensagemCampanhaRepository
    {
        public MENSAGEM_CAMPANHA CheckExist(MENSAGEM_CAMPANHA item)
        {
            IQueryable<MENSAGEM_CAMPANHA> query = Db.MENSAGEM_CAMPANHA;
            query = query.Where(p => p.MENS_CD_ID == item.MENS_CD_ID);
            query = query.Where(p => p.CAMP_CD_ID == item.CAMP_CD_ID);
            return query.FirstOrDefault();
        }

        public MENSAGEM_CAMPANHA GetItemById(Int32 id)
        {
            IQueryable<MENSAGEM_CAMPANHA> query = Db.MENSAGEM_CAMPANHA;
            query = query.Where(p => p.MECA_CD_ID == id);
            return query.FirstOrDefault();
        }

    }
}
 