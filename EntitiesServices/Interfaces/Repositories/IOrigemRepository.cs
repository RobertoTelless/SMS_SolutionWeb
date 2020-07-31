using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IOrigemRepository : IRepositoryBase<ORIGEM>
    {
        ORIGEM CheckExist(ORIGEM origem);
        List<ORIGEM> GetAllItens();
        ORIGEM GetItemById(Int32 id);
        List<ORIGEM> GetAllItensAdm();
    }
}
