using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
   public class DAOCompteMarketer
    {
        private isoftTankEntities db = null;

        public DAOCompteMarketer()
        {
            db = new isoftTankEntities();
        }

        public Compte_marketer ajouter(Compte_marketer u)
        {
            db.Compte_marketer.Add(u);
            db.SaveChanges();

            return u;
        }

        public Compte_marketer modifier(Compte_marketer u)
        {
            //recherche de l'objet dans la bd
            Compte_marketer u2 = db.Compte_marketer.First(x => x.codeCOMPTE_MARKETER == u.codeCOMPTE_MARKETER);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.montant_net = u.montant_net;

                //sauvegarde des nouvelles informations

                db.SaveChanges();
                return u;
            }
            else
            {
                u.montant_net = 0;
                return u;
            }
        }

        public Compte_marketer rechercher(string code)
        {
            Compte_marketer u = db.Compte_marketer.First(x => x.codeCOMPTE_MARKETER == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.montant_net = 0;
                return u;
            }
        }

        public Compte_marketer supprimer(Compte_marketer u)
        {
            Compte_marketer u2 = rechercher(u.codeCOMPTE_MARKETER);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Compte_marketer.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.montant_net = 0;
                return u2;
            }
        }

        public IEnumerable<Compte_marketer> rechercherParMC(Func<Compte_marketer, bool> predicate)
        {
            var us = db.Compte_marketer.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<Compte_marketer> rechercherTous()
        {
            return db.Compte_marketer.ToList();

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
