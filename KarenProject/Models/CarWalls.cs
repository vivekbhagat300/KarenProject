using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KarenProject.Models
{
    public class CarWalls
    {

        public List<SelectListItem> obj { get; set; }
        internal dynamic getHandRailType(string type)
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            if (type == "Residential")
            {
                obj.Add(new SelectListItem { Text = "No Handrail", Value = "No Handrail" });

                obj.Add(new SelectListItem { Text = "Flat Natural Anodised Aluminium", Value = "Flat Natural Anodised Aluminium" });
                obj.Add(new SelectListItem { Text = "Flat Polished  Anodised Aluminium", Value = "Flat Polished  Anodised Aluminium" });
                obj.Add(new SelectListItem { Text = "Flat Gold Anodised Aluminium", Value = "Flat Gold Anodised Aluminium" });
                obj.Add(new SelectListItem { Text = "Round Satin Stainless Steel", Value = "Round Satin Stainless Steel" });
                obj.Add(new SelectListItem { Text = "Round Polished Stainless Steel", Value = "Round Polished Stainless Steel" });
                obj.Add(new SelectListItem { Text = "Round Gold Stainless Steel", Value = "Round Gold Stainless Steel" });

            }
            else
            {
                obj.Add(new SelectListItem { Text = "No Handrail", Value = "No Handrail" });
                obj.Add(new SelectListItem { Text = "Round stainless steel with rounded corners", Value = "Round stainless steel with rounded corners" });

            }
            return obj;
        }
        public List<SelectListItem> getStructureFinish(string type)
        {
            List<SelectListItem> obj = new List<SelectListItem>();

            if (type == "Aluminium")
            {


                obj.Add(new SelectListItem { Text = "Anodised Aluminium", Value = "Anodised Aluminium" });
                obj.Add(new SelectListItem { Text = "Brilliant Silver Aluminium", Value = "Brilliant Silver Aluminium" });
                obj.Add(new SelectListItem { Text = "Brilliant Polished Gold Aluminium", Value = "Brilliant Polished Gold Aluminium" });
                obj.Add(new SelectListItem { Text = "RAL painted std (colour to be defined)", Value = "RAL painted std (colour to be defined)" });
                obj.Add(new SelectListItem { Text = "RAL painted 3003 ruby red", Value = "RAL painted 3003 ruby red" });
                obj.Add(new SelectListItem { Text = "RAL painted 5011 steel blue", Value = "RAL painted 5011 steel blue" });
                obj.Add(new SelectListItem { Text = "RAL painted 5023 distant blue", Value = "RAL painted 5023 distant blue" });
                obj.Add(new SelectListItem { Text = "RAL painted 6010 grass green", Value = "RAL painted 6010 grass green" });
                obj.Add(new SelectListItem { Text = "RAL painted 9010 pure white", Value = "RAL painted 9010 pure white" });
                obj.Add(new SelectListItem { Text = "RAL painted 1013 oyster white", Value = "RAL painted 1013 oyster white" });
                obj.Add(new SelectListItem { Text = "RAL painted 7001 silver grey", Value = "RAL painted 7001 silver grey" });
                obj.Add(new SelectListItem { Text = "RAL special painted", Value = "RAL special painted" });
                obj.Add(new SelectListItem { Text = "Cherry Painted", Value = "Cherry Painted" });
                obj.Add(new SelectListItem { Text = "Deco White painted", Value = "Deco White painted" });
                obj.Add(new SelectListItem { Text = "Colour Nickel 14-091 painted", Value = "Colour Nickel 14-091 painted" });
                obj.Add(new SelectListItem { Text = "Part", Value = "Part" });
                obj.Add(new SelectListItem { Text = "Colour Coffee 14-100 painted", Value = "Colour Coffee 14-100 painted" });
                obj.Add(new SelectListItem { Text = "Colour Copper 14-092 painted", Value = "Colour Copper 14-092 painted" });
                obj.Add(new SelectListItem { Text = "Colour Polished black 14-005 painted", Value = "Colour Polished black 14-005 painted" });
                obj.Add(new SelectListItem { Text = "Adhesive Film", Value = "Adhesive Film" });


            }
            else
            {

                obj.Add(new SelectListItem { Text = "Primed Painted", Value = "Primed Painted" });
                obj.Add(new SelectListItem { Text = "RAL painted std (colour to be defined)", Value = "RAL painted std (colour to be defined)" });
                obj.Add(new SelectListItem { Text = "RAL painted 3003 ruby red", Value = "RAL painted 3003 ruby red" });
                obj.Add(new SelectListItem { Text = "RAL painted 5011 steel blue", Value = "RAL painted 5011 steel blue" });
                obj.Add(new SelectListItem { Text = "RAL painted 5023 distant blue", Value = "RAL painted 5023 distant blue" });
                obj.Add(new SelectListItem { Text = "RAL painted 6010 grass green", Value = "RAL painted 6010 grass green" });
                obj.Add(new SelectListItem { Text = "RAL painted 9010 pure white", Value = "RAL painted 9010 pure white" });
                obj.Add(new SelectListItem { Text = "RAL painted 1013 oyster white", Value = "RAL painted 1013 oyster white" });
                obj.Add(new SelectListItem { Text = "RAL painted 7001 silver grey", Value = "RAL painted 7001 silver grey" });
                obj.Add(new SelectListItem { Text = "RAL special painted", Value = "RAL special painted" });
                obj.Add(new SelectListItem { Text = "Adhesive Film", Value = "Adhesive Film" });



            }

            return obj;
        }
        public List<SelectListItem> getCladding(string type)
        {
            List<SelectListItem> obj = new List<SelectListItem>();

            if (type == "Aluminium")
            {


                obj.Add(new SelectListItem { Text = "Transparent glass", Value = "Transparent glass" });
                obj.Add(new SelectListItem { Text = "Milky white glass", Value = "Milky white glass" });
                obj.Add(new SelectListItem { Text = "RAL Painted standard", Value = "RAL Painted standard" });
                obj.Add(new SelectListItem { Text = "RAL painted std colour to be defined", Value = "RAL painted std colour to be defined" });
                obj.Add(new SelectListItem { Text = "RAL Painted special", Value = "RAL Painted special" });
                obj.Add(new SelectListItem { Text = "Anodised Aluminium", Value = "Anodised Aluminium" });
                obj.Add(new SelectListItem { Text = "Brilliant Silver Aluminium", Value = "Brilliant Silver Aluminium" });
                obj.Add(new SelectListItem { Text = "Deco White Painted Aluminium", Value = "Deco White Painted Aluminium" });



            }
            else
            {

                obj.Add(new SelectListItem { Text = "Transparent glass", Value = "Transparent glass" });
                obj.Add(new SelectListItem { Text = "Milky white glass", Value = "Milky white glass" });
                obj.Add(new SelectListItem { Text = "RAL Painted standard", Value = "RAL Painted standard" });
                obj.Add(new SelectListItem { Text = "RAL painted std colour to be defined", Value = "RAL painted std colour to be defined" });
                obj.Add(new SelectListItem { Text = "RAL Painted special", Value = "RAL Painted special" });
                obj.Add(new SelectListItem { Text = "Adhesive Film", Value = "Adhesive Film" });



            }

            return obj;
        }

        public List<SelectListItem> LDFDoorType(string type)
        {
            List<SelectListItem> obj = new List<SelectListItem>();

            if (type == "DomusLift" || type == "DomusXL")
            {

                // obj.Add(new SelectListItem { Value = "===B Type - Panoramic Aluminium===", Text = "===B Type - Panoramic Aluminium===" });
                obj.Add(new SelectListItem { Value = "B - Panoramic aluminium with transparent glass", Text = "B - Panoramic aluminium with transparent glass" });
                obj.Add(new SelectListItem { Value = "B - Panoramic aluminium with Milky White Glass", Text = "B - Panoramic aluminium with Milky White Glass" });
                obj.Add(new SelectListItem { Value = "B - Panoramic aluminium with two sided mirrored glass", Text = "B - Panoramic aluminium with two sided mirrored glass" });
                obj.Add(new SelectListItem { Value = "B Type - Panoramic Aluminium with smoked glass", Text = "B Type - Panoramic Aluminium with smoked glass" });
                obj.Add(new SelectListItem { Value = "B Type - Panoramic Aluminium with stopsol glass", Text = "B Type - Panoramic Aluminium with stopsol glass" });
                obj.Add(new SelectListItem { Value = "B Type - Panoramic Aluminium with artistic floral glass", Text = "B Type - Panoramic Aluminium with artistic floral glass" });
                obj.Add(new SelectListItem { Value = "B Type - Panoramic Aluminium with artistic perspective glass", Text = "B Type - Panoramic Aluminium with artistic perspective glass" });
                obj.Add(new SelectListItem { Value = "B Type - Panoramic Aluminium with rectangle effect glass", Text = "B Type - Panoramic Aluminium with rectangle effect glass" });
                obj.Add(new SelectListItem { Value = "B Type - Panoramic Aluminium with coloured glass", Text = "B Type - Panoramic Aluminium with coloured glass" });
                obj.Add(new SelectListItem { Value = "===C Type - Blind===", Text = "===C Type - Blind===" });
                obj.Add(new SelectListItem { Value = "C - Blind Standard Steel (without glass)", Text = "C - Blind Standard Steel (without glass)" });
                obj.Add(new SelectListItem { Value = "C - Blind EI 60  Steel (1 hour fire rated - without glass)", Text = "C - Blind EI 60  Steel (1 hour fire rated - without glass)" });
                obj.Add(new SelectListItem { Value = "C - Blind EI 120  Steel (2 hour fire rated - without glass)", Text = "C - Blind EI 120  Steel (2 hour fire rated - without glass)" });
                obj.Add(new SelectListItem { Value = "===D Type -Vision Panel===", Text = "===D Type -Vision Panel===" });
                obj.Add(new SelectListItem { Value = "D - Vision Panel Steel with transparent glass 150W x 1170H", Text = "D - Vision Panel Steel with transparent glass 150W x 1170H" });
                obj.Add(new SelectListItem { Value = "D - Vision Panel Steel with Milky White glass 150W x 1170H", Text = "D - Vision Panel Steel with Milky White glass 150W x 1170H" });
                obj.Add(new SelectListItem { Value = "D - Vision Panel Steel with mirror glass 150W x 1170H", Text = "D - Vision Panel Steel with mirror glass 150W x 1170H" });
                obj.Add(new SelectListItem { Value = "D - Vision Panel Steel with smoked-grey glass 150W x 1170H", Text = "C Type - BlindD - Vision Panel Steel with smoked-grey glass 150W x 1170H" });
                obj.Add(new SelectListItem { Value = "D - Vision Panel Steel with stopsol  glass 150W x 1170H", Text = "D - Vision Panel Steel with stopsol  glass 150W x 1170H" });
                obj.Add(new SelectListItem { Value = "D - Vision Panel Steel Belgium fire rated (glass 100W x 600H)", Text = "D - Vision Panel Steel Belgium fire rated (glass 100W x 600H)" });
                obj.Add(new SelectListItem { Value = "D - Vision Panel Steel UK fire rated (glass 100W x 600H)", Text = "D - Vision Panel Steel UK fire rated (glass 100W x 600H)" });
                obj.Add(new SelectListItem { Value = "===E Type -Panoramic Steel===", Text = "===E Type -Panoramic Steel===" });
                obj.Add(new SelectListItem { Value = "E - Panoramic Steel with transparent glass", Text = "E - Panoramic Steel with transparent glass" });
                obj.Add(new SelectListItem { Value = "E - Panoramic Steel with Milky White glass", Text = "E - Panoramic Steel with Milky White glass" });
                obj.Add(new SelectListItem { Value = "E - Panoramic Steel with two sided mirror glass", Text = "E - Panoramic Steel with two sided mirror glass" });
                obj.Add(new SelectListItem { Value = "E - Panoramic Steel with smoked glass", Text = "E - Panoramic Steel with smoked glass" });
                obj.Add(new SelectListItem { Value = "E - Panoramic Steel with stopsol glass", Text = "E - Panoramic Steel with stopsol glass" });
                obj.Add(new SelectListItem { Value = "===V1  Panoramic===", Text = "===V1  Panoramic===" });
                obj.Add(new SelectListItem { Value = "===V1 - Frameless Clear Glass Door===", Text = "===V1 - Frameless Clear Glass Door===" });

            }
            else if (type == "Domus Spirit" || type == "DomusXL Spirit")
            {
                obj.Add(new SelectListItem { Text = "D - Vision Panel Steel with transparent glass 150W x 1170H", Value = "D - Vision Panel Steel with transparent glass 150W x 1170H" });


            }
            else
            {
                obj.Add(new SelectListItem { Text = "Standard - 2 Panel Side Stacking", Value = "Standard - 2 Panel Side Stacking" });

                // obj.Add(new SelectListItem { Text = "Standard - 2 Panel Side Stacking", Value = "Standard - 2 Panel Side Stacking" });
                obj.Add(new SelectListItem { Text = "2 hour Fire Rated - 2 Panel Side Stacking", Value = "2 hour Fire Rated - 2 Panel Side Stacking" });
                //   obj.Add(new SelectListItem { Text = "2 hour Fire Rated - 2 Panel Side Stacking", Value = "2 hour Fire Rated - 2 Panel Side Stacking" });

            }

            return obj;
        }
        public List<SelectListItem> LDFDoorFinish(string type, string doorType)
        {
            string value1 = doorType.Substring(0, 1);
            switch (type)
            {
                case "DomusLift":
                case "DomusXL":
                    List<SelectListItem> obj = new List<SelectListItem>();

                    if (value1 == "B")
                    {

                        obj.Add(new SelectListItem { Text = "Anodised Aluminium - natural", Value = "Anodised Aluminium - natural" });
                        obj.Add(new SelectListItem { Text = "Anodised Aluminium - shiny", Value = "Anodised Aluminium - shiny" });
                        obj.Add(new SelectListItem { Text = "Anodised Aluminium - polish gold", Value = "Anodised Aluminium - polish gold" });
                        obj.Add(new SelectListItem { Text = "RAL painted std (colour to be defined)", Value = "RAL painted std (colour to be defined)" });
                        obj.Add(new SelectListItem { Text = "RAL painted 3003 ruby red", Value = "RAL painted 3003 ruby red" });
                        obj.Add(new SelectListItem { Text = "RAL painted 5011 steel blue", Value = "RAL painted 5011 steel blue" });

                        obj.Add(new SelectListItem { Text = "RAL painted 5023 distant blue", Value = "RAL painted 5023 distant blue" });
                        obj.Add(new SelectListItem { Text = "RAL painted 6010 grass green", Value = "RAL painted 6010 grass green" });
                        obj.Add(new SelectListItem { Text = "RAL painted 9010 pure white", Value = "RAL painted 9010 pure white" });
                        obj.Add(new SelectListItem { Text = "RAL painted 1013 oyster white", Value = "RAL painted 1013 oyster white" });
                        obj.Add(new SelectListItem { Text = "RAL painted 7001 silver grey", Value = "RAL painted 7001 silver grey" });
                        obj.Add(new SelectListItem { Text = "RAL special painted", Value = "RAL special painted" });
                        obj.Add(new SelectListItem { Text = "Cherry Painted", Value = "Cherry Painted" });
                        obj.Add(new SelectListItem { Text = "Deco White painted", Value = "Deco White painted" });

                        obj.Add(new SelectListItem { Text = "Colour Nickel 14-091 painted", Value = "Colour Nickel 14-091 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Coffee 14-100 painted", Value = "Colour Coffee 14-100 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Copper 14-092 painted", Value = "Colour Copper 14-092 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Polished black 14-005 painted", Value = "Colour Polished black 14-005 painted" });


                    }
                    else if (value1 == "V")
                    {
                        obj.Add(new SelectListItem { Text = "Brushed Stainless Steel", Value = "Brushed Stainless Steel" });

                        obj.Add(new SelectListItem { Text = "Mirror Stainless Steel", Value = "Mirror Stainless Steel" });
                    }
                    else
                    {
                        obj.Add(new SelectListItem { Text = "Primed Painted (finishing by customer)", Value = "Primed Painted (finishing by customer)" });
                        obj.Add(new SelectListItem { Text = "RAL painted std (colour to be defined)", Value = "RAL painted std (colour to be defined)" });
                        obj.Add(new SelectListItem { Text = "RAL painted 3003 ruby red", Value = "RAL painted 3003 ruby red" });
                        obj.Add(new SelectListItem { Text = "RAL painted 5011 steel blue", Value = "RAL painted 5011 steel blue" });
                        obj.Add(new SelectListItem { Text = "RAL painted 5023 distant blue", Value = "RAL painted 5023 distant blue" });
                        obj.Add(new SelectListItem { Text = "RAL painted 6010 grass green", Value = "RAL painted 6010 grass green" });
                        obj.Add(new SelectListItem { Text = "RAL painted 9010 pure white", Value = "RAL painted 9010 pure white" });
                        obj.Add(new SelectListItem { Text = "RAL painted 1013 oyster white", Value = "RAL painted 1013 oyster white" });
                        obj.Add(new SelectListItem { Text = "RAL painted 7001 silver grey", Value = "RAL painted 7001 silver grey" });
                        obj.Add(new SelectListItem { Text = "RAL special painted", Value = "RAL special painted" });
                        obj.Add(new SelectListItem { Text = "Colour Nickel 14-091 painted", Value = "Colour Nickel 14-091 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Coffee 14-100 painted", Value = "Colour Coffee 14-100 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Copper 14-092 painted", Value = "Colour Copper 14-092 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Polished black 14-005 painted", Value = "Colour Polished black 14-005 painted" });
                        obj.Add(new SelectListItem { Text = "If door type V1  Panoramic", Value = "If door type V1  Panoramic" });
                    }

                    return obj;

                case "Domus Spirit":

                case "DomusXL Spirit":

                    List<SelectListItem> obj2 = new List<SelectListItem>();
                    obj2.Add(new SelectListItem { Text = "RAL painted 9010 pure White", Value = "RAL painted 9010 pure White" });
                    obj2.Add(new SelectListItem { Text = "Primed Painted (finishing by customer)", Value = "Primed Painted (finishing by customer)" });
                    return obj2;

                case "Domus Evolution":
                    List<SelectListItem> obj1 = new List<SelectListItem>();
                    obj1.Add(new SelectListItem { Text = "===Brushed Stainless Steel===", Value = "===Brushed Stainless Steel===" });
                    obj1.Add(new SelectListItem { Text = "Brushed Stainless Steel 127", Value = "Brushed Stainless Steel 127" });
                    obj1.Add(new SelectListItem { Text = "Mirror Stainless Steel 127", Value = "Mirror Stainless Steel 127" });
                    obj1.Add(new SelectListItem { Text = "Stainless Steel 132 - Leather", Value = "Stainless Steel 132 - Leather" });
                    obj1.Add(new SelectListItem { Text = "Stainless Steel 145 - Avesta 9", Value = "Stainless Steel 145 - Avesta 9" });
                    obj1.Add(new SelectListItem { Text = "Stainless Steel 131 - Chequered", Value = "Stainless Steel 131 - Chequered" });
                    obj1.Add(new SelectListItem { Text = "Stainless Steel 150 - blue square", Value = "Stainless Steel 150 - blue square" });
                    obj1.Add(new SelectListItem { Text = "===Skinplate===", Value = "===Skinplate===" });
                    obj1.Add(new SelectListItem { Text = "Skinplate DL81E", Value = "Skinplate DL81E" });
                obj1.Add(new SelectListItem { Text = "Skinplate A90GTA", Value = "Skinplate A90GTA" });
                obj1.Add(new SelectListItem { Text = "Skinplate DL86", Value = "Skinplate DL86" });
                obj1.Add(new SelectListItem { Text = "Skinplate M12", Value = "Skinplate M12" });
                obj1.Add(new SelectListItem { Text = "Skinplate B32SMA", Value = "Skinplate B32SMA" });
                obj1.Add(new SelectListItem { Text = "Skinplate G22SMA", Value = "Skinplate G22SMA" });
                obj1.Add(new SelectListItem { Text = "Skinplate G21SMA", Value = "Skinplate G21SMA" });
                obj1.Add(new SelectListItem { Text = "Skinplate R8SME Dark Red", Value = "Skinplate R8SME Dark Red" });
                obj1.Add(new SelectListItem { Text = "Skinplate A32PP - Polished Effect", Value = "Skinplate A32PP - Polished Effect" });
                obj1.Add(new SelectListItem { Text = "Skinplate F2SMA silver grey", Value = "Skinplate F2SMA silver grey" });
                obj1.Add(new SelectListItem { Text = "Skinplate F42PPS brushed stainless steel", Value = "Skinplate F42PPS brushed stainless steel" });
                obj1.Add(new SelectListItem { Text = "Skinplate F12PPS polished stainless steel", Value = "Skinplate F12PPS polished stainless steel" }); 
                obj1.Add(new SelectListItem { Text = "Skinplate Special", Value = "Skinplate Special" });
                    obj1.Add(new SelectListItem { Text = "Plastic Laminate", Value = "Plastic Laminate" });
                    obj1.Add(new SelectListItem { Text = "Adhesive Film", Value = "Adhesive Film" });
                    obj1.Add(new SelectListItem { Text = "===Painting===", Value = "===Painting===" });
                    obj1.Add(new SelectListItem { Text = "Primed Painted (finishing by customer)", Value = "Primed Painted (finishing by customer)" });
                    obj1.Add(new SelectListItem { Text = "RAL painted std (colour to be defined)", Value = "RAL painted std (colour to be defined)" });
                    obj1.Add(new SelectListItem { Text = "RAL painted  9010 pure white", Value = "RAL painted  9010 pure white" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 7001 silver grey", Value = "RAL painted 7001 silver grey" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 5023 distant blue", Value = "RAL painted 5023 distant blue" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 5011 steel blue", Value = "RAL painted 5011 steel blue" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 6010 grass green", Value = "RAL painted 6010 grass green" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 3003 Ruby Red", Value = "RAL painted 3003 Ruby Red" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 1013 pearl white", Value = "RAL painted 1013 pearl white" });
                    obj1.Add(new SelectListItem { Text = "Special RAL painted", Value = "Special RAL painted" });
                    obj1.Add(new SelectListItem { Text = "===Glass===", Value = "===Glass===" });
                    obj1.Add(new SelectListItem { Text = "Trasparent Glass with brushed stainless steel frame", Value = "Trasparent Glass with brushed stainless steel frame" });
                    obj1.Add(new SelectListItem { Text = "Trasparent Glass with Mirror stainless steel frame", Value = "Trasparent Glass with Mirror stainless steel frame" });
                    obj1.Add(new SelectListItem { Text = "Trasparent Glass with film", Value = "Trasparent Glass with film" });
                    return obj1;
                default:
                    return null;


            }

        }
        public List<SelectListItem> LDFFrameFinish(string type, string doorType)
        {
            string vallue1 = doorType.Substring(0, 1);
            switch (type)
            {
                case "DomusLift":
                case "DomusXL":
                    List<SelectListItem> obj = new List<SelectListItem>();

                    if (vallue1 == "B")
                    {

                        obj.Add(new SelectListItem { Text = "Anodised Aluminium - natural", Value = "Anodised Aluminium - natural" });
                        obj.Add(new SelectListItem { Text = "Anodised Aluminium - shiny", Value = "Anodised Aluminium - shiny" });
                        obj.Add(new SelectListItem { Text = "Anodised Aluminium - polish gold", Value = "Anodised Aluminium - polish gold" });
                        obj.Add(new SelectListItem { Text = "RAL painted std (colour to be defined)", Value = "RAL painted std (colour to be defined)" });
                        obj.Add(new SelectListItem { Text = "RAL painted 3003 ruby red", Value = "RAL painted 3003 ruby red" });
                        obj.Add(new SelectListItem { Text = "RAL painted 5011 steel blue", Value = "RAL painted 5011 steel blue" });

                        obj.Add(new SelectListItem { Text = "RAL painted 5023 distant blue", Value = "RAL painted 5023 distant blue" });
                        obj.Add(new SelectListItem { Text = "RAL painted 6010 grass green", Value = "RAL painted 6010 grass green" });
                        obj.Add(new SelectListItem { Text = "RAL painted 9010 pure white", Value = "RAL painted 9010 pure white" });
                        obj.Add(new SelectListItem { Text = "RAL painted 1013 oyster white", Value = "RAL painted 1013 oyster white" });
                        obj.Add(new SelectListItem { Text = "RAL painted 7001 silver grey", Value = "RAL painted 7001 silver grey" });
                        obj.Add(new SelectListItem { Text = "RAL special painted", Value = "RAL special painted" });
                        obj.Add(new SelectListItem { Text = "Cherry Painted", Value = "Cherry Painted" });
                        obj.Add(new SelectListItem { Text = "Deco White painted", Value = "Deco White painted" });

                        obj.Add(new SelectListItem { Text = "Colour Nickel 14-091 painted", Value = "Colour Nickel 14-091 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Coffee 14-100 painted", Value = "Colour Coffee 14-100 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Copper 14-092 painted", Value = "Colour Copper 14-092 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Polished black 14-005 painted", Value = "Colour Polished black 14-005 painted" });


                    }
                    else if (vallue1 == "V")
                    {
                        obj.Add(new SelectListItem { Text = "Brushed Stainless Steel", Value = "Brushed Stainless Steel" });

                        obj.Add(new SelectListItem { Text = "Mirror Stainless Steel", Value = "Mirror Stainless Steel" });
                    }
                    else
                    {
                        obj.Add(new SelectListItem { Text = "Primed Painted (finishing by customer)", Value = "Primed Painted (finishing by customer)" });
                        obj.Add(new SelectListItem { Text = "RAL painted std (colour to be defined)", Value = "RAL painted std (colour to be defined)" });
                        obj.Add(new SelectListItem { Text = "RAL painted 3003 ruby red", Value = "RAL painted 3003 ruby red" });
                        obj.Add(new SelectListItem { Text = "RAL painted 5011 steel blue", Value = "RAL painted 5011 steel blue" });
                        obj.Add(new SelectListItem { Text = "RAL painted 5023 distant blue", Value = "RAL painted 5023 distant blue" });
                        obj.Add(new SelectListItem { Text = "RAL painted 6010 grass green", Value = "RAL painted 6010 grass green" });
                        obj.Add(new SelectListItem { Text = "RAL painted 9010 pure white", Value = "RAL painted 9010 pure white" });
                        obj.Add(new SelectListItem { Text = "RAL painted 1013 oyster white", Value = "RAL painted 1013 oyster white" });
                        obj.Add(new SelectListItem { Text = "RAL painted 7001 silver grey", Value = "RAL painted 7001 silver grey" });
                        obj.Add(new SelectListItem { Text = "RAL special painted", Value = "RAL special painted" });
                        obj.Add(new SelectListItem { Text = "Colour Nickel 14-091 painted", Value = "Colour Nickel 14-091 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Coffee 14-100 painted", Value = "Colour Coffee 14-100 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Copper 14-092 painted", Value = "Colour Copper 14-092 painted" });
                        obj.Add(new SelectListItem { Text = "Colour Polished black 14-005 painted", Value = "Colour Polished black 14-005 painted" });
                        obj.Add(new SelectListItem { Text = "If door type V1  Panoramic", Value = "If door type V1  Panoramic" });
                    }


                    return obj;
                case "Domus Spirit":
                case "DomusXL Spirit":




                    List<SelectListItem> obj2 = new List<SelectListItem>();


                    obj2.Add(new SelectListItem { Text = "RAL painted 9010 pure White", Value = "RAL painted 9010 pure White" });
                    obj2.Add(new SelectListItem { Text = "Primed Painted (finishing by customer)", Value = "Primed Painted (finishing by customer)" });
                    return obj2;
                case "Domus Evolution":
                    List<SelectListItem> obj1 = new List<SelectListItem>();
                    obj1.Add(new SelectListItem { Text = "Stainless Steel", Value = "Stainless Steel" });

                    obj1.Add(new SelectListItem { Text = "Brushed Stainless Steel 127", Value = "Brushed Stainless Steel 127" });
                    obj1.Add(new SelectListItem { Text = "Mirror Stainless Steel 127", Value = "Mirror Stainless Steel 127" });
                    obj1.Add(new SelectListItem { Text = "Stainless Steel 132 - Leather", Value = "Stainless Steel 132 - Leather" });
                    obj1.Add(new SelectListItem { Text = "Stainless Steel 145 - Avesta 9", Value = "Stainless Steel 145 - Avesta 9" });
                    obj1.Add(new SelectListItem { Text = "Stainless Steel 131 - Chequered", Value = "Stainless Steel 131 - Chequered" });
                    obj1.Add(new SelectListItem { Text = "Stainless Steel 150 - blue square", Value = "Stainless Steel 150 - blue square" });
                    obj1.Add(new SelectListItem { Text = "Skinplate", Value = "Skinplate" });
                    obj1.Add(new SelectListItem { Text = "Skinplate Standard", Value = "Skinplate Standard" });
                    obj1.Add(new SelectListItem { Text = "Skinplate Special", Value = "Skinplate Special" });
                    obj1.Add(new SelectListItem { Text = "Plastic Laminate", Value = "Plastic Laminate" });
                    obj1.Add(new SelectListItem { Text = "Adhesive Film", Value = "Adhesive Film" });
                    obj1.Add(new SelectListItem { Text = "Painting", Value = "Painting" });
                    obj1.Add(new SelectListItem { Text = "Primed Painted (finishing by customer)", Value = "Primed Painted (finishing by customer)" });
                    obj1.Add(new SelectListItem { Text = "RAL painted std (colour to be defined)", Value = "RAL painted std (colour to be defined)" });
                    obj1.Add(new SelectListItem { Text = "RAL painted  9010 pure white", Value = "RAL painted  9010 pure white" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 7001 silver grey", Value = "RAL painted 7001 silver grey" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 5023 distant blue", Value = "RAL painted 5023 distant blue" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 5011 steel blue", Value = "RAL painted 5011 steel blue" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 6010 grass green", Value = "RAL painted 6010 grass green" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 3003 Ruby Red", Value = "RAL painted 3003 Ruby Red" });
                    obj1.Add(new SelectListItem { Text = "RAL painted 1013 pearl white", Value = "RAL painted 1013 pearl white" });
                    obj1.Add(new SelectListItem { Text = "Special RAL painted", Value = "Special RAL painted" });
                    obj1.Add(new SelectListItem { Text = "Glass", Value = "Glass" });
                    obj1.Add(new SelectListItem { Text = "Trasparent Glass with brushed stainless steel frame", Value = "Trasparent Glass with brushed stainless steel frame" });
                    obj1.Add(new SelectListItem { Text = "Trasparent Glass with Mirror stainless steel frame", Value = "Trasparent Glass with Mirror stainless steel frame" });
                    obj1.Add(new SelectListItem { Text = "Trasparent Glass with film", Value = "Trasparent Glass with film" });
                    return obj1;
                default:
                    return null;


            }

        }

        internal dynamic getLiftTypes(string type)
        {
            string lifttypez = "";
            if (type == "Residential")
            {

                lifttypez = "Part 18";


            }
            else
            {
                lifttypez = "Part 15";

            }

            return lifttypez;

        }




        public List<SelectListItem> getobj(string type)
        {
            List<SelectListItem> obj = new List<SelectListItem>();

            if (type == "Residential")
            {



                obj.Add(new SelectListItem { Text = "Part 18", Value = "Part 18" });
                obj.Add(new SelectListItem { Text = "Part 16(Residential)", Value = "Part 16(Residential)" });
            }
            else
            {
                obj.Add(new SelectListItem { Text = "Part 15", Value = "Part 15" });

                obj.Add(new SelectListItem { Text = "Part 16(commercial)", Value = "Part 16(commercial)" });
            }

            return obj;
        }

        public List<SelectListItem> getPhone(string type)
        {
            List<SelectListItem> obj = new List<SelectListItem>();

            if (type == "Residential")
            {


                obj.Add(new SelectListItem { Text = "Handset", Value = "Handset" });
                obj.Add(new SelectListItem { Text = "Handsfree", Value = "Handsfree" });

            }
            else
            {
                obj.Add(new SelectListItem { Text = "Handsfree", Value = "Handsfree" });
            }

            return obj;
        }

        public List<SelectListItem> getCarWalls()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            {
                // obj.Add(new SelectListItem { Text = "===Skinplate===", Value = "===Skinplate DL81E===" });
                obj.Add(new SelectListItem { Text = "Skinplate DL81E", Value = "Skinplate DL81E" });
                obj.Add(new SelectListItem { Text = "Skinplate A90GTA", Value = "Skinplate A90GTA" });
                obj.Add(new SelectListItem { Text = "Skinplate DL86", Value = "Skinplate DL86" });
                obj.Add(new SelectListItem { Text = "Skinplate M12", Value = "Skinplate M12" });
                obj.Add(new SelectListItem { Text = "Skinplate B32SMA", Value = "Skinplate B32SMA" });
                obj.Add(new SelectListItem { Text = "Skinplate G22SMA", Value = "Skinplate G22SMA" });
                obj.Add(new SelectListItem { Text = "Skinplate G21SMA", Value = "Skinplate G21SMA" });
                obj.Add(new SelectListItem { Text = "Skinplate R8SME Dark Red", Value = "Skinplate R8SME Dark Red" });
                obj.Add(new SelectListItem { Text = "Skinplate A32PP - Polished Effect", Value = "Skinplate A32PP - Polished Effect" });
                obj.Add(new SelectListItem { Text = "Skinplate F2SMA silver grey", Value = "Skinplate F2SMA silver grey" });
                obj.Add(new SelectListItem { Text = "Skinplate F42PPS brushed stainless steel", Value = "Skinplate F42PPS brushed stainless steel" });
                obj.Add(new SelectListItem { Text = "Skinplate F12PPS polished stainless steel", Value = "Skinplate F12PPS polished stainless steel" });
                obj.Add(new SelectListItem { Text = "Skinplate Special colour", Value = "Skinplate Special colour" });
                obj.Add(new SelectListItem { Text = "===Stainless Steel===", Value = "===Stainless Steel===" });
                obj.Add(new SelectListItem { Text = "Brushed Stainless Steel 127", Value = "Brushed Stainless Steel 127" });
                obj.Add(new SelectListItem { Text = "Mirror Stainless Steel 127", Value = "Mirror Stainless Steel 127" });
                obj.Add(new SelectListItem { Text = "Stainless steel 132 - leather", Value = "Stainless steel 132 - leather" });
                obj.Add(new SelectListItem { Text = "Stainless steel 145 - Avesta 9", Value = "Stainless steel 145 - Avesta 9" });
                obj.Add(new SelectListItem { Text = "Stainless Steel 131 - chequered", Value = "Stainless Steel 131 - chequered" });
                obj.Add(new SelectListItem { Text = "Stainless Steel Austenit", Value = "Stainless Steel Austenit" });
                obj.Add(new SelectListItem { Text = "Stainless Steel 150 - Blue Squared", Value = "Stainless Steel 150 - Blue Squared" });
                obj.Add(new SelectListItem { Text = "Stainless Steel 138- Shiny Gold", Value = "Stainless Steel 138- Shiny Gold" });
                obj.Add(new SelectListItem { Text = "Stainless Steel Special colour", Value = "Stainless Steel Special colour" });
                obj.Add(new SelectListItem { Text = "===Glass===", Value = "===Glass===" });
                obj.Add(new SelectListItem { Text = "Transparent Glass", Value = "Transparent Glass" });
                obj.Add(new SelectListItem { Text = "Milk White Glass", Value = "Milk White Glass" });
                obj.Add(new SelectListItem { Text = "Smoked Glass", Value = "Smoked Glass" });
                obj.Add(new SelectListItem { Text = "Smoked Mirror Glass", Value = "Smoked Mirror Glass" });
                obj.Add(new SelectListItem { Text = "Mirror Glass", Value = "Mirror Glass" });
                obj.Add(new SelectListItem { Text = "Bronze Glass", Value = "Bronze Glass" });
                obj.Add(new SelectListItem { Text = "Stopsol Glass", Value = "Stopsol Glass" });
                obj.Add(new SelectListItem { Text = "===Coated Chipboard===", Value = "===Coated Chipboard===" });
                obj.Add(new SelectListItem { Text = "W410", Value = "W410" });
                obj.Add(new SelectListItem { Text = "U116", Value = "U116" });
                obj.Add(new SelectListItem { Text = "U1184", Value = "U1184" });
                obj.Add(new SelectListItem { Text = "U508", Value = "U508" });
                obj.Add(new SelectListItem { Text = "U102 - Polished effect", Value = "U102 - Polished effect" });
                obj.Add(new SelectListItem { Text = "U007 - Polished effect", Value = "U007 - Polished effect" });
                obj.Add(new SelectListItem { Text = "F8110 - Aluminium effect", Value = "F8110 - Aluminium effect" });
                obj.Add(new SelectListItem { Text = "Edelstahl3 - Stainless Steel effect", Value = "Edelstahl3 - Stainless Steel effect" });
                obj.Add(new SelectListItem { Text = "R5243 - Wood effect", Value = "R5243 - Wood effect" });
                obj.Add(new SelectListItem { Text = "F10/034 - Wood effect", Value = "F10/034 - Wood effect" });
                obj.Add(new SelectListItem { Text = "R5360 - Wood effect", Value = "R5360 - Wood effect" });
                obj.Add(new SelectListItem { Text = "F06/172- Wood effect", Value = "F06/172- Wood effect" });
                obj.Add(new SelectListItem { Text = "===Plastic Laminate===", Value = "===Plastic Laminate===" });
                obj.Add(new SelectListItem { Text = "810- Polished effect", Value = "810- Polished effect" });
                obj.Add(new SelectListItem { Text = "868 - Polished effect", Value = "868 - Polished effect" });
                obj.Add(new SelectListItem { Text = "475- Polished effect", Value = "475- Polished effect" });
                obj.Add(new SelectListItem { Text = "472- Polished effect", Value = "472- Polished effect" });
                obj.Add(new SelectListItem { Text = "1901", Value = "1901" });
                obj.Add(new SelectListItem { Text = "1902", Value = "1902" });
                obj.Add(new SelectListItem { Text = "1902", Value = "1902" });
                obj.Add(new SelectListItem { Text = "1903", Value = "1903" });
                obj.Add(new SelectListItem { Text = "1904", Value = "1904" });
                obj.Add(new SelectListItem { Text = "1678 - Wood effect", Value = "1678 - Wood effect" });
                obj.Add(new SelectListItem { Text = "1611- Wood effect", Value = "1611- Wood effect" });
                obj.Add(new SelectListItem { Text = "1379- Wood effect", Value = "1379- Wood effect" });
                obj.Add(new SelectListItem { Text = "1328- Wood effect", Value = "1328- Wood effect" });

                obj.Add(new SelectListItem { Text = "1609- Wood effect", Value = "1609- Wood effect" });
                obj.Add(new SelectListItem { Text = "358- Wood effect", Value = "358- Wood effect" });
                obj.Add(new SelectListItem { Text = "658- Wood effect", Value = "658- Wood effect" });
                obj.Add(new SelectListItem { Text = "1306- Wood effect", Value = "1306- Wood effect" });
                obj.Add(new SelectListItem { Text = "2705 Marrakech Silver", Value = "2705 Marrakech Silver" });
                obj.Add(new SelectListItem { Text = "2708 Marrakech Gold", Value = "2708 Marrakech Gold" });
                obj.Add(new SelectListItem { Text = "2711 Marrakech Steel", Value = "2711 Marrakech Steel" });
                obj.Add(new SelectListItem { Text = "===Vinyl Film===", Value = "===Vinyl Film===" });
                obj.Add(new SelectListItem { Text = "LE-1105", Value = "LE-1105" });
                obj.Add(new SelectListItem { Text = "FA-1099", Value = "FA-1099" });
                obj.Add(new SelectListItem { Text = "LW-1084", Value = "LW-1084" });
                obj.Add(new SelectListItem { Text = "VN-452", Value = "VN-452" });
                obj.Add(new SelectListItem { Text = "LE-1109", Value = "LE-1109" });
                obj.Add(new SelectListItem { Text = "FA-690", Value = "FA-690" });
                obj.Add(new SelectListItem { Text = "WG-467", Value = "WG-467" });
                obj.Add(new SelectListItem { Text = "WG-947", Value = "WG-947" });
                obj.Add(new SelectListItem { Text = "FW-7007", Value = "FW-7007" });
                obj.Add(new SelectListItem { Text = "WG-1147", Value = "WG-1147" });
                obj.Add(new SelectListItem { Text = "WG-763GN - Polished effect", Value = "WG-763GN - Polished effect" });
                obj.Add(new SelectListItem { Text = "===Liberty Mosaic===", Value = "===Liberty Mosaic===" });
                obj.Add(new SelectListItem { Text = "Amber", Value = "Amber" });
                obj.Add(new SelectListItem { Text = "Topaz", Value = "Topaz" });
                obj.Add(new SelectListItem { Text = "Diamond", Value = "Diamond" });
                obj.Add(new SelectListItem { Text = "Bronzite", Value = "Bronzite" });
                obj.Add(new SelectListItem { Text = "===Leather===", Value = "===Leather===" });
                obj.Add(new SelectListItem { Text = "Ivory", Value = "Ivory" });
                obj.Add(new SelectListItem { Text = "Silver", Value = "Silver" });


            }

            return obj;
        }



        public List<SelectListItem> getCeiling()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            {

                //                obj.Add(new SelectListItem { Text = "===Spots===", Value = "===Spots===" });

                obj.Add(new SelectListItem { Text = "White with halogen Spots", Value = "White with halogen Spots" });
                obj.Add(new SelectListItem { Text = "Brushed stainless steel with halogen spots", Value = "Brushed stainless steel with halogen spots" });
                obj.Add(new SelectListItem { Text = "White, chrome ring LED spots", Value = "White, chrome ring LED spots" });
                obj.Add(new SelectListItem { Text = "Brushed stainless steel , chrome ring LED spots", Value = "Brushed stainless steel , chrome ring LED spots" });
                obj.Add(new SelectListItem { Text = "Mirror stainless steel,chrome ring LED spots", Value = "Mirror stainless steel,chrome ring LED spots" });
                obj.Add(new SelectListItem { Text = "White, 4 chrome ring LED spots", Value = "White, 4 chrome ring LED spots" });

                obj.Add(new SelectListItem { Text = "Brushed stainless steel, 4 chrome ring LED spots", Value = "Brushed stainless steel, 4 chrome ring LED spots" });
                obj.Add(new SelectListItem { Text = "Mirror stainless steel,4 chrome ring LED spots", Value = "Mirror stainless steel,4 chrome ring LED spots" });
                obj.Add(new SelectListItem { Text = "===Firmanent===", Value = "===Firmanent===" });
                obj.Add(new SelectListItem { Text = "Firmanent ceiling (Mirrored stainless steel)", Value = "Firmanent ceiling (Mirrored stainless steel)" });
                obj.Add(new SelectListItem { Text = "Floral ceiling (Mirrored stainless steel)", Value = "Floral ceiling (Mirrored stainless steel)" });
                obj.Add(new SelectListItem { Text = "===Bowl===", Value = "===Bowl===" });
                obj.Add(new SelectListItem { Text = "White with lighting LED bowl", Value = "White with lighting LED bowl" });
                obj.Add(new SelectListItem { Text = "Brushed Stainless Steel with lighting LED bowl", Value = "Brushed Stainless Steel with lighting LED bowl" });
                obj.Add(new SelectListItem { Text = "Mirrored stainless Steel with lighting LED bowl", Value = "Mirrored stainless Steel with lighting LED bowl" });
                obj.Add(new SelectListItem { Text = "Mirror stainless steel 128 with LED Barocco bowl", Value = "Mirror stainless steel 128 with LED Barocco bowl" });
                obj.Add(new SelectListItem { Text = "Stainless steel shiny gold with LED Barocco bowl", Value = "Stainless steel shiny gold with LED Barocco bowl" });
                obj.Add(new SelectListItem { Text = "===Giugiaro===", Value = "===Giugiaro===" });
                obj.Add(new SelectListItem { Text = "Giugiaro  light touch", Value = "Giugiaro  light touch" });
                obj.Add(new SelectListItem { Text = "Giugiaro light touch & music", Value = "Giugiaro light touch & music" });
                obj.Add(new SelectListItem { Text = "Embedded in CAB Mouldings", Value = "Embedded in CAB Mouldings" });
                obj.Add(new SelectListItem { Text = "LED in car frame, white ceiling", Value = "LED in car frame, white ceiling" });
                obj.Add(new SelectListItem { Text = "LED in car frame, Brushed stainless steel ceiling", Value = "LED in car frame, Brushed stainless steel ceiling" });
                obj.Add(new SelectListItem { Text = "LED in car frame, polished stainless steel ceiling", Value = "LED in car frame, polished stainless steel ceiling" });
            }

            return obj;
        }
        public List<SelectListItem> getFloors()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            {

                //obj.Add(new SelectListItem { Text = "===Linoleum===", Value = "===Linoleum===" });
                obj.Add(new SelectListItem { Text = "Marmoleum 3866 Eternity", Value = "Marmoleum 3866 Eternity" });
                obj.Add(new SelectListItem { Text = "Marmoleum STD ( colour to be defeined)", Value = "Marmoleum STD ( colour to be defeined)" });
                obj.Add(new SelectListItem { Text = "Marmoleum 3861 Arabian Pearl", Value = "Marmoleum 3861 Arabian Pearl" });
                obj.Add(new SelectListItem { Text = "Marmoleum 3874 Walnut", Value = "Marmoleum 3874 Walnut" });
                obj.Add(new SelectListItem { Text = "===PVC===", Value = "===PVC===" });
                obj.Add(new SelectListItem { Text = "Eternal 12802 Elegant oak", Value = "Eternal 12802 Elegant oak" });

                obj.Add(new SelectListItem { Text = "Eternal 11562 Tropical beech", Value = "Eternal 11562 Tropical beech" });
                obj.Add(new SelectListItem { Text = "Eternal 10492 Red oak", Value = "Eternal 10492 Red oak" });
                obj.Add(new SelectListItem { Text = "Eternal 10482 Rustic oak", Value = "Eternal 10482 Rustic oak" });

                obj.Add(new SelectListItem { Text = "Eternal 10382 Silver Chestnut", Value = "Eternal 10382 Silver Chestnut" });
                obj.Add(new SelectListItem { Text = "===Rubber===", Value = "===Rubber===" });
                obj.Add(new SelectListItem { Text = "Grey Studded Rubber", Value = "Grey Studded Rubber" });
                obj.Add(new SelectListItem { Text = "Black Studded Rubber ", Value = "Black Studded Rubber" });
                obj.Add(new SelectListItem { Text = "===Granite===", Value = "===Granite===" });
                obj.Add(new SelectListItem { Text = "Granite Rocksolid 607", Value = "Granite Rocksolid 607" });
                obj.Add(new SelectListItem { Text = "Granite Rocksolid 671", Value = "Granite Rocksolid 671" });
                obj.Add(new SelectListItem { Text = "Granit T 2402=", Value = "Granit T 2402" });
                obj.Add(new SelectListItem { Text = "Granit STD Titan Grey", Value = "Granit STD Titan Grey" });
                obj.Add(new SelectListItem { Text = "Granit Cristallina 451", Value = "Granit Cristallina 451" });
                obj.Add(new SelectListItem { Text = "Granite (colour std to be defined)", Value = "Granite (colour std to be defined)" });
                obj.Add(new SelectListItem { Text = "===Mosiac===", Value = "===Mosiac===" });
                obj.Add(new SelectListItem { Text = "Liberty Mosaic Amber", Value = "Liberty Mosaic Amber" });
                obj.Add(new SelectListItem { Text = "Liberty Mosaic Topaz", Value = "Liberty Mosaic Topaz" });
                obj.Add(new SelectListItem { Text = "Liberty Mosaic Diamond", Value = "Liberty Mosaic Diamond" });
                obj.Add(new SelectListItem { Text = "Liberty Mosaic Bronzite	", Value = "Liberty Mosaic Bronzite	" });
                obj.Add(new SelectListItem { Text = "===Other===", Value = "===Other===" });
                obj.Add(new SelectListItem { Text = "Floor by Client - 16mm setdown by ELHE", Value = "Floor by Client - 16mm setdown by ELHE" });

            }

            return obj;
        }



        public List<SelectListItem> getProfiles()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            {

                //         obj.Add(new SelectListItem { Text = "===Anodised Aluminium===", Value = "===Anodised Aluminium===" });

                obj.Add(new SelectListItem { Text = "Anodised Aluminium - natural", Value = "Anodised Aluminium - natural" });
                obj.Add(new SelectListItem { Text = "Anodised Aluminium - Shiny", Value = "Anodised Aluminium - Shiny" });
                obj.Add(new SelectListItem { Text = "Anodised Aluminium - Polish gold", Value = "Anodised Aluminium - Polish gold" });
                obj.Add(new SelectListItem { Text = "===RAL Painting===", Value = "===RAL Painting===" });
                obj.Add(new SelectListItem { Text = "RAL painted st (colour to be defined)", Value = "RAL painted st (colour to be defined)" });
                obj.Add(new SelectListItem { Text = "RAL 9010 Pure White  painted", Value = "RAL 9010 Pure White  painted" });

                obj.Add(new SelectListItem { Text = "RAL 7001 Silver frey painted", Value = "RAL 7001 Silver frey painted" });
                obj.Add(new SelectListItem { Text = "RAL 5023 distant blue painted", Value = "RAL 5023 distant blue painted" });
                obj.Add(new SelectListItem { Text = "RAL 5011 steel blue painted", Value = "RAL 5011 steel blue painted" });

                obj.Add(new SelectListItem { Text = "RAL 6010 grass green painted", Value = "RAL 6010 grass green painted" });
                obj.Add(new SelectListItem { Text = "RAL 3003 ruby red painted", Value = "RAL 3003 ruby red painted" });
                obj.Add(new SelectListItem { Text = "RAL 1013 oyster white painted", Value = "RAL 1013 oyster white painted" });
                obj.Add(new SelectListItem { Text = "RAL painted - Special colour", Value = "RAL painted - Special colour" });
                obj.Add(new SelectListItem { Text = "===Wood Effect Painting===", Value = "===Wood Effect Painting===" });
                obj.Add(new SelectListItem { Text = "Cherry Painted", Value = "Cherry Painted" });
                obj.Add(new SelectListItem { Text = "Deco White painted", Value = "Deco White painted" });
                obj.Add(new SelectListItem { Text = "===Polyester Painting===", Value = "===Polyester Painting ===" });
                obj.Add(new SelectListItem { Text = "Colour Nickel 14-091 painted", Value = "Colour Nickel 14-091 painted" });
                obj.Add(new SelectListItem { Text = "Colour Coffee 14-100 painted", Value = "Colour Coffee 14-100 painted" });
                obj.Add(new SelectListItem { Text = "Granite (colour std to be defined)", Value = "Granite (colour std to be defined)" });
                obj.Add(new SelectListItem { Text = "Colour Copper 14-092 painted", Value = "Colour Copper 14-092 painted" });
                obj.Add(new SelectListItem { Text = "Colour Polished Black 14-005 painted", Value = "Colour Polished Black 14-005 painted " });

            }

            return obj;
        }

        public List<SelectListItem> getCOP()
        {
            List<SelectListItem> obj = new List<SelectListItem>();
            {

                //                obj.Add(new SelectListItem { Text = "===Plate===", Value = "===Plate===" });

                obj.Add(new SelectListItem { Text = "Brushed Stainless Steel plate", Value = "Brushed Stainless Steel plate" });
                obj.Add(new SelectListItem { Text = "Mirror Stainless Steel plate", Value = "Mirror Stainless Steel plate" });
                obj.Add(new SelectListItem { Text = "Gold Steel 138 plate", Value = "Gold Steel 138 plate" });
                obj.Add(new SelectListItem { Text = "IGV touch screen mirror stainless steel plate", Value = "IGV touch screen mirror stainless steel plate" });
                obj.Add(new SelectListItem { Text = "===SuperFlat===", Value = "===SuperFlat===" });
                obj.Add(new SelectListItem { Text = "Brushed Stainless Steel Superflat plate", Value = "Brushed Stainless Steel Superflat plate" });

                obj.Add(new SelectListItem { Text = "Mirror Stainless Steel Superflat plate", Value = "Mirror Stainless Steel Superflat plate" });
                obj.Add(new SelectListItem { Text = "Gold Stainless Steel Full height vertical panel", Value = "Gold Stainless Steel Full height vertical panel" });




                obj.Add(new SelectListItem { Text = "===Full Height Vertical Panel===", Value = "===Full Height Vertical Panel===" });
                obj.Add(new SelectListItem { Text = "Brushed Stainless Steel Full height vertical panel", Value = "Brushed Stainless Steel Full height vertical panel" });
                obj.Add(new SelectListItem { Text = "Mirror Stainless Steel Full height vertical panel", Value = "Mirror Stainless Steel Full height vertical panel" });
                obj.Add(new SelectListItem { Text = "Gold Stainless Steel Full height vertical panel", Value = "Gold Stainless Steel Full height vertical panel" });

                obj.Add(new SelectListItem { Text = " IGV touch-screen Mirror Stainless Steel Full height vertical panel ", Value = " IGV touch-screen Mirror Stainless Steel Full height vertical panel " });

                obj.Add(new SelectListItem { Text = "Giugiaro touch-screen Mirror Stainless Steel Full height vertical panel", Value = "Giugiaro touch-screen Mirror Stainless Steel Full height vertical panel" });
                obj.Add(new SelectListItem { Text = "===Integrated in Handrail===", Value = "===Integrated in Handrail===" });
                obj.Add(new SelectListItem { Text = "RAL 1013 oyster white painted", Value = "RAL 1013 oyster white painted" });
                obj.Add(new SelectListItem { Text = "RAL painted - Special colour", Value = "RAL painted - Special colour" });
                obj.Add(new SelectListItem { Text = "===Wood Effect Painting===", Value = "===Wood Effect Painting===" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - Natural Anodised", Value = "Integrated in flat Aluminium  Handrail - Natural Anodised" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - Shiny Anodised", Value = "Integrated in flat Aluminium  Handrail - Shiny Anodised" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - Gold Anodised", Value = "Integrated in flat Aluminium  Handrail - Gold Anodised" });

                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - RAL 3003 ruby red painted", Value = "Integrated in flat Aluminium  Handrail - RAL 3003 ruby red painted" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - RAL 5011 steel blue painted", Value = "Integrated in flat Aluminium  Handrail - RAL 5011 steel blue painted" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - RAL 2023", Value = "Integrated in flat Aluminium  Handrail - RAL 2023" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - RAL 6010 grass green painted", Value = "Integrated in flat Aluminium  Handrail - RAL 6010 grass green painted" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - RAL 7021", Value = "Integrated in flat Aluminium  Handrail - RAL 7021" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - RAL 9010", Value = "Integrated in flat Aluminium  Handrail - RAL 9010" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - RAL 7001", Value = "Integrated in flat Aluminium  Handrail - RAL 7001" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - RAL Special", Value = "Integrated in flat Aluminium  Handrail - RAL Special" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - Nickel 14-091", Value = "Integrated in flat Aluminium  Handrail - Nickel 14-091" });
                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - Coffee 14-100", Value = "Integrated in flat Aluminium  Handrail - Coffee 14-100" });

                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - Copper 14-092", Value = "Integrated in flat Aluminium  Handrail -Copper 14-092" });

                obj.Add(new SelectListItem { Text = "Integrated in flat Aluminium  Handrail - Black 14-005", Value = "Integrated in flat Aluminium  Handrail - Black 14-005" });

                obj.Add(new SelectListItem { Text = "Integrated in shiny chromiuim-plate round handrail", Value = "Integrated in shiny chromiuim-plate round handrail" });

            }

            return obj;
        }










        internal dynamic getHandRail(string p)
        {
            throw new NotImplementedException();
        }

        internal dynamic getEntranceTypes(string type)
        {
            List<SelectListItem> obj = new List<SelectListItem>();

            if (type == "Front entrance")
            {

                obj.Add(new SelectListItem { Text = "Front entrance", Value = "Front entrance" });
                // obj.Add(new SelectListItem { Text = "Part 16(Residential)", Value = "Part 16(Residential)" });
            }
            else
            {
                obj.Add(new SelectListItem { Text = "Front entrance", Value = "Front entrance" });

                obj.Add(new SelectListItem { Text = "Second entrance", Value = "Second entrance" });
                obj.Add(new SelectListItem { Text = "Front & Second entrance", Value = "Front & Second entrance" });

            }

            return obj;
        }
    }
}