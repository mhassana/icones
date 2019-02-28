using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Taxe
    {
        public Taxe()
        {
            this.JoinTaxeToFacturations = new HashSet<JoinTaxeToFacturation>();
        }

        public string libelle { get; set; }
        public decimal taux { get; set; }
        public string codeU { get; set; }
        public string codeTAXE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<JoinTaxeToFacturation> JoinTaxeToFacturations { get; set; }
    }
}
