using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IContatoService : IServiceBase<CONTATO>
    {
        Int32 Create(CONTATO item, LOG log, Int32? idAss);
        Int32 Create(CONTATO item, Int32? idAss);
        Int32 Edit(CONTATO item, LOG log, Int32? idAss);
        Int32 Edit(CONTATO item, Int32? idAss);
        Int32 Delete(CONTATO item, LOG log, Int32? idAss);
        CONTATO CheckExist(CONTATO item, Int32? idAss);
        CONTATO GetItemById(Int32 id);
        List<CONTATO> GetAllItens(Int32? idAss);
        List<CONTATO> GetAllItensAdm(Int32? idAss);
        List<CONTATO> ExecuteFilter(String nome, Int32? origem, Int32? categoria, String cargo, Int32? profissao, String cidade, Int32? uf, DateTime? data, Int32? clube, Int32? idAss);
    }
}
