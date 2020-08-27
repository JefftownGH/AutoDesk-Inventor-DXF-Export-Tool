using Inventor;
using System.Collections.Generic;
using System.Linq;
using ProgramUtilities;
using System;

namespace DesignValidationLibrary
{
    public class SheetmetalPart : Part 
    {
        public int NumberOfBends { get; }

        public double TotalCuttingLength { get; private set; }
        public double Thickness { get; }

        public bool HasFlatPattern { get; private set; }

        public FlatPattern FlatPattern { get; }

        private SheetMetalComponentDefinition SheetMetalCompDef;

        public SheetmetalPart(PartDocument partDocument) : base(partDocument)
        {
            SheetMetalCompDef = (SheetMetalComponentDefinition)partDocument.ComponentDefinition;

            NumberOfBends = SheetMetalCompDef.Bends.Count;

            Thickness = SheetMetalCompDef.Thickness.ModelValue;

            FlatPattern = new FlatPattern(SheetMetalCompDef);

            GetFlatPatternProperties();
        }

        public void GetFlatPatternProperties()
        {
            TotalCuttingLength = FlatPattern.TotalLengthFlatPatternLoops();

            if (TotalCuttingLength == 0)
            {
                EventLogger.CreateLogEntry($"ERROR: creating a flat pattern for {PartDocument.DisplayName}");
                ImportStatus = "Failed";
                HasFlatPattern = false;
            }
            else
            {
                EventLogger.CreateLogEntry($"SUCCESS: creating a flat pattern for {PartDocument.DisplayName}");
                HasFlatPattern = true;
            }
        }
    }
}
