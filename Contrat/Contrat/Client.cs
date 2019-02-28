using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Client
    {
        public Client()
        {
            this.Dettes = new HashSet<Dette>();
            this.Point_consommation = new HashSet<Point_consommation>();
        }

        public string adresse { get; set; }
        public string email { get; set; }
        public string nom { get; set; }
        public string pays { get; set; }
        public string telephone { get; set; }
        public string ville { get; set; }
        public string codeU { get; set; }
        public string codeCLIENT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<Dette> Dettes { get; set; }
        public virtual ICollection<Point_consommation> Point_consommation { get; set; }
    }
}
