using Postal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KarenProject.Models
{
    public class NewCommentEmail : Email
    {
        public string To { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; }
        public int quoteID { get; set; }
        public string filename { get; set; }

        public Boolean Quote { get; set; }
        public Boolean brochure { get; set; }
        public Boolean SampleDrawings { get; set; }
        public Boolean LadderBracketDrawings { get; set; }
    
    }

    public class MailModel
    {

        public MailModel()
        { 
        }

        public int mainquiteId { get; set; }
        public MailModel(int quoteid)
        {
            this.quoteID = quoteid;
            MainQuote lvgquote = (new quoteDb()).MainQuote.Find(quoteID);
            this.mainquiteId = lvgquote.Section1ModelId;
            section1Model sec1model = (new quoteDb()).section1Model.Find(lvgquote.Section1ModelId);
            switch (sec1model.SalesPerson)
            {
                case "Craig Schmidt":
                    {
                        from = "craig@easy-living.com.au";
                        break;
                    }
                case "David Mayer":
                    {
                        from = "david.mayer@easy-living.com.au";
                        break;
                    }
                case "David Smith":
                    {
                        from = "david.smith@easy-living.com.au";
                        break;
                    }
                case "Kevin Bunting":
                    {
                        from = "kevin.bunting@easy-living.com.au";
                        break;
                    }
                case "Michael Heltborg":
                    {
                        from = "michaelh@easy-living.com.au";
                        break;
                    }

                case "Dijana Vojvodic":
                    {
                        from = "dijanav@easy-living.com.au";
                        break;
                    }

                case "Robert Pizzie":
                    {
                        from = "robert@easy-living.com.au";
                        break;
                    }

                case "Paul Solotwa":
                    {
                        from = "paul.solotwa@easy-living.com.au";
                        break;
                    }
            }
            this.To = sec1model.Email;
//            this.cc = "gajendra_dessai@hotmail.com";
            this.bcc = "paige.gray@easy-living.com.au";
            this.BccAdd = new List<string>();
            this.BccAdd.Add("paige.gray@easy-living.com.au");

//            this.subject = "Lift Quote"+lvgquote.LiftType + " " + lvgquote.id + " " + sec1model.ProjectName;
           this.subject = "Lift Quote P"+sec1model.id +"-"+quoteid+": "+lvgquote.LiftType+" at "+sec1model.ProjectName;// + " " + lvgquote.id + " " + sec1model.ProjectName;

            this.Comment = "Dear "+sec1model.ContactName+",\n\n"+ "We are pleased to attach our tender offer for Lift Services at "+sec1model.ProjectName+".  We have provided the following documentation for your review,\n\n"+ "1. Easy Living  Home Elevator Tender Offer\n"+
                "2. "+lvgquote.LiftType+" Elevator Brochure\n"+ 
                "3. Preliminary Sketch ";
            this.Quote = true;
            this.brochure = true;
            this.SampleDrawings = true;
        }

        public string from { get; set; }
        public string To { get; set; }
        [DataType(DataType.EmailAddress)]
        public IList<string> ToAdd { get; set; }
        public IList<string> BccAdd { get; set; }

        public string Comment { get; set; }
        public int quoteID { get; set; }

        public string cc { get; set; }
        public string bcc { get; set; }
        public string subject { get; set; }
        public string body { get; set; }

        public string filename { get; set; }

        public Boolean Quote { get; set; }
        public Boolean brochure { get; set; }
        public Boolean SampleDrawings { get; set; }
        public Boolean LadderBracketDrawings { get; set; }
//        public MainQuote lvgquote { get; set; }
//        public section1Model sec1model { get; set; }




        //public void attachDomusLift1(MainQuote lVGquote, MailMessage email)
        //{
        //    {
        //        if (lVGquote.LiftType == "DomusLift")
        //        {

        //            //if load bearing wall if left
        //            if (lVGquote.LoadBearingWall == "Left")
        //            {
        //                switch (lVGquote.LiftModel)
        //                {
        //                    case "1c/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 4 M SX (1000x1300) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/1":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 1 M DX (800x800 car size) .pdf"))); // to be updated 
        //                            break;
        //                        }
        //                    case "1c/2":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 2 M SX (800x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/3":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 3 M DX (800x1300) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/5":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 5 M DX (1000x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/6":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 6 M SX (1000x800 car size).pdf")));
        //                            break;
        //                        }
        //                    case "1c/7":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 7 M SX (800x1200 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2P/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 4 M SX (1000x1300 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2P/1":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 1 M SX (800X800 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2P/2":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 2 M SX (800x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/3":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 3 M SX (800x1300 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/5":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 5 M SX (1000x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/6":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 6 M SX (1000x800 Car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/7":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 7 M SX (800x1200 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2A/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 4 M SX (1000x1300 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2A/1":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 1 M SX (800x800 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2A/2":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 2 M SX (800x1000 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2A/3":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 3 M DX (800x1300 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2A/5":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 5 M SX (1000x1000 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2A/6":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 6 M SX (1000x800 car size) .pdf")));
        //                            break;
        //                        }
        //                }

        //            }



        //            if (lVGquote.LoadBearingWall == "Right")
        //            {
        //                switch (lVGquote.LiftModel)
        //                {
        //                    case "1c/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 4 M DX (1000x1300) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/1":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 1 M DX (800x800 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/2":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 2 M DX (800x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/3":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 3 M DX (800x1300) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/5":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 5 M DX (1000x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1c/6":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 6 M SX (1000x800 car size).pdf")));
        //                            break;
        //                        }
        //                    case "1c/7":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1C\\DL-1C 7 M DX (800x1200 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2P/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 4 M DX (1000x1300 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/1":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 1 M DX (800x800 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2P/2":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 2 M DX (800X1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/3":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 3 M  DX (800x1300 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/5":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 5 M DX (1000x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/6":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 6 M DX (1000x800 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2P/7":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2P\\DL-2P 7 M DX (800x1200 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2A/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 4 M DX (1000x1300 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2A/1":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 1 M DX (800x800 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2A/2":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 2 M DX (800x1000).pdf")));
        //                            break;
        //                        }
        //                    case "2A/3":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 3 M DX (800x1300 car size).pdf")));
        //                            break;
        //                        }
        //                    case "2A/5":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 5 M DX (1000x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "2A/6":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-2A\\DL-2A 6 M DX (1000x800 car size).pdf")));
        //                            break;
        //                        }
        //                }
        //            }

        //            if (lVGquote.LoadBearingWall != "Right" & lVGquote.LoadBearingWall != "Left")
        //            {
        //                switch (lVGquote.LiftModel)
        //                {
        //                    case "1L/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 4 M (1000x1300 car size).pdf")));
        //                            break;
        //                        }
        //                    case "1L/1":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 1 M  (800x800mm car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1L/2":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 2 M (1000x800 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1L/3":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 3 M (1300x800 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1L/5":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 5 M (1000x1000 car size) .pdf")));
        //                            break;
        //                        }
        //                    case "1L/6":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Masonry\\DL-1L\\DL-1L 6 M (800x1000 car size) .pdf")));
        //                            break;
        //                        }

        //                }
        //            }
        //        }

        //    }
        //}

        //public void attachDomusXL1(MainQuote lVGquote, MailMessage email)
        //{
        //    if (lVGquote.LoadBearingWall == "Left")
        //    {
        //        switch (lVGquote.LiftModel)
        //        {
        //            case "1C/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Drawings\\Domus XL\\Masonry\\DL-1C XL M SX (900mm LH Door Hinge) 1100x1400mm.pdf")));
        //                    break;
        //                }
        //            case "2P/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2P XL M SX RHH (1100x1400mm car size).pdf")));
        //                    break;
        //                }
        //            case "2A/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2A XL M Variations.pdf")));
        //                    break;
        //                }
        //        }
        //    }
        //    if (lVGquote.LoadBearingWall == "Right")
        //    {
        //        switch (lVGquote.LiftModel)
        //        {
        //            case "1C/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-1C XL M DX RHH (1100x1400mm Car size).pdf")));
        //                    break;
        //                }
        //            case "2P/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2P XL M SX RHH (1100x1400mm car size).pdf")));
        //                    break;
        //                }
        //            case "2A/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Masonry\\DL-2A XL M Variations.pdf")));
        //                    break;
        //                }

        //        }
        //    }
        //}

        //public void attachFiles1(MailMessage email, MailModel data, MainQuote lVGquote)
        //{

        //    if (data.Quote)
        //    {
        //        email.Attachments.Add(new Attachment(data.filename));

        //    }


        //    // check if  brochure is ticked in 
        //    if (data.brochure)
        //    {
        //        // check lift types copy this code for other type of lifts
        //        if (lVGquote.LiftType == "DomusLift")
        //        {
        //            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusLift Brochure-Easy Living Home Elevators.pdf")));
        //        }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));

        //        {
        //            // check lift types copy this code for other type of lifts
        //            if (lVGquote.LiftType == "DomusXL")
        //            {
        //                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusLift Brochure-Easy Living Home Elevators.pdf")));
        //            }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));
        //        }

        //        {
        //            // check lift types copy this code for other type of lifts
        //            if (lVGquote.LiftType == "Domus Evolution")
        //            {
        //                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\DomusEvolution - Easy Living Home Elevators.pdf")));
        //            }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));
        //        }
        //        {
        //            // check lift types copy this code for other type of lifts
        //            if (lVGquote.LiftType == "Domus Spirit" || lVGquote.LiftType == "DomusXL Spirit")
        //            {
        //                email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Brochure\\The Domus Spirit Low Res.pdf")));
        //            }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));
        //        }

        //    }

        //    if (data.LadderBracketDrawings)
        //    {
        //        // check lift types copy this code for other type of lifts
        //        if (lVGquote.LiftType == "DomusLift")
        //        {
        //            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus Steel Layout.pdf")));
        //        }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));


        //        // check lift types copy this code for other type of lifts
        //        if (lVGquote.LiftType == "DomusXL")
        //        {
        //            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL Steel Layout.pdf")));
        //        }// email.Attachments.Add(new Attachment("C:\\DreamerQuotes\\dd1.txt"));

        //        // check lift types copy this code for other type of lifts
        //        if (lVGquote.LiftType == "Domus Evolution")
        //        {
        //            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL - Evolution Steel Layout.pdf")));
        //        }

        //        if (lVGquote.LiftType == "Domus Spirit")
        //        {
        //            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus Steel Layout.pdf")));
        //        }

        //        if (lVGquote.LiftType == "DomusXL Spirit")
        //        {
        //            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Steel Layout\\Domus XL Steel Layout.pdf")));
        //        }
        //    }




        //    ///////////////////////////

        //    if (data.SampleDrawings)
        //    {   // if shaft type is masonry
        //        if (lVGquote.ShaftType == "Masonry")
        //        {
        //            // if lift type is DomusLift
        //            if (lVGquote.LiftType == "DomusLift")
        //            {
        //                attachDomusLift(lVGquote, email);
        //            }
        //            // if lift type is Domusxl
        //            if (lVGquote.LiftType == "DomusXL")
        //            {
        //                attachDomusXL(lVGquote, email);
        //                //if load bearing wall if left
        //            }
        //            if (lVGquote.LiftType == "DomusEvolution")
        //            {
        //                switch (lVGquote.LiftModel)
        //                {
        //                    case "EVO-1C/2T":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\EVO7-1C-2T M (1100x1400mm car size).pdf")));
        //                            break;
        //                        }

        //                    case "EVO-2P/2T":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\EVO7-2P-2T M (1100x1400mm car size) .pdf")));
        //                            break;
        //                        }
        //                    case "EVO-2A/2T":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Masonry\\Domus Evo M adjacent entry - 1100 x1400.pdf")));
        //                            break;
        //                        }
        //                }
        //            }

        //            if (lVGquote.LiftType == "DomusSpirit")
        //            {
        //                switch (lVGquote.LiftModel)
        //                {
        //                    case "RS-1C/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C M.pdf")));
        //                            break;
        //                        }
        //                    case "RS-2P/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf"))); //to be updated
        //                            break;
        //                        }
        //                    case "RS-2A/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); //to be updated
        //                            break;
        //                        }
        //                }
        //            }
        //            if (lVGquote.LiftType == "DomusXL Spirit")
        //            {
        //                switch (lVGquote.LiftModel)
        //                {
        //                    case "RS-1C/XL":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T M .pdf")));
        //                            break;
        //                        }
        //                    case "RS-2P/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf"))); //to be updated
        //                            break;
        //                        }
        //                    case "RS-2A/4":
        //                        {

        //                            email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); //to be updated
        //                            break;
        //                        }

        //                }
        //            }

        //        }            // if shaft type is not masonary
        //        else
        //        {
        //            nonMasonaryAttach(lVGquote, email);

        //        }

        //    }
        //}

        //public void nonMasonaryAttach1(MainQuote lVGquote, MailMessage email)
        //{
        //    if (lVGquote.LiftType == "DomusLift")
        //    {

        //        //if load bearing wall if left
        //        if (lVGquote.LoadBearingWall == "Left")
        //        {
        //            switch (lVGquote.LiftModel)
        //            {
        //                case "1c/4":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 4 T SX (1000x1300 car size).pdf")));
        //                        break;
        //                    }
        //                case "1c/1":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 1 T SX (800X800 car size).pdf")));
        //                        break;
        //                    }
        //                case "1c/2":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 2 T SX (800x1000 car size).pdf")));
        //                        break;
        //                    }
        //                case "1c/3":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 3 T DX (800x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1c/5":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 5 T SX (1000x1000mm car size).pdf")));
        //                        break;
        //                    }
        //                case "1c/6":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 6 T SX (1000x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1c/7":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T SX (800x1200mm car size).pdf")));
        //                        break;
        //                    }
        //                case "2P/4":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 4 T SX (1000x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/1":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 1 T SX (800x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/2":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 2 T SX (800x1000 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/3":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 3 T SX (800x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/5":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 5 T SX (1000x1000 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/6":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 6 T DX (1000x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/7":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 7 T SX (800x1200 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/4":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 4 T SX (1000x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/1":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 1 T SX (800x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/2":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 2 T SX (800x1000 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/3":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 3 T SX (800x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/5":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 5 T SX (1000x1000 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/6":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 6 T SX (1000x800 car size).pdf")));
        //                        break;
        //                    }
        //            }

        //        }
        //        if (lVGquote.LoadBearingWall == "Right")
        //        {
        //            switch (lVGquote.LiftModel)
        //            {

        //                case "1c/4":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 4 T SX (1000x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1c/1":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 1 T SX (800X800 car size).pdf")));
        //                        break;
        //                    }
        //                case "1c/2":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 2 T SX (800x1000 car size).pdf")));
        //                        break;
        //                    }
        //                case "1c/3":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 3 T DX (800x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1c/5":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 5 T DX (1000x1000 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1c/6":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 6 T DX (1000x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1c/7":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1C\\DL-1C 7 T DX (800x1200 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/4":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 4 T DX (1000x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/1":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 1 T DX (800x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/2":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 2 T DX (800x1000 car size).pdf")));
        //                        break;
        //                    }
        //                case "2P/3":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 3 T DX (800x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/5":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 5 T DX (1000x1000 car size).pdf")));
        //                        break;
        //                    }
        //                case "2P/6":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 6 M DX (1000x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2P/7":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2P\\DL-2P 7 T DX (800x1200 car size).pdf")));
        //                        break;
        //                    }
        //                case "2A/4":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 4 T DX (1000x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/1":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 1 T DX (800x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/2":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 2 T DX (800x1000 car size) ")));
        //                        break;
        //                    }
        //                case "2A/3":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 3 T DX (800x1300 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/5":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 5 T DX (1000x1000 car size) .pdf")));
        //                        break;
        //                    }
        //                case "2A/6":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-2A\\DL-2A 6 T SX (1000x800 car size).pdf")));
        //                        break;
        //                    }
        //            }
        //        }

        //        if (lVGquote.LoadBearingWall != "Left" & lVGquote.LoadBearingWall != "Right")
        //        {
        //            // IF LOAD BEARING WALL IS REAR 
        //            switch (lVGquote.LiftModel)
        //            {
        //                case "1L/4":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 4A DX (1300x1000 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1L/1":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 1A (800x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1L/2":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 2A (1000x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1L/3":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 3A DX (1300x800 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1L/5":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L T 5A (1000x1000 car size) .pdf")));
        //                        break;
        //                    }
        //                case "1L/6":
        //                    {

        //                        email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\DomusLift\\Tower\\DL-1L\\DL-1L 6 M (800x1000 car size) .pdf")));
        //                        break;
        //                    }


        //            }
        //        }
        //    }

        //    // if lift type is Domusxl
        //    if (lVGquote.LiftType == "DomusXL")
        //    {

        //        switch (lVGquote.LiftModel)
        //        {
        //            case "1C/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-1C XL DX LHH (1100x1400 car size).pdf")));
        //                    break;
        //                }
        //            case "2P/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-2P XL SX Doors hinged on rail side.pdf")));
        //                    break;
        //                }
        //            case "2A/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus XL\\Tower\\DL-2A XL Variations.pdf")));
        //                    break;
        //                }
        //        }
        //    }

        //    if (lVGquote.LiftType == "DomusEvolution")
        //    {
        //        switch (lVGquote.LiftModel)
        //        {
        //            case "EVO-1C/2T":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\EVO7-1C-2T (1100x1400mm car size).pdf")));
        //                    break;
        //                }
        //            case "EVO-2P/2T":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\EVO7-2P-2T (1100x1400mm car size).pdf")));
        //                    break;
        //                }
        //            case "EVO-2A/2T":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Evolution\\Tower\\"))); // drawing to be updated
        //                    break;
        //                }
        //        }
        //    }

        //    if (lVGquote.LiftType == "DomusSpirit")
        //    {
        //        switch (lVGquote.LiftModel)
        //        {
        //            case "RS-1C/4":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf")));
        //                    break;
        //                }
        //            case "RS-2P/4":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf"))); //to be updated
        //                    break;
        //                }
        //            case "RS-2A/4":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); //to be updated
        //                    break;
        //                }
        //        }
        //    }

        //    if (lVGquote.LiftType == "DomusXL Spirit")
        //    {
        //        switch (lVGquote.LiftModel)
        //        {
        //            case "RS-1C/XL":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); // to be fixed
        //                    break;
        //                }
        //            case "RS-2P/4":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset sample drawing- 1C T .pdf"))); //to be updated
        //                    break;
        //                }
        //            case "RS-2A/4":
        //                {

        //                    email.Attachments.Add(new Attachment(System.Web.HttpContext.Current.Server.MapPath("~\\Content\\Drawings\\Domus Spirit\\Domus Reset XL sample drawing- 1C T .pdf"))); //to be updated
        //                    break;
        //                }

        //        }


        //    }
        //}

    }


}