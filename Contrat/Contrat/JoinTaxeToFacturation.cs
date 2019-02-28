using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class JoinTaxeToFacturation
    {
        public string codeU { get; set; }
        public string codeFACTURATION { get; set; }
        public string codeTAXE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Taxe Taxe { get; set; }
    }
}
