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
    public class supplier2Controller : Controller
    {
        private quoteDb db = new quoteDb();

        // GET: supplier2
        public ActionResult Index()
        {
            return View(db.MainQuote.ToList() );
        }

        // GET: supplier2/Details/5
     /*   public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplier2 supplier2 = db.MainQuote.Find(id);
            if (supplier2 == null)
            {
                return HttpNotFound();
            }
            return View(supplier2);
        }*/

        // GET: supplier2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: supplier2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,LiftType,LiftModel,Part,section1ModelId,expiry,speed")] supplier2 supplier2)
        {
            if (ModelState.IsValid)
            {
                db.MainQuote.Add(supplier2);
                db.SaveChanges();
               return RedirectToAction("Index");
            }

            return View(supplier2);
        }

        // GET: supplier2/Edit/5
       /* public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            supplier2 supplier2 = db.MainQuote.Find(id);
            if (supplier2 == null)
            {
                return HttpNotFound();
            }
            return View(supplier2);
        */}

        // POST: supplier2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
     /*   [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,LiftType,LiftModel,Part,section1ModelId,expiry,speed")] supplier2 supplier2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supplier2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(supplier2);
        }*/

        // GET: supplier2/Delete/5
       

      

    /*    protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }*/
}
