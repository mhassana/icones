using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Dette
    {
        public Dette()
        {
            this.JoinDetteToProduits = new HashSet<JoinDetteToProduit>();
        }

        public System.DateTime date_dette { get; set; }
        public decimal montant_paye { get; set; }
        public decimal montant_restant { get; set; }
        public decimal montant_total { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeCLIENT { get; set; }
        public string codeDETTE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<JoinDetteToProduit> JoinDetteToProduits { get; set; }
    }
}
