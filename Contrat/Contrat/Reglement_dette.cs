using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Reglement_dette
    {
        public System.DateTime date_paiement { get; set; }
        public string libelle { get; set; }
        public decimal montant { get; set; }
        public string codeU { get; set; }
        public string codeDETTE { get; set; }
        public string codeREGLEMENT_DETTE { get; set; }
        public System.DateTime date_c { get; set; }
    }
}
