using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;
using brouillon.Models;

namespace brouillon.Controllers
{
    public class MarketerController : Controller
    {
        DAOMarketer dao = new DAOMarketer();
        // GET: Marketer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Marketer/Details/5
        public ActionResult Details(string code)
        {
            Marketer x = dao.rechercher(code);

            MarketerModel pm = new MarketerModel
            {
                CodeMARKETER = x.codeMARKETER,
                Nom = x.nom,
                Adresse = x.adresse,
                Email = x.email,
                Pays = x.pays,
                Telephone = x.telephone,
                Ville = x.ville
            };

            if (x == null)
            {
                return HttpNotFound();
            }
            return View(pm);
        }

        public ActionResult Creer()
        {
            return View("ajouter");
        }

        // GET: Marketer/Create
        public ActionResult Create(Marketer m)
        {
            Marketer m2 = dao.rechercherUnique(m);
            if (m2 == null)
            {
                CreateMarketer(m);

                return View("afficherTous");
            }

            else
            {
                return View("ajouter");
            }
        }

        // POST: Marketer/Create
        [HttpPost]
        public void CreateMarketer(Marketer m)
        {
            try
            {
                dao.ajouter(m);
            }
            catch
            {
            }
        }

        // GET: Marketer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Marketer/Edit/5
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

        // GET: Marketer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Marketer/Delete/5
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
            IEnumerable<Marketer> ls = dao.rechercherTous();

            ViewBag.listeMarketer = ls;

            return View();
        }
    }
}
