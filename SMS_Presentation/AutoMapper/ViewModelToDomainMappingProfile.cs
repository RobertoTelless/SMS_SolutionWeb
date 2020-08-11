using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EntitiesServices.Model;
using SMS_Presentation.ViewModels;

namespace MvcMapping.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel, USUARIO>();
            CreateMap<UsuarioLoginViewModel, USUARIO>();
            CreateMap<LogViewModel, LOG>();
            CreateMap<ConfiguracaoViewModel, CONFIGURACAO>();
            CreateMap<NoticiaViewModel, NOTICIA>();
            CreateMap<NoticiaComentarioViewModel, NOTICIA_COMENTARIO>();
            CreateMap<NotificacaoViewModel, NOTIFICACAO>();
            CreateMap<TemplateViewModel, TEMPLATE>();
            CreateMap<AssinanteViewModel, ASSINANTE>();
            CreateMap<CategoriaContatoViewModel, CATEGORIA_CONTATO>();
            CreateMap<CategoriaNotificacaoViewModel, CATEGORIA_NOTIFICACAO>();
            CreateMap<ClubeViewModel, CLUBE>();
            CreateMap<OrigemViewModel, ORIGEM>();
            CreateMap<PaisViewModel, PAIS>();
            CreateMap<ProfissaoViewModel, PROFISSAO>();
            CreateMap<UFViewModel, UF>();
            CreateMap<ContatoViewModel, CONTATO>();
            CreateMap<GrupoViewModel, GRUPO>();
            CreateMap<CampanhaViewModel, CAMPANHA>();
            CreateMap<MensagemViewModel, MENSAGEM>();
        }
    }
}