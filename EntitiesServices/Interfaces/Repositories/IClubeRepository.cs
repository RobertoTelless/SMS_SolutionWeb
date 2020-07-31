using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IClubeRepository : IRepositoryBase<CLUBE>
    {
        CLUBE CheckExist(CLUBE clube);
        List<CLUBE> GetAllItens();
        CLUBE GetItemById(Int32 id);
        List<CLUBE> GetAllItensAdm();
    }
}
