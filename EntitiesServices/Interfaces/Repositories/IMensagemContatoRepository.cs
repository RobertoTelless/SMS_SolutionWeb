using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IMensagemContatoRepository : IRepositoryBase<MENSAGEM_CONTATO>
    {
        MENSAGEM_CONTATO CheckExist(MENSAGEM_CONTATO item);
        MENSAGEM_CONTATO GetItemById(Int32 id);
    }
}
