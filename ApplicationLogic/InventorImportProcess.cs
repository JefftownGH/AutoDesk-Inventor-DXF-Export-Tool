using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignValidationLibrary;
using ProgramUtilities;
using Inventor;
using ExportLibrary;

namespace ApplicationLogic
{
    public class InventorImportProcess
    {
        public InventorConnection inventorConnection { get; } = new InventorConnection();

        public Application thisApplication { get; private set; } = null;

        public TopLevel topLevel { get; } = new TopLevel();

        /// Delegates to allow the UI layer to display outputs/Info while maintaining loose coupling with the application logic
        public delegate void InventorConnectionStatus(bool successfulConnectionEstablished);
        public delegate void ValidDocumentType(bool validDocumentType);
        public delegate void UpdateProgressBar(bool processComplete);

        public bool ImportANewInventorModel(InventorConnectionStatus inventorConnectionStatus, ValidDocumentType validDocumentType, UpdateProgressBar updateProgressBar)
        {
            thisApplication = inventorConnection.CreateInventorConnection();

            if (thisApplication == null)
            {
                inventorConnectionStatus(false);
                return false;
            }

            else
                inventorConnectionStatus(true);

            if (!DetermineDocumentType(validDocumentType, updateProgressBar))
                return false;

            updateProgressBar(true);

            return false;
        }

        public bool DetermineDocumentType(ValidDocumentType validDocumentType, UpdateProgressBar updateProgressBar)
        {
            DocumentTypeEnum currentDocumentType;
            //a try/catch block is used for when no document is open and the assignment of a a value to currentDocumentType fails

            try
            {
                currentDocumentType = thisApplication.ActiveDocument.DocumentType;

                if (DocumentInfo.IsAssemblyDocument(currentDocumentType))
                {
                    topLevel.TraverseAssembly((AssemblyDocument)thisApplication.ActiveDocument, 0);
                    validDocumentType(true);
                    return true;
                }

                else if ((DocumentInfo.IsPartDocument(currentDocumentType)))
                {
                    validDocumentType(false);
                    return false;
                }

                else
                {
                    validDocumentType(false);
                    return false;
                }
            }
            catch
            {
                validDocumentType(false);
                updateProgressBar(true);
                return false;
            }
        }

        //used to return an instance of top level so that methods can be "hooked" into the ProgressBarEventHandler
        public TopLevel GetToplevel()  
        {
            return topLevel;
        }
    }
}
