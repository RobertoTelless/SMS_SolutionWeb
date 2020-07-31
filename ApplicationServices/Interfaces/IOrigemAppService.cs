using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IOrigemAppService : IAppServiceBase<ORIGEM>
    {
        Int32 ValidateCreate(ORIGEM perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(ORIGEM perfil, ORIGEM perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateDelete(ORIGEM perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(ORIGEM perfil, USUARIO usuario, Int32? idAss);
        ORIGEM CheckExist(ORIGEM conta);
        List<ORIGEM> GetAllItens();
        List<ORIGEM> GetAllItensAdm();
        ORIGEM GetItemById(Int32 id);
    }
}
