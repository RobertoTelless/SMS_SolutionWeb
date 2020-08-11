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
    public class MensagemContatoService : ServiceBase<MENSAGEM_CONTATO>, IMensagemContatoService
    {
        private readonly IMensagemContatoRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        protected SMS_DatabaseEntities Db = new SMS_DatabaseEntities();

        public MensagemContatoService(IMensagemContatoRepository baseRepository, ILogRepository logRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
        }

        public MENSAGEM_CONTATO CheckExist(MENSAGEM_CONTATO item)
        {
            MENSAGEM_CONTATO obj = _baseRepository.CheckExist(item);
            return obj;
        }

        public MENSAGEM_CONTATO GetItemById(Int32 id)
        {
            MENSAGEM_CONTATO item = _baseRepository.GetItemById(id);
            return item;
        }

        public Int32 Create(MENSAGEM_CONTATO item)
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

        public Int32 Edit(MENSAGEM_CONTATO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    MENSAGEM_CONTATO obj = _baseRepository.GetById(item.MECO_CD_ID);
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

        public Int32 Delete(MENSAGEM_CONTATO item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
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
