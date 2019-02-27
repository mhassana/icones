using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
    class DAOJoinTaxeToFacturation
    {
        private isoftTankEntities db = null;

        public DAOJoinTaxeToFacturation()
        {
            db = new isoftTankEntities();
        }

        public JoinTaxeToFacturation ajouter(JoinTaxeToFacturation u)
        {
            db.JoinTaxeToFacturations.Add(u);
            db.SaveChanges();

            return u;
        }

        public JoinTaxeToFacturation modifier(JoinTaxeToFacturation u)
        {
            //recherche de l'objet dans la bd
            JoinTaxeToFacturation u2 = db.JoinTaxeToFacturations.First(x => x.codeJoinTaxeToFacturation == u.codeJoinTaxeToFacturation);

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

        public JoinTaxeToFacturation rechercher(string code)
        {
            JoinTaxeToFacturation u = db.JoinTaxeToFacturations.First(x => x.codeJoinTaxeToFacturation == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.nom = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public JoinTaxeToFacturation supprimer(JoinTaxeToFacturation u)
        {
            JoinTaxeToFacturation u2 = rechercher(u.codeJoinTaxeToFacturation);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.JoinTaxeToFacturations.Remove(u2);
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

        public IEnumerable<JoinTaxeToFacturation> rechercherTous()
        {
            return db.JoinTaxeToFacturations.ToList();

        }

        ~DAOJoinTaxeToFacturation()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
