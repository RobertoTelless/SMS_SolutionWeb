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
    public class MensagemGrupoAppService : AppServiceBase<MENSAGEM_GRUPO>, IMensagemGrupoAppService
    {
        private readonly IMensagemGrupoService _baseService;

        public MensagemGrupoAppService(IMensagemGrupoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public MENSAGEM_GRUPO GetItemById(Int32 id)
        {
            MENSAGEM_GRUPO item = _baseService.GetItemById(id);
            return item;
        }

        public MENSAGEM_GRUPO CheckExist(MENSAGEM_GRUPO item)
        {
            MENSAGEM_GRUPO obj = _baseService.CheckExist(item);
            return obj;
        }

        public Int32 ValidateCreate(MENSAGEM_GRUPO item)
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

        public Int32 ValidateEdit(MENSAGEM_GRUPO item, MENSAGEM_GRUPO itemAntes)
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

        public Int32 ValidateDelete(MENSAGEM_GRUPO item)
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
