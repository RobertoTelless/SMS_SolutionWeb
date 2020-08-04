using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ApplicationServices.Interfaces;
using EntitiesServices.Model;
using System.Globalization;
using SMS_Presentation.App_Start;
using EntitiesServices.Work_Classes;
using AutoMapper;
using SMS_Presentation.ViewModels;
using System.IO;

namespace SMS_Presentation.Controllers
{
    public class BaseAdminController : Controller
    {
        private readonly IUsuarioAppService baseApp;
        private readonly INoticiaAppService notiApp;
        private readonly ILogAppService logApp;
        private readonly INotificacaoAppService notfApp;
        private readonly IUsuarioAppService usuApp;
        private readonly IOrigemAppService oriApp;
        private readonly IProfissaoAppService proApp;
        private readonly IClubeAppService cluApp;
        private readonly ICategoriaContatoAppService ccApp;

        private String msg;
        private Exception exception;
        USUARIO objeto = new USUARIO();
        USUARIO objetoAntes = new USUARIO();
        List<USUARIO> listaMaster = new List<USUARIO>();

        public BaseAdminController(IUsuarioAppService baseApps, ILogAppService logApps, INoticiaAppService notApps, INotificacaoAppService notfApps, IUsuarioAppService usuApps, IOrigemAppService oriApps, IProfissaoAppService proApps, IClubeAppService cluApps, ICategoriaContatoAppService ccApps)
        {
            baseApp = baseApps;
            logApp = logApps;
            notiApp = notApps;
            notfApp = notfApps;
            usuApp = usuApps;
            oriApp = oriApps;
            proApp = proApps;
            cluApp = cluApps;
            ccApp = ccApps;
        }

        public ActionResult CarregarAdmin()
        {
            Int32? idAss = (Int32)Session["IdAssinante"];
            ViewBag.Usuarios = baseApp.GetAllUsuarios(idAss).Count;
            ViewBag.Logs = logApp.GetAllItens(idAss).Count;
            ViewBag.UsuariosLista = baseApp.GetAllUsuarios(idAss);
            ViewBag.LogsLista = logApp.GetAllItens(idAss);
            return View();
        }

        public ActionResult CarregarLandingPage()
        {
            return View();
        }

