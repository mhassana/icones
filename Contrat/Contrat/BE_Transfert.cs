using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class BE_Transfert
    {
        public System.DateTime date_emission { get; set; }
        public int duree_validite { get; set; }
        public string immatriculation_camion { get; set; }
        public string nom_chauffeur { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeDEPOT { get; set; }
        public string codeMARKETER { get; set; }
        public string codeBE_TRANSFERT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Depot Depot { get; set; }
        public virtual Marketer Marketer { get; set; }
    }
}
