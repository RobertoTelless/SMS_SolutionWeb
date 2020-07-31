using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IGrupoContatoAppService : IAppServiceBase<GRUPO_CONTATO>
    {
        Int32 ValidateCreate(GRUPO_CONTATO item);
        Int32 ValidateEdit(GRUPO_CONTATO item, GRUPO_CONTATO itemAntes);
        Int32 ValidateDelete(GRUPO_CONTATO item);

        GRUPO_CONTATO GetItemById(Int32 id);
        GRUPO_CONTATO CheckExist(GRUPO_CONTATO item);
    }
}
