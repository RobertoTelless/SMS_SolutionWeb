using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ICampanhaGrupoRepository : IRepositoryBase<CAMPANHA_GRUPO>
    {
        CAMPANHA_GRUPO CheckExist(CAMPANHA_GRUPO item);
        CAMPANHA_GRUPO GetItemById(Int32 id);
    }
}
