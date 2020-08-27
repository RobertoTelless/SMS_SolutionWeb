using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace ApplicationServices.Interfaces
{
    public interface IMensagemAppService : IAppServiceBase<MENSAGEM>
    {
        String ValidateCreate(MENSAGEM perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(MENSAGEM perfil, MENSAGEM perfilAntes, USUARIO usuario, Int32? idAss);
        Int32 ValidateEdit(MENSAGEM perfil, Int32? idAss);
        Int32 ValidateDelete(MENSAGEM perfil, USUARIO usuario, Int32? idAss);
        Int32 ValidateReativar(MENSAGEM perfil, USUARIO usuario, Int32? idAss);
        Int32 IncluirMensagemContato(MENSAGEM item, USUARIO usuario, Int32? idAss);
        Int32 IncluirMensagemGrupo(MENSAGEM item, USUARIO usuario, Int32? idAss);
        Int32 IncluirMensagemCampanha(MENSAGEM item, USUARIO usuario, Int32? idAss);

        MENSAGEM CheckExist(MENSAGEM conta, Int32? idAss);
        List<MENSAGEM> GetAllItens(Int32? idAss);
        List<MENSAGEM> GetAllItensAdm(Int32? idAss);
        List<MENSAGEM> GetAllAgendadas(Int32? idAss);
        List<MENSAGEM> GetAllEnviadas(Int32? idAss);
        MENSAGEM GetItemById(Int32 id);
        Int32 ExecuteFilter(String nome, DateTime? data, Int32? enviada, Int32? agendada, String conteudo, Int32? idAss, out List<MENSAGEM> objeto);

        MENSAGEM_ANEXO GetAnexoById(Int32 id);
        List<CONTATO> GetAllContatos(Int32 id);
        List<GRUPO> GetAllGrupos(Int32 id);
        List<CAMPANHA> GetAllCampanhas(Int32 id);
        Int32 ValidateEditMensagemContato(MENSAGEM_CONTATO item);
        Int32 ValidateEditMensagemGrupo(MENSAGEM_GRUPO item);
        Int32 ValidateEditMensagemCampanha(MENSAGEM_CAMPANHA item);
    }
}
