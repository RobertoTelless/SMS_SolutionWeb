using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationServices.Interfaces;
using EntitiesServices.Model;
using System.Globalization;
using SMS_Presentation.App_Start;
//using EntitiesServices.Work_Classes;
using AutoMapper;
using SMS_Presentation.ViewModels;
using System.IO;

namespace SMS_Presentation.Controllers
{
    public class MensagemController : Controller
    {
        private readonly IMensagemAppService baseApp;
        private readonly IUsuarioAppService usuApp;
        private readonly IContatoAppService conApp;
        private readonly IGrupoAppService gruApp;
        private readonly ICampanhaAppService camApp;
        private readonly IMensagemContatoAppService mcApp;
        private readonly IMensagemGrupoAppService mgApp;
        private readonly IMensagemCampanhaAppService mpApp;
        private readonly ITemplateAppService temApp;

        private String msg;
        private Exception exception;
        MENSAGEM objetoAss = new MENSAGEM();
        MENSAGEM objetoAssAntes = new MENSAGEM();
        List<MENSAGEM> listaMasterAss = new List<MENSAGEM>();
        String extensao;

        public MensagemController(IMensagemAppService baseApps, IUsuarioAppService usuApps, IContatoAppService conApps, IGrupoAppService gruApps, ICampanhaAppService camApps, IMensagemContatoAppService mcApps, IMensagemGrupoAppService mgApps, IMensagemCampanhaAppService mpApps, ITemplateAppService temApps)
        {
            baseApp = baseApps;
            usuApp = usuApps;
            conApp = conApps;
            gruApp = gruApps;
            camApp = camApps;
            mcApp = mcApps;
            mgApp = mgApps;
            mpApp = mpApps;
            temApp = temApps;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Voltar()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            return RedirectToAction("CarregarBase", "BaseAdmin");
        }

        public ActionResult VoltarGeral()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            return RedirectToAction("CarregarBase", "BaseAdmin");
        }

