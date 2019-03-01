using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOTransaction_effectuee : IDAOTransaction_effectuee
    {
        private isoftTankEntities db = null;

        public DAOTransaction_effectuee()
        {
            db = new isoftTankEntities();
        }

        public Transaction_effectuee ajouter(Transaction_effectuee u)
        {
            if (u == null)
                u = new Transaction_effectuee();
            try
            {
                db.creerTransaction_effectuee(u.libelle, u.montant_transaction, u.codeCOMPTE_MARKETER, u.codeU);
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public Transaction_effectuee modifier(Transaction_effectuee u)
        {
            if (u == null)
                u = new Transaction_effectuee();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Transaction_effectuee.First(x => x.codeTRANSACTION_EFFECTUEE == u.codeTRANSACTION_EFFECTUEE) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierTransaction_effectuee(u.codeTRANSACTION_EFFECTUEE, u.date_transaction, u.libelle, u.montant_transaction, u.codeCOMPTE_MARKETER, u.codeU);
                }

                else
                {
                    u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }
            return u;
        }

        public Transaction_effectuee supprimer(Transaction_effectuee u)
        {
            if (u == null)
                u = new Transaction_effectuee();
            try
            {
                if (db.Transaction_effectuee.First(x => x.codeTRANSACTION_EFFECTUEE == u.codeTRANSACTION_EFFECTUEE) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerTransaction_effectuee(u.codeTRANSACTION_EFFECTUEE, u.codeCOMPTE_MARKETER, u.codeU);
                }

                else
                {
                    u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }
            return u;
        }


        public Transaction_effectuee rechercher(string code)
        {
            Transaction_effectuee u = new Transaction_effectuee();
            try
            {
                u = db.Transaction_effectuee.First(x => x.codeTRANSACTION_EFFECTUEE == code);

                //verification de l'existence de l'objet dans la bd
                if (u != null) return u;

                else
                {
                    u.libelle = "Aucun enregistrement trouve.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }


        public List<Transaction_effectuee> rechercherParMC(Func<Transaction_effectuee, bool> predicate)
        {
            List<Transaction_effectuee> us = new List<Transaction_effectuee>();
            try
            {
                us = db.Transaction_effectuee.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Transaction_effectuee p = new Transaction_effectuee();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Transaction_effectuee rechercherUnique(Transaction_effectuee m)
        {
            Transaction_effectuee u = new Transaction_effectuee();

            try
            {
                u = db.Transaction_effectuee.First(x => x.libelle == m.libelle);

            }

            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public List<Transaction_effectuee> rechercherTous()
        {
            List<Transaction_effectuee> us = new List<Transaction_effectuee>();
            try
            {
                us = db.Transaction_effectuee.ToList();
            }
            catch (Exception ex)
            {
                Transaction_effectuee p = new Transaction_effectuee();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }

        ~DAOTransaction_effectuee()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
