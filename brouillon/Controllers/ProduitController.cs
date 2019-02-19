using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using ClassLibrary.DAO;
using brouillon.Models;

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
        public ActionResult Details(string code)
        {
            Produit produit = dao.rechercher(code);

            ProduitModel pm = new ProduitModel
            {
                CodePRODUIT = produit.codePRODUIT,
                CodeU = produit.codeU,
                date_c = produit.date_c,
                Designation = produit.designation,
                Libelle = produit.libelle,
                Prix = produit.prix,
                Unite_mesure = produit.unite_mesure
            };

            if (produit == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }

        // GET: Produit/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produit/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                var libelle = collection["Libelle"];
                var designation = collection["Designation"];
                var prix = collection["Prix"];
                var unite_mesure = collection["Unite_mesure"];
                var code_u = collection["CodeU"];

                Produit p = new Produit
                {
                    libelle = libelle,
                    designation = designation,
                    prix = decimal.Parse(prix),
                    unite_mesure = unite_mesure
                };

                dao.ajouter(p);

                return RedirectToAction("afficherTous");
            }
            catch(Exception ex)
            {
                ViewBag.Erreur = ex.Message;
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
