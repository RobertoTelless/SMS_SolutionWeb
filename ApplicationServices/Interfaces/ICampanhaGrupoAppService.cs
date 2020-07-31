using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ICampanhaGrupoAppService : IAppServiceBase<CAMPANHA_GRUPO>
    {
        Int32 ValidateCreate(CAMPANHA_GRUPO item);
        Int32 ValidateEdit(CAMPANHA_GRUPO item, CAMPANHA_GRUPO itemAntes);
        Int32 ValidateDelete(CAMPANHA_GRUPO item);

        CAMPANHA_GRUPO GetItemById(Int32 id);
        CAMPANHA_GRUPO CheckExist(CAMPANHA_GRUPO item);
    }
}
