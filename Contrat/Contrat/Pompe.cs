using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Pompe
    {
        public string libelle { get; set; }
        public string codeU { get; set; }
        public string codeTANKER { get; set; }
        public string codePOMPE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Tanker Tanker { get; set; }
    }
}
