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
    public class TemplateEmailRepository : RepositoryBase<TEMPLATE_EMAIL>, ITemplateEmailRepository
    {
        public TEMPLATE_EMAIL GetItemById(Int32 id)
        {
            IQueryable<TEMPLATE_EMAIL> query = Db.TEMPLATE_EMAIL;
            query = query.Where(p => p.TEMP_CD_ID == id);
            return query.FirstOrDefault();
        }

        public TEMPLATE_EMAIL GetItemByCode(String code)
        {
            IQueryable<TEMPLATE_EMAIL> query = Db.TEMPLATE_EMAIL;
            query = query.Where(p => p.TEMP_CD_CODIGO == code);
            return query.FirstOrDefault();
        }

        public List<TEMPLATE_EMAIL> GetAllItensAdm()
        {
            IQueryable<TEMPLATE_EMAIL> query = Db.TEMPLATE_EMAIL;
            return query.ToList();
        }

        public List<TEMPLATE_EMAIL> GetAllItens()
        {
            IQueryable<TEMPLATE_EMAIL> query = Db.TEMPLATE_EMAIL.Where(p => p.TEMP_IN_ATIVO == 1);
            return query.ToList();
        }
    }
}
 