//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntitiesServices.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USUARIO()
        {
            this.LOG = new HashSet<LOG>();
            this.USUARIO_ANEXO = new HashSet<USUARIO_ANEXO>();
            this.NOTICIA_COMENTARIO = new HashSet<NOTICIA_COMENTARIO>();
            this.NOTIFICACAO = new HashSet<NOTIFICACAO>();
            this.MENSAGEM = new HashSet<MENSAGEM>();
        }
    
        public int USUA_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        public int PERF_CD_ID { get; set; }
        public string USUA_NM_NOME { get; set; }
        public string USUA_NM_LOGIN { get; set; }
        public string USUA_NM_EMAIL { get; set; }
        public string USUA_NR_TELEFONE { get; set; }
        public string USUA_NR_CELULAR { get; set; }
        public string USUA_NM_SENHA { get; set; }
        public string USUA_NM_SENHA_CONFIRMA { get; set; }
        public string USUA_NM_NOVA_SENHA { get; set; }
        public Nullable<int> USUA_IN_BLOQUEADO { get; set; }
        public Nullable<int> USUA_IN_PROVISORIO { get; set; }
        public Nullable<int> USUA_IN_LOGIN_PROVISORIO { get; set; }
        public Nullable<int> USUA_IN_ATIVO { get; set; }
        public Nullable<System.DateTime> USUA_DT_BLOQUEADO { get; set; }
        public Nullable<System.DateTime> USUA_DT_ALTERACAO { get; set; }
        public Nullable<System.DateTime> USUA_DT_TROCA_SENHA { get; set; }
        public Nullable<System.DateTime> USUA_DT_ACESSO { get; set; }
        public Nullable<System.DateTime> USUA_DT_ULTIMA_FALHA { get; set; }
        public Nullable<System.DateTime> USUA_DT_CADASTRO { get; set; }
        public Nullable<int> USUA_NR_ACESSOS { get; set; }
        public Nullable<int> USUA_NR_FALHAS { get; set; }
        public string USUA_TX_OBSERVACOES { get; set; }
        public string USUA_AQ_FOTO { get; set; }
    
        public virtual ASSINANTE ASSINANTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOG> LOG { get; set; }
        public virtual PERFIL PERFIL { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO_ANEXO> USUARIO_ANEXO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTICIA_COMENTARIO> NOTICIA_COMENTARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICACAO> NOTIFICACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAGEM> MENSAGEM { get; set; }
    }
}
