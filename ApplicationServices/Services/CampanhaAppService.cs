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
    public class CampanhaAppService : AppServiceBase<CAMPANHA>, ICampanhaAppService
    {
        private readonly ICampanhaService _baseService;
        private readonly IUsuarioService _usuService;

        public CampanhaAppService(ICampanhaService baseService, IUsuarioService usuService): base(baseService)
        {
            _baseService = baseService;
            _usuService = usuService;
        }

        public CAMPANHA CheckExist(CAMPANHA conta, Int32? idAss)
        {
            CAMPANHA item = _baseService.CheckExist(conta, idAss);
            return item;
        }

        public List<CAMPANHA> GetAllItens(Int32? idAss)
        {
            List<CAMPANHA> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<CAMPANHA> GetAllItensAdm(Int32? idAss)
        {
            List<CAMPANHA> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public CAMPANHA GetItemById(Int32 id)
        {
            CAMPANHA item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ExecuteFilter(String nome, String descricao, Int32? idAss, out List<CAMPANHA> objeto)
        {
            try
            {
                objeto = new List<CAMPANHA>();
                Int32 volta = 0;

                // Processa filtro
                objeto = _baseService.ExecuteFilter(nome, descricao, idAss);
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

        public Int32 ValidateCreate(CAMPANHA item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, idAss) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.CAMP_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "AddCAMP",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CAMPANHA>(item)
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

        public Int32 ValidateEdit(CAMPANHA item, CAMPANHA itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "EditCAMP",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CAMPANHA>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<CAMPANHA>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(CAMPANHA item, Int32? idAss)
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

        public Int32 ValidateDelete(CAMPANHA item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial
                if (item.CAMPANHA_CONTATO.Count > 0)
                {
                    return 1;
                }
                if (item.CAMPANHA_GRUPO.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.CAMP_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelCAMP",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CAMPANHA>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(CAMPANHA item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.CAMP_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatCAMP",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<CAMPANHA>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 IncluirCampanhaContato(CAMPANHA item, USUARIO usuario, Int32? idAss)
        {
            try
            {

                // Cria registro
                CAMPANHA rot = _baseService.GetItemById(item.CAMP_CD_ID);
                item.CAMP_IN_ATIVO = 1;
                CAMPANHA_CONTATO rl = new CAMPANHA_CONTATO();
                rl.CONT_CD_ID = item.CONT_CD_ID.Value;
                rl.CAMP_CD_ID = item.CAMP_CD_ID;
                rl.CACT_IN_ATIVO = 1;

                // Verifica existencia
                if (_baseService.CheckExist(rl, idAss ) != null)
                {
                    return 1;
                }

                // Inclui na coleção
                rot.CAMPANHA_CONTATO.Add(rl);

                // Persiste
                return _baseService.Edit(rot, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEditCampanhaContato(CAMPANHA_CONTATO item)
        {
            try
            {
                // Persiste
                item.CAMPANHA = null;
                item.CONTATO = null;
                return _baseService.EditCampanhaContato(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CONTATO> GetAllContatos(Int32 id)
        {
            List<CONTATO> lista = _baseService.GetAllContatos(id);
            return lista;
        }

        public Int32 IncluirCampanhaGrupo(CAMPANHA item, USUARIO usuario, Int32? idAss)
        {
            try
            {

                // Cria registro
                CAMPANHA rot = _baseService.GetItemById(item.CAMP_CD_ID);
                item.CAMP_IN_ATIVO = 1;
                CAMPANHA_GRUPO rl = new CAMPANHA_GRUPO();
                rl.GRUP_CD_ID = item.GRUP_CD_ID.Value;
                rl.CAMP_CD_ID = item.CAMP_CD_ID;
                rl.CAGR_IN_ATIVO = 1;

                // Verifica existencia
                if (_baseService.CheckExist(rl, idAss) != null)
                {
                    return 1;
                }

                // Inclui na coleção
                rot.CAMPANHA_GRUPO.Add(rl);

                // Persiste
                return _baseService.Edit(rot, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEditCampanhaGrupo(CAMPANHA_GRUPO item)
        {
            try
            {
                // Persiste
                item.CAMPANHA = null;
                item.GRUPO = null;
                return _baseService.EditCampanhaGrupo(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<GRUPO> GetAllGrupos(Int32 id)
        {
            List<GRUPO> lista = _baseService.GetAllGrupos(id);
            return lista;
        }

    }
}
