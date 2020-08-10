using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using DesignValidationLibrary;

namespace ExportLibrary
{
    public class ExportDXF
    {
        private string exportString { get; set; }

        public void ExportSheetMetalPartsToDXF(List<SheetmetalPart> sheetmetalPartList)
        {
            //a method is used to send a List of PartDocument Inventor Objects to the method

            foreach(SheetmetalPart sheetmetalPart in sheetmetalPartList)
            {
                //Check to make sure it has a flat pattern

                string exportString = GenerateExportStringTest();

                Random random = new Random();

                string fileName = @"C:\Users\mccu4157\OneDrive Corp\OneDrive - Atkins Ltd\Documents\DXFExportTest\" + sheetmetalPart.Name + random.Next(1,100) + ".DXF";

                try
                {
                    SheetMetalComponentDefinition sheetMetalCompDef = (SheetMetalComponentDefinition)sheetmetalPart.partDocument.ComponentDefinition;

                    DataIO dataIO = sheetMetalCompDef.FlatPattern.DataIO;

                    //add option to save with sheetmetal thickness etc... 

                    dataIO.WriteDataToFile(exportString, fileName);
                }
                catch
                {
                    continue;
                }
            }
        }

        public string GenerateExportStringTest()
        {
            string exportString = "FLAT PATTERN DXF?AcadVersion=R12&BendDownLayer=BendDown&TangentLayer=Tangent&InvisibleLayers=Tangent&BendDownLayerLineType=37644";

            return exportString;
        }

        public void GenerateExportString(List<DXFLayerItem> dXFLayerItems)
        {
            List<string> dXFLayerItemsDashedLine = new List<string>();

            List<string> dXFLayerItemsNoLine = new List<string>();

            StringBuilder invisibleLayersString = new StringBuilder();


            foreach (DXFLayerItem dXFLayerItem in dXFLayerItems)
            {
                if (dXFLayerItem.DashedLine)
                    dXFLayerItemsDashedLine.Add(dXFLayerItem.Name);

                else if (dXFLayerItem.NoLine)
                    dXFLayerItemsNoLine.Add(dXFLayerItem.Name);
            }

            //Temporary Code//
            string autoCadVersion = "AcadVersion=R12";

            //build the string for the InvisibleLayers

            //checks to make the List contains values, ie. is not null
            if(dXFLayerItemsNoLine != null)
            {
                invisibleLayersString.Append("InvisibleLayers=");

                string lastEntry = dXFLayerItemsNoLine.Last();

                foreach (string dXFLayerItemNoLine in dXFLayerItemsNoLine)
                {
                    invisibleLayersString.Append(dXFLayerItemNoLine);

                    if (!dXFLayerItemNoLine.Equals(lastEntry))
                    {
                        invisibleLayersString.Append(";");
                    }
                }
            }
        }
    }
}
