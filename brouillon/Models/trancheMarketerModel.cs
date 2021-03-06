﻿using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class TrancheMarketerModel
    {
        public System.DateTime date_paiement { get; set; }
        public string libelle { get; set; }
        public decimal montant { get; set; }
        public string codeU { get; set; }
        public string codeFACTURATION_MARKETER { get; set; }

        [Key]
        public string codeTRANCHE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual FacturationMarketer FacturationMarketer { get; set; }
    }
}