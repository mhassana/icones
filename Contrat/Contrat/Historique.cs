using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Historique
    {
        public System.DateTime date_connexion { get; set; }
        public System.DateTime date_deconmexion { get; set; }
        public int nbe_tentative { get; set; }
        public string operation_effectuee { get; set; }
        public string codeCompteU { get; set; }
        public string codeHISTORIQUE { get; set; }

        public virtual Compte_utilisateur Compte_utilisateur { get; set; }
    }
}
