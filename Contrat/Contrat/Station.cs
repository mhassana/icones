using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Station
    {
        public Station()
        {
            this.Pompistes = new HashSet<Pompiste>();
            this.Stocks = new HashSet<Stock>();
            this.Tankers = new HashSet<Tanker>();
        }

        public string adresse { get; set; }
        public string email { get; set; }
        public string localisation { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }
        public string codeMARKETER { get; set; }
        public string codeStation { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Marketer Marketer { get; set; }
        public virtual ICollection<Pompiste> Pompistes { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<Tanker> Tankers { get; set; }
    }
}
