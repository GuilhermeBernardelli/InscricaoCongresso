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
    
    public partial class CONTAS
    {
        public CONTAS()
        {
            this.CEDENTES = new HashSet<CEDENTES>();
        }
    
        public int id { get; set; }
        public string codigoBanco { get; set; }
        public string agenciaNumero { get; set; }
    
        public virtual ICollection<CEDENTES> CEDENTES { get; set; }
    }
}