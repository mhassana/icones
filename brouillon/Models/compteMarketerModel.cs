using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class CompteMarketerModel
    {
        public decimal montant_net { get; set; }
        public string codeU { get; set; }
        public string codeMARKETER { get; set; }

        [Key]
        public string codeCOMPTE_MARKETER { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Marketer Marketer { get; set; }
        public virtual ICollection<Transaction_effectuee> Transaction_effectuee { get; set; }
    }
}