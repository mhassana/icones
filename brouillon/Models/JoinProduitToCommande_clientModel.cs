using ClassLibrary;
namespace brouillon.Models
{
    public class JoinProduitToCommande_clientModel
    {
        public string codeU { get; set; }
        public string codeCOMMANDE_CLIENT { get; set; }
        public string codeProduit { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Commande_client Commande_client { get; set; }
        public virtual Produit Produit { get; set; }
    }
}