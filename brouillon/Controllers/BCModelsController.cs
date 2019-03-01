using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using brouillon.Models;

namespace brouillon.Controllers
{
    public class BCModelsController : Controller
    {
        private brouillonContext db = new brouillonContext();

        // GET: BCModels
        public ActionResult Index()
        {
            return View(db.BCModels.ToList());
        }

        // GET: BCModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCModel bCModel = db.BCModels.Find(id);
            if (bCModel == null)
            {
                return HttpNotFound();
            }
            return View(bCModel);
        }

        // GET: BCModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BCModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeBC,date_emission,quantite,codeU,codeDEPOT,date_c")] BCModel bCModel)
        {
            if (ModelState.IsValid)
            {
                db.BCModels.Add(bCModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bCModel);
        }

        // GET: BCModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCModel bCModel = db.BCModels.Find(id);
            if (bCModel == null)
            {
                return HttpNotFound();
            }
            return View(bCModel);
        }

        // POST: BCModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeBC,date_emission,quantite,codeU,codeDEPOT,date_c")] BCModel bCModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bCModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bCModel);
        }

        // GET: BCModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BCModel bCModel = db.BCModels.Find(id);
            if (bCModel == null)
            {
                return HttpNotFound();
            }
            return View(bCModel);
        }

        // POST: BCModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BCModel bCModel = db.BCModels.Find(id);
            db.BCModels.Remove(bCModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
