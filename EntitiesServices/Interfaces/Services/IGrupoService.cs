using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IGrupoService : IServiceBase<GRUPO>
    {
        Int32 Create(GRUPO item, LOG log, Int32? idAss);
        Int32 Create(GRUPO item, Int32? idAss);
        Int32 Edit(GRUPO item, LOG log, Int32? idAss);
        Int32 Edit(GRUPO item, Int32? idAss);
        Int32 Delete(GRUPO item, LOG log, Int32? idAss);
        Int32 EditGrupoContato(GRUPO_CONTATO item);

        GRUPO CheckExist(GRUPO item, Int32? idAss);
        GRUPO_CONTATO CheckExist(GRUPO_CONTATO item, Int32? idAss);
        GRUPO GetItemById(Int32 id);
        List<GRUPO> GetAllItens(Int32? idAss);
        List<GRUPO> GetAllItensAdm(Int32? idAss);
        List<GRUPO> ExecuteFilter(String nome, Int32? idAss);
        List<CONTATO> GetAllContatos(Int32 id);
    }
}
