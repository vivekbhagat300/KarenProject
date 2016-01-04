using KarenProject.Models;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System.Linq;
using System;
using System.Net.Mail;
using System.Xml.XPath;
using System.Collections.Generic;


using System.Data;
using System.Data.Entity;
using System.Web;


namespace PdfSample
{
    public class PdfGenerator
    {
        public Document document = new Document();
        static TextFrame addressFrame;
        static Table table;
        private quoteDb db = new quoteDb();

        public PdfDocument CreatePdf(MainQuote lVGquote)
        {

            DefineStyles();
            CreatePage(lVGquote);
            FillContent();
            return RenderDocument(document);
        }

        public void DefineStyles()
        {

            Style style = document.Styles["Normal"];
            style.Font.Name = "calibri";
            style.Font.Size = 11;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("5cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.Font.Name = "Calibri";
            style.Font.Size = 9;
            style.ParagraphFormat.AddTabStop("10cm", TabAlignment.Center);

            style = document.Styles.AddStyle("Table", "Normal");
            style.Font.Name = "calibri";
            style.Font.Size = 10;

            style = document.Styles.AddStyle("Table2", "Normal");
            style.Font.Name = "calibri";
            style.Font.Size = 11;

            style = document.Styles.AddStyle("Table3", "Normal");
            style.Font.Name = "calibri";
            style.Font.Size = 10;

            style = document.Styles.AddStyle("Reference", "Normal");
            style.ParagraphFormat.SpaceBefore = "5mm";
            style.ParagraphFormat.SpaceAfter = "5mm";
            style.ParagraphFormat.TabStops.AddTabStop("2cm", TabAlignment.Right);

            document.DefaultPageSetup.RightMargin = 18;
            document.DefaultPageSetup.LeftMargin = 20;
            document.DefaultPageSetup.TopMargin = 18;
        }

        public void CreatePage(MainQuote lVGquote)
        {

            var model =
           (from r in db.section1Model
            where r.id == lVGquote.Section1ModelId
            select r).SingleOrDefault();


            Section section = document.AddSection();



            // --------------------------PAGE 1----------------------------------------------------             
            // masnory domuslift
            //Image image; 
            if (lVGquote.ShaftType == "Masonry")
            {
                if (lVGquote.LiftType == "DomusLift")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\DomusLift Masonry Shaft Header .jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
                else if (lVGquote.LiftType == "DomusXL")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\DomusLift Masonry Shaft Header .jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
                else if (lVGquote.LiftType == "Domus Evolution")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\Domus Evolution Masonry Tender Header.jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
                else if (lVGquote.LiftType == "Domus Spirit")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\Domus Spirit Tender Template .jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
                else if (lVGquote.LiftType == "DomusXL Spirit")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\Domus Spirit Tender Template .jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
            }
            else
            {
                if (lVGquote.LiftType == "DomusLift")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\DomusLift Glass Tower - Tender Header.jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
                else if (lVGquote.LiftType == "DomusXL")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\DomusLift Glass Tower - Tender Header.jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
                else if (lVGquote.LiftType == "Domus Evolution")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\Domus Evolution Glass Tower - Tender Header.jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
                else if (lVGquote.LiftType == "Domus Spirit")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\Domus Spirit Tender Template .jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
                else if (lVGquote.LiftType == "DomusXL Spirit")
                {
                    Image image = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\Logo\\Domus Spirit Tender Template .jpg"));
                    image.Height = "6.6cm";
                    image.LockAspectRatio = true;
                    image.RelativeVertical = RelativeVertical.Line;
                    image.RelativeHorizontal = RelativeHorizontal.Margin;
                    image.Top = ShapePosition.Top;
                    image.Left = ShapePosition.Center;
                    image.WrapFormat.Style = WrapStyle.Through;
                }
            }




            // Create footer
            Paragraph paragraph = section.Footers.Primary.AddParagraph();
            Paragraph paragraph1 = section.Footers.Primary.AddParagraph();
            //            Paragraph paragraph2 = section.Footers.Primary.AddParagraph();


            paragraph.Format.Alignment = ParagraphAlignment.Right;
            paragraph.AddFormattedText("Page no  : ", TextFormat.Bold);
            paragraph.AddPageField();
            paragraph.AddText("  ");
            paragraph.AddFormattedText("Initial: _________", TextFormat.Bold);
            paragraph.AddLineBreak();

            paragraph1.AddFormattedText("Project Name: ", TextFormat.Bold);
            paragraph1.AddText(model.ProjectName);
            //            paragraph1.AddLineBreak();
            paragraph1.AddFormattedText("  Quote No: ", TextFormat.Bold);
            paragraph1.AddText("P" + model.id + "-" + lVGquote.id);
            paragraph1.AddLineBreak();
            paragraph1.AddText("Copyright © 2010 Easy Living Home Elevators Pty Limited - Commercial in Confidence   V270315");
            paragraph1.Format.Font.Size = 9;
            paragraph1.Format.Alignment = ParagraphAlignment.Center;
            paragraph1.AddLineBreak();


            if (model.Branch == "NSW")
            {


                addressFrame = section.AddTextFrame();
                addressFrame.Height = "2.0cm";
                addressFrame.Width = "9.5cm";
                addressFrame.Left = ShapePosition.Right;
                addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;


                addressFrame.Top = "5.5cm";
                addressFrame.RelativeVertical = RelativeVertical.Page;


                paragraph = addressFrame.AddParagraph("Easy Living Home Elevators Pty Limited  ABN: 82 083 936 896 ");
                paragraph.Format.Font.Size = 10;
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph = addressFrame.AddParagraph("64 Penshurst St,Willoughby NSW 2068");
                paragraph.Format.Font.Size = 10;
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph = addressFrame.AddParagraph("Phone 02 8116 1500 / Fax 02 8116 1511");
                paragraph.Format.Font.Size = 10;
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph = addressFrame.AddParagraph("www.easy-living.com.au");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Name = "Calibri";
                paragraph.Format.Font.Size = 10;
                paragraph.Format.SpaceAfter = 15;



            }
            else if (model.Branch == "VIC")
            {


                addressFrame = section.AddTextFrame();
                addressFrame.Height = "2.0cm";
                addressFrame.Width = "10.0cm";
                addressFrame.Left = ShapePosition.Right;
                addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
                addressFrame.Top = "5.5cm";
                addressFrame.RelativeVertical = RelativeVertical.Page;


                paragraph = addressFrame.AddParagraph("Easy Living Home Elevators (VIC) Pty Limited ABN: 91 136 701 865");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("7 Hoddle St,Collingwood VIC 3066");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("Phone 03 9094 8600 / Fax 03 9094 8611");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("www.easy-living.com.au");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph.Format.SpaceAfter = 0;


                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0cm";

            }
            else if (model.Branch == "QLD")
            {

                addressFrame = section.AddTextFrame();
                addressFrame.Height = "2.0cm";
                addressFrame.Width = "10.0cm";
                addressFrame.Left = ShapePosition.Right;
                addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
                addressFrame.Top = "5.5cm";
                addressFrame.RelativeVertical = RelativeVertical.Page;

                paragraph = addressFrame.AddParagraph("Easy Living Home Elevators (QLD) Pty Limited ABN: 85 136 701 838");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("17 Campbell Street, BOWEN HILLS QLD 4006");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("Phone 07 3851 7500 / Fax 07 3851 7511");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("www.easy-living.com.au");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph.Format.SpaceAfter = 0;



                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0cm";

            }
            else
            {


                addressFrame = section.AddTextFrame();
                addressFrame.Height = "2.0cm";
                addressFrame.Width = "10.0cm";
                addressFrame.Left = ShapePosition.Right;
                addressFrame.RelativeHorizontal = RelativeHorizontal.Margin;
                addressFrame.Top = "5.5cm";
                addressFrame.RelativeVertical = RelativeVertical.Page;

                paragraph = addressFrame.AddParagraph("Easy Living Home Elevators (WA) Pty Limited  ABN: 15 142 482 451");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("Unit 6/ 347-351 Great Eastern Hwy,REDCLIFFE WA 6104");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("Phone 08 9322 4688 / Fax  08 9322 4655");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Size = 9.5;
                paragraph = addressFrame.AddParagraph("www.easy-living.com.au");
                paragraph.Format.Alignment = ParagraphAlignment.Right;
                paragraph.Format.Font.Name = "Calibri";
                paragraph.Format.Font.Size = 9.5;
                paragraph.Format.SpaceAfter = 0;


                paragraph = section.AddParagraph();
                paragraph.Format.SpaceBefore = "0cm";

            }
            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph("");
            paragraph = section.AddParagraph("");
            paragraph.Format.SpaceBefore = "7cm";

            paragraph.AddText("DATE : ");
            paragraph.AddDateField("dd.MM.yyyy");
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.Format.SpaceAfter = 6;

            paragraph.Format.SpaceBefore = "7cm";
            paragraph = section.AddParagraph(model.ContactName);
            if (model.Company != null)
            {
                paragraph = section.AddParagraph(model.Company);
            }
            if (model.ContactAdress != null)
            {
                paragraph = section.AddParagraph(model.ContactAdress);

                paragraph = section.AddParagraph(model.ContactSuburb + ", " + model.ContactState + ", " + model.ContactPostCode);
            }
            paragraph.Format.SpaceAfter = 9;
            string LiftCodeComplence = "";
            if (lVGquote.CodeComplence == "Part 15")
            {
                LiftCodeComplence = "AS1735.15  Limited Mobility Lift";
            }

            else if (lVGquote.CodeComplence == "Part 18")
            {
                LiftCodeComplence = "AS1735.18  Private Residential Lift";

            }
            else
            {
                LiftCodeComplence = "AS1735.16  Limited Mobility Lift";


            }
            paragraph = section.AddParagraph(LiftCodeComplence);
            paragraph.Format.Font.Bold = true;


            if (lVGquote.ShaftType == "Tower")
            {
                paragraph = section.AddParagraph("The One and Only " + lVGquote.LiftType + " in shaft structure");
            }
            else
            {
                paragraph = section.AddParagraph("The one and Only " + lVGquote.LiftType);

            } paragraph.Format.Font.Bold = true;

            string Slogan = "";
            if (lVGquote.LiftType == "DomusLift")
            {
                Slogan = "The most bought home elevator in Australia";
            }
            else if (lVGquote.LiftType == "DomusXL")
            {
                Slogan = "The big cousin of Australia’s most popular home lift";

            }
            else if (lVGquote.LiftType == "Domus Evolution")
            {
                Slogan = "The next generation";

            }
            else if (lVGquote.LiftType == "Domus Spirit")
            {
                Slogan = "Exceptional value for money";

            }
            else
            {
                Slogan = "The more powerful DomusXL Spirit Lift, designed for optimum performance";

            }
            paragraph = section.AddParagraph(Slogan);
            paragraph.Format.Font.Bold = true;




            paragraph = section.AddParagraph();
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("At Project Name: " + model.ProjectName, TextFormat.Bold);


            paragraph = section.AddParagraph();
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Order dated ______ / ______ / _______ is set out below");
            paragraph.Format.SpaceAfter = 8;

            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("AUSTRALIA’S #1 IN HOME ELEVATORS");
            paragraph.Format.Font.Bold = true;
            string answer = model.ProjectType == "Commercial" ? "project" : "home";
            paragraph = section.AddParagraph("Welcoming luxury and convenience into your " + answer + " has never been so simple. Easy Living Home Elevators not only improve the value of your " + answer + ", but can also boost your quality of life");
            paragraph = section.AddParagraph("We’re specialists who’ve been leading the way in Australia for the last 16 years and are unchallenged across flexibility, quality, service and value");


            paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "0cm";
            paragraph.Style = "Reference";
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("#1 FOR FLEXIBILITY", TextFormat.Bold);
            paragraph.AddLineBreak();
            paragraph.AddText("The ability to custom design your lift to specific requirements, allows our lifts to fit perfectly into your home and not the other way around.");
            Image image3 = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\logo\\Made In Italy.jpg"));
            image3.Height = "2cm";
            image3.Width = "3cm";
            image3.LockAspectRatio = true;
            image3.RelativeVertical = RelativeVertical.Line;
            image3.RelativeHorizontal = RelativeHorizontal.Margin;
            image3.Left = ShapePosition.Right;
            image3.WrapFormat.Style = WrapStyle.Through;
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("#1 FOR QUALITY");
            paragraph.Format.Font.Bold = true;
            paragraph = section.AddParagraph("Our 100% European Quality Promise is coupled with the fact that Easy Living Home Elevators are the exclusive trusted suppliers of the DomusLift brand.");
            paragraph.Format.RightIndent = "4cm";
            paragraph = section.AddParagraph("Amazing Statistic: 27,500 DomusLifts are sold in over 40 countries worldwide and growing! You can be assured of the quality, reliability and back-up.");
            paragraph.Format.RightIndent = "4cm";
            paragraph.Format.SpaceAfter = 8;
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("#1 FOR SERVICE");
            paragraph.Format.Font.Bold = true;
            Image image2 = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\logo\\Quality-ISO-9001-PMS302.gif")); //C:\Users\karen.mendes\Downloads\KarenProject\KarenProject\Content\Logo\Quality-ISO-9001-PMS302.gif
            image2.Height = "2cm";

            //image2.Width = "1cm";
            image2.LockAspectRatio = true;

            image2.RelativeVertical = RelativeVertical.Line;
            image2.RelativeHorizontal = RelativeHorizontal.Margin;
            image2.Left = ShapePosition.Right;
            image2.WrapFormat.Style = WrapStyle.Through;

            paragraph = section.AddParagraph("Easy Living Home Elevators has integrated with Google maps so you can see the popularity of our lifts in your area and know exactly where your service is coming from.");
            paragraph.Format.RightIndent = "3cm";

            paragraph = section.AddParagraph("We’re the clear #1 supplier of home elevators in Australia with 7,500+ in our maintenance system, which is over x3 our nearest competitor.");
            paragraph.Format.RightIndent = "3cm";

            paragraph = section.AddParagraph("");


            paragraph.AddLineBreak();

            // --------------------------PAGE 2----------------------------------------------------     

            document.LastSection.AddPageBreak();
            paragraph = section.AddParagraph("#1 FOR VALUE");
            paragraph.Format.Font.Bold = true;
            paragraph = section.AddParagraph("We’re Australia’s largest home elevator company that’s still privately owned so we pass the savings on to you." +
                "Easy Living Home Elevators is the only specialist Home Elevator Company that holds certification to ISO9001," + "with internationally recognised processes in place to ensure you receive the lift you want……on time!");
            paragraph = section.AddParagraph();
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("SAFE AND SECURE");
            paragraph.Format.Font.Bold = true;
            paragraph = section.AddParagraph("The " + lVGquote.LiftType + " range has been developed with the paramount objective of providing users with the highest possible level of safety ensuring peace of mind.");
            paragraph = section.AddParagraph("- Ten (10) year parts availability guarantee");
            paragraph.Format.LeftIndent = "0.2cm";
            paragraph = section.AddParagraph("- In the event of mains power failure, the lift will return to the lowest floor with all safety features in place and unlock the door to allow passengers to exit");
            paragraph.Format.LeftIndent = "0.2cm";
            paragraph = section.AddParagraph("- 24/7 Call centre assistance: Every lift installed has access to our 24-hour call centre.");
            paragraph.Format.LeftIndent = "0.2cm";
            paragraph = section.AddParagraph("- Other safety features include: Emergency lighting, Emergency Alarm Button, over speed sensing safety gear, Electrical and Mechanical interlocks.");
            paragraph.Format.LeftIndent = "0.2cm";

            paragraph = section.AddParagraph();
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Our standard safety features that others consider optional extras are what make the " + lVGquote.LiftType + " different from any other elevators.", TextFormat.Bold); //2.4 lift type in the text before different
            Image image1 = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\logo\\Easy Living Home Elevators showrooms.jpg"));
            image1.Height = "8cm";
            image1.Width = "8cm";
            image1.LockAspectRatio = true;
            image1.RelativeVertical = RelativeVertical.Line;
            image1.RelativeHorizontal = RelativeHorizontal.Margin;
            image1.Left = ShapePosition.Right;
            image1.WrapFormat.Style = WrapStyle.Through;
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("WORKING LIFTS ON DISPLAY IN EVERY MAJOR CAPITAL CITY.");
            paragraph.Format.Font.Bold = true;
            paragraph = section.AddParagraph("We have world-class showrooms with flexible hours so we’re there when you need us.");
            paragraph.Format.RightIndent = "8.5cm";
            paragraph = section.AddParagraph("Our operational elevators are not simply put on display rather; they take centre stage, ready to transport you to the next level at the push of a button, demonstrating the latest technological advances, whisper quiet performance, style, innovation and durability.");
            paragraph.Format.RightIndent = "8.5cm";
            paragraph = section.AddParagraph("You are not just another number to us, as a valued client your lift is “Designed to Impress” to reflect your individual needs and taste. Your lift is about you, your life and your expectations.");


            paragraph.Format.RightIndent = "8.5cm";
            paragraph.Format.SpaceAfter = "2cm";
            paragraph = section.AddParagraph("Best Regards,");
            paragraph.Format.SpaceAfter = "2cm";
            paragraph.AddLineBreak();




            // Sales Person email   // GAJ TO DO 
            paragraph = section.AddParagraph(model.SalesPerson);
            switch (model.SalesPerson)
            {
                case "Craig Schmidt":
                    {
                        paragraph = section.AddParagraph("craig@easy-living.com.au");
                        break;
                    }
                case "David Mayer":
                    {
                        paragraph = section.AddParagraph("david.mayer@easy-living.com.au");

                        break;
                    }
                case "David Smith":
                    {
                        paragraph = section.AddParagraph("david.smith@easy-living.com.au");
                        break;
                    }
                case "Kevin Bunting":
                    {
                        paragraph = section.AddParagraph("kevin.bunting@easy-living.com.au");
                        break;
                    }
                case "Michael Heltborg":
                    {
                        paragraph = section.AddParagraph("michaelh@easy-living.com.au");
                        break;
                    }

                case "Dijana Vojvodic":
                    {
                        paragraph = section.AddParagraph("dijanav@easy-living.com.au");
                        break;
                    }

                case "Robert Pizzie":
                    {
                        paragraph = section.AddParagraph("robert@easy-living.com.au");
                        break;
                    }

                case "Paul Solotwa":
                    {
                        paragraph = section.AddParagraph("paul.solotwa@easy-living.com.au");
                        break;
                    }
                case "Mike Booth":
                    {
                        paragraph = section.AddParagraph(" mike.booth@easy-living.com.au");
                        break;
                    }
            }
            // paragraph = section.AddParagraph("Email - ");

            paragraph = section.AddParagraph("Easy Living Home Elevators");
            document.LastSection.AddPageBreak();

            // --------------------------PAGE 3----------------------------------------------------  

            paragraph = section.AddParagraph(lVGquote.LiftType + " SPECIFICATIONS (refer to " + lVGquote.LiftType + " brochure)");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 13;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;


            table = section.AddTable();
            table.Style = "Table";
            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;



            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph("GENERAL SPECIFICATION");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 13;
            paragraph.Format.SpaceAfter = 5;

            table = section.AddTable();
            table.Style = "Table2";
            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;



            Column column = table.AddColumn("9cm");
            column.Format.Alignment = ParagraphAlignment.Center;

            column = table.AddColumn("9cm");
            column.Format.Alignment = ParagraphAlignment.Right;

            Row row = table.AddRow();
            row.Format.Alignment = ParagraphAlignment.Center;
            row.Cells[0].AddParagraph("Lift Code Compliance:");
            row.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            row.Cells[1].AddParagraph(LiftCodeComplence);
            if (lVGquote.Part12 == true)
            {
                row.Cells[1].AddParagraph("AS1735.12 - Facilities for persons with Disabilities");
            }
            row.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row1 = table.AddRow();
            row1.Format.Alignment = ParagraphAlignment.Center;
            row1.Cells[0].AddParagraph("No. of Lifts:");
            row1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row1.Cells[1].AddParagraph(lVGquote.NoOfLifts.ToString());
            row1.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row2 = table.AddRow();
            row2.Format.Alignment = ParagraphAlignment.Center;
            row2.Cells[0].AddParagraph("Shaft Type:");
            row2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            if (lVGquote.ShaftType == "Masonry")
            {
                row2.Cells[1].AddParagraph("Enclosed by client");
            }
            else if (lVGquote.ShaftType == "Tower")
            {
                row2.Cells[1].AddParagraph("Shaft structure");
            }
            else
            {
                row2.Cells[1].AddParagraph("Partial structure");
            }
            row2.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row3 = table.AddRow();
            row3.Format.Alignment = ParagraphAlignment.Center;
            row3.Cells[0].AddParagraph("Lift Model:");
            row3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row3.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row3.Cells[1].AddParagraph(lVGquote.LiftModel);
            row3.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row4 = table.AddRow();
            row4.Format.Alignment = ParagraphAlignment.Center;
            paragraph = row4.Cells[0].AddParagraph();
            paragraph.AddText("Load Bearing Wall ");
            FormattedText formattedText5 = paragraph.AddFormattedText(" (as viewed from  landing):", TextFormat.Italic);
            formattedText5.Size = 9;
            row4.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row4.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            paragraph = row4.Cells[1].AddParagraph();
            paragraph.AddText(lVGquote.LoadBearingWall + " hand side");
            FormattedText formattedText7 = paragraph.AddFormattedText(" - refer to works by others section 3", TextFormat.Italic);
            formattedText7.Size = 9;
            row4.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row5 = table.AddRow();
            row5.Format.Alignment = ParagraphAlignment.Center;
            row5.Cells[0].AddParagraph("No. of Floors:");
            row5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row5.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row5.Cells[1].AddParagraph(lVGquote.NoOfFloors.ToString());
            row5.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row6 = table.AddRow();
            row6.Format.Alignment = ParagraphAlignment.Center;
            row6.Cells[0].AddParagraph("Entrance Type: ");
            row6.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row6.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row6.Cells[1].AddParagraph(lVGquote.EntranceType);
            row6.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row7 = table.AddRow();
            row7.Format.Alignment = ParagraphAlignment.Center;
            row7.Cells[0].AddParagraph("Capacity:");
            row7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row7.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row7.Cells[1].AddParagraph(lVGquote.Capacity == null ? "" : (lVGquote.Capacity.EndsWith(" Kg") ? lVGquote.Capacity : (lVGquote.Capacity + " Kg")));
            row7.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row8 = table.AddRow();
            row8.Format.Alignment = ParagraphAlignment.Center;
            paragraph = row8.Cells[0].AddParagraph();
            paragraph.AddText("Speed ");
            FormattedText formattedText4 = paragraph.AddFormattedText(" (maximum) without lift car door:", TextFormat.Italic);
            formattedText4.Size = 9;
            row8.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row8.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row8.Cells[1].AddParagraph(lVGquote.Speed + "m/s");
            row8.Cells[1].Format.Alignment = ParagraphAlignment.Left;


            Row row9 = table.AddRow();
            row9.Format.Alignment = ParagraphAlignment.Center;
            row9.Cells[0].AddParagraph("Drive System:");
            row9.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row9.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            if (lVGquote.LiftType == "Domus Spirit" || lVGquote.LiftType == "DomusXL Spirit")
            {
                row9.Cells[1].AddParagraph("Direct Acting " + lVGquote.DriveSystem);
            }
            else
            {
                row9.Cells[1].AddParagraph("Roped Oil-" + lVGquote.DriveSystem + ", metal sheave");


            } row9.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row10 = table.AddRow();
            row10.Format.Alignment = ParagraphAlignment.Center;
            row10.Cells[0].AddParagraph("Power Supply:");
            row10.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row10.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row10.Cells[1].AddParagraph(lVGquote.Power);
            row10.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row11 = table.AddRow();
            row11.Format.Alignment = ParagraphAlignment.Center;
            row11.Cells[0].AddParagraph("Control Cabinet Size:");
            row11.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row11.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            row11.Cells[1].AddParagraph(lVGquote.ConCabSize);
            row11.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row row12 = table.AddRow();
            row12.Format.Alignment = ParagraphAlignment.Center;
            paragraph = row12.Cells[0].AddParagraph();
            paragraph.AddText("Control Cabinet Location: ");
            FormattedText formattedText3 = paragraph.AddFormattedText(" (Distance from Shaft)", TextFormat.Italic);
            formattedText3.Size = 9;
            row12.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            row12.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            row12.Cells[1].AddParagraph("Vertical Distance: " + lVGquote.ConCabLocVer + " mm");
            row12.Cells[1].AddParagraph("Horizontal Distance: " + lVGquote.ConCabLocHor + " mm");
            row12.Cells[1].Format.Alignment = ParagraphAlignment.Left;


            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph("DIMENSIONS");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 13;
            paragraph.Format.SpaceAfter = 5;


            table = section.AddTable();
            table.Style = "Table2";
            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;



            Column columndim = table.AddColumn("9cm");
            columndim.Format.Alignment = ParagraphAlignment.Center;

            columndim = table.AddColumn("9cm");
            columndim.Format.Alignment = ParagraphAlignment.Right;

            Row rowdim = table.AddRow();
            rowdim.Format.Alignment = ParagraphAlignment.Center;
            rowdim.Cells[0].AddParagraph("Internal Car Size:");
            rowdim.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowdim.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowdim.Cells[1].AddParagraph(lVGquote.IntCarSizeWide + " mm W x " + lVGquote.IntCarSizeDeep + " mm D x " + lVGquote.CarHeight + " mm H");
            rowdim.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowdim1 = table.AddRow();
            rowdim1.Format.Alignment = ParagraphAlignment.Center;
            if (lVGquote.FrontEntLanDoor == "Swing doors")
            {
                rowdim1.Cells[0].AddParagraph("Shaft Size: ").AddFormattedText("(Alternate door hinging will affect shaft size)", TextFormat.Italic).Size = 9;
            }
            else
            {
                rowdim1.Cells[0].AddParagraph("Shaft Size: "); ;
            }
            //           FormattedText note = new FormattedText("(Alternate door hinging will affect shaft size)");

            rowdim1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowdim1.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowdim1.Cells[1].AddParagraph(lVGquote.ShaftSizeWide + " mm W x " + lVGquote.ShaftSizeDeep + " mm D");
            rowdim1.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowdim2 = table.AddRow();
            paragraph = rowdim2.Cells[0].AddParagraph("Door Size:");
            paragraph.AddTab();
            paragraph.AddText("Front Entrance:");
            paragraph.Format.ClearAll();
            paragraph.Format.AddTabStop("8.7cm", TabAlignment.Right);
            rowdim2.Cells[1].AddParagraph(lVGquote.Door1SizeWide + " mm W x " + lVGquote.Doo1SizeDeep + " mm H");
            rowdim2.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            ////            rowdim2.Cells[0].AddParagraph("Front Entrance:");
            ////            rowdim2.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            ////            rowdim2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

            //            Row rowdim4 = table.AddRow();
            //            rowdim4.Format.Alignment = ParagraphAlignment.Center;
            //            rowdim4.Cells[0].AddParagraph("Front Entrance:");
            //            rowdim4.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            //            rowdim4.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            //            rowdim4.Cells[1].AddParagraph(lVGquote.Door1SizeWide + " mm W x " + lVGquote.Doo1SizeDeep + " mm H");
            //            rowdim4.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            if (lVGquote.EntranceType != "Front entrance")
            {
                Row rowdim5 = table.AddRow();
                rowdim5.Format.Alignment = ParagraphAlignment.Center;
                rowdim5.Cells[0].AddParagraph("Second Entrance:");
                rowdim5.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                rowdim5.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                rowdim5.Cells[1].AddParagraph(lVGquote.Door2SizeWide + " mm W x " + lVGquote.Door2SizeDeep + " mm H");
                rowdim5.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }

            Row rowdim6 = table.AddRow();
            rowdim6.Format.Alignment = ParagraphAlignment.Center;
            paragraph = rowdim6.Cells[0].AddParagraph();
            paragraph.AddText("Headroom ");
            FormattedText formattedText2 = paragraph.AddFormattedText(" (minimum) from finished floor level:", TextFormat.Italic);
            formattedText2.Size = 9;
            rowdim6.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowdim6.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowdim6.Cells[1].AddParagraph(lVGquote.Headroom + " mm");
            rowdim6.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowdim7 = table.AddRow();
            rowdim7.Format.Alignment = ParagraphAlignment.Center;
            paragraph = rowdim7.Cells[0].AddParagraph();
            paragraph.AddText("Pit Depth");
            rowdim7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowdim7.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowdim7.Cells[1].AddParagraph(lVGquote.Pit + " mm");
            rowdim7.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowdim8 = table.AddRow();
            rowdim8.Format.Alignment = ParagraphAlignment.Center;
            paragraph = rowdim8.Cells[0].AddParagraph();
            paragraph.AddText("Travel Height");


            FormattedText formattedText = paragraph.AddFormattedText(" ( " + (lVGquote.CodeComplence == "Part 15" ? "4,000" : "12,000") + " mm maximum travel):", TextFormat.Italic);
            formattedText.Size = 9;
            rowdim8.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowdim8.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowdim8.Cells[1].AddParagraph(lVGquote.Travel + " mm");
            rowdim8.Cells[1].Format.Alignment = ParagraphAlignment.Left;


            Row rowdim10 = table.AddRow();
            rowdim10.Format.Alignment = ParagraphAlignment.Center;
            paragraph = rowdim10.Cells[0].AddParagraph();
            paragraph.AddText("Floor to floor distance");
            FormattedText formattedText6 = paragraph.AddFormattedText(" (From FFL’s)", TextFormat.Italic);
            formattedText6.Size = 9;
            rowdim10.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowdim10.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowdim10.Cells[1].AddParagraph("Between floor travel is now confirmed at:");

            for (var i = 0; i < lVGquote.NoOfFloors - 1; i++)
            {

                if (i == 0)
                {
                    rowdim10.Cells[1].AddParagraph(lVGquote.FtoFStart1 + " to " + lVGquote.FtoFFinish1 + "  " + lVGquote.FtoFDistance1 + " mm");

                }
                if (i == 1)
                {
                    rowdim10.Cells[1].AddParagraph(lVGquote.FtoFStart2 + " to " + lVGquote.FtoFFinish2 + "  " + lVGquote.FtoFDistance2 + " mm");

                }
                if (i == 2)
                {
                    rowdim10.Cells[1].AddParagraph(lVGquote.FtoFStart3 + " to " + lVGquote.FtoFFinish3 + "  " + lVGquote.FtoFDistance3 + " mm");

                }
                if (i == 3)
                {
                    rowdim10.Cells[1].AddParagraph(lVGquote.FtoFStart4 + " to " + lVGquote.FtoFFinish4 + "  " + lVGquote.FtoFDistance4 + " mm");


                }

            }
            rowdim10.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            paragraph = section.AddParagraph("");

            if (lVGquote.ExtraNotes != null)
            {
                paragraph = section.AddParagraph("Notes:");  // Link it to the Note section in the form - GAJ TO DO 
                paragraph = section.AddParagraph(lVGquote.ExtraNotes);
                paragraph = section.AddParagraph("_________________________________________________________________________________");
                paragraph = section.AddParagraph("_________________________________________________________________________________");
                paragraph = section.AddParagraph("_________________________________________________________________________________");
                paragraph = section.AddParagraph("_________________________________________________________________________________");
                // --------------------------PAGE 4---------------------------------------------------- 
            }
            else
            {
                paragraph = section.AddParagraph("Notes:");  // Link it to the Note section in the form - GAJ TO DO 
                paragraph = section.AddParagraph("_________________________________________________________________________________");
                paragraph = section.AddParagraph("_________________________________________________________________________________");
                paragraph = section.AddParagraph("_________________________________________________________________________________");
                paragraph = section.AddParagraph("_________________________________________________________________________________");
                // --------------------------PAGE 4----------------------------------------------------
            }
            document.LastSection.AddPageBreak();

            paragraph = section.AddParagraph(lVGquote.LiftType + " FINISHES (refer to " + lVGquote.LiftType + " brochure)");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 13;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;


            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph("CAR FINISHES");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 13;
            paragraph.Format.SpaceAfter = 5;

            table = section.AddTable();
            table.Style = "Table2";
            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;




            Column columncar = table.AddColumn("7cm");
            columncar.Format.Alignment = ParagraphAlignment.Center;

            columncar = table.AddColumn("12cm");
            columncar.Format.Alignment = ParagraphAlignment.Right;

            Row rowcar = table.AddRow();
            rowcar.Format.Alignment = ParagraphAlignment.Center;
            rowcar.Cells[0].AddParagraph("Car Walls:");
            rowcar.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowcar.Cells[1].AddParagraph("As viewed from the landing facing your lift car");
            rowcar.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            if (lVGquote.EntranceType == "Front entrance" || lVGquote.EntranceType == "Front & Rear entrance" || lVGquote.EntranceType == "Front & Adjacent – Right")
            {
                Row rowcar1 = table.AddRow();
                rowcar1.Format.Alignment = ParagraphAlignment.Center;
                rowcar1.Cells[0].AddParagraph("Left Hand Side Wall:");
                rowcar1.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                rowcar1.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                rowcar1.Cells[1].AddParagraph(lVGquote.CarWallsLHS);
                rowcar1.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            }
            if (lVGquote.EntranceType == "Front entrance" || lVGquote.EntranceType == "Front & Rear entrance" || lVGquote.EntranceType == "Front & Adjacent – Left")
            {
                Row rowcar3 = table.AddRow();
                rowcar3.Format.Alignment = ParagraphAlignment.Center;
                rowcar3.Cells[0].AddParagraph("Right Hand Side Wall:");
                rowcar3.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                rowcar3.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                rowcar3.Cells[1].AddParagraph(lVGquote.CarWallsRHS);
                rowcar3.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }

            if (lVGquote.EntranceType == "Front entrance" || lVGquote.EntranceType == "Front & Adjacent – Left" || lVGquote.EntranceType == "Front & Adjacent – Right")
            {
                Row rowcar33 = table.AddRow();
                rowcar33.Format.Alignment = ParagraphAlignment.Center;
                rowcar33.Cells[0].AddParagraph("Rear Wall:");
                rowcar33.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                rowcar33.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                rowcar33.Cells[1].AddParagraph(lVGquote.CarWallsRear);
                rowcar33.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }


            Row rowcar4 = table.AddRow();
            rowcar4.Format.Alignment = ParagraphAlignment.Center;
            rowcar4.Cells[0].AddParagraph("Ceiling");
            rowcar4.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar4.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowcar4.Cells[1].AddParagraph(lVGquote.Ceiling);
            rowcar4.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowcar5 = table.AddRow();
            rowcar5.Format.Alignment = ParagraphAlignment.Center;
            rowcar5.Cells[0].AddParagraph("Flooring");
            rowcar5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar5.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowcar5.Cells[1].AddParagraph(lVGquote.Floor);
            rowcar5.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowcar6 = table.AddRow();
            rowcar6.Format.Alignment = ParagraphAlignment.Center;
            rowcar6.Cells[0].AddParagraph("Profiles");
            rowcar6.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar6.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowcar6.Cells[1].AddParagraph(lVGquote.Profile);
            rowcar6.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            //string copLoc = "";
            //if (lVGquote.CopLocLHS == true)
            //{
            //    copLoc = " - Located on: Left Wall";
            //}
            //if (lVGquote.CopLocRHS == true)
            //{
            //    copLoc = " - Located on: Right Wall";
            //}
            //if (lVGquote.CopLocRear == true)
            //{
            //    copLoc = " - Located on: Rear Wall";
            //}


            Row rowcar8 = table.AddRow();
            rowcar8.Format.Alignment = ParagraphAlignment.Center;
            rowcar8.Cells[0].AddParagraph("Control Operating Panel:");
            rowcar8.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar8.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            if (lVGquote.Part12 == true)
            {
                rowcar8.Cells[1].AddParagraph("2 X " + lVGquote.CopType + " located on: " + lVGquote.LoadBearingWall + " Wall");
                rowcar8.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }
            else
            {
                rowcar8.Cells[1].AddParagraph(lVGquote.CopType + " located on: " + lVGquote.LoadBearingWall + " Wall");
                rowcar8.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }




            Row rowcar10 = table.AddRow();
            rowcar10.Format.Alignment = ParagraphAlignment.Center;
            rowcar10.Cells[0].AddParagraph("Buttons:");
            rowcar10.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar10.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            if (lVGquote.CodeComplence == "Part 15")
            {
                rowcar10.Cells[1].AddParagraph(lVGquote.CopButton + " - constant pressure");
                rowcar10.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }
            else
            {
                rowcar10.Cells[1].AddParagraph(lVGquote.CopButton);
                rowcar10.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }

            string HandLoc = "";
            if (lVGquote.HandRailLocRHS == true)
            {
                HandLoc = " Located on: Right Wall";
            }
            if (lVGquote.HandRailLocLHS == true)
            {
                HandLoc = " Located on: Left Wall";
            }
            if (lVGquote.HandRailLocRear == true)
            {
                HandLoc = " Located on: Rear Wall";
            }

            Row rowcar21 = table.AddRow();
            rowcar21.Format.Alignment = ParagraphAlignment.Center;
            rowcar21.Cells[0].AddParagraph("Handrail:");
            rowcar21.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar21.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowcar21.Cells[1].AddParagraph(lVGquote.HandRailType + HandLoc);
            rowcar21.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowcar13 = table.AddRow();
            rowcar13.Format.Alignment = ParagraphAlignment.Center;
            rowcar13.Cells[0].AddParagraph("Car Telephone:");
            rowcar13.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar13.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowcar13.Cells[1].AddParagraph(lVGquote.Phone + " Located on guide wall side");
            rowcar13.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            if (lVGquote.MirrorType != "No Mirror")
            {
                string MirrorLoc = "";
                if (lVGquote.MirrorLocLHS == true)
                {
                    MirrorLoc = " Located on: Left Wall";
                }
                if (lVGquote.MirrorLocRHS == true)
                {
                    MirrorLoc = " Located on: Right Wall";
                }
                if (lVGquote.MirrorLocRear == true)
                {
                    MirrorLoc = " Located on: Rear Wall";
                }
                Row rowcar12 = table.AddRow();
                rowcar12.Format.Alignment = ParagraphAlignment.Center;
                rowcar12.Cells[0].AddParagraph("Mirror:");
                rowcar12.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowcar12.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                rowcar12.Cells[1].AddParagraph(lVGquote.MirrorType + MirrorLoc);
                rowcar12.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }
            if (lVGquote.CarDisplayType != "No Display")
            {

                Row rowcar15 = table.AddRow();
                rowcar15.Format.Alignment = ParagraphAlignment.Center;
                rowcar15.Cells[0].AddParagraph("Car Display Type:");
                rowcar15.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowcar15.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                rowcar15.Cells[1].AddParagraph(lVGquote.CarDisplayType);
                rowcar15.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            }
            /*
                        if (lVGquote.CarDisplayTypeLoc != "No Display")
                        {
                            Row rowcar16 = table.AddRow();
                            rowcar16.Format.Alignment = ParagraphAlignment.Center;
                            rowcar16.Cells[0].AddParagraph("Landing Display Type:");
                            rowcar16.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                            rowcar16.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                            rowcar16.Cells[1].AddParagraph(lVGquote.CarDisplayTypeLoc);
                            if (lVGquote.AllLevels)
                            {
                                Row rowcar16_1 = table.AddRow();
                                rowcar16_1.Format.Alignment = ParagraphAlignment.Center;
                                rowcar16_1.Cells[0].AddParagraph("Landing Display Type:");
                                rowcar16_1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                                rowcar16_1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

                                rowcar16_1.Cells[1].AddParagraph("All Levels");
                            }
                            else
                            {
                                Row rowcar16_1 = table.AddRow();
                                rowcar16_1.Format.Alignment = ParagraphAlignment.Center;
                                rowcar16_1.Cells[0].AddParagraph("Landing Display Type:");
                                rowcar16_1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                                rowcar16_1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;

                                if (lVGquote.Level1)
                                { rowcar16_1.Cells[1].AddParagraph("Level 1"); }
                                if (lVGquote.Level2)
                                { rowcar16_1.Cells[1].AddParagraph("Level 2"); }
                                if (lVGquote.Level3)
                                { rowcar16_1.Cells[1].AddParagraph("Level 3"); }
                                if (lVGquote.Level4)
                                { rowcar16_1.Cells[1].AddParagraph("Level 4"); }
                            }
            
                            rowcar16.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                        }*/


            if (lVGquote.CarDisplayTypeLoc != "No Display")
            {
                Row rowcar16_2 = table.AddRow();
                rowcar16_2.Format.Alignment = ParagraphAlignment.Center;
                rowcar16_2.Cells[0].AddParagraph("Landing Display Type:");
                rowcar16_2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowcar16_2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                rowcar16_2.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                rowcar16_2.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;



                string located = "Located on: ";
                if (lVGquote.AllLevels)
                {
                    located += "All Levels";

                }
                else
                {
                    if (lVGquote.Level1)
                    {
                        located += lVGquote.FtoFStart1;
                    }
                    if (lVGquote.Level2)
                    {
                        located += (" & " + lVGquote.FtoFFinish1);

                    }
                    if (lVGquote.Level3)
                    {
                        located += (" & " + lVGquote.FtoFFinish2);
                    }
                    if (lVGquote.Level4)
                    {
                        located += (" & " + lVGquote.FtoFFinish3);
                    }
                    if (lVGquote.Level5)
                    {
                        located += (" & " + lVGquote.FtoFFinish4);
                    }
                }

                rowcar16_2.Cells[1].AddParagraph(lVGquote.CarDisplayTypeLoc + " " + located);
            }
            /*
            Row rowcar16_3 = table.AddRow();
            rowcar16_3.Format.Alignment = ParagraphAlignment.Center;
            rowcar16_3.Cells[0].AddParagraph("Located on:");
            rowcar16_3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar16_3.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowcar16_3.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            rowcar16_3.Cells[1].VerticalAlignment = VerticalAlignment.Bottom;
            if (lVGquote.AllLevels)
            {
                rowcar16_3.Cells[1].AddParagraph("All Levels");

            }
            else
            {
                if (lVGquote.Level1)
                { rowcar16_3.Cells[1].AddParagraph("Level 1"); }
                if (lVGquote.Level2)
                { rowcar16_3.Cells[1].AddParagraph("Level 2"); }
                if (lVGquote.Level3)
                { rowcar16_3.Cells[1].AddParagraph("Level 3"); }
                if (lVGquote.Level4)
                { rowcar16_3.Cells[1].AddParagraph("Level 4"); }
            }

            */

            Row rowcar17 = table.AddRow();
            rowcar17.Format.Alignment = ParagraphAlignment.Center;
            rowcar17.Cells[0].AddParagraph("Car safety protection:");
            rowcar17.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowcar17.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowcar17.Cells[1].AddParagraph(lVGquote.CarSafteyProtection);
            rowcar17.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            if (lVGquote.CarKeySwitch == true &
            lVGquote.LandingKeySwitch == true &
            lVGquote.Gong == true &
            lVGquote.VoiceSynt == true &
            lVGquote.RemoteControl == true &
            lVGquote.ShaftComRalPaint == true &
            lVGquote.MirrorStrip == true &
           lVGquote.NoOfStrips != null)
            {
                Row rowcar19 = table.AddRow();
                rowcar19.Format.Alignment = ParagraphAlignment.Center;
                rowcar19.Cells[0].AddParagraph("Extras Included:");
                rowcar19.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowcar19.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                rowcar19.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                if (lVGquote.CarKeySwitch == true)
                {
                    rowcar19.Cells[1].AddParagraph("Car Key Switch");
                }
                if (lVGquote.LandingKeySwitch == true)
                {
                    rowcar19.Cells[1].AddParagraph("Landing Key Switch");
                }
                if (lVGquote.Gong == true)
                {
                    rowcar19.Cells[1].AddParagraph("Gong");
                }
                if (lVGquote.VoiceSynt == true)
                {
                    rowcar19.Cells[1].AddParagraph("Voice Synthesiser");
                }
                if (lVGquote.RemoteControl == true)
                {
                    rowcar19.Cells[1].AddParagraph("Remote Control");
                }
                if (lVGquote.ShaftComRalPaint == true)
                {
                    rowcar19.Cells[1].AddParagraph("Shaft Component RAL Paint");
                    rowcar19.Cells[1].AddParagraph(lVGquote.ShaftComRalPaintText);
                    rowcar19.Cells[1].AddParagraph(lVGquote.ShaftComRalPaintInt.ToString());

                }
                if (lVGquote.MirrorStrip == true)
                {
                    rowcar19.Cells[1].AddParagraph("Mirror st/st Strip ");
                }
                if (lVGquote.NoOfStrips != null)
                {
                    rowcar19.Cells[1].AddParagraph(lVGquote.NoOfStrips.ToString());
                }
            }
            paragraph = section.AddParagraph("");




            paragraph = section.AddParagraph("DOOR FINISHES");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 13;
            paragraph.Format.SpaceAfter = 5;

            table = section.AddTable();
            table.Style = "Table2";
            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;




            Column doorcar = table.AddColumn("7cm");
            doorcar.Format.Alignment = ParagraphAlignment.Center;

            doorcar = table.AddColumn("12cm");
            doorcar.Format.Alignment = ParagraphAlignment.Right;

            Row rowdoor = table.AddRow();
            rowdoor.Format.Alignment = ParagraphAlignment.Center;
            rowdoor.Cells[0].AddParagraph("Door Operation:");
            //rowdoor.Cells[0].Format.Font.size = 11;
            rowdoor.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowdoor.Cells[0].VerticalAlignment = VerticalAlignment.Top;

            if (lVGquote.FrontEntLanDoor == "Swing doors")
            {
                rowdoor.Cells[1].AddParagraph(lVGquote.FrontEntLanDoor);
            }
            else
            {
                rowdoor.Cells[1].AddParagraph("2 Speed automatic side opening");
                Row rowdoor4 = table.AddRow();
                rowdoor4.Format.Alignment = ParagraphAlignment.Center;
                rowdoor4.Cells[0].AddParagraph("Car Door Finish:   \tFront Entrance:");
                rowdoor4.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowdoor4.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                rowdoor4.Cells[1].AddParagraph(lVGquote.FrontEntCarDoorFinish);
                rowdoor4.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                if (lVGquote.EntranceType != "Front entrance")
                {
                    if (lVGquote.SecondEntCarDoorFinish != "N/A")
                    {
                        Row rowdoor5 = table.AddRow();
                        rowdoor5.Format.Alignment = ParagraphAlignment.Center;
                        rowdoor5.Cells[0].AddParagraph("Second Entrance:");
                        rowdoor5.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                        rowdoor5.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                        rowdoor5.Cells[1].AddParagraph(lVGquote.SecondEntCarDoorFinish);
                        rowdoor5.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                    }

                }
            }
            rowdoor.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            //Row rowdoor6 = table.AddRow();
            //rowdoor6.Format.Alignment = ParagraphAlignment.Center;
            //rowdoor6.Cells[0].AddParagraph("Landing Operating panel");
            //rowdoor6.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            //rowdoor6.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            //  rowdoor6.Cells[1].Format.Font.size = 11;
            //rowdoor6.Cells[1].AddParagraph(lVGquote.LopFinish1 + "  Location:  " + lVGquote.LopLocation1);
            //rowdoor6.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            // rowdoor6.Cells[1].Format.Font.size = 11;

            //Row rowdoor7 = table.AddRow();
            //rowdoor7.Format.Alignment = ParagraphAlignment.Center;
            //rowdoor7.Cells[0].AddParagraph("Landing Buttons");
            //rowdoor7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            //rowdoor7.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            //  rowdoor7.Cells[1].Format.Font.size = 11;
            //rowdoor7.Cells[1].AddParagraph(lVGquote.LopButton1);
            //rowdoor7.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            //rowdoor7.Cells[1].Format.Font.size = 11;

            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph("Landing Doors");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = 5;

            table = section.AddTable();
            table.Style = "Table3";
            table.Borders.Width = 0.25;
            table.Borders.Color = Colors.Gray;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;

            if (lVGquote.FrontEntLanDoor == "Swing doors")
            {

                Column LanDoor = table.AddColumn("1.5cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Center;

                LanDoor = table.AddColumn("2cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Right;

                LanDoor = table.AddColumn("1.5cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Right;
                LanDoor = table.AddColumn("9.5cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Right;
                LanDoor = table.AddColumn("7cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Right;

                Row rowLanDoor = table.AddRow();
                rowLanDoor.Format.Alignment = ParagraphAlignment.Center;
                rowLanDoor.Cells[0].AddParagraph("Levels");
                rowLanDoor.Cells[0].Format.Font.Bold = true;
                rowLanDoor.Cells[0].Format.Font.Size = 9;
                rowLanDoor.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[1].AddParagraph("Entrance Type");
                rowLanDoor.Cells[1].Format.Font.Bold = true;
                rowLanDoor.Cells[1].Format.Font.Size = 9;
                rowLanDoor.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[2].AddParagraph("Door Hinge");
                rowLanDoor.Cells[2].Format.Font.Bold = true;
                rowLanDoor.Cells[2].Format.Font.Size = 9;
                rowLanDoor.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[3].AddParagraph("Door ");
                rowLanDoor.Cells[3].Format.Font.Bold = true;
                rowLanDoor.Cells[3].Format.Font.Size = 9;
                rowLanDoor.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[4].AddParagraph("Landing Operating Panel");
                rowLanDoor.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[4].Format.Font.Bold = true;
                rowLanDoor.Cells[4].Format.Font.Size = 9;

                for (var i = 0; i < lVGquote.NoOfFloors; i++)
                {

                    if (i == 0)
                    {
                        Row rowLanDoor1 = table.AddRow();
                        rowLanDoor1.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor1.Cells[0].AddParagraph(lVGquote.FtoFStart1);
                        rowLanDoor1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        if (lVGquote.DoorEntType1 == "Second entrance")
                        {
                            rowLanDoor1.Cells[1].AddParagraph("Second");
                        }
                        else { rowLanDoor1.Cells[1].AddParagraph("Front"); }
                        rowLanDoor1.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[1].Format.Font.Size = 9;


                        rowLanDoor1.Cells[2].AddParagraph(lVGquote.Hinge1);
                        rowLanDoor1.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor1.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType1);
                        rowLanDoor1.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[3].Format.Font.Size = 9;
                        rowLanDoor1.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish1);
                        rowLanDoor1.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[3].Format.Font.Size = 9;
                        rowLanDoor1.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle1);
                        rowLanDoor1.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[3].Format.Font.Size = 9;

                        rowLanDoor1.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish1);
                        rowLanDoor1.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[4].Format.Font.Size = 9;
                        rowLanDoor1.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton1);
                        rowLanDoor1.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[4].Format.Font.Size = 9;
                        rowLanDoor1.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation1);
                        rowLanDoor1.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[4].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType1 == "Front & Second entrance")
                        {
                            rowLanDoor1.Cells[0].MergeDown = 1;

                            Row rowLanDoor2 = table.AddRow();
                            rowLanDoor2.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor2.Cells[1].AddParagraph("Second");
                            rowLanDoor2.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor2.Cells[2].AddParagraph(lVGquote.Hinge2);
                            rowLanDoor2.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                            //rowLanDoor2.Cells[3].AddParagraph(lVGquote.LDFDoorType2);
                            //rowLanDoor2.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            //rowLanDoor2.Cells[4].AddParagraph(lVGquote.LDFDoorFinish4);
                            //// rowLanDoor2.Cells[4].AddParagraph("LOP" + lVGquote.LopFinish1 + lVGquote.LopLocation1);
                            //rowLanDoor2.Cells[4].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor2.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType2);
                            rowLanDoor2.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[3].Format.Font.Size = 9;
                            rowLanDoor2.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish2);
                            rowLanDoor2.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[3].Format.Font.Size = 9;
                            rowLanDoor2.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle2);
                            rowLanDoor2.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[3].Format.Font.Size = 9;

                            rowLanDoor2.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish2);
                            rowLanDoor2.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[4].Format.Font.Size = 9;
                            rowLanDoor2.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton2);
                            rowLanDoor2.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[4].Format.Font.Size = 9;
                            rowLanDoor2.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation2);
                            rowLanDoor2.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[4].Format.Font.Size = 9;
                        }
                    }
                    if (i == 1)
                    {
                        Row rowLanDoor3 = table.AddRow();
                        rowLanDoor3.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor3.Cells[0].AddParagraph(lVGquote.FtoFStart2); //Link it to the form GAJ TO DO 
                        rowLanDoor3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        if (lVGquote.DoorEntType3 == "Second entrance")
                        {
                            rowLanDoor3.Cells[1].AddParagraph("Second");
                        }
                        else { rowLanDoor3.Cells[1].AddParagraph("Front"); }
                        rowLanDoor3.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor3.Cells[2].AddParagraph(lVGquote.Hinge3);
                        rowLanDoor3.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        //rowLanDoor3.Cells[3].AddParagraph(lVGquote.LDFDoorType3);
                        //rowLanDoor3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        //rowLanDoor3.Cells[4].AddParagraph(lVGquote.LDFDoorFinish3);
                        ////rowLanDoor3.Cells[4].AddParagraph("LOP - " + lVGquote.LopFinish2 + lVGquote.LopLocation2);
                        //rowLanDoor3.Cells[4].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor3.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType3);
                        rowLanDoor3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[3].Format.Font.Size = 9;
                        rowLanDoor3.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish3);
                        rowLanDoor3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[3].Format.Font.Size = 9;
                        rowLanDoor3.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle3);
                        rowLanDoor3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[3].Format.Font.Size = 9;

                        rowLanDoor3.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish3);
                        rowLanDoor3.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[4].Format.Font.Size = 9;
                        rowLanDoor3.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton3);
                        rowLanDoor3.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[4].Format.Font.Size = 9;
                        rowLanDoor3.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation3);
                        rowLanDoor3.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[4].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType3 == "Front & Second entrance")
                        {
                            rowLanDoor3.Cells[0].MergeDown = 1;
                            Row rowLanDoor4 = table.AddRow();
                            rowLanDoor4.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor4.Cells[1].AddParagraph("Second");
                            rowLanDoor4.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                            if (lVGquote.FrontEntLanDoor != "Swing doors")
                            {
                                rowLanDoor4.Cells[2].AddParagraph("N/A");
                                rowLanDoor4.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            }
                            else
                            {
                                rowLanDoor4.Cells[2].AddParagraph(lVGquote.Hinge4);
                                rowLanDoor4.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            }
                            //rowLanDoor4.Cells[3].AddParagraph(lVGquote.LDFDoorType4);
                            //rowLanDoor4.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            //rowLanDoor4.Cells[4].AddParagraph(lVGquote.LDFDoorFinish4);
                            //rowLanDoor4.Cells[4].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor4.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType4);
                            rowLanDoor4.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[3].Format.Font.Size = 9;
                            rowLanDoor4.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish4);
                            rowLanDoor4.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[3].Format.Font.Size = 9;
                            rowLanDoor4.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle4);
                            rowLanDoor4.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[3].Format.Font.Size = 9;

                            rowLanDoor4.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish4);
                            rowLanDoor4.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[4].Format.Font.Size = 9;
                            rowLanDoor4.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton4);
                            rowLanDoor4.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[4].Format.Font.Size = 9;
                            rowLanDoor4.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation4);
                            rowLanDoor4.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[4].Format.Font.Size = 9;
                        }
                    }
                    if (i == 2)
                    {
                        Row rowLanDoor5 = table.AddRow();
                        rowLanDoor5.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor5.Cells[0].AddParagraph(lVGquote.FtoFStart3);
                        rowLanDoor5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        if (lVGquote.DoorEntType5 == "Second entrance")
                        {
                            rowLanDoor5.Cells[1].AddParagraph("Second");
                        }
                        else { rowLanDoor5.Cells[1].AddParagraph("Front"); }
                        rowLanDoor5.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor5.Cells[2].AddParagraph(lVGquote.Hinge5);
                        rowLanDoor5.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor5.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType5);
                        rowLanDoor5.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[3].Format.Font.Size = 9;
                        rowLanDoor5.Cells[3].AddParagraph("Finish: " + lVGquote.LDFFrameFinish5);
                        rowLanDoor5.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[3].Format.Font.Size = 9;
                        rowLanDoor5.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorFinish5);
                        rowLanDoor5.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[3].Format.Font.Size = 9;

                        rowLanDoor5.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish5);
                        rowLanDoor5.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[4].Format.Font.Size = 9;
                        rowLanDoor5.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton5);
                        rowLanDoor5.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[4].Format.Font.Size = 9;
                        rowLanDoor5.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation5);
                        rowLanDoor5.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[4].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType5 == "Front & Second entrance")
                        {
                            rowLanDoor5.Cells[0].MergeDown = 1;
                            Row rowLanDoor6 = table.AddRow();
                            rowLanDoor6.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor6.Cells[1].AddParagraph("Second");
                            rowLanDoor6.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor6.Cells[2].AddParagraph(lVGquote.Hinge6);
                            rowLanDoor6.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor6.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType6);
                            rowLanDoor6.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[3].Format.Font.Size = 9;
                            rowLanDoor6.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish6);
                            rowLanDoor6.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[3].Format.Font.Size = 9;
                            rowLanDoor6.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle6);
                            rowLanDoor6.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[3].Format.Font.Size = 9;

                            rowLanDoor6.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish6);
                            rowLanDoor6.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[4].Format.Font.Size = 9;
                            rowLanDoor6.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton6);
                            rowLanDoor6.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[4].Format.Font.Size = 9;
                            rowLanDoor6.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation6);
                            rowLanDoor6.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[4].Format.Font.Size = 9;
                        }
                    }
                    if (i == 3)
                    {
                        Row rowLanDoor7 = table.AddRow();
                        rowLanDoor7.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor7.Cells[0].AddParagraph(lVGquote.FtoFStart4);
                        rowLanDoor7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        if (lVGquote.DoorEntType7 == "Second entrance")
                        {
                            rowLanDoor7.Cells[1].AddParagraph("Second");
                        }
                        else { rowLanDoor7.Cells[1].AddParagraph("Front"); }
                        rowLanDoor7.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor7.Cells[2].AddParagraph(lVGquote.Hinge7);
                        rowLanDoor7.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor7.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType7);
                        rowLanDoor7.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[3].Format.Font.Size = 9;
                        rowLanDoor7.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish7);
                        rowLanDoor7.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[3].Format.Font.Size = 9;
                        rowLanDoor7.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle7);
                        rowLanDoor7.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[3].Format.Font.Size = 9;

                        rowLanDoor7.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish7);
                        rowLanDoor7.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[4].Format.Font.Size = 9;
                        rowLanDoor7.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton7);
                        rowLanDoor7.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[4].Format.Font.Size = 9;
                        rowLanDoor7.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation7);
                        rowLanDoor7.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[4].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType7 == "Front & Second entrance")
                        {
                            rowLanDoor7.Cells[0].MergeDown = 1;
                            Row rowLanDoor8 = table.AddRow();
                            rowLanDoor8.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor8.Cells[1].AddParagraph("Second");
                            rowLanDoor8.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor8.Cells[2].AddParagraph(lVGquote.Hinge8);
                            rowLanDoor8.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor8.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType8);
                            rowLanDoor8.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[3].Format.Font.Size = 9;
                            rowLanDoor8.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish8);
                            rowLanDoor8.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[3].Format.Font.Size = 9;
                            rowLanDoor8.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle8);
                            rowLanDoor8.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[3].Format.Font.Size = 9;

                            rowLanDoor8.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish8);
                            rowLanDoor8.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[4].Format.Font.Size = 9;
                            rowLanDoor8.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton8);
                            rowLanDoor8.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[4].Format.Font.Size = 9;
                            rowLanDoor8.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation8);
                            rowLanDoor8.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[4].Format.Font.Size = 9;
                        }
                    }
                    if (i == 4)
                    {
                        Row rowLanDoor9 = table.AddRow();
                        rowLanDoor9.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor9.Cells[0].AddParagraph(lVGquote.FtoFFinish4);
                        rowLanDoor9.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        if (lVGquote.DoorEntType9 == "Second entrance")
                        {
                            rowLanDoor9.Cells[1].AddParagraph("Second");
                        }
                        else { rowLanDoor9.Cells[1].AddParagraph("Front"); }
                        rowLanDoor9.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor9.Cells[2].AddParagraph(lVGquote.Hinge9);
                        rowLanDoor9.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor9.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType9);
                        rowLanDoor9.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[3].Format.Font.Size = 9;
                        rowLanDoor9.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish9);
                        rowLanDoor9.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[3].Format.Font.Size = 9;
                        rowLanDoor9.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle9);
                        rowLanDoor9.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[3].Format.Font.Size = 9;

                        rowLanDoor9.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish9);
                        rowLanDoor9.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[4].Format.Font.Size = 9;
                        rowLanDoor9.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton9);
                        rowLanDoor9.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[4].Format.Font.Size = 9;
                        rowLanDoor9.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation9);
                        rowLanDoor9.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[4].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType9 == "Front & Second entrance")
                        {
                            rowLanDoor9.Cells[0].MergeDown = 1;
                            Row rowLanDoor10 = table.AddRow();
                            rowLanDoor10.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor10.Cells[1].AddParagraph("Second");
                            rowLanDoor10.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor10.Cells[2].AddParagraph(lVGquote.Hinge10);
                            rowLanDoor10.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor10.Cells[3].AddParagraph("Type: " + lVGquote.LDFDoorType10);
                            rowLanDoor10.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[3].Format.Font.Size = 9;
                            rowLanDoor10.Cells[3].AddParagraph("Finish: " + lVGquote.LDFDoorFinish10);
                            rowLanDoor10.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[3].Format.Font.Size = 9;
                            rowLanDoor10.Cells[3].AddParagraph("Handle: " + lVGquote.LDFDoorHandle10);
                            rowLanDoor10.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[3].Format.Font.Size = 9;

                            rowLanDoor10.Cells[4].AddParagraph("Finish: " + lVGquote.LopFinish10);
                            rowLanDoor10.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[4].Format.Font.Size = 9;
                            rowLanDoor10.Cells[4].AddParagraph("Buttons: " + lVGquote.LopButton10);
                            rowLanDoor10.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[4].Format.Font.Size = 9;
                            rowLanDoor10.Cells[4].AddParagraph("Location: " + lVGquote.LopLocation10);
                            rowLanDoor10.Cells[4].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[4].Format.Font.Size = 9;
                        }
                    }
                }


            }
            else
            {
                Column LanDoor = table.AddColumn("1.5cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Center;

                LanDoor = table.AddColumn("2cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Right;

                //LanDoor = table.AddColumn("1.5cm");
                //LanDoor.Format.Alignment = ParagraphAlignment.Right;
                LanDoor = table.AddColumn("8cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Right;
                LanDoor = table.AddColumn("7cm");
                LanDoor.Format.Alignment = ParagraphAlignment.Right;

                Row rowLanDoor = table.AddRow();
                rowLanDoor.Format.Alignment = ParagraphAlignment.Center;
                rowLanDoor.Cells[0].AddParagraph("Levels");
                rowLanDoor.Cells[0].Format.Font.Bold = true;
                rowLanDoor.Cells[0].Format.Font.Size = 9;
                rowLanDoor.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[1].AddParagraph("Entrance Type");
                rowLanDoor.Cells[1].Format.Font.Bold = true;
                rowLanDoor.Cells[1].Format.Font.Size = 9;
                rowLanDoor.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                //rowLanDoor.Cells[2].AddParagraph("Door Hinge");
                //rowLanDoor.Cells[2].Format.Font.Bold = true;
                //rowLanDoor.Cells[2].Format.Font.Size = 9;
                //rowLanDoor.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[2].AddParagraph("Door ");
                rowLanDoor.Cells[2].Format.Font.Bold = true;
                rowLanDoor.Cells[2].Format.Font.Size = 9;
                rowLanDoor.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[3].AddParagraph("Landing Operating Panel");
                rowLanDoor.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                rowLanDoor.Cells[3].Format.Font.Bold = true;
                rowLanDoor.Cells[3].Format.Font.Size = 9;

                for (var i = 0; i < lVGquote.NoOfFloors; i++)
                {

                    if (i == 0)
                    {
                        Row rowLanDoor1 = table.AddRow();
                        rowLanDoor1.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor1.Cells[0].AddParagraph(lVGquote.FtoFStart1);  // 1ST LEVEL Link it to the form GAJ TO DO 
                        rowLanDoor1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[1].AddParagraph("front"); // Link it to the form GAJ TO DO 
                        rowLanDoor1.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[1].Format.Font.Size = 9;


                        //rowLanDoor1.Cells[2].AddParagraph(lVGquote.Hinge1);
                        //rowLanDoor1.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor1.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType1);
                        rowLanDoor1.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[2].Format.Font.Size = 9;
                        rowLanDoor1.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish1);
                        rowLanDoor1.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[2].Format.Font.Size = 9;
                        rowLanDoor1.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish1);
                        rowLanDoor1.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[2].Format.Font.Size = 9;

                        rowLanDoor1.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish1);
                        rowLanDoor1.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[3].Format.Font.Size = 9;
                        rowLanDoor1.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton1);
                        rowLanDoor1.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[3].Format.Font.Size = 9;
                        rowLanDoor1.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation1);
                        rowLanDoor1.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor1.Cells[3].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType1 == "Front & Second entrance")
                        {
                            rowLanDoor1.Cells[0].MergeDown = 1;

                            Row rowLanDoor2 = table.AddRow();
                            rowLanDoor2.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor2.Cells[1].AddParagraph("Second");
                            rowLanDoor2.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                            //rowLanDoor2.Cells[2].AddParagraph(lVGquote.Hinge2);
                            //rowLanDoor2.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                            //rowLanDoor2.Cells[2].AddParagraph(lVGquote.LDFDoorType2);
                            //rowLanDoor2.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            //rowLanDoor2.Cells[3].AddParagraph(lVGquote.LDFDoorFinish4);
                            //// rowLanDoor2.Cells[3].AddParagraph("LOP" + lVGquote.LopFinish1 + lVGquote.LopLocation1);
                            //rowLanDoor2.Cells[3].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor2.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType2);
                            rowLanDoor2.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[2].Format.Font.Size = 9;
                            rowLanDoor2.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish2);
                            rowLanDoor2.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[2].Format.Font.Size = 9;
                            rowLanDoor2.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish2);
                            rowLanDoor2.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[2].Format.Font.Size = 9;

                            rowLanDoor2.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish2);
                            rowLanDoor2.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[3].Format.Font.Size = 9;
                            rowLanDoor2.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton2);
                            rowLanDoor2.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[3].Format.Font.Size = 9;
                            rowLanDoor2.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation2);
                            rowLanDoor2.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor2.Cells[3].Format.Font.Size = 9;
                        }
                    }
                    if (i == 1)
                    {
                        Row rowLanDoor3 = table.AddRow();
                        rowLanDoor3.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor3.Cells[0].AddParagraph(lVGquote.FtoFStart2); //Link it to the form GAJ TO DO 
                        rowLanDoor3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[1].AddParagraph("front"); //Link it to the form GAJ TO DO 
                        rowLanDoor3.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                        //rowLanDoor3.Cells[2].AddParagraph(lVGquote.Hinge3);
                        //rowLanDoor3.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        //rowLanDoor3.Cells[2].AddParagraph(lVGquote.LDFDoorType3);
                        //rowLanDoor3.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        //rowLanDoor3.Cells[3].AddParagraph(lVGquote.LDFDoorFinish3);
                        ////rowLanDoor3.Cells[3].AddParagraph("LOP - " + lVGquote.LopFinish2 + lVGquote.LopLocation2);
                        //rowLanDoor3.Cells[3].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor3.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType3);
                        rowLanDoor3.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[2].Format.Font.Size = 9;
                        rowLanDoor3.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish3);
                        rowLanDoor3.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[2].Format.Font.Size = 9;
                        rowLanDoor3.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish3);
                        rowLanDoor3.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[2].Format.Font.Size = 9;

                        rowLanDoor3.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish3);
                        rowLanDoor3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[3].Format.Font.Size = 9;
                        rowLanDoor3.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton3);
                        rowLanDoor3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[3].Format.Font.Size = 9;
                        rowLanDoor3.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation3);
                        rowLanDoor3.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor3.Cells[3].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType3 == "Front & Second entrance")
                        {
                            rowLanDoor3.Cells[0].MergeDown = 1;
                            Row rowLanDoor4 = table.AddRow();
                            rowLanDoor4.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor4.Cells[1].AddParagraph("Second");
                            rowLanDoor4.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                            if (lVGquote.FrontEntLanDoor != "Swing doors")
                                //{
                                //    rowLanDoor4.Cells[2].AddParagraph("N/A");
                                //    rowLanDoor4.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                                //}
                                //else
                                //{
                                //    rowLanDoor4.Cells[2].AddParagraph(lVGquote.Hinge4);
                                //    rowLanDoor4.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                                //}
                                //rowLanDoor4.Cells[2].AddParagraph(lVGquote.LDFDoorType4);
                                //rowLanDoor4.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                                //rowLanDoor4.Cells[3].AddParagraph(lVGquote.LDFDoorFinish4);
                                //rowLanDoor4.Cells[3].Format.Alignment = ParagraphAlignment.Left;

                                rowLanDoor4.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType4);
                            rowLanDoor4.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[2].Format.Font.Size = 9;
                            rowLanDoor4.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish4);
                            rowLanDoor4.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[2].Format.Font.Size = 9;
                            rowLanDoor4.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish4);
                            rowLanDoor4.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[2].Format.Font.Size = 9;

                            rowLanDoor4.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish4);
                            rowLanDoor4.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[3].Format.Font.Size = 9;
                            rowLanDoor4.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton4);
                            rowLanDoor4.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[3].Format.Font.Size = 9;
                            rowLanDoor4.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation4);
                            rowLanDoor4.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor4.Cells[3].Format.Font.Size = 9;
                        }
                    }
                    if (i == 2)
                    {
                        Row rowLanDoor5 = table.AddRow();
                        rowLanDoor5.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor5.Cells[0].AddParagraph(lVGquote.FtoFStart3);
                        rowLanDoor5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[1].AddParagraph("Front");
                        rowLanDoor5.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                        //rowLanDoor5.Cells[2].AddParagraph(lVGquote.Hinge5);
                        //rowLanDoor5.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor5.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType5);
                        rowLanDoor5.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[2].Format.Font.Size = 9;
                        rowLanDoor5.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish5);
                        rowLanDoor5.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[2].Format.Font.Size = 9;
                        rowLanDoor5.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish5);
                        rowLanDoor5.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[2].Format.Font.Size = 9;

                        rowLanDoor5.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish5);
                        rowLanDoor5.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[3].Format.Font.Size = 9;
                        rowLanDoor5.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton5);
                        rowLanDoor5.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[3].Format.Font.Size = 9;
                        rowLanDoor5.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation5);
                        rowLanDoor5.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor5.Cells[3].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType5 == "Front & Second entrance")
                        {
                            rowLanDoor5.Cells[0].MergeDown = 1;
                            Row rowLanDoor6 = table.AddRow();
                            rowLanDoor6.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor6.Cells[1].AddParagraph("Second");
                            rowLanDoor6.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                            //rowLanDoor6.Cells[2].AddParagraph(lVGquote.Hinge6);
                            //rowLanDoor6.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor6.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType6);
                            rowLanDoor6.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[2].Format.Font.Size = 9;
                            rowLanDoor6.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish6);
                            rowLanDoor6.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[2].Format.Font.Size = 9;
                            rowLanDoor6.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish6);
                            rowLanDoor6.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[2].Format.Font.Size = 9;

                            rowLanDoor6.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish6);
                            rowLanDoor6.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[3].Format.Font.Size = 9;
                            rowLanDoor6.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton6);
                            rowLanDoor6.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[3].Format.Font.Size = 9;
                            rowLanDoor6.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation6);
                            rowLanDoor6.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor6.Cells[3].Format.Font.Size = 9;
                        }
                    }
                    if (i == 3)
                    {
                        Row rowLanDoor7 = table.AddRow();
                        rowLanDoor7.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor7.Cells[0].AddParagraph(lVGquote.FtoFStart4);
                        rowLanDoor7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[1].AddParagraph("Front");
                        rowLanDoor7.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                        //rowLanDoor7.Cells[2].AddParagraph(lVGquote.Hinge7);
                        //rowLanDoor7.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor7.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType7);
                        rowLanDoor7.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[2].Format.Font.Size = 9;
                        rowLanDoor7.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish7);
                        rowLanDoor7.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[2].Format.Font.Size = 9;
                        rowLanDoor7.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish7);
                        rowLanDoor7.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[2].Format.Font.Size = 9;

                        rowLanDoor7.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish7);
                        rowLanDoor7.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[3].Format.Font.Size = 9;
                        rowLanDoor7.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton7);
                        rowLanDoor7.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[3].Format.Font.Size = 9;
                        rowLanDoor7.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation7);
                        rowLanDoor7.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor7.Cells[3].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType7 == "Front & Second entrance")
                        {
                            rowLanDoor7.Cells[0].MergeDown = 1;
                            Row rowLanDoor8 = table.AddRow();
                            rowLanDoor8.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor8.Cells[1].AddParagraph("Second");
                            rowLanDoor8.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                            //rowLanDoor8.Cells[2].AddParagraph(lVGquote.Hinge8);
                            //rowLanDoor8.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor8.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType8);
                            rowLanDoor8.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[2].Format.Font.Size = 9;
                            rowLanDoor8.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish8);
                            rowLanDoor8.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[2].Format.Font.Size = 9;
                            rowLanDoor8.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish8);
                            rowLanDoor8.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[2].Format.Font.Size = 9;

                            rowLanDoor8.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish8);
                            rowLanDoor8.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[3].Format.Font.Size = 9;
                            rowLanDoor8.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton8);
                            rowLanDoor8.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[3].Format.Font.Size = 9;
                            rowLanDoor8.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation8);
                            rowLanDoor8.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor8.Cells[3].Format.Font.Size = 9;
                        }
                    }
                    if (i == 4)
                    {
                        Row rowLanDoor9 = table.AddRow();
                        rowLanDoor9.Format.Alignment = ParagraphAlignment.Center;
                        rowLanDoor9.Cells[0].AddParagraph(lVGquote.FtoFFinish4);
                        rowLanDoor9.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[1].AddParagraph("Front");
                        rowLanDoor9.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                        //rowLanDoor9.Cells[2].AddParagraph(lVGquote.Hinge9);
                        //rowLanDoor9.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                        rowLanDoor9.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType9);
                        rowLanDoor9.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[2].Format.Font.Size = 9;
                        rowLanDoor9.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish9);
                        rowLanDoor9.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[2].Format.Font.Size = 9;
                        rowLanDoor9.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish9);
                        rowLanDoor9.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[2].Format.Font.Size = 9;

                        rowLanDoor9.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish9);
                        rowLanDoor9.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[3].Format.Font.Size = 9;
                        rowLanDoor9.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton9);
                        rowLanDoor9.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[3].Format.Font.Size = 9;
                        rowLanDoor9.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation9);
                        rowLanDoor9.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                        rowLanDoor9.Cells[3].Format.Font.Size = 9;

                        if (lVGquote.DoorEntType9 == "Front & Second entrance")
                        {
                            rowLanDoor9.Cells[0].MergeDown = 1;
                            Row rowLanDoor10 = table.AddRow();
                            rowLanDoor10.Format.Alignment = ParagraphAlignment.Center;

                            rowLanDoor10.Cells[1].AddParagraph("Second");
                            rowLanDoor10.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                            //rowLanDoor10.Cells[2].AddParagraph(lVGquote.Hinge10);
                            //rowLanDoor10.Cells[2].Format.Alignment = ParagraphAlignment.Left;

                            rowLanDoor10.Cells[2].AddParagraph("Type: " + lVGquote.LDFDoorType10);
                            rowLanDoor10.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[2].Format.Font.Size = 9;
                            rowLanDoor10.Cells[2].AddParagraph("Panel: " + lVGquote.LDFDoorFinish10);
                            rowLanDoor10.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[2].Format.Font.Size = 9;
                            rowLanDoor10.Cells[2].AddParagraph("Frame: " + lVGquote.LDFFrameFinish10);
                            rowLanDoor10.Cells[2].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[2].Format.Font.Size = 9;

                            rowLanDoor10.Cells[3].AddParagraph("Finish: " + lVGquote.LopFinish10);
                            rowLanDoor10.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[3].Format.Font.Size = 9;
                            rowLanDoor10.Cells[3].AddParagraph("Buttons: " + lVGquote.LopButton10);
                            rowLanDoor10.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[3].Format.Font.Size = 9;
                            rowLanDoor10.Cells[3].AddParagraph("Location: " + lVGquote.LopLocation10);
                            rowLanDoor10.Cells[3].Format.Alignment = ParagraphAlignment.Left;
                            rowLanDoor10.Cells[3].Format.Font.Size = 9;
                        }
                    }
                }

            }




            if (lVGquote.ShaftType != "Masonry")
            {



                paragraph = section.AddParagraph();
                paragraph = section.AddParagraph("TOWER FINISH");
                paragraph.Format.Font.Bold = true;
                paragraph.Format.Font.Size = 13;
                paragraph.Format.SpaceAfter = 5;

                table = section.AddTable();
                table.Style = "Table3";

                //          table.Borders.Color = TableBorder;
                table.Borders.Width = 0;
                table.Borders.Left.Width = 0;
                table.Borders.Right.Width = 0;
                table.Rows.LeftIndent = 0;

                Column columnTower = table.AddColumn("7cm");
                columnTower.Format.Alignment = ParagraphAlignment.Center;

                columnTower = table.AddColumn("8cm");
                columnTower.Format.Alignment = ParagraphAlignment.Right;

                Row rowtower = table.AddRow();
                rowtower.Format.Alignment = ParagraphAlignment.Center;
                rowtower.Cells[0].AddParagraph("Application:");
                rowtower.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowtower.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                rowtower.Cells[1].AddParagraph(lVGquote.TowerLocation);
                rowtower.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                if (lVGquote.ShaftType == "Top Hat")
                {
                    Row rowtower1 = table.AddRow();
                    rowtower1.Format.Alignment = ParagraphAlignment.Center;
                    rowtower1.Cells[0].AddParagraph("Structure Type  (this structure is not fire Rated)");
                    rowtower1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                    rowtower1.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                    rowtower1.Cells[1].AddParagraph(lVGquote.StructureType + "      Partial Structure Height: " + lVGquote.THPartialStructHeight);
                    rowtower1.Cells[1].Format.Alignment = ParagraphAlignment.Left;
                }

                Row rowtower3 = table.AddRow();
                rowtower3.Format.Alignment = ParagraphAlignment.Center;
                rowtower3.Cells[0].AddParagraph("Structure Finish:");
                rowtower3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowtower3.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                rowtower3.Cells[1].AddParagraph(lVGquote.StructureFinish);
                rowtower3.Cells[1].Format.Alignment = ParagraphAlignment.Left;



                //Row rowtower4 = table.AddRow();
                //rowtower4.Format.Alignment = ParagraphAlignment.Center;
                //rowtower4.Cells[0].AddParagraph("Roof");
                //rowtower4.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                //rowtower4.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
                //rowtower4.Cells[1].AddParagraph(lVGquote.Roof);
                //rowtower4.Cells[1].Format.Alignment = ParagraphAlignment.Left;

                Row rowtower5 = table.AddRow();
                rowtower5.Format.Alignment = ParagraphAlignment.Center;
                rowtower5.Cells[0].AddParagraph("Cladding");
                rowtower5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
                rowtower5.Cells[0].VerticalAlignment = VerticalAlignment.Top;
                rowtower5.Cells[1].AddParagraph("Left Side:  " + lVGquote.CladdingLHS);
                rowtower5.Cells[1].AddParagraph("Right Side: " + lVGquote.CladdingRHS);
                rowtower5.Cells[1].AddParagraph("Rear Side: " + lVGquote.CladdingRear);
                rowtower5.Cells[1].AddParagraph("Front Side: " + lVGquote.CladdingFront);
                rowtower5.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            }
            paragraph = section.AddParagraph("");
            paragraph.Format.SpaceAfter = 5;
            paragraph = section.AddParagraph(lVGquote.Power + " power @ " + lVGquote.Speed + "m/s (maximum) without lift car door");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = 5;
            paragraph = section.AddParagraph("");
            paragraph.Format.SpaceAfter = 3;
            paragraph = section.AddParagraph("Lift is required on site approximately  ____/____/_____");
            paragraph.Format.SpaceAfter = 5;

            paragraph.AddLineBreak(); paragraph.AddLineBreak();
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("Please sign to approve the above finishes:   Signed_______________________ Date: ____/____/________ ");
            paragraph.Format.Font.Bold = true;
            paragraph.AddLineBreak();
            paragraph.AddLineBreak();


            // --------------------------PAGE 5----------------------------------------------------  

            document.LastSection.AddPageBreak();
            paragraph = section.AddParagraph("LIFT PRICE");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 13;

            paragraph = section.AddParagraph("Our price for the supply, installation, testing and commissioning for (" + lVGquote.NoOfLifts + ") Easy Living Home Elevators Italian");
            paragraph = section.AddParagraph("designed, engineered and manufactured " + lVGquote.LiftType + " as described herein is as follows:");

            paragraph = section.AddParagraph();

            table = section.AddTable();
            table.Style = "Table";


            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;



            Column price = table.AddColumn("5cm");

            price.Format.Alignment = ParagraphAlignment.Center;

            price = table.AddColumn("5cm");
            price.Format.Alignment = ParagraphAlignment.Right;

            price = table.AddColumn("5cm");
            price.Format.Alignment = ParagraphAlignment.Right;

            Row rowprice = table.AddRow();
            rowprice.Format.Alignment = ParagraphAlignment.Center;
            rowprice.Cells[0].AddParagraph("Price per lift");
            rowprice.Cells[0].Format.Font.Size = 13;
            rowprice.Cells[0].Format.Font.Bold = true;
            rowprice.Cells[0].Format.Alignment = ParagraphAlignment.Left;

            rowprice.Cells[1].AddParagraph("No. of lifts ");
            rowprice.Cells[1].Format.Font.Size = 13;
            rowprice.Cells[1].Format.Font.Bold = true;
            rowprice.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            rowprice.Cells[2].AddParagraph("Total Contract Price ");
            rowprice.Cells[2].Format.Font.Size = 13;
            rowprice.Cells[2].Format.Font.Bold = true;
            rowprice.Cells[2].Format.Alignment = ParagraphAlignment.Left;

            Row rowprice1 = table.AddRow();
            rowprice1.Format.Alignment = ParagraphAlignment.Center;
            string s = string.Format("{0:#,0.00}", Math.Round(float.Parse(lVGquote.SellingPrice), 2));
            rowprice1.Cells[0].AddParagraph("$" + s + " + GST");
            rowprice1.Cells[0].Format.Font.Size = 13;
            rowprice1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            //twoDec = Math.Round(val, 2)
            rowprice1.Cells[1].AddParagraph("" + lVGquote.NoOfLifts);
            rowprice1.Cells[1].Format.Font.Size = 13;
            rowprice1.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            float s2 = float.Parse(lVGquote.SellingPrice) * lVGquote.NoOfLifts;
            string total_price = string.Format("{0:#,0.00}", Math.Round(s2, 2));
            rowprice1.Cells[2].AddParagraph("$ " + total_price + " + GST");
            rowprice1.Cells[2].Format.Font.Size = 13;
            rowprice1.Cells[2].Format.Alignment = ParagraphAlignment.Left;


            //Row rowprice = table.AddRow();
            //rowprice.Format.Alignment = ParagraphAlignment.Center;
            //rowprice.Cells[0].AddParagraph("Lift Price:");
            //rowprice.Cells[0].Format.Font.Size = 13;
            //rowprice.Cells[0].Format.Font.Bold = true;
            //rowprice.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            //rowprice.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            ////twoDec = Math.Round(val, 2)
            //string s1 = string.Format("{0:#,0.00}", Math.Round(float.Parse(lVGquote.SellingPrice), 2));
            //rowprice.Cells[1].AddParagraph("$ " + s1);
            //rowprice.Cells[1].Format.Font.Size = 13;
            //rowprice.Cells[1].Format.Font.Bold = true;
            //rowprice.Cells[1].Format.Alignment = ParagraphAlignment.Right;

            //Row rowprice1 = table.AddRow();
            //rowprice1.Format.Alignment = ParagraphAlignment.Center;
            //rowprice1.Cells[0].AddParagraph("GST:");
            //rowprice1.Cells[0].Format.Font.Size = 13;
            //rowprice1.Cells[0].Format.Font.Bold = true;
            //rowprice1.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            //rowprice1.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            //string sg = string.Format("{0:#,0.00}", float.Parse(lVGquote.Gst));
            //rowprice1.Cells[1].AddParagraph("$ " + sg);
            //rowprice1.Cells[1].Format.Font.Size = 13;
            //rowprice1.Cells[1].Format.Font.Bold = true;
            //rowprice1.Cells[1].Format.Alignment = ParagraphAlignment.Right;

            //Row rowprice2 = table.AddRow();
            //rowprice2.Format.Alignment = ParagraphAlignment.Center;
            //rowprice2.Cells[0].AddParagraph("Total Lift Price:");
            //rowprice2.Cells[0].Format.Font.Size = 13;
            //rowprice2.Cells[0].Format.Font.Bold = true;
            //rowprice2.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            //rowprice2.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            //string s2 = string.Format("{0:#,0.00}", float.Parse(lVGquote.TotalSellingPrice));
            //rowprice2.Cells[1].AddParagraph("$ " + s2);
            //rowprice2.Cells[1].Format.Font.Size = 13;
            //rowprice2.Cells[1].Format.Font.Bold = true;
            //rowprice2.Cells[1].Format.Alignment = ParagraphAlignment.Right;

            paragraph = section.AddParagraph("");
            paragraph = section.AddParagraph("This is a conditional fixed price based on the above finishes included and is valid for 21 days from today");
            //paragraph.AddLineBreak();

            //paragraph.AddLineBreak();
            if (lVGquote.GstFree)
            {
                Image imagegst = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\logo\\GST Free Image.jpg"));
                imagegst.Height = "5cm";
                //imagegst.Width = "14cm";
                imagegst.LockAspectRatio = true;
                imagegst.RelativeVertical = RelativeVertical.Line;
                imagegst.RelativeHorizontal = RelativeHorizontal.Margin;
                //image.Top = ShapePosition.Top;
                imagegst.Left = ShapePosition.Center;
                //  imagegst.WrapFormat.Style = WrapStyle.Through;

            }

            paragraph = section.AddParagraph("");


            table = section.AddTable();
            table.Style = "Table";

            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;


            Column waranty = table.AddColumn("5cm");
            waranty.Format.Alignment = ParagraphAlignment.Center;

            waranty = table.AddColumn("5cm");
            waranty.Format.Alignment = ParagraphAlignment.Right;

            Row rowwaranty = table.AddRow();
            rowwaranty.Format.Alignment = ParagraphAlignment.Center;
            rowwaranty.Cells[0].AddParagraph("WARRANTY:");
            rowwaranty.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowwaranty.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowwaranty.Cells[0].Format.Font.Bold = true;
            rowwaranty.Cells[0].Format.Font.Size = 12;
            rowwaranty.Cells[1].AddParagraph(lVGquote.Warranty + " Year(s)");
            rowwaranty.Cells[1].Format.Font.Size = 12;
            rowwaranty.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowwaranty1 = table.AddRow();
            rowwaranty1.Format.Alignment = ParagraphAlignment.Center;
            rowwaranty1.Cells[0].AddParagraph("SERVICING:");
            rowwaranty1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowwaranty1.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowwaranty1.Cells[0].Format.Font.Bold = true;
            rowwaranty1.Cells[0].Format.Font.Size = 12;
            rowwaranty1.Cells[1].AddParagraph(lVGquote.Servicing + " Year(s)");
            rowwaranty1.Cells[1].Format.Font.Size = 12;
            rowwaranty1.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            paragraph = section.AddParagraph();

            table = section.AddTable();
            table.Style = "Table2";
            table.Borders.Width = 0;
            table.Borders.Left.Width = 0;
            table.Borders.Right.Width = 0;
            table.Rows.LeftIndent = 0;

            Column prestige = table.AddColumn("6cm");
            prestige.Format.Alignment = ParagraphAlignment.Center;
            prestige = table.AddColumn("10cm");
            prestige.Format.Alignment = ParagraphAlignment.Right;

            Row rowprestige = table.AddRow();
            rowprestige.Format.Alignment = ParagraphAlignment.Center;
            rowprestige.Cells[0].AddParagraph("OPTIONAL EXTRAS");
            rowprestige.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowprestige.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowprestige.Cells[0].Format.Font.Bold = true;
            rowprestige.Cells[0].Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            rowprestige.Cells[0].Format.Font.Size = 14;

            Row rowprestige1 = table.AddRow();
            rowprestige1.Format.Alignment = ParagraphAlignment.Center;
            rowprestige1.Cells[0].AddParagraph("PRESTIGE FINISHES PACK:");
            rowprestige1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowprestige1.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowprestige1.Cells[0].Format.Font.Bold = true;
            rowprestige1.Cells[0].Format.Font.Size = 12;
            rowprestige1.Cells[1].AddParagraph("1.Mirror Stainless Steel Car Walls");
            rowprestige1.Cells[1].AddParagraph("2.Mirror Stainless Steel Ceiling with LED downlights");
            rowprestige1.Cells[1].AddParagraph("3.Manufactured Stone Floor (Choice of 5 colours)");

            rowprestige1.Cells[1].Format.Alignment = ParagraphAlignment.Left;

            Row rowprestige2 = table.AddRow();
            rowprestige2.Format.Alignment = ParagraphAlignment.Center;
            rowprestige2.Cells[0].AddParagraph("");
            rowprestige2.Cells[1].AddParagraph("Total extra cost $2500 + GST per Lift");
            rowprestige2.Cells[1].Format.Font.Bold = true;
            rowprestige2.Cells[1].Format.Font.Size = 12;

            Row rowprestige3 = table.AddRow();
            rowprestige3.Format.Alignment = ParagraphAlignment.Center;
            rowprestige3.Cells[0].AddParagraph("INSURANCE:");
            rowprestige3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowprestige3.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowprestige3.Cells[0].Format.Font.Bold = true;
            rowprestige3.Cells[0].Format.Font.Size = 12;
            rowprestige3.Cells[1].AddParagraph("Mandatory owner-builder Home Warranty Insurance");
            rowprestige3.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            paragraph.Format.SpaceAfter = 12;

            Row rowprestige4 = table.AddRow();
            rowprestige4.Format.Alignment = ParagraphAlignment.Center;
            rowprestige4.Cells[0].AddParagraph("");
            rowprestige4.Cells[1].AddParagraph("Total extra cost $500 + GST per Lift");
            rowprestige4.Cells[1].Format.Font.Bold = true;
            rowprestige4.Cells[1].Format.Font.Size = 12;

            paragraph.AddLineBreak();
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("");
            paragraph.Format.SpaceBefore = 12;
            paragraph.AddFormattedText("Please note:", TextFormat.Bold);
            paragraph.AddText("Home Warranty insurance is mandatory for contracts over the value of $12,000, where the contract has been entered into directly between Easy Living Home Elevators and the home owner or owner/builder.  This cost is not included in the tender price and is an additional variation cost if required on this contract");
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("General");
            paragraph.Format.Font.Bold = true;
            paragraph = section.AddParagraph("The tender is submitted based on our Standard Conditions of Contract. A copy of this document is available on request. We have not included for any architects fees, building application or design application fees, or any building works for the project"
                + "All dimensions to be confirmed via site-specific layout drawing. Drawings to take precedence over any stated dimension. Sketches provided at sales stage are “Not for Construction” This offer takes precedent over any specification document provided for pricing purposes.");
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Note: Regarding selected RAL paint finishes: ", TextFormat.Bold);
            paragraph.AddText("Every effort will be made to ensure the colours of the lift finish match the colour sample you selected from."
                + "Unfortunately, we cannot guarantee an exact colour match due to differences in substrate material, application thickness and ambient light conditions and as such are not liable for any rectification of same."
                + " The nature of the product means that some slight colour variance may occur.");
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("The above information describes the Lift Specifications, Lift Finishes, lift price and Warranty & Servicing as per your selection"
                + "and is hereby accepted along with terms of payment & manufacture program as described in the quotation supplied by Easy-Living Home Elevators:");

            paragraph.Format.Font.Bold = true;
            paragraph.Format.SpaceAfter = 25;

            paragraph = section.AddParagraph("Signed:_________________________________________________   Date:_______________");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = 15;
            paragraph = section.AddParagraph("Print Name_____________________________________________");
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = 7;
            document.LastSection.AddPageBreak();

            // --------------------------PAGE 6---------------------------------------------------- 

            paragraph = section.AddParagraph("PROGRAM AND PAYMENT SCHEDULE");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("Easy Living Home Elevators makes the buying program easy! Simply follow the program outlined below."
                + "	Our team of experts will keep you informed on the progress of your elevator, every step of the way.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 10;



            table = section.AddTable();
            table.Style = "Table3";


            table.Borders.Width = 0.5;
            table.Borders.Left.Width = 0.5;
            table.Borders.Right.Width = 0.5;
            table.Rows.LeftIndent = 0.5;



            Column page6 = table.AddColumn("2cm");
            page6.Format.Alignment = ParagraphAlignment.Center;


            page6 = table.AddColumn("14cm");
            page6.Format.Alignment = ParagraphAlignment.Center;

            page6 = table.AddColumn("3.5cm");
            page6.Format.Alignment = ParagraphAlignment.Center;

            Row rowpage6 = table.AddRow();
            rowpage6.Format.Alignment = ParagraphAlignment.Center;
            rowpage6.Cells[0].AddParagraph("LEAD TIME");
            rowpage6.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowpage6.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowpage6.Cells[0].Format.Font.Bold = true;
            rowpage6.Cells[0].Format.Font.Size = 10;
            rowpage6.Cells[1].AddParagraph("PROGRAM");
            rowpage6.Cells[1].Format.Font.Bold = true;
            rowpage6.Cells[1].Format.Font.Size = 10;
            rowpage6.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            rowpage6.Cells[2].AddParagraph("PAYMENT");
            rowpage6.Cells[2].Format.Font.Bold = true;
            rowpage6.Cells[2].Format.Font.Size = 10;
            rowpage6.Cells[2].Format.Alignment = ParagraphAlignment.Left;

            Row rowpage61 = table.AddRow();
            rowpage61.Format.Alignment = ParagraphAlignment.Center;
            rowpage61.Cells[0].AddParagraph("Step 1");
            rowpage61.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowpage61.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowpage61.Cells[0].Format.Font.Bold = true;
            rowpage61.Cells[0].Format.Font.Size = 11;
            paragraph = rowpage61.Cells[1].AddParagraph();
            paragraph.AddFormattedText("TO PROCESS YOUR ORDER", TextFormat.Bold);
            paragraph.AddText(" without delay we only need four things.");
            rowpage61.Cells[1].AddParagraph("1. Sign acceptance and initial each page of this document.");
            rowpage61.Cells[1].AddParagraph("2. First payment of 10% of the total contract value upon placement of order- To produce site specific Shop Drawings which include preliminary engineering design. Non refundable and is due within 21 days from invoice  issue date");
            rowpage61.Cells[1].AddParagraph("3. Confirmed travel dimension (from bottom finished floor level to top finished floor)");
            rowpage61.Cells[1].AddParagraph("4. Your selection of finishes");
            rowpage61.Cells[1].Format.Font.Size = 10;

            rowpage61.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            paragraph = rowpage61.Cells[2].AddParagraph();
            paragraph.AddFormattedText("Payment:", TextFormat.Bold);
            paragraph.AddText(" First Payment");
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Amount Payable:", TextFormat.Bold);
            paragraph.AddText(" 10% of the contract value");
            rowpage61.Cells[2].Format.Font.Size = 10;
            rowpage61.Cells[2].Format.Alignment = ParagraphAlignment.Left;

            Row rowpage62 = table.AddRow();
            rowpage62.Format.Alignment = ParagraphAlignment.Center;
            rowpage62.Cells[0].AddParagraph("Step 2");
            rowpage62.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowpage62.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowpage62.Cells[0].Format.Font.Bold = true;
            rowpage62.Cells[0].Format.Font.Size = 11;
            paragraph = rowpage62.Cells[1].AddParagraph();
            paragraph.AddFormattedText("SITE SPECIFIC DRAWINGS", TextFormat.Bold);
            paragraph.AddText(" issued for client approval");
            rowpage62.Cells[1].AddParagraph("Please check it carefully paying special attention to the following:");
            rowpage62.Cells[1].AddParagraph("1. Shaft dimensions");
            rowpage62.Cells[1].AddParagraph("2. Travel");
            rowpage62.Cells[1].AddParagraph("3. Pit and headroom");
            rowpage62.Cells[1].AddParagraph("4. It is important that your builder contact us prior to starting construction");
            rowpage62.Cells[1].Format.Font.Size = 10;
            rowpage62.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            rowpage62.Cells[2].AddParagraph("");

            rowpage62.Cells[2].Format.Font.Size = 10;
            rowpage62.Cells[2].Format.Alignment = ParagraphAlignment.Left;

            Row rowpage63 = table.AddRow();
            rowpage63.Format.Alignment = ParagraphAlignment.Center;
            rowpage63.Cells[0].AddParagraph("Step 3");
            rowpage63.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowpage63.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowpage63.Cells[0].Format.Font.Bold = true;
            rowpage63.Cells[0].Format.Font.Size = 11;
            paragraph = rowpage63.Cells[1].AddParagraph();
            paragraph.AddFormattedText("TO COMMENCE MANUFACTURE", TextFormat.Bold);
            paragraph.AddText(" of your lift we will require you to send back:");
            rowpage63.Cells[1].AddParagraph("1.Signed and approved copy of the Site Specific drawing");
            rowpage63.Cells[1].AddParagraph("2.Signed and fully completed Finishes and Selections page");
            rowpage63.Cells[1].AddParagraph("3.PC1 payment");
            rowpage63.Cells[1].AddParagraph("4.Outstanding first payment");
            rowpage63.Cells[1].AddParagraph("Date Payable: 90 days after offer acceptance & prior to commencement of manufacture. We reserve the right to adjust the contract price after this 90 day period."
                + "Client/builder is responsible for ensuring the lift is placed into production on time to meet schedule");
            rowpage63.Cells[1].Format.Font.Size = 10;


            rowpage63.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            paragraph = rowpage63.Cells[2].AddParagraph();
            paragraph.AddFormattedText("Payment:", TextFormat.Bold);
            paragraph.AddText(" PC1");
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Amount Payable:", TextFormat.Bold);
            paragraph.AddText("25%  of the contract value");
            rowpage63.Cells[2].Format.Font.Size = 10;
            rowpage63.Cells[2].Format.Alignment = ParagraphAlignment.Left;

            Row rowpage64 = table.AddRow();
            rowpage64.Format.Alignment = ParagraphAlignment.Center;
            rowpage64.Cells[0].AddParagraph("Week");
            rowpage64.Cells[0].AddParagraph("10-12");
            rowpage64.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowpage64.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowpage64.Cells[0].Format.Font.Bold = true;
            rowpage64.Cells[0].Format.Font.Size = 11;
            paragraph = rowpage64.Cells[1].AddParagraph();
            paragraph.AddFormattedText("EX Works**", TextFormat.Bold);
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("To ship your lift", TextFormat.Bold);
            paragraph.AddText(" on the scheduled ex works date we will require you to:");
            rowpage64.Cells[1].AddParagraph("Make payment 2 weeks prior to completion of manufacture of the lift from the factory");
            rowpage64.Cells[1].Format.Font.Size = 10;

            rowpage64.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            paragraph = rowpage64.Cells[2].AddParagraph();
            paragraph.AddFormattedText("Payment:", TextFormat.Bold);
            paragraph.AddText(" PC2");
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Amount Payable:", TextFormat.Bold);
            paragraph.AddText("35%  of the contract value");
            rowpage64.Cells[2].Format.Font.Size = 10;
            rowpage64.Cells[2].Format.Alignment = ParagraphAlignment.Left;


            Row rowpage65 = table.AddRow();
            rowpage65.Format.Alignment = ParagraphAlignment.Center;
            rowpage65.Cells[0].AddParagraph("Week");
            rowpage65.Cells[0].AddParagraph("16-18");
            rowpage65.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowpage65.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowpage65.Cells[0].Format.Font.Bold = true;
            rowpage65.Cells[0].Format.Font.Size = 11;
            paragraph = rowpage65.Cells[1].AddParagraph();
            paragraph.AddFormattedText("Site Delivery***", TextFormat.Bold);
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("To organise site delivery of your lift", TextFormat.Bold);
            paragraph.AddText(" without delay we will require you to:");
            rowpage65.Cells[1].AddParagraph("Make payment, Date Payable: As it clears customs");
            rowpage65.Cells[1].AddParagraph("Site delivery timings are from 8am-5pm Monday to Friday. Surcharge applies for");
            rowpage65.Cells[1].AddParagraph("after hours and weekend deliveries.");
            rowpage65.Cells[1].Format.Font.Size = 10;

            rowpage65.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            paragraph = rowpage65.Cells[2].AddParagraph();
            paragraph.AddFormattedText("Payment:", TextFormat.Bold);
            paragraph.AddText(" PC3");
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Amount Payable:", TextFormat.Bold);
            paragraph.AddText("10%  of the contract value");
            rowpage65.Cells[2].Format.Font.Size = 10;
            rowpage65.Cells[2].Format.Alignment = ParagraphAlignment.Left;


            Row rowpage66 = table.AddRow();
            rowpage66.Format.Alignment = ParagraphAlignment.Center;
            rowpage66.Cells[0].AddParagraph("Week");
            rowpage66.Cells[0].AddParagraph("18-24");
            rowpage66.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowpage66.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowpage66.Cells[0].Format.Font.Bold = true;
            rowpage66.Cells[0].Format.Font.Size = 11;
            paragraph = rowpage66.Cells[1].AddParagraph();
            paragraph.AddFormattedText("Installation", TextFormat.Bold);
            paragraph.AddLineBreak();
            rowpage66.Cells[1].AddParagraph("We require a further 4-7 weeks (depending on the number of stops)");
            rowpage66.Cells[1].AddParagraph("1. Written acceptance of lift is required at completion of lift installation.");
            rowpage66.Cells[1].AddParagraph("2. Final balance is to be paid in progress payments to lift completion and prior to lift being passed into service."
            + " If the lift cannot be passed into service due to outstanding builder’s works, payment of the final contract balance less $500 is required. Final payment of $500 shall be made at handover.");
            rowpage66.Cells[1].Format.Font.Size = 10;
            rowpage66.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            paragraph = rowpage66.Cells[2].AddParagraph();
            paragraph.AddFormattedText("Payment:", TextFormat.Bold);
            paragraph.AddText(" Balance");
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("Amount Payable:", TextFormat.Bold);
            paragraph.AddText("20%  of the contract value");
            rowpage66.Cells[2].Format.Font.Size = 10;
            rowpage66.Cells[2].Format.Alignment = ParagraphAlignment.Left;

            Row rowpage67 = table.AddRow();
            rowpage67.Format.Alignment = ParagraphAlignment.Center;
            rowpage67.Cells[0].AddParagraph("Week");

            rowpage67.Cells[0].AddParagraph("21-24");
            rowpage67.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowpage67.Cells[0].VerticalAlignment = VerticalAlignment.Top;
            rowpage67.Cells[0].Format.Font.Bold = true;
            rowpage67.Cells[0].Format.Font.Size = 11;
            rowpage67.Cells[1].AddParagraph("Completion ");
            rowpage67.Cells[1].Format.Font.Bold = true;


            rowpage67.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            rowpage67.Cells[2].AddParagraph("");

            rowpage67.Cells[2].Format.Font.Size = 11;
            rowpage67.Cells[2].Format.Alignment = ParagraphAlignment.Left;

            Row rowpage68 = table.AddRow();
            rowpage68.Format.Alignment = ParagraphAlignment.Center;
            rowpage68.Cells[0].AddParagraph("  Please note: Time frames exclude Christmas and European August (approx 3 weeks) shutdown periods.");
            rowpage68.Cells[0].MergeRight = 2;

            paragraph = section.AddParagraph("Interest applies on all overdue payments at the applicable cash rate + 3% as published by Westpac Banking Corporation Corporation and any fluctuation in foreign currency that has occurred.");
            paragraph.Format.Font.Size = 9;
            paragraph.Format.Font.Italic = true;
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("STORAGE");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph();
            paragraph.AddFormattedText("**Overseas:", TextFormat.Bold);
            paragraph.AddText("Should your project or payments be delayed, transport and storage costs for completed equipment required to be stored at the overseas factory are payable at a rate of $250+GST per lift, per week.");
            paragraph.Format.Font.Size = 10;
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph();
            paragraph.AddFormattedText("***Local:", TextFormat.Bold);
            paragraph.AddText(" If you cannot accept delivery of the lift equipment on site when it clears customs, we must arrange storage and insurance on your behalf for an additional $250+GST per lift, per week. Space is limited and is not always available. An additional delivery charge also applies because we have delivered your equipment twice (Once to the storage facility and once to site) this extra charge is $995.00+GST per lift, for capital city metropolitan areas and TBA for any other regional location.");
            paragraph.Format.Font.Size = 10;
            document.LastSection.AddPageBreak();


            // --------------------------PAGE 7---------------------------------------------------- 

            paragraph = section.AddParagraph("Dear Customer, please take a few moments to complete the form below");
            paragraph = section.AddParagraph();

            paragraph = section.AddParagraph("Quote Number: " + " " + "P" + model.id + "-" + lVGquote.id);
            paragraph.Format.Font.Bold = true;
            paragraph = section.AddParagraph();
            paragraph.AddText("Project Name: " + model.ProjectName);
            paragraph.Format.SpaceAfter = 12;
            paragraph.Format.Font.Bold = true;
            paragraph = section.AddParagraph("FULL DETAILS OF CUSTOMER");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;

            paragraph = section.AddParagraph();
            table = section.AddTable();
            table.Style = "Table2";
            // table.Borders.Width = 0.75;
            //table.Borders.Left.Width = 0;
            //table.Borders.Right.Width = 0;
            //table.Borders.Top.Width = 0;
            //table.Rows.LeftIndent = 0;

            Column columnCustomerDetail = table.AddColumn("7cm");
            columnCustomerDetail.Format.Alignment = ParagraphAlignment.Center;

            columnCustomerDetail = table.AddColumn("13cm");
            columnCustomerDetail.Format.Alignment = ParagraphAlignment.Left;
            columnCustomerDetail.Borders.Width = 0.75;
            columnCustomerDetail.Borders.Left.Width = 0;
            columnCustomerDetail.Borders.Right.Width = 0;
            columnCustomerDetail.Borders.Top.Width = 0;

            Row rowCustomerDetail = table.AddRow();
            rowCustomerDetail.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail.Cells[0].AddParagraph("Contact Name:");
            rowCustomerDetail.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail.Cells[1].AddParagraph("" + (model.ContactName == null ? "" : model.ContactName));
            rowCustomerDetail.Cells[1].Borders.Color = Colors.Black;
            rowCustomerDetail.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            Row rowCustomerDetail1 = table.AddRow();
            rowCustomerDetail1.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail1.Cells[0].AddParagraph("Registered Name of Company:");
            rowCustomerDetail1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail1.Cells[1].AddParagraph("");
            rowCustomerDetail1.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowCustomerDetail2 = table.AddRow();
            rowCustomerDetail2.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail2.Cells[0].AddParagraph("Trading Name:");
            rowCustomerDetail2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail2.Cells[1].AddParagraph("" + (model.Company == null ? "" : model.Company));
            rowCustomerDetail2.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowCustomerDetail3 = table.AddRow();
            rowCustomerDetail3.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail3.Cells[0].AddParagraph("Address:");
            rowCustomerDetail3.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail3.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail3.Cells[1].AddParagraph("");
            rowCustomerDetail3.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowCustomerDetail4 = table.AddRow();
            rowCustomerDetail4.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail4.Cells[0].AddParagraph("Mobile Number:");
            rowCustomerDetail4.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail4.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail4.Cells[1].AddParagraph("");
            rowCustomerDetail4.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowCustomerDetail5 = table.AddRow();
            rowCustomerDetail5.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail5.Cells[0].AddParagraph("Phone Number:");
            rowCustomerDetail5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail5.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail5.Cells[1].AddParagraph("" + (model.Phone == null ? "" : model.Phone));
            rowCustomerDetail5.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowCustomerDetail6 = table.AddRow();
            rowCustomerDetail6.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail6.Cells[0].AddParagraph("Fax Number:");
            rowCustomerDetail6.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail6.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail6.Cells[1].AddParagraph("");
            rowCustomerDetail6.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowCustomerDetail7 = table.AddRow();
            rowCustomerDetail7.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail7.Cells[0].AddParagraph("Email Address for Invoices/Statements:");
            rowCustomerDetail7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail7.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail7.Cells[1].AddParagraph("" + (model.Email == null ? "" : model.Email));
            rowCustomerDetail7.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowCustomerDetail8 = table.AddRow();
            rowCustomerDetail8.Format.Alignment = ParagraphAlignment.Center;
            rowCustomerDetail8.Cells[0].AddParagraph("Contact Name for Accounts:");
            rowCustomerDetail8.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowCustomerDetail8.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowCustomerDetail8.Cells[1].AddParagraph("");
            rowCustomerDetail8.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph("PROJECT SITE RELATED DETAILS");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;

            table = section.AddTable();
            table.Style = "Table2";

            Column columnSiteDetail = table.AddColumn("7cm");
            columnSiteDetail.Format.Alignment = ParagraphAlignment.Center;

            columnSiteDetail = table.AddColumn("13cm");
            columnSiteDetail.Format.Alignment = ParagraphAlignment.Left;
            columnSiteDetail.Borders.Width = 0.75;
            columnSiteDetail.Borders.Left.Width = 0;
            columnSiteDetail.Borders.Right.Width = 0;
            columnSiteDetail.Borders.Top.Width = 0;

            Row rowSiteDetail = table.AddRow();
            rowSiteDetail.Format.Alignment = ParagraphAlignment.Center;
            rowSiteDetail.Cells[0].AddParagraph("Site Contact Name:");
            rowSiteDetail.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowSiteDetail.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowSiteDetail.Cells[1].AddParagraph("");
            rowSiteDetail.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowSiteDetail1 = table.AddRow();
            rowSiteDetail1.Format.Alignment = ParagraphAlignment.Center;
            rowSiteDetail1.Cells[0].AddParagraph("Job Title:");
            rowSiteDetail1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowSiteDetail1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowSiteDetail1.Cells[1].AddParagraph("");
            rowSiteDetail1.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            Row rowSiteDetail2 = table.AddRow();
            rowSiteDetail2.Format.Alignment = ParagraphAlignment.Center;
            rowSiteDetail2.Cells[0].AddParagraph("Company Name:");
            rowSiteDetail2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowSiteDetail2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowSiteDetail2.Cells[1].AddParagraph("");
            rowSiteDetail2.Cells[1].Format.Alignment = ParagraphAlignment.Justify;



            Row rowSiteDetail4 = table.AddRow();
            rowSiteDetail4.Format.Alignment = ParagraphAlignment.Center;
            rowSiteDetail4.Cells[0].AddParagraph("Mobile Number:");
            rowSiteDetail4.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowSiteDetail4.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowSiteDetail4.Cells[1].AddParagraph("");
            rowSiteDetail4.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            Row rowSiteDetail5 = table.AddRow();
            rowSiteDetail5.Format.Alignment = ParagraphAlignment.Center;
            rowSiteDetail5.Cells[0].AddParagraph("Phone Number:");
            rowSiteDetail5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowSiteDetail5.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowSiteDetail5.Cells[1].AddParagraph("");
            rowSiteDetail5.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            Row rowSiteDetail6 = table.AddRow();
            rowSiteDetail6.Format.Alignment = ParagraphAlignment.Center;
            rowSiteDetail6.Cells[0].AddParagraph("Fax Number:");
            rowSiteDetail6.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowSiteDetail6.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowSiteDetail6.Cells[1].AddParagraph("");
            rowSiteDetail6.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            Row rowSiteDetail7 = table.AddRow();
            rowSiteDetail7.Format.Alignment = ParagraphAlignment.Center;
            rowSiteDetail7.Cells[0].AddParagraph("Email Address:");
            rowSiteDetail7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowSiteDetail7.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowSiteDetail7.Cells[1].AddParagraph("");
            rowSiteDetail7.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph("OTHER CONTACTS");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("CONTACT 1");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;

            table = section.AddTable();
            table.Style = "Table2";



            Column columnOtherDetail = table.AddColumn("7cm");
            columnOtherDetail.Format.Alignment = ParagraphAlignment.Center;

            columnOtherDetail = table.AddColumn("13cm");
            columnOtherDetail.Format.Alignment = ParagraphAlignment.Left;
            columnOtherDetail.Borders.Width = 0.75;
            columnOtherDetail.Borders.Left.Width = 0;
            columnOtherDetail.Borders.Right.Width = 0;
            columnOtherDetail.Borders.Top.Width = 0;


            Row rowOtherDetail = table.AddRow();
            rowOtherDetail.Format.Alignment = ParagraphAlignment.Center;
            rowOtherDetail.Cells[0].AddParagraph("Contact Name:");
            rowOtherDetail.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowOtherDetail.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowOtherDetail.Cells[1].AddParagraph("");
            rowOtherDetail.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowOtherDetail1 = table.AddRow();
            rowOtherDetail1.Format.Alignment = ParagraphAlignment.Center;
            rowOtherDetail1.Cells[0].AddParagraph("Job Title:");
            rowOtherDetail1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowOtherDetail1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowOtherDetail1.Cells[1].AddParagraph("");
            rowOtherDetail1.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowOtherDetail2 = table.AddRow();
            rowOtherDetail2.Format.Alignment = ParagraphAlignment.Center;
            rowOtherDetail2.Cells[0].AddParagraph("Company Name:");
            rowOtherDetail2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowOtherDetail2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowOtherDetail2.Cells[1].AddParagraph("");
            rowOtherDetail2.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            Row rowOtherDetail4 = table.AddRow();
            rowOtherDetail4.Format.Alignment = ParagraphAlignment.Center;
            rowOtherDetail4.Cells[0].AddParagraph("Mobile Number:");
            rowOtherDetail4.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowOtherDetail4.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowOtherDetail4.Cells[1].AddParagraph("");
            rowOtherDetail4.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowOtherDetail5 = table.AddRow();
            rowOtherDetail5.Format.Alignment = ParagraphAlignment.Center;
            rowOtherDetail5.Cells[0].AddParagraph("Phone Number:");
            rowOtherDetail5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowOtherDetail5.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowOtherDetail5.Cells[1].AddParagraph("");
            rowOtherDetail5.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowOtherDetail7 = table.AddRow();
            rowOtherDetail7.Format.Alignment = ParagraphAlignment.Center;
            rowOtherDetail7.Cells[0].AddParagraph("Email Address:");
            rowOtherDetail7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowOtherDetail7.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowOtherDetail7.Cells[1].AddParagraph("");
            rowOtherDetail7.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            paragraph = section.AddParagraph();
            paragraph = section.AddParagraph("CONTACT 2");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;

            table = section.AddTable();
            table.Style = "Table2";



            Column columnContactDetail = table.AddColumn("7cm");
            columnContactDetail.Format.Alignment = ParagraphAlignment.Center;

            columnContactDetail = table.AddColumn("13cm");
            columnContactDetail.Format.Alignment = ParagraphAlignment.Left;
            columnContactDetail.Borders.Width = 0.75;
            columnContactDetail.Borders.Left.Width = 0;
            columnContactDetail.Borders.Right.Width = 0;
            columnContactDetail.Borders.Top.Width = 0;

            Row rowContactDetail = table.AddRow();
            rowContactDetail.Format.Alignment = ParagraphAlignment.Center;
            rowContactDetail.Cells[0].AddParagraph("Contact Name:");
            rowContactDetail.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowContactDetail.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowContactDetail.Cells[1].AddParagraph("");
            rowContactDetail.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowContactDetail1 = table.AddRow();
            rowContactDetail1.Format.Alignment = ParagraphAlignment.Center;
            rowContactDetail1.Cells[0].AddParagraph("Job Title:");
            rowContactDetail1.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowContactDetail1.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowContactDetail1.Cells[1].AddParagraph("");
            rowContactDetail1.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowContactDetail2 = table.AddRow();
            rowContactDetail2.Format.Alignment = ParagraphAlignment.Center;
            rowContactDetail2.Cells[0].AddParagraph("Company Name:");
            rowContactDetail2.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowContactDetail2.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowContactDetail2.Cells[1].AddParagraph("");
            rowContactDetail2.Cells[1].Format.Alignment = ParagraphAlignment.Justify;


            Row rowContactDetail4 = table.AddRow();
            rowContactDetail4.Format.Alignment = ParagraphAlignment.Center;
            rowContactDetail4.Cells[0].AddParagraph("Mobile Number:");
            rowContactDetail4.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowContactDetail4.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowContactDetail4.Cells[1].AddParagraph("");
            rowContactDetail4.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowContactDetail5 = table.AddRow();
            rowContactDetail5.Format.Alignment = ParagraphAlignment.Center;
            rowContactDetail5.Cells[0].AddParagraph("Phone Number:");
            rowContactDetail5.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowContactDetail5.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowContactDetail5.Cells[1].AddParagraph("");
            rowContactDetail5.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            Row rowContactDetail7 = table.AddRow();
            rowContactDetail7.Format.Alignment = ParagraphAlignment.Center;
            rowContactDetail7.Cells[0].AddParagraph("Email Address:");
            rowContactDetail7.Cells[0].Format.Alignment = ParagraphAlignment.Left;
            rowContactDetail7.Cells[0].VerticalAlignment = VerticalAlignment.Bottom;
            rowContactDetail7.Cells[1].AddParagraph("");
            rowContactDetail7.Cells[1].Format.Alignment = ParagraphAlignment.Justify;

            // --------------------------PAGE 8 -  WORKS BY OTHERS  ---------------------------------------------------- 

            document.LastSection.AddPageBreak();
            Image image4 = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\logo\\WBO Tick box.jpg"));
            image4.Height = "3.5cm";
            //image2.Width = "1cm";
            image4.LockAspectRatio = true;
            image4.RelativeVertical = RelativeVertical.Line;
            image4.RelativeHorizontal = RelativeHorizontal.Margin;
            image4.Left = ShapePosition.Right;
            image4.WrapFormat.Style = WrapStyle.Through;
            paragraph = section.AddParagraph("WORKS BY OTHERS CHECKLIST");
            paragraph.Format.Font.Name = "Tahoma";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph.Format.Alignment = ParagraphAlignment.Justify;
            paragraph = section.AddParagraph("THE FOLLOWING ITEMS ARE YOUR RESPONSIBILTY");
            paragraph.Format.Font.Name = "Tahoma";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph.Format.Alignment = ParagraphAlignment.Justify;
            paragraph.Format.SpaceAfter = 12;
            paragraph = section.AddParagraph("What you have to do for us to make your Project a success.....");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Alignment = ParagraphAlignment.Left;
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("1. APPROVED DRAWING");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("1.1 Build to your Approved Drawing only");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Do not build to the “Not for Construction” drawing provided at sales stage, or any preliminary dimensions shown in brochures, architectural details etc."); // 2.4 Lift Type
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("1.2 All vertical dimensions on our drawings are from Finished Floor Level (FFL)");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Are critical and those noted on the site specific drawing must be adhered to. Ensure any rough opening heights are calculated from FFL. A typical construction problem occurs if rough openings are measured from the SFL and not considering floor finishes in measurement calculations.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.AddLineBreak();
            paragraph.AddFormattedText(lVGquote.LiftType + " (masonary shaft) Vertical Travel:", TextFormat.Bold); // Dimension is critical to +/- 25mm changes as per lift type KAREN
            paragraph.AddText("Dimension is critical to +/- 25mm");
            paragraph.AddLineBreak();
            paragraph.AddFormattedText(lVGquote.LiftType + " (Shaft Structure) Vertical Travel:", TextFormat.Bold); // Dimension is critical to +/- 25mm changes as per lift type KAREN
            paragraph.AddText("Dimension is critical to +/- 4mm");
            //paragraph = section.AddParagraph("1.3 If you make a mistake or change anything:");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("If you change anything, the drawing will need to be re-issued and additional costs will apply both in re-drawing and equipment costs. Your project will also be delayed. If you realise you have made a mistake and not built to the approved drawing, stop immediately and get clarification.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            paragraph.Format.SpaceAfter = 12;

            //paragraph = section.AddParagraph("2. PAYMENTS");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 14;
            //paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            //paragraph = section.AddParagraph("2.1 Pay your site delivery payment on time");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("We will not deliver without receipt of your site delivery payment.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            //paragraph = section.AddParagraph("2.2 Pay your final payment upon our completion");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("If the lift cannot be passed into service due to outstanding builder’s works, payment of the final contract balance less $500 is required. Final payment of $500 shall be made at handover.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            //paragraph = section.AddParagraph("2.3 Paying on time avoids price rises");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("Our fixed price is based on the program and payments provided in our quotation. If you do not pay on time we will charge penalty interest on late payments and any fluctuation in foreign currency that has occurred.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            //paragraph.Format.SpaceAfter = 12;

            //paragraph = section.AddParagraph("3. MANUFACTURE");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 14;
            //paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            //paragraph = section.AddParagraph("3.1 Placement of elevator into production/manufacture");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("Client/builder is responsible for ensuring the lift is placed into production on time to meet their schedule.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            //paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("2. DELIVERY & STORAGE");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("2.1 Site access and OHS");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Provide appropriate site access in full compliance with current Occupational Health and Safety requirements. " +
                "Clear level access for delivery by tailgate loader or crane truck must be provided with access into the storage area by pallet jack. " +
                "Extra cost will be incurred for non-standard delivery.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            //paragraph = section.AddParagraph("4.2 Site access and OHS");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("Provide appropriate site access in full compliance with current Occupational Health and Safety requirements. " +
            //                     " Clear level access for delivery by tailgate loader or crane truck must be provided with access into the storage area by pallet jack. Extra cost will be incurred for non-standard delivery.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("2.2 Hoisting Facilities");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("If delivery is difficult, we may need assistance from a crane or all terrain forklift to be provided by client. At no cost to ELHE.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 10.5;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("2.3 Site Storage Area");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Provide dry, clean and safe storage of the lift equipment on site. The location of the storage area shall be agreed with ELHE and be close to the lift shaft and machine room. The storage area required is equivalent to approximately one car space per lift + tower boxes if applicable.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("2.4 Insurance");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Client/Builder is responsible for lift equipment & insurance once delivered to site.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.Format.SpaceAfter = 12;
            //document.LastSection.AddPageBreak();

            paragraph = section.AddParagraph("3. LIFT SHAFT");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("3.1 Build the shaft plumb, flush & square");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("To your approved drawings. It is reasonable for ELHE (Easy Living Home Elevators) to claim additional cost for works required due to incorrect building works.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.2 Weather Proofing");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("We require the shaft, all landing entrances and the controller location to be weather proof prior to our commencement. The controller is not provided with a waterproof enclosure. The workspace in front of the controller is also required to be covered and sheltered from the weather.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.3 Scaffolding");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Lift shaft scaffolding to internal and/or external of lift shaft or tower to be supplied with SWL of 250kg at each floor served. At no cost to ELHE. Position to be confirmed by ELHE representative");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.4 Load bearing wall(s)");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Must be either poured concrete, OR pre-cast concrete OR core filled reinforced block OR steel columns as designed by a structural engineer. ");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("Cavity brick walls are not suitable. Loads are shown on our layout drawing.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.5 Non load bearing walls");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Can be timber or metal stud construction provided this method is engineer approved. You must provide a smooth finish internally with plasterboard or 6mm Villaboard.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.6 Steel Column Supports Instead of Block/Masonry");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Must be approved by your engineer, including the fixing points at pit, floors and headroom. Columns supplied by others and installed inside wall cavity. (Sample engineering steel design from ELHE upon request)");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.7 Glass installed in the Lift Shaft");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Must be 10.76 laminated and fitted flush with the inside face of the lift shaft. To comply with AS1735 (not AS1288)");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            document.LastSection.AddPageBreak();
            paragraph = section.AddParagraph("3.8 Lift Pit");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Must be kept dry. No seepage or damp areas are allowed. This is a safety requirement and will affect the long-term condition of the equipment. No drainage is required in the pit. If a drain is present, it must have a non-return valve fitted. If a pit is not provided the builder must provide a ramp. Ramp must comply with BCA access requirements.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.9 Shaft & Pit Finish");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("A smooth and plumb surface shall be provided. Ensure shaft and pit is dry, stripped, cleaned, holes patched and free of construction debris and formwork nails or other protrusions prior to our start on site. Note pit dimensions is from FFL.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.10 Shaft Roof");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Must be a solid, non-perforated material, permanently fixed from the inside of the shaft and of sufficient strength to support the weight of a person, nominally 120kg. The lift shaft must not open into a roof space or, for flat roofs; removal of a roofing sheet shall not expose the open top of a lift shaft and therefore a fall risk for the person working on the roof. ");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("3.11 Shaft Protection Barricades");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("must be supplied, installed and maintained to each lift entrance or penetrations through floors. Cages are required for commercial jobs.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("4. ELECTRICAL REQUIREMENTS");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("4.1 Core Holes");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("We require core holes in positions indicated by your ELHE Representative. Typically this core hole is 100mm diameter. Patching and/making good to this core hole is by the builder if required. ");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            //paragraph.Format.SpaceAfter = 12;
            //paragraph.AddFormattedText(lVGquote.LiftType, TextFormat.Bold);
            //paragraph.AddText(": The location of this core hole shall be 315mm from FFL to the RHS of the " + lVGquote.LiftType + " control cabinet."); // THis will change as per lift type KAREN
            //document.LastSection.AddPageBreak();
            paragraph = section.AddParagraph("4.2 Other services in the Lift shaft");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Other services are not permitted in the lift shaft.(Examples: storm water pipes, cable TV, security wiring) ");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";

            paragraph = section.AddParagraph("4.3 Conduits");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Any conduits intended to carry lift cabling or hydraulic hoses from controller cabinet to lift shaft must be 100mm diameter minimum and include sweep bends (3 x 30 degree or 2 x 45 degree) not 90 degree elbows.");// 100mm diameter to be changed as per lift type
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.AddLineBreak();
            paragraph.AddFormattedText("For Conduits coming up into the slab:", TextFormat.Bold);
            paragraph.AddText("Note preferred locations and exclusion zone in diagram below.");
            //paragraph.Format.SpaceAfter = "6cm";
            Image image5 = section.AddImage(HttpContext.Current.Server.MapPath("~\\Content\\logo\\WBO diagram.jpg"));
            image5.Height = "6cm";
            //image2.Width = "1cm";
            image5.LockAspectRatio = true;
            image5.RelativeVertical = RelativeVertical.Line;
            image5.RelativeHorizontal = RelativeHorizontal.Margin;
            image5.Left = ShapePosition.Center;
            //image5.WrapFormat.Style = WrapStyle.Through;
            paragraph = section.AddParagraph("4.4 Power Requirements" + lVGquote.LiftType);
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("We require permanent single phase power rated at " + lVGquote.Power + " for the " + lVGquote.LiftType + "left to lock off isolator at the controller location.  Power must be active for installation of lift.");//Change Lift type & amps
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("4.5 Lighting");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("There must be lighting to the area that contains the controller cabinet.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("4.6 Phone Point & Eagle Controller (if applicable):");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Provide single separate  telephone point and/or ethernet plug for remote diagnostics and monitoring (Eagle Controller only) within 250mm of the location of the lift controller drive cabinet."
            + "It may be an extension to the main house line in single private residences only. In all other applications a separate dedicated phone line must be provided."
             + "All connection charges and line rental is by the builder/owner, these are not included by ELHE");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            //paragraph = section.AddParagraph("6.7 Eagle Controller (if applicable)");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("Provide ethernet plug for remote diagnostics and monitoring within 250mm of the location of the lift controller drive cabinet. It may be an extension to the main house line in single private residences only."
            //    + "n all other applications a separate dedicated line must be provided. All usage and connection charges is by the builder/owner, these are not included by ELHE.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            //paragraph.AddLineBreak();
            //paragraph.AddFormattedText("WiFi Connection:", TextFormat.Bold);
            //paragraph.AddText("Is required for onsite testing and using the iphone application as a remote control for the lift.");
            paragraph = section.AddParagraph("4.7 Fire Rating");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Fire rated lift sub-mains are required for all installations other than a private home");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("5. LIFT BUTTONS & DOORS");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("5.1 Landing Buttons");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Are typically located within the frame but if installed onto a wall, the landing button finishing is by builder.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            document.LastSection.AddPageBreak();
            paragraph = section.AddParagraph("5.2 Making Good");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Building in and/or making good to lift doorframes, penetrations and floor sills. Finishing of nibs back to door frame by builder after door installation.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("5.3 Glass Door");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("For clear or tinted glass landing doors, the inside of the shaft is visible when the lift is away from that floor & requires finishing (paint, render, bagging etc)");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.AddFormattedText("Note:", TextFormat.Bold | TextFormat.Italic);
            paragraph.AddFormattedText("Overall shaft size must be maintained.", TextFormat.Italic);
            paragraph = section.AddParagraph("5.4 Door Opening Sides");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Lift shaft to be smooth & finished on door opening side(s) to within 3mm.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("5.5 Doors Exposed To Weather");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Landing doors are not and cannot be made waterproof. An awning and protection against wind driven rain is required where the lift doors are located in the open.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("6. CONTROL CABINET");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("6.1 Location of control cabinet:");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("At lowest floor. The control and pump system can be located at alternate floor to that noted above however further calculations are required; please consult ELHE. Locked, finish painted cabinet (in cream colour) is supplied by ELHE. Cabinet is not fire rated or weather proof.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.AddFormattedText("Note:", TextFormat.Bold | TextFormat.Italic);
            paragraph.AddFormattedText("Cabinet is not fire rated.", TextFormat.Italic);
            paragraph = section.AddParagraph("6.2 Machine Room Requirements (commercial/public access applications only)");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("If machine room is provided, supply and install fire door with closer and night-type latch to the lift machine room entrance. Minimum door dimension is 900mm x 2000mm clear. The door must open outwards from the lift machine room.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("6.3 Control Cabinet Access");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Clear permanent access of 600mm wide X 2000mm high must be provided in front of the lift control cabinet.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.Format.SpaceAfter = 12;

            //document.LastSection.AddPageBreak();
            paragraph = section.AddParagraph("7. GENERAL");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("7.1 Lift Car Flooring");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Where lift car flooring is not provided by ELHE, you must provide a 6mm aluminium plate floor for ELHE to fit prior to installation of floor finish. Dimensions to be provided by ELHE.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.2 Owner Supplied Flooring");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Maximum thickness is 15mm including fixing medium.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.3 Safety Requirements");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Parts of the lift equipment move when operating and must be painted yellow. These are visible through glass doors or glass tower structure panels; they cannot be painted another colour.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.4 Timing");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph(" Your lift contains sophisticated electronic computer equipment as well as other systems sensitive to atmospheric dust and moisture. The lift should be installed as late as practicable in the construction program to ensure a reliable finished product. A “rule of thumb” is that commencement of the lift installation should coincide with commencement of the interior painting contractor.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.5 Use as a Builders Lift/Hoist");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Use as a builders lift or hoist is not recommended and voids any warranty for parts and labour.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.6 Access Key Safe");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Builder to provide suitable location, we will supply and install a key safe, to permit 24 hour access in the event of lift fault. Final location to be confirmed by us.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.7 Signage");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("We would like to erect an advertising sign on site");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.8 Rubbish removal ");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Your purchase price includes packaging. This means it is yours to dispose of. We are happy to dispose of the lift packaging into your site bins. Rubbish removal from the site is the responsibility of the client/builder");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.9 Acceptance of finishes through sign-off");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("We require the lift doors and cabin finishes to be accepted via sign-off after installation – not at the end of the project. If inspection of lift finishes check list is not signed off then client /builder accepts the finishes.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("7.10 Installation start date");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Pre-installation checklists are required to be completed once lift shaft associated works are complete. Once all items are finalised and checked an installation start date is scheduled and typically is between 3 and 6 weeks after receipt of this paperwork.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph.Format.SpaceAfter = 12;

            document.LastSection.AddPageBreak();
            paragraph = section.AddParagraph("8. WORKS TO ADD FOR TOWER STRUCTURES & TOP HATS");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 14;
            paragraph.Format.Font.Color = MigraDoc.DocumentObjectModel.Colors.YellowGreen;
            paragraph = section.AddParagraph("8.1 Tower Structure");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("A suitable lift base and finish to floor penetrations must be provided prior to ELHE commencing on site. You will need to finish the lift tower prior to our completion. The tower structure is of standard design and is suitable to support the lift only and cannot be used as a structural member for the surrounding building."
                + "clear or tinted glass in the tower means that all workings of the lift are visible. In some cases of extended travel and/or limited fixing points, use of a steel tower may be required, POA");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("8.2 Fixings");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Fixings are required in the pit, each landing entrance and at the top of the shaft tower. At the top of the tower, suitable points must be provided to fix to. These points need to be allowed for in the building design (Max span 3.5m)");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("8.3 Cross Bracing");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("For indoor tower structures internal “cross” bracing may be required. For outside tower structures internal “diagonal cross” bracing for wind resistance will be required. This is provided by ELHE and subject to factory engineering conditions.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("8.4 Fixed Against Wall");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("The wall must be plumb to +/-10mm in total, subject to a site visit and measure.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            //paragraph = section.AddParagraph("8.5 Tolerance ");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("Tolerance of vertical floor to floor heights is +/-4mm from FFL.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            paragraph = section.AddParagraph("8.5 Through A Floor");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("Where the tower structure runs through a floor, we require: 35mm clearance on each side and a maximum of 10mm on the door side.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            //paragraph.AddLineBreak();
            //paragraph.AddFormattedText("Single Entry Towers:", TextFormat.Bold);
            //paragraph.AddText("35mm clearance on each side and a maximum of 10mm on the door side.");
            //paragraph.AddLineBreak();
            //paragraph.AddFormattedText("Adjacent or Through Entry Towers:", TextFormat.Bold);
            //paragraph.AddText("35mm clearance on each side and a maximum of 10mm on the door side.");
            paragraph = section.AddParagraph("8.6 Exposed To Weather");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph = section.AddParagraph("The lift tower and landing doors are weather resistant and not waterproof. Where the tower structure is exposed to weather, an awning should be fitted over the tower and landing the entrances. This is to protect the landing doors from weather. It is the client/builders responsibility to seal around the shaft and pit.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Size = 11;
            paragraph.Format.LeftIndent = "0.6cm";
            //paragraph = section.AddParagraph("10.8 Overhead Ceiling ");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("Where there is an overhead ceiling, a recess of 130mm high x the width of the tower + 70mm x depth of the tower + 70mm is required. This recess must have a top of sufficient strength to support 120kg and can support the top of the tower loads.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            //paragraph = section.AddParagraph("10.9 Scaffolding");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph = section.AddParagraph("Lift shaft scaffolding for tower structures is required to be provided to both internal and external of lift tower at no cost to ELHE. This is to be supplied by the builder with SWL of 250kg at each floor served and to ELHE specifications.");
            //paragraph.Format.Font.Name = "Calibri";
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.LeftIndent = "0.6cm";
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("Please contact your local Project Management office for any information you need about getting your lift shaft construction right. We have experienced lift technicians on hand to answer your questions.");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Italic = true;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = 12;
            paragraph.AddLineBreak();
            paragraph = section.AddParagraph("");

            paragraph.AddFormattedText("The above is hereby understood and accepted:", TextFormat.Bold);
            paragraph = section.AddParagraph("");
            paragraph.Format.SpaceAfter = 12;

            paragraph = section.AddParagraph("Signed:_________________________________________________   Date:_______________");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = 15;
            paragraph = section.AddParagraph("Print Name_____________________________________________");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = 15;
            paragraph = section.AddParagraph("For and on behalf of (company)__________________________________________________");
            paragraph.Format.Font.Name = "Calibri";
            paragraph.Format.Font.Bold = true;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.SpaceAfter = 15;


            //paragraph = section.AddParagraph("Door Operation:"); //2.6
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.SpaceAfter = 2;
            //paragraph = section.AddParagraph(" Car Door Finish"); // 2.7
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.SpaceAfter = 2;
            //paragraph = section.AddParagraph("Front Entrance"); // 4.8
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.SpaceAfter = 2;
            //paragraph = section.AddParagraph("Rear/Adj Entrance"); // 4.8
            //paragraph.Format.Font.Size = 11;
            //paragraph.Format.SpaceAfter = 2;

            //paragraph = section.AddParagraph("Landing Doors :"); // 2.1
            //paragraph.Format.Font.Bold = true;
            //paragraph.Format.Font.Size = 12;
            //paragraph.Format.Font.Italic = true;
            //paragraph.Format.SpaceAfter = 3;


        }

        static void FillContent()
        {
            //Paragraph paragraph = addressFrame.AddParagraph();
            ////paragraph.AddText("IGV PRODUCT:");
            ////paragraph.AddLineBreak();
            ////paragraph.AddText("CUSTOMER ENQUIRY FORM");
            ////paragraph.AddLineBreak();



            //double totalExtendedPrice = 0;
            //double quantity = 23.00;
            //double price = 23.0;
            //double discount = 2445.00;


            //Row row1 = table.AddRow();
            //Row row2 = table.AddRow();
            //row1.TopPadding = 1.5;
            ////                row1.Cells[0].Shading.Color = TableGray;
            //row1.Cells[0].VerticalAlignment = VerticalAlignment.Center;
            //row1.Cells[0].MergeDown = 1;
            //row1.Cells[1].Format.Alignment = ParagraphAlignment.Left;
            //row1.Cells[1].MergeRight = 3;
            ////                row1.Cells[5].Shading.Color = TableGray;
            //row1.Cells[5].MergeDown = 1;

            //row1.Cells[0].AddParagraph("-");

            //paragraph = row1.Cells[1].AddParagraph();
            //paragraph.AddFormattedText("Model ");
            //paragraph.AddFormattedText(" - ", TextFormat.Italic);
            //paragraph.AddText("1C/4");
            //row2.Cells[1].AddParagraph("Load Bearing wall");
            //row2.Cells[2].AddParagraph(price.ToString("0.00") + " $");
            //row2.Cells[3].AddParagraph(discount.ToString("0.0"));
            //row2.Cells[4].AddParagraph();
            //row2.Cells[5].AddParagraph(price.ToString("0.00"));
            //double extendedPrice = quantity * price;
            //extendedPrice = extendedPrice * (100 - discount) / 100;
            //row1.Cells[5].AddParagraph(extendedPrice.ToString("0.00") + " $");
            //row1.Cells[5].VerticalAlignment = VerticalAlignment.Bottom;
            //totalExtendedPrice += extendedPrice;

            //table.SetEdge(0, table.Rows.Count - 2, 6, 2, Edge.Box, BorderStyle.Single, 0.75);

            //Row row = table.AddRow();
            //row.Borders.Visible = false;

            //row = table.AddRow();
            //row.Cells[0].Borders.Visible = false;
            //row.Cells[0].AddParagraph("Qouted Price");
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            //row.Cells[0].MergeRight = 4;
            //row.Cells[5].AddParagraph(totalExtendedPrice.ToString("0.00") + " $");

            //// Add the VAT row
            //row = table.AddRow();
            //row.Cells[0].Borders.Visible = false;
            //row.Cells[0].AddParagraph("Margin");
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            //row.Cells[0].MergeRight = 4;
            //row.Cells[5].AddParagraph((0.19 * totalExtendedPrice).ToString("0.00") + " $");


            //row = table.AddRow();
            //row.Cells[0].Borders.Visible = false;
            //row.Cells[0].AddParagraph("+ GST");
            //row.Cells[5].AddParagraph(0.ToString("0.00") + " $");
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            //row.Cells[0].MergeRight = 4;


            //row = table.AddRow();
            //row.Cells[0].AddParagraph("Total ");
            //row.Cells[0].Borders.Visible = false;
            //row.Cells[0].Format.Font.Bold = true;
            //row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            //row.Cells[0].MergeRight = 4;
            //totalExtendedPrice += 0.19 * totalExtendedPrice;
            //row.Cells[5].AddParagraph(totalExtendedPrice.ToString("0.00") + " $");


            //table.SetEdge(5, table.Rows.Count - 4, 1, 4, Edge.Box, BorderStyle.Single, 0.75);

            //// Add the notes paragraph
            //paragraph = document.LastSection.AddParagraph();
            //paragraph.Format.SpaceBefore = "1cm";
            //paragraph.Format.Borders.Width = 0.75;
            //paragraph.Format.Borders.Distance = 3;
            ////  paragraph.Format.Borders.Color = TableBorder;
            ////   paragraph.Format.Shading.Color = TableGray;
            //paragraph.AddText("Notes");
        }

        private PdfDocument RenderDocument(Document document)
        {
            var rend = new PdfDocumentRenderer { Document = document };
            rend.RenderDocument();
            return rend.PdfDocument;
        }

    }
}