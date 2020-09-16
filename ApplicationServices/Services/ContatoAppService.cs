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
    public class ContatoAppService : AppServiceBase<CONTATO>, IContatoAppService
    {
        private readonly IContatoService _baseService;
        private readonly IUsuarioService _usuService;

        public ContatoAppService(IContatoService baseService, IUsuarioService usuService): base(baseService)
        {
            _baseService = baseService;
            _usuService = usuService;
        }

        public CONTATO CheckExist(CONTATO conta, Int32? idAss)
        {
            CONTATO item = _baseService.CheckExist(conta, idAss);
            return item;
        }

        public List<CONTATO> GetAllItens(Int32? idAss)
        {
            List<CONTATO> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<CONTATO> GetAllItensAdm(Int32? idAss)
        {
            List<CONTATO> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public CONTATO GetItemById(Int32 id)
        {
            CONTATO item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ExecuteFilter(String nome, Int32? origem, Int32? categoria, String cargo, Int32? profissao, String cidade, Int32? uf, DateTime? data, Int32? clube, Int32? idAss, out List<CONTATO> objeto)
        {
            try
            {
                objeto = new List<CONTATO>();
                Int32 volta = 0;

                // Processa filtro
                objeto = _baseService.ExecuteFilter(nome, origem,categoria, cargo, profissao, cidade, uf, data, clube, idAss);
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

        public Int32 ValidateCreate(CONTATO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, idAss) != null)
                {
                    return 1;
                }
                if (item.CONT_NR_WHATSAPP.Substring(0,2) != "55")
                {
                    item.CONT_NR_WHATSAPP = "55" + item.CONT_NR_WHATSAPP;
                }

                // Completa objeto
                item.CONT_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "AddCONT",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CONTATO>(item)
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

        public Int32 ValidateEdit(CONTATO item, CONTATO itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "EditCONT",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CONTATO>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<CONTATO>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(CONTATO item, Int32? idAss)
        {
            try
            {
                // Monta Log
                // Persiste
                return _baseService.Edit(item, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateDelete(CONTATO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial
                if (item.CAMPANHA_CONTATO.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.CONT_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelCONT",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CONTATO>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(CONTATO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.CONT_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatCONT",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CONTATO>(item)
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
