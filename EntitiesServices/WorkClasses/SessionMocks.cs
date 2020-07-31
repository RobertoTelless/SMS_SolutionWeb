using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntitiesServices.Model;

namespace EntitiesServices.Work_Classes
{
    public static class SessionMocks
    {
        public static USUARIO UserCredentials { get; set; }
        public static Int32 IdAssinante { get; set; }
        public static Int32 IdAssinanteVolta { get; set; }
        public static ASSINANTE Assinante { get; set; }
        public static List<USUARIO> listaUsuario { get; set; }
        public static USUARIO Usuario { get; set; }
        public static String NomeLogado { get; set; }
        public static List<LOG> listaLog { get; set; }
        public static Int32 Logs { get; set; }
        public static List<PERFIL> listaPerfil { get; set; }
        public static String voltaLogin { get; set; }
        public static String origem { get; set; }
        public static Int32 idVolta { get; set; }
        public static String arquivo { get; set; }
        public static CONFIGURACAO Configuracao { get; set; }
        public static LOG filtroLog { get; set; }
        public static USUARIO filtroUsuario { get; set; }
        public static Int32 voltaCEP { get; set; }
        public static Int32 clonar { get; set; }
        public static List<NOTIFICACAO> listaNotificacao { get; set; }
        public static List<NOTIFICACAO> Notificacoes { get; set; }
        public static Int32 NovasNotificacoes { get; set; }
        public static PERFIL perfil { get; set; }
        public static Int32 flagInicial { get; set; }
        public static Int32 tipoAssinante { get; set; }
        public static ASSINANTE assinante { get; set; }
        public static List<PERFIL> Perfis { get; set; }
        public static Int32 numUsuarios { get; set; }
        public static List<USUARIO> Usuarios { get; set; }
        public static List<ASSINANTE> listaAssinante { get; set; }
        public static Int32 voltaAssinante { get; set; }
        public static List<UF> UFs { get; set; }
        public static NOTIFICACAO notificacao { get; set; }
        public static List<NOTIFICACAO> listaNovas { get; set; }
        public static NOTIFICACAO filtroNotificacao { get; set; }
    }
}
