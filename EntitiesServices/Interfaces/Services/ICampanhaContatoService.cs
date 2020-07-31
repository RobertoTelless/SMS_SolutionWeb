using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ICampanhaContatoService : IServiceBase<CAMPANHA_CONTATO>
    {
        Int32 Create(CAMPANHA_CONTATO item);
        Int32 Edit(CAMPANHA_CONTATO item);
        Int32 Delete(CAMPANHA_CONTATO item);
        CAMPANHA_CONTATO CheckExist(CAMPANHA_CONTATO item);
        CAMPANHA_CONTATO GetItemById(Int32 id);
    }
}
