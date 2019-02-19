using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
    class DAODepot
    {
        private isoftTankEntities db = null;

        public DAODepot()
        {
            db = new isoftTankEntities();
        }

        public Depot ajouter(Depot u)
        {
            db.Depots.Add(u);
            db.SaveChanges();

            return u;
        }

        public Depot modifier(Depot u)
        {
            //recherche de l'objet dans la bd
            Depot u2 = db.Depots.First(x => x.codeDEPOT == u.codeDEPOT);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.adresse = u.adresse;
                u2.email = u.email;
                u2.nom = u.nom;
                u2.pays = u.pays;
                u2.telephone = u.telephone;
                u2.ville = u.ville;
                u2.localisation = u.localisation;

                //sauvegarde des nouvelles informations

                db.SaveChanges();
                return u;
            }
            else
            {
                u.nom = "Cet enregistrement n'existe pas dans la base de donnees.";
                return u;
            }
        }

        public Depot rechercher(string code)
        {
            Depot u = db.Depots.First(x => x.codeDEPOT == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.nom = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public Depot supprimer(Depot u)
        {
            Depot u2 = rechercher(u.codeDEPOT);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Depots.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.nom = "Aucun enregistrement trouve.";
                return u2;
            }
        }

        public IEnumerable<Marketer> rechercherParMC(Func<Marketer, bool> predicate)
        {
            var us = db.Marketers.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<Depot> rechercherTous()
        {
            return db.Depots.ToList();

        }

        ~DAODepot()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
