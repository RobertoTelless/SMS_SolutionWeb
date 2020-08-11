using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;
using ModelServices.Interfaces.Repositories;
using ModelServices.Interfaces.EntitiesServices;
using CrossCutting;
using System.Data.Entity;
using System.Data;

namespace ModelServices.EntitiesServices
{
    public class MensagemService : ServiceBase<MENSAGEM>, IMensagemService
    {
        private readonly IMensagemRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        private readonly IMensagemContatoRepository _mcRepository;
        private readonly IMensagemGrupoRepository _mgRepository;
        private readonly IMensagemCampanhaRepository _mpRepository;
        private readonly IContatoRepository _conRepository;
        private readonly IGrupoRepository _gruRepository;
        private readonly ICampanhaRepository _camRepository;
        private readonly IMensagemAnexoRepository _anexoRepository;

        protected SMS_DatabaseEntities Db = new SMS_DatabaseEntities();

        public MensagemService(IMensagemRepository baseRepository, ILogRepository logRepository, IMensagemContatoRepository mcRepository, IMensagemGrupoRepository mgRepository, IMensagemCampanhaRepository mpRepository, IContatoRepository conRepository, IGrupoRepository gruRepository, ICampanhaRepository camRepository, IMensagemAnexoRepository anexoRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
            _mcRepository = mcRepository;
            _mgRepository = mgRepository;
            _mpRepository = mpRepository;
            _conRepository = conRepository;
            _gruRepository = gruRepository;
            _camRepository = camRepository;
            _anexoRepository = anexoRepository;
        }

        public MENSAGEM CheckExist(MENSAGEM camp, Int32? idAss)
        {
            MENSAGEM item = _baseRepository.CheckExist(camp, idAss);
            return item;
        }

        public MENSAGEM_CONTATO CheckExist(MENSAGEM_CONTATO item, Int32? idAss)
        {
            MENSAGEM_CONTATO obj = _mcRepository.CheckExist(item);
            return obj;
        }

        public MENSAGEM_GRUPO CheckExist(MENSAGEM_GRUPO item, Int32? idAss)
        {
            MENSAGEM_GRUPO obj = _mgRepository.CheckExist(item);
            return obj;
        }

        public MENSAGEM_CAMPANHA CheckExist(MENSAGEM_CAMPANHA item, Int32? idAss)
        {
            MENSAGEM_CAMPANHA obj = _mpRepository.CheckExist(item);
            return obj;
        }

        public MENSAGEM GetItemById(Int32 id)
        {
            MENSAGEM item = _baseRepository.GetItemById(id);
            return item;
        }

        public List<MENSAGEM> GetAllItens(Int32? idAss)
        {
            return _baseRepository.GetAllItens(idAss);
        }

        public List<CONTATO> GetAllContatos(Int32 id)
        {
            return _conRepository.GetAllItens(id);
        }

        public List<GRUPO> GetAllGrupos(Int32 id)
        {
            return _gruRepository.GetAllItens(id);
        }

        public List<CAMPANHA> GetAllCampanhas(Int32 id)
        {
            return _camRepository.GetAllItens(id);
        }

        public List<MENSAGEM> GetAllItensAdm(Int32? idAss)
        {
            return _baseRepository.GetAllItensAdm(idAss);
        }

        public List<MENSAGEM> GetAllAgendadas(Int32? idAss)
        {
            return _baseRepository.GetAllAgendadas(idAss);
        }

        public List<MENSAGEM> GetAllEnviadas(Int32? idAss)
        {
            return _baseRepository.GetAllEnviadas(idAss);
        }

        public MENSAGEM_ANEXO GetAnexoById(Int32 id)
        {
            return _anexoRepository.GetItemById(id);
        }

        public List<MENSAGEM> ExecuteFilter(String nome, DateTime? data, Int32? enviada, Int32? agendada, String conteudo, Int32? idAss)
        {
            return _baseRepository.ExecuteFilter(nome, data, enviada, agendada, conteudo, idAss);

        }

        public Int32 Create(MENSAGEM item, LOG log, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _logRepository.Add(log);
                    _baseRepository.Add(item);
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

        public Int32 Create(MENSAGEM item, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _baseRepository.Add(item);
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


        public Int32 Edit(MENSAGEM item, LOG log, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    MENSAGEM obj = _baseRepository.GetById(item.MENS_CD_ID);
                    _baseRepository.Detach(obj);
                    _logRepository.Add(log);
                    _baseRepository.Update(item);
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

        public Int32 Edit(MENSAGEM item, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    MENSAGEM obj = _baseRepository.GetById(item.MENS_CD_ID);
                    _baseRepository.Detach(obj);
                    _baseRepository.Update(item);
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

        public Int32 Delete(MENSAGEM item, LOG log, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    _logRepository.Add(log);
                    _baseRepository.Remove(item);
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

        public Int32 EditMensagemContato(MENSAGEM_CONTATO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    MENSAGEM_CONTATO obj = _mcRepository.GetById(item.MECO_CD_ID);
                    _mcRepository.Detach(obj);
                    _mcRepository.Update(item);
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

        public Int32 EditMensagemGrupo(MENSAGEM_GRUPO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    MENSAGEM_GRUPO obj = _mgRepository.GetById(item.MEGR_CD_ID);
                    _mgRepository.Detach(obj);
                    _mgRepository.Update(item);
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

        public Int32 EditMensagemCampanha(MENSAGEM_CAMPANHA item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    MENSAGEM_CAMPANHA obj = _mpRepository.GetById(item.MECA_CD_ID);
                    _mpRepository.Detach(obj);
                    _mpRepository.Update(item);
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

    }
}
