using ClassLibrary;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace brouillon.Models
{
    public class UtilisateurModel
    {
        public UtilisateurModel()
        {
            this.Compte_utilisateur = new HashSet<Compte_utilisateur>();
        }

        public string email { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string telephone { get; set; }
        public string codeU { get; set; }

        [Key]
        public string codeUTILISATEUR { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual ICollection<Compte_utilisateur> Compte_utilisateur { get; set; }
    }
}