using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EntitiesServices.Model;
using System.Web;

namespace SMS_Presentation.ViewModels
{
    public class MensagemViewModel
    {
        [Key]
        public int MENS_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        public int USUA_CD_ID { get; set; }
        [DataType(DataType.Date, ErrorMessage = "DATA Deve ser uma data válida")]
        public System.DateTime MENS_DT_DATA { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O NOME deve ter no minimo 1 caractere e no máximo 50.")]
        public string MENS_NM_NOME { get; set; }
        public int MENS_IN_ENVIADA { get; set; }
        [DataType(DataType.Date, ErrorMessage = "DATA DE ENVIO Deve ser uma data válida")]
        public Nullable<System.DateTime> MENS_DT_ENVIO { get; set; }
        public string MENS_TX_OBSERVACOES { get; set; }
        [DataType(DataType.Date, ErrorMessage = "DATA DE AGENDAMENTO Deve ser uma data válida")]
        public Nullable<System.DateTime> MENS_DT_AGENDA { get; set; }
        [Required(ErrorMessage = "Campo TEXTO obrigatorio")]
        [StringLength(160, ErrorMessage = "O TEXTO deve ter no máximo 160 caracteres.")]
        public string MENS_TX_TEXTO { get; set; }
        public Nullable<int> MENS_IN_ATIVO { get; set; }
        public Nullable<int> CONT_CD_ID { get; set; }
        public Nullable<int> GRUP_CD_ID { get; set; }
        public Nullable<int> CAMP_CD_ID { get; set; }
        public Nullable<int> TEMP_CD_ID { get; set; }
        public Nullable<int> MENS_IN_TIPO_SMS { get; set; }
        public string MENS_TX_RETORNOS { get; set; }
        public Nullable<int> MENS_IN_OPERACAO { get; set; }
        public Nullable<int> MENS_IN_STATUS { get; set; }
        [StringLength(50, ErrorMessage = "O NOME DA CAMPANHA deve ter no máximo 50 caracteres.")]
        public string MENS_NM_CAMPANHA { get; set; }

        public virtual ASSINANTE ASSINANTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAGEM_CAMPANHA> MENSAGEM_CAMPANHA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAGEM_CONTATO> MENSAGEM_CONTATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAGEM_GRUPO> MENSAGEM_GRUPO { get; set; }
        public virtual USUARIO USUARIO { get; set; }
        public virtual CONTATO CONTATO { get; set; }
        public virtual GRUPO GRUPO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAGEM_ANEXO> MENSAGEM_ANEXO { get; set; }
        public virtual TEMPLATE TEMPLATE { get; set; }
        public virtual CAMPANHA CAMPANHA { get; set; }
    }
}