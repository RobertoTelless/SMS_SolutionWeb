using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IOrigemService : IServiceBase<ORIGEM>
    {
        Int32 Create(ORIGEM item, LOG log);
        Int32 Create(ORIGEM item);
        Int32 Edit(ORIGEM item, LOG log);
        Int32 Edit(ORIGEM item);
        Int32 Delete(ORIGEM item, LOG log);
        ORIGEM CheckExist(ORIGEM item);
        ORIGEM GetItemById(Int32 id);
        List<ORIGEM> GetAllItens();
        List<ORIGEM> GetAllItensAdm();
    }
}
