using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Marketer
    {
        public Marketer()
        {
            this.BE_Transfert = new HashSet<BE_Transfert>();
            this.Commande_client = new HashSet<Commande_client>();
            this.Commande_marketer = new HashSet<Commande_marketer>();
            this.Compte_marketer = new HashSet<Compte_marketer>();
            this.Stations = new HashSet<Station>();
        }

        public string adresse { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }
        public string codeMARKETER { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<BE_Transfert> BE_Transfert { get; set; }
        public virtual ICollection<Commande_client> Commande_client { get; set; }
        public virtual ICollection<Commande_marketer> Commande_marketer { get; set; }
        public virtual ICollection<Compte_marketer> Compte_marketer { get; set; }
        public virtual ICollection<Station> Stations { get; set; }
    }
}
