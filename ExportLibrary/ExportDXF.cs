using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Inventor;
using DesignValidationLibrary;
using ExportLibrary.Properties;
using System.IO;
using ProgramUtilities;

using Path = System.IO.Path;
using File = System.IO.File;

namespace ExportLibrary
{
    public class ExportDXF
    {
        private string exportString { get; set; }

        private static string jsonRelativeFilePath { get; set; } = "Resources\\DXFLayerItems.json";

        public string jsonFilePath { get; private set; }

        public List<DXFLayerItem> dXFLayerItems = new List<DXFLayerItem>();

        //"Constructor method"
        public static ExportDXF CreateExportDXFObject()
        {
            string runningPath = AppDomain.CurrentDomain.BaseDirectory;

            return new ExportDXF { jsonFilePath = string.Format("{0}" + jsonRelativeFilePath, Path.GetFullPath(Path.Combine(runningPath, @"..\..\"))) };
        }

        //load/create the DXFLayerObjects then return them back to the calling class
        public void ImportJsonFile()
        {
            if (!FileHandling.CheckIfFilesExists(jsonFilePath))
            {
                CreateDXFLayerItemsList();

                SerialiseJson(dXFLayerItems);
            }
            else
                DeserialiseJson();
        }

        //starting off point if their is no JSON file, create the DXF layer items
        public void CreateDXFLayerItemsList()
        {
            IEnumerable<LayerNames> layerNames = Enum.GetValues(typeof(LayerNames)).Cast<LayerNames>();

            foreach(Enum layerName in layerNames)
            {
                dXFLayerItems.Add(new DXFLayerItem(layerName.ToString()));
            }
        }

        public void DeserialiseJson()
        {
            string jsonString = File.ReadAllText(jsonFilePath);

            dXFLayerItems = JsonSerializer.Deserialize<List<DXFLayerItem>>(jsonString);
        }

        //receives a List<DXFLayerItem> and returns a JSON string
        public void SerialiseJson(List<DXFLayerItem> listDXFLayerItems)
        {
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

            FileHandling.SaveStringToFile(JsonSerializer.Serialize(listDXFLayerItems, jsonOptions), jsonFilePath, true);
        }

        public void ExportSheetMetalPartsToDXF(List<SheetmetalPart> sheetmetalPartList)
        {
            GenerateExportString();

            //a method is used to send a List of PartDocument Inventor Objects to the method

            foreach(SheetmetalPart sheetmetalPart in sheetmetalPartList)
            {
                //Check to make sure it has a flat pattern

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
                    Debug.Write("opps something went wrong");
                    continue;
                }
            }
        }

        public string GenerateExportString()
        {
            //Test code - very messy refactor ASAP
            //this will probably be sperated out in a number of methods or a separate static class

            List<string> dXFLayerItemsDashedLine = new List<string>();

            List<string> dXFLayerItemsNoLine = new List<string>();

            StringBuilder exportStringBuilder = new StringBuilder();

            exportStringBuilder.Append("FLAT PATTERN DXF?");
            exportStringBuilder.Append(Settings.Default["AutoCadVersion"].ToString());

            //build the two lists required

            foreach (DXFLayerItem dXFLayerItem in dXFLayerItems)
            {
                if (dXFLayerItem.DashedLine)
                    dXFLayerItemsDashedLine.Add(dXFLayerItem.Name);

                else if (dXFLayerItem.NoLine)
                    dXFLayerItemsNoLine.Add(dXFLayerItem.Name);
            }

            if (dXFLayerItemsNoLine.Any() || dXFLayerItemsDashedLine.Any())
                exportStringBuilder.Append("&");

            //assign names to the no line objects


            if (dXFLayerItemsNoLine.Any())
            {
                string lastEntry = dXFLayerItemsNoLine.Last();

                foreach (string dXFLayerItemNoLine in dXFLayerItemsNoLine)
                {
                    exportStringBuilder.Append(dXFLayerItemNoLine + "=" + dXFLayerItemNoLine);

                    if (!dXFLayerItemNoLine.Equals(lastEntry) || dXFLayerItemsNoLine.Count == 1)
                    {
                        exportStringBuilder.Append("&");
                    }
                }
            }

            if (dXFLayerItemsNoLine.Any())
            {
                exportStringBuilder.Append("InvisibleLayers=");

                string lastEntry = dXFLayerItemsNoLine.Last();

                foreach (string dXFLayerItemNoLine in dXFLayerItemsNoLine)
                {
                    exportStringBuilder.Append(dXFLayerItemNoLine);

                    if (!dXFLayerItemNoLine.Equals(lastEntry))
                    {
                        exportStringBuilder.Append(";");
                    }
                }
            }

            if(dXFLayerItemsDashedLine.Any())
            {
                string lineStyle = "LayerLineType=37644";

                foreach(string dXFLayerItemDashedLine in dXFLayerItemsDashedLine)
                {
                    exportStringBuilder.Append("&");
                    exportStringBuilder.Append(dXFLayerItemDashedLine);
                    exportStringBuilder.Append(lineStyle);
                }
            }

            exportString = exportStringBuilder.ToString();

            return exportStringBuilder.ToString();
        }
    }
}
