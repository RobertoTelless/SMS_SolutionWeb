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
    public class ProfissaoAppService : AppServiceBase<PROFISSAO>, IProfissaoAppService
    {
        private readonly IProfissaoService _baseService;

        public ProfissaoAppService(IProfissaoService baseService): base(baseService)
        {
            _baseService = baseService;
        }

        public List<PROFISSAO> GetAllItens()
        {
            List<PROFISSAO> lista = _baseService.GetAllItens();
            return lista;
        }

        public PROFISSAO CheckExist(PROFISSAO conta)
        {
            PROFISSAO item = _baseService.CheckExist(conta);
            return item;
        }

        public List<PROFISSAO> GetAllItensAdm()
        {
            List<PROFISSAO> lista = _baseService.GetAllItensAdm();
            return lista;
        }

        public PROFISSAO GetItemById(Int32 id)
        {
            PROFISSAO item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ValidateCreate(PROFISSAO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.PROF_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_NM_OPERACAO = "AddPROF",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<PROFISSAO>(item)
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

        public Int32 ValidateEdit(PROFISSAO item, PROFISSAO itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa existencia
                if (item.PROF_NM_NOME != itemAntes.PROF_NM_NOME)
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
                    LOG_NM_OPERACAO = "EditPROF",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<PROFISSAO>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<PROFISSAO>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(PROFISSAO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Checa integridade
                if (item.CONTATO.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.PROF_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelPROF",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<PROFISSAO>(item)
                };

                // Persiste
                return _baseService.Edit(item, log);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(PROFISSAO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.PROF_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    ASSI_CD_ID = idAss.Value,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatPROF",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<PROFISSAO>(item)
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
