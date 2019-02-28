using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Fournisseur
    {
        public Fournisseur()
        {
            this.Commande_marketer = new HashSet<Commande_marketer>();
        }

        public string adresse { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }
        public string codeFOURNISSEUR { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<Commande_marketer> Commande_marketer { get; set; }
    }
}
