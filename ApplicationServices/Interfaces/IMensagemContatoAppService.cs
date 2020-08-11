using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IMensagemContatoAppService : IAppServiceBase<MENSAGEM_CONTATO>
    {
        Int32 ValidateCreate(MENSAGEM_CONTATO item);
        Int32 ValidateEdit(MENSAGEM_CONTATO item, MENSAGEM_CONTATO itemAntes);
        Int32 ValidateDelete(MENSAGEM_CONTATO item);

        MENSAGEM_CONTATO GetItemById(Int32 id);
        MENSAGEM_CONTATO CheckExist(MENSAGEM_CONTATO item);
    }
}
