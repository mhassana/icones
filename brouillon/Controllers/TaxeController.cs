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
    public class TaxeController : Controller
    {
        IDAOTaxe dao = new DAOTaxe();

        // GET: Taxe
        public ActionResult Index()
        {
            return View();
        }

        // GET: Taxe/Details/5
        public ActionResult Details(string code)
        {
            Taxe x = dao.rechercher(code);

            TaxeModel pm = new TaxeModel
            {
                codeTAXE = x.codeTAXE,
                libelle = x.libelle,
                taux = x.taux

            };

            if (x == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }


        // GET: Taxe/Create
        public ActionResult Create()
        {
            TaxeModel tm = new TaxeModel();

            return View("Create", tm);
        }

        // POST: Taxe/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                string s = "";
                s = collection["taux"];
                char decimalSymbol = ',';
                var curr = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                s = s.Replace(".", curr).Replace(decimalSymbol.ToString(), curr);

                Taxe x = new Taxe
                {
                    libelle = collection["libelle"],
                    taux = decimal.Parse(s),


                    //*******

                    codeU = collection["codeU"]
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

        // GET: Taxe/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Taxe/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("afficherTous");
            }
            catch
            {
                return View();
            }
        }

        // GET: Taxe/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Taxe/Delete/5
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
            IEnumerable<Taxe> ls = dao.rechercherTous();

            ViewBag.listeTaxe = ls;

            return View();
        }
    }
}
