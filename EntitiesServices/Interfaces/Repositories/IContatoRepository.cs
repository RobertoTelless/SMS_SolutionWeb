using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IContatoRepository : IRepositoryBase<CONTATO>
    {
        CONTATO CheckExist(CONTATO contato, Int32? idAss);
        CONTATO GetItemById(Int32 id);
        List<CONTATO> GetAllItens(Int32? idAss);
        List<CONTATO> GetAllItensAdm(Int32? idAss);
        List<CONTATO> ExecuteFilter(String nome, Int32? origem, Int32? categoria, String cargo, Int32? profissao, String cidade, Int32? uf, DateTime? data, Int32? clube, Int32? idAss);
    }
}
