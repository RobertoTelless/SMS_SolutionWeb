using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;

namespace SMS_Presentation.ViewModels
{
    public class TemplateViewModel
    {
        [Key]
        public int TEMP_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NOME obrigatorio")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O NOME deve ter no minimo 1 caractere e no máximo 50.")]
        public string TEMP_NM_NOME { get; set; }
        [Required(ErrorMessage = "Campo TEXTO obrigatorio")]
        [StringLength(160, ErrorMessage = "O TEXTO deve ter no máximo 160 caracteres.")]
        public string TEMP_TX_TEXTO { get; set; }
        [Required(ErrorMessage = "Campo DATA DE CRIAÇÃO obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "DATA DE CRIAÇÃO Deve ser uma data válida")]
        public Nullable<System.DateTime> TEMP_DT_CRIACAO { get; set; }
        public int TEMP_IN_ATIVO { get; set; }
        [Required(ErrorMessage = "Campo SIGLA obrigatorio")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "A SIGLA deve ter no minimo 1 caractere e no máximo 10.")]
        public string TEMP_SG_SIGLA { get; set; }
        public Nullable<int> CAMP_CD_ID { get; set; }

        public virtual ASSINANTE ASSINANTE { get; set; }
        public virtual CAMPANHA CAMPANHA { get; set; }
    }
}