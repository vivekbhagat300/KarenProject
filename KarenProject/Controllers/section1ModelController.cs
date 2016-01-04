using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KarenProject.Models;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.Diagnostics;
using System.Net.Mail;
using MigraDoc.DocumentObjectModel;
using RazorEngine;
using System.IO;
using PdfSample;

namespace KarenProject.Controllers
{
    public class section1ModelController : Controller
    {
        private quoteDb db = new quoteDb();

        PdfDocument pdf = new PdfDocument();
        // GET: section1Model
        [Authorize]
        public ActionResult Index(string projectName = null, int quoteNo = 0)
        {

          //  return View(db.section1Model.ToList());
            if (quoteNo != 0)
            {

                var innerQuery = from fb in db.MainQuote where fb.id == quoteNo select fb.Section1ModelId;
                var result = from f in db.section1Model where innerQuery.Contains(f.id) select f;
                //var model =
                //    from r in db.section1Model
                    
                //    let quo = from j in db.MainQuote
                //              select j.id
                //    where quo.Contains(quoteNo)
                //    orderby r.id ascending
                  

                   // select f;
                return View(result);
            }
            else
            {
                var model =
                    from r in db.section1Model
                    //join  j in db.MainQuote
                    //on r.id equals j.Section1ModelId
                    //let quo = from j in db.MainQuote
                    //          select j.id
                    //where quo.Contains(quoteNo)
                    //orderby r.id ascending
                    where (projectName == null || r.ProjectName.Contains(projectName))

                    // where (quoteNo == 0 || r.id in ( where j.id )

                    select r;
                return View(model);

            }
           
        }

        public ActionResult Quotes()
        {
            return View("Hi");
        }

        // GET: section1Model/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: section1Model/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( section1Model section1Model)
        {
            if (ModelState.IsValid)
            {
                db.section1Model.Add(section1Model);
                db.SaveChanges();
                //var email = new NewCommentEmail
                //{
                //    To = "gajendra_dessai@hotmail.com",
                //    UserName = section1Model.ProjectName,
                //    Comment = section1Model.ToString()
                //};

                //email.Send();
                
                return RedirectToAction("Edit","section1Model", new { id = section1Model.id });

            }

            return View(section1Model);
        }
        public ActionResult pdf1()
        {
            //Document document = new Document();
            //PdfDocument paragraph1 = new PdfDocument();
            //Section section = document.AddSection();
            //Paragraph paragraph = section.Footers.Primary.AddParagraph();
            //paragraph.AddText("Easy Living - Home elevators");
            //paragraph.AddText("Project Name");
            //paragraph.Format.Font.Size = 9;
            //paragraph.Format.Alignment = ParagraphAlignment.Center;
            //// Save the document...
             //string filename = Server.MapPath("~/PDF/HelloWorld.pdf");
           //  paragraph1 = PdfGenerator.CreatePdf("cc");
             //paragraph1.Save(filename);
            //// ...and start a viewer
           // Process.Start(filename);
            // public FileStreamResult CreateFile() {
       
            return View();
            }



                // GET: section1Model/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            section1Model section1Model = db.section1Model.Find(id);
            if (section1Model == null)
            {
                return HttpNotFound();
            }
            return View(section1Model);
        }

        // POST: section1Model/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( section1Model section1Model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(section1Model).State = EntityState.Modified;
                db.SaveChanges();
                return View(section1Model);
            }
            return View(section1Model);
        }

        // GET: section1Model/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            section1Model section1Model = db.section1Model.Find(id);
            if (section1Model == null)
            {
                return HttpNotFound();
            }
            return View(section1Model);
        }

        // POST: section1Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            section1Model section1Model = db.section1Model.Find(id);
            db.section1Model.Remove(section1Model);
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
