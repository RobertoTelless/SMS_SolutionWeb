using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IMensagemCampanhaRepository : IRepositoryBase<MENSAGEM_CAMPANHA>
    {
        MENSAGEM_CAMPANHA CheckExist(MENSAGEM_CAMPANHA item);
        MENSAGEM_CAMPANHA GetItemById(Int32 id);
    }
}
