using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IGrupoRepository : IRepositoryBase<GRUPO>
    {
        GRUPO CheckExist(GRUPO contato, Int32? idAss);
        GRUPO GetItemById(Int32 id);
        List<GRUPO> GetAllItens(Int32? idAss);
        List<GRUPO> GetAllItensAdm(Int32? idAss);
        List<GRUPO> ExecuteFilter(String nome, Int32? idAss);
    }
}
