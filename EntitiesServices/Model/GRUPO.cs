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
    
    public partial class GRUPO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GRUPO()
        {
            this.GRUPO_CONTATO = new HashSet<GRUPO_CONTATO>();
            this.CAMPANHA_GRUPO = new HashSet<CAMPANHA_GRUPO>();
            this.MENSAGEM_GRUPO = new HashSet<MENSAGEM_GRUPO>();
            this.MENSAGEM = new HashSet<MENSAGEM>();
        }
    
        public int GRUP_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        public string GRUP_NM_NOME { get; set; }
        public int GRUP_IN_ATIVO { get; set; }
        public Nullable<System.DateTime> GRUP_DT_CADASTRO { get; set; }
        public Nullable<int> CONT_CD_ID { get; set; }
        public string GRUP_DS_DESCRICAO { get; set; }
    
        public virtual ASSINANTE ASSINANTE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GRUPO_CONTATO> GRUPO_CONTATO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CAMPANHA_GRUPO> CAMPANHA_GRUPO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAGEM_GRUPO> MENSAGEM_GRUPO { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MENSAGEM> MENSAGEM { get; set; }
    }
}
