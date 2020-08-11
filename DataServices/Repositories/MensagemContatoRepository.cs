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
    public class MensagemContatoRepository : RepositoryBase<MENSAGEM_CONTATO>, IMensagemContatoRepository
    {
        public MENSAGEM_CONTATO CheckExist(MENSAGEM_CONTATO item)
        {
            IQueryable<MENSAGEM_CONTATO> query = Db.MENSAGEM_CONTATO;
            query = query.Where(p => p.MENS_CD_ID == item.MENS_CD_ID);
            query = query.Where(p => p.CONT_CD_ID == item.CONT_CD_ID);
            return query.FirstOrDefault();
        }

        public MENSAGEM_CONTATO GetItemById(Int32 id)
        {
            IQueryable<MENSAGEM_CONTATO> query = Db.MENSAGEM_CONTATO;
            query = query.Where(p => p.MECO_CD_ID == id);
            return query.FirstOrDefault();
        }

    }
}
 