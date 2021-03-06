﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public class Produit
    {
        public Produit()
        {
            this.Commande_client = new HashSet<Commande_client>();
            this.Commande_marketer = new HashSet<Commande_marketer>();
            this.JoinDetteToProduits = new HashSet<JoinDetteToProduit>();
            this.JoinProduitToCommande_client = new HashSet<JoinProduitToCommande_client>();
            this.Stocks = new HashSet<Stock>();
            this.Tankers = new HashSet<Tanker>();
        }

        public string designation { get; set; }
        public string libelle { get; set; }
        public decimal prix { get; set; }
        public string unite_mesure { get; set; }
        public string codeU { get; set; }
        public string codePRODUIT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<Commande_client> Commande_client { get; set; }
        public virtual ICollection<Commande_marketer> Commande_marketer { get; set; }
        public virtual ICollection<JoinDetteToProduit> JoinDetteToProduits { get; set; }
        public virtual ICollection<JoinProduitToCommande_client> JoinProduitToCommande_client { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Tanker> Tankers { get; set; }
    }
}
