using ClassLibrary;

namespace brouillon.Models
{
    public class TrancheModel
    {
        public System.DateTime date_paiement { get; set; }
        public string libelle { get; set; }
        public decimal montant { get; set; }
        public string codeU { get; set; }
        public string codeFACTURATION { get; set; }
        public string codeTRANCHE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual FacturationClient FacturationClient { get; set; }
    }
}