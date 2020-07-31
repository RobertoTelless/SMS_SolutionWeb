using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IGrupoContatoRepository : IRepositoryBase<GRUPO_CONTATO>
    {
        GRUPO_CONTATO CheckExist(GRUPO_CONTATO item);
        GRUPO_CONTATO GetItemById(Int32 id);
    }
}
