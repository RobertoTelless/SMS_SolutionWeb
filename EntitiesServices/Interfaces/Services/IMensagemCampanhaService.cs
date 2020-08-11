using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IMensagemCampanhaService : IServiceBase<MENSAGEM_CAMPANHA>
    {
        Int32 Create(MENSAGEM_CAMPANHA item);
        Int32 Edit(MENSAGEM_CAMPANHA item);
        Int32 Delete(MENSAGEM_CAMPANHA item);
        MENSAGEM_CAMPANHA CheckExist(MENSAGEM_CAMPANHA item);
        MENSAGEM_CAMPANHA GetItemById(Int32 id);
    }
}