        public ActionResult DashboardAdministracao()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            return RedirectToAction("CarregarAdmin", "BaseAdmin");
        }

        [HttpGet]
        public ActionResult MontarTelaMensagens()
        {
            // Verifica se tem usuario logado
            USUARIO usuario = new USUARIO();
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            usuario = (USUARIO)Session["UserCredentials"];
            Int32 idAss = (Int32)Session["IdAssinante"];

            // Carrega listas
            if ((List<CAMPANHA>)Session["ListaMensagem"] == null)
            {
                listaMasterAss = baseApp.GetAllItens(idAss);
                Session["ListaMensagem"] = listaMasterAss;
            }
            ViewBag.Listas = (List<MENSAGEM>)Session["ListaMensagem"];
            ViewBag.Title = "Mensagens";

            // Indicadores
            ViewBag.Mensagens = ((List<CAMPANHA>)Session["ListaMensagem"]).Count;

            // Mensagem
            if ((Int32)Session["MensMensagem"] == 1)
            {
                ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0016", CultureInfo.CurrentCulture));
            }

            // Abre view
            Session["MensMensagem"] = 0;
            objetoAss = new MENSAGEM();
            return View(objetoAss);
        }

        public ActionResult RetirarFiltroMensagem()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Session["ListaMensagem"] = null;
            return RedirectToAction("MontarTelaMensagem");
        }

        public ActionResult MostrarTudoMensagem()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            listaMasterAss = baseApp.GetAllItensAdm(idAss);
            Session["ListaMensagem"] = listaMasterAss;
            return RedirectToAction("MontarTelaMensagem");
        }

        [HttpPost]
        public ActionResult FiltrarMensagem(MENSAGEM item)
        {
            try
            {
                // Executa a operação
                if ((String)Session["Ativa"] == null)
                {
                    return RedirectToAction("Login", "ControleAcesso");
                }
                List<MENSAGEM> listaObj = new List<MENSAGEM>();
                Int32 idAss = (Int32)Session["IdAssinante"];
                Int32 volta = baseApp.ExecuteFilter(item.MENS_NM_NOME, item.MENS_DT_ENVIO, item.MENS_IN_ENVIADA, 0, item.MENS_TX_TEXTO, idAss, out listaObj);

                // Verifica retorno
                if (volta == 1)
                {
                    Session["MensMensagem"] = 1;
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0016", CultureInfo.CurrentCulture));
                    return RedirectToAction("MontarTelaMensagem");
                }

                // Sucesso
                Session["MensMensagem"] = 0;
                listaMasterAss = listaObj;
                Session["ListaMensagem"] = listaObj;
                return RedirectToAction("MontarTelaMensagem");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return RedirectToAction("MontarTelaMensagem");
            }
        }

        public ActionResult VoltarBaseMensagem()
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            return RedirectToAction("MontarTelaMensagem");
        }

        [HttpGet]
        public ActionResult IncluirMensagem()
        {
            // Prepara listas
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            USUARIO usuarioLogado = (USUARIO)Session["UserCredentials"];

            // Prepara view
            ViewBag.Contatos = new SelectList(conApp.GetAllItens(idAss), "CONT_CD_ID", "CONT_NM_NOME");
            ViewBag.Grupos = new SelectList(gruApp.GetAllItens(idAss), "GRUP_CD_ID", "GRUP_NM_NOME");
            ViewBag.Campanhas = new SelectList(camApp.GetAllItens(idAss), "CAMP_CD_ID", "CAMP_NM_NOME");
            ViewBag.Templates = new SelectList(temApp.GetAllItens(idAss), "TEMP_CD_ID", "TEMP_NM_NOME");
            List<SelectListItem> tipoSMS = new List<SelectListItem>();
            tipoSMS.Add(new SelectListItem() { Text = "Long Code", Value = "1" });
            tipoSMS.Add(new SelectListItem() { Text = "Short Code", Value = "2" });
            ViewBag.Tipos = new SelectList(tipoSMS, "Value", "Text");

            USUARIO usuario = (USUARIO)Session["UserCredentials"];
            MENSAGEM item = new MENSAGEM();
            MensagemViewModel vm = Mapper.Map<MENSAGEM, MensagemViewModel>(item);
            vm.MENS_IN_ATIVO = 1;
            vm.ASSI_CD_ID = idAss;
            vm.MENS_DT_DATA = DateTime.Today.Date;
            vm.MENS_DT_AGENDA = null;
            vm.MENS_DT_ENVIO = null;
            vm.MENS_IN_ENVIADA = 0;
            vm.MENS_IN_TIPO_SMS = 1;
            vm.USUA_CD_ID = usuarioLogado.USUA_CD_ID;
            return View(vm);
        }

        [HttpPost]
        public ActionResult IncluirMensagem(MensagemViewModel vm)
        {
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            Int32 idAss = (Int32)Session["IdAssinante"];
            if (ModelState.IsValid)
            {
                try
                {
                    // Executa a operação
                    MENSAGEM item = Mapper.Map<MensagemViewModel, MENSAGEM>(vm);
                    USUARIO usuarioLogado = (USUARIO)Session["UserCredentials"];
                    Int32 volta = baseApp.ValidateCreate(item, usuarioLogado, idAss);

                    // Verifica retorno
                    if (volta == 1)
                    {
                        Session["MensMensagem"] = 1;
                        ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0041", CultureInfo.CurrentCulture));
                        return View(vm);
                    }
                    if (volta == 2)
                    {
                        Session["MensMensagem"] = 2;
                        ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0042", CultureInfo.CurrentCulture));
                        return View(vm);
                    }
                    if (volta == 3)
                    {
                        Session["MensMensagem"] = 3;
                        ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0043", CultureInfo.CurrentCulture));
                        return View(vm);
                    }

                    // Sucesso
                    listaMasterAss = new List<MENSAGEM>();
                    Session["ListaMensagem"] = null;
                    Session["VoltaMensagem"] = 1;
                    Session["IdAssinanteVolta"] = item.ASSI_CD_ID;
                    Session["Mensagem"] = item;
                    Session["MensMensagem"] = 0;
                    Session["IdVolta"] = item.MENS_CD_ID;
                    return RedirectToAction("IncluirMensagem");
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    return View(vm);
                }
            }
            else
            {
                return View(vm);
            }
        }



    }
}