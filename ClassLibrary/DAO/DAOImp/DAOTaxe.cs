using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOTaxe : IDAOTaxe
    {
        private isoftTankEntities db = null;

        public DAOTaxe()
        {
            db = new isoftTankEntities();
        }

        public Taxe ajouter(Taxe u)
        {
            if (u == null)
                u = new Taxe();
            try
            {
                db.creerTaxe(u.libelle, u.taux, u.codeU);
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public Taxe modifier(Taxe u)
        {
            if (u == null)
                u = new Taxe();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.Taxes.First(x => x.codeTAXE == u.codeTAXE) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierTaxe(u.codeTAXE, u.libelle, u.taux, u.codeU);
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

        public Taxe supprimer(Taxe u)
        {
            if (u == null)
                u = new Taxe();
            try
            {
                if (db.Taxes.First(x => x.codeTAXE == u.codeTAXE) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerTaxe(u.codeTAXE, u.codeU);
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


        public Taxe rechercher(string code)
        {
            Taxe u = new Taxe();
            try
            {
                u = db.Taxes.First(x => x.codeTAXE == code);

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


        public List<Taxe> rechercherParMC(Func<Taxe, bool> predicate)
        {
            List<Taxe> us = new List<Taxe>();
            try
            {
                us = db.Taxes.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                Taxe p = new Taxe();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public Taxe rechercherUnique(Taxe m)
        {
            Taxe u = new Taxe();

            try
            {
                u = db.Taxes.First(x => x.libelle == m.libelle);

            }

            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public List<Taxe> rechercherTous()
        {
            List<Taxe> us = new List<Taxe>();
            try
            {
                us = db.Taxes.ToList();
            }
            catch (Exception ex)
            {
                Taxe p = new Taxe();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }

        ~DAOTaxe()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
