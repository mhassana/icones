using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contrat.Contrat
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            this.Compte_utilisateur = new HashSet<Compte_utilisateur>();
        }

        public string email { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string telephone { get; set; }
        public string codeU { get; set; }
        public string codeUTILISATEUR { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<Compte_utilisateur> Compte_utilisateur { get; set; }
    }
}
