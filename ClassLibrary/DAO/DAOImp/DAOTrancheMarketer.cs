﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.DAO.IDAO;

namespace ClassLibrary.DAO
{
   public class DAOTrancheMarketer : IDAOTrancheMarketer
    {
        private isoftTankEntities db = null;

        public DAOTrancheMarketer()
        {
            db = new isoftTankEntities();
        }

        public TrancheMarketer ajouter(TrancheMarketer u)
        {
            if (u == null)
                u = new TrancheMarketer();
            try
            {
                db.creerTranche_Marketer(u.libelle, u.montant, u.codeFACTURATION_MARKETER, u.codeU);
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public TrancheMarketer modifier(TrancheMarketer u)
        {
            if (u == null)
                u = new TrancheMarketer();
            try
            {
                //verification de l'existence de l'objet dans la bd
                if (db.TrancheMarketers.First(x => x.codeTRANCHE == u.codeTRANCHE) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.modifierTranche_Marketer(u.codeTRANCHE, u.date_paiement, u.libelle, u.montant, u.codeFACTURATION_MARKETER, u.codeU);
                }

                else
                {
                    u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }
            return u;
        }

        public TrancheMarketer supprimer(TrancheMarketer u)
        {
            if (u == null)
                u = new TrancheMarketer();
            try
            {
                if (db.TrancheMarketers.First(x => x.codeTRANCHE == u.codeTRANCHE) != null)
                {

                    //sauvegarde des nouvelles informations

                    db.supprimerTranche_Marketer(u.codeTRANCHE, u.codeFACTURATION_MARKETER, u.codeU);
                }

                else
                {
                    u.libelle = "Cet enregistrement n'existe pas dans la base de donnees.";
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }
            return u;
        }


        public TrancheMarketer rechercher(string code)
        {
            TrancheMarketer u = new TrancheMarketer();
            try
            {
                u = db.TrancheMarketers.First(x => x.codeTRANCHE == code);

                //verification de l'existence de l'objet dans la bd
                if (u != null) return u;

                else
                {
                    u.libelle = "Aucun enregistrement trouve.";
                    return null;
                }
            }
            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }


        public List<TrancheMarketer> rechercherParMC(Func<TrancheMarketer, bool> predicate)
        {
            List<TrancheMarketer> us = new List<TrancheMarketer>();
            try
            {
                us = db.TrancheMarketers.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                TrancheMarketer p = new TrancheMarketer();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
        }


        public TrancheMarketer rechercherUnique(TrancheMarketer m)
        {
            TrancheMarketer u = new TrancheMarketer();

            try
            {
                u = db.TrancheMarketers.First(x => x.libelle == m.libelle);

            }

            catch (Exception ex)
            {
                u.libelle = ex.StackTrace;
            }

            return u;
        }

        public List<TrancheMarketer> rechercherTous()
        {
            List<TrancheMarketer> us = new List<TrancheMarketer>();
            try
            {
                us = db.TrancheMarketers.ToList();
            }
            catch (Exception ex)
            {
                TrancheMarketer p = new TrancheMarketer();
                p.libelle = ex.StackTrace;
                us.Add(p);
            }

            return us;
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
