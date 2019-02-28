namespace Contrat.Contrat
{
    public partial class TrancheMarketer
    {
        public System.DateTime date_paiement { get; set; }
        public string libelle { get; set; }
        public decimal montant { get; set; }
        public string codeU { get; set; }
        public string codeFACTURATION_MARKETER { get; set; }
        public string codeTRANCHE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual FacturationMarketer FacturationMarketer { get; set; }
    }
}
