using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EntitiesServices.Model;
using System.Web;

namespace SMS_Presentation.ViewModels
{
    public class GrupoViewModel
    {
        [Key]
        public int GRUP_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NOME obrigatorio")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O NOME deve ter no minimo 1 caractere e no máximo 50.")]
        public string GRUP_NM_NOME { get; set; }
        public int GRUP_IN_ATIVO { get; set; }
        public Nullable<System.DateTime> GRUP_DT_CADASTRO { get; set; }
        public Nullable<int> CONT_CD_ID { get; set; }
        [StringLength(500, ErrorMessage = "A DESCRIÇÃO deve ter no máximo 500 caracteres.")]
        public string GRUP_DS_DESCRICAO { get; set; }

        public virtual ASSINANTE ASSINANTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GRUPO_CONTATO> GRUPO_CONTATO { get; set; }
    }
}