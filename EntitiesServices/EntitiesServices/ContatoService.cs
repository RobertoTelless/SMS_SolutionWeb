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
    public class ContatoService : ServiceBase<CONTATO>, IContatoService
    {
        private readonly IContatoRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        protected SMS_DatabaseEntities Db = new SMS_DatabaseEntities();

        public ContatoService(IContatoRepository baseRepository, ILogRepository logRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
        }

        public CONTATO CheckExist(CONTATO camp, Int32? idAss)
        {
            CONTATO item = _baseRepository.CheckExist(camp, idAss);
            return item;
        }

        public CONTATO GetItemById(Int32 id)
        {
            CONTATO item = _baseRepository.GetItemById(id);
            return item;
        }

        public List<CONTATO> GetAllItens(Int32? idAss)
        {
            return _baseRepository.GetAllItens(idAss);
        }

        public List<CONTATO> GetAllItensAdm(Int32? idAss)
        {
            return _baseRepository.GetAllItensAdm(idAss);
        }

      
        public List<CONTATO> ExecuteFilter(String nome, Int32? origem, Int32? categoria, String cargo, Int32? profissao, String cidade, Int32? uf, DateTime? data, Int32? clube, Int32? idAss)
        {
            return _baseRepository.ExecuteFilter(nome, origem, categoria,cargo, profissao, cidade, uf, data, clube, idAss);

        }

        public Int32 Create(CONTATO item, LOG log, Int32? idAss)
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

        public Int32 Create(CONTATO item, Int32? idAss)
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


        public Int32 Edit(CONTATO item, LOG log, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CONTATO obj = _baseRepository.GetById(item.CONT_CD_ID);
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

        public Int32 Edit(CONTATO item, Int32? idAss)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    CONTATO obj = _baseRepository.GetById(item.CONT_CD_ID);
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

        public Int32 Delete(CONTATO item, LOG log, Int32? idAss)
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
    }
}
