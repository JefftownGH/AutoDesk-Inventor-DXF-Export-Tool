using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using DesignValidationLibrary;

namespace ExportLibrary
{
    public static class ExportDXF
    {

        public static void ExportSheetMetalPartsToDXF(List<SheetmetalPart> sheetmetalPartList)
        {
            //a method is used to send a List of PartDocument Inventor Objects to the method

            foreach(SheetmetalPart sheetmetalPart in sheetmetalPartList)
            {
                //Check to make sure it has a flat pattern

                string exportString = GenerateExportString();

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

        public static string GenerateExportString()
        {
            string exportString = "FLAT PATTERN DXF?AcadVersion=R12&BendDownLayer=BendDown&TangentLayer=Tangent&InvisibleLayers=Tangent&BendDownLayerLineType=37644";

            //string flatPattern = "FLAT PATTERN DXF?";

            //string autoCadVersion = "AcadVersion = 2000";

            return exportString;
        }











    }
}
