using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EntitiesServices.Model;
using System.Web;

namespace SMS_Presentation.ViewModels
{
    public class AssinanteViewModel
    {
        [Key]
        public int ASSI_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NOME obrigatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O NOME deve ter no minimo 1 caractere e no máximo 100.")]
        public string ASSI_NM_NOME { get; set; }
        public int ASSI_IN_ATIVO { get; set; }
        [Required(ErrorMessage = "Campo DATA DE INÍCIO obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "DATA DE EMISSÂO Deve ser uma data válida")]
        public Nullable<System.DateTime> ASSI_DT_INICIO { get; set; }
        public Nullable<int> ASSI_IN_TIPO { get; set; }
        public Nullable<int> ASSI_IN_STATUS { get; set; }
        [Required(ErrorMessage = "Campo E-MAIL obrigatorio")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "O E-MAIL deve ter no minimo 1 caractere e no máximo 100.")]
        public string ASSI_NM_EMAIL { get; set; }
        public Nullable<int> ASSI_IN_PESSOA { get; set; }
        [DataType(DataType.Date, ErrorMessage = "DATA DE EMISSÂO Deve ser uma data válida")]
        public Nullable<System.DateTime> ASSI_DT_FINAL { get; set; }
        [StringLength(500, ErrorMessage = "O MOTIVO deve ter no máximo 500 caracteres.")]
        public string ASSI_NM_MOTIVO { get; set; }
        [StringLength(20, ErrorMessage = "O CPF deve ter no máximo 20 caracteres.")]
        public string ASSI_NR_CPF { get; set; }
        [StringLength(20, ErrorMessage = "O CNPJ deve ter no máximo 20 caracteres.")]
        public string ASSI_NR_CNPJ { get; set; }
        [StringLength(50, ErrorMessage = "O ENDEREÇO deve ter no máximo 50 caracteres.")]
        public string ASSI_NM_ENDERECO { get; set; }
        [StringLength(50, ErrorMessage = "O BAIRRO deve ter no máximo 50 caracteres.")]
        public string ASSI_NM_BAIRRO { get; set; }
        [StringLength(50, ErrorMessage = "A CIDADE deve ter no máximo 50 caracteres.")]
        public string ASSI_NM_CIDADE { get; set; }
        [StringLength(10, ErrorMessage = "O CEP deve ter no máximo 10 caracteres.")]
        public string ASSI_NR_CEP { get; set; }
        public Nullable<int> UF_CD_ID { get; set; }
        [StringLength(50, ErrorMessage = "O TELEFONE deve ter no máximo 50 caracteres.")]
        public string ASSI_NR_TELEFONE { get; set; }
        [StringLength(50, ErrorMessage = "O CELULAR deve ter no máximo 50 caracteres.")]
        public string ASSI_NR_CELULAR { get; set; }
        [StringLength(50, ErrorMessage = "O WHATSAPP deve ter no máximo 50 caracteres.")]
        public string ASSI_NR_WHATSAPP { get; set; }
        [Required(ErrorMessage = "Campo LOGIN obrigatorio")]
        public string ASSI_NM_LOGIN { get; set; }
        [Required(ErrorMessage = "Campo SENHA obrigatorio")]
        public string ASSI_NM_SENHA { get; set; }
        public string ASSI_TX_OBSERVACOES { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONFIGURACAO> CONFIGURACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOG> LOG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOG> LOG1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTIFICACAO> NOTIFICACAO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USUARIO> USUARIO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NOTICIA> NOTICIA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ASSINANTE_ANEXO> ASSINANTE_ANEXO { get; set; }
        public virtual UF UF { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPANHA> CAMPANHA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTATO> CONTATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEMPLATE> TEMPLATE { get; set; }
    }
}