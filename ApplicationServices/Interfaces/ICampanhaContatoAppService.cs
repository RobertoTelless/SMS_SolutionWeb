using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ICampanhaContatoAppService : IAppServiceBase<CAMPANHA_CONTATO>
    {
        Int32 ValidateCreate(CAMPANHA_CONTATO item);
        Int32 ValidateEdit(CAMPANHA_CONTATO item, CAMPANHA_CONTATO itemAntes);
        Int32 ValidateDelete(CAMPANHA_CONTATO item);

        CAMPANHA_CONTATO GetItemById(Int32 id);
        CAMPANHA_CONTATO CheckExist(CAMPANHA_CONTATO item);
    }
}
