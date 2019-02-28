using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOStock : IDAOStock
    {
        private isoftTankEntities db = null;

        public DAOStock()
        {
            db = new isoftTankEntities();
        }

        public Stock ajouter(Stock u)
        {
            db.Stocks.Add(u);
            db.SaveChanges();

            return u;
        }

        public Stock modifier(Stock u)
        {
            //recherche de l'objet dans la bd
            Stock u2 = db.Stocks.First(x => x.codeSTOCK == u.codeSTOCK);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.libelle = u.libelle;
                u2.quantite = u.quantite;

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

        public Stock rechercher(string code)
        {
            Stock u = db.Stocks.First(x => x.codeSTOCK == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.libelle = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public Stock supprimer(Stock u)
        {
            Stock u2 = rechercher(u.codeSTOCK);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Stocks.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.libelle = "Aucun enregistrement trouve.";
                return u2;
            }
        }

        public IEnumerable<Stock> rechercherParMC(Func<Stock, bool> predicate)
        {
            var us = db.Stocks.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<Stock> rechercherTous()
        {
            return db.Stocks.ToList();

        }

        ~DAOStock()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
