using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IMensagemService : IServiceBase<MENSAGEM>
    {
        Int32 Create(MENSAGEM item, LOG log, Int32? idAss);
        Int32 Create(MENSAGEM item, Int32? idAss);
        Int32 Edit(MENSAGEM item, LOG log, Int32? idAss);
        Int32 Edit(MENSAGEM item, Int32? idAss);
        Int32 Delete(MENSAGEM item, LOG log, Int32? idAss);
        Int32 EditMensagemContato(MENSAGEM_CONTATO item);
        Int32 EditMensagemGrupo(MENSAGEM_GRUPO item);
        Int32 EditMensagemCampanha(MENSAGEM_CAMPANHA item);

        MENSAGEM CheckExist(MENSAGEM item, Int32? idAss);
        MENSAGEM GetItemById(Int32 id);
        List<MENSAGEM> GetAllItens(Int32? idAss);
        List<MENSAGEM> GetAllItensAdm(Int32? idAss);
        List<MENSAGEM> GetAllAgendadas(Int32? idAss);
        List<MENSAGEM> GetAllEnviadas(Int32? idAss);
        List<MENSAGEM> ExecuteFilter(String nome, DateTime? data, Int32? enviada, Int32? agendada, String conteudo, Int32? idAss);

        MENSAGEM_ANEXO GetAnexoById(Int32 id);
        List<CONTATO> GetAllContatos(Int32 id);
        MENSAGEM_CONTATO CheckExist(MENSAGEM_CONTATO item, Int32? idAss);
        List<GRUPO> GetAllGrupos(Int32 id);
        MENSAGEM_GRUPO CheckExist(MENSAGEM_GRUPO item, Int32? idAss);
        List<CAMPANHA> GetAllCampanhas(Int32 id);
        MENSAGEM_CAMPANHA CheckExist(MENSAGEM_CAMPANHA item, Int32? idAss);
    }
}
