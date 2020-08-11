using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IMensagemGrupoService : IServiceBase<MENSAGEM_GRUPO>
    {
        Int32 Create(MENSAGEM_GRUPO item);
        Int32 Edit(MENSAGEM_GRUPO item);
        Int32 Delete(MENSAGEM_GRUPO item);
        MENSAGEM_GRUPO CheckExist(MENSAGEM_GRUPO item);
        MENSAGEM_GRUPO GetItemById(Int32 id);
    }
}