        public ActionResult CarregarBase()
        {
            // Carrega listas
            Int32? idAss = (Int32)Session["IdAssinante"];
            SessionMocks.Perfis = baseApp.GetAllPerfis();
            SessionMocks.UFs = baseApp.GetAllUF();
            Session["MensAssinante"] = 0;
            Session["Perfis"] = baseApp.GetAllPerfis();
            Session["UFs"] = baseApp.GetAllUF();
            Session["Origens"] = oriApp.GetAllItens();
            Session["Profissoes"] = proApp.GetAllItens();
            Session["Clubes"] = cluApp.GetAllItens();
            Session["CatContatos"] = ccApp.GetAllItens();

            Session["ListaUsuario"] = null;
            Session["MensUsuario"] = 0;
            Session["ListaLog"] = null;
            Session["MensLog"] = 0;
            Session["ListaNoticia"] = null;
            Session["MensNoticia"] = 0;
            Session["MensAcesso"] = 0;
            Session["MensNotificacao"] = 0;
            Session["VoltaNotificacao"] = 1;
            Session["ListaNotificacao"] = null;
            Session["ListaContato"] = null;
            Session["MensContato"] = 0;
            Session["ListaCatCont"] = null;
            Session["ListaGrupo"] = null;
            Session["MensGrupo"] = 0;
            Session["ListaCampanha"] = null;
            Session["MensCampanha"] = 0;
            Session["ListaTemplate"] = null;
            Session["MensTemplate"] = 0;
            Session["MensCatCont"] = 0;
            Session["ListaClube"] = null;
            Session["MensClube"] = 0;
            Session["ListaOrigem"] = null;
            Session["MensOrigem"] = 0;
            Session["ListaProfissao"] = null;
            Session["MensProfissao"] = 0;
            Session["ListaUsuarioAdm"] = null;
            Session["MensUsuarioAdm"] = 0;
            Session["Configuracao"] = null;
            Session["MensConfiguracao"] = 0;

            USUARIO usu = usuApp.GetItemById((Int32)Session["IdUsuario"]);
            UsuarioViewModel vm = Mapper.Map<USUARIO, UsuarioViewModel>(usu);

            Session["Perfil"] = usu.PERFIL.PERF_SG_SIGLA;
            Session["Notificacoes"] = baseApp.GetAllItensUser(usu.USUA_CD_ID, idAss);
            Session["ListasNovas"] = baseApp.GetNotificacaoNovas(usu.USUA_CD_ID, idAss);
            Session["NovasNotificacoes"] = ((List<NOTIFICACAO>)Session["Notificacoes"]).Where(p => p.NOTI_IN_VISTA == 0).Count();
            Session["Nome"] = usu.USUA_NM_NOME;
            ViewBag.Notificacoes = (List<NOTIFICACAO>)Session["Notificacoes"];
            ViewBag.ListasNovas = (List<NOTIFICACAO>)Session["ListasNovas"];
            ViewBag.NovasNotificacoes = (Int32)Session["NovasNotificacoes"];
            ViewBag.Nome = (String)Session["Nome"];

            if ((Int32)Session["NovasNotificacoes"] > 0)
            {
                ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0015", CultureInfo.CurrentCulture));
            }

            Session["Noticias"] = notiApp.GetAllItensValidos();
            Session["NoticiasNumero"] = ((List<NOTICIA>)Session["Noticias"]).Count;
            ViewBag.Noticias = (List<NOTICIA>)Session["Noticias"];
            ViewBag.NoticiasNumero = (Int32)Session["NoticiasNumero"];

            Session["Logs"] = logApp.GetAllItensUsuario(usu.USUA_CD_ID, idAss).Count;
            ViewBag.Logs = (Int32)Session["Logs"];
            ViewBag.SaldoSC = 1987;
            ViewBag.SaldoLC = 520;
            ViewBag.EnviadosSC = 349;
            ViewBag.EnviadosLC = 432;
            ViewBag.Entregue = 30;
            ViewBag.Rejeitado = 1;
            ViewBag.Pendente = 22;
            ViewBag.Expirado = 0;
            ViewBag.NaoEntregue = 0;

            List<SelectListItem> camp = new List<SelectListItem>();
            camp.Add(new SelectListItem() { Text = "Camapnha 1", Value = "1" });
            camp.Add(new SelectListItem() { Text = "Campanha 2", Value = "2" });
            camp.Add(new SelectListItem() { Text = "Campanha 3", Value = "3" });
            ViewBag.Campanhas = new SelectList(camp, "Value", "Text");

            String frase = String.Empty;
            String nome = usu.USUA_NM_NOME.Substring(0, usu.USUA_NM_NOME.IndexOf(" "));
            if (DateTime.Now.Hour <= 12)
            {
                frase = "Bom dia, " + nome;
            }
            else if (DateTime.Now.Hour > 12 & DateTime.Now.Hour <= 18)
            {
                frase = "Boa tarde, " + nome;
            }
            else
            {
                frase = "Boa noite, " + nome;
            }
            ViewBag.Greetings = frase;
            Session["Foto"] = usu.USUA_AQ_FOTO;
            ViewBag.Foto = usu.USUA_AQ_FOTO;
            Session["Ativa"] = "1";
            return View(vm);
        }


        public ActionResult CarregarDesenvolvimento()
        {
            //ViewBag.ListasNovas = (List<NOTIFICACAO>)Session["ListasNovas"];
            //ViewBag.Noticias = (List<NOTICIA>)Session["Noticias"];
            return View();
        }

        public ActionResult VoltarDashboard()
        {
            return RedirectToAction("CarregarDashboardInicial", "BaseAdmin");
        }

        public ActionResult MontarFaleConosco()
        {
            return View();
        }

    }
}