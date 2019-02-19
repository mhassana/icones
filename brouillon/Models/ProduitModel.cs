using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class ProduitModel
    {
        [Key]
        public string CodePRODUIT { get; set; }

        public string Libelle { get; set; }

        public string Designation { get; set; }

        public decimal Prix { get; set; }

        public string Unite_mesure { get; set; }

        public string CodeU { get; set; }
    }
}