using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClassLibrary;

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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Marketer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marketer/Create
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
