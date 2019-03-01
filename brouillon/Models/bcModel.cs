using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class BCModel
    {
        public System.DateTime date_emission { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeDEPOT { get; set; }

        [Key]
        public string codeBC { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Depot Depot { get; set; }
    }
}