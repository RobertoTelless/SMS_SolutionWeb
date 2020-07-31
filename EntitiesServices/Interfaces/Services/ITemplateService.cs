using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ITemplateService : IServiceBase<TEMPLATE>
    {
        Int32 Create(TEMPLATE perfil, LOG log, Int32? idAss);
        Int32 Create(TEMPLATE perfil, Int32? idAss);
        Int32 Edit(TEMPLATE perfil, LOG log, Int32? idAss);
        Int32 Edit(TEMPLATE perfil, Int32? idAss);
        Int32 Delete(TEMPLATE perfil, LOG log, Int32? idAss);
        List<TEMPLATE> GetAllItens(Int32? idAss);
        List<TEMPLATE> GetAllItensCampanha(Int32? idCampanha, Int32? idAss);
        TEMPLATE GetItemById(Int32 id);
        List<TEMPLATE> GetAllItensAdm(Int32? idAss);
        List<TEMPLATE> ExecuteFilter(String nome, String conteudo, String sigla, Int32? idAss);
        TEMPLATE CheckExist(TEMPLATE item, Int32? idAss);
    }
}
