using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class BEExportModel
    {
        public string adresse { get; set; }
        public string cni_chauffeur { get; set; }
        public System.DateTime date_emission { get; set; }
        public int duree_validite { get; set; }
        public string immatriculation_camion { get; set; }
        public string nom_chauffeur { get; set; }
        public string num_decl_douane_im7 { get; set; }
        public string pays_destination { get; set; }
        public decimal quantite { get; set; }
        public string ville_destination { get; set; }
        public string codeU { get; set; }
        public string codeDEPOT { get; set; }
        public string codeCOMMANDE_CLIENT { get; set; }
        public string codeTRANSPORTEUR { get; set; }
        [Key]
        public string codeBE_EXPORT { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Commande_client Commande_client { get; set; }
        public virtual Depot Depot { get; set; }
        public virtual Transporteur Transporteur { get; set; }
    }
}