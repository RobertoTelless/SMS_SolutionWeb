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
    public class CampanhaContatoAppService : AppServiceBase<CAMPANHA_CONTATO>, ICampanhaContatoAppService
    {
        private readonly ICampanhaContatoService _baseService;

        public CampanhaContatoAppService(ICampanhaContatoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public CAMPANHA_CONTATO GetItemById(Int32 id)
        {
            CAMPANHA_CONTATO item = _baseService.GetItemById(id);
            return item;
        }

        public CAMPANHA_CONTATO CheckExist(CAMPANHA_CONTATO item)
        {
            CAMPANHA_CONTATO obj = _baseService.CheckExist(item);
            return obj;
        }

        public Int32 ValidateCreate(CAMPANHA_CONTATO item)
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

        public Int32 ValidateEdit(CAMPANHA_CONTATO item, CAMPANHA_CONTATO itemAntes)
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

        public Int32 ValidateDelete(CAMPANHA_CONTATO item)
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
