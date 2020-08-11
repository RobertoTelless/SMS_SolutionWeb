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
    public class MensagemCampanhaAppService : AppServiceBase<MENSAGEM_CAMPANHA>, IMensagemCampanhaAppService
    {
        private readonly IMensagemCampanhaService _baseService;

        public MensagemCampanhaAppService(IMensagemCampanhaService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public MENSAGEM_CAMPANHA GetItemById(Int32 id)
        {
            MENSAGEM_CAMPANHA item = _baseService.GetItemById(id);
            return item;
        }

        public MENSAGEM_CAMPANHA CheckExist(MENSAGEM_CAMPANHA item)
        {
            MENSAGEM_CAMPANHA obj = _baseService.CheckExist(item);
            return obj;
        }

        public Int32 ValidateCreate(MENSAGEM_CAMPANHA item)
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

        public Int32 ValidateEdit(MENSAGEM_CAMPANHA item, MENSAGEM_CAMPANHA itemAntes)
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

        public Int32 ValidateDelete(MENSAGEM_CAMPANHA item)
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
