//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClassLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tranche
    {
        public System.DateTime date_paiement { get; set; }
        public string libelle { get; set; }
        public decimal montant { get; set; }
        public string codeU { get; set; }
        public string codeFACTURATION { get; set; }
        public string codeTRANCHE { get; set; }
        public System.DateTime date_c { get; set; }
    
        public virtual FacturationClient FacturationClient { get; set; }
    }
}
