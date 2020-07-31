using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IGrupoContatoService : IServiceBase<GRUPO_CONTATO>
    {
        Int32 Create(GRUPO_CONTATO item);
        Int32 Edit(GRUPO_CONTATO item);
        Int32 Delete(GRUPO_CONTATO item);
        GRUPO_CONTATO CheckExist(GRUPO_CONTATO item);
        GRUPO_CONTATO GetItemById(Int32 id);
    }
}
