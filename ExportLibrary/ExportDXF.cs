using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        //This class is starting to perform two mainly deserialise/serialise the JSON file for the layer objects and the DXF export logic.. they probably need to be separated off into separate classes

        public string exportString { get; private set; }

        private static string jsonRelativeFilePath { get; set; } = "Resources\\DXFLayerItems.json";

        private string _jsonFilePath;
        public string jsonFilePath
        {
            get { return _jsonFilePath; }

            set
            {
                string runningPath = AppDomain.CurrentDomain.BaseDirectory;

                _jsonFilePath = string.Format("{0}" + jsonRelativeFilePath, Path.GetFullPath(Path.Combine(runningPath, @"..\..\")));
            }
        }

        public List<DXFLayerItem> dXFLayerItems = new List<DXFLayerItem>();

        public List<string> exportLog = new List<string>();

        public ExportDXFSettings exportDXFSettings { get; set; }

        public ExportDXF() { jsonFilePath = null; }

        public ExportDXF(ExportDXFSettings exportDXFSettings)
        {
            jsonFilePath = null;
            this.exportDXFSettings = exportDXFSettings;
        }

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

        //main meat of this class - should really be broken off into another class
        public void ExportSheetMetalPartsToDXF(List<SheetmetalPart> sheetmetalPartList)
        {
            exportString = ExportStringGenerator.GenerateExportString(dXFLayerItems);

            foreach(SheetmetalPart sheetmetalPart in sheetmetalPartList)
            {

                string exportFileName = GenerateExportFileName(sheetmetalPart);

                try
                {
                    SheetMetalComponentDefinition sheetMetalCompDef = (SheetMetalComponentDefinition)sheetmetalPart.partDocument.ComponentDefinition;

                    DataIO dataIO = sheetMetalCompDef.FlatPattern.DataIO;

                    dataIO.WriteDataToFile(exportString, exportFileName);

                    exportLog.Add(sheetmetalPart.partDocument.DisplayName + " DXF was successfully exported");
                }
                catch (Exception e)
                {
                    exportLog.Add(sheetmetalPart.partDocument.DisplayName + " DXF was successfully exported");
                    exportLog.Add(e.Message + "____" + e.StackTrace);
                    continue;
                }
            }
        }

        private string GenerateExportFileName(SheetmetalPart sheetmetalPart)
        {
            StringBuilder exportFileName = new StringBuilder();

            exportFileName.Append(exportDXFSettings.saveLocationFilePath);
            exportFileName.Append(sheetmetalPart.partDocument.DisplayName);

            if (exportDXFSettings.appendMaterialThickness)
                exportFileName.Append("_" + sheetmetalPart.thickness);

            if (exportDXFSettings.appendFoldedStatus)
                if (sheetmetalPart.numberOfBends > 0)
                    exportFileName.Append("_Folded");
                else
                    exportFileName.Append("_NotFolded");

            exportFileName.Append(".DXF");

            return exportFileName.ToString();
        }

    }
}
