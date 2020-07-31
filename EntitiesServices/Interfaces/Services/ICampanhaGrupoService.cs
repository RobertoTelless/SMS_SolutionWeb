using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ICampanhaGrupoService : IServiceBase<CAMPANHA_GRUPO>
    {
        Int32 Create(CAMPANHA_GRUPO item);
        Int32 Edit(CAMPANHA_GRUPO item);
        Int32 Delete(CAMPANHA_GRUPO item);
        CAMPANHA_GRUPO CheckExist(CAMPANHA_GRUPO item);
        CAMPANHA_GRUPO GetItemById(Int32 id);
    }
}
