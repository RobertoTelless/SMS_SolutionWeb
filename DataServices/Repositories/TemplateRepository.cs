using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using ModelServices.Interfaces.Repositories;
using EntitiesServices.Work_Classes;

namespace DataServices.Repositories
{
    public class TemplateRepository : RepositoryBase<TEMPLATE>, ITemplateRepository
    {
        public TEMPLATE GetItemById(Int32 id)
        {
            IQueryable<TEMPLATE> query = Db.TEMPLATE;
            query = query.Where(p => p.TEMP_CD_ID == id);
            return query.FirstOrDefault();
        }

        public TEMPLATE GetItemByCode(String code, Int32? idAss)
        {
            IQueryable<TEMPLATE> query = Db.TEMPLATE;
            query = query.Where(p => p.TEMP_SG_SIGLA == code);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.FirstOrDefault();
        }

        public List<TEMPLATE> GetAllItensAdm(Int32? idAss)
        {
            IQueryable<TEMPLATE> query = Db.TEMPLATE;
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<TEMPLATE> GetAllItens(Int32? idAss)
        {
            IQueryable<TEMPLATE> query = Db.TEMPLATE.Where(p => p.TEMP_IN_ATIVO == 1);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.ToList();
        }

        public List<TEMPLATE> GetAllItensCampanha(Int32? idCampanha, Int32? idAss)
        {
            IQueryable<TEMPLATE> query = Db.TEMPLATE.Where(p => p.TEMP_IN_ATIVO == 1);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            query = query.Where(p => p.CAMP_CD_ID == idCampanha || p.CAMP_CD_ID == null);
            return query.ToList();
        }

        public TEMPLATE CheckExist(TEMPLATE item, Int32? idAss)
        {
            IQueryable<TEMPLATE> query = Db.TEMPLATE;
            query = query.Where(p => p.TEMP_NM_NOME == item.TEMP_NM_NOME);
            query = query.Where(p => p.ASSI_CD_ID == idAss);
            return query.FirstOrDefault();
        }

        public List<TEMPLATE> ExecuteFilter(String nome, String conteudo, String sigla, Int32? idAss)
        {
            List<TEMPLATE> lista = new List<TEMPLATE>();
            IQueryable<TEMPLATE> query = Db.TEMPLATE;
            if (!String.IsNullOrEmpty(nome))
            {
                query = query.Where(p => p.TEMP_NM_NOME.Contains(nome));
            }
            if (!String.IsNullOrEmpty(sigla))
            {
                query = query.Where(p => p.TEMP_SG_SIGLA == sigla);
            }
            if (!String.IsNullOrEmpty(conteudo))
            {
                query = query.Where(p => p.TEMP_TX_TEXTO.Contains(conteudo));
            }
            if (query != null)
            {
                query = query.OrderBy(a => a.TEMP_NM_NOME);
                lista = query.ToList<TEMPLATE>();
            }
            return lista;
        }
    }
}
 