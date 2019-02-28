using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Pompiste
    {
        public Pompiste()
        {
            this.Vente_carburant = new HashSet<Vente_carburant>();
        }

        public string adresse { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string telephone { get; set; }
        public string codeStation { get; set; }
        public string codeU { get; set; }
        public string codePOMPISTE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Station Station { get; set; }
        public virtual ICollection<Vente_carburant> Vente_carburant { get; set; }
    }
}
