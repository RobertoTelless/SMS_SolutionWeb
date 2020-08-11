using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IMensagemCampanhaAppService : IAppServiceBase<MENSAGEM_CAMPANHA>
    {
        Int32 ValidateCreate(MENSAGEM_CAMPANHA item);
        Int32 ValidateEdit(MENSAGEM_CAMPANHA item, MENSAGEM_CAMPANHA itemAntes);
        Int32 ValidateDelete(MENSAGEM_CAMPANHA item);

        MENSAGEM_CAMPANHA GetItemById(Int32 id);
        MENSAGEM_CAMPANHA CheckExist(MENSAGEM_CAMPANHA item);
    }
}
