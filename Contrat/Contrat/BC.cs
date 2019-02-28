using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class BC
    {
        public System.DateTime date_emission { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeDEPOT { get; set; }
        public string codeBC { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Depot Depot { get; set; }
    }
}
