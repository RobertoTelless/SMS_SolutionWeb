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
    public class CampanhaGrupoAppService : AppServiceBase<CAMPANHA_GRUPO>, ICampanhaGrupoAppService
    {
        private readonly ICampanhaGrupoService _baseService;

        public CampanhaGrupoAppService(ICampanhaGrupoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public CAMPANHA_GRUPO GetItemById(Int32 id)
        {
            CAMPANHA_GRUPO item = _baseService.GetItemById(id);
            return item;
        }

        public CAMPANHA_GRUPO CheckExist(CAMPANHA_GRUPO item)
        {
            CAMPANHA_GRUPO obj = _baseService.CheckExist(item);
            return obj;
        }

        public Int32 ValidateCreate(CAMPANHA_GRUPO item)
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

        public Int32 ValidateEdit(CAMPANHA_GRUPO item, CAMPANHA_GRUPO itemAntes)
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

        public Int32 ValidateDelete(CAMPANHA_GRUPO item)
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
