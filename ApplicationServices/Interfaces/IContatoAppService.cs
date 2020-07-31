using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IContatoAppService : IAppServiceBase<CONTATO>
    {
        Int32 ValidateCreate(CONTATO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(CONTATO perfil, CONTATO perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(CONTATO perfil, Int32? idAss);
        Int32 ValidateDelete(CONTATO perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(CONTATO perfil, USUARIO usuario, Int32? idAss);
        CONTATO CheckExist(CONTATO conta, Int32? idAss);
        List<CONTATO> GetAllItens(Int32? idAss);
        List<CONTATO> GetAllItensAdm(Int32? idAss);
        CONTATO GetItemById(Int32 id);
        Int32 ExecuteFilter(String nome, Int32? origem, Int32? categoria, String cargo, Int32? profissao, String cidade, Int32? uf, DateTime? data, Int32? clube, Int32? idAss, out List<CONTATO> objeto);
    }
}
