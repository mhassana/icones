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
            try
            {
                db.creerStock(u.quantite, u.codeStation, u.codePRODUIT, u.libelle, u.codeU);
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public Stock modifier(Stock u)
        {
            if (u == null)
                u = new Stock();
            
            //verification de l'existence de l'objet dans la bd
            if (db.Stocks.First(x => x.codeSTOCK == u.codeSTOCK) != null)
            {

                //sauvegarde des nouvelles informations

                db.modifierStock(u.codeSTOCK, u.quantite, u.codeStation, u.codePRODUIT, u.libelle, u.codeU);
            }

            else
            {
                u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
            }

            return u;
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
