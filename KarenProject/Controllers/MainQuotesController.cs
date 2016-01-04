using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KarenProject.Models;

namespace KarenProject.Controllers
{
    public class MainQuotesController : Controller
    {
        private quoteDb db = new quoteDb();

        // GET: MainQuotes
        public ActionResult Index([Bind(Prefix="id")] int productid)
        {
            return View(db.section1Model.Find(productid));
        }


        // GET: MainQuotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainQuote mainQuote = db.MainQuote.Find(id);
            if (mainQuote == null)
            {
                return HttpNotFound();
            }
            return View(mainQuote);
        }

        // GET: MainQuotes/Create
        public ActionResult Create(int projectId)
        {
            ViewBag.projectID = projectId;
            return View();
        }

        // POST: MainQuotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,LiftType,LiftModel,Part,expiry")] MainQuote mainQuote)
        {
            if (ModelState.IsValid)
            {
                db.MainQuote.Add(mainQuote);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mainQuote);
        }

        // GET: MainQuotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainQuote mainQuote = db.MainQuote.Find(id);
            if (mainQuote.MyType == "LVGquote")
            {
                return RedirectToAction("Edit", "LVGquotes", new { id = id });
            }
            if (mainQuote == null)
            {
                return HttpNotFound();
            }
            return View(mainQuote);
        }

        // POST: MainQuotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MainQuote mainQuote)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mainQuote).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mainQuote);
        }

        // GET: MainQuotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainQuote mainQuote = db.MainQuote.Find(id);
            if (mainQuote == null)
            {
                return HttpNotFound();
            }
            return View(mainQuote);
        }

        // POST: MainQuotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainQuote mainQuote = db.MainQuote.Find(id);
            db.MainQuote.Remove(mainQuote);
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
