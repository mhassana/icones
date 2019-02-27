using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
   public class DAOCommandeMarketer
    {
        private isoftTankEntities db = null;

        public DAOCommandeMarketer()
        {
            db = new isoftTankEntities();
        }

        public Commande_marketer ajouter(Commande_marketer u)
        {
            db.Commande_marketer.Add(u);
            db.SaveChanges();

            return u;
        }

        public Commande_marketer modifier(Commande_marketer u)
        {
            //recherche de l'objet dans la bd
            Commande_marketer u2 = db.Commande_marketer.First(x => x.codeCOMMANDE_MARKETER == u.codeCOMMANDE_MARKETER);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.quantite = u.quantite;

                //sauvegarde des nouvelles informations

                db.SaveChanges();
                return u;
            }
            else
            {
                u.quantite = 0;
                return u;
            }
        }

        public Commande_marketer rechercher(string code)
        {
            Commande_marketer u = db.Commande_marketer.First(x => x.codeCOMMANDE_MARKETER == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.quantite = 0;
                return u;
            }
        }

        public Commande_marketer supprimer(Commande_marketer u)
        {
            Commande_marketer u2 = rechercher(u.codeCOMMANDE_MARKETER);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Commande_marketer.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.quantite = 0;
                return u2;
            }
        }

        public IEnumerable<Commande_marketer> rechercherParMC(Func<Commande_marketer, bool> predicate)
        {
            var us = db.Commande_marketer.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<Commande_marketer> rechercherTous()
        {
            return db.Commande_marketer.ToList();

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
