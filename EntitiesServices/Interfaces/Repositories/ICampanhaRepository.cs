using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface ICampanhaRepository : IRepositoryBase<CAMPANHA>
    {
        CAMPANHA CheckExist(CAMPANHA campanha, Int32? idAss);
        CAMPANHA GetItemById(Int32 id);
        List<CAMPANHA> GetAllItens(Int32? idAss);
        List<CAMPANHA> GetAllItensAdm(Int32? idAss);
        List<CAMPANHA> ExecuteFilter(String nome, String descricao, Int32? idAss);
    }
}
