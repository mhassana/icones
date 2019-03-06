using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClassLibrary;
using ClassLibrary.DAO;
using ClassLibrary.DAO.IDAO;
using brouillon.Models;
using System.Data;

namespace brouillon.Controllers
{
    public class TrancheMarketerController : Controller
    {
        IDAOTrancheMarketer dao = new DAOTrancheMarketer();

        // GET: TrancheMarketer
        public ActionResult Index()
        {
            return View();
        }

        // GET: TrancheMarketer/Details/5
        public ActionResult Details(string code)
        {
            TrancheMarketer x = dao.rechercher(code);

            TrancheMarketerModel pm = new TrancheMarketerModel
            {
                codeTRANCHE = x.codeTRANCHE,
                date_paiement = x.date_paiement,
                montant = x.montant,
                libelle = x.libelle

            };

            if (x == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }


        // GET: TrancheMarketer/Create
        public ActionResult Create()
        {
            TrancheMarketerModel tm = new TrancheMarketerModel();

            return View("Create", tm);
        }

        // POST: TrancheMarketer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                string s = "";
                s = collection["montant"];
                char decimalSymbol = ',';
                var curr = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                s = s.Replace(".", curr).Replace(decimalSymbol.ToString(), curr);

                TrancheMarketer x = new TrancheMarketer
                {
                    libelle = collection["libelle"],
                    date_paiement = DateTime.Now,
                    montant = decimal.Parse(s),


                    //*******

                    codeU = collection["codeU"],
                    codeFACTURATION_MARKETER = collection["codeFACTURATION_MARKETER"]
                    //date_c = DateTime.Now
                };

                dao.ajouter(x);


                return RedirectToAction("afficherTous");
            }
            catch (Exception ex)
            {
                ViewBag.Erreur = ex.Message;
                return View();
            }
        }

        // GET: TrancheMarketer/Edit/5
        public ActionResult Edit(string code)
        {
            TrancheMarketer x = dao.rechercher(code);

            TrancheMarketerModel pm = new TrancheMarketerModel
            {
                date_paiement = x.date_paiement,
                montant = x.montant,
                libelle = x.libelle,


                ///*******
                /// 
                codeU = x.codeU,
                codeTRANCHE = x.codeTRANCHE

            };

            return View(pm);
        }

        // POST: TrancheMarketer/Edit/5
        [HttpPost]
        public ActionResult Edit(TrancheMarketer x)
        {
            try
            {


                dao.modifier(x);
                // TODO: Add update logic here

                return RedirectToAction("afficherTous");
            }
            catch
            {
                return View();
            }
        }

        // GET: TrancheMarketer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TrancheMarketer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult afficherTous()
        {
            IEnumerable<TrancheMarketer> ls = dao.rechercherTous();

            ViewBag.listeTrancheMarketer = ls;

            return View();
        }
    }
}