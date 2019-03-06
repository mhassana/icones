using brouillon.Models;
using ClassLibrary;
using ClassLibrary.DAO;
using ClassLibrary.DAO.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace brouillon.Controllers
{
    public class TransactionEffectueeController : Controller
    {
        IDAOTransaction_effectuee dao = new DAOTransaction_effectuee();
        // GET: Marketer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transaction_effectuee/Details/5
        public ActionResult Details(string code)
        {
            Transaction_effectuee x = dao.rechercher(code);

            TransactionEffectueeModel pm = new TransactionEffectueeModel
            {
                codeTRANSACTION_EFFECTUEE = x.codeTRANSACTION_EFFECTUEE,
                libelle = x.libelle,
                montant_transaction = x.montant_transaction,
                codeCOMPTE_MARKETER = x.codeCOMPTE_MARKETER,
                codeU = x.codeU

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

        // GET: Transaction_effectuee/Create
        public ActionResult Create(Transaction_effectuee m)
        {
            TransactionEffectueeModel pm = new TransactionEffectueeModel();

            return View("Create", pm);
        }

        // POST: Transaction_effectuee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                string s = "";
                s = collection["montant_transaction"];
                char decimalSymbol = ',';
                var curr = System.Windows.Forms.Application.CurrentCulture.NumberFormat.NumberDecimalSeparator;

                s = s.Replace(".", curr).Replace(decimalSymbol.ToString(), curr);
                // TODO: Add insert logic here
                Transaction_effectuee x = new Transaction_effectuee
                {
                    libelle = collection["libelle"],
                    date_transaction = DateTime.Now,
                    montant_transaction = decimal.Parse(s),


                    //*******

                    codeCOMPTE_MARKETER = collection["codeCOMPTE_MARKETER"],
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

        // GET: Transaction_effectuee/Edit/5
        public ActionResult Edit(string code)
        {
            Transaction_effectuee x = dao.rechercher(code);

            TransactionEffectueeModel pm = new TransactionEffectueeModel
            {
                codeTRANSACTION_EFFECTUEE = x.codeTRANSACTION_EFFECTUEE,
                libelle = x.libelle,
                montant_transaction = x.montant_transaction,


                ///*******
                /// 
                codeU = x.codeU,
                codeCOMPTE_MARKETER = x.codeCOMPTE_MARKETER

            };

            return View(pm);
        }

        // POST: CompteMarketer/Edit/5
        [HttpPost]
        public ActionResult Edit(Transaction_effectuee x)
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

        // GET: Transaction_effectuee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Transaction_effectuee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("afficherTous");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult afficherTous()
        {
            IEnumerable<Transaction_effectuee> ls = dao.rechercherTous();

            ViewBag.listeTransaction_effectuee = ls;

            return View();
        }
    }
}