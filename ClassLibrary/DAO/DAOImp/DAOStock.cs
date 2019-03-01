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
            if (u == null)
                u = new Stock();
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
            try
            {
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
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }
            return u;
        }

        public Stock supprimer(Stock u)
        {
            if (u == null)
                u = new Stock();
            try
            {
                if (db.Stocks.First(x => x.codeSTOCK == u.codeSTOCK) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerStock(u.codeSTOCK, u.codeStation, u.codePRODUIT, u.codeU);
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


        public Stock rechercher(string code)
        {
            Stock u = new Stock();
            try
            {
                u = db.Stocks.First(x => x.codeSTOCK == code);

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


        public List<Stock> rechercherParMC(Func<Stock, bool> predicate)
        {
            List<Stock> us = new List<Stock>();
            try
            {
                us = db.Stocks.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Stock p = new Stock();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Stock rechercherUnique(Stock m)
        {
            Stock u = new Stock();

            try
            {
                u = db.Stocks.First(x => x.libelle == m.libelle);

            }

            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }
            
            return u;
        }

        public List<Stock> rechercherTous()
        {
            List<Stock> us = new List<Stock>();
            try
            {
                us = db.Stocks.ToList();
            }
            catch (Exception ex)
            {
                Stock p = new Stock();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
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
