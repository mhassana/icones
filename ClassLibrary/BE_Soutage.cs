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
    
    public partial class BE_Soutage
    {
        public BE_Soutage()
        {
            this.JoinBE_SoutageToNavire = new HashSet<JoinBE_SoutageToNavire>();
        }
    
        public System.DateTime date_emission { get; set; }
        public int duree_validite { get; set; }
        public string immatriculation_camion { get; set; }
        public string nom_chauffeur { get; set; }
        public string nom_client { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeCOMMANDE_CLIENT { get; set; }
        public string codeDEPOT { get; set; }
        public string codeTRANSPORTEUR { get; set; }
        public string codeBE_SOUTAGE { get; set; }
        public System.DateTime date_c { get; set; }
    
        public virtual Commande_client Commande_client { get; set; }
        public virtual Depot Depot { get; set; }
        public virtual Transporteur Transporteur { get; set; }
        public virtual ICollection<JoinBE_SoutageToNavire> JoinBE_SoutageToNavire { get; set; }
    }
}
