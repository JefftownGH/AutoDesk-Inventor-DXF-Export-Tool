using Inventor;
using System.Collections.Generic;
using System.Linq;
using ProgramUtilities;

namespace DesignValidationLibrary
{
    public class SheetmetalPart : Part
    {
        public double totalCuttingLength { get; private set; }

        public int numberOfBends { get; private set; }

        public double thickness { get; private set; }

        public bool hasFlatPattern { get; private set; }

        public FlatPattern flatPattern { get; private set; }

        private SheetMetalComponentDefinition sheetMetalCompDef { get; set; }

        public SheetmetalPart(PartDocument partDocument) : base(partDocument)
        {
            sheetMetalCompDef = (SheetMetalComponentDefinition)partDocument.ComponentDefinition;

            numberOfBends = sheetMetalCompDef.Bends.Count;

            thickness = sheetMetalCompDef.Thickness.ModelValue;

            flatPattern = new FlatPattern(sheetMetalCompDef);
        }

        public void GetFlatPatternProperties()
        {
            totalCuttingLength = flatPattern.TotalLengthFlatPatternLoops();

            //only here temporarily - for debugging purposes
            errorList.Add(totalCuttingLength.ToString());

            if (totalCuttingLength == 0)
            {
                errorList.Add("Could not generate flat pattern for component");

                hasFlatPattern = false;
            }
            else
                hasFlatPattern = true;
        }
    }
}
