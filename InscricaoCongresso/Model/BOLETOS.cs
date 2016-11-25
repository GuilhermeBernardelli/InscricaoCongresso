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
    
    public partial class BOLETOS
    {
        public int id { get; set; }
        public string linhaDigitavel { get; set; }
        public string localPagamento { get; set; }
        public string carteira { get; set; }
        public string especieDocumento { get; set; }
        public System.DateTime dataEmissao { get; set; }
        public Nullable<System.DateTime> dataPagamento { get; set; }
        public System.DateTime dataVencimento { get; set; }
        public string numeroDocumento { get; set; }
        public string nossoNumero { get; set; }
        public string informacoesDiversas { get; set; }
        public Nullable<decimal> descontos { get; set; }
        public Nullable<decimal> abatimento { get; set; }
        public Nullable<decimal> mora { get; set; }
        public Nullable<decimal> outrosAcrescimos { get; set; }
        public int idValor { get; set; }
        public int idCedente { get; set; }
        public int idInscritos { get; set; }
    
        public virtual INSCRITOS INSCRITOS { get; set; }
        public virtual CEDENTES CEDENTES { get; set; }
        public virtual VALORES VALORES { get; set; }
    }
}
