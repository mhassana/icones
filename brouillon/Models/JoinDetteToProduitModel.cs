using ClassLibrary;

namespace brouillon.Models
{
    public class JoinDetteToProduitModel
    {
        public string codeU { get; set; }
        public string codePRODUIT { get; set; }
        public string codeDETTE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Dette Dette { get; set; }
        public virtual Produit Produit { get; set; }
    }
}