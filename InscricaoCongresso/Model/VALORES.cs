//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InscricaoCongresso.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class VALORES
    {
        public VALORES()
        {
            this.BOLETOS = new HashSet<BOLETOS>();
        }
    
        public int id { get; set; }
        public decimal valor { get; set; }
        public string descritivo { get; set; }
    
        public virtual ICollection<BOLETOS> BOLETOS { get; set; }
    }
}
