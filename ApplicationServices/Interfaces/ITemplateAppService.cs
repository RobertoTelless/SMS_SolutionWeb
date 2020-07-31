using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ITemplateAppService : IAppServiceBase<TEMPLATE>
    {
        Int32 ValidateCreate(TEMPLATE item, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(TEMPLATE item, TEMPLATE itemAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateDelete(TEMPLATE item, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(TEMPLATE item, USUARIO usuario, Int32? idAss);

        TEMPLATE CheckExist(TEMPLATE item, Int32? idAss);
        List<TEMPLATE> GetAllItens(Int32? idAss);
        List<TEMPLATE> GetAllItensCampanha(Int32? idCampanha, Int32? idAss);
        TEMPLATE GetItemById(Int32 id);
        List<TEMPLATE> GetAllItensAdm(Int32? idAss);
        Int32 ExecuteFilter(String nome, String conteudo, String sigla, Int32? idAss, out List<TEMPLATE> objeto);
    }
}
