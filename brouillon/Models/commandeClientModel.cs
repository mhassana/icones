using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class CommandeClientModel
    {
        public CommandeClientModel()
        {
            this.BE_export = new HashSet<BE_export>();
            this.BE_livraison = new HashSet<BE_livraison>();
            this.BE_Soutage = new HashSet<BE_Soutage>();
            this.FacturationClients = new HashSet<FacturationClient>();
            this.JoinProduitToCommande_client = new HashSet<JoinProduitToCommande_client>();
            this.Receptions = new HashSet<Reception>();
        }

        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codePOINT_CONSOMMATION { get; set; }
        public string codeMARKETER { get; set; }
        public string codePRODUIT { get; set; }

        [Key]
        public string codeCOMMANDE_CLIENT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<BE_export> BE_export { get; set; }
        public virtual ICollection<BE_livraison> BE_livraison { get; set; }
        public virtual ICollection<BE_Soutage> BE_Soutage { get; set; }
        public virtual Marketer Marketer { get; set; }
        public virtual Point_consommation Point_consommation { get; set; }
        public virtual Produit Produit { get; set; }
        public virtual ICollection<FacturationClient> FacturationClients { get; set; }
        public virtual ICollection<JoinProduitToCommande_client> JoinProduitToCommande_client { get; set; }
        public virtual ICollection<Reception> Receptions { get; set; }
    }
}