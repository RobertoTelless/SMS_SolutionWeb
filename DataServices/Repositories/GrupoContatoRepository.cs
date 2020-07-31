using System;
using System.Collections.Generic;
using EntitiesServices.Model;  
using ModelServices.Interfaces.Repositories;
using System.Linq;
using System.Data.Entity;
using CrossCutting;

namespace DataServices.Repositories
{
    public class GrupoContatoRepository : RepositoryBase<GRUPO_CONTATO>, IGrupoContatoRepository
    {
        public GRUPO_CONTATO CheckExist(GRUPO_CONTATO item)
        {
            IQueryable<GRUPO_CONTATO> query = Db.GRUPO_CONTATO;
            query = query.Where(p => p.GRUP_CD_ID == item.GRUP_CD_ID);
            query = query.Where(p => p.CONT_CD_ID == item.CONT_CD_ID);
            return query.FirstOrDefault();
        }

        public GRUPO_CONTATO GetItemById(Int32 id)
        {
            IQueryable<GRUPO_CONTATO> query = Db.GRUPO_CONTATO;
            query = query.Where(p => p.GRCO_CD_ID == id);
            return query.FirstOrDefault();
        }
    }
}
