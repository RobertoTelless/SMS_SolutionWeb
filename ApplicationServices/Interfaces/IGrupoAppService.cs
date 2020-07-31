using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IGrupoAppService : IAppServiceBase<GRUPO>
    {
        Int32 ValidateCreate(GRUPO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(GRUPO perfil, GRUPO perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(GRUPO perfil, Int32? idAss);
        Int32 ValidateDelete(GRUPO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(GRUPO perfil, USUARIO usuario, Int32? idAss);
        Int32 IncluirGrupoContato(GRUPO item, USUARIO usuario, Int32? idAss);

        GRUPO CheckExist(GRUPO conta, Int32? idAss);
        List<GRUPO> GetAllItens(Int32? idAss);
        List<GRUPO> GetAllItensAdm(Int32? idAss);
        GRUPO GetItemById(Int32 id);
        Int32 ExecuteFilter(String nome, Int32? idAss, out List<GRUPO> objeto);
        List<CONTATO> GetAllContatos(Int32 id);
        Int32 ValidateEditGrupoContato(GRUPO_CONTATO item);
    }
}
