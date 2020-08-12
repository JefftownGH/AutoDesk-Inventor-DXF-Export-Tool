using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using ProgramUtilities;
using System.Windows.Forms;

namespace DesignValidationLibrary
{
    public class FlatPattern
    {
        //An instance of the flatpattern class is spun up when a new instance for the sheetmetal class

        //this is used in total cut length calculation ie counting edge loops which requires a Face object
        private Face flatPattern { get; set; } 

        private SheetMetalComponentDefinition sheetMetalCompDef { get; set; }

        private InventorConnection inventorConnection { get; set; }

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
