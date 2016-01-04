using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace KarenProject.Models
{
    public class MainQuote
    {
        public int id { get; set; }
        
        public string MyType { get; set; }

        [Display(Name="Shaft Type")]
        public string ShaftType { get; set; }

        [Display(Name = "Code Compliance")]
        public string CodeComplence { get; set; }


        public Boolean Part12 { get; set; }


        [Display(Name = "Lift Type")]
        public string LiftType { get; set; }

        [Display(Name = "No of Lifts")]
        public int NoOfLifts { get; set; }

        [Display(Name = "Entrance Type")]
        public string EntranceType { get; set; }

        [Display(Name = "Lift Model")]
        public string LiftModel { get; set; }

        [Display(Name = "Rail wall")]
        public string LoadBearingWall { get; set; }

        [Display(Name = "No. Floors/stops")]
        public int NoOfFloors { get; set; }

        [Display(Name = "Drive System")]
        public string DriveSystem { get; set; }

        
        public string Power { get; set; }
        public string Speed { get; set; }
        public string Capacity { get; set; }

        [Display(Name = "Control Cabinet size")]
        public string ConCabSize { get; set; }

        [Display(Name = "Vertical")]
        public string ConCabLocVer { get; set; }

        [Display(Name = "Horizontal")]
        public string ConCabLocHor { get; set; }


        public int Section1ModelId { get; set; }


        public string IntCarSizeWide { get; set; }
        public string IntCarSizeDeep { get; set; }

        public string ShaftSizeWide { get; set; }
        public string ShaftSizeDeep { get; set; }

        public string Door1SizeWide { get; set; }
        public string Doo1SizeDeep { get; set; }

        public string Door2SizeWide { get; set; }
        public string Door2SizeDeep { get; set; }

        [Display(Name="Car Height")]
        public int CarHeight { get; set; }
        public int Headroom { get; set; }

        public int Pit { get; set; }

        public int Travel { get; set; }

        public string FtoFStart1 { get; set; }
        public string FtoFFinish1 { get; set; }
        public string FtoFDistance1 { get; set; }

        public string FtoFStart2 { get; set; }
        public string FtoFFinish2 { get; set; }
        public string FtoFDistance2 { get; set; }

        public string FtoFStart3 { get; set; }
        public string FtoFFinish3 { get; set; }
        public string FtoFDistance3 { get; set; }

        public string FtoFStart4 { get; set; }
        public string FtoFFinish4 { get; set; }
        public string FtoFDistance4 { get; set; }


        //section 4
        [Display(Name = "LHS")]
        public string CarWallsLHS { get; set; }
        [Display(Name = "RHS")]
        public string CarWallsRHS { get; set; }
         [Display(Name = "Rear")]
        public string CarWallsRear { get; set; }

        public string Ceiling { get; set; }
        public string Floor { get; set; }
        public string Profile { get; set; }

        public String ProfileSpecial { get; set; }
        
        public int? ProfileSpecialInt { get; set; }
        
        [Display(Name = "COP")]
        public string CopType { get; set; }
        public Boolean CopLocRHS { get; set; }
        public Boolean CopLocLHS { get; set; }
        public Boolean CopLocRear { get; set; }
        public Boolean CopLocDCOP { get; set; }
         [Display(Name = "COP Button")]
        public string CopButton { get; set; }
         [Display(Name = "Handrail Type")]
        public string HandRailType { get; set; }
        public Boolean HandRailLocRHS { get; set; }
        public Boolean HandRailLocLHS { get; set; }
        public Boolean HandRailLocRear { get; set; }

        public string MirrorType { get; set; }
        public Boolean MirrorLocRHS { get; set; }
        public Boolean MirrorLocLHS { get; set; }
        public Boolean MirrorLocRear { get; set; }

        public string Phone { get; set; }

         [Display(Name = "Car Display")]
        public string CarDisplayType { get; set; }
         [Display(Name = "Landing Displays")]
        public string CarDisplayTypeLoc { get; set; }

        public Boolean AllLevels { get; set; }
        public Boolean Level1 { get; set; }
        public Boolean Level2 { get; set; }
        public Boolean Level3 { get; set; }
        public Boolean Level4 { get; set; }
        public Boolean Level5 { get; set; }
         [Display(Name = "Car Protection")]
        public string CarSafteyProtection { get; set; }

        //Extras
        public Boolean CarKeySwitch { get; set; }
        public Boolean LandingKeySwitch { get; set; }
        public Boolean Gong { get; set; }
        public Boolean VoiceSynt { get; set; }
        public Boolean RemoteControl { get; set; }
        public Boolean ShaftComRalPaint { get; set; }
        public String ShaftComRalPaintText { get; set; }
        [UIHint("NumberTemplate")]
        public int ShaftComRalPaintInt { get; set; }

        public Boolean MirrorStrip { get; set; }
        public Boolean StripLHS { get; set; }
        public Boolean StripRHS { get; set; }
        public Boolean StripRear { get; set; }

        public String NoOfStrips { get; set; }

        [Display(Name = "Notes")]
        [DataType(DataType.MultilineText)]
        public string ExtraNotes { get; set; }

        //section 5 doors

        public string FrontEntLanDoor { get; set; }
        public string FrontEntCarDoor { get; set; }
        public string FrontEntCarDoorFinish { get; set; }

        public string SecondEntLanDoor { get; set; }
        public string SecondEntCarDoor { get; set; }
        public string SecondEntCarDoorFinish { get; set; }

       
        public string DoorEntType1 { get; set; }
        public String Hinge1 { get; set; }
        
        public string LopLocation1 { get; set; }
        public string LopFinish1 { get; set; }
        public string LopButton1 { get; set; }

        public string DoorEntType2 { get; set; }
        public String Hinge2 { get; set; }
        public string LopLocation2 { get; set; }
        public string LopFinish2 { get; set; }
        public string LopButton2 { get; set; }
        public string DoorEntType3 { get; set; }
        public String Hinge3 { get; set; }
        public string LopLocation3 { get; set; }
        public string LopFinish3 { get; set; }
        public string LopButton3 { get; set; }
        public string DoorEntType4 { get; set; }
        public String Hinge4 { get; set; }
        public string LopLocation4 { get; set; }
        public string LopFinish4 { get; set; }
        public string LopButton4 { get; set; }
        public string DoorEntType5 { get; set; }
        public String Hinge5 { get; set; }
        public string LopLocation5 { get; set; }
        public string LopFinish5 { get; set; }
        public string LopButton5 { get; set; }
        public string DoorEntType6 { get; set; }
        public String Hinge6 { get; set; }
        public string LopLocation6 { get; set; }
        public string LopFinish6 { get; set; }
        public string LopButton6 { get; set; }
        public string DoorEntType7 { get; set; }
        public String Hinge7 { get; set; }
        public string LopLocation7 { get; set; }
        public string LopFinish7 { get; set; }
        public string LopButton7 { get; set; }
        public string DoorEntType8 { get; set; }
        public String Hinge8 { get; set; }
        public string LopLocation8 { get; set; }
        public string LopFinish8 { get; set; }
        public string LopButton8 { get; set; }
        public string DoorEntType9 { get; set; }
        public String Hinge9 { get; set; }
        public string LopLocation9 { get; set; }
        public string LopFinish9 { get; set; }
        public string LopButton9 { get; set; }
        public string DoorEntType10 { get; set; }
        public String Hinge10 { get; set; }
        public string LopLocation10 { get; set; }
        public string LopFinish10 { get; set; }
        public string LopButton10 { get; set; }


        public string LopButton18 { get; set; }
        public string LopButton19 { get; set; }//landing door finishes section 5

        public string LDFDoorType1 { get; set; }
        public string LDFDoorType2 { get; set; }
        public string LDFDoorType3 { get; set; }
        public string LDFDoorType4 { get; set; }
        public string LDFDoorType5 { get; set; }
        public string LDFDoorType6 { get; set; }
        public string LDFDoorType7 { get; set; }
        public string LDFDoorType8 { get; set; }
        public string LDFDoorType9 { get; set; }
        public string LDFDoorType10 { get; set; }

        public string LDFDoorFinish1 { get; set; }
        public string LDFDoorFinish2 { get; set; }
        public string LDFDoorFinish3 { get; set; }
        public string LDFDoorFinish4 { get; set; }
        public string LDFDoorFinish5 { get; set; }
        public string LDFDoorFinish6 { get; set; }
        public string LDFDoorFinish7 { get; set; }
        public string LDFDoorFinish8 { get; set; }
        public string LDFDoorFinish9 { get; set; }
        public string LDFDoorFinish10 { get; set; }

        public string LDFFrameFinish1 { get; set; }
        public string LDFFrameFinish2 { get; set; }
        public string LDFFrameFinish3 { get; set; }
        public string LDFFrameFinish4 { get; set; }
        public string LDFFrameFinish5 { get; set; }
        public string LDFFrameFinish6 { get; set; }
        public string LDFFrameFinish7 { get; set; }
        public string LDFFrameFinish8 { get; set; }
        public string LDFFrameFinish9 { get; set; }
        public string LDFFrameFinish10 { get; set; }

        public string LDFDoorHandle1 { get; set; }
        public string LDFDoorHandle2 { get; set; }
        public string LDFDoorHandle3 { get; set; }
        public string LDFDoorHandle4 { get; set; }
        public string LDFDoorHandle5 { get; set; }
        public string LDFDoorHandle6 { get; set; }
        public string LDFDoorHandle7 { get; set; }
        public string LDFDoorHandle8 { get; set; }
        public string LDFDoorHandle9 { get; set; }
        public string LDFDoorHandle10 { get; set; }

        public Boolean LDFEmbDoorClose1 { get; set; }
        public Boolean LDFEmbDoorClose2 { get; set; }
        public Boolean LDFEmbDoorClose3 { get; set; }
        public Boolean LDFEmbDoorClose4 { get; set; }
        public Boolean LDFEmbDoorClose5 { get; set; }
        public Boolean LDFEmbDoorClose6 { get; set; }
        public Boolean LDFEmbDoorClose7 { get; set; }
        public Boolean LDFEmbDoorClose8 { get; set; }
        public Boolean LDFEmbDoorClose9 { get; set; }
        public Boolean LDFEmbDoorClose10 { get; set; }

        public Boolean LDFAutoDoorOpener1 { get; set; }
        public Boolean LDFAutoDoorOpener2 { get; set; }
        public Boolean LDFAutoDoorOpener3 { get; set; }
        public Boolean LDFAutoDoorOpener4 { get; set; }
        public Boolean LDFAutoDoorOpener5 { get; set; }
        public Boolean LDFAutoDoorOpener6 { get; set; }
        public Boolean LDFAutoDoorOpener7 { get; set; }
        public Boolean LDFAutoDoorOpener8 { get; set; }
        public Boolean LDFAutoDoorOpener9 { get; set; }
        public Boolean LDFAutoDoorOpener10 { get; set; }

        //section 6

        public string TowerLocation { get; set; }
         [Display(Name = "Structure Type")]
        public string StructureType { get; set; }

        public string THPartialStructHeight { get; set; }
        [Display(Name = "Structure Finish")]
        public string StructureFinish { get; set; }
        public string CladdingLHS { get; set; }
        public string CladdingRHS { get; set; }
        public string CladdingRear { get; set; }
        public string CladdingFront { get; set; }
        public string Roof { get; set; }

        //section 7

        public string Warranty { get; set; }
        public string Servicing { get; set; }

        //section 8
       [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        [Display(Name = "Selling Price")]
      //  [RegularExpression(@"[0-9]+(\.[0-9][0-9]?)?", ErrorMessage = "Selling Price must be a natural number")]
        public string SellingPrice { get; set; }
        
        
        [Display(Name = "GST")]
        public string Gst { get; set; }
        [Display(Name = "Total Selling Price")]
      //  [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]

       // [DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:c}", ApplyFormatInEditMode = true)]
        public string TotalSellingPrice { get; set; }

       
        //public string BudgetText
        //{
        //    get
        //    {
        //        return TotalSellingPrice.HasValue ? TotalSellingPrice.ToString() : string.Empty;
        //    }
        //    set
        //    {
        //      //  BudgetText = BudgetText.Replace("$", string.Empty);
        //       // BudgetText = BudgetText.Replace(",", string.Empty);
        //        TotalSellingPrice = Decimal.Parse(BudgetText.ToString());
        //        // parse "value" and try to put it into Budget
        //    }
        //}

       // public string TotalSellingPrice { get; set; }
        public Boolean GstFree { get; set; }

       // public string test { get; set; }
    }
}