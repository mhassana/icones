using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class depotModel
    {
        public string adresse { get; set; }
        public string email { get; set; }
        public string localisation { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }
        public string codeDEPOT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<BC> BCs { get; set; }
        public virtual ICollection<BE_export> BE_export { get; set; }
        public virtual ICollection<BE_livraison> BE_livraison { get; set; }
        public virtual ICollection<BE_Soutage> BE_Soutage { get; set; }
        public virtual ICollection<BE_Transfert> BE_Transfert { get; set; }
    }
}