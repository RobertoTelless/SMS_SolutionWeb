using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EntitiesServices.Model;
using System.Web;

namespace SMS_Presentation.ViewModels
{
    public class ContatoViewModel
    {
        [Key]
        public int CONT_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NOME obrigatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O NOME deve ter no minimo 1 caractere e no máximo 100.")]
        public string CONT_NM_NOME { get; set; }
        [Required(ErrorMessage = "Campo WHATSAPP obrigatorio")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "O WHATSAPP deve ter no minimo 1 caractere e no máximo 20.")]
        public string CONT_NR_WHATSAPP { get; set; }
        [StringLength(20, ErrorMessage = "O WHATSAPP 2 deve ter no máximo 20 caracteres.")]
        public string CONT_NR_WHATSAPP2 { get; set; }
        public Nullable<int> ORIG_CD_ID { get; set; }
        [StringLength(50, ErrorMessage = "O CARGO deve ter no máximo 50 caracteres.")]
        public string CONT_NM_CARGO { get; set; }
        [Required(ErrorMessage = "Campo CATEGORIA obrigatorio")]
        public Nullable<int> CACO_CD_ID { get; set; }
        public Nullable<int> UF_CD_ID { get; set; }
        [StringLength(50, ErrorMessage = "A CIDADE deve ter no máximo 50 caracteres.")]
        public string CACO_NM_CIDADE { get; set; }
        public Nullable<int> PROF_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo DATA NASCIMENTO obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "DATA DE NASCIMENTO Deve ser uma data válida")]
        public Nullable<System.DateTime> CONT_DT_NASCIMENTO { get; set; }
        public Nullable<int> CLUB_CD_ID { get; set; }
        [StringLength(500, ErrorMessage = "OS DETALHES devem ter no máximo 500 caracteres.")]
        public string CONT_DS_DETALHES { get; set; }
        [Required(ErrorMessage = "Campo E-MAIL obrigatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O E-MAIL deve ter no minimo 1 caractere e no máximo 100.")]
        public string CONT_NM_EMAIL { get; set; }
        [StringLength(50, ErrorMessage = "O TELEFONE deve ter no máximo 50 caracteres.")]
        public string CONT_NR_TELEFONE { get; set; }
        [Required(ErrorMessage = "Campo CELULAR obrigatorio")]
        [StringLength(50, ErrorMessage = "O CELULAR deve ter no máximo 50 caracteres.")]
        public string CONT_NR_CELULAR { get; set; }
        public Nullable<int> CONT_IN_ATIVO { get; set; }

        public virtual ASSINANTE ASSINANTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPANHA_CONTATO> CAMPANHA_CONTATO { get; set; }
        public virtual CATEGORIA_CONTATO CATEGORIA_CONTATO { get; set; }
        public virtual CLUBE CLUBE { get; set; }
        public virtual ORIGEM ORIGEM { get; set; }
        public virtual PROFISSAO PROFISSAO { get; set; }
        public virtual UF UF { get; set; }
    }
}