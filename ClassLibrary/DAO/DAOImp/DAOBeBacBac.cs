using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DAO
{
   public class DAOBeBacBac
    {
        private isoftTankEntities db = null;

        public DAOBeBacBac()
        {
            db = new isoftTankEntities();
        }

        public BE_bac_bac ajouter(BE_bac_bac u)
        {
            db.BE_bac_bac.Add(u);
            db.SaveChanges();

            return u;
        }

        public BE_bac_bac modifier(BE_bac_bac u)
        {
            //recherche de l'objet dans la bd
            BE_bac_bac u2 = db.BE_bac_bac.First(x => x.codeBE_BAC_BAC == u.codeBE_BAC_BAC);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                //mise a jour des modifications
                u2.libelle = u.libelle;
                u2.quantite = u.quantite;

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

        public BE_bac_bac rechercher(string code)
        {
            BE_bac_bac u = db.BE_bac_bac.First(x => x.codeBE_BAC_BAC == code);

            //verification de l'existence de l'objet dans la bd
            if (u != null) return u;

            else
            {
                u.libelle = "Aucun enregistrement trouve.";
                return u;
            }
        }

        public BE_bac_bac supprimer(BE_bac_bac u)
        {
            BE_bac_bac u2 = rechercher(u.codeBE_BAC_BAC);

            //verification de l'existence de l'objet dans la bd
            if (u2 != null)
            {
                db.BE_bac_bac.Remove(u2);
                db.SaveChanges();
                return u2;
            }

            else
            {
                u2.libelle = "Aucun enregistrement trouve.";
                return u2;
            }
        }

        public IEnumerable<Marketer> rechercherParMC(Func<Marketer, bool> predicate)
        {
            var us = db.Marketers.Where(predicate);

            return us.ToList();
        }

        public IEnumerable<BE_bac_bac> rechercherTous()
        {
            return db.BE_bac_bac.ToList();

        }

        ~DAOBeBacBac()
        {
            Dispose();
        }
        public void Dispose()
        {
            if (db != null) db.Dispose();
        }

    }
}
