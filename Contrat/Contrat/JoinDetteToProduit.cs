using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class JoinDetteToProduit
    {
        public string codeU { get; set; }
        public string codePRODUIT { get; set; }
        public string codeDETTE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Dette Dette { get; set; }
        public virtual Produit Produit { get; set; }
    }
}
