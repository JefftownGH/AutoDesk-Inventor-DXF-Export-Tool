using Inventor;
using System.Collections.Generic;
using MaterialPropertiesLibrary;
using System.Linq;

namespace DesignValidationLibrary
{
    public class SheetmetalPart : Part
    {
        public double sheetMetalLength { get; set; }
        public double sheetMetalWidth { get; set; }
        public double maxSheetMetalLength { get; set; }
        public double maxSheetMetalWidth { get; set; }
        public double kFactor { get; set; }
        private SheetMetalComponentDefinition SheetMetalCompDef { get; set; }

        public void AssignMaterialProperties(List<MaterialProperty> materialProperties)
        {
            material = partDocument.ActiveMaterial.DisplayName;
            IEnumerable<MaterialProperty> Result = materialProperties.Where(x => x.materialName == material);
              
        }

        public void FlatPatternArea()
        {
            //Code is for testing purposes.. not intended for use

            SheetMetalCompDef = (SheetMetalComponentDefinition)partDocument.ComponentDefinition;

            Box tempBox;
            double width;
            double length;

            if (SheetMetalCompDef.HasFlatPattern)
            {

                errorList.Add("FlatPatternExists");

                errorList.Add(SheetMetalCompDef.ActiveSheetMetalStyle.Thickness);

                SheetMetalCompDef.Unfold();

                tempBox = SheetMetalCompDef.FlatPattern.Body.RangeBox;

                sheetMetalLength = tempBox.MaxPoint.X - tempBox.MinPoint.X;
                sheetMetalWidth = tempBox.MaxPoint.Y - tempBox.MinPoint.Y;

                errorList.Add(sheetMetalWidth.ToString());
                errorList.Add(sheetMetalWidth.ToString());

                errorList.Add(partDocument.UnitsOfMeasure.LengthUnits.ToString());
            }
            else
            {
                errorList.Add("No flat pattern");

                tempBox = SheetMetalCompDef.FlatPattern.Body.RangeBox;

                width = tempBox.MaxPoint.X - tempBox.MinPoint.X;
                length = tempBox.MaxPoint.Y - tempBox.MinPoint.Y;

                errorList.Add(width.ToString());
                errorList.Add(length.ToString());
            }
        }

        public void UnitConversion()
        {
            partDocument.UnitsOfMeasure.LengthUnits.ToString();

        }
    }
}
