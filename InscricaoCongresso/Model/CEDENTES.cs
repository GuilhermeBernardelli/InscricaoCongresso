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
    
    public partial class CEDENTES
    {
        public CEDENTES()
        {
            this.BOLETOS = new HashSet<BOLETOS>();
        }
    
        public int id { get; set; }
        public string nomeCedente { get; set; }
        public string cnpjCedente { get; set; }
        public string codigoCedente { get; set; }
        public int idEndereco { get; set; }
        public int idConta { get; set; }
    
        public virtual ICollection<BOLETOS> BOLETOS { get; set; }
        public virtual CONTAS CONTAS { get; set; }
        public virtual ENDERECOS ENDERECOS { get; set; }
    }
}