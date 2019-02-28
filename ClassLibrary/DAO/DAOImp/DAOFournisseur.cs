using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOFournisseur : IDAOFournisseur
    {
        private isoftTankEntities db = null;

        public DAOFournisseur()
        {
            db = new isoftTankEntities();
        }

        public Fournisseur ajouter(Fournisseur u)
        {
            db.Fournisseurs.Add(u);
            db.SaveChanges();

            return u;
        }

        public Fournisseur modifier(Fournisseur u)
        {
            //recherche de l'objet dans la bd
            Fournisseur u2 = db.Fournisseurs.First(x => x.codeFOURNISSEUR == u.codeFOURNISSEUR);

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

        public Fournisseur rechercher(string code)
        {
            Fournisseur u = db.Fournisseurs.First(x => x.codeFOURNISSEUR == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.nom = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public Fournisseur supprimer(Fournisseur u)
        {
            Fournisseur u2 = rechercher(u.codeFOURNISSEUR);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.Fournisseurs.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.nom = "Aucun enregistrement trouve.";
                return u2;
            }
        }

        public IEnumerable<Fournisseur> rechercherParMC(Func<Fournisseur, bool> predicate)
        {
            var us = db.Fournisseurs.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<Fournisseur> rechercherTous()
        {
            return db.Fournisseurs.ToList();

        }

        ~DAOFournisseur()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
