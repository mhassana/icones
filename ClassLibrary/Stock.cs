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
    
    public partial class Stock
    {
        public string libelle { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeStation { get; set; }
        public string codePRODUIT { get; set; }
        public string codeSTOCK { get; set; }
        public System.DateTime date_c { get; set; }
    
        public virtual Produit Produit { get; set; }
        public virtual Station Station { get; set; }
    }
}
