using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IClubeAppService : IAppServiceBase<CLUBE>
    {
        Int32 ValidateCreate(CLUBE perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(CLUBE perfil, CLUBE perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateDelete(CLUBE perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(CLUBE perfil, USUARIO usuario, Int32? idAss);
        CLUBE CheckExist(CLUBE conta);
        List<CLUBE> GetAllItens();
        List<CLUBE> GetAllItensAdm();
        CLUBE GetItemById(Int32 id);
    }
}
