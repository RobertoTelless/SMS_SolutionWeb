using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using EntitiesServices.Model;
using ModelServices.Interfaces.Repositories;
using ModelServices.Interfaces.EntitiesServices;
using CrossCutting;
using System.Data.Entity;
using System.Data;

namespace ModelServices.EntitiesServices
{
    public class UsuarioService : ServiceBase<USUARIO>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPerfilRepository _perfRepository;
        private readonly ILogRepository _logRepository;
        private readonly IConfiguracaoRepository _configuracaoRepository;
        private readonly ITemplateEmailRepository _tempRepository;
        private readonly IUsuarioAnexoRepository _anexoRepository;
        private readonly INotificacaoRepository _notRepository;
        private readonly INoticiaRepository _ntcRepository;
        private readonly IUFRepository _ufRepository;
        protected SMS_DatabaseEntities Db = new SMS_DatabaseEntities();

        public UsuarioService(IUsuarioRepository usuarioRepository, ILogRepository logRepository, IConfiguracaoRepository configuracaoRepository, IPerfilRepository perfRepository, IUsuarioAnexoRepository anexoRepository, INotificacaoRepository notRepository, INoticiaRepository ntcRepository, ITemplateEmailRepository tempRepository, IUFRepository ufRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _logRepository = logRepository;
            _configuracaoRepository = configuracaoRepository;
            _perfRepository = perfRepository;
            _anexoRepository = anexoRepository;
            _notRepository = notRepository;
            _ntcRepository = ntcRepository;
            _tempRepository = tempRepository;
            _ufRepository = ufRepository;
        }

        public USUARIO RetriveUserByEmail(String email)
        {
            USUARIO usuario = _usuarioRepository.GetByEmail(email);
            return usuario;
        }

        public Boolean VerificarCredenciais (String senha, USUARIO usuario)
        {
            // Criptografa senha informada
            //String senhaCrip = Cryptography.Encode(senha);
            string senhaCrip = senha;

            // verifica senha
            if (usuario.USUA_NM_SENHA.Trim() != senhaCrip.Trim())
            {
                return false;
            }
            return true;
        }

        public USUARIO GetByEmail(String email)
        {
            return _usuarioRepository.GetByEmail(email);
        }

        public TEMPLATE_EMAIL GetTemplate(String code)
        {
            return _tempRepository.GetItemByCode(code);
        }

        public USUARIO_ANEXO GetAnexoById(Int32 id)
        {
            return _anexoRepository.GetItemById(id);
        }

        public USUARIO GetByLogin(String login)
        {
            return _usuarioRepository.GetByLogin(login);
        }

        public USUARIO GetItemById(Int32 id)
        {
            return _usuarioRepository.GetItemById(id);
        }

        public List<USUARIO> GetAllUsuariosAdm(Int32? idAss)
        {
            return _usuarioRepository.GetAllUsuariosAdm(idAss);
        }

        public List<UF> GetAllUF()
        {
            return _ufRepository.GetAllItens();
        }

        public List<USUARIO> GetAllUsuarios(Int32? idAss)
        {
            return _usuarioRepository.GetAllUsuarios(idAss);
        }

        public List<USUARIO> GetAllItens(Int32? idAss)
        {
            return _usuarioRepository.GetAllItens(idAss);
        }

        public List<USUARIO> GetAllItensBloqueados(Int32? idAss)
        {
            return _usuarioRepository.GetAllItensBloqueados(idAss);
        }

        public USUARIO GetAdministrador(Int32? idAss)
        {
            return _usuarioRepository.GetAdministrador(idAss);
        }

        public List<USUARIO> GetAllItensAcessoHoje(Int32? idAss)
        {
            return _usuarioRepository.GetAllItensAcessoHoje(idAss);
        }

        public Int32 CreateUser(USUARIO usuario, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _logRepository.Add(log);
                    _usuarioRepository.Add(usuario);
                    transaction.Commit();
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Int32 CreateUser(USUARIO usuario)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _usuarioRepository.Add(usuario);
                    transaction.Commit();
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Int32 EditUser(USUARIO usuario, LOG log)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    USUARIO obj = _usuarioRepository.GetById(usuario.USUA_CD_ID);
                    _usuarioRepository.Detach(obj);
                    _logRepository.Add(log);
                    _usuarioRepository.Update(usuario);
                    transaction.Commit();
                    return 0;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
            }
        }

        public Int32 EditUser(USUARIO usuario)
        {
            try
            {
                USUARIO obj = _usuarioRepository.GetById(usuario.USUA_CD_ID);
                _usuarioRepository.Detach(obj);
                _usuarioRepository.Update(usuario);
                return 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int32 VerifyUserSubscription(USUARIO usuario)
        {
            return 0;
        }

        public CONFIGURACAO CarregaConfiguracao()
        {
            CONFIGURACAO conf = _configuracaoRepository.GetById(1);
            return conf;
        }

        public List<USUARIO> ExecuteFilter(Int32? perfilId, String cargo, String nome, String login, String email, Int32? idAss)
        {
            List<USUARIO> lista = _usuarioRepository.ExecuteFilter(perfilId, cargo, nome, login, email, idAss);
            return lista;
        }

        public List<PERFIL> GetAllPerfis()
        {
            List<PERFIL> lista = _perfRepository.GetAll().ToList();
            return lista;
        }

        public List<NOTIFICACAO> GetAllItensUser(Int32 id, Int32? idAss)
        {
            return _notRepository.GetAllItensUser(id, idAss);
        }

        public List<NOTIFICACAO> GetNotificacaoNovas(Int32 id, Int32? idAss)
        {
            return _notRepository.GetNotificacaoNovas(id, idAss);
        }

        public List<NOTICIA> GetAllNoticias()
        {
            return _ntcRepository.GetAllItens();
        }
    }
}
