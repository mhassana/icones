using ClassLibrary;

namespace brouillon.Models
{
    public class ReceptionModel
    {
        public System.DateTime date_reception { get; set; }
        public decimal quantite { get; set; }
        public string codeU { get; set; }
        public string codeCOMMANDE_CLIENT { get; set; }
        public string codeRECEPTION { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Commande_client Commande_client { get; set; }
    }
}