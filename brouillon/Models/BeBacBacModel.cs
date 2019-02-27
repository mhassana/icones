using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class BeBacBacModel
    {
        public string libelle { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeCOMMANDE_MARKET { get; set; }
        public string codeDEPOT { get; set; }
        public string codeBE_BAC_BAC { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Commande_marketer Commande_marketer { get; set; }
    }
}