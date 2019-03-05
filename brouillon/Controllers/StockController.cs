using brouillon.Models;
using ClassLibrary;
using ClassLibrary.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace brouillon.Controllers
{
    public class StockController : Controller
    {
        DAOStock dao = new DAOStock();
        // GET: Marketer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Stock/Details/5
        public ActionResult Details(string code)
        {
            Stock x = dao.rechercher(code);

            StockModel pm = new StockModel
            {
                codeSTOCK = x.codeSTOCK,
                libelle = x.libelle,
                quantite = x.quantite,
                codeStation = x.codeStation,
                codePRODUIT = x.codePRODUIT,

            };

            if (x == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }

        public ActionResult Creer()
        {
            return View("Create");
        }

        // GET: Stock/Create
        public ActionResult Create(Stock m)
        {
            StockModel pm = new StockModel();

            return View("Create", pm);
        }

        // POST: Stock/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Stock x = new Stock
                {
                    libelle = collection["libelle"],
                    quantite = decimal.Parse(collection["quantite"]),


                    //*******

                    codePRODUIT = collection["codePRODUIT"],
                    codeStation = collection["codeStation"],
                    codeU = collection["codeU"],
                    date_c = DateTime.Now,
                    //codePRODUIT = "PDT20192208"
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

        // GET: Stock/Edit/5
        public ActionResult Edit(string code)
        {
            Stock x = dao.rechercher(code);

            StockModel pm = new StockModel
            {
                libelle = x.libelle,
                quantite = x.quantite,


                ///*******
                /// 
                codeU = x.codeU,
                codeSTOCK = x.codeSTOCK

            };

            return View(pm);
        }

        // POST: Stock/Edit/5
        [HttpPost]
        public ActionResult Edit(Stock x)
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

        // GET: Stock/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Stock/Delete/5
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
            IEnumerable<Stock> ls = dao.rechercherTous();

            ViewBag.listeStock = ls;

            return View();
        }
    }
}