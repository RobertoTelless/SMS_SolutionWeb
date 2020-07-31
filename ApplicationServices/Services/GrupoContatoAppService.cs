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
    public class GrupoContatoAppService : AppServiceBase<GRUPO_CONTATO>, IGrupoContatoAppService
    {
        private readonly IGrupoContatoService _baseService;

        public GrupoContatoAppService(IGrupoContatoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public GRUPO_CONTATO GetItemById(Int32 id)
        {
            GRUPO_CONTATO item = _baseService.GetItemById(id);
            return item;
        }

        public GRUPO_CONTATO CheckExist(GRUPO_CONTATO item)
        {
            GRUPO_CONTATO obj = _baseService.CheckExist(item);
            return obj;
        }

        public Int32 ValidateCreate(GRUPO_CONTATO item)
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

        public Int32 ValidateEdit(GRUPO_CONTATO item, GRUPO_CONTATO itemAntes)
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

        public Int32 ValidateDelete(GRUPO_CONTATO item)
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
