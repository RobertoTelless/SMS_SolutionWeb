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
    public class AssinanteAppService : AppServiceBase<ASSINANTE>, IAssinanteAppService
    {
        private readonly IAssinanteService _baseService;
        private readonly IUsuarioService _usuService;

        public AssinanteAppService(IAssinanteService baseService, IUsuarioService usuService): base(baseService)
        {
            _baseService = baseService;
            _usuService = usuService;
        }

        public ASSINANTE CheckExist(ASSINANTE conta)
        {
            ASSINANTE item = _baseService.CheckExist(conta);
            return item;
        }

        public List<ASSINANTE> GetAllItens()
        {
            List<ASSINANTE> lista = _baseService.GetAllItens();
            return lista;
        }

        public List<ASSINANTE> GetAllItensAdm()
        {
            List<ASSINANTE> lista = _baseService.GetAllItensAdm();
            return lista;
        }

        public ASSINANTE_ANEXO GetAnexoById(Int32 id)
        {
            return _baseService.GetAnexoById(id);
        }

        public ASSINANTE GetItemById(Int32 id)
        {
            ASSINANTE item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ExecuteFilter(Int32? tipo, String nome, out List<ASSINANTE> objeto)
        {
            try
            {
                objeto = new List<ASSINANTE>();
                Int32 volta = 0;

                // Processa filtro
                objeto = _baseService.ExecuteFilter(tipo, nome);
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

        public Int32 ValidateCreate(ASSINANTE item, USUARIO usuario)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.ASSI_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = 3,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "AddASSI",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<ASSINANTE>(item)
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

        public Int32 ValidateEdit(ASSINANTE item, ASSINANTE itemAntes, USUARIO usuario)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = 3,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "EditASSI",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<ASSINANTE>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<ASSINANTE>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(ASSINANTE item)
        {
            try
            {
                // Monta Log
                // Persiste
                return _baseService.Edit(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(ASSINANTE item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial
                if (item.USUARIO.Count > 2)
                {
                    return 1;
                }

                // Acerta campos
                item.ASSI_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = 3,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelASSI",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<ASSINANTE>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(ASSINANTE item, USUARIO usuario)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.ASSI_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = 3,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatASSI",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<ASSINANTE>(item)
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
