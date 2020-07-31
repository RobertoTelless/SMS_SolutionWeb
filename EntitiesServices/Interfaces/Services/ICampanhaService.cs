using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface ICampanhaService : IServiceBase<CAMPANHA>
    {
        Int32 Create(CAMPANHA item, LOG log, Int32? idAss);
        Int32 Create(CAMPANHA item, Int32? idAss);
        Int32 Edit(CAMPANHA item, LOG log, Int32? idAss);
        Int32 Edit(CAMPANHA item, Int32? idAss);
        Int32 Delete(CAMPANHA item, LOG log, Int32? idAss);
        Int32 EditCampanhaContato(CAMPANHA_CONTATO item);
        Int32 EditCampanhaGrupo(CAMPANHA_GRUPO item);

        CAMPANHA CheckExist(CAMPANHA item, Int32? idAss);
        CAMPANHA GetItemById(Int32 id);
        List<CAMPANHA> GetAllItens(Int32? idAss);
        List<CAMPANHA> GetAllItensAdm(Int32? idAss);
        List<CAMPANHA> ExecuteFilter(String nome, String descricao, Int32? idAss);
        List<CONTATO> GetAllContatos(Int32 id);
        CAMPANHA_CONTATO CheckExist(CAMPANHA_CONTATO item, Int32? idAss);
        List<GRUPO> GetAllGrupos(Int32 id);
        CAMPANHA_GRUPO CheckExist(CAMPANHA_GRUPO item, Int32? idAss);
    }
}
