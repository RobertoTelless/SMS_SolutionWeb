using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IProfissaoAppService : IAppServiceBase<PROFISSAO>
    {
        Int32 ValidateCreate(PROFISSAO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(PROFISSAO perfil, PROFISSAO perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateDelete(PROFISSAO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(PROFISSAO perfil, USUARIO usuario, Int32? idAss);
        PROFISSAO CheckExist(PROFISSAO conta);
        List<PROFISSAO> GetAllItens();
        List<PROFISSAO> GetAllItensAdm();
        PROFISSAO GetItemById(Int32 id);
    }
}
