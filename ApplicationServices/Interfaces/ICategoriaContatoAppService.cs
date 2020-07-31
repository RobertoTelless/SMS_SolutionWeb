using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ICategoriaContatoAppService : IAppServiceBase<CATEGORIA_CONTATO>
    {
        Int32 ValidateCreate(CATEGORIA_CONTATO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(CATEGORIA_CONTATO perfil, CATEGORIA_CONTATO perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateDelete(CATEGORIA_CONTATO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(CATEGORIA_CONTATO perfil, USUARIO usuario, Int32? idAss);
        CATEGORIA_CONTATO CheckExist(CATEGORIA_CONTATO conta);
        List<CATEGORIA_CONTATO> GetAllItens();
        List<CATEGORIA_CONTATO> GetAllItensAdm();
        CATEGORIA_CONTATO GetItemById(Int32 id);
    }
}
