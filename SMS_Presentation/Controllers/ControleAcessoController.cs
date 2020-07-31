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
    public class ControleAcessoController : Controller
    {
        private readonly IUsuarioAppService baseApp;
        private String msg;
        private Exception exception;
        USUARIO objeto = new USUARIO();
        USUARIO objetoAntes = new USUARIO();
        List<USUARIO> listaMaster = new List<USUARIO>();

        public ControleAcessoController(IUsuarioAppService baseApps)
        {
            baseApp = baseApps;
        }

        [HttpGet]
        public ActionResult Index()
        {
            USUARIO item = new USUARIO();
            UsuarioViewModel vm = Mapper.Map<USUARIO, UsuarioViewModel>(item);
            return View(vm);
        }

        [HttpGet]
        public ActionResult Login()
        {
            USUARIO item = new USUARIO();
            UsuarioLoginViewModel vm = Mapper.Map<USUARIO, UsuarioLoginViewModel>(item);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UsuarioLoginViewModel vm)
        {
            try
            {
                // Checa credenciais e atualiza acessos
                USUARIO usuario;
                Session["UserCredentials"] = null;
                ViewBag.Usuario = null;
                USUARIO login = Mapper.Map<UsuarioLoginViewModel, USUARIO>(vm);
                Int32 volta = baseApp.ValidateLogin(login.USUA_NM_LOGIN, login.USUA_NM_SENHA, out usuario);
                if (volta == 1)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0001", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 2)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0002", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 3)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0004", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 5)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0006", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 4)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0005", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 6)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0008", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 7)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0007", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 9)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0003", CultureInfo.CurrentCulture));
                    return View(vm);
                }

                // Armazena credenciais para autorização
                Session["UserCredentials"] = usuario;
                Session["Usuario"]= usuario;
                Session["IdUsuario"] = usuario.USUA_CD_ID;
                Session["IdAssinante"]= usuario.ASSI_CD_ID;
                Session["TipoAssinante"]= usuario.ASSINANTE.ASSI_IN_TIPO.Value;
                Session["Assinante"] = usuario.ASSINANTE;

                // Atualiza view
                String frase = String.Empty;
                String nome = usuario.USUA_NM_NOME;
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
                ViewBag.Greeting = frase;
                ViewBag.Nome = usuario.USUA_NM_NOME;
                ViewBag.Foto = usuario.USUA_AQ_FOTO;

                Session["Greetings"]= frase;
                Session["Nome"] = usuario.USUA_NM_NOME;
                Session["Foto"] = usuario.USUA_AQ_FOTO;
                Session["Perfil"] = usuario.PERFIL.PERF_SG_SIGLA;
                Session["Ativa"] = "1";

                // Route
                if ((USUARIO)Session["UserCredentials"] != null)
                {
                    return RedirectToAction("CarregarBase", "BaseAdmin");
                }
                return RedirectToAction("Login", "ControleAcesso");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(vm);
            }
        }

        public ActionResult Logout()
        {
            Session["UserCredentials"] = null;
            Session["Ativa"] = 0;
            return RedirectToAction("Login", "ControleAcesso");
        }

        public ActionResult Cancelar()
        {
            return RedirectToAction("Login", "ControleAcesso");
        }

        [HttpGet]
        public ActionResult TrocarSenha()
        {
            // Verifica se tem usuario logado
            if ((String)Session["Ativa"] == null)
            {
                return RedirectToAction("Login", "ControleAcesso");
            }
            USUARIO usuario = new USUARIO();

            // Reseta senhas
            usuario.USUA_NM_NOVA_SENHA = null;
            usuario.USUA_NM_SENHA_CONFIRMA = null;
            UsuarioLoginViewModel vm = Mapper.Map<USUARIO, UsuarioLoginViewModel>(usuario);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TrocarSenha(UsuarioLoginViewModel vm)
        {
            try
            {
                // Checa credenciais e atualiza acessos
                Int32? idAss = (Int32)Session["IdAssinante"];
                USUARIO usuario = SessionMocks.UserCredentials;
                USUARIO item = Mapper.Map<UsuarioLoginViewModel, USUARIO>(vm);
                Int32 volta = baseApp.ValidateChangePassword(item, idAss);
                if (volta == 1)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0011", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 2)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0012", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 3)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0009", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 4)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0010", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                Session["UserCredentials"] = null;
                Session["Ativa"] = null;
                return RedirectToAction("Login", "ControleAcesso");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(vm);
            }
        }

        [HttpGet]
        public ActionResult GerarSenha()
        {
            USUARIO item = new USUARIO();
            UsuarioLoginViewModel vm = Mapper.Map<USUARIO, UsuarioLoginViewModel>(item);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GerarSenha(UsuarioLoginViewModel vm)
        {
            try
            {
                // Processa
                Session["UserCredentials"]  = null;
                USUARIO item = Mapper.Map<UsuarioLoginViewModel, USUARIO>(vm);
                Int32 volta = baseApp.GenerateNewPassword(item.USUA_NM_EMAIL);
                if (volta == 1)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0013", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 2)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0014", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 3)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0004", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                if (volta == 4)
                {
                    ModelState.AddModelError("", SMS_Resource.ResourceManager.GetString("M0005", CultureInfo.CurrentCulture));
                    return View(vm);
                }
                Session["Ativa"] = null;
                Session["UserCredentials"] = null;
                return RedirectToAction("Login", "ControleAcesso");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return View(vm);
            }
        }
    }
}