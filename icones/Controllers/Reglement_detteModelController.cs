using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using brouillon.Models;
using icones.Models;

namespace icones.Controllers
{
    public class Reglement_detteModelController : Controller
    {
        private iconesContext db = new iconesContext();

        // GET: Reglement_detteModel
        public ActionResult Index()
        {
            return View(db.Reglement_detteModel.ToList());
        }

        // GET: Reglement_detteModel/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reglement_detteModel reglement_detteModel = db.Reglement_detteModel.Find(id);
            if (reglement_detteModel == null)
            {
                return HttpNotFound();
            }
            return View(reglement_detteModel);
        }

        // GET: Reglement_detteModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reglement_detteModel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codeREGLEMENT_DETTE,date_paiement,libelle,montant,codeU,codeDETTE,date_c")] Reglement_detteModel reglement_detteModel)
        {
            if (ModelState.IsValid)
            {
                db.Reglement_detteModel.Add(reglement_detteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reglement_detteModel);
        }

        // GET: Reglement_detteModel/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reglement_detteModel reglement_detteModel = db.Reglement_detteModel.Find(id);
            if (reglement_detteModel == null)
            {
                return HttpNotFound();
            }
            return View(reglement_detteModel);
        }

        // POST: Reglement_detteModel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codeREGLEMENT_DETTE,date_paiement,libelle,montant,codeU,codeDETTE,date_c")] Reglement_detteModel reglement_detteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reglement_detteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reglement_detteModel);
        }

        // GET: Reglement_detteModel/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reglement_detteModel reglement_detteModel = db.Reglement_detteModel.Find(id);
            if (reglement_detteModel == null)
            {
                return HttpNotFound();
            }
            return View(reglement_detteModel);
        }

        // POST: Reglement_detteModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Reglement_detteModel reglement_detteModel = db.Reglement_detteModel.Find(id);
            db.Reglement_detteModel.Remove(reglement_detteModel);
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
