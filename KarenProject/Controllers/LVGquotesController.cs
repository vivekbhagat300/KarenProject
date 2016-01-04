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
using System.Globalization;
using System.Net.Mime;
using System.Web.Hosting;

namespace KarenProject.Controllers
{
    public class LVGquotesController : Controller
    {
        private quoteDb db = new quoteDb();

        public CarWalls car = new CarWalls();
        string Type = "";
        string Branch = "";
        // GET: LVGquotes
        public ActionResult Index()
        {
            return View(db.MainQuote.ToList());
        }

        public ActionResult Index(int pageindex)
        {
            List<MainQuote> list_main = db.MainQuote.ToList();
            List<MainQuote> list_main_current;
            int count_start = 15 * pageindex;
            int count_finish = 15 * pageindex + 15;
            list_main_current = list_main.GetRange(count_start, 15);
            return View(list_main_current);
        }

        public ActionResult pricing()
        {
            return View();
        }

        // GET: LVGquotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainQuote lVGquote = db.MainQuote.Find(id);
            if (lVGquote == null)
            {
                return HttpNotFound();
            }
            return View(lVGquote);
        }


        // GET: LVGquotes/Create
        public ActionResult Create(int section_1)
        {
            Type = (from b in db.section1Model
                    where b.id == section_1
                    select b.ProjectType).SingleOrDefault();


            ViewBag.SectionType = Type;
            ViewBag.ProductId = section_1;

            LVGquote model = new LVGquote();


            var lifttypes = car.getLiftTypes(Type);
            var lift = GetLift(lifttypes, 0);
            ViewBag.LiftTypes = GetLiftType1(lifttypes, 0);
            ViewBag.LiftModels = GetLiftModel1(lift, "Front entrance");

            if (lift == "DomusLift")
            {
                model.IntCarSizeDeep = "1300";
                model.IntCarSizeWide = "1000";
                model.ShaftSizeDeep = "1450";
                model.ShaftSizeWide = "1400";
                model.Door1SizeWide = "950";
                model.Doo1SizeDeep = "2000";
                model.Headroom = 2450;
                model.Pit = 130;
                model.Travel = 3000;
                model.CarHeight = 2000;
                model.ConCabSize = "600mm W x  280mm D x 1000mm H";
                model.ConCabLocVer = "0";
                model.ConCabLocHor = "2500";
                model.Speed = "0.25";
            }
            else
            {
                model.IntCarSizeDeep = "1400";
                model.IntCarSizeWide = "1100";
                model.ShaftSizeDeep = "1550";
                if (lift == "Domus Evolution")
                {
                    model.ShaftSizeWide = "1550";
                }
                else {
                    model.ShaftSizeWide = "1500";
                }
                model.Door1SizeWide = "900";
                model.Doo1SizeDeep = "2000";
                model.Headroom = 2500;
                model.Pit = 130;
                model.Travel = 3000;
                model.CarHeight = 2000;
                model.ConCabSize = "720 mm W x 360 mm D x 1500 mm H";
                model.ConCabLocVer = "0";
                model.ConCabLocHor = "2500";
                model.Speed = "0.15";
            }
            ViewBag.CarWallsLHSS = car.getCarWalls();
            // ViewBag.CarWallsRHS = car.getCarWalls();
            //ViewBag.CarWallsRear = car.getCarWalls();

            ViewBag.powers = Getpower1(lift, "fake");
            ViewBag.CodeComp = car.getobj(Type);
            ViewBag.Phone = car.getPhone(Type);
            ViewBag.Ceilings = car.getCeiling();
            ViewBag.Floors = car.getFloors();
            ViewBag.Profiles = car.getProfiles();
            ViewBag.COP = car.getCOP();
            ViewBag.HandrailTypes = car.getHandRailType(Type);
            ViewBag.LDFDoorType = car.LDFDoorType(lift);
            ViewBag.LDFDoorFinish = car.LDFDoorFinish(lift, "B");
            ViewBag.StructureFinish = car.getStructureFinish("Aluminium");
            ViewBag.Claddings = car.getCladding("Aluminium");
            ViewBag.entrancetypes = car.getEntranceTypes("Front entrance");


            return View(model);
        }

