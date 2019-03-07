using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
    public class DAOProduit : IDAOProduit
    {
        private isoftTankEntities db = null;

        public DAOProduit()
        {
            db = new isoftTankEntities();
        }

        public Produit ajouter(Produit u)
        {
            if (u == null)
                u = new Produit();
            try
            {
                db.creerProduit(u.designation, u.libelle, u.prix, u.unite_mesure, u.codeU);
            }
            catch (Exception ex)
            {
                u.designation = ex.StackTrace;
            }

            return u;
        }

        public Produit modifier(Produit u)
        {
            if (u == null)
                u = new Produit();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Produits.First(x => x.codePRODUIT == u.codePRODUIT) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierProduit(u.codePRODUIT, u.designation, u.libelle, u.prix, u.unite_mesure, u.codeU);
                }

                else
                {
                    u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.designation = ex.StackTrace;
            }


            return u;
        }

        public Produit supprimer(Produit u)
        {
            if (u == null)
                u = new Produit();
            try
            {
                if (db.Produits.First(x => x.codePRODUIT == u.codePRODUIT) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerProduit(u.codePRODUIT, u.codeU);
                }

                else
                {
                    u.designation = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.designation = ex.StackTrace;
            }
            return u;
        }


        public Produit rechercher(string code)
        {
            Produit u = new Produit();
            try
            {
                u = db.Produits.First(x => x.codePRODUIT == code);

                //verification de l'existence de l'objet dans la bd
                if (u != null) return u;

                else
                {
                    u.designation = "Aucun enregistrement trouve.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                u.designation = ex.StackTrace;
            }

            return u;
        }


        public List<Produit> rechercherParMC(Func<Produit, bool> predicate)
        {
            List<Produit> us = new List<Produit>();
            try
            {
                us = db.Produits.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Produit p = new Produit();
                p.designation = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Produit rechercherUnique(Produit m)
        {
            Produit u = new Produit();

            try
            {
                u = db.Produits.FirstOrDefault(x => x.designation == m.designation && x.libelle == m.libelle && x.prix == m.prix && x.unite_mesure == m.unite_mesure);
                
            }

            catch (Exception ex)
            {
                u.designation = ex.StackTrace;
            }
            

            return u;

        }

        public List<Produit> rechercherTous()
        {
            List<Produit> us = new List<Produit>();
            try
            {
                us = db.Produits.ToList();
            }
            catch (Exception ex)
            {
                Produit p = new Produit();
                p.designation = ex.StackTrace;
                us.Add(p);
            }

            return us;

        }

        ~DAOProduit()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
