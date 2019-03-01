using ClassLibrary;
using System.Collections.Generic;

namespace brouillon.Models
{
    public class TransporteurModel
    {
        public TransporteurModel()
        {
            this.BE_export = new HashSet<BE_export>();
            this.BE_livraison = new HashSet<BE_livraison>();
            this.BE_Soutage = new HashSet<BE_Soutage>();
        }

        public string email { get; set; }
        public string localisation { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }
        public string codeTRANSPORTEUR { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<BE_export> BE_export { get; set; }
        public virtual ICollection<BE_livraison> BE_livraison { get; set; }
        public virtual ICollection<BE_Soutage> BE_Soutage { get; set; }
    }
}