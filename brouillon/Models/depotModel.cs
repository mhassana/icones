using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class depotModel
    {
        public depotModel()
        {
            this.BCs = new HashSet<BC>();
            this.BE_export = new HashSet<BE_export>();
            this.BE_livraison = new HashSet<BE_livraison>();
            this.BE_Soutage = new HashSet<BE_Soutage>();
            this.BE_Transfert = new HashSet<BE_Transfert>();
        }
        public string adresse { get; set; }
        public string email { get; set; }
        public string localisation { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }
        [Key]
        public string codeDEPOT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<BC> BCs { get; set; }
        public virtual ICollection<BE_export> BE_export { get; set; }
        public virtual ICollection<BE_livraison> BE_livraison { get; set; }
        public virtual ICollection<BE_Soutage> BE_Soutage { get; set; }
        public virtual ICollection<BE_Transfert> BE_Transfert { get; set; }
    }
}