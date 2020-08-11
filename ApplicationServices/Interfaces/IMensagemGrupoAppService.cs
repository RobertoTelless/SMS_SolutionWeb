using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IMensagemGrupoAppService : IAppServiceBase<MENSAGEM_GRUPO>
    {
        Int32 ValidateCreate(MENSAGEM_GRUPO item);
        Int32 ValidateEdit(MENSAGEM_GRUPO item, MENSAGEM_GRUPO itemAntes);
        Int32 ValidateDelete(MENSAGEM_GRUPO item);

        MENSAGEM_GRUPO GetItemById(Int32 id);
        MENSAGEM_GRUPO CheckExist(MENSAGEM_GRUPO item);
    }
}
