using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ICategoriaNotificacaoAppService : IAppServiceBase<CATEGORIA_NOTIFICACAO>
    {
        Int32 ValidateCreate(CATEGORIA_NOTIFICACAO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(CATEGORIA_NOTIFICACAO perfil, CATEGORIA_NOTIFICACAO perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateDelete(CATEGORIA_NOTIFICACAO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(CATEGORIA_NOTIFICACAO perfil, USUARIO usuario, Int32? idAss);
        List<CATEGORIA_NOTIFICACAO> GetAllItens();
        List<CATEGORIA_NOTIFICACAO> GetAllItensAdm();
        CATEGORIA_NOTIFICACAO GetItemById(Int32 id);
    }
}
