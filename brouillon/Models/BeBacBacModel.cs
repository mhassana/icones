using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class BEBacBacModel
    {
        public string libelle { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeCOMMANDE_MARKET { get; set; }
        public string codeDEPOT { get; set; }
        [Key]
        public string codeBE_BAC_BAC { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Commande_marketer Commande_marketer { get; set; }
    }
}