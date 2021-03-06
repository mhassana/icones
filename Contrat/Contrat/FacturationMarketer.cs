﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class FacturationMarketer
    {
        public FacturationMarketer()
        {
            this.TrancheMarketers = new HashSet<TrancheMarketer>();
        }

        public string libelle { get; set; }
        public Nullable<decimal> montant_paye { get; set; }
        public Nullable<decimal> montant_restant { get; set; }
        public decimal montant_total { get; set; }
        public string codeU { get; set; }
        public string codeCOMMANDE_MARKETER { get; set; }
        public string codeFACTURATION_MARKETER { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Commande_marketer Commande_marketer { get; set; }
        public virtual ICollection<TrancheMarketer> TrancheMarketers { get; set; }
    }
}
