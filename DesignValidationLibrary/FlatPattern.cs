
using Inventor;
using ProgramUtilities;
using System;

namespace DesignValidationLibrary
{
    public class FlatPattern
    {
        //An instance of the flatpattern class is spun up when a new instance for the sheetmetal class created
        private Face flatPattern;

        private SheetMetalComponentDefinition sheetMetalCompDef;

        private InventorConnection inventorConnection;

        public FlatPattern(SheetMetalComponentDefinition sheetMetalCompDef)
        {
            this.sheetMetalCompDef = sheetMetalCompDef;

            inventorConnection = new InventorConnection();
        }

        public bool HasFlatPattern()
        {
            if (!sheetMetalCompDef.HasFlatPattern)
                if (!CreateFlatPattern())
                {
                    flatPattern = null;
                    return false;
                }

            flatPattern = sheetMetalCompDef.FlatPattern.BottomFace;

            return true;
        }

        private bool CreateFlatPattern()
        {
            try
            {
                sheetMetalCompDef.Unfold();
                return true;
            }
            catch (Exception e)
            {
                EventLogger.CreateLogEntry(e.Message + " " + e.StackTrace);
                return false;
            }
        }

        public double TotalLengthFlatPatternLoops(double totalCuttingLength = 0)
        {
            if (!HasFlatPattern())
                return 0;

            MeasureTools measureTools = inventorConnection.GetMeasureTools();

            foreach (EdgeLoop edgeLoop in flatPattern.EdgeLoops)
                totalCuttingLength += measureTools.GetLoopLength(edgeLoop);

            return Math.Round(totalCuttingLength);
        }
    }
}
