using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary.DAO.IDAO;


namespace ClassLibrary.DAO
{
   public class DAOCommandeMarketer : IDAOCommandeMarketer
    {
        private isoftTankEntities db = null;

        public DAOCommandeMarketer()
        {
            db = new isoftTankEntities();
        }

        public Commande_marketer ajouter(Commande_marketer u)
        {
            if (u == null)
                u = new Commande_marketer();
            try
            {
                db.creerCommande_marketer(u.quantite, u.codeMARKETER, u.codeFOURNISSEUR, u.codePRODUIT, u.codeU);
            }
            catch (Exception ex)
            {
                u.Produit.designation = ex.StackTrace;
            }

            return u;
        }

        public Commande_marketer modifier(Commande_marketer u)
        {
            if (u == null)
                u = new Commande_marketer();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Commande_marketer.First(x => x.codeCOMMANDE_MARKETER == u.codeCOMMANDE_MARKETER) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierCommande_marketer(u.codeCOMMANDE_MARKETER, u.quantite, u.codeMARKETER, u.codeFOURNISSEUR, u.codePRODUIT, u.codeU);
                }

                else
                {
                    u.Produit.designation = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.Produit.designation = ex.StackTrace;
            }


            return u;
        }

        public Commande_marketer supprimer(Commande_marketer u)
        {
            if (u == null)
                u = new Commande_marketer();
            try
            {
                if (db.Commande_marketer.First(x => x.codeCOMMANDE_MARKETER == u.codeCOMMANDE_MARKETER) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerCommande_marketer(u.codeCOMMANDE_MARKETER, u.codeMARKETER, u.codeFOURNISSEUR, u.codePRODUIT, u.codeU);
                }

                else
                {
                    u.Produit.designation = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.Produit.designation = ex.StackTrace;
            }
            return u;
        }


        public Commande_marketer rechercher(string code)
        {
            Commande_marketer u = new Commande_marketer();
            try
            {
                u = db.Commande_marketer.First(x => x.codeCOMMANDE_MARKETER == code);

                //verification de l'existence de l'objet dans la bd
                if (u != null) return u;

                else
                {
                    u.Produit.designation = "Aucun enregistrement trouve.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                u.Produit.designation = ex.StackTrace;
            }

            return u;
        }


        public List<Commande_marketer> rechercherParMC(Func<Commande_marketer, bool> predicate)
        {
            List<Commande_marketer> us = new List<Commande_marketer>();
            try
            {
                us = db.Commande_marketer.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Commande_marketer p = new Commande_marketer();
                p.Produit.designation = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        //public Commande_marketer rechercherUnique(Commande_marketer m)
        //{
        //    Commande_marketer u = new Commande_marketer();

        //    try
        //    {
        //        u = db.Commande_marketer.First(x => x.quantite == m.quantite && x.libelle == m.libelle && x.prix == m.prix && x.unite_mesure == m.unite_mesure);

        //    }

        //    catch (Exception ex)
        //    {
        //        u.designation = ex.StackTrace;
        //    }


        //    return u;

        //}

        public List<Commande_marketer> rechercherTous()
        {
            List<Commande_marketer> us = new List<Commande_marketer>();
            try
            {
                us = db.Commande_marketer.ToList();
            }
            catch (Exception ex)
            {
                Commande_marketer p = new Commande_marketer();
                p.Produit.designation = ex.StackTrace;
                us.Add(p);
            }

            return us;

        }

        ~DAOCommandeMarketer()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
