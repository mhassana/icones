using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Vente_carburant
    {
        public int compteur_apres { get; set; }
        public int compteur_avant { get; set; }
        public System.DateTime date_vente { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codePOMPE { get; set; }
        public string codePOMPISTE { get; set; }
        public string codeVENTE_CARBURANT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Pompiste Pompiste { get; set; }
    }
}
