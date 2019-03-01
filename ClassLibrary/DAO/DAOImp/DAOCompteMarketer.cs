using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOCompteMarketer : IDAOCompteMarketer
    {
        private isoftTankEntities db = null;

        public DAOCompteMarketer()
        {
            db = new isoftTankEntities();
        }

        public Compte_marketer ajouter(Compte_marketer u)
        {
            if (u == null)
                u = new Compte_marketer();
            try
            {
                db.creerCompte_marketer(u.montant_net, u.codeMARKETER, u.codeU);
            }
            catch (Exception ex)
            {
                u.Marketer.adresse = ex.StackTrace;
            }

            return u;
        }

        public Compte_marketer modifier(Compte_marketer u)
        {
            if (u == null)
                u = new Compte_marketer();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Compte_marketer.First(x => x.codeCOMPTE_MARKETER == u.codeCOMPTE_MARKETER) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierCompte_marketer(u.codeCOMPTE_MARKETER, u.montant_net, u.codeMARKETER, u.codeU);
                }

                else
                {
                    u.Marketer.adresse = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.Marketer.adresse = ex.StackTrace;
            }


            return u;
        }

        public Compte_marketer supprimer(Compte_marketer u)
        {
            if (u == null)
                u = new Compte_marketer();
            try
            {
                if (db.Compte_marketer.First(x => x.codeCOMPTE_MARKETER == u.codeCOMPTE_MARKETER) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerCompte_marketer(u.codeCOMPTE_MARKETER, u.codeMARKETER, u.codeU);
                }

                else
                {
                    u.Marketer.adresse = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.Marketer.adresse = ex.StackTrace;
            }
            return u;
        }


        public Compte_marketer rechercher(string code)
        {
            Compte_marketer u = new Compte_marketer();
            try
            {
                u = db.Compte_marketer.First(x => x.codeCOMPTE_MARKETER == code);

                //verification de l'existence de l'objet dans la bd
                if (u != null) return u;

                else
                {
                    u.Marketer.adresse = "Aucun enregistrement trouve.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                u.Marketer.adresse = ex.StackTrace;
            }

            return u;
        }


        public List<Compte_marketer> rechercherParMC(Func<Compte_marketer, bool> predicate)
        {
            List<Compte_marketer> us = new List<Compte_marketer>();
            try
            {
                us = db.Compte_marketer.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Compte_marketer p = new Compte_marketer();
                p.Marketer.adresse = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Compte_marketer rechercherUnique(Compte_marketer m)
        {
            Compte_marketer u = new Compte_marketer();

            try
            {
                u = db.Compte_marketer.First(x => x.codeMARKETER == m.codeMARKETER);
            }

            catch (Exception ex)
            {
                u.Marketer.adresse = ex.StackTrace;
            }


            return u;

        }

        public List<Compte_marketer> rechercherTous()
        {
            List<Compte_marketer> us = new List<Compte_marketer>();
            try
            {
                us = db.Compte_marketer.ToList();
            }
            catch (Exception ex)
            {
                Compte_marketer p = new Compte_marketer();
                p.Marketer.adresse = ex.StackTrace;
                us.Add(p);
            }

            return us;

        }

        ~DAOCompteMarketer()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
