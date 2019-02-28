using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary
{
    public class DAOMarketer : IDAOMarketer
    {
        private isoftTankEntities db = null;

        public DAOMarketer()
        {
            db = new isoftTankEntities();
        }

        public Marketer ajouter(Marketer u)
        {
            db.Marketers.Add(u);
            db.SaveChanges();

            return u;
        }

        public Marketer modifier(Marketer u)
        {
            //recherche de l'objet dans la bd
            Marketer u2 = db.Marketers.First(x => x.codeMARKETER == u.codeMARKETER);

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

        public Marketer rechercher(string code)
        {
            Marketer u = db.Marketers.First(x => x.codeMARKETER == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.nom = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public Marketer supprimer(Marketer u)
        {
            Marketer u2 = rechercher(u.codeMARKETER);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Marketers.Remove(u2);
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


        public Marketer rechercherUnique(Marketer m)
        {
            Marketer u = db.Marketers.First(x => x.nom == m.nom && x.pays == m.pays && x.ville == m.ville);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            return null;
            
        }

        public IEnumerable<Marketer> rechercherTous()
        {
            return db.Marketers.ToList();

        }

        ~DAOMarketer()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
