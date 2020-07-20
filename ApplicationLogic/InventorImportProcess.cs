using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignValidationLibrary;
using ProgramUtilities;
using Inventor;

namespace ApplicationLogic
{
    public class InventorImportProcess
    {
        public InventorConnection inventorConnection { get; set; } = new InventorConnection();
        public Inventor.Application thisApplication { get; set; } = null;
        public TopLevel topLevel { get; set; } = new TopLevel();

        /// Delegates to allow the UI layer to display outputs/Info while maintaining loose coupling with the application logic

        public delegate void InventorConnectionStatus(bool successfulConnectionEstablished);

        public delegate void ValidDocumentType(bool validDocumentType);

        public delegate void UpdateProgressBar(bool processComplete, int noProcessSteps);

        //1. get the Inventor connection/this application isntance

        public bool ImportANewInventorModel(InventorConnectionStatus inventorConnectionStatus, ValidDocumentType validDocumentType)
        {
            thisApplication = inventorConnection.CreateInventorConnection();

            //Attempting to create an InventorConnection..

            if (thisApplication == null)
            {
                inventorConnectionStatus(false);
                return false;
            }

            else
                inventorConnectionStatus(true);

            //Checking to see if the active document is valid..

            if (!DetermineDocumentType(validDocumentType))
                return false;

            CreateFlatPatterns();

            return false;
        }

        public bool DetermineDocumentType(ValidDocumentType validDocumentType)
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
                    //when support for single parts is added more logic to be added here
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
                return false;
            }
        }

        public void CreateFlatPatterns()
        {
            foreach(Assembly asm in topLevel.AssemblyList)
            {
                foreach(SheetmetalPart sheetmetalPart in asm.sheetmetalPartList)
                {
                    sheetmetalPart.GetFlatPatternProperties();
                }
            }
        }

        public TopLevel GetToplevel()
        {
            return topLevel;
        }
    }
}
