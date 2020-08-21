using Inventor;
using System.Collections.Generic;
using System.Linq;
using ProgramUtilities;

namespace DesignValidationLibrary
{
    public class SheetmetalPart : Part
    {
        public int numberOfBends { get; }

        public double totalCuttingLength { get; private set; }
        public double thickness { get; }

        public bool hasFlatPattern { get; private set; }

        public FlatPattern flatPattern { get; }

        private SheetMetalComponentDefinition sheetMetalCompDef;

        public SheetmetalPart(PartDocument partDocument) : base(partDocument)
        {
            sheetMetalCompDef = (SheetMetalComponentDefinition)partDocument.ComponentDefinition;

            numberOfBends = sheetMetalCompDef.Bends.Count;

            thickness = sheetMetalCompDef.Thickness.ModelValue;

            flatPattern = new FlatPattern(sheetMetalCompDef);

            GetFlatPatternProperties();
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
