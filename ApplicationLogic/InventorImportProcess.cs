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
        public delegate void UpdateProgressBar(bool processComplete);

        public bool ImportANewInventorModel(InventorConnectionStatus inventorConnectionStatus, ValidDocumentType validDocumentType, UpdateProgressBar updateProgressBar)
        {
            //does this need a bool return type or should it be null?

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

            if (!DetermineDocumentType(validDocumentType, updateProgressBar))
                return false;

            CreateFlatPatterns(updateProgressBar);

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

                updateProgressBar(true);

                return false;
            }
        }

        public void CreateFlatPatterns(UpdateProgressBar updateProgressBar)
        {
            foreach(Assembly asm in topLevel.AssemblyList)
            {
                foreach(SheetmetalPart sheetmetalPart in asm.sheetmetalPartList)
                {
                    sheetmetalPart.GetFlatPatternProperties();
                }
            }

            updateProgressBar(true);
        }

        //used to return an instance of top level so that methods can be "hooked" into the ProgressBarEventHandler
        public TopLevel GetToplevel()
        {
            return topLevel;
        }
    }
}
