using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ITemplateRepository : IRepositoryBase<TEMPLATE>
    {
        List<TEMPLATE> GetAllItens(Int32? idAss);
        List<TEMPLATE> GetAllItensCampanha(Int32? idCampanha, Int32? idAss);
        TEMPLATE GetItemById(Int32 id);
        TEMPLATE GetItemByCode(String code, Int32? idAss);
        List<TEMPLATE> GetAllItensAdm(Int32? idAss);
        List<TEMPLATE> ExecuteFilter(String nome, String conteudo, String sigla, Int32? idAss);
        TEMPLATE CheckExist(TEMPLATE item, Int32? idAss);
    }
}
