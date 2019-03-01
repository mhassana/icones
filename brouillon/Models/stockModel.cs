using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class stockModel
    {
        public string libelle { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeStation { get; set; }
        public string codePRODUIT { get; set; }
        [Key]
        public string codeSTOCK { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Produit Produit { get; set; }
        public virtual Station Station { get; set; }
    }
}