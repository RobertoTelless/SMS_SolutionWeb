using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;

namespace SMS_Presentation.ViewModels
{
    public class UsuarioViewModel
    {
        [Key]
        public int USUA_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo PERFIL obrigatorio")]
        public int PERF_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NOME obrigatorio")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O NOME deve ter no minimo 1 caractere e no máximo 50.")]
        public string USUA_NM_NOME { get; set; }
        public string USUA_NM_LOGIN { get; set; }
        [Required(ErrorMessage = "Campo E-MAIL obrigatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O E-MAIL deve ter no minimo 1 caractere e no máximo 100.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Deve ser um e-mail válido")]
        public string USUA_NM_EMAIL { get; set; }
        [StringLength(50, ErrorMessage = "O TELEFONE deve ter no máximo 50 caracteres.")]
        public string USUA_NR_TELEFONE { get; set; }
        [StringLength(50, ErrorMessage = "O CELULAR deve ter no máximo 50 caracteres.")]
        public string USUA_NR_CELULAR { get; set; }
        [Required(ErrorMessage = "Campo SENHA obrigatorio")]
        public string USUA_NM_SENHA { get; set; }
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O SENHA deve ter no minimo 1 caractere e no máximo 10.")]
        [Required(ErrorMessage = "Campo CONFIRMAÇÃO DE SENHA obrigatorio")]
        public string USUA_NM_SENHA_CONFIRMA { get; set; }
        [StringLength(10, MinimumLength = 1, ErrorMessage = "O SENHA deve ter no minimo 1 caractere e no máximo 10.")]
        public string USUA_NM_NOVA_SENHA { get; set; }
        public int USUA_IN_BLOQUEADO { get; set; }
        public int USUA_IN_PROVISORIO { get; set; }
        public int USUA_IN_LOGIN_PROVISORIO { get; set; }
        public int USUA_IN_ATIVO { get; set; }
        [DataType(DataType.Date, ErrorMessage = "DATA DE BLOQUEIO Deve ser uma data válida")]
        public Nullable<System.DateTime> USUA_DT_BLOQUEADO { get; set; }
        [DataType(DataType.Date, ErrorMessage = "DATA DE ALTERAÇÃO Deve ser uma data válida")]
        public Nullable<System.DateTime> USUA_DT_ALTERACAO { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Deve ser uma data válida")]
        public Nullable<System.DateTime> USUA_DT_TROCA_SENHA { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Deve ser uma data válida")]
        public Nullable<System.DateTime> USUA_DT_ACESSO { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Deve ser uma data válida")]
        public Nullable<System.DateTime> USUA_DT_ULTIMA_FALHA { get; set; }
        public System.DateTime USUA_DT_CADASTRO { get; set; }
        public int USUA_NR_ACESSOS { get; set; }
        public int USUA_NR_FALHAS { get; set; }
        public string USUA_TX_OBSERVACOES { get; set; }
        public string USUA_AQ_FOTO { get; set; }
        public int USUA_IN_CAMPANHA { get; set; }

        public bool Bloqueio
        {
            get
            {
                if (USUA_IN_BLOQUEADO == 1)
                {
                    return true;
                }
                return false;
            }
            set
            {
                USUA_IN_BLOQUEADO = (value == true) ? 1 : 0;
            }
        }
        public bool LoginProvisorio
        {
            get
            {
                if (USUA_IN_LOGIN_PROVISORIO == 1)
                {
                    return true;
                }
                return false;
            }
            set
            {
                USUA_IN_LOGIN_PROVISORIO = (value == true) ? 1 : 0;
            }
        }
        public bool Provisoria
        {
            get
            {
                if (USUA_IN_PROVISORIO == 1)
                {
                    return true;
                }
                return false;
            }
            set
            {
                USUA_IN_PROVISORIO = (value == true) ? 1 : 0;
            }
        }


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
    }
}