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
    public class CategoriaContatoAppService : AppServiceBase<CATEGORIA_CONTATO>, ICategoriaContatoAppService
    {
        private readonly ICategoriaContatoService _baseService;

        public CategoriaContatoAppService(ICategoriaContatoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<CATEGORIA_CONTATO> GetAllItens()
        {
            List<CATEGORIA_CONTATO> lista = _baseService.GetAllItens();
            return lista;
        }

        public CATEGORIA_CONTATO CheckExist(CATEGORIA_CONTATO conta)
        {
            CATEGORIA_CONTATO item = _baseService.CheckExist(conta);
            return item;
        }

        public List<CATEGORIA_CONTATO> GetAllItensAdm()
        {
            List<CATEGORIA_CONTATO> lista = _baseService.GetAllItensAdm();
            return lista;
        }

        public CATEGORIA_CONTATO GetItemById(Int32 id)
        {
            CATEGORIA_CONTATO item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ValidateCreate(CATEGORIA_CONTATO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.CACO_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "AddCACO",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CATEGORIA_CONTATO>(item)
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

        public Int32 ValidateEdit(CATEGORIA_CONTATO item, CATEGORIA_CONTATO itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa existencia
                if (item.CACO_NM_NOME != itemAntes.CACO_NM_NOME)
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
                    LOG_NM_OPERACAO = "EditCACO",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CATEGORIA_CONTATO>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<CATEGORIA_CONTATO>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(CATEGORIA_CONTATO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa integridade
                if (item.CONTATO.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.CACO_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelCACO",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CATEGORIA_CONTATO>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(CATEGORIA_CONTATO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.CACO_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatCACO",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CATEGORIA_CONTATO>(item)
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
