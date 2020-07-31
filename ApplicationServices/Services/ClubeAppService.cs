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
    public class ClubeAppService : AppServiceBase<CLUBE>, IClubeAppService
    {
        private readonly IClubeService _baseService;

        public ClubeAppService(IClubeService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<CLUBE> GetAllItens()
        {
            List<CLUBE> lista = _baseService.GetAllItens();
            return lista;
        }

        public CLUBE CheckExist(CLUBE conta)
        {
            CLUBE item = _baseService.CheckExist(conta);
            return item;
        }

        public List<CLUBE> GetAllItensAdm()
        {
            List<CLUBE> lista = _baseService.GetAllItensAdm();
            return lista;
        }

        public CLUBE GetItemById(Int32 id)
        {
            CLUBE item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ValidateCreate(CLUBE item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.CLUB_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "AddCLUB",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CLUBE>(item)
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

        public Int32 ValidateEdit(CLUBE item, CLUBE itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa existencia
                if (item.CLUB_NM_NOME != itemAntes.CLUB_NM_NOME)
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
                    LOG_NM_OPERACAO = "EditCLUB",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CLUBE>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<CLUBE>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(CLUBE item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa integridade
                if (item.CONTATO.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.CLUB_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelCLUB",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CLUBE>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(CLUBE item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.CLUB_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatClUB",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CLUBE>(item)
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
