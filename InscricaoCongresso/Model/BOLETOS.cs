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
        public string especieDocumento { get; set; }
        public string dataEmissao { get; set; }
        public string dataPagamento { get; set; }
        public string dataVencimento { get; set; }
        public Nullable<int> numeroDocumento { get; set; }
        public Nullable<decimal> descontos { get; set; }
        public Nullable<decimal> abatimento { get; set; }
        public int idValor { get; set; }
        public int idCedente { get; set; }
        public int idInscritos { get; set; }
        public int nossoNumero { get; set; }
        public string codigoBarras { get; set; }
        public string informacoesL1 { get; set; }
        public string informacoesL2 { get; set; }
        public string informacoesL3 { get; set; }
        public string informacoesL4 { get; set; }
        public string informacoesL5 { get; set; }
        public string informacoesL6 { get; set; }
        public string informacoesL7 { get; set; }
        public string informacoesL8 { get; set; }
        public string informacoesL9 { get; set; }
        public string informacoesL10 { get; set; }
        public Nullable<int> acrescimo { get; set; }
        public Nullable<int> multa { get; set; }
    
        public virtual INSCRITOS INSCRITOS { get; set; }
        public virtual CEDENTES CEDENTES { get; set; }
        public virtual VALORES VALORES { get; set; }
    }
}
