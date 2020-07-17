using Inventor;
using System.Collections.Generic;
using MaterialPropertiesLibrary;
using System.Linq;
using ProgramUtilities;

namespace DesignValidationLibrary
{
    public class SheetmetalPart : Part
    {
        public double sheetMetalLength { get; private set; }
        public double sheetMetalWidth { get; private set; }
        public double totalCuttingLength { get; private set; }
        public double kFactor { get; private set; }

        public int numberOfBends { get; private set; }
        public bool hasFlatPattern { get; private set; }

        public FlatPattern flatPattern { get; private set; }
        private SheetMetalComponentDefinition sheetMetalCompDef { get; set; }
        private MaterialProperty materialProperty { get; set; }

        public SheetmetalPart(PartDocument partDocument) : base(partDocument)
        {
            sheetMetalCompDef = (SheetMetalComponentDefinition)partDocument.ComponentDefinition;

            numberOfBends = sheetMetalCompDef.Bends.Count;

            flatPattern = new FlatPattern(sheetMetalCompDef);
        }

        public void GetFlatPatternProperties()
        {
            totalCuttingLength = flatPattern.TotalLengthFlatPatternLoops();

            errorList.Add(totalCuttingLength.ToString());

            if (totalCuttingLength == 0)
            {
                errorList.Add("Could not generate flat patteern for component");

                hasFlatPattern = false;
            }
            else
                hasFlatPattern = true;
        }
    }
}
