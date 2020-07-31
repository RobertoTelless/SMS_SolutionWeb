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
    public class OrigemAppService : AppServiceBase<ORIGEM>, IOrigemAppService
    {
        private readonly IOrigemService _baseService;

        public OrigemAppService(IOrigemService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<ORIGEM> GetAllItens()
        {
            List<ORIGEM> lista = _baseService.GetAllItens();
            return lista;
        }

        public ORIGEM CheckExist(ORIGEM conta)
        {
            ORIGEM item = _baseService.CheckExist(conta);
            return item;
        }

        public List<ORIGEM> GetAllItensAdm()
        {
            List<ORIGEM> lista = _baseService.GetAllItensAdm();
            return lista;
        }

        public ORIGEM GetItemById(Int32 id)
        {
            ORIGEM item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ValidateCreate(ORIGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.ORIG_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "AddORIG",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<ORIGEM>(item)
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

        public Int32 ValidateEdit(ORIGEM item, ORIGEM itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa existencia
                if (item.ORIG_NM_NOME != itemAntes.ORIG_NM_NOME)
                {
                    if (_baseService.CheckExist(item) != null)
                    {
                        return 1;
                    }
                }

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "EditORIG",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<ORIGEM>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<ORIGEM>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(ORIGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa integridade
                if (item.CONTATO.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.ORIG_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelORIG",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<ORIGEM>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(ORIGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.ORIG_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatORIG",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<ORIGEM>(item)
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
