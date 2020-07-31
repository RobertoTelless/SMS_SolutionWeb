using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using EntitiesServices.Model;
using SMS_Presentation.ViewModels;

namespace MvcMapping.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<USUARIO, UsuarioViewModel>();
            CreateMap<USUARIO, UsuarioLoginViewModel>();
            CreateMap<LOG, LogViewModel>();
            CreateMap<CONFIGURACAO, ConfiguracaoViewModel>();
            CreateMap<NOTICIA, NoticiaViewModel>();
            CreateMap<NOTICIA_COMENTARIO, NoticiaComentarioViewModel>();
            CreateMap<NOTIFICACAO, NotificacaoViewModel>();
            CreateMap<TEMPLATE, TemplateViewModel>();
            CreateMap<ASSINANTE, AssinanteViewModel>();
            CreateMap<CATEGORIA_CONTATO, CategoriaContatoViewModel>();
            CreateMap<CATEGORIA_NOTIFICACAO, CategoriaNotificacaoViewModel>();
            CreateMap<CLUBE, ClubeViewModel>();
            CreateMap<ORIGEM, OrigemViewModel>();
            CreateMap<PAIS, PaisViewModel>();
            CreateMap<PROFISSAO, ProfissaoViewModel>();
            CreateMap<UF, UFViewModel>();
            CreateMap<CONTATO, ContatoViewModel>();
            CreateMap<GRUPO, GrupoViewModel>();
            CreateMap<CAMPANHA, CampanhaViewModel>();
        }
    }
}
