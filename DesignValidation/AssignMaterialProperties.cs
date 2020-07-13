using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialPropertiesLibrary;
using DesignValidationLibrary;


namespace DesignValidation
{
    public static class AssignMaterialProperties
    {
        public static List<MaterialProperty> RetrieveMaterialProperties()
        {
            CollectionMaterialProperties collectionMaterialProperties = CollectionMaterialProperties.CreateCollectionMaterialProperties();
            collectionMaterialProperties.ImportJsonFile();
            return collectionMaterialProperties.materialProperties;
        }

        public static void AssignMaterialPropertiesToParts(TopLevel topLevel)
        {
            List<MaterialProperty> materialProperties = RetrieveMaterialProperties();

            foreach (Assembly asm in topLevel.AssemblyList)
            {
                IEnumerable<Part> sheetmetalPartList = asm.ComponentList.Where(p => p.GetType() == typeof(SheetmetalPart));

                foreach (SheetmetalPart sheetmetalPart in sheetmetalPartList)
                {
                    sheetmetalPart.AssignMaterialProperties(materialProperties);
                }
            }
        }
    }
}
