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
    
    public partial class MENSAGEM_GRUPO
    {
        public int MEGR_CD_ID { get; set; }
        public int MENS_CD_ID { get; set; }
        public int GRUP_CD_ID { get; set; }
        public Nullable<int> MEGR_IN_ATIVO { get; set; }
    
        public virtual GRUPO GRUPO { get; set; }
        public virtual MENSAGEM MENSAGEM { get; set; }
    }
}