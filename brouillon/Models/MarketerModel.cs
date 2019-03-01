using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using System.ComponentModel.DataAnnotations;

namespace brouillon.Models
{
    public class MarketerModel
    {
        public MarketerModel()
        {
            this.BE_Transfert = new HashSet<BE_Transfert>();
            this.Commande_client = new HashSet<Commande_client>();
            this.Commande_marketer = new HashSet<Commande_marketer>();
            this.Compte_marketer = new HashSet<Compte_marketer>();
            this.Stations = new HashSet<Station>();
        }

        [Key]
        public string CodeMARKETER { get; set; }

        public string Nom { get; set; }

        public string Telephone { get; set; }

        public string Email { get; set; }

        public string Adresse { get; set; }

        public string Ville { get; set; }

        public string Pays { get; set; }

        public virtual ICollection<BE_Transfert> BE_Transfert { get; set; }
        public virtual ICollection<Commande_client> Commande_client { get; set; }
        public virtual ICollection<Commande_marketer> Commande_marketer { get; set; }
        public virtual ICollection<Compte_marketer> Compte_marketer { get; set; }
        public virtual ICollection<Station> Stations { get; set; }

    }
}