using ClassLibrary;
using System.Collections.Generic;

namespace brouillon.Models
{
    public class DetteModel
    {
        public DetteModel()
        {
            this.JoinDetteToProduits = new HashSet<JoinDetteToProduit>();
        }

        public System.DateTime date_dette { get; set; }
        public decimal montant_paye { get; set; }
        public decimal montant_restant { get; set; }
        public decimal montant_total { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeCLIENT { get; set; }
        public string codeDETTE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Client Client { get; set; }
        public virtual ICollection<JoinDetteToProduit> JoinDetteToProduits { get; set; }
    }
}