using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
    class DAOFacturationMarketer
    {
        private isoftTankEntities db = null;

        public DAOFacturationMarketer()
        {
            db = new isoftTankEntities();
        }

        public FacturationMarketer ajouter(FacturationMarketer u)
        {
            db.FacturationMarketers.Add(u);
            db.SaveChanges();

            return u;
        }

        public FacturationMarketer modifier(FacturationMarketer u)
        {
            //recherche de l'objet dans la bd
            FacturationMarketer u2 = db.FacturationMarketers.First(x => x.codeFACTURATION_MARKETER == u.codeFACTURATION_MARKETER);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.libelle = u.libelle;
                u2.libelle = u.libelle;
                u2.montant_restant = u.montant_restant;
                u2.montant_total = u.montant_total;

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

        public FacturationMarketer rechercher(string code)
        {
            FacturationMarketer u = db.FacturationMarketers.First(x => x.codeFACTURATION_MARKETER == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.libelle = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public FacturationMarketer supprimer(FacturationMarketer u)
        {
            FacturationMarketer u2 = rechercher(u.codeFACTURATION_MARKETER);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.FacturationMarketers.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.libelle = "Aucun enregistrement trouve.";
                return u2;
            }
        }

        public IEnumerable<FacturationMarketer> rechercherParMC(Func<FacturationMarketer, bool> predicate)
        {
            var us = db.FacturationMarketers.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<FacturationMarketer> rechercherTous()
        {
            return db.FacturationMarketers.ToList();

        }

        ~DAOFacturationMarketer()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
