using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;

namespace DesignValidation
{
    public class InventorConnection
    {
        private Application thisApplication { get; set; } = null;

        //method pertinent to the inventor connection will be added here instead of in the main form.

        public Application CreateInventorConnection()
        {
            try
            {
                return thisApplication = (Inventor.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Inventor.Application");
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
    }
}
