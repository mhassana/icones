using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Compte_marketer
    {
        public Compte_marketer()
        {
            this.Transaction_effectuee = new HashSet<Transaction_effectuee>();
        }

        public decimal montant_net { get; set; }
        public string codeU { get; set; }
        public string codeMARKETER { get; set; }
        public string codeCOMPTE_MARKETER { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Marketer Marketer { get; set; }
        public virtual ICollection<Transaction_effectuee> Transaction_effectuee { get; set; }
    }
}
