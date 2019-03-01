using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class Reglement_detteModel
    {
        public System.DateTime date_paiement { get; set; }
        public string libelle { get; set; }
        public decimal montant { get; set; }
        public string codeU { get; set; }
        public string codeDETTE { get; set; }

        [Key]
        public string codeREGLEMENT_DETTE { get; set; }
        public System.DateTime date_c { get; set; }
    }
}