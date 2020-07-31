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
    public class TemplateAppService : AppServiceBase<TEMPLATE>, ITemplateAppService
    {
        private readonly ITemplateService _baseService;

        public TemplateAppService(ITemplateService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<TEMPLATE> GetAllItens(Int32? idAss)
        {
            List<TEMPLATE> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<TEMPLATE> GetAllItensCampanha(Int32? idCampanha, Int32? idAss)
        {
            List<TEMPLATE> lista = _baseService.GetAllItensCampanha(idCampanha, idAss);
            return lista;
        }

        public TEMPLATE CheckExist(TEMPLATE conta, Int32? idAss)
        {
            TEMPLATE item = _baseService.CheckExist(conta, idAss);
            return item;
        }

        public List<TEMPLATE> GetAllItensAdm(Int32? idAss)
        {
            List<TEMPLATE> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public TEMPLATE GetItemById(Int32 id)
        {
            TEMPLATE item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ExecuteFilter(String nome, String conteudo, String sigla, Int32? idAss, out List<TEMPLATE> objeto)
        {
            try
            {
                objeto = new List<TEMPLATE>();
                Int32 volta = 0;

                // Processa filtro
                objeto = _baseService.ExecuteFilter(nome, conteudo, sigla, idAss);
                if (objeto.Count == 0)
                {
                    volta = 1;
                }
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateCreate(TEMPLATE item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, idAss) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.ASSI_CD_ID = idAss.Value;
                item.TEMP_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "AddTEMP",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TEMPLATE>(item)
                };

                // Persiste
                Int32 volta = _baseService.Create(item, log, idAss);
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(TEMPLATE item, TEMPLATE itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "EditTEMP",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TEMPLATE>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<TEMPLATE>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(TEMPLATE item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa integridade
                //if (item.CONTRATO.Count > 0)
                //{
                //    return 1;
                //}              
                
                // Acerta campos
                item.TEMP_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelTEMP",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TEMPLATE>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(TEMPLATE item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.TEMP_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatTEMP",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<TEMPLATE>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
