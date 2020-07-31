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
    public class CampanhaService : ServiceBase<CAMPANHA>, ICampanhaService
    {
        private readonly ICampanhaRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        private readonly ICampanhaContatoRepository _ccRepository;
        private readonly ICampanhaGrupoRepository _cgRepository;
        private readonly IContatoRepository _conRepository;
        private readonly IGrupoRepository _gruRepository;

        protected SMS_DatabaseEntities Db = new SMS_DatabaseEntities();

        public CampanhaService(ICampanhaRepository baseRepository, ILogRepository logRepository, ICampanhaContatoRepository ccRepository, ICampanhaGrupoRepository cgRepository, IContatoRepository conRepository, IGrupoRepository gruRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
            _ccRepository = ccRepository;
            _cgRepository = cgRepository;
            _conRepository = conRepository;
            _gruRepository = gruRepository;
        }

        public CAMPANHA CheckExist(CAMPANHA camp, Int32? idAss)
        {
            CAMPANHA item = _baseRepository.CheckExist(camp, idAss);
            return item;
        }

        public CAMPANHA_CONTATO CheckExist(CAMPANHA_CONTATO item, Int32? idAss)
        {
            CAMPANHA_CONTATO obj = _ccRepository.CheckExist(item);
            return obj;
        }

        public CAMPANHA_GRUPO CheckExist(CAMPANHA_GRUPO item, Int32? idAss)
        {
            CAMPANHA_GRUPO obj = _cgRepository.CheckExist(item);
            return obj;
        }

        public CAMPANHA GetItemById(Int32 id)
        {
            CAMPANHA item = _baseRepository.GetItemById(id);
            return item;
        }

        public List<CAMPANHA> GetAllItens(Int32? idAss)
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

        public List<CAMPANHA> GetAllItensAdm(Int32? idAss)
        {
            return _baseRepository.GetAllItensAdm(idAss);
        }

      
        public List<CAMPANHA> ExecuteFilter(String nome, String descricao, Int32? idAss)
        {
            return _baseRepository.ExecuteFilter(nome, descricao, idAss);

        }

        public Int32 Create(CAMPANHA item, LOG log, Int32? idAss)
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

        public Int32 Create(CAMPANHA item, Int32? idAss)
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


        public Int32 Edit(CAMPANHA item, LOG log, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CAMPANHA obj = _baseRepository.GetById(item.CAMP_CD_ID);
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

        public Int32 Edit(CAMPANHA item, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CAMPANHA obj = _baseRepository.GetById(item.CAMP_CD_ID);
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

        public Int32 Delete(CAMPANHA item, LOG log, Int32? idAss)
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

        public Int32 EditCampanhaContato(CAMPANHA_CONTATO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CAMPANHA_CONTATO obj = _ccRepository.GetById(item.CACT_CD_ID);
                    _ccRepository.Detach(obj);
                    _ccRepository.Update(item);
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

        public Int32 EditCampanhaGrupo(CAMPANHA_GRUPO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CAMPANHA_GRUPO obj = _cgRepository.GetById(item.CAGR_CD_ID);
                    _cgRepository.Detach(obj);
                    _cgRepository.Update(item);
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
