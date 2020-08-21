
using Inventor;
using ProgramUtilities;

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
            catch
            {
                //This will throw a message up to the part error list to show there has been an error obtaining the flat pattern 
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

            return totalCuttingLength;
        }
    }
}
