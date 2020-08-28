using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
using ProgramUtilities;

namespace ExportLibrary
{
    public class ImportExportDXFLayers
    {
        private static string jsonRelativeFilePath  = "Resources\\DXFLayerItems.json";
        public static string jsonFilePath
        {
            get 
            {
                string runningPath = AppDomain.CurrentDomain.BaseDirectory;
                return string.Format("{0}" + jsonRelativeFilePath, Path.GetFullPath(Path.Combine(runningPath, @"..\..\")));
            }
        }
        public List<DXFLayerItem> dXFLayerItems { get; private set; } = new List<DXFLayerItem>();

        public ImportExportDXFLayers()
        {
            ImportJsonFile();
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
                dXFLayerItems.Add(new DXFLayerItem(layerName.ToString()));
        }

        public void DeserialiseJson()
        {
            dXFLayerItems = JsonSerializer.Deserialize<List<DXFLayerItem>>(File.ReadAllText(jsonFilePath));
        }

        public void SerialiseJson(List<DXFLayerItem> listDXFLayerItems)
        {
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            FileHandling.SaveStringToFile(JsonSerializer.Serialize(listDXFLayerItems, jsonOptions), jsonFilePath, true);
        }
    }
}
