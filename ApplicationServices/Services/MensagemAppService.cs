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
    public class MensagemAppService : AppServiceBase<MENSAGEM>, IMensagemAppService
    {
        private readonly IMensagemService _baseService;
        private readonly IUsuarioService _usuService;

        public MensagemAppService(IMensagemService baseService, IUsuarioService usuService): base(baseService)
        {
            _baseService = baseService;
            _usuService = usuService;
        }

        public MENSAGEM CheckExist(MENSAGEM conta, Int32? idAss)
        {
            MENSAGEM item = _baseService.CheckExist(conta, idAss);
            return item;
        }

        public List<MENSAGEM> GetAllItens(Int32? idAss)
        {
            List<MENSAGEM> lista = _baseService.GetAllItens(idAss);
            return lista;
        }

        public List<MENSAGEM> GetAllItensAdm(Int32? idAss)
        {
            List<MENSAGEM> lista = _baseService.GetAllItensAdm(idAss);
            return lista;
        }

        public List<MENSAGEM> GetAllAgendadas(Int32? idAss)
        {
            List<MENSAGEM> lista = _baseService.GetAllAgendadas(idAss);
            return lista;
        }

        public List<MENSAGEM> GetAllEnviadas(Int32? idAss)
        {
            List<MENSAGEM> lista = _baseService.GetAllEnviadas(idAss);
            return lista;
        }

        public MENSAGEM GetItemById(Int32 id)
        {
            MENSAGEM item = _baseService.GetItemById(id);
            return item;
        }

        public MENSAGEM_ANEXO GetAnexoById(Int32 id)
        {
            MENSAGEM_ANEXO lista = _baseService.GetAnexoById(id);
            return lista;
        }

        public Int32 ExecuteFilter(String nome, DateTime? data, Int32? enviada, Int32? agendada, String conteudo, Int32? idAss, out List<MENSAGEM> objeto)
        {
            try
            {
                objeto = new List<MENSAGEM>();
                Int32 volta = 0;

                // Processa filtro
                objeto = _baseService.ExecuteFilter(nome, data, enviada, agendada, conteudo, idAss);
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

        public Int32 ValidateCreate(MENSAGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica existencia prévia
                if (_baseService.CheckExist(item, idAss) != null)
                {
                    return 1;
                }

                // Criticas
                if (item.CONT_CD_ID == null & item.CAMP_CD_ID == null & item.GRUP_CD_ID == null)
                {
                    return 2;
                }
                if (item.TEMP_CD_ID == null & item.MENS_TX_TEXTO == null)
                {
                    return 3;
                }

                // Completa objeto
                item.MENS_IN_ATIVO = 1;
                item.MENS_DT_DATA = DateTime.Today.Date;
                item.MENS_DT_AGENDA = null;
                item.MENS_DT_ENVIO = null;
                item.MENS_IN_ENVIADA = 0;
                item.ASSI_CD_ID = idAss.Value;
                item.USUA_CD_ID = usuario.USUA_CD_ID;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "AddMENS",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<MENSAGEM>(item)
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

        public Int32 ValidateEdit(MENSAGEM item, MENSAGEM itemAntes, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_NM_OPERACAO = "EditMENS",
                    LOG_IN_ATIVO = 1,
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<MENSAGEM>(item),
                    LOG_TX_REGISTRO_ANTES = Serialization.SerializeJSON<MENSAGEM>(itemAntes)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEdit(MENSAGEM item, Int32? idAss)
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

        public Int32 ValidateDelete(MENSAGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.MENS_IN_ATIVO = 0;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "DelMENS",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<MENSAGEM>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateReativar(MENSAGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {
                // Verifica integridade referencial

                // Acerta campos
                item.MENS_IN_ATIVO = 1;

                // Monta Log
                LOG log = new LOG
                {
                    LOG_DT_DATA = DateTime.Now,
                    ASSI_CD_ID = idAss.Value,
                    USUA_CD_ID = usuario.USUA_CD_ID,
                    LOG_IN_ATIVO = 1,
                    LOG_NM_OPERACAO = "ReatMENS",
                    LOG_TX_REGISTRO = Serialization.SerializeJSON<MENSAGEM>(item)
                };

                // Persiste
                return _baseService.Edit(item, log, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 IncluirMensagemContato(MENSAGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {

                // Cria registro
                MENSAGEM rot = _baseService.GetItemById(item.MENS_CD_ID);
                item.MENS_IN_ATIVO = 1;
                MENSAGEM_CONTATO rl = new MENSAGEM_CONTATO();
                rl.CONT_CD_ID = item.CONT_CD_ID.Value;
                rl.MENS_CD_ID = item.MENS_CD_ID;
                rl.MECO_IN_ATIVO = 1;

                // Verifica existencia
                if (_baseService.CheckExist(rl, idAss ) != null)
                {
                    return 1;
                }

                // Inclui na coleção
                rot.MENSAGEM_CONTATO.Add(rl);

                // Persiste
                return _baseService.Edit(rot, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEditMensagemContato(MENSAGEM_CONTATO item)
        {
            try
            {
                // Persiste
                item.MENSAGEM = null;
                item.CONTATO = null;
                return _baseService.EditMensagemContato(item);
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

        public Int32 IncluirMensagemGrupo(MENSAGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {

                // Cria registro
                MENSAGEM rot = _baseService.GetItemById(item.MENS_CD_ID);
                item.MENS_IN_ATIVO = 1;
                MENSAGEM_GRUPO rl = new MENSAGEM_GRUPO();
                rl.GRUP_CD_ID = item.GRUP_CD_ID.Value;
                rl.MENS_CD_ID = item.MENS_CD_ID;
                rl.MEGR_IN_ATIVO = 1;

                // Verifica existencia
                if (_baseService.CheckExist(rl, idAss) != null)
                {
                    return 1;
                }

                // Inclui na coleção
                rot.MENSAGEM_GRUPO.Add(rl);

                // Persiste
                return _baseService.Edit(rot, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEditMensagemGrupo(MENSAGEM_GRUPO item)
        {
            try
            {
                // Persiste
                item.MENSAGEM = null;
                item.GRUPO = null;
                return _baseService.EditMensagemGrupo(item);
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

        public Int32 IncluirMensagemCampanha(MENSAGEM item, USUARIO usuario, Int32? idAss)
        {
            try
            {

                // Cria registro
                MENSAGEM rot = _baseService.GetItemById(item.MENS_CD_ID);
                item.MENS_IN_ATIVO = 1;
                MENSAGEM_CAMPANHA rl = new MENSAGEM_CAMPANHA();
                rl.CAMP_CD_ID = item.CAMP_CD_ID.Value;
                rl.MENS_CD_ID = item.MENS_CD_ID;
                rl.MECA_IN_ATIVO = 1;

                // Verifica existencia
                if (_baseService.CheckExist(rl, idAss) != null)
                {
                    return 1;
                }

                // Inclui na coleção
                rot.MENSAGEM_CAMPANHA.Add(rl);

                // Persiste
                return _baseService.Edit(rot, idAss);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 ValidateEditMensagemCampanha(MENSAGEM_CAMPANHA item)
        {
            try
            {
                // Persiste
                item.MENSAGEM = null;
                item.CAMPANHA = null;
                return _baseService.EditMensagemCampanha(item);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<CAMPANHA> GetAllCampanhas(Int32 id)
        {
            List<CAMPANHA> lista = _baseService.GetAllCampanhas(id);
            return lista;
        }
    }
}
