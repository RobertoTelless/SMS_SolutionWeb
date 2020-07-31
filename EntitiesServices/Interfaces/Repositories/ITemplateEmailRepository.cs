using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ITemplateEmailRepository : IRepositoryBase<TEMPLATE_EMAIL>
    {
        List<TEMPLATE_EMAIL> GetAllItens();
        TEMPLATE_EMAIL GetItemById(Int32 id);
        TEMPLATE_EMAIL GetItemByCode(String code);
        List<TEMPLATE_EMAIL> GetAllItensAdm();
    }
}
