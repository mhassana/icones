using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class ProduitModel
    {
        public ProduitModel()
        {
            this.Commande_client = new HashSet<Commande_client>();
            this.Commande_marketer = new HashSet<Commande_marketer>();
            this.JoinDetteToProduits = new HashSet<JoinDetteToProduit>();
            this.JoinProduitToCommande_client = new HashSet<JoinProduitToCommande_client>();
            this.Stocks = new HashSet<Stock>();
            this.Tankers = new HashSet<Tanker>();
        }

        [Key]
        public string CodePRODUIT { get; set; }

        public string Libelle { get; set; }

        public string Designation { get; set; }

        public decimal Prix { get; set; }

        public string Unite_mesure { get; set; }

        public DateTime date_c { get; set; }

        public string CodeU { get; set; }

        public virtual ICollection<Commande_client> Commande_client { get; set; }
        public virtual ICollection<Commande_marketer> Commande_marketer { get; set; }
        public virtual ICollection<JoinDetteToProduit> JoinDetteToProduits { get; set; }
        public virtual ICollection<JoinProduitToCommande_client> JoinProduitToCommande_client { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Tanker> Tankers { get; set; }
    }
}