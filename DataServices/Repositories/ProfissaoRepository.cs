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
    public class ProfissaoRepository : RepositoryBase<PROFISSAO>, IProfissaoRepository
    {
        public PROFISSAO CheckExist(PROFISSAO prof)
        {
            IQueryable<PROFISSAO> query = Db.PROFISSAO;
            query = query.Where(p => p.PROF_NM_NOME == prof.PROF_NM_NOME);
            return query.FirstOrDefault();
        }

        public PROFISSAO GetItemById(Int32 id)
        {
            IQueryable<PROFISSAO> query = Db.PROFISSAO;
            query = query.Where(p => p.PROF_CD_ID == id);
            return query.FirstOrDefault();
        }

        public List<PROFISSAO> GetAllItensAdm()
        {
            IQueryable<PROFISSAO> query = Db.PROFISSAO;
            return query.ToList();
        }

        public List<PROFISSAO> GetAllItens()
        {
            IQueryable<PROFISSAO> query = Db.PROFISSAO.Where(p => p.PROF_IN_ATIVO == 1);
            return query.ToList();
        }

    }
}
 