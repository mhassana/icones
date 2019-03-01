using System;
using System.Collections.Generic;
using ClassLibrary;

namespace brouillon.Models
{
    public class FacturationClientModel
    {
        public FacturationClientModel()
        {
            this.Tranches = new HashSet<Tranche>();
        }

        public string libelle { get; set; }
        public Nullable<decimal> montant_paye { get; set; }
        public Nullable<decimal> montant_restant { get; set; }
        public decimal montant_total { get; set; }
        public string codeU { get; set; }
        public string codeCOMMANDE_CLIENT { get; set; }
        public string codeFACTURATION_CLIENT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Commande_client Commande_client { get; set; }
        public virtual ICollection<Tranche> Tranches { get; set; }
    }
}