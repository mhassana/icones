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
    
    public partial class View_BE_soutage
    {
        public System.DateTime date_emission { get; set; }
        public int duree_validite { get; set; }
        public string immatriculation_camion { get; set; }
        public string nom_chauffeur { get; set; }
        public string nom_client { get; set; }
        public decimal quantite { get; set; }
        public int bE_SoutageID { get; set; }
        public int commande_clientID { get; set; }
        public int depotID { get; set; }
        public int transporteurID { get; set; }
        public System.Guid code { get; set; }
    }
}
