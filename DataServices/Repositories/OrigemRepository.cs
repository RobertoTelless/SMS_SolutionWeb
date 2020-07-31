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
    public class OrigemRepository : RepositoryBase<ORIGEM>, IOrigemRepository
    {
        public ORIGEM CheckExist(ORIGEM origem)
        {
            IQueryable<ORIGEM> query = Db.ORIGEM;
            query = query.Where(p => p.ORIG_NM_NOME == origem.ORIG_NM_NOME);
            return query.FirstOrDefault();
        }

        public ORIGEM GetItemById(Int32 id)
        {
            IQueryable<ORIGEM> query = Db.ORIGEM;
            query = query.Where(p => p.ORIG_CD_ID == id);
            return query.FirstOrDefault();
        }

        public List<ORIGEM> GetAllItensAdm()
        {
            IQueryable<ORIGEM> query = Db.ORIGEM;
            return query.ToList();
        }

        public List<ORIGEM> GetAllItens()
        {
            IQueryable<ORIGEM> query = Db.ORIGEM.Where(p => p.ORIG_IN_ATIVO == 1);
            return query.ToList();
        }

    }
}
 