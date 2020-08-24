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
    
    public partial class MENSAGEM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MENSAGEM()
        {
            this.MENSAGEM_CAMPANHA = new HashSet<MENSAGEM_CAMPANHA>();
            this.MENSAGEM_CONTATO = new HashSet<MENSAGEM_CONTATO>();
            this.MENSAGEM_GRUPO = new HashSet<MENSAGEM_GRUPO>();
            this.MENSAGEM_ANEXO = new HashSet<MENSAGEM_ANEXO>();
        }
    
        public int MENS_CD_ID { get; set; }
        public int ASSI_CD_ID { get; set; }
        public int USUA_CD_ID { get; set; }
        public System.DateTime MENS_DT_DATA { get; set; }
        public string MENS_NM_NOME { get; set; }
        public int MENS_IN_ENVIADA { get; set; }
        public Nullable<System.DateTime> MENS_DT_ENVIO { get; set; }
        public string MENS_TX_OBSERVACOES { get; set; }
        public Nullable<System.DateTime> MENS_DT_AGENDA { get; set; }
        public string MENS_TX_TEXTO { get; set; }
        public Nullable<int> MENS_IN_ATIVO { get; set; }
        public Nullable<int> CONT_CD_ID { get; set; }
        public Nullable<int> GRUP_CD_ID { get; set; }
        public Nullable<int> CAMP_CD_ID { get; set; }
        public Nullable<int> TEMP_CD_ID { get; set; }
        public Nullable<int> MENS_IN_TIPO_SMS { get; set; }
        public string MENS_TX_RETORNOS { get; set; }
        public Nullable<int> MENS_IN_OPERACAO { get; set; }
    
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
