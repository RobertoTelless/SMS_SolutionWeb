using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Web.Common;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using ApplicationServices.Interfaces;
using ModelServices.Interfaces.EntitiesServices;
using ModelServices.Interfaces.Repositories;
using ApplicationServices.Services;
using ModelServices.EntitiesServices;
using DataServices.Repositories;
using Ninject.Web.Common.WebHost;
using EntitiesServices.Model;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Presentation.Start.NinjectWebCommons), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Presentation.Start.NinjectWebCommons), "Stop")]

namespace Presentation.Start
{
    public class NinjectWebCommons
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<IUsuarioAppService>().To<UsuarioAppService>();
            kernel.Bind<ILogAppService>().To<LogAppService>();
            kernel.Bind<IPerfilAppService>().To<PerfilAppService>();
            kernel.Bind<IConfiguracaoAppService>().To<ConfiguracaoAppService>();
            kernel.Bind<INoticiaAppService>().To<NoticiaAppService>();
            kernel.Bind<INotificacaoAppService>().To<NotificacaoAppService>();
            kernel.Bind<ITemplateAppService>().To<TemplateAppService>();
            kernel.Bind<ICategoriaContatoAppService>().To<CategoriaContatoAppService>();
            kernel.Bind<ICategoriaNotificacaoAppService>().To<CategoriaNotificacaoAppService>();
            kernel.Bind<IClubeAppService>().To<ClubeAppService>();
            kernel.Bind<IOrigemAppService>().To<OrigemAppService>();
            kernel.Bind<IProfissaoAppService>().To<ProfissaoAppService>();
            kernel.Bind<IAssinanteAppService>().To<AssinanteAppService>();
            kernel.Bind<IContatoAppService>().To<ContatoAppService>();
            kernel.Bind<IGrupoAppService>().To<GrupoAppService>();
            kernel.Bind<IGrupoContatoAppService>().To<GrupoContatoAppService>();
            kernel.Bind<ICampanhaAppService>().To<CampanhaAppService>();
            kernel.Bind<ICampanhaContatoAppService>().To<CampanhaContatoAppService>();
            kernel.Bind<ICampanhaGrupoAppService>().To<CampanhaGrupoAppService>();
            kernel.Bind<IMensagemAppService>().To<MensagemAppService>();
            kernel.Bind<IMensagemCampanhaAppService>().To<MensagemCampanhaAppService>();
            kernel.Bind<IMensagemContatoAppService>().To<MensagemContatoAppService>();
            kernel.Bind<IMensagemGrupoAppService>().To<MensagemGrupoAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<ILogService>().To<LogService>();
            kernel.Bind<IPerfilService>().To<PerfilService>();
            kernel.Bind<IConfiguracaoService>().To<ConfiguracaoService>();
            kernel.Bind<INotificacaoService>().To<NotificacaoService>();
            kernel.Bind<INoticiaService>().To<NoticiaService>();
            kernel.Bind<ITemplateService>().To<TemplateService>();
            kernel.Bind<IAssinanteService>().To<AssinanteService>();
            kernel.Bind<ICategoriaContatoService>().To<CategoriaContatoService>();
            kernel.Bind<ICategoriaNotificacaoService>().To<CategoriaNotificacaoService>();
            kernel.Bind<IClubeService>().To<ClubeService>();
            kernel.Bind<IOrigemService>().To<OrigemService>();
            kernel.Bind<IProfissaoService>().To<ProfissaoService>();
            kernel.Bind<IContatoService>().To<ContatoService>();
            kernel.Bind<IGrupoService>().To<GrupoService>();
            kernel.Bind<IGrupoContatoService>().To<GrupoContatoService>();
            kernel.Bind<ICampanhaService>().To<CampanhaService>();
            kernel.Bind<ICampanhaContatoService>().To<CampanhaContatoService>();
            kernel.Bind<ICampanhaGrupoService>().To<CampanhaGrupoService>();
            kernel.Bind<IMensagemService>().To<MensagemService>();
            kernel.Bind<IMensagemCampanhaService>().To<MensagemCampanhaService>();
            kernel.Bind<IMensagemContatoService>().To<MensagemContatoService>();
            kernel.Bind<IMensagemGrupoService>().To<MensagemGrupoService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<IConfiguracaoRepository>().To<ConfiguracaoRepository>();
            kernel.Bind<IUsuarioRepository>().To<UsuarioRepository>();
            kernel.Bind<ILogRepository>().To<LogRepository>();
            kernel.Bind<IPerfilRepository>().To<PerfilRepository>();
            kernel.Bind<ITemplateRepository>().To<TemplateRepository>();
            kernel.Bind<ICategoriaNotificacaoRepository>().To<CategoriaNotificacaoRepository>();
            kernel.Bind<INotificacaoRepository>().To<NotificacaoRepository>();
            kernel.Bind<INoticiaRepository>().To<NoticiaRepository>();
            kernel.Bind<INoticiaComentarioRepository>().To<NoticiaComentarioRepository>();
            kernel.Bind<INotificacaoAnexoRepository>().To<NotificacaoAnexoRepository>();
            kernel.Bind<IUsuarioAnexoRepository>().To<UsuarioAnexoRepository>();
            kernel.Bind<IUFRepository>().To<UFRepository>();
            kernel.Bind<IAssinanteRepository>().To<AssinanteRepository>();
            kernel.Bind<IAssinanteAnexoRepository>().To<AssinanteAnexoRepository>();
            kernel.Bind<ICategoriaContatoRepository>().To<CategoriaContatoRepository>();
            kernel.Bind<IClubeRepository>().To<ClubeRepository>();
            kernel.Bind<IOrigemRepository>().To<OrigemRepository>();
            kernel.Bind<IProfissaoRepository>().To<ProfissaoRepository>();
            kernel.Bind<ITemplateEmailRepository>().To<TemplateEmailRepository>();
            kernel.Bind<IContatoRepository>().To<ContatoRepository>();
            kernel.Bind<IGrupoRepository>().To<GrupoRepository>();
            kernel.Bind<IGrupoContatoRepository>().To<GrupoContatoRepository>();
            kernel.Bind<ICampanhaRepository>().To<CampanhaRepository>();
            kernel.Bind<ICampanhaContatoRepository>().To<CampanhaContatoRepository>();
            kernel.Bind<ICampanhaGrupoRepository>().To<CampanhaGrupoRepository>();
            kernel.Bind<IMensagemRepository>().To<MensagemRepository>();
            kernel.Bind<IMensagemCampanhaRepository>().To<MensagemCampanhaRepository>();
            kernel.Bind<IMensagemContatoRepository>().To<MensagemContatoRepository>();
            kernel.Bind<IMensagemGrupoRepository>().To<MensagemGrupoRepository>();
            kernel.Bind<IMensagemAnexoRepository>().To<MensagemAnexoRepository>();

        }
    }
}