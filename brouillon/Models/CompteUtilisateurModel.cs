using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace brouillon.Models
{
    public class CompteUtilisateurModel
    {
        public CompteUtilisateurModel()
        {
            this.Historiques = new HashSet<Historique>();
        }

        public string indice { get; set; }
        public string login { get; set; }
        public string mdp { get; set; }
        public string niveau { get; set; }
        public string statut { get; set; }
        public string codeU { get; set; }
        public string codeUTILISATEUR { get; set; }

        [Key]
        public string codeCOMPTE_UTILISATEUR { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Utilisateur Utilisateur { get; set; }
        public virtual ICollection<Historique> Historiques { get; set; }
    }
}