using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;
using EntitiesServices.Work_Classes;
using ApplicationServices.Interfaces;
using ModelServices.Interfaces.EntitiesServices;
using CrossCutting;
using System.Text.RegularExpressions;

namespace ApplicationServices.Services
{
    public class MensagemContatoAppService : AppServiceBase<MENSAGEM_CONTATO>, IMensagemContatoAppService
    {
        private readonly IMensagemContatoService _baseService;

        public MensagemContatoAppService(IMensagemContatoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public MENSAGEM_CONTATO GetItemById(Int32 id)
        {
            MENSAGEM_CONTATO item = _baseService.GetItemById(id);
            return item;
        }

        public MENSAGEM_CONTATO CheckExist(MENSAGEM_CONTATO item)
        {
            MENSAGEM_CONTATO obj = _baseService.CheckExist(item);
            return obj;
        }

        public Int32 ValidateCreate(MENSAGEM_CONTATO item)
        {
            try
            {
                // Verifica existencia prévia

                // Completa objeto

                // Persiste
                Int32 volta = _baseService.Create(item);
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(MENSAGEM_CONTATO item, MENSAGEM_CONTATO itemAntes)
        {
            try
            {
                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(MENSAGEM_CONTATO item)
        {
            try
            {
                // Persiste
                return _baseService.Delete(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
