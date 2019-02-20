using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
    public class DAOProduit
    {
        private isoftTankEntities db = null;

        public DAOProduit()
        {
            db = new isoftTankEntities();
        }

        public Produit ajouter(Produit u)
        {
            db.Produits.Add(u);
            db.SaveChanges();

            return u;
        }

        public Produit modifier(Produit u)
        {
            //recherche de l'objet dans la bd
            Produit u2 = db.Produits.First(x => x.codePRODUIT == u.codePRODUIT);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.designation = u.designation;
                u2.libelle = u.libelle;
                u2.prix = u.prix;
                u2.unite_mesure = u.unite_mesure;

                //sauvegarde des nouvelles informations
                db.Entry(u2).State = EntityState.Modified;
                db.SaveChanges();
                return u;
            }
            else
            {
                u.designation = "Cet enregistrement n'existe pas dans la base de donnees.";
                return u;
            }
        }

        public Produit supprimer(Produit u)
        {
            Produit u2 = db.Produits.First(x => x.codePRODUIT == u.codePRODUIT);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Produits.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.designation = "Aucun enregistrement trouve.";
                return u2;
            }
        }


        public Produit rechercher(string code)
        {
            Produit u = db.Produits.First(x => x.codePRODUIT == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.designation = "Aucun enregistrement trouve.";
                return u;
            }
        }


        public IEnumerable<Produit> rechercherParMC(Func<Produit, bool> predicate)
        {
            var us = db.Produits.Where(predicate);

            return us.ToList();
        }


        public Produit rechercherUnique(Produit m)
        {
            Produit u = db.Produits.First(x => x.designation == m.designation && x.libelle == m.libelle && x.prix == m.prix && x.unite_mesure == m.unite_mesure);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            return null;

        }

        public IEnumerable<Produit> rechercherTous()
        {
            return db.Produits.ToList();

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
