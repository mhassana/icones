using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
    class DAOTrancheMarketer
    {
        private isoftTankEntities db = null;

        public DAOTrancheMarketer()
        {
            db = new isoftTankEntities();
        }

        public TrancheMarketer ajouter(TrancheMarketer u)
        {
            db.TrancheMarketers.Add(u);
            db.SaveChanges();

            return u;
        }

        public TrancheMarketer modifier(TrancheMarketer u)
        {
            //recherche de l'objet dans la bd
            TrancheMarketer u2 = db.TrancheMarketers.First(x => x.codeTRANCHE == u.codeTRANCHE);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.libelle = u.libelle;
                u2.montant = u.montant;
                u2.date_paiement = u.date_paiement;

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

        public TrancheMarketer rechercher(string code)
        {
            TrancheMarketer u = db.TrancheMarketers.First(x => x.codeTRANCHE == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.libelle = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public TrancheMarketer supprimer(TrancheMarketer u)
        {
            TrancheMarketer u2 = rechercher(u.codeTRANCHE);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.TrancheMarketers.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.libelle = "Aucun enregistrement trouve.";
                return u2;
            }
        }

        public IEnumerable<TrancheMarketer> rechercherParMC(Func<TrancheMarketer, bool> predicate)
        {
            var us = db.TrancheMarketers.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<TrancheMarketer> rechercherTous()
        {
            return db.TrancheMarketers.ToList();

        }

        ~DAOTrancheMarketer()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
