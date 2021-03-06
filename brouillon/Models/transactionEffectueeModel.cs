﻿using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace brouillon.Models
{
    public class TransactionEffectueeModel
    {
        public System.DateTime date_transaction { get; set; }
        public string libelle { get; set; }
        public decimal montant_transaction { get; set; }
        public string codeU { get; set; }
        public string codeCOMPTE_MARKETER { get; set; }

        [Key]
        public string codeTRANSACTION_EFFECTUEE { get; set; }
        public System.DateTime date_c { get; set; }

        public virtual Compte_marketer Compte_marketer { get; set; }
    }
}