using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface ICampanhaAppService : IAppServiceBase<CAMPANHA>
    {
        Int32 ValidateCreate(CAMPANHA perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(CAMPANHA perfil, CAMPANHA perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(CAMPANHA perfil, Int32? idAss);
        Int32 ValidateDelete(CAMPANHA perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(CAMPANHA perfil, USUARIO usuario, Int32? idAss);
        Int32 IncluirCampanhaContato(CAMPANHA item, USUARIO usuario, Int32? idAss);
        Int32 IncluirCampanhaGrupo(CAMPANHA item, USUARIO usuario, Int32? idAss);

        CAMPANHA CheckExist(CAMPANHA conta, Int32? idAss);
        List<CAMPANHA> GetAllItens(Int32? idAss);
        List<CAMPANHA> GetAllItensAdm(Int32? idAss);
        CAMPANHA GetItemById(Int32 id);
        Int32 ExecuteFilter(String nome, String descricao, Int32? idAss, out List<CAMPANHA> objeto);
        List<CONTATO> GetAllContatos(Int32 id);
        List<GRUPO> GetAllGrupos(Int32 id);
        Int32 ValidateEditCampanhaContato(CAMPANHA_CONTATO item);
        Int32 ValidateEditCampanhaGrupo(CAMPANHA_GRUPO item);
    }
}
