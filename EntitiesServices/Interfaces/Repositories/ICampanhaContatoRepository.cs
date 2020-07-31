using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ICampanhaContatoRepository : IRepositoryBase<CAMPANHA_CONTATO>
    {
        CAMPANHA_CONTATO CheckExist(CAMPANHA_CONTATO item);
        CAMPANHA_CONTATO GetItemById(Int32 id);
    }
}
