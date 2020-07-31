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
    public class CategoriaNotificacaoAppService : AppServiceBase<CATEGORIA_NOTIFICACAO>, ICategoriaNotificacaoAppService
    {
        private readonly ICategoriaNotificacaoService _baseService;

        public CategoriaNotificacaoAppService(ICategoriaNotificacaoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<CATEGORIA_NOTIFICACAO> GetAllItens()
        {
            List<CATEGORIA_NOTIFICACAO> lista = _baseService.GetAllItens();
            return lista;
        }

        public List<CATEGORIA_NOTIFICACAO> GetAllItensAdm()
        {
            List<CATEGORIA_NOTIFICACAO> lista = _baseService.GetAllItensAdm();
            return lista;
        }

        public CATEGORIA_NOTIFICACAO GetItemById(Int32 id)
        {
            CATEGORIA_NOTIFICACAO item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ValidateCreate(CATEGORIA_NOTIFICACAO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia

                // Completa objeto
                item.CANO_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "AddCANO",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CATEGORIA_NOTIFICACAO>(item)
                };

                // Persiste
                Int32 volta = _baseService.Create(item, log);
                return volta;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(CATEGORIA_NOTIFICACAO item, CATEGORIA_NOTIFICACAO itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "EditCANO",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CATEGORIA_NOTIFICACAO>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<CATEGORIA_NOTIFICACAO>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(CATEGORIA_NOTIFICACAO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa integridade
                //if (item.CONTRATO.Count > 0)
                //{
                //    return 1;
                //}              
                
                // Acerta campos
                item.CANO_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelCANO",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CATEGORIA_NOTIFICACAO>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(CATEGORIA_NOTIFICACAO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.CANO_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatCANO",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CATEGORIA_NOTIFICACAO>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
