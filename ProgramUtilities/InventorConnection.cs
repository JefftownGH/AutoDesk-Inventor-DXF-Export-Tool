using Inventor;

namespace ProgramUtilities
{
    public class InventorConnection
    {
        public Application ThisApplication { get; private set; } = null;

        public MeasureTools MeasureTools { get; private set; } = null;

        public Application CreateInventorConnection()
        {
            try
            {
                ThisApplication = (Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application");

                MeasureTools = ThisApplication.MeasureTools;

                return ThisApplication;
            }
            catch
            {
                return null;
            }
        }

        public bool InventorReady() => ThisApplication.Ready;

        public MeasureTools GetMeasureTools()
        {
            CreateInventorConnection();
            return MeasureTools;
        }
    }
}
