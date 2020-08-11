using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ModelServices.Interfaces.Repositories
{
    public interface IMensagemRepository : IRepositoryBase<MENSAGEM>
    {
        MENSAGEM CheckExist(MENSAGEM campanha, Int32? idAss);
        MENSAGEM GetItemById(Int32 id);
        List<MENSAGEM> GetAllItens(Int32? idAss);
        List<MENSAGEM> GetAllItensAdm(Int32? idAss);
        List<MENSAGEM> GetAllAgendadas(Int32? idAss);
        List<MENSAGEM> GetAllEnviadas(Int32? idAss);
        List<MENSAGEM> ExecuteFilter(String nome, DateTime? data, Int32? enviada, Int32? agendada, String conteudo, Int32? idAss);
    }
}
