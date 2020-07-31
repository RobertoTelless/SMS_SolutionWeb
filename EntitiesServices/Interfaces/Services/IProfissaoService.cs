using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IProfissaoService : IServiceBase<PROFISSAO>
    {
        Int32 Create(PROFISSAO item, LOG log);
        Int32 Create(PROFISSAO item);
        Int32 Edit(PROFISSAO item, LOG log);
        Int32 Edit(PROFISSAO item);
        Int32 Delete(PROFISSAO item, LOG log);
        PROFISSAO CheckExist(PROFISSAO item);
        PROFISSAO GetItemById(Int32 id);
        List<PROFISSAO> GetAllItens();
        List<PROFISSAO> GetAllItensAdm();
    }
}
