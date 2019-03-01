using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class FournisseurModel
    {
        public string adresse { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }

        [Key]
        public string codeFOURNISSEUR { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<Commande_marketer> Commande_marketer { get; set; }
    }
}