using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class taxeModel
    {
        public taxeModel()
        {
            this.JoinTaxeToFacturations = new HashSet<JoinTaxeToFacturation>();
        }

        public string libelle { get; set; }
        public decimal taux { get; set; }
        public string codeU { get; set; }
        [Key]
        public string codeTAXE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<JoinTaxeToFacturation> JoinTaxeToFacturations { get; set; }
    }
}