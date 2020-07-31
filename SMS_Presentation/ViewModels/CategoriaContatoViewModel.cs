using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using EntitiesServices.Model;

namespace SMS_Presentation.ViewModels
{
    public class CategoriaContatoViewModel
    {
        [Key]
        public int CACO_CD_ID { get; set; }
        [Required(ErrorMessage = "Campo NOME obrigatorio")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "O NOME deve ter no minimo 1 caractere e no máximo 50.")]
        public string CACO_NM_NOME { get; set; }
        public int CACO_IN_ATIVO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CONTATO> CONTATO { get; set; }

    }
}