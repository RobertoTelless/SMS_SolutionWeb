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
    public class GrupoAppService : AppServiceBase<GRUPO>, IGrupoAppService
    {
        private readonly IGrupoService _baseService;
        private readonly IUsuarioService _usuService;

        public GrupoAppService(IGrupoService baseService, IUsuarioService usuService): base(baseService)
        {
            _baseService = baseService;
            _usuService = usuService;
        }

        public GRUPO CheckExist(GRUPO conta, Int32? idAss)
        {
            GRUPO item = _baseService.CheckExist(conta, idAss);
            return item;
        }

        public List<GRUPO> GetAllItens(Int32? idAss)
        {
            List<GRUPO> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<GRUPO> GetAllItensAdm(Int32? idAss)
        {
            List<GRUPO> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public GRUPO GetItemById(Int32 id)
        {
            GRUPO item = _baseService.GetItemById(id);
            return item;
        }

        public Int32 ExecuteFilter(String nome, Int32? idAss, out List<GRUPO> objeto)
        {
            try
            {
                objeto = new List<GRUPO>();
                Int32 volta = 0;

                // Processa filtro
                objeto = _baseService.ExecuteFilter(nome, idAss);
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

        public Int32 ValidateCreate(GRUPO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, idAss) != null)
                {
                    return 1;
                }

                // Completa objeto
                item.GRUP_IN_ATIVO = 1;
                item.GRUP_DT_CADASTRO = DateTime.Today.Date;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "AddGRUP",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<GRUPO>(item)
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

        public Int32 ValidateEdit(GRUPO item, GRUPO itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "EditGRUP",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<GRUPO>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<GRUPO>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(GRUPO item, Int32? idAss)
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

        public Int32 ValidateDelete(GRUPO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial
                if (item.GRUPO_CONTATO.Count > 0)
                {
                    return 1;
                }

                // Acerta campos
                item.GRUP_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelGRUP",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<GRUPO>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(GRUPO item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.GRUP_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatGRUP",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<GRUPO>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 IncluirGrupoContato(GRUPO item, USUARIO usuario, Int32? idAss)
        {
            try
            {

                // Cria registro
                GRUPO rot = _baseService.GetItemById(item.GRUP_CD_ID);
                item.GRUP_IN_ATIVO = 1;
                GRUPO_CONTATO rl = new GRUPO_CONTATO();
                rl.CONT_CD_ID = item.CONT_CD_ID.Value;
                rl.GRUP_CD_ID = item.GRUP_CD_ID;
                rl.GRCO_IN_ATIVO = 1;

                // Verifica existencia
                if (_baseService.CheckExist(rl, idAss ) != null)
                {
                    return 1;
                }

                // Inclui na coleção
                rot.GRUPO_CONTATO.Add(rl);

                // Persiste
                return _baseService.Edit(rot, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEditGrupoContato(GRUPO_CONTATO item)
        {
            try
            {
                // Persiste
                item.GRUPO = null;
                item.CONTATO = null;
                return _baseService.EditGrupoContato(item);
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
    }
}
