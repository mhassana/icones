using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using ClassLibrary.DAO;

namespace brouillon.Controllers
{
    public class ProduitController : Controller
    {
        DAOProduit dao = new DAOProduit();

        // GET: Produit
        public ActionResult Index()
        {
            return View();
        }

        // GET: Produit/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Produit/Create
        public ActionResult Create()
        {
            return View("ajouter");
        }

        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produit/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Produit/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Produit/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Produit/Delete/5
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
            IEnumerable<Produit> ls = dao.rechercherTous();

            ViewBag.listeProduit = ls;

            return View();
        }
    }
}
