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
    public class CategoriaContatoRepository : RepositoryBase<CATEGORIA_CONTATO>, ICategoriaContatoRepository
    {
        public CATEGORIA_CONTATO CheckExist(CATEGORIA_CONTATO cat)
        {
            IQueryable<CATEGORIA_CONTATO> query = Db.CATEGORIA_CONTATO;
            query = query.Where(p => p.CACO_NM_NOME == cat.CACO_NM_NOME);
            return query.FirstOrDefault();
        }

        public CATEGORIA_CONTATO GetItemById(Int32 id)
        {
            IQueryable<CATEGORIA_CONTATO> query = Db.CATEGORIA_CONTATO;
            query = query.Where(p => p.CACO_CD_ID == id);
            return query.FirstOrDefault();
        }

        public List<CATEGORIA_CONTATO> GetAllItensAdm()
        {
            IQueryable<CATEGORIA_CONTATO> query = Db.CATEGORIA_CONTATO;
            return query.ToList();
        }

        public List<CATEGORIA_CONTATO> GetAllItens()
        {
            IQueryable<CATEGORIA_CONTATO> query = Db.CATEGORIA_CONTATO.Where(p => p.CACO_IN_ATIVO == 1);
            return query.ToList();
        }

    }
}
 