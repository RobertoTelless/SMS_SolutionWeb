using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IMensagemGrupoRepository : IRepositoryBase<MENSAGEM_GRUPO>
    {
        MENSAGEM_GRUPO CheckExist(MENSAGEM_GRUPO item);
        MENSAGEM_GRUPO GetItemById(Int32 id);
    }
}
