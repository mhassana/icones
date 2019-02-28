using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Point_consommation
    {
        public Point_consommation()
        {
            this.Commande_client = new HashSet<Commande_client>();
        }

        public string adresse { get; set; }
        public string email { get; set; }
        public string localisation { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }
        public string codeCLIENT { get; set; }
        public string codePOINT_CONSOMMATION { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<Commande_client> Commande_client { get; set; }
    }
}
