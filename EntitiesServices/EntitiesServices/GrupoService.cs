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
    public class GrupoService : ServiceBase<GRUPO>, IGrupoService
    {
        private readonly IGrupoRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        private readonly IGrupoContatoRepository _gcRepository;
        private readonly IContatoRepository _conRepository;

        protected SMS_DatabaseEntities Db = new SMS_DatabaseEntities();

        public GrupoService(IGrupoRepository baseRepository, ILogRepository logRepository, IGrupoContatoRepository gcRepository, IContatoRepository conRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
            _gcRepository = gcRepository;
            _conRepository = conRepository;
        }

        public GRUPO CheckExist(GRUPO camp, Int32? idAss)
        {
            GRUPO item = _baseRepository.CheckExist(camp, idAss);
            return item;
        }

        public GRUPO_CONTATO CheckExist(GRUPO_CONTATO item, Int32? idAss)
        {
            GRUPO_CONTATO obj = _gcRepository.CheckExist(item);
            return obj;
        }

        public GRUPO GetItemById(Int32 id)
        {
            GRUPO item = _baseRepository.GetItemById(id);
            return item;
        }

        public List<GRUPO> GetAllItens(Int32? idAss)
        {
            return _baseRepository.GetAllItens(idAss);
        }

        public List<CONTATO> GetAllContatos(Int32 id)
        {
            return _conRepository.GetAllItens(id);
        }

        public List<GRUPO> GetAllItensAdm(Int32? idAss)
        {
            return _baseRepository.GetAllItensAdm(idAss);
        }

      
        public List<GRUPO> ExecuteFilter(String nome, Int32? idAss)
        {
            return _baseRepository.ExecuteFilter(nome, idAss);

        }

        public Int32 Create(GRUPO item, LOG log, Int32? idAss)
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

        public Int32 Create(GRUPO item, Int32? idAss)
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


        public Int32 Edit(GRUPO item, LOG log, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    GRUPO obj = _baseRepository.GetById(item.GRUP_CD_ID);
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

        public Int32 Edit(GRUPO item, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    GRUPO obj = _baseRepository.GetById(item.GRUP_CD_ID);
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

        public Int32 Delete(GRUPO item, LOG log, Int32? idAss)
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

        public Int32 EditGrupoContato(GRUPO_CONTATO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    GRUPO_CONTATO obj = _gcRepository.GetById(item.GRCO_CD_ID);
                    _gcRepository.Detach(obj);
                    _gcRepository.Update(item);
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
