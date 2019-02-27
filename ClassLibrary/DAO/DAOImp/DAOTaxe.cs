using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
   public class DAOTaxe
    {
        private isoftTankEntities db = null;

        public DAOTaxe()
        {
            db = new isoftTankEntities();
        }

        public Taxe ajouter(Taxe u)
        {
            db.Taxes.Add(u);
            db.SaveChanges();

            return u;
        }

        public Taxe modifier(Taxe u)
        {
            //recherche de l'objet dans la bd
            Taxe u2 = db.Taxes.First(x => x.codeTAXE == u.codeTAXE);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.libelle = u.libelle;
                u2.taux = u.taux;
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

        public Taxe rechercher(string code)
        {
            Taxe u = db.Taxes.First(x => x.codeTAXE == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.libelle = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public Taxe supprimer(Taxe u)
        {
            Taxe u2 = rechercher(u.codeTAXE);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Taxes.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.libelle = "Aucun enregistrement trouve.";
                return u2;
            }
        }

        public IEnumerable<Taxe> rechercherParMC(Func<Taxe, bool> predicate)
        {
            var us = db.Taxes.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<Taxe> rechercherTous()
        {
            return db.Taxes.ToList();

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
