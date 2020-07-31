using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using EntitiesServices.Model;
using System.Web;

namespace SMS_Presentation.ViewModels
{
    public class CampanhaViewModel
    {
        [Key]
        public int CAMP_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NOME obrigatorio")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O NOME deve ter no minimo 1 caractere e no máximo 50.")]
        public string CAMP_NM_NOME { get; set; }
        [Required(ErrorMessage = "Campo DATA INICIAL obrigatorio")]
        [DataType(DataType.Date, ErrorMessage = "DATA INICIAL Deve ser uma data válida")]
        public System.DateTime CAMP_DT_INICIO { get; set; }
        [DataType(DataType.Date, ErrorMessage = "DATA FINAL Deve ser uma data válida")]
        public Nullable<System.DateTime> CAMP_DT_FINAL { get; set; }
        [StringLength(500, ErrorMessage = "A DESCRIÇÃO deve ter no máximo 500 caracteres.")]
        public string CAMP_DS_DESCRICAO { get; set; }
        public int CAMP_IN_ATIVO { get; set; }
        public Nullable<int> CONT_CD_ID { get; set; }
        public Nullable<int> GRUP_CD_ID { get; set; }

        public virtual ASSINANTE ASSINANTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPANHA_CONTATO> CAMPANHA_CONTATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPANHA_GRUPO> CAMPANHA_GRUPO { get; set; }
    }
}