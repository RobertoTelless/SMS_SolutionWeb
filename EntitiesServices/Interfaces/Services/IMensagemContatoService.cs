using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IMensagemContatoService : IServiceBase<MENSAGEM_CONTATO>
    {
        Int32 Create(MENSAGEM_CONTATO item);
        Int32 Edit(MENSAGEM_CONTATO item);
        Int32 Delete(MENSAGEM_CONTATO item);
        MENSAGEM_CONTATO CheckExist(MENSAGEM_CONTATO item);
        MENSAGEM_CONTATO GetItemById(Int32 id);
    }
}
