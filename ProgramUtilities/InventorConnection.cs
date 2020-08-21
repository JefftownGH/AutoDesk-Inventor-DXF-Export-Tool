using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;

namespace ProgramUtilities
{
    public class InventorConnection
    {
        public Application thisApplication { get; private set; } = null;

        public MeasureTools measureTools { get; private set; } = null;

        public Application CreateInventorConnection()
        {
            try
            {
                thisApplication = (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application");

                measureTools = thisApplication.MeasureTools;

                return thisApplication;
            }
            catch
            {
                return null;
            }
        }

        public bool InventorReady()
        {
            return thisApplication.Ready;
        }

        public MeasureTools GetMeasureTools()
        {
            CreateInventorConnection();

            return measureTools;
        }
    }
}
