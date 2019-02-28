using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Commande_marketer
    {
        public Commande_marketer()
        {
            this.BE_bac_bac = new HashSet<BE_bac_bac>();
            this.FacturationMarketers = new HashSet<FacturationMarketer>();
        }

        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeFOURNISSEUR { get; set; }
        public string codeMARKETER { get; set; }
        public string codePRODUIT { get; set; }
        public string codeCOMMANDE_MARKETER { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<BE_bac_bac> BE_bac_bac { get; set; }
        public virtual Fournisseur Fournisseur { get; set; }
        public virtual Marketer Marketer { get; set; }
        public virtual Produit Produit { get; set; }
        public virtual ICollection<FacturationMarketer> FacturationMarketers { get; set; }
    }
}
