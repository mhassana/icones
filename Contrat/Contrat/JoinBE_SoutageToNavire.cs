using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class JoinBE_SoutageToNavire
    {
        public string codeU { get; set; }
        public string codeNAVIRE { get; set; }
        public string codeBE_SOUTAGE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual BE_soutage BE_Soutage { get; set; }
        public virtual Navire Navire { get; set; }
    }
}
