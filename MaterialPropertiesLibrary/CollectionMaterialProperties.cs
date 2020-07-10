using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using ProgramUtilities;
using System.Windows.Forms;

namespace MaterialPropertiesLibrary
{
    public class CollectionMaterialProperties
    {
        public List<MaterialProperty> materialProperties { get; set; } = new List<MaterialProperty>();
        private static string jsonRelativeFilePath { get; set; } = "Resources\\MaterialProperties.json";
        public string jsonFilePath { get; private set; } 

        public static CollectionMaterialProperties CreateCollectionMaterialProperties()
        {
            string runningPath = AppDomain.CurrentDomain.BaseDirectory;
            return new CollectionMaterialProperties{jsonFilePath = string.Format("{0}" + jsonRelativeFilePath, Path.GetFullPath(Path.Combine(runningPath, @"..\..\"))) };
        }

        public void AddDefaultMaterialProperty()
        {
            MaterialProperty defaultMaterial = new MaterialProperty() { materialName = "Default", materialDescription = "Default sheet metal profile",
                costPerKilogram = 1.00M, maxSheetLength = 3000, maxSheetWidth = 1500, kFactor = 0.42 };
            
            materialProperties.Add(defaultMaterial);
        }

        public string SerializeJson()
        {
            JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };
            return JsonSerializer.Serialize(materialProperties,jsonOptions);
        }

        public void DeserialiseJson(string filePath)
        {
            //this should ideally be in a try catch block in case the JSON file get corrupted then delete the file if there is an issue
            string jsonString = File.ReadAllText(filePath);
            materialProperties = JsonSerializer.Deserialize<List<MaterialProperty>>(jsonString);
        }

        public void ImportJsonFile()
        {
            if (!FileHandling.CheckIfFilesExists(jsonFilePath))
            {
                AddDefaultMaterialProperty();
                FileHandling.SaveStringToFile(SerializeJson(), jsonFilePath, true);
            }
            else
            {
                DeserialiseJson(jsonFilePath);
            }
        }

        public void AlphabeticallySortMaterialProperties()
        {
            materialProperties.Sort((x, y) => string.Compare(x.materialName, y.materialName));
        }

        private bool CheckIfMaterialNameIsInUse(string materialPropertyName)
        {
            return materialProperties.Any(name => name.materialName == materialPropertyName);
        }

        public void RemoveMaterialProperty(string materialPropertyName)
        {
            if (materialPropertyName == "Default")
            {
                MessageBox.Show("Cannot delete the Default material property");
                return;
            }
            materialProperties.RemoveAll(x => x.materialName == materialPropertyName);
            FileHandling.SaveStringToFile(SerializeJson(), jsonFilePath, true);
        }

        public void AddNewMaterialProperty(string materialName, string materialDescription, decimal costPerKilogram, double maxSheetLength, double maxSheetWidth, double kFactor)
        {
            if (CheckIfMaterialNameIsInUse(materialName))
            {
                DialogResult materialNameDialogueResult = MessageBox.Show("This material property already exists, do you want to overwrite it?",
                    "Add Material Property", MessageBoxButtons.YesNo);

                switch (materialNameDialogueResult)
                {
                    case DialogResult.No:
                        return;

                    case DialogResult.Yes:
                        RemoveMaterialProperty(materialName);
                        break;
                }
            }
            try
            {
                MaterialProperty materialProperty = new MaterialProperty() { materialName = materialName, materialDescription = materialDescription, costPerKilogram = costPerKilogram,
                    maxSheetLength = maxSheetLength, maxSheetWidth = maxSheetWidth, kFactor = kFactor };

                materialProperties.Add(materialProperty);
                FileHandling.SaveStringToFile(SerializeJson(), jsonFilePath, true);
            }
            catch (Exception)
            {
                MessageBox.Show("An error was encountered adding the material to the library");
                throw;
            }
        }
    }
}
