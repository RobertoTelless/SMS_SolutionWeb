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
    public class MensagemCampanhaService : ServiceBase<MENSAGEM_CAMPANHA>, IMensagemCampanhaService
    {
        private readonly IMensagemCampanhaRepository _baseRepository;
        private readonly ILogRepository _logRepository;
        protected SMS_DatabaseEntities Db = new SMS_DatabaseEntities();

        public MensagemCampanhaService(IMensagemCampanhaRepository baseRepository, ILogRepository logRepository) : base(baseRepository)
        {
            _baseRepository = baseRepository;
            _logRepository = logRepository;
        }

        public MENSAGEM_CAMPANHA CheckExist(MENSAGEM_CAMPANHA item)
        {
            MENSAGEM_CAMPANHA obj = _baseRepository.CheckExist(item);
            return obj;
        }

        public MENSAGEM_CAMPANHA GetItemById(Int32 id)
        {
            MENSAGEM_CAMPANHA item = _baseRepository.GetItemById(id);
            return item;
        }

        public Int32 Create(MENSAGEM_CAMPANHA item)
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

        public Int32 Edit(MENSAGEM_CAMPANHA item)
        {
            using (DbContextTransaction transaction = Db.Database.BeginTransaction(IsolationLevel.ReadCommitted))
            {
                try
                {
                    MENSAGEM_CAMPANHA obj = _baseRepository.GetById(item.MECA_CD_ID);
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

        public Int32 Delete(MENSAGEM_CAMPANHA item)
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
