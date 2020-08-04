using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;

namespace ModelServices.Interfaces.EntitiesServices
{
    public interface IUsuarioService : IServiceBase<USUARIO>
    {
        Boolean VerificarCredenciais(String senha, USUARIO usuario);
        USUARIO GetByEmail(String email);
        USUARIO GetByLogin(String login);
        USUARIO RetriveUserByEmail(String email);
        Int32 CreateUser(USUARIO usuario, LOG log);
        Int32 CreateUser(USUARIO usuario);
        Int32 EditUser(USUARIO usuario, LOG log);
        Int32 VerifyUserSubscription(USUARIO usuario);
        Int32 EditUser(USUARIO usuario);
        CONFIGURACAO CarregaConfiguracao();
        List<USUARIO> GetAllUsuariosAdm(Int32? idAss);
        USUARIO GetItemById(Int32 id);
        List<USUARIO> GetAllUsuarios(Int32? idAss);
        List<PERFIL> GetAllPerfis();
        List<USUARIO> GetAllItens(Int32? idAss);
        List<USUARIO> GetAllItensBloqueados(Int32? idAss);
        List<USUARIO> GetAllItensAcessoHoje(Int32? idAss);
        List<USUARIO> ExecuteFilter(Int32? perfilId, String cargo, String nome, String login, String email, Int32? idAss);
        USUARIO_ANEXO GetAnexoById(Int32 id);
        List<NOTIFICACAO> GetAllItensUser(Int32 id, Int32? idAss);
        List<NOTIFICACAO> GetNotificacaoNovas(Int32 id, Int32? idAss);
        List<NOTICIA> GetAllNoticias();
        List<UF> GetAllUF();
        USUARIO GetAdministrador(Int32? idAss);
        TEMPLATE_EMAIL GetTemplate(String code);
        List<USUARIO> GetAllUsuariosAdm();
        List<USUARIO> ExecuteFilter(Int32? perfilId, String cargo, String nome, String login, String email);
    }
}
