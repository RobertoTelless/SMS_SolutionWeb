using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IClubeService : IServiceBase<CLUBE>
    {
        Int32 Create(CLUBE item, LOG log);
        Int32 Create(CLUBE item);
        Int32 Edit(CLUBE item, LOG log);
        Int32 Edit(CLUBE item);
        Int32 Delete(CLUBE item, LOG log);
        CLUBE CheckExist(CLUBE item);
        CLUBE GetItemById(Int32 id);
        List<CLUBE> GetAllItens();
        List<CLUBE> GetAllItensAdm();
    }
}