        // POST: LVGquotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LVGquote lVGquote)
        {
            if (ModelState.IsValid)
            {
                lVGquote.MyType = "LVGquote";
                db.MainQuote.Add(lVGquote);
                db.SaveChanges();

                var model =
               (from r in db.section1Model
                where r.id == lVGquote.Section1ModelId
                select r).SingleOrDefaultAsync();
                // return View(model);





                return RedirectToAction("Edit", "LVGquotes", new { id = lVGquote.id });
            }

            ViewBag.ProductId = lVGquote.Section1ModelId;
            ViewBag.CodeComp = car.getobj(Type);
            ViewBag.LiftTypes = GetLiftType1(lVGquote.CodeComplence, lVGquote.id);
            ViewBag.LiftModels = GetLiftModel1(lVGquote.LiftType, lVGquote.EntranceType);

            ViewBag.CarWallsLHSS = car.getCeiling();

            ViewBag.powers = Getpower1(lVGquote.LiftType, "fake");
            ViewBag.Phone = car.getPhone(Type);
            ViewBag.Ceilings = car.getCeiling();
            ViewBag.Floors = car.getFloors();
            ViewBag.Profiles = car.getProfiles();
            ViewBag.COP = car.getCOP();
            ViewBag.HandrailTypes = car.getHandRailType(Type);

            ViewBag.LDFDoorType = car.LDFDoorType(lVGquote.LiftType);
            ViewBag.LDFDoorFinishs1 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType1.Substring(0, 1));
            ViewBag.LDFDoorFinishs2 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType2.Substring(0, 1));
            ViewBag.LDFDoorFinishs3 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType3.Substring(0, 1));
            ViewBag.LDFDoorFinishs4 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType4.Substring(0, 1));
            ViewBag.LDFDoorFinishs5 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType5.Substring(0, 1));
            ViewBag.LDFDoorFinishs6 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType6.Substring(0, 1));
            ViewBag.LDFDoorFinishs7 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType7.Substring(0, 1));
            ViewBag.LDFDoorFinishs8 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType8.Substring(0, 1));
            ViewBag.LDFDoorFinishs9 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType9.Substring(0, 1));
            ViewBag.LDFDoorFinishs10 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType10.Substring(0, 1));
            ViewBag.StructureFinish = car.getStructureFinish(lVGquote.StructureType);
            ViewBag.Claddings = car.getCladding(lVGquote.StructureType);
            ViewBag.entrancetypes = car.getEntranceTypes(lVGquote.EntranceType);

            return View(lVGquote);
        }

        public ActionResult downloadfile(string fname)
        {

            return File(fname, "Application/pdf", fname);


        }


        public ActionResult SendEmail(int id)
        {
            MainQuote lVGquote = db.MainQuote.Find(id);
            Branch = (from b in db.section1Model
                            where b.id == lVGquote.Section1ModelId
                            select b.Branch).SingleOrDefault();
            PdfDocument paragraph1 = new PdfDocument();
            string QuoteRoot = System.Configuration.ConfigurationManager.AppSettings["QuoteRoot"];
            string filename = "C:\\" + QuoteRoot + "\\" + Branch + "\\" + lVGquote.LiftType + "_P" + lVGquote.Section1ModelId + "-" + lVGquote.id + ".pdf";
            PdfGenerator pdfg = new PdfGenerator();
            paragraph1 = pdfg.CreatePdf(lVGquote);
            paragraph1.Save(filename);

            ViewBag.id = id;
            ViewBag.filename = filename;
            var filesavename = lVGquote.LiftType + "_P" + lVGquote.Section1ModelId + "-" + lVGquote.id + ".pdf";
            ViewBag.filenamename = filesavename;
            // File(filename, "Application/pdf", filesavename);
            return View(new Models.MailModel(id));

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string SendEmail1(NewCommentEmail data)
        {

            MainQuote lVGquote = db.MainQuote.Find(data.quoteID);

            var email = new NewCommentEmail
            {
                To = data.To,
                UserName = data.UserName,
                Comment = data.Comment

            };


            // check if quotes checkbox is ticked
            if (data.Quote)
            {
                email.Attach(new Attachment(data.filename));

            }

            // check if  brochure is ticked in 
            if (data.brochure)
            {
                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "DomusLift")
                {
                    email.Attach(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\IGV-DomusLift-Brochure-eng.pdf")));
                }// email.Attach(new Attachment("C:\\DreamerQuotes\\dd1.txt"));
            }

            // check if  sample drowings is ticked 
            if (data.SampleDrawings)
            {   // if shaft type is masonry
                if (lVGquote.ShaftType == "Masonry")
                {
                    // if lift type is DomusLift
                    if (lVGquote.LiftType == "DomusLift")
                    {

                        //if load bearing wall if left
                        if (lVGquote.LoadBearingWall == "Left")
                        {

                        }
                        //if load bearing wall is right
                        {

                        }
                    }
                    // if lift type is Domusxl
                    if (lVGquote.LiftType == "DomusLift")
                    {

                        //if load bearing wall if left
                        if (lVGquote.LoadBearingWall == "Left")
                        {

                        }
                        //if load bearing wall is right
                        {

                        }
                    }
                }
                // if shaft type is not masonary
                else
                {
                    if (lVGquote.LiftType == "DomusLift")
                    {

                        //if load bearing wall if left
                        if (lVGquote.LoadBearingWall == "Left")
                        {

                        }
                        //if load bearing wall is right
                        {

                        }
                    }
                    // if lift type is Domusxl
                    if (lVGquote.LiftType == "DomusLift")
                    {

                        //if load bearing wall if left
                        if (lVGquote.LoadBearingWall == "Left")
                        {

                        }
                        //if load bearing wall is right
                        {

                        }
                    }

                }
            }

            email.Send();

            return "Email Sent";
        }

        /*
        public void attachDomusLift(MainQuote lVGquote, MailMessage email)
        {
            {
                if (lVGquote.LiftType == "DomusLift")
                {

                    //if load bearing wall if left
                    if (lVGquote.LoadBearingWall == "Left")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "1c/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 4 M SX (1000x1300) .pdf")));
                                    break;
                                }
                            case "1c/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 1 M DX (800x800 car size) .pdf"))); // to be updated 
                                    break;
                                }
                            case "1c/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 2 M SX (800x1000 car size) .pdf")));
                                    break;
                                }
                            case "1c/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 3 M DX (800x1300) .pdf")));
                                    break;
                                }
                            case "1c/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 5 M DX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "1c/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 6 M SX (1000x800 car size).pdf")));
                                    break;
                                }
                            case "1c/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 7 M SX (800x1200 car size).pdf")));
                                    break;
                                }
                            case "2P/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 4 M SX (1000x1300 car size).pdf")));
                                    break;
                                }
                            case "2P/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 1 M SX (800X800 car size).pdf")));
                                    break;
                                }
                            case "2P/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 2 M SX (800x1000 car size) .pdf")));
                                    break;
                                }
                            case "2P/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 3 M SX (800x1300 car size) .pdf")));
                                    break;
                                }
                            case "2P/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 5 M SX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "2P/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 6 M SX (1000x800 Car size) .pdf")));
                                    break;
                                }
                            case "2P/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 7 M SX (800x1200 car size) .pdf")));
                                    break;
                                }
                            case "2A/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 4 M SX (1000x1300 car size).pdf")));
                                    break;
                                }
                            case "2A/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 1 M SX (800x800 car size) .pdf")));
                                    break;
                                }
                            case "2A/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 2 M SX (800x1000 car size).pdf")));
                                    break;
                                }
                            case "2A/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 3 M DX (800x1300 car size).pdf")));
                                    break;
                                }
                            case "2A/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 5 M SX (1000x1000 car size).pdf")));
                                    break;
                                }
                            case "2A/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 6 M SX (1000x800 car size) .pdf")));
                                    break;
                                }
                        }

                    }



                    if (lVGquote.LoadBearingWall == "Right")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "1c/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 4 M DX (1000x1300) .pdf")));
                                    break;
                                }
                            case "1c/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 1 M DX (800x800 car size) .pdf")));
                                    break;
                                }
                            case "1c/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 2 M DX (800x1000 car size) .pdf")));
                                    break;
                                }
                            case "1c/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 3 M DX (800x1300) .pdf")));
                                    break;
                                }
                            case "1c/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 5 M DX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "1c/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 6 M SX (1000x800 car size).pdf")));
                                    break;
                                }
                            case "1c/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 7 M DX (800x1200 car size).pdf")));
                                    break;
                                }
                            case "2P/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 4 M DX (1000x1300 car size) .pdf")));
                                    break;
                                }
                            case "2P/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 1 M DX (800x800 car size).pdf")));
                                    break;
                                }
                            case "2P/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 2 M DX (800X1000 car size) .pdf")));
                                    break;
                                }
                            case "2P/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 3 M  DX (800x1300 car size) .pdf")));
                                    break;
                                }
                            case "2P/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 5 M DX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "2P/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 6 M DX (1000x800 car size) .pdf")));
                                    break;
                                }
                            case "2P/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 7 M DX (800x1200 car size).pdf")));
                                    break;
                                }
                            case "2A/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 4 M DX (1000x1300 car size) .pdf")));
                                    break;
                                }
                            case "2A/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 1 M DX (800x800 car size) .pdf")));
                                    break;
                                }
                            case "2A/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 2 M DX (800x1000).pdf")));
                                    break;
                                }
                            case "2A/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 3 M DX (800x1300 car size).pdf")));
                                    break;
                                }
                            case "2A/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 5 M DX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "2A/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 6 M DX (1000x800 car size).pdf")));
                                    break;
                                }
                        }
                    }

                    if (lVGquote.LoadBearingWall != "Right" & lVGquote.LoadBearingWall != "Left")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "1L/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 4 M (1000x1300 car size).pdf")));
                                    break;
                                }
                            case "1L/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 1 M  (800x800mm car size) .pdf")));
                                    break;
                                }
                            case "1L/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 2 M (1000x800 car size) .pdf")));
                                    break;
                                }
                            case "1L/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 3 M (1300x800 car size) .pdf")));
                                    break;
                                }
                            case "1L/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 5 M (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "1L/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 6 M (800x1000 car size) .pdf")));
                                    break;
                                }

                        }
                    }
                }

            }
        }

        public void attachDomusXL(MainQuote lVGquote, MailMessage email)
        {
            if (lVGquote.LoadBearingWall == "Left")
            {
                switch (lVGquote.LiftModel)
                {
                    case "1C/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Drawings\\Domus XL\\Masonry\\DL-1C XL M SX (900mm LH Door Hinge) 1100x1400mm.pdf")));
                            break;
                        }
                    case "2P/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2P XL M SX RHH (1100x1400mm car size).pdf")));
                            break;
                        }
                    case "2A/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2A XL M Variations.pdf")));
                            break;
                        }
                }
            }
            if (lVGquote.LoadBearingWall == "Right")
            {
                switch (lVGquote.LiftModel)
                {
                    case "1C/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-1C XL M DX RHH (1100x1400mm Car size).pdf")));
                            break;
                        }
                    case "2P/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2P XL M SX RHH (1100x1400mm car size).pdf")));
                            break;
                        }
                    case "2A/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2A XL M Variations.pdf")));
                            break;
                        }

                }
            }
        }

        public void attachFiles(MailMessage email, MailModel data, MainQuote lVGquote)
        {

            if (data.Quote)
            {
                email.Attachments.Add(new Attachment(data.filename));

            }


            // check if  brochure is ticked in 
            if (data.brochure)
            {
                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "DomusLift")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusLift Brochure-Easy Living Home Elevators.pdf")));
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));

                {
                    // check lift types copy this code for other type of lifts
                    if (lVGquote.LiftType == "DomusXL")
                    {
                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusLift Brochure-Easy Living Home Elevators.pdf")));
                    }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));
                }

                {
                    // check lift types copy this code for other type of lifts
                    if (lVGquote.LiftType == "Domus Evolution")
                    {
                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusEvolution - Easy Living Home Elevators.pdf")));
                    }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));
                }
                {
                    // check lift types copy this code for other type of lifts
                    if (lVGquote.LiftType == "Domus Spirit" || lVGquote.LiftType == "DomusXL Spirit")
                    {
                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\The Domus Spirit Low Res.pdf")));
                    }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));
                }

            }

            if (data.LadderBracketDrawings)
            {
                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "DomusLift")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus Steel Layout.pdf")));
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));


                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "DomusXL")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL Steel Layout.pdf")));
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));

                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "Domus Evolution")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL - Evolution Steel Layout.pdf")));
                }

                if (lVGquote.LiftType == "Domus Spirit")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus Steel Layout.pdf")));
                }

                if (lVGquote.LiftType == "DomusXL Spirit")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL Steel Layout.pdf")));
                }
            }




            ///////////////////////////

            if (data.SampleDrawings)
            {   // if shaft type is masonry
                if (lVGquote.ShaftType == "Masonry")
                {
                    // if lift type is DomusLift
                    if (lVGquote.LiftType == "DomusLift")
                    {
                        attachDomusLift(lVGquote, email);
                    }
                    // if lift type is Domusxl
                    if (lVGquote.LiftType == "DomusXL")
                    {
                        attachDomusXL(lVGquote, email);
                        //if load bearing wall if left
                    }
                    if (lVGquote.LiftType == "DomusEvolution")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "EVO-1C/2T":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\EVO7-1C-2T M (1100x1400mm car size).pdf")));
                                    break;
                                }

                            case "EVO-2P/2T":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\EVO7-2P-2T M (1100x1400mm car size) .pdf")));
                                    break;
                                }
                            case "EVO-2A/2T":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\Domus Evo M adjacent entry - 1100 x1400.pdf")));
                                    break;
                                }
                        }
                    }

                    if (lVGquote.LiftType == "DomusSpirit")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "RS-1C/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C M.pdf")));
                                    break;
                                }
                            case "RS-2P/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf"))); //to be updated
                                    break;
                                }
                            case "RS-2A/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); //to be updated
                                    break;
                                }
                        }
                    }
                    if (lVGquote.LiftType == "DomusXL Spirit")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "RS-1C/XL":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T M .pdf")));
                                    break;
                                }
                            case "RS-2P/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf"))); //to be updated
                                    break;
                                }
                            case "RS-2A/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); //to be updated
                                    break;
                                }

                        }
                    }

                }            // if shaft type is not masonary
                else
                {
                    nonMasonaryAttach(lVGquote, email);

                }

            }
        }

        public void nonMasonaryAttach(MainQuote lVGquote, MailMessage email)
        {
            if (lVGquote.LiftType == "DomusLift")
            {

                //if load bearing wall if left
                if (lVGquote.LoadBearingWall == "Left")
                {
                    switch (lVGquote.LiftModel)
                    {
                        case "1c/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 4 T SX (1000x1300 car size).pdf")));
                                break;
                            }
                        case "1c/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 1 T SX (800X800 car size).pdf")));
                                break;
                            }
                        case "1c/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 2 T SX (800x1000 car size).pdf")));
                                break;
                            }
                        case "1c/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 3 T DX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "1c/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 5 T SX (1000x1000mm car size).pdf")));
                                break;
                            }
                        case "1c/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 6 T SX (1000x800 car size) .pdf")));
                                break;
                            }
                        case "1c/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T SX (800x1200mm car size).pdf")));
                                break;
                            }
                        case "2P/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 4 T SX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "2P/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 1 T SX (800x800 car size) .pdf")));
                                break;
                            }
                        case "2P/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 2 T SX (800x1000 car size) .pdf")));
                                break;
                            }
                        case "2P/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 3 T SX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "2P/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 5 T SX (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "2P/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 6 T DX (1000x800 car size) .pdf")));
                                break;
                            }
                        case "2P/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 7 T SX (800x1200 car size) .pdf")));
                                break;
                            }
                        case "2A/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 4 T SX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "2A/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 1 T SX (800x800 car size) .pdf")));
                                break;
                            }
                        case "2A/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 2 T SX (800x1000 car size) .pdf")));
                                break;
                            }
                        case "2A/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 3 T SX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "2A/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 5 T SX (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "2A/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 6 T SX (1000x800 car size).pdf")));
                                break;
                            }
                    }

                }
                if (lVGquote.LoadBearingWall == "Right")
                {
                    switch (lVGquote.LiftModel)
                    {

                        case "1c/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 4 T SX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "1c/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 1 T SX (800X800 car size).pdf")));
                                break;
                            }
                        case "1c/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 2 T SX (800x1000 car size).pdf")));
                                break;
                            }
                        case "1c/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 3 T DX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "1c/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 5 T DX (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "1c/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 6 T DX (1000x800 car size) .pdf")));
                                break;
                            }
                        case "1c/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T DX (800x1200 car size) .pdf")));
                                break;
                            }
                        case "2P/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 4 T DX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "2P/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 1 T DX (800x800 car size) .pdf")));
                                break;
                            }
                        case "2P/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 2 T DX (800x1000 car size).pdf")));
                                break;
                            }
                        case "2P/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 3 T DX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "2P/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 5 T DX (1000x1000 car size).pdf")));
                                break;
                            }
                        case "2P/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 6 M DX (1000x800 car size) .pdf")));
                                break;
                            }
                        case "2P/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 7 T DX (800x1200 car size).pdf")));
                                break;
                            }
                        case "2A/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 4 T DX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "2A/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 1 T DX (800x800 car size) .pdf")));
                                break;
                            }
                        case "2A/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 2 T DX (800x1000 car size) ")));
                                break;
                            }
                        case "2A/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 3 T DX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "2A/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 5 T DX (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "2A/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 6 T SX (1000x800 car size).pdf")));
                                break;
                            }
                    }
                }

                if (lVGquote.LoadBearingWall != "Left" & lVGquote.LoadBearingWall != "Right")
                {
                    // IF LOAD BEARING WALL IS REAR 
                    switch (lVGquote.LiftModel)
                    {
                        case "1L/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 4A DX (1300x1000 car size) .pdf")));
                                break;
                            }
                        case "1L/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 1A (800x800 car size) .pdf")));
                                break;
                            }
                        case "1L/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 2A (1000x800 car size) .pdf")));
                                break;
                            }
                        case "1L/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 3A DX (1300x800 car size) .pdf")));
                                break;
                            }
                        case "1L/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 5A (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "1L/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 6 M (800x1000 car size) .pdf")));
                                break;
                            }


                    }
                }
            }

            // if lift type is Domusxl
            if (lVGquote.LiftType == "DomusXL")
            {

                switch (lVGquote.LiftModel)
                {
                    case "1C/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-1C XL DX LHH (1100x1400 car size).pdf")));
                            break;
                        }
                    case "2P/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-2P XL SX Doors hinged on rail side.pdf")));
                            break;
                        }
                    case "2A/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-2A XL Variations.pdf")));
                            break;
                        }
                }
            }

            if (lVGquote.LiftType == "DomusEvolution")
            {
                switch (lVGquote.LiftModel)
                {
                    case "EVO-1C/2T":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\EVO7-1C-2T (1100x1400mm car size).pdf")));
                            break;
                        }
                    case "EVO-2P/2T":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\EVO7-2P-2T (1100x1400mm car size).pdf")));
                            break;
                        }
                    case "EVO-2A/2T":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\"))); // drawing to be updated
                            break;
                        }
                }
            }

            if (lVGquote.LiftType == "DomusSpirit")
            {
                switch (lVGquote.LiftModel)
                {
                    case "RS-1C/4":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf")));
                            break;
                        }
                    case "RS-2P/4":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf"))); //to be updated
                            break;
                        }
                    case "RS-2A/4":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); //to be updated
                            break;
                        }
                }
            }

            if (lVGquote.LiftType == "DomusXL Spirit")
            {
                switch (lVGquote.LiftModel)
                {
                    case "RS-1C/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); // to be fixed
                            break;
                        }
                    case "RS-2P/4":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf"))); //to be updated
                            break;
                        }
                    case "RS-2A/4":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); //to be updated
                            break;
                        }

                }


            }
        }


        */

        public void attachFiles(MailMessage email, MailModel data, MainQuote lVGquote)
        {

            if (data.Quote)
            {
                email.Attachments.Add(new Attachment(data.filename));

            }


            // check if  brochure is ticked in 
            if (data.brochure)
            {
                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "DomusLift")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusLift Brochure-Easy Living Home Elevators.pdf")));
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));

                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "DomusXL")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusLift Brochure-Easy Living Home Elevators.pdf")));
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));

                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "Domus Evolution")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusEvolution - Easy Living Home Elevators.pdf")));
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));
                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "Domus Spirit" || lVGquote.LiftType == "DomusXL Spirit")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\The Domus Spirit Low Res.pdf")));
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));


            }

            if (data.LadderBracketDrawings)
            {
                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "DomusLift")
                {
                    if (lVGquote.Capacity == "400 Kg")
                    {
                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL Steel Layout.pdf")));
                    }
                    else
                    {
                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus Steel Layout.pdf")));
                    }
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));


                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "DomusXL")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL Steel Layout.pdf")));
                }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));

                // check lift types copy this code for other type of lifts
                if (lVGquote.LiftType == "Domus Evolution")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL - Evolution Steel Layout.pdf")));
                }

                if (lVGquote.LiftType == "Domus Spirit")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus Steel Layout.pdf")));
                }

                if (lVGquote.LiftType == "DomusXL Spirit")
                {
                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL Steel Layout.pdf")));
                }
            }




            ///////////////////////////

            if (data.SampleDrawings)
            {   // if shaft type is masonry
                if (lVGquote.ShaftType == "Masonry")
                {
                    // if lift type is DomusLift
                    if (lVGquote.LiftType == "DomusLift")
                    {
                        attachDomusLift(lVGquote, email);
                    }
                    // if lift type is Domusxl
                    if (lVGquote.LiftType == "DomusXL")
                    {
                        attachDomusXL(lVGquote, email);
                        //if load bearing wall if left
                    }

                    if (lVGquote.LiftType == "Domus Evolution")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "EVO-1C/2T":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\EVO7-1C-2T (1100x1400mm car size).pdf")));
                                    break;
                                }

                            case "EVO-2P/2T":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\EVO7-2P-2T (1100x1400mm car size) .pdf")));
                                    break;
                                }
                            case "EVO-2A/2T":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\Domus Evo adjacent entry - 1100 x1400.pdf")));
                                    break;
                                }
                        }
                    }

                    if (lVGquote.LiftType == "Domus Spirit")
                    {
                        if (lVGquote.LoadBearingWall == "Left") // Vivek to check 
                        {
                            switch (lVGquote.LiftModel)
                            {
                                case "RS-1C/4":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Masonry\\DomusSpirit RS-1C-4SX (950x1300 car size).pdf")));
                                        break;
                                    }
                                case "RS-2P/4":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Masonry\\DomusSpirit RS-2P-4SX (950x1300 car size).pdf")));
                                        break;
                                    }
                                case "RS-2A/4":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Masonry\\DomusSpirit RS-2A-4SX (1000x1300 car size).pdf")));
                                        break;
                                    }
                            }
                        }

                        if (lVGquote.LoadBearingWall == "Right")  // Vivek to check 
                        {
                            switch (lVGquote.LiftModel)
                            {
                                case "RS-1C/4":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Masonry\\DomusSpirit RS-1C-4DX (950x1300 car size).pdf")));
                                        break;
                                    }
                                case "RS-2P/4":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Masonry\\DomusSpirit RS-2P-4DX (950x1300 car size).pdf")));
                                        break;
                                    }
                                case "RS-2A/4":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Masonry\\DomusSpirit RS-2A-4DX (1000x1300 car size).pdf")));
                                        break;
                                    }
                            }
                        }
                    }


                    if (lVGquote.LiftType == "DomusXL Spirit") // Karen - check with Dee
                    {
                        if (lVGquote.LoadBearingWall == "Left") // Vivek to check 
                        {
                            switch (lVGquote.LiftModel)
                            {
                                case "RS-1C/XL":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Masonry\\DomusSpirit RS-1C8 SX (1100x1400 car size).pdf")));
                                        break;
                                    }
                                case "RS-2P/XL":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Masonry\\DomusSpirit RS-2P8 SX (1100x1400 car size).pdf")));
                                        break;
                                    }
                                case "RS-2A/XL":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Masonry\\"))); //to be updated
                                        break;
                                    }

                            }
                        }
                        if (lVGquote.LoadBearingWall == "Right")  // Vivek to check 
                        {
                            switch (lVGquote.LiftModel)
                            {
                                case "RS-1C/XL":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Masonry\\DomusSpirit RS-1C8 DX (1100x1400 car size).pdf")));
                                        break;
                                    }
                                case "RS-2P/XL":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Masonry\\DomusSpirit RS-2P8 DX (1100x1400 car size).pdf")));
                                        break;
                                    }
                                case "RS-2A/XL":
                                    {

                                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Masonry\\"))); //to be updated
                                        break;
                                    }

                            }
                        }
                    }
                }// if shaft type is not masonary
                else
                {
                    nonMasonaryAttach(lVGquote, email);

                }

            }

        }



        public void attachDomusLift(MainQuote lVGquote, MailMessage email)
        {
            {
                if (lVGquote.LiftType == "DomusLift")
                {

                    //if load bearing wall if left
                    if (lVGquote.LoadBearingWall == "Left")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "1C/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 4 SX (1000x1300) .pdf")));
                                    break;
                                }
                            case "1C/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 1 SX (800x800 car size).pdf")));
                                    break;
                                }
                            case "1C/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 2 SX (800x1000 car size) .pdf")));
                                    break;
                                }
                            case "1C/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 3 SX (800x1300 car size).pdf")));
                                    break;
                                }
                            case "1C/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 5 SX (1000x1000 car size).pdf")));
                                    break;
                                }
                            case "1C/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 6 SX (1000x800 car size).pdf")));
                                    break;
                                }
                            case "1C/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 7 SX (800x1200 car size).pdf")));
                                    break;
                                }
                            case "1C/8":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 8 SX (1100x1400 car size).pdf")));
                                    break;
                                }
                            case "1C/12":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C12 SX (1000x1400 car size).pdf")));
                                    break;
                                }
                            case "2P/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 4 SX (1000x1300 car size).pdf")));
                                    break;
                                }
                            case "2P/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 1 SX (800X800 car size).pdf")));
                                    break;
                                }
                            case "2P/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 2 SX (800x1000 car size) .pdf")));
                                    break;
                                }
                            case "2P/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 3 SX (800x1300 car size) .pdf")));
                                    break;
                                }
                            case "2P/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 5 SX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "2P/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 6 SX (1000x800 Car size) .pdf")));
                                    break;
                                }
                            case "2P/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 7 SX (800x1200 car size) .pdf")));
                                    break;
                                }
                            case "2P/8":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 8 SX (1100x1400 car size).pdf")));
                                    break;
                                }
                            case "2A/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 4 SX (1000x1300 car size).pdf")));
                                    break;
                                }
                            case "2A/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 1 SX (800x800 car size) .pdf")));
                                    break;
                                }
                            case "2A/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 2 SX (800x1000 car size).pdf")));
                                    break;
                                }
                            case "2A/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 3 SX (800x1300 car size).pdf")));
                                    break;
                                }
                            case "2A/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 5 SX (1000x1000 car size).pdf")));
                                    break;
                                }
                            case "2A/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 6 SX (1000x800 car size) .pdf")));
                                    break;
                                }
                        }

                    }



                    if (lVGquote.LoadBearingWall == "Right")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "1C/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 4 DX (1000x1300) .pdf")));
                                    break;
                                }
                            case "1C/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 1 DX (800x800 car size).pdf")));
                                    break;
                                }
                            case "1C/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 2 DX (800x1000 car size) .pdf")));
                                    break;
                                }
                            case "1C/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 3 DX (800x1300) .pdf")));
                                    break;
                                }
                            case "1C/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 5 DX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "1C/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 6 DX (1000x800 car size).pdf")));
                                    break;
                                }
                            case "1C/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 7 DX (800x1200 car size).pdf")));
                                    break;
                                }
                            case "1C/8":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 8 DX (1100x1400 car size).pdf")));
                                    break;
                                }
                            case "1C/12":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C12 DX (1000x1400 car size).pdf")));
                                    break;
                                }
                            case "2P/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 4 DX (1000x1300 car size) .pdf")));
                                    break;
                                }
                            case "2P/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 1 DX (800x800 car size).pdf")));
                                    break;
                                }
                            case "2P/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 2 DX (800X1000 car size) .pdf")));
                                    break;
                                }
                            case "2P/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 3 DX (800x1300 car size) .pdf")));
                                    break;
                                }
                            case "2P/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 5 DX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "2P/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 6 DX (1000x800 car size) .pdf")));
                                    break;
                                }
                            case "2P/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 7 DX (800x1200 car size).pdf")));
                                    break;
                                }
                            case "2P/8":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 8 SX (1100x1400 car size).pdf"))); // to be updated
                                    break;
                                }
                            case "2A/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 4 M DX (1000x1300 car size) .pdf")));
                                    break;
                                }
                            case "2A/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 1 DX (800x800 car size) .pdf")));
                                    break;
                                }
                            case "2A/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 2 DX (800x1000).pdf")));
                                    break;
                                }
                            case "2A/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 3 DX (800x1300 car size).pdf")));
                                    break;
                                }
                            case "2A/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 5 DX (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "2A/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 6 DX (1000x800 car size).pdf")));
                                    break;
                                }
                        }
                    }

                    if (lVGquote.LoadBearingWall != "Right" & lVGquote.LoadBearingWall != "Left")
                    {
                        switch (lVGquote.LiftModel)
                        {
                            case "1L/4":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 4 (1000x1300 car size).pdf")));
                                    break;
                                }
                            case "1L/1":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 1 (800x800mm car size) .pdf")));
                                    break;
                                }
                            case "1L/2":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 2 (1000x800 car size) .pdf")));
                                    break;
                                }
                            case "1L/3":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 3 (1300x800 car size) .pdf")));
                                    break;
                                }
                            case "1L/5":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 5 (1000x1000 car size) .pdf")));
                                    break;
                                }
                            case "1L/6":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 6 (800x1000 car size) .pdf")));
                                    break;
                                }
                            case "1L/7":
                                {

                                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 6 M (800x1000 car size) .pdf")));// to be updated
                                    break;
                                }

                        }
                    }
                }

            }
        }

        public void attachDomusXL(MainQuote lVGquote, MailMessage email)
        {
            if (lVGquote.LoadBearingWall == "Left")
            {
                switch (lVGquote.LiftModel)
                {
                    case "1C/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-1C XL DX RHH (1100x1400mm Car size).pdf")));
                            break;
                        }
                    case "2P/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2P XL RHH (1100x1400mm car size).pdf")));
                            break;
                        }
                    case "2A/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2A XL Variations.pdf")));
                            break;
                        }
                }
            }
            if (lVGquote.LoadBearingWall == "Right")
            {
                switch (lVGquote.LiftModel)
                {
                    case "1C/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-1C XL DX RHH (1100x1400mm Car size).pdf")));
                            break;
                        }
                    case "2P/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2P XL DX (1100x1400 car size).pdf")));
                            break;
                        }
                    case "2A/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2A XL Variations.pdf")));
                            break;
                        }

                }
            }
        }


        public void nonMasonaryAttach(MainQuote lVGquote, MailMessage email)
        {
            if (lVGquote.LiftType == "DomusLift")
            {

                //if load bearing wall if left
                if (lVGquote.LoadBearingWall == "Left")
                {
                    switch (lVGquote.LiftModel)
                    {
                        case "1C/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 4 T SX (1000x1300 car size).pdf")));
                                break;
                            }
                        case "1C/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 1 T SX (800X800 car size).pdf")));
                                break;
                            }
                        case "1C/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 2 T SX (800x1000 car size).pdf")));
                                break;
                            }
                        case "1C/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 3 T SX (800x1300 car size).pdf")));
                                break;
                            }
                        case "1C/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 5 T SX (1000x1000mm car size).pdf")));
                                break;
                            }
                        case "1C/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 6 T SX (1000x800 car size) .pdf")));
                                break;
                            }
                        case "1C/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T SX (800x1200mm car size).pdf")));
                                break;
                            }
                        case "1C/8":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T SX (800x1200mm car size).pdf"))); // to be updated
                                break;
                            }
                        case "1C/12":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T SX (800x1200mm car size).pdf"))); // to be updated
                                break;
                            }
                        case "2P/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 4 T SX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "2P/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 1 T SX (800x800 car size) .pdf")));
                                break;
                            }
                        case "2P/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 2 T SX (800x1000 car size) .pdf")));
                                break;
                            }
                        case "2P/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 3 T SX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "2P/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 5 T SX (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "2P/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 6 T DX (1000x800 car size) .pdf")));
                                break;
                            }
                        case "2P/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 7 T SX (800x1200 car size) .pdf")));
                                break;
                            }
                        case "2P/8":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 7 T SX (800x1200 car size) .pdf"))); //to be updated
                                break;
                            }
                        case "2A/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 4 T SX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "2A/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 1 T SX (800x800 car size) .pdf")));
                                break;
                            }
                        case "2A/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 2 T SX (800x1000 car size) .pdf")));
                                break;
                            }
                        case "2A/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 3 T SX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "2A/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 5 T SX (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "2A/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 6 T SX (1000x800 car size).pdf")));
                                break;
                            }
                    }

                }
                if (lVGquote.LoadBearingWall == "Right")
                {
                    switch (lVGquote.LiftModel)
                    {

                        case "1C/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 4 T DX (1000x1300 car size).pdf")));
                                break;
                            }
                        case "1C/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 1 T DX (800x800 car size).pdf")));
                                break;
                            }
                        case "1C/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 2 T DX (800x1000 car size).pdf")));
                                break;
                            }
                        case "1C/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 3 T DX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "1C/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 5 T DX (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "1C/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 6 T DX (1000x800 car size) .pdf")));
                                break;
                            }
                        case "1C/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T DX (800x1200 car size) .pdf")));
                                break;
                            }
                        case "1C/8":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T DX (800x1200 car size) .pdf"))); // to be updated
                                break;
                            }
                        case "1C/12":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T DX (800x1200 car size) .pdf"))); // to be updated
                                break;
                            }
                        case "2P/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 4 T DX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "2P/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 1 T DX (800x800 car size) .pdf")));
                                break;
                            }
                        case "2P/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 2 T DX (800x1000 car size).pdf")));
                                break;
                            }
                        case "2P/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 3 T DX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "2P/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 5 T DX (1000x1000 car size).pdf")));
                                break;
                            }
                        case "2P/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 6 M DX (1000x800 car size) .pdf")));
                                break;
                            }
                        case "2P/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 7 T DX (800x1200 car size).pdf")));
                                break;
                            }
                        case "2P/8":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 7 T DX (800x1200 car size).pdf"))); // to be updated
                                break;
                            }
                        case "2A/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 4 T DX (1000x1300 car size) .pdf")));
                                break;
                            }
                        case "2A/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 1 T DX (800x800 car size) .pdf")));
                                break;
                            }
                        case "2A/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 2 T DX (800x1000 car size) ")));
                                break;
                            }
                        case "2A/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 3 T DX (800x1300 car size) .pdf")));
                                break;
                            }
                        case "2A/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 5 T DX (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "2A/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 6 T SX (1000x800 car size).pdf")));
                                break;
                            }
                    }
                }

                if (lVGquote.LoadBearingWall != "Left" & lVGquote.LoadBearingWall != "Right")
                {
                    // IF LOAD BEARING WALL IS REAR 
                    switch (lVGquote.LiftModel)
                    {
                        case "1L/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 4A DX (1300x1000 car size) .pdf")));
                                break;
                            }
                        case "1L/1":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 1A (800x800 car size) .pdf")));
                                break;
                            }
                        case "1L/2":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 2A (1000x800 car size) .pdf")));
                                break;
                            }
                        case "1L/3":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 3A DX (1300x800 car size) .pdf")));
                                break;
                            }
                        case "1L/5":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 5A (1000x1000 car size) .pdf")));
                                break;
                            }
                        case "1L/6":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 6 M (800x1000 car size) .pdf"))); // to be updated
                                break;
                            }
                        case "1L/7":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 6 M (800x1000 car size) .pdf"))); // to be updated
                                break;
                            }

                    }
                }
            }

            // if lift type is Domusxl
            if (lVGquote.LiftType == "DomusXL")
            {

                switch (lVGquote.LiftModel)
                {
                    case "1C/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-1C XL DX LHH (1100x1400 car size).pdf")));
                            break;
                        }
                    case "2P/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-2P XL SX Doors hinged on rail side.pdf")));
                            break;
                        }
                    case "2A/XL":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-2A XL Variations.pdf")));
                            break;
                        }
                }
            }

            if (lVGquote.LiftType == "Domus Evolution")
            {
                switch (lVGquote.LiftModel)
                {
                    case "EVO-1C/2T":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\EVO7-1C-2T (1100x1400mm car size).pdf")));
                            break;
                        }
                    case "EVO-2P/2T":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\EVO7-2P-2T (1100x1400mm car size).pdf")));
                            break;
                        }
                    case "EVO-2A/2T":
                        {

                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\EVO7-2A-2T DX (1100x1400 car size).pdf")));
                            break;
                        }
                }
            }

            if (lVGquote.LiftType == "Domus Spirit")
            {
                if (lVGquote.LoadBearingWall == "Left") // Vivek to check 
                {
                    switch (lVGquote.LiftModel)
                    {
                        case "RS-1C/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Tower\\DomusSpirit RS-1C-4 SX T (950x1300 car size).pdf")));
                                break;
                            }
                        case "RS-2P/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Tower\\DomusSpirit RS-2P-4 SX T (950x1300 car size).pdf")));
                                break;
                            }
                        case "RS-2A/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Tower\\"))); //to be updated
                                break;
                            }
                    }
                }

                if (lVGquote.LoadBearingWall == "Right")  // Vivek to check 
                {
                    switch (lVGquote.LiftModel)
                    {
                        case "RS-1C/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Tower\\DomusSpirit RS-1C-4 DX T (950x1300 car size).pdf")));
                                break;
                            }
                        case "RS-2P/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Tower\\DomusSpirit RS-2P-4 DX T (950x1300 car size).pdf")));
                                break;
                            }
                        case "RS-2A/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Tower\\"))); //to be updated
                                break;
                            }
                    }
                }
            }
            if (lVGquote.LiftType == "DomusXL Spirit")
            {
                if (lVGquote.LoadBearingWall == "Left") // Vivek to check 
                {
                    switch (lVGquote.LiftModel)
                    {
                        case "RS-1C/XL":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Tower\\DomusSpirit RS-1C8 SX T (1100x1400 car size).pdf")));
                                break;
                            }
                        case "RS-2P/XL":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Tower\\DomusSpirit RS-2P8 SX T (1100x1400 car size).pdf")));
                                break;
                            }
                        case "RS-2A/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Tower\\ .pdf"))); //to be updated
                                break;
                            }

                    }
                }
                if (lVGquote.LoadBearingWall == "Right")  // Vivek to check 
                {
                    switch (lVGquote.LiftModel)
                    {
                        case "RS-1C/XL":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Tower\\DomusSpirit RS-1C8 DX T (1100x1400 car size).pdf")));
                                break;
                            }
                        case "RS-2P/XL":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Tower\\DomusSpirit RS-2P8 DX T (1100x1400 car size).pdf")));
                                break;
                            }
                        case "RS-2A/4":
                            {

                                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusXL Spirit\\Tower\\ .pdf"))); //to be updated
                                break;
                            }

                    }
                }
            }
        }
        [HttpPost]
        public ActionResult SendEmail(Models.MailModel objModelMail, HttpPostedFileBase[] fileUploader)
        {
            MainQuote lVGquote = db.MainQuote.Find(objModelMail.quoteID);
            section1Model sectmodel = db.section1Model.Find(lVGquote.Section1ModelId);
            if (ModelState.IsValid)
            {
                string from = null;
                string path = null;
                string sign_text=null;
                switch (sectmodel.SalesPerson)
                {
                    case "Craig Schmidt":
                        {
                            from = "craig@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/craig_scmidt_sign.png");
                            sign_text = "<div>Craig Schmidt<br>0402143793 <br><br>I thought I’d highlight &nbsp;a couple of important points that sets us apart from our competitors and keeps us at #1 in the private residential lift market: Fully designed and manufactured in&nbsp;Europe..…where quality&nbsp;still counts!. You may be comparing our price with Chinese price and quality. We won’t compromise quality<b>.</b></div><div><b><br></b></div><div><font color='#009900'>Optional Extended Warranty&nbsp;</font><font color='#33ff33'>&nbsp; &nbsp;</font>We can tailor an extended service &amp; warranty agreement of up to 5 years, to suit your individual needs,&nbsp;for all the Domus range of lifts in private homes</div><div><font color='#009900'><br></font></div><div><font color='#009900'>Smooth and Quiet…</font>the dual speed oil hydraulic valve system accelerates and decelerates your lift smoothly and quietly because of its precision manufacture.</div><div>&nbsp;Add to this the fact we have over 5000 lifts in our maintenance system nationally…..you’ve got the expertise and back-up you need locally and internationally……so what are you waiting for</div><div><br></div><div><font color='#009900'>Come in and be inspired with our world class “working” showroom</font></div><div>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>Home Elevators (VIC) Pty Limited (ABN 91 136 701 865) &amp; Easy Living Home Elevators (WA) Pty Limited (ABN 15 142 482 451) &nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>accepts no liability for any damage caused by this email or its attachments due to&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>viruses, interference, interception, corruption or unauthorised access.</font></div></div>,";
                            break;
                        }
                    case "David Mayer":
                        {
                            from = "david.mayer@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/david_mayer_sign.png");
                            //craigs copied sign
                            sign_text = "<div>David Mayer<br><br><br>I thought I’d highlight &nbsp;a couple of important points that sets us apart from our competitors and keeps us at #1 in the private residential lift market: Fully designed and manufactured in&nbsp;Europe..…where quality&nbsp;still counts!. You may be comparing our price with Chinese price and quality. We won’t compromise quality<b>.</b></div><div><b><br></b></div><div><font color='#009900'>Optional Extended Warranty&nbsp;</font><font color='#33ff33'>&nbsp; &nbsp;</font>We can tailor an extended service &amp; warranty agreement of up to 5 years, to suit your individual needs,&nbsp;for all the Domus range of lifts in private homes</div><div><font color='#009900'><br></font></div><div><font color='#009900'>Smooth and Quiet…</font>the dual speed oil hydraulic valve system accelerates and decelerates your lift smoothly and quietly because of its precision manufacture.</div><div>&nbsp;Add to this the fact we have over 5000 lifts in our maintenance system nationally…..you’ve got the expertise and back-up you need locally and internationally……so what are you waiting for</div><div><br></div><div><font color='#009900'>Come in and be inspired with our world class “working” showroom</font></div><div>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>Home Elevators (VIC) Pty Limited (ABN 91 136 701 865) &amp; Easy Living Home Elevators (WA) Pty Limited (ABN 15 142 482 451) &nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>accepts no liability for any damage caused by this email or its attachments due to&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>viruses, interference, interception, corruption or unauthorised access.</font></div></div>,";
                            break;
                        }
                    case "David Smith":
                        {
                            from = "david.smith@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/david_smith_sign.png");
                            sign_text = "<div>David Mayer<br>0423320668<br><br>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'><div><div>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</div><div>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</div><div>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</div><div>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</div><div>Home Elevators Pty Limited (ABN 85 136 701 838) accepts no liability for any damage caused by this email or its attachments due to&nbsp;</div><div>viruses, interference, interception, corruption or unauthorised access.</div></div>";
                            break;
                        }
                    case "Kevin Bunting":
                        {
                            from = "kevin.bunting@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/kevin_bunting_sign.png");
                            sign_text = "<div>Kevin Bunting<br>0409642843<br><br><br>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'><div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>Home Elevators Pty Limited (ABN 083 936 896) accepts no liability for any damage caused by this email or its attachments due to&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size=1'>viruses, interference, interception, corruption or unauthorised access.</font></div></div>";
                            break;
                        }
                    case "Michael Heltborg":
                        {
                            from = "michaelh@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/michael_heltborg_sign.png");
                            sign_text = "<div>Michael Heltborg<br>0414 937 675<br><br>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'><div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>Home Elevators Pty Limited (ABN 083 936 896) accepts no liability for any damage caused by this email or its attachments due to&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size=1'>viruses, interference, interception, corruption or unauthorised access.</font></div></div>";
                            break;
                        }

                    case "Dijana Vojvodic":
                        {
                            from = "dijanav@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/dijana_vojvodic_sign.png");
                            sign_text = "<div>Dijana Vojvodic<br>0431 095 335<br><br>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'><div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>Home Elevators Pty Limited (ABN 083 936 896) accepts no liability for any damage caused by this email or its attachments due to&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size=1'>viruses, interference, interception, corruption or unauthorised access.</font></div></div>";
                            break;
                        }

                    case "Robert Pizzie":
                        {
                            from = "robert@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/robert_pizzie_sign.png");
                            sign_text = "<div>Robert Pizzie<br>0418 613 424<br><br>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'><div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size='1'>Home Elevators Pty Limited (ABN 083 936 896) accepts no liability for any damage caused by this email or its attachments due to&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:Times New Roman;font-size:medium'><font face='Arial' size=1'>viruses, interference, interception, corruption or unauthorised access.</font></div></div>";
                            break;
                        }

                    case "Paul Solotwa":
                        {
                            from = "paul.solotwa@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/paul_solotwa_sign.png");
                            sign_text = "<div>Paul Solotwa<br>0412 034 976<br><br>I thought I’d highlight &nbsp;a couple of important points that sets us apart from our competitors and keeps us at #1 in the private residential lift market: Fully designed and manufactured in&nbsp;Europe..…where quality&nbsp;still counts!. You may be comparing our price with Chinese price and quality. We won’t compromise quality<b>.</b></div><div><b><br></b></div><div><font color='#009900'>Optional Extended Warranty&nbsp;</font><font color='#33ff33'>&nbsp; &nbsp;</font>We can tailor an extended service &amp; warranty agreement of up to 5 years, to suit your individual needs,&nbsp;for all the Domus range of lifts in private homes</div><div><font color='#009900'><br></font></div><div><font color='#009900'>Smooth and Quiet…</font>the dual speed oil hydraulic valve system accelerates and decelerates your lift smoothly and quietly because of its precision manufacture.</div><div>&nbsp;Add to this the fact we have over 5000 lifts in our maintenance system nationally…..you’ve got the expertise and back-up you need locally and internationally……so what are you waiting for</div><div><br></div><div><font color='#009900'>Come in and be inspired with our world class “working” showroom</font></div><div>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>Home Elevators (VIC) Pty Limited (ABN 91 136 701 865) &amp; Easy Living Home Elevators (WA) Pty Limited (ABN 15 142 482 451) &nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>accepts no liability for any damage caused by this email or its attachments due to&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>viruses, interference, interception, corruption or unauthorised access.</font></div></div>,";
                            break;
                        }

                    case "Mike Booth":
                        {
                            from = "mike.booth@easy-living.com.au";
                            path = Server.MapPath(@"~/Content/signature/mike_booth_sign.png");
                            sign_text = "<div>Mike Booth<br>0418 589 857<br><br>I thought I’d highlight &nbsp;a couple of important points that sets us apart from our competitors and keeps us at #1 in the private residential lift market: Fully designed and manufactured in&nbsp;Europe..…where quality&nbsp;still counts!. You may be comparing our price with Chinese price and quality. We won’t compromise quality<b>.</b></div><div><b><br></b></div><div><font color='#009900'>Optional Extended Warranty&nbsp;</font><font color='#33ff33'>&nbsp; &nbsp;</font>We can tailor an extended service &amp; warranty agreement of up to 5 years, to suit your individual needs,&nbsp;for all the Domus range of lifts in private homes</div><div><font color='#009900'><br></font></div><div><font color='#009900'>Smooth and Quiet…</font>the dual speed oil hydraulic valve system accelerates and decelerates your lift smoothly and quietly because of its precision manufacture.</div><div>&nbsp;Add to this the fact we have over 5000 lifts in our maintenance system nationally…..you’ve got the expertise and back-up you need locally and internationally……so what are you waiting for</div><div><br></div><div><font color='#009900'>Come in and be inspired with our world class “working” showroom</font></div><div>&nbsp;<a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' style='font-family:'Times New Roman';font-size:medium' target='_blank'><img src=cid:signature align='top' border='0' alt='' hspace='' vspace='' class='CToWUd'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><a href='http://www.easy-living.com.au/' name='14dc31407bc964f3_SafeHtmlFilter_' target='_blank'></a></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>This message and its attachments may contain legally privileged or confidential information. It is for the intended addressee(s) only.&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>If you are not the intended recipient you must not disclose or use the information contained in it. If you have received this email in&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>error please notify us immediately by return email and delete the document. Any views expressed in this message are those of the&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>individual sender, except where the sender specifies and with authority, states them to be the views of the Company. Easy Living&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>Home Elevators (VIC) Pty Limited (ABN 91 136 701 865) &amp; Easy Living Home Elevators (WA) Pty Limited (ABN 15 142 482 451) &nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>accepts no liability for any damage caused by this email or its attachments due to&nbsp;</font></div><div style='color:rgb(0,0,0);font-family:'Times New Roman';font-size:medium'><font face='Arial' size='1'>viruses, interference, interception, corruption or unauthorised access.</font></div></div>,";
                            break;
                        }
                }


                using (MailMessage mail = new MailMessage(from, objModelMail.To))
                {
                    for (int i = 0; i < objModelMail.ToAdd.Count; i++)
                    {
                        if (objModelMail.ToAdd.ElementAt(i) != String.Empty)
                        {
                            mail.To.Add(objModelMail.ToAdd.ElementAt(i));
                        }
                    }

                    for (int i = 0; i < objModelMail.BccAdd.Count; i++)
                    {
                        if (objModelMail.BccAdd.ElementAt(i) != String.Empty)
                        {
                            mail.Bcc.Add(objModelMail.BccAdd.ElementAt(i));
                        }
                    }

                    attachFiles(mail, objModelMail, lVGquote);



                    if (objModelMail.cc != null)
                    {
                        if (objModelMail.cc != String.Empty)
                        {
                            mail.CC.Add(objModelMail.cc);
                        }
                    }

                    mail.Bcc.Add(objModelMail.from);
                    mail.Subject = objModelMail.subject;
                    mail.IsBodyHtml = true;

                    for (int k = 0; k < fileUploader.Length; k++)
                    {
                        if (fileUploader[k] != null)
                        {
                            string fileName = Path.GetFileName(fileUploader[k].FileName);
                            mail.Attachments.Add(new Attachment(fileUploader[k].InputStream, fileName));
                        }
                    }



                    LinkedResource sign_img = new LinkedResource(path);
                    sign_img.ContentId = "signature";

                    String comm = objModelMail.Comment;
                    String comm_after = comm.Replace("\n", "<br>");
                    AlternateView av1 = AlternateView.CreateAlternateViewFromString(
                          "<html><body><div>" + comm_after + "<br><br></div><div><br>"+sign_text+"</html>"
                          , null, MediaTypeNames.Text.Html);

                    av1.LinkedResources.Add(sign_img);
                    mail.AlternateViews.Add(av1);


                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("mail.tpg.com.au");
                    smtp.EnableSsl = true;
                    smtp.Port = 25;
                    mail.From = new MailAddress(from);
                    smtp.UseDefaultCredentials = true;
                    smtp.Send(mail);
                    ViewBag.Message = "Sent";
                    ViewBag.quiteIndex = objModelMail.mainquiteId;
                    return View(objModelMail);
                }
            }
            else
            {
                ViewBag.Message = "Not Sent";
                ViewBag.quiteIndex = objModelMail.mainquiteId;
                return View(objModelMail);
            }
        }



        //create quote
        public ActionResult CreateQuote(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainQuote lVGquote = db.MainQuote.Find(id);
            if (lVGquote == null)
            {
                return HttpNotFound();

            }

            Branch = (from b in db.section1Model
                      where b.id == lVGquote.Section1ModelId
                      select b.Branch).SingleOrDefault();
            PdfDocument paragraph1 = new PdfDocument();
            string QuoteRoot = System.Configuration.ConfigurationManager.AppSettings["QuoteRoot"];
          //  string filename = "\\\\elhe-syd-ad1\\" + QuoteRoot + "\\" + Branch + "\\Quote" + lVGquote.id + ".pdf";
            string filename = "C:\\" + QuoteRoot + "\\" + Branch + "\\" + lVGquote.LiftType + "_P" + lVGquote.Section1ModelId + "-" + lVGquote.id + ".pdf";
            PdfGenerator pdfg = new PdfGenerator();
            paragraph1 = pdfg.CreatePdf(lVGquote);
            paragraph1.Save(filename);
            //// ...and start a viewer
            //   Process.Start(filename);
            var email = new NewCommentEmail
            {
                To = "gajendra4488@gmail.com",
                UserName = lVGquote.id.ToString(),
                //Comment = "Hello,There is a new comment from " + UserName;
            };
            // email.Attach(new Attachment(filename));
            // email.Send();
            var filesavename = lVGquote.LiftType + "_P" + lVGquote.Section1ModelId + "-" + lVGquote.id + ".pdf";
            return File(filename, "Application/pdf", filesavename);

        }


        [HttpPost]
        public ActionResult CreateQuoteWithSave(LVGquote lvgquote, string nameOfSubmit)
        {

            if (nameOfSubmit == "Save and Create Pdf")
            {
                {
                    Type = (from b in db.section1Model
                            where b.id == lvgquote.Section1ModelId
                            select b.ProjectType).SingleOrDefault();
                    Branch = (from b in db.section1Model
                            where b.id == lvgquote.Section1ModelId
                            select b.Branch).SingleOrDefault();

                    ViewBag.LiftTypes = GetLiftType1(lvgquote.CodeComplence, lvgquote.id);
                    ViewBag.LiftModels = GetLiftModel1(lvgquote.LiftType, lvgquote.EntranceType);

                    ViewBag.CarWallsLHSS = car.getCarWalls();
                    // ViewBag.CarWallsRHS = car.getCarWalls();
                    //ViewBag.CarWallsRear = car.getCarWalls();
                    ViewBag.powers = Getpower1(lvgquote.LiftType, "fake");
                    ViewBag.CodeComp = car.getobj(Type);
                    ViewBag.Phone = car.getPhone(Type);
                    ViewBag.Ceilings = car.getCeiling();
                    ViewBag.Floors = car.getFloors();
                    ViewBag.Profiles = car.getProfiles();
                    ViewBag.COP = car.getCOP();
                    ViewBag.HandrailTypes = car.getHandRailType(Type);
                    ViewBag.LDFDoorType = car.LDFDoorType(lvgquote.LiftType); ViewBag.LDFDoorFinishs1 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType1.Substring(0, 1));
                    ViewBag.LDFDoorFinishs2 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType2.Substring(0, 1));
                    ViewBag.LDFDoorFinishs3 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType3.Substring(0, 1));
                    ViewBag.LDFDoorFinishs4 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType4.Substring(0, 1));
                    ViewBag.LDFDoorFinishs5 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType5.Substring(0, 1));
                    ViewBag.LDFDoorFinishs6 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType6.Substring(0, 1));
                    ViewBag.LDFDoorFinishs7 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType7.Substring(0, 1));
                    ViewBag.LDFDoorFinishs8 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType8.Substring(0, 1));
                    ViewBag.LDFDoorFinishs9 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType9.Substring(0, 1));
                    ViewBag.LDFDoorFinishs10 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType10.Substring(0, 1));
                    ViewBag.StructureFinish = car.getStructureFinish(lvgquote.StructureType);
                    ViewBag.Claddings = car.getCladding(lvgquote.StructureType);
                    ViewBag.entrancetypes = car.getEntranceTypes(lvgquote.EntranceType);


                    // if (lVGquote.TotalSellingPrice == 0)
                    //   ModelState.AddModelError("Name", "Name is required.");

                    try
                    {
                        var actualValue = Convert.ToDecimal(lvgquote.TotalSellingPrice,
                            CultureInfo.CurrentCulture);
                    }
                    catch (FormatException e)
                    {
                        //ModelState.Errors.Add(e);
                        ModelState.AddModelError(e.Message, "Name is required.");
                    }


                    if (ModelState.IsValid)
                    {
                        lvgquote.MyType = "LVGquote";
                        db.Entry(lvgquote).State = EntityState.Modified;
                        db.SaveChanges();
                        //                   return View(lvgquote);
                    }
                }


                if (lvgquote.id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                MainQuote lVGquote = db.MainQuote.Find(lvgquote.id);
                if (lVGquote == null)
                {
                    return HttpNotFound();

                }
                PdfDocument paragraph1 = new PdfDocument();

                string QuoteRoot = System.Configuration.ConfigurationManager.AppSettings["QuoteRoot"];
                string filename = "C:\\" + QuoteRoot + "\\" + Branch+"\\" + lVGquote.LiftType + "_P" + lVGquote.Section1ModelId + "-" + lVGquote.id + ".pdf";
                PdfGenerator pdfg = new PdfGenerator();
                paragraph1 = pdfg.CreatePdf(lVGquote);
                paragraph1.Save(filename);
                //// ...and start a viewer
                //   Process.Start(filename);
                var email = new NewCommentEmail
                {
                    To = "gajendra4488@gmail.com",
                    UserName = lVGquote.id.ToString(),
                    //Comment = "Hello,There is a new comment from " + UserName;
                };
                // email.Attach(new Attachment(filename));
                // email.Send();
                var filesavename = lVGquote.LiftType + "_P" + lVGquote.Section1ModelId + "-" + lVGquote.id + ".pdf";
                return File(filename, "Application/pdf", filesavename);
            }
            else
            {

                {
                    Type = (from b in db.section1Model
                            where b.id == lvgquote.Section1ModelId
                            select b.ProjectType).SingleOrDefault();

                    ViewBag.LiftTypes = GetLiftType1(lvgquote.CodeComplence, lvgquote.id);
                    ViewBag.LiftModels = GetLiftModel1(lvgquote.LiftType, lvgquote.EntranceType);

                    ViewBag.CarWallsLHSS = car.getCarWalls();
                    // ViewBag.CarWallsRHS = car.getCarWalls();
                    //ViewBag.CarWallsRear = car.getCarWalls();
                    ViewBag.powers = Getpower1(lvgquote.LiftType, "fake");
                    ViewBag.CodeComp = car.getobj(Type);
                    ViewBag.Phone = car.getPhone(Type);
                    ViewBag.Ceilings = car.getCeiling();
                    ViewBag.Floors = car.getFloors();
                    ViewBag.Profiles = car.getProfiles();
                    ViewBag.COP = car.getCOP();
                    ViewBag.HandrailTypes = car.getHandRailType(Type);
                    ViewBag.LDFDoorType = car.LDFDoorType(lvgquote.LiftType); ViewBag.LDFDoorFinishs1 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType1.Substring(0, 1));
                    ViewBag.LDFDoorFinishs2 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType2.Substring(0, 1));
                    ViewBag.LDFDoorFinishs3 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType3.Substring(0, 1));
                    ViewBag.LDFDoorFinishs4 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType4.Substring(0, 1));
                    ViewBag.LDFDoorFinishs5 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType5.Substring(0, 1));
                    ViewBag.LDFDoorFinishs6 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType6.Substring(0, 1));
                    ViewBag.LDFDoorFinishs7 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType7.Substring(0, 1));
                    ViewBag.LDFDoorFinishs8 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType8.Substring(0, 1));
                    ViewBag.LDFDoorFinishs9 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType9.Substring(0, 1));
                    ViewBag.LDFDoorFinishs10 = car.LDFDoorFinish(lvgquote.LiftType, lvgquote.LDFDoorType10.Substring(0, 1));
                    ViewBag.StructureFinish = car.getStructureFinish(lvgquote.StructureType);
                    ViewBag.Claddings = car.getCladding(lvgquote.StructureType);
                    ViewBag.entrancetypes = car.getEntranceTypes(lvgquote.EntranceType);


                    // if (lVGquote.TotalSellingPrice == 0)
                    //   ModelState.AddModelError("Name", "Name is required.");

                    try
                    {
                        var actualValue = Convert.ToDecimal(lvgquote.TotalSellingPrice,
                            CultureInfo.CurrentCulture);
                    }
                    catch (FormatException e)
                    {
                        //ModelState.Errors.Add(e);
                        ModelState.AddModelError(e.Message, "Name is required.");
                    }


                    if (ModelState.IsValid)
                    {
                        lvgquote.MyType = "LVGquote";
                        db.Entry(lvgquote).State = EntityState.Modified;
                        db.SaveChanges();
                        //return View(lvgquote);
                    }
                    return RedirectToAction("Edit", "LVGquotes", new { id = lvgquote.id });
                }

            }
        }



        public ActionResult ClearQuotes()
        {


            db.Database.ExecuteSqlCommand("Delete from MainQuotes");
            db.Database.ExecuteSqlCommand("DBCC Checkident ('MainQuotes',Reseed,0)");

            db.Database.ExecuteSqlCommand("Delete from section1Model");
            db.Database.ExecuteSqlCommand("DBCC Checkident ('section1Model',Reseed,0)");
            return View();

        }
        // GET: LVGquotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            MainQuote lVGquote = db.MainQuote.Find(id);
            Type = (from b in db.section1Model
                    where b.id == lVGquote.Section1ModelId
                    select b.ProjectType).SingleOrDefault();
            if (lVGquote == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type = Type;
            Type = (from b in db.section1Model
                    where b.id == lVGquote.Section1ModelId
                    select b.ProjectType).SingleOrDefault();

            ViewBag.LiftTypes = GetLiftType1(lVGquote.CodeComplence, lVGquote.id);
            ViewBag.LiftModels = GetLiftModel1(lVGquote.LiftType, lVGquote.EntranceType);
            ViewBag.CarWallsLHSS = car.getCarWalls();
            ViewBag.powers = Getpower1(lVGquote.LiftType, "fake");
            ViewBag.CodeComp = car.getobj(Type);
            ViewBag.Phone = car.getPhone(Type);
            ViewBag.Ceilings = car.getCeiling();
            ViewBag.Floors = car.getFloors();
            ViewBag.Profiles = car.getProfiles();
            ViewBag.COP = car.getCOP();
            ViewBag.HandrailTypes = car.getHandRailType(Type);
            ViewBag.LDFDoorType = car.LDFDoorType(lVGquote.LiftType);
            ViewBag.LDFDoorFinishs1 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType1.Substring(0, 1));
            ViewBag.LDFDoorFinishs2 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType2.Substring(0, 1));
            ViewBag.LDFDoorFinishs3 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType3.Substring(0, 1));
            ViewBag.LDFDoorFinishs4 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType4.Substring(0, 1));
            ViewBag.LDFDoorFinishs5 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType5.Substring(0, 1));
            ViewBag.LDFDoorFinishs6 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType6.Substring(0, 1));
            ViewBag.LDFDoorFinishs7 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType7.Substring(0, 1));
            ViewBag.LDFDoorFinishs8 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType8.Substring(0, 1));
            ViewBag.LDFDoorFinishs9 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType9.Substring(0, 1));
            ViewBag.LDFDoorFinishs10 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType10.Substring(0, 1));
            ViewBag.Claddings = car.getCladding(lVGquote.StructureType);
            ViewBag.entrancetypes = car.getEntranceTypes(lVGquote.EntranceType);

            ViewBag.StructureFinish = car.getStructureFinish(lVGquote.StructureType);
            ViewBag.Message = "";
            return View(lVGquote);
        }

        // POST: LVGquotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LVGquote lVGquote)
        {

            Type = (from b in db.section1Model
                    where b.id == lVGquote.Section1ModelId
                    select b.ProjectType).SingleOrDefault();

            ViewBag.LiftTypes = GetLiftType1(lVGquote.CodeComplence, lVGquote.id);
            ViewBag.LiftModels = GetLiftModel1(lVGquote.LiftType, lVGquote.EntranceType);

            ViewBag.CarWallsLHSS = car.getCarWalls();
            ViewBag.powers = Getpower1(lVGquote.LiftType, "fake");
            ViewBag.CodeComp = car.getobj(Type);
            ViewBag.Phone = car.getPhone(Type);
            ViewBag.Ceilings = car.getCeiling();
            ViewBag.Floors = car.getFloors();
            ViewBag.Profiles = car.getProfiles();
            ViewBag.COP = car.getCOP();
            ViewBag.HandrailTypes = car.getHandRailType(Type);
            ViewBag.LDFDoorType = car.LDFDoorType(lVGquote.LiftType); ViewBag.LDFDoorFinishs1 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType1.Substring(0, 1));
            ViewBag.LDFDoorFinishs2 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType2.Substring(0, 1));
            ViewBag.LDFDoorFinishs3 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType3.Substring(0, 1));
            ViewBag.LDFDoorFinishs4 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType4.Substring(0, 1));
            ViewBag.LDFDoorFinishs5 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType5.Substring(0, 1));
            ViewBag.LDFDoorFinishs6 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType6.Substring(0, 1));
            ViewBag.LDFDoorFinishs7 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType7.Substring(0, 1));
            ViewBag.LDFDoorFinishs8 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType8.Substring(0, 1));
            ViewBag.LDFDoorFinishs9 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType9.Substring(0, 1));
            ViewBag.LDFDoorFinishs10 = car.LDFDoorFinish(lVGquote.LiftType, lVGquote.LDFDoorType10.Substring(0, 1));
            ViewBag.StructureFinish = car.getStructureFinish(lVGquote.StructureType);
            ViewBag.Claddings = car.getCladding(lVGquote.StructureType);
            ViewBag.entrancetypes = car.getEntranceTypes(lVGquote.EntranceType);


            try
            {
                var actualValue = Convert.ToDecimal(lVGquote.TotalSellingPrice,
                    CultureInfo.CurrentCulture);
            }
            catch (FormatException e)
            {
                ModelState.AddModelError(e.Message, "Name is required.");
            }


            if (ModelState.IsValid)
            {
                lVGquote.MyType = "LVGquote";
                db.Entry(lVGquote).State = EntityState.Modified;
                db.SaveChanges();
                return View(lVGquote);
            }
            return View(lVGquote);
        }

        // GET: LVGquotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MainQuote lVGquote = db.MainQuote.Find(id);
            if (lVGquote == null)
            {
                return HttpNotFound();
            }
            return View(lVGquote);
        }



        // POST: LVGquotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MainQuote lVGquote = db.MainQuote.Find(id);
            db.MainQuote.Remove(lVGquote);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetLiftType(string Value, int Id)
        {
            string x = (from b in db.section1Model
                        where b.id == Id
                        select b.Branch).SingleOrDefault();
            string[] words = Value.Split('(');
            //   string vallue1 = Value.Substring(7);

            switch (words[0])
            {
                case "Part 18":

                    List<SelectListItem> obj = new List<SelectListItem>();

                    obj.Add(new SelectListItem { Value = "DomusLift", Text = "DomusLift" });
                    obj.Add(new SelectListItem { Value = "DomusXL", Text = "DomusXL" });
                    obj.Add(new SelectListItem { Value = "Domus Evolution", Text = "Domus Evolution" });
                    obj.Add(new SelectListItem { Value = "Domus Spirit", Text = "Domus Spirit" });
                    obj.Add(new SelectListItem { Value = "DomusXL Spirit", Text = "DomusXL Spirit" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj, JsonRequestBehavior.AllowGet);
                case "Part 15":

                    List<SelectListItem> obj1 = new List<SelectListItem>();

                    obj1.Add(new SelectListItem { Value = "DomusXL", Text = "DomusXL" });
                    obj1.Add(new SelectListItem { Value = "DomusXL Spirit", Text = "DomusXL Spirit" });
                    obj1.Add(new SelectListItem { Value = "DomusLift", Text = "DomusLift" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj1, JsonRequestBehavior.AllowGet);


                case "Part 16":

                    if (Value == "Part 16(commercial)")
                    {
                        if (x == "VIC")
                        {
                            List<SelectListItem> obj2 = new List<SelectListItem>();

                            obj2.Add(new SelectListItem { Value = "Domus Evolution", Text = "Domus Evolution" });
                            obj2.Add(new SelectListItem { Value = "DomusXL", Text = "DomusXL" });
                            obj2.Add(new SelectListItem { Value = "DomusXL Spirit", Text = "DomusXL Spirit" });
                            return Json(obj2, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            List<SelectListItem> obj3 = new List<SelectListItem>();

                            obj3.Add(new SelectListItem { Value = "Domus Evolution", Text = "Domus Evolution" });

                            // ViewBag.MainCategoryid = obj;
                            return Json(obj3, JsonRequestBehavior.AllowGet);

                        }
                    }
                    else
                    {
                        List<SelectListItem> obj2 = new List<SelectListItem>();
                        obj2.Add(new SelectListItem { Value = "DomusLift", Text = "DomusLift" });
                        obj2.Add(new SelectListItem { Value = "Domus Spirit", Text = "Domus Spirit" });
                        obj2.Add(new SelectListItem { Value = "Domus Evolution", Text = "Domus Evolution" });
                        obj2.Add(new SelectListItem { Value = "DomusXL", Text = "DomusXL" });
                        obj2.Add(new SelectListItem { Value = "DomusXL Spirit", Text = "DomusXL Spirit" });
                        return Json(obj2, JsonRequestBehavior.AllowGet);


                    }

                default:
                    return Json(null, JsonRequestBehavior.AllowGet); ;

            }
        }
        public List<SelectListItem> GetLiftType1(string Value, int Id)
        {
            string x = (from b in db.section1Model
                        where b.id == Id
                        select b.Branch).SingleOrDefault();
            string[] words = Value.Split('(');
            //   string vallue1 = Value.Substring(7);

            switch (words[0])
            {
                case "Part 18":

                    List<SelectListItem> obj = new List<SelectListItem>();

                    obj.Add(new SelectListItem { Value = "DomusLift", Text = "DomusLift" });
                    obj.Add(new SelectListItem { Value = "DomusXL", Text = "DomusXL" });
                    obj.Add(new SelectListItem { Value = "Domus Evolution", Text = "Domus Evolution" });
                    obj.Add(new SelectListItem { Value = "Domus Spirit", Text = "Domus Spirit" });
                    obj.Add(new SelectListItem { Value = "DomusXL Spirit", Text = "DomusXL Spirit" });

                    // ViewBag.MainCategoryid = obj;
                    return (obj);
                case "Part 15":

                    List<SelectListItem> obj1 = new List<SelectListItem>();

                    obj1.Add(new SelectListItem { Value = "DomusXL", Text = "DomusXL" });
                    obj1.Add(new SelectListItem { Value = "DomusXL Spirit", Text = "DomusXL Spirit" });
                    obj1.Add(new SelectListItem { Value = "DomusLift", Text = "DomusLift" });

                    // ViewBag.MainCategoryid = obj;
                    return (obj1);


                case "Part 16":
                    if (Value == "Part 16(commercial)")
                    {
                        if (x == "VIC")
                        {
                            List<SelectListItem> obj2 = new List<SelectListItem>();

                            obj2.Add(new SelectListItem { Value = "Domus Evolution", Text = "Domus Evolution" });
                            obj2.Add(new SelectListItem { Value = "DomusXL", Text = "DomusXL" });
                            obj2.Add(new SelectListItem { Value = "DomusXL Spirit", Text = "DomusXL Spirit" });
                            return (obj2);
                        }
                        else
                        {
                            List<SelectListItem> obj3 = new List<SelectListItem>();

                            obj3.Add(new SelectListItem { Value = "Domus Evolution", Text = "Domus Evolution" });

                            // ViewBag.MainCategoryid = obj;
                            return (obj3);

                        }
                    }
                    else {
                        List<SelectListItem> obj2 = new List<SelectListItem>();
                        obj2.Add(new SelectListItem { Value = "DomusLift", Text = "DomusLift" });
                        obj2.Add(new SelectListItem { Value = "Domus Spirit", Text = "Domus Spirit" });
                        obj2.Add(new SelectListItem { Value = "Domus Evolution", Text = "Domus Evolution" });
                        obj2.Add(new SelectListItem { Value = "DomusXL", Text = "DomusXL" });
                        obj2.Add(new SelectListItem { Value = "DomusXL Spirit", Text = "DomusXL Spirit" });
                        return (obj2);
                       
 
                    }

                default:
                    return (null);

            }
        }

        public string GetLift(string Value, int Id)
        {
            string x = (from b in db.section1Model
                        where b.id == Id
                        select b.Branch).SingleOrDefault();
            string[] words = Value.Split('(');
            //   string vallue1 = Value.Substring(7);

            switch (words[0])
            {
                case "Part 18":


                    return ("DomusLift");

                case "Part 15":



                    // ViewBag.MainCategoryid = obj;
                    return ("DomusXL");

                case "Part 16":

                    if (x == "VIC")
                    {

                        return ("DomusXL");
                    }
                    else
                    {
                        return ("DomusXL");


                    }

                default:
                    return (null);

            }
        }
        public ActionResult GetLiftModel(string Value, string Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();


            switch (Value)
            {
                case "DomusXL Spirit":

                    List<SelectListItem> obj3 = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {
                        obj3.Add(new SelectListItem { Value = "RS-1C/XL", Text = "RS-1C/XL" });
                        obj3.Add(new SelectListItem { Value = "RS-1C/XL Special", Text = "RS-1C/XL Special" });

                    }

                    if (Id == "Front & Rear entrance")
                    {
                        obj3.Add(new SelectListItem { Value = "RS-2P/XL", Text = "RS-2P/XL" });
                        obj3.Add(new SelectListItem { Value = "RS-2P/XL Special", Text = "RS-2P/XL Special" });

                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj3.Add(new SelectListItem { Value = "RS-2A/XL", Text = "RS-2A/XL" });
                        obj3.Add(new SelectListItem { Value = "RS-2A/XL Special", Text = "RS-2A/XL Special" });


                    }


                    return Json(obj3, JsonRequestBehavior.AllowGet);

                case "DomusLift":
                    List<SelectListItem> obj = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {


                        obj.Add(new SelectListItem { Value = "1C/4", Text = "1C/4" });
                        obj.Add(new SelectListItem { Value = "1C/1", Text = "1C/1" });
                        obj.Add(new SelectListItem { Value = "1C/2", Text = "1C/2" });
                        obj.Add(new SelectListItem { Value = "1C/3", Text = "1C/3" });

                        obj.Add(new SelectListItem { Value = "1C/5", Text = "1C/5" });
                        obj.Add(new SelectListItem { Value = "1C/6", Text = "1C/6" });
                        obj.Add(new SelectListItem { Value = "1C/7", Text = "1C/7" });
                        obj.Add(new SelectListItem { Value = "1C/8", Text = "1C/8" });
                        obj.Add(new SelectListItem { Value = "1C/12", Text = "1C/12" });
                        obj.Add(new SelectListItem { Value = "1C/Special", Text = "1C/Special" });
                        obj.Add(new SelectListItem { Value = "1C/small", Text = "1C/small" });
                        obj.Add(new SelectListItem { Value = "1L/1", Text = "1L/1" });
                        obj.Add(new SelectListItem { Value = "1L/2", Text = "1L/2" });
                        obj.Add(new SelectListItem { Value = "1L/3", Text = "1L/3" });
                        obj.Add(new SelectListItem { Value = "1L/4", Text = "1L/4" });
                        obj.Add(new SelectListItem { Value = "1L/5", Text = "1L/5" });
                        obj.Add(new SelectListItem { Value = "1L/6", Text = "1L/6" });
                        obj.Add(new SelectListItem { Value = "1L/7", Text = "1L/7" });
                        obj.Add(new SelectListItem { Value = "1L/Special", Text = "1L/Special" });
                        obj.Add(new SelectListItem { Value = "1L/small", Text = "1L/small" });

                        // ViewBag.MainCategoryid = obj;

                    }
                    if (Id == "Front & Rear entrance")
                    {
                        obj.Add(new SelectListItem { Value = "2P/4", Text = "2P/4" });
                        obj.Add(new SelectListItem { Value = "2P/1", Text = "2P/1" });
                        obj.Add(new SelectListItem { Value = "2P/2", Text = "2P/2" });
                        obj.Add(new SelectListItem { Value = "2P/3", Text = "2P/3" });

                        obj.Add(new SelectListItem { Value = "2P/5", Text = "2P/5" });
                        obj.Add(new SelectListItem { Value = "2P/6", Text = "2P/6" });
                        obj.Add(new SelectListItem { Value = "2P/7", Text = "2P/7" });
                        obj.Add(new SelectListItem { Value = "2P/8", Text = "2P/8" });
                        obj.Add(new SelectListItem { Value = "2P/Special", Text = "2P/Special" });
                        obj.Add(new SelectListItem { Value = "2P/small", Text = "2P/small" });

                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj.Add(new SelectListItem { Value = "2A/4", Text = "2A/4" });
                        obj.Add(new SelectListItem { Value = "2A/1", Text = "2A/1" });
                        obj.Add(new SelectListItem { Value = "2A/2", Text = "2A/2" });
                        obj.Add(new SelectListItem { Value = "2A/3", Text = "2A/3" });

                        obj.Add(new SelectListItem { Value = "2A/5", Text = "2A/5" });
                        obj.Add(new SelectListItem { Value = "2A/6", Text = "2A/6" });
                        obj.Add(new SelectListItem { Value = "2A/7", Text = "2A/7" });
                        obj.Add(new SelectListItem { Value = "2A/9", Text = "2A/9" });
                        obj.Add(new SelectListItem { Value = "2A/Special", Text = "2A/Special" });
                        obj.Add(new SelectListItem { Value = "2A/small", Text = "2P/small" });

                    }
                    return Json(obj, JsonRequestBehavior.AllowGet);

                case "DomusXL":
                    List<SelectListItem> obj1 = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {
                        obj1.Add(new SelectListItem { Value = "1C/XL", Text = "1C/XL" });
                        obj1.Add(new SelectListItem { Value = "1C/XL Special", Text = "1C/XL Special" });

                    }

                    if (Id == "Front & Rear entrance")
                    {
                        obj1.Add(new SelectListItem { Value = "2P/XL", Text = "2P/XL" });
                        obj1.Add(new SelectListItem { Value = "2P/XL Special", Text = "2P/XL Special" });

                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {

                        obj1.Add(new SelectListItem { Value = "2A/XL", Text = "2A/XL" });
                        obj1.Add(new SelectListItem { Value = "2A/XL Special", Text = "2A/XL Special" });

                    }


                    return Json(obj1, JsonRequestBehavior.AllowGet);

                case "Domus Spirit":

                    List<SelectListItem> obj4 = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {
                        obj4.Add(new SelectListItem { Value = "RS-1C/4", Text = "RS-1C/4" });
                        obj4.Add(new SelectListItem { Value = "RS/Special", Text = "RS/Special" });

                    }

                    if (Id == "Front & Rear entrance")
                    {
                        obj4.Add(new SelectListItem { Value = "RS-2P/4", Text = "RS-2P/4" });
                        obj4.Add(new SelectListItem { Value = "RS/Special", Text = "RS/Special" });

                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj4.Add(new SelectListItem { Value = "RS-2A/4", Text = "RS-2A/4" });
                        obj4.Add(new SelectListItem { Value = "RS/Special", Text = "RS/Special" });

                    }


                    return Json(obj4, JsonRequestBehavior.AllowGet);

                case "Domus Evolution":

                    List<SelectListItem> obj2 = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {
                        obj2.Add(new SelectListItem { Value = "EVO-1C/2T", Text = "EVO-1C/2T" });
                        obj2.Add(new SelectListItem { Value = "EVO-1C/2T Special", Text = "EVO-1C/2T Special" });
                        obj2.Add(new SelectListItem { Value = "EVO-1L/2T", Text = "EVO-1L/2T" });
                        obj2.Add(new SelectListItem { Value = "EVO-1L/2T Special", Text = "EVO-1L/2T Special" });

                    }

                    if (Id == "Front & Rear entrance")
                    {
                        obj2.Add(new SelectListItem { Value = "EVO-2P/2T", Text = "EVO-2P/2T" });
                        obj2.Add(new SelectListItem { Value = "EVO-2P/2T Special", Text = "EVO-2P/2T Special" });

                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj2.Add(new SelectListItem { Value = "EVO-2A/2T", Text = "EVO-2A/2T" });
                        obj2.Add(new SelectListItem { Value = "EVO-2A/2T Special", Text = "EVO-2A/2T Special" });

                    }


                    return Json(obj2, JsonRequestBehavior.AllowGet);



                default:
                    return Json(null, JsonRequestBehavior.AllowGet); ;

            }
        }
        public List<SelectListItem> GetLiftModel1(string Value, string Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();


            switch (Value)
            {
                case "DomusXL Spirit":

                    List<SelectListItem> obj3 = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {
                        obj3.Add(new SelectListItem { Value = "RS-1C/XL", Text = "RS-1C/XL" });
                        obj3.Add(new SelectListItem { Value = "RS-1C/XL Special", Text = "RS-1C/XL Special" });


                    }

                    if (Id == "Front & Rear entrance")
                    {
                        obj3.Add(new SelectListItem { Value = "RS-2P/XL", Text = "RS-2P/XL" });
                        obj3.Add(new SelectListItem { Value = "RS-2P/XL Special", Text = "RS-2P/XL Special" });

                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj3.Add(new SelectListItem { Value = "RS-2A/XL", Text = "RS-2A/XL" });
                        obj3.Add(new SelectListItem { Value = "RS-2A/XL Special", Text = "RS-2A/XL Special" });


                    }


                    return (obj3);

                case "DomusLift":
                    List<SelectListItem> obj = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {


                        obj.Add(new SelectListItem { Value = "1C/4", Text = "1C/4" });
                        obj.Add(new SelectListItem { Value = "1C/1", Text = "1C/1" });
                        obj.Add(new SelectListItem { Value = "1C/2", Text = "1C/2" });
                        obj.Add(new SelectListItem { Value = "1C/3", Text = "1C/3" });

                        obj.Add(new SelectListItem { Value = "1C/5", Text = "1C/5" });
                        obj.Add(new SelectListItem { Value = "1C/6", Text = "1C/6" });
                        obj.Add(new SelectListItem { Value = "1C/7", Text = "1C/7" });
                        obj.Add(new SelectListItem { Value = "1C/8", Text = "1C/8" });
                        obj.Add(new SelectListItem { Value = "1C/12", Text = "1C/12" });
                        obj.Add(new SelectListItem { Value = "1C/Special", Text = "1C/Special" });
                        obj.Add(new SelectListItem { Value = "1C/small", Text = "1C/small" });
                        obj.Add(new SelectListItem { Value = "1L/1", Text = "1L/1" });
                        obj.Add(new SelectListItem { Value = "1L/2", Text = "1L/2" });
                        obj.Add(new SelectListItem { Value = "1L/3", Text = "1L/3" });
                        obj.Add(new SelectListItem { Value = "1L/4", Text = "1L/4" });
                        obj.Add(new SelectListItem { Value = "1L/5", Text = "1L/5" });
                        obj.Add(new SelectListItem { Value = "1L/6", Text = "1L/6" });
                        obj.Add(new SelectListItem { Value = "1L/7", Text = "1L/7" });
                        obj.Add(new SelectListItem { Value = "1L/Special", Text = "1L/Special" });
                        obj.Add(new SelectListItem { Value = "1L/small", Text = "1L/small" });

                        // ViewBag.MainCategoryid = obj;

                    }
                    if (Id == "Front & Rear entrance")
                    {
                        obj.Add(new SelectListItem { Value = "2P/4", Text = "2P/4" });
                        obj.Add(new SelectListItem { Value = "2P/1", Text = "2P/1" });
                        obj.Add(new SelectListItem { Value = "2P/2", Text = "2P/2" });
                        obj.Add(new SelectListItem { Value = "2P/3", Text = "2P/3" });

                        obj.Add(new SelectListItem { Value = "2P/5", Text = "2P/5" });
                        obj.Add(new SelectListItem { Value = "2P/6", Text = "2P/6" });
                        obj.Add(new SelectListItem { Value = "2P/7", Text = "2P/7" });
                        obj.Add(new SelectListItem { Value = "2P/8", Text = "2P/8" });
                        obj.Add(new SelectListItem { Value = "2P/Special", Text = "2P/Special" });
                        obj.Add(new SelectListItem { Value = "2P/small", Text = "2P/small" });

                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj.Add(new SelectListItem { Value = "2A/4", Text = "2A/4" });
                        obj.Add(new SelectListItem { Value = "2A/1", Text = "2A/1" });
                        obj.Add(new SelectListItem { Value = "2A/2", Text = "2A/2" });
                        obj.Add(new SelectListItem { Value = "2A/3", Text = "2A/3" });

                        obj.Add(new SelectListItem { Value = "2A/5", Text = "2A/5" });
                        obj.Add(new SelectListItem { Value = "2A/6", Text = "2A/6" });
                        obj.Add(new SelectListItem { Value = "2A/7", Text = "2A/7" });
                        obj.Add(new SelectListItem { Value = "2A/9", Text = "2A/9" });
                        obj.Add(new SelectListItem { Value = "2A/Special", Text = "2A/Special" });
                        obj.Add(new SelectListItem { Value = "2A/small", Text = "2P/small" });

                    }
                    return (obj);

                case "DomusXL":
                    List<SelectListItem> obj1 = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {
                        obj1.Add(new SelectListItem { Value = "1C/XL", Text = "1C/XL" });
                        obj1.Add(new SelectListItem { Value = "1C/XL Special", Text = "1C/XL Special" });

                    }

                    if (Id == "Front & Rear entrance")
                    {
                        obj1.Add(new SelectListItem { Value = "2P/XL", Text = "2P/XL" });
                        obj1.Add(new SelectListItem { Value = "2P/XL Special", Text = "2P/XL Special" });


                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj1.Add(new SelectListItem { Value = "2A/XL", Text = "2A/XL" });
                        obj1.Add(new SelectListItem { Value = "2A/XL Special", Text = "2A/XL Special" });

                    }


                    return (obj1);

                case "Domus Spirit":

                    List<SelectListItem> obj4 = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {
                        obj4.Add(new SelectListItem { Value = "RS-1C/4", Text = "RS-1C/4" });
                        obj4.Add(new SelectListItem { Value = "RS/Special", Text = "RS/Special" });

                    }

                    if (Id == "Front & Rear entrance")
                    {
                        obj4.Add(new SelectListItem { Value = "RS-2P/4", Text = "RS-2P/4" });
                        obj4.Add(new SelectListItem { Value = "RS/Special", Text = "RS/Special" });

                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj4.Add(new SelectListItem { Value = "RS-2A/4", Text = "RS-2A/4" });
                        obj4.Add(new SelectListItem { Value = "RS/spcl", Text = "RS/spcl" });

                    }


                    return (obj4);

                case "Domus Evolution":

                    List<SelectListItem> obj2 = new List<SelectListItem>();
                    if (Id == "Front entrance")
                    {
                        obj2.Add(new SelectListItem { Value = "EVO-1C/2T", Text = "EVO-1C/2T" });
                        obj2.Add(new SelectListItem { Value = "EVO-1C/2T Special", Text = "EVO-1C/2T Special" });

                    }

                    if (Id == "Front & Rear entrance")
                    {
                        obj2.Add(new SelectListItem { Value = "EVO-2P/2T", Text = "EVO-2P/2T" });
                        obj2.Add(new SelectListItem { Value = "EVO-2P/2T Special", Text = "EVO-2P/2T Special" });


                    }
                    if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
                    {
                        obj2.Add(new SelectListItem { Value = "EVO-2P/2A", Text = "EVO-2P/2A" });
                        obj2.Add(new SelectListItem { Value = "EVO-2P/2A Special", Text = "EVO-2P/2A Special" });

                    }


                    return (obj2);

                default:
                    return (null); ;





            }
        }

        //public ActionResult GetLiftModel1(string Value, string Id , string Shaft)
        //{
        //    //string x = (from b in db.section1Model
        //    //            where b.id == Id
        //    //            select b.Branch).SingleOrDefault();


        //    switch (Value)
        //    {

        //        case "DomusXL Spirit":

        //            List<SelectListItem> obj3 = new List<SelectListItem>();
        //            if (Id == "Front entrance")
        //            {
        //                obj3.Add(new SelectListItem { Value = "RS-1C/XL", Text = "RS-1C/XL" });
        //                return GetDimensions(Value, Shaft, "RS-1C/XL");

        //            }

        //            if (Id == "Front & Rear entrance")
        //            {
        //                obj3.Add(new SelectListItem { Value = "RS-2P/XL", Text = "RS-2P/XL" });
        //                return GetDimensions(Value, Shaft, "RS-2P/XL");

        //            }
        //            if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
        //            {
        //                obj3.Add(new SelectListItem { Value = "RS-2A/XL", Text = "RS-2A/XL" });
        //                return GetDimensions(Value, Shaft, "RS-2A/X");

        //            }

        //            return Json(obj3, JsonRequestBehavior.AllowGet);

        //        case "DomusLift":

        //            List<SelectListItem> obj = new List<SelectListItem>();
        //            if (Id == "Front entrance")
        //            {



        //                obj.Add(new SelectListItem { Value = "1C/1", Text = "1C/1" });
        //                obj.Add(new SelectListItem { Value = "1C/2", Text = "1C/2" });
        //                obj.Add(new SelectListItem { Value = "1C/3", Text = "1C/3" });
        //                obj.Add(new SelectListItem { Value = "1C/4", Text = "1C/4" });
        //                obj.Add(new SelectListItem { Value = "1C/5", Text = "1C/5" });
        //                obj.Add(new SelectListItem { Value = "1C/6", Text = "1C/6" });
        //                obj.Add(new SelectListItem { Value = "1C/7", Text = "1C/7" });
        //                obj.Add(new SelectListItem { Value = "1C/8", Text = "1C/8" });
        //                obj.Add(new SelectListItem { Value = "1C/12", Text = "1C/12" });
        //                obj.Add(new SelectListItem { Value = "1C/Special", Text = "1C/Special" });
        //                obj.Add(new SelectListItem { Value = "1C/small", Text = "1C/small" });
        //                obj.Add(new SelectListItem { Value = "1L/1", Text = "1L/1" });
        //                obj.Add(new SelectListItem { Value = "1L/2", Text = "1L/2" });
        //                obj.Add(new SelectListItem { Value = "1L/3", Text = "1L/3" });
        //                obj.Add(new SelectListItem { Value = "1L/4", Text = "1L/4" });
        //                obj.Add(new SelectListItem { Value = "1L/5", Text = "1L/5" });
        //                obj.Add(new SelectListItem { Value = "1L/6", Text = "1L/6" });
        //                obj.Add(new SelectListItem { Value = "1L/7", Text = "1L/7" });
        //                obj.Add(new SelectListItem { Value = "1L/Special", Text = "1L/Special" });
        //                obj.Add(new SelectListItem { Value = "1L/small", Text = "1L/small" });

        //                // ViewBag.MainCategoryid = obj;
        //                return GetDimensions(Value, Shaft, "1C/1");

        //            }
        //            if (Id == "Front & Rear entrance")
        //            {

        //                obj.Add(new SelectListItem { Value = "2P/1", Text = "2P/1" });
        //                obj.Add(new SelectListItem { Value = "2P/2", Text = "2P/2" });
        //                obj.Add(new SelectListItem { Value = "2P/3", Text = "2P/3" });
        //                obj.Add(new SelectListItem { Value = "2P/4", Text = "2P/4" });
        //                obj.Add(new SelectListItem { Value = "2P/5", Text = "2P/5" });
        //                obj.Add(new SelectListItem { Value = "2P/6", Text = "2P/6" });
        //                obj.Add(new SelectListItem { Value = "2P/7", Text = "2P/7" });
        //                obj.Add(new SelectListItem { Value = "2P/8", Text = "2P/8" });
        //                obj.Add(new SelectListItem { Value = "2P/Special", Text = "2P/Special" });
        //                obj.Add(new SelectListItem { Value = "2P/small", Text = "2P/small" });
        //                return GetDimensions(Value, Shaft, "2P/1");
        //            }
        //            if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
        //            {

        //                obj.Add(new SelectListItem { Value = "2A/1", Text = "2A/1" });
        //                obj.Add(new SelectListItem { Value = "2A/2", Text = "2A/2" });
        //                obj.Add(new SelectListItem { Value = "2A/3", Text = "2A/3" });
        //                obj.Add(new SelectListItem { Value = "2A/4", Text = "2A/4" });
        //                obj.Add(new SelectListItem { Value = "2A/5", Text = "2A/5" });
        //                obj.Add(new SelectListItem { Value = "2A/6", Text = "2A/6" });
        //                obj.Add(new SelectListItem { Value = "2A/7", Text = "2A/7" });
        //                obj.Add(new SelectListItem { Value = "2A/9", Text = "2A/9" });
        //                obj.Add(new SelectListItem { Value = "2A/Special", Text = "2A/Special" });
        //                obj.Add(new SelectListItem { Value = "2A/small", Text = "2P/small" });
        //                return GetDimensions(Value, Shaft, "2A/1");
        //            }
        //            return Json(obj, JsonRequestBehavior.AllowGet);
        //            break;

        //        case "DomusXL":


        //            List<SelectListItem> obj1 = new List<SelectListItem>();
        //            if (Id == "Front entrance")
        //            {
        //                obj1.Add(new SelectListItem { Value = "1C/XL", Text = "1C/XL" });
        //                return GetDimensions(Value, Shaft, "1C/XL");
        //            }

        //            if (Id == "Front & Rear entrance")
        //            {
        //                obj1.Add(new SelectListItem { Value = "2P/XL", Text = "2P/XL" });
        //                return GetDimensions(Value, Shaft, "2P/XL");
        //            }
        //            if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
        //            {
        //                obj1.Add(new SelectListItem { Value = "2A/XL", Text = "2A/XL" });
        //                return GetDimensions(Value, Shaft, "2A/XL");
        //            }


        //            return Json(obj1, JsonRequestBehavior.AllowGet);
        //            break;

        //        case "Domus Spirit":

        //              List<SelectListItem> obj4 = new List<SelectListItem>();
        //            if (Id == "Front entrance")
        //            {
        //                obj4.Add(new SelectListItem { Value = "RS-1C/4", Text = "RS-1C/4" });
        //                obj4.Add(new SelectListItem { Value = "RS/Special", Text = "RS/Special" });
        //                return GetDimensions(Value, Shaft, "RS-1C/4");

        //            }

        //            if (Id == "Front & Rear entrance")
        //            {
        //                obj4.Add(new SelectListItem { Value = "RS-2P/4", Text = "RS-2P/4" });
        //                obj4.Add(new SelectListItem { Value = "RS/Special", Text = "RS/Special" });
        //                return GetDimensions(Value, Shaft, "RS-2P/4");
        //            }
        //            if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
        //            {
        //                obj4.Add(new SelectListItem { Value = "RS-2A/4", Text = "RS-2A/4" });
        //                obj4.Add(new SelectListItem { Value = "RS/spcl", Text = "RS/spcl" });
        //                return GetDimensions(Value, Shaft, "RS-2A/4");
        //            }


        //            return Json(obj4, JsonRequestBehavior.AllowGet);
        //            break;
        //        case "Domus Evolution":
        //              List<SelectListItem> obj2 = new List<SelectListItem>();
        //            if (Id == "Front entrance")
        //            {
        //                obj2.Add(new SelectListItem { Value = "EVO-1C/2T", Text = "EVO-1C/2T" });
        //                return GetDimensions(Value, Shaft, "EVO-1C/2T");
        //            }

        //            if (Id == "Front & Rear entrance")
        //            {
        //                obj2.Add(new SelectListItem { Value = "EVO-2P/2T", Text = "EVO-2P/2T" });
        //                return GetDimensions(Value, Shaft, "EVO-2P/2T");
        //            }
        //            if (Id == "Front & Adjacent – Left" || Id == "Front & Adjacent – Right")
        //            {
        //                obj2.Add(new SelectListItem { Value = "EVO-2P/2A", Text = "EVO-2P/2A" });
        //                return GetDimensions(Value, Shaft, "EVO-2P/2A");
        //            }


        //            return Json(obj2, JsonRequestBehavior.AllowGet);
        //            break;
        //        default:
        //            return Json(null, JsonRequestBehavior.AllowGet); ;

        //    }
        //}

        public ActionResult GetloadBearingWall(string Value, String Id)
        {

            string[] words = Value.Split('/');
            string SubString = words[0].Substring(words[0].Length - 2);
            switch (SubString)
            {
                case "1C":
                case "2P":

                    List<SelectListItem> obj = new List<SelectListItem>();

                    obj.Add(new SelectListItem { Value = "Left", Text = "Left" });
                    obj.Add(new SelectListItem { Value = "Right", Text = "Right" });
                    // ViewBag.MainCategoryid = obj;
                    return Json(obj, JsonRequestBehavior.AllowGet);

                case "1L":

                    List<SelectListItem> obj1 = new List<SelectListItem>();

                    obj1.Add(new SelectListItem { Value = "Rear", Text = "Rear" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj1, JsonRequestBehavior.AllowGet);


                case "2A":
                    List<SelectListItem> obj3 = new List<SelectListItem>();
                    if (Id == "Front & Adjacent – Left")
                    {
                        //   List<SelectListItem> obj2 = new List<SelectListItem>();

                        obj3.Add(new SelectListItem { Value = "Right", Text = "Right" });

                    }
                    if (Id == "Front & Adjacent – Right")
                    {


                        obj3.Add(new SelectListItem { Value = "Left", Text = "Left" });

                        // ViewBag.MainCategoryid = obj;
                        // return Json(obj3, JsonRequestBehavior.AllowGet);

                    }
                    return Json(obj3, JsonRequestBehavior.AllowGet);

                default:
                        obj3 = new List<SelectListItem>();
                        obj3.Add(new SelectListItem { Value = "Right", Text = "Right" });
                        obj3.Add(new SelectListItem { Value = "Left", Text = "Left" });

                    if (Id == "Front & Adjacent – Left")
                    {

                        obj3.Remove(new SelectListItem { Value = "Left", Text = "Left" });

                    }
                    if (Id == "Front & Adjacent – Right")
                    {


                        obj3.Add(new SelectListItem { Value = "Right", Text = "Right" });


                    }
                    return Json(obj3, JsonRequestBehavior.AllowGet);

            }
        }


        public ActionResult GetCarWalls(string Value, String Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();

            // string[] words = Value.Split('/');
            switch (Value)
            {
                case "DomusLift":
                case "DomusXL":
                case "Domus Evolution":

                    var obj = car.getCarWalls();
                    ViewBag.CarWallsLHS = obj;
                    return Json(obj, JsonRequestBehavior.AllowGet);



                case "Domus Spirit":
                case "DomusXL Spirit":

                    List<SelectListItem> obj1 = new List<SelectListItem>();
                    obj1.Add(new SelectListItem { Value = "Skinplate A32PP - Polished Effect", Text = "Skinplate A32PP - Polished Effect" });
                    ViewBag.CarWallsLHS = obj1;
                    return Json(obj1, JsonRequestBehavior.AllowGet);



                default:
                    return Json(null, JsonRequestBehavior.AllowGet); ;

            }
        }


        public ActionResult GetDriveSystem(string Value, String Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();

            // string[] words = Value.Split('/');
            switch (Value)
            {
                case "DomusLift":
                case "Domus Spirit":
                case "DomusXL":
                case "DomusXL Spirit":

                    List<SelectListItem> obj = new List<SelectListItem>();

                    obj.Add(new SelectListItem { Value = "Hydraulic", Text = "Hydraulic" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj, JsonRequestBehavior.AllowGet);

                case "Domus Evolution":

                    List<SelectListItem> obj1 = new List<SelectListItem>();

                    obj1.Add(new SelectListItem { Value = "Hydraulic", Text = "Hydraulic" });
                    //            obj1.Add(new SelectListItem { Value = "Traction", Text = "Traction" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj1, JsonRequestBehavior.AllowGet);




                default:
                    return Json(null, JsonRequestBehavior.AllowGet); ;

            }
        }
        public List<SelectListItem> Getpower1(string Value, String Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();

            // string[] words = Value.Split('/');
            switch (Value)
            {
                case "DomusLift":
                case "Domus Spirit":
                case "DomusXL":
                case "DomusXL Spirit":

                    List<SelectListItem> obj = new List<SelectListItem>();

                    obj.Add(new SelectListItem { Value = "Single Phase", Text = "Single Phase" });

                    // ViewBag.MainCategoryid = obj;
                    return obj;

                case "Domus Evolution":

                    List<SelectListItem> obj1 = new List<SelectListItem>();
                    obj1.Add(new SelectListItem { Value = "Three Phase", Text = "Three Phase" });
                    obj1.Add(new SelectListItem { Value = "Single Phase", Text = "Single Phase" });


                    // ViewBag.MainCategoryid = obj;
                    return obj1;



                default:
                    return null;

            }
        }
        public ActionResult Getpower(string Value, String Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();

            // string[] words = Value.Split('/');
            switch (Value)
            {
                case "DomusLift":
                case "Domus Spirit":
                case "DomusXL":
                case "DomusXL Spirit":

                    List<SelectListItem> obj = new List<SelectListItem>();

                    obj.Add(new SelectListItem { Value = "Single Phase", Text = "Single Phase" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj, JsonRequestBehavior.AllowGet);

                case "Domus Evolution":

                    List<SelectListItem> obj1 = new List<SelectListItem>();
                    obj1.Add(new SelectListItem { Value = "Three Phase", Text = "Three Phase" });
                    obj1.Add(new SelectListItem { Value = "Single Phase", Text = "Single Phase" });


                    // ViewBag.MainCategoryid = obj;
                    return Json(obj1, JsonRequestBehavior.AllowGet);



                default:
                    return Json(null, JsonRequestBehavior.AllowGet); ;

            }
        }
        public ActionResult GetLDFDoorType(string Value, String Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();



            List<SelectListItem> obj = car.LDFDoorType(Value);






            return Json(obj, JsonRequestBehavior.AllowGet);




        }
        public ActionResult GetLDFDoorFinish(string Value, String Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();



            List<SelectListItem> obj = car.LDFDoorFinish(Value, Id);






            return Json(obj, JsonRequestBehavior.AllowGet);




        }

        public ActionResult GetStructureFinish(string Value)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();



            List<SelectListItem> obj = car.getStructureFinish(Value);






            return Json(obj, JsonRequestBehavior.AllowGet);




        }

        public ActionResult GetCapacity(string Value, String Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();

            // string[] words = Value.Split('/');
            switch (Value)
            {
                case "DomusLift":

                    List<SelectListItem> obj = new List<SelectListItem>();

                    obj.Add(new SelectListItem { Value = "300", Text = "300 Kg" });
                    obj.Add(new SelectListItem { Value = "340", Text = "340 Kg" });
                    obj.Add(new SelectListItem { Value = "400", Text = "400 Kg" });


                    // ViewBag.MainCategoryid = obj;
                    return Json(obj, JsonRequestBehavior.AllowGet);

                case "Domus Spirit":


                    List<SelectListItem> obj2 = new List<SelectListItem>();

//                    obj2.Add(new SelectListItem { Value = "250", Text = "250 Kg" });
                    obj2.Add(new SelectListItem { Value = "300", Text = "300 Kg" });


                    // ViewBag.MainCategoryid = obj;
                    return Json(obj2, JsonRequestBehavior.AllowGet);

                case "DomusXL":
                case "DomusXL Spirit":
                case "Domus Evolution":

                    List<SelectListItem> obj1 = new List<SelectListItem>();

                    obj1.Add(new SelectListItem { Value = "400", Text = "400 Kg" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj1, JsonRequestBehavior.AllowGet);



                default:
                    return Json(null, JsonRequestBehavior.AllowGet); ;

            }
        }
        public ActionResult GetCabSize(string Value, String Id)
        {
            //string x = (from b in db.section1Model
            //            where b.id == Id
            //            select b.Branch).SingleOrDefault();

            // string[] words = Value.Split('/');
            switch (Value)
            {
                case "DomusLift":
                case "Domus Spirit":


                    List<SelectListItem> obj = new List<SelectListItem>();

                    obj.Add(new SelectListItem { Value = "600mm W x  280mm D x 1000mm H", Text = "600mm W x  280mm D x 1000mm H" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj, JsonRequestBehavior.AllowGet);

                case "DomusXL":
                case "DomusXL Spirit":
                case "Domus Evolution":

                    List<SelectListItem> obj1 = new List<SelectListItem>();

                    obj1.Add(new SelectListItem { Value = "720 mm W x 360 mm D x 1500 mm H", Text = "720 mm W x 360 mm D x 1500 mm H" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj1, JsonRequestBehavior.AllowGet);

                default:
                    return Json(null, JsonRequestBehavior.AllowGet); ;

            }
        }
        public ActionResult GetDimensions(string Value, String Shaft, String Model)
        {
            //  string x = "sss";
            // string[] words = Value.Split('/');

            switch (Value)
            {
                case "DomusLift":
                    List<SelectListItem> obj = new List<SelectListItem>();
                    if (Shaft == "Masonry")
                    {
                        switch (Model)
                        {
                            case "1C/1":

                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/2":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1150" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/3":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1450" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/4":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1450" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1C/5":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1150" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/6":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/7":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1350" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/8":
                                obj.Add(new SelectListItem { Value = "1100" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1500" });
                                obj.Add(new SelectListItem { Value = "1550" });
                                obj.Add(new SelectListItem { Value = "900" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1C/12":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1550" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1C/Special":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/Small":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/1":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1100" });
                                obj.Add(new SelectListItem { Value = "1110" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/2":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1110" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/3":
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1600" });
                                obj.Add(new SelectListItem { Value = "1110" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1L/4":
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1600" });
                                obj.Add(new SelectListItem { Value = "1310" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1L/5":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1310" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/6":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1100" });
                                obj.Add(new SelectListItem { Value = "1310" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/7":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1100" });
                                obj.Add(new SelectListItem { Value = "1510" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/Special":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/Small":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;

                            case "2P/1":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "920" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/2":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1120" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/3":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1420" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/4":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1420" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/5":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1120" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/6":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "920" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/7":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1320" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2P/8":
                                obj.Add(new SelectListItem { Value = "1100" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1500" });
                                obj.Add(new SelectListItem { Value = "1520" });
                                obj.Add(new SelectListItem { Value = "900" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "900" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/Special":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "2P/Small":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "2A/1":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1110" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/2":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1110" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2A/3":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1110" });
                                obj.Add(new SelectListItem { Value = "1500" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/4":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1310" });
                                obj.Add(new SelectListItem { Value = "1500" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/5":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1310" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/6":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1310" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/7":
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1510" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/9":
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1510" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/Special":

                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "2A/Small":

                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;


                        }
                    }
                    else
                    {
                        switch (Model)
                        {
                            case "1C/1":

                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1345" });
                                obj.Add(new SelectListItem { Value = "1070" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/2":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1345" });
                                obj.Add(new SelectListItem { Value = "1270" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/3":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1345" });
                                obj.Add(new SelectListItem { Value = "1570" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/4":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1545" });
                                obj.Add(new SelectListItem { Value = "1570" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1C/5":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1545" });
                                obj.Add(new SelectListItem { Value = "1270" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/6":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1545" });
                                obj.Add(new SelectListItem { Value = "1070" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/7":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1345" });
                                obj.Add(new SelectListItem { Value = "1470" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/8":
                                obj.Add(new SelectListItem { Value = "1100" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1600" });
                                obj.Add(new SelectListItem { Value = "1700" });
                                obj.Add(new SelectListItem { Value = "900" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1C/12":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1500" });
                                obj.Add(new SelectListItem { Value = "1700" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1C/Special":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1C/Small":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/1":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1290" });
                                obj.Add(new SelectListItem { Value = "1225" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/2":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1490" });
                                obj.Add(new SelectListItem { Value = "1225" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/3":
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1700" });
                                obj.Add(new SelectListItem { Value = "1225" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1L/4":
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1700" });
                                obj.Add(new SelectListItem { Value = "1425" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "1L/5":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1490" });
                                obj.Add(new SelectListItem { Value = "1425" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/6":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1290" });
                                obj.Add(new SelectListItem { Value = "1425" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/7":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1050" });
                                obj.Add(new SelectListItem { Value = "1550" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/Special":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;
                            case "1L/Small":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });

                                break;

                            case "2P/1":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1345" });
                                obj.Add(new SelectListItem { Value = "1040" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/2":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1345" });
                                obj.Add(new SelectListItem { Value = "1240" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/3":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1345" });
                                obj.Add(new SelectListItem { Value = "1540" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/4":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1540" });
                                obj.Add(new SelectListItem { Value = "1540" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/5":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1545" });
                                obj.Add(new SelectListItem { Value = "1240" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/6":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1545" });
                                obj.Add(new SelectListItem { Value = "1040" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/7":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1345" });
                                obj.Add(new SelectListItem { Value = "1440" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2P/8":
                                obj.Add(new SelectListItem { Value = "1100" });
                                obj.Add(new SelectListItem { Value = "1400" });
                                obj.Add(new SelectListItem { Value = "1500" });
                                obj.Add(new SelectListItem { Value = "1520" });
                                obj.Add(new SelectListItem { Value = "900" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "900" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2P/Special":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "2P/Small":
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "2A/1":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1290" });
                                obj.Add(new SelectListItem { Value = "1165" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "685" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/2":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1290" });
                                obj.Add(new SelectListItem { Value = "1365" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });

                                break;
                            case "2A/3":
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1290" });
                                obj.Add(new SelectListItem { Value = "1665" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/4":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1300" });
                                obj.Add(new SelectListItem { Value = "1490" });
                                obj.Add(new SelectListItem { Value = "1665" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/5":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "1490" });
                                obj.Add(new SelectListItem { Value = "1365" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/6":
                                obj.Add(new SelectListItem { Value = "1000" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1490" });
                                obj.Add(new SelectListItem { Value = "1365" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "685" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/7":
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "800" });
                                obj.Add(new SelectListItem { Value = "1510" });
                                obj.Add(new SelectListItem { Value = "980" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "750" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/9":
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1200" });
                                obj.Add(new SelectListItem { Value = "1510" });
                                obj.Add(new SelectListItem { Value = "1380" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                obj.Add(new SelectListItem { Value = "950" });
                                obj.Add(new SelectListItem { Value = "2000" });
                                break;
                            case "2A/Special":

                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                            case "2A/Small":

                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                obj.Add(new SelectListItem { Value = "N/A" });
                                break;
                        }
                    }
                    return Json(obj, JsonRequestBehavior.AllowGet);



                case "Domus Evolution":
                    List<SelectListItem> obj1 = new List<SelectListItem>();

                    if (Shaft == "Masonry")
                    {
                        switch (Model)
                        {

                            case "EVO-1C/2T":
                                obj1.Add(new SelectListItem { Value = "1100" });
                                obj1.Add(new SelectListItem { Value = "1400" });
                                obj1.Add(new SelectListItem { Value = "1500" });
                                obj1.Add(new SelectListItem { Value = "1690" });
                                obj1.Add(new SelectListItem { Value = "900" });
                                obj1.Add(new SelectListItem { Value = "2000" });
                                obj1.Add(new SelectListItem { Value = "N/A" });
                                obj1.Add(new SelectListItem { Value = "N/A" });
                                break;



                            case "EVO-2P/2T":
                                obj1.Add(new SelectListItem { Value = "1100" });
                                obj1.Add(new SelectListItem { Value = "1400" });
                                obj1.Add(new SelectListItem { Value = "1550" });
                                obj1.Add(new SelectListItem { Value = "1800" });
                                obj1.Add(new SelectListItem { Value = "900" });
                                obj1.Add(new SelectListItem { Value = "2000" });
                                obj1.Add(new SelectListItem { Value = "900" });
                                obj1.Add(new SelectListItem { Value = "2000" });
                                break;

                            case "EVO-2A/2T":
                                obj1.Add(new SelectListItem { Value = "1100" });
                                obj1.Add(new SelectListItem { Value = "1400" });
                                obj1.Add(new SelectListItem { Value = "1650" });
                                obj1.Add(new SelectListItem { Value = "1505" });
                                obj1.Add(new SelectListItem { Value = "800" });
                                obj1.Add(new SelectListItem { Value = "2000" });
                                obj1.Add(new SelectListItem { Value = "800" });
                                obj1.Add(new SelectListItem { Value = "2000" });
                                break;
                        }
                    }

                    else
                    {

                        switch (Model)
                        {

                            case "EVO-1C/2T":
                                obj1.Add(new SelectListItem { Value = "1100" });
                                obj1.Add(new SelectListItem { Value = "1400" });
                                obj1.Add(new SelectListItem { Value = "1720" });
                                obj1.Add(new SelectListItem { Value = "1780" });
                                obj1.Add(new SelectListItem { Value = "900" });
                                obj1.Add(new SelectListItem { Value = "2000" });
                                obj1.Add(new SelectListItem { Value = "N/A" });
                                obj1.Add(new SelectListItem { Value = "N/A" });
                                break;



                            case "EVO-2P/2T":
                                obj1.Add(new SelectListItem { Value = "1100" });
                                obj1.Add(new SelectListItem { Value = "1400" });

                                /*
                                 * Change 246: added first if block for shaft = Tower
                                 */
                                if (Shaft == "Tower")
                                {
                                    obj1.Add(new SelectListItem { Value = "1720" });
                                    obj1.Add(new SelectListItem { Value = "1890" });
                                }
                                else
                                {
                                    obj1.Add(new SelectListItem { Value = "1630" });
                                    obj1.Add(new SelectListItem { Value = "1640" });
                               
                                }
                                obj1.Add(new SelectListItem { Value = "900" });                                
                                obj1.Add(new SelectListItem { Value = "2000" });
                                obj1.Add(new SelectListItem { Value = "900" });
                                obj1.Add(new SelectListItem { Value = "2000" });
                                break;

                            case "EVO-2A/2T":
                                /*
                                 * Change 247: added first if block for shaft = Tower and
                                 * changed the whole dimensions
                                 */
                                if (Shaft == "Tower")
                                {
                                    obj1.Add(new SelectListItem { Value = "1200" });
                                    obj1.Add(new SelectListItem { Value = "1200" });
                                    obj1.Add(new SelectListItem { Value = "1750" });
                                    obj1.Add(new SelectListItem { Value = "1665" });
                                    obj1.Add(new SelectListItem { Value = "800" });
                                    obj1.Add(new SelectListItem { Value = "2000" });
                                    obj1.Add(new SelectListItem { Value = "800" });
                                    obj1.Add(new SelectListItem { Value = "2000" });
                                    break;
                                }
                                else
                                {
                                    obj1.Add(new SelectListItem { Value = "1100" });
                                    obj1.Add(new SelectListItem { Value = "1400" });
                                    obj1.Add(new SelectListItem { Value = "1590" });
                                    obj1.Add(new SelectListItem { Value = "1750" });
                                    obj1.Add(new SelectListItem { Value = "900" });
                                    obj1.Add(new SelectListItem { Value = "2000" });
                                    obj1.Add(new SelectListItem { Value = "900" });
                                    obj1.Add(new SelectListItem { Value = "2000" });
                                    break;
                                }
                        }

                    }
                    return Json(obj1, JsonRequestBehavior.AllowGet);

                case "Domus Spirit":
                    List<SelectListItem> obj4 = new List<SelectListItem>();

                    if (Shaft == "Masonry")
                    {
                        switch (Model)
                        {

                            case "RS-1C/4":
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "1300" });
                                obj4.Add(new SelectListItem { Value = "1320" });
                                obj4.Add(new SelectListItem { Value = "1400" });
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "2000" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                break;



                            case "RS-2P/4":
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "1300" });
                                obj4.Add(new SelectListItem { Value = "1320" });
                                obj4.Add(new SelectListItem { Value = "1380" });
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "2000" });
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "2000" });
                                break;

                            case "RS-Special":
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                break;
                        }
                    }

                    else
                    {

                        switch (Model)
                        {

                            case "RS-1C/4":
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "1300" });
                                obj4.Add(new SelectListItem { Value = "1492" });
                                obj4.Add(new SelectListItem { Value = "1512" });
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "2000" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                break;



                            case "RS-2P/4":
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "1300" });
                                obj4.Add(new SelectListItem { Value = "1492" });
                                obj4.Add(new SelectListItem { Value = "1502" });
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "2000" });
                                obj4.Add(new SelectListItem { Value = "950" });
                                obj4.Add(new SelectListItem { Value = "2000" });
                                break;

                            case "RS-Special":
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                obj4.Add(new SelectListItem { Value = "N/A" });
                                break;
                        }

                    }
                    return Json(obj4, JsonRequestBehavior.AllowGet);

                case "DomusXL":
                    List<SelectListItem> obj2 = new List<SelectListItem>();
                    if (Shaft == "Masonry")
                    {
                        switch (Model)
                        {

                            case "1C/XL":
                                obj2.Add(new SelectListItem { Value = "1100" });
                                obj2.Add(new SelectListItem { Value = "1400" });
                                obj2.Add(new SelectListItem { Value = "1500" });
                                obj2.Add(new SelectListItem { Value = "1550" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                obj2.Add(new SelectListItem { Value = "N/A" });
                                obj2.Add(new SelectListItem { Value = "N/A" });
                                break;



                            case "2P/XL":
                                obj2.Add(new SelectListItem { Value = "1100" });
                                obj2.Add(new SelectListItem { Value = "1400" });
                                obj2.Add(new SelectListItem { Value = "1500" });
                                obj2.Add(new SelectListItem { Value = "1520" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                break;

                            case "2A/XL":
                                obj2.Add(new SelectListItem { Value = "1100" });
                                obj2.Add(new SelectListItem { Value = "1400" });
                                obj2.Add(new SelectListItem { Value = "1410" });
                                obj2.Add(new SelectListItem { Value = "1580" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                break;
                        }
                    }

                    else
                    {

                        switch (Model)
                        {

                            case "1C/XL":
                                obj2.Add(new SelectListItem { Value = "1100" });
                                obj2.Add(new SelectListItem { Value = "1400" });
                                obj2.Add(new SelectListItem { Value = "1630" });
                                obj2.Add(new SelectListItem { Value = "1660" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                obj2.Add(new SelectListItem { Value = "N/A" });
                                obj2.Add(new SelectListItem { Value = "N/A" });
                                break;



                            case "2P/XL":
                                obj2.Add(new SelectListItem { Value = "1100" });
                                obj2.Add(new SelectListItem { Value = "1400" });
                                obj2.Add(new SelectListItem { Value = "1630" });
                                obj2.Add(new SelectListItem { Value = "1640" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                break;

                            case "2A/XL":
                                obj2.Add(new SelectListItem { Value = "1100" });
                                obj2.Add(new SelectListItem { Value = "1400" });
                                obj2.Add(new SelectListItem { Value = "1590" });
                                obj2.Add(new SelectListItem { Value = "1750" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                obj2.Add(new SelectListItem { Value = "900" });
                                obj2.Add(new SelectListItem { Value = "2000" });
                                break;
                        }
                    }

                    //  List<SelectListItem> obj1 = new List<SelectListItem>();


                    //obj1.Add(new SelectListItem { Value = "720 mm W x 360 mm D x 1500 mm H", Text = "720 mm W x 360 mm D x 1500 mm H" });

                    // ViewBag.MainCategoryid = obj;
                    return Json(obj2, JsonRequestBehavior.AllowGet);

                case "DomusXL Spirit":
                    List<SelectListItem> obj5 = new List<SelectListItem>();

                    if (Shaft == "Masonry")
                    {
                        switch (Model)
                        {

                            case "RS-1C/XL":
                                obj5.Add(new SelectListItem { Value = "1100" });
                                obj5.Add(new SelectListItem { Value = "1400" });
                                obj5.Add(new SelectListItem { Value = "1500" });
                                obj5.Add(new SelectListItem { Value = "1550" });
                                obj5.Add(new SelectListItem { Value = "900" });
                                obj5.Add(new SelectListItem { Value = "2000" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                break;



                            case "RS-2P/XL":
                                obj5.Add(new SelectListItem { Value = "1100" });
                                obj5.Add(new SelectListItem { Value = "1400" });
                                obj5.Add(new SelectListItem { Value = "1500" });
                                obj5.Add(new SelectListItem { Value = "1520" });
                                obj5.Add(new SelectListItem { Value = "900" });
                                obj5.Add(new SelectListItem { Value = "2000" });
                                obj5.Add(new SelectListItem { Value = "900" });
                                obj5.Add(new SelectListItem { Value = "2000" });
                                break;

                            case "RS-2A/XL":
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                break;
                        }
                    }

                    else
                    {

                        switch (Model)
                        {

                            case "RS-1C/XL":
                                obj5.Add(new SelectListItem { Value = "1100" });
                                obj5.Add(new SelectListItem { Value = "1400" });
                                obj5.Add(new SelectListItem { Value = "1630" });
                                obj5.Add(new SelectListItem { Value = "1660" });
                                obj5.Add(new SelectListItem { Value = "900" });
                                obj5.Add(new SelectListItem { Value = "2000" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                break;



                            case "RS-2P/XL":
                                obj5.Add(new SelectListItem { Value = "1100" });
                                obj5.Add(new SelectListItem { Value = "1400" });
                                obj5.Add(new SelectListItem { Value = "1630" });
                                obj5.Add(new SelectListItem { Value = "1640" });
                                obj5.Add(new SelectListItem { Value = "900" });
                                obj5.Add(new SelectListItem { Value = "2000" });
                                obj5.Add(new SelectListItem { Value = "900" });
                                obj5.Add(new SelectListItem { Value = "2000" });
                                break;

                            case "RS-2A/XL":
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                obj5.Add(new SelectListItem { Value = "N/A" });
                                break;
                        }

                    }
                    return Json(obj5, JsonRequestBehavior.AllowGet);

                default:
                    List<SelectListItem> obj3 = new List<SelectListItem>();


                    obj3.Add(new SelectListItem { Value = "12" });
                    obj3.Add(new SelectListItem { Value = "13" });
                    obj3.Add(new SelectListItem { Value = "14" });
                    // ViewBag.MainCategoryid = obj;
                    return Json(obj3, JsonRequestBehavior.AllowGet);
                //return Json(obj1, JsonRequestBehavior.AllowGet); ;

                //}
            }
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
