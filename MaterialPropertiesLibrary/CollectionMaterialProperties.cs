using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace MaterialPropertiesLibrary
{
    public class CollectionMaterialProperties
    {
        public List<MaterialProperty> materialProperties { get; set; }
        private string jsonRelativeFilePath { get; set; } = "Resources\\MaterialProperties.json";
        private string jsonFilePath { get; set; } 

        public CollectionMaterialProperties()
        {
            materialProperties = new List<MaterialProperty>();
        }

        public string GenerateJsonFilePath()
        {
            string runningPath = AppDomain.CurrentDomain.BaseDirectory;
            jsonFilePath = string.Format("{0}" + jsonRelativeFilePath, Path.GetFullPath(Path.Combine(runningPath, @"..\..\")));
            return jsonFilePath;
        }

        //Creates a Json file from the materialProperties Collection of MaterialProperty objects

        public string SerializeJson()
        {
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(materialProperties,jsonOptions);
            return jsonString;
        }

        //Deserializes the Json file to create the collection of MaterialProperty objects

        public void DeserialiseJson(string filePath)
        {
            //this should ideally be in a try catch block in case the JSON file get corrupted then delete the file if there is an issue
            string jsonString = File.ReadAllText(filePath);
            materialProperties = JsonSerializer.Deserialize<List<MaterialProperty>>(jsonString);
        }
    }
}
