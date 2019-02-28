using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class JoinProduitToCommande_client
    {
        public string codeU { get; set; }
        public string codeCOMMANDE_CLIENT { get; set; }
        public string codeProduit { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Commande_client Commande_client { get; set; }
        public virtual Produit Produit { get; set; }
    }
}
