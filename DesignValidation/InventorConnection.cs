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
