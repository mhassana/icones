using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
   public class DAOTransactionEffectuee
    {
        private isoftTankEntities db = null;

        public DAOTransactionEffectuee()
        {
            db = new isoftTankEntities();
        }

        public Transaction_effectuee ajouter(Transaction_effectuee u)
        {
            db.Transaction_effectuee.Add(u);
            db.SaveChanges();

            return u;
        }

        public Transaction_effectuee modifier(Transaction_effectuee u)
        {
            //recherche de l'objet dans la bd
            Transaction_effectuee u2 = db.Transaction_effectuee.First(x => x.codeTRANSACTION_EFFECTUEE == u.codeTRANSACTION_EFFECTUEE);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.libelle = u.libelle;
                u2.montant_transaction = u.montant_transaction;

                //sauvegarde des nouvelles informations

                db.SaveChanges();
                return u;
            }
            else
            {
                u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
                return u;
            }
        }

        public Transaction_effectuee rechercher(string code)
        {
            Transaction_effectuee u = db.Transaction_effectuee.First(x => x.codeTRANSACTION_EFFECTUEE == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.libelle = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public Transaction_effectuee supprimer(Transaction_effectuee u)
        {
            Transaction_effectuee u2 = rechercher(u.codeTRANSACTION_EFFECTUEE);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Transaction_effectuee.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.libelle = "Aucun enregistrement trouve.";
                return u2;
            }
        }

        public IEnumerable<Marketer> rechercherParMC(Func<Marketer, bool> predicate)
        {
            var us = db.Marketers.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<Transaction_effectuee> rechercherTous()
        {
            return db.Transaction_effectuee.ToList();

        }

        ~DAOTransactionEffectuee()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
