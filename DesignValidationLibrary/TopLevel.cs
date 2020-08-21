using Inventor;
using ProgramUtilities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace DesignValidationLibrary
{
    public class TopLevel 
    {
        public int noOccurrences { get; private set; }

        public List<Assembly> AssemblyList { get; } = new List<Assembly>();

        public List<int> IDlist { get; } = new List<int>();

        public delegate void ProgressBarEventHandler(object source, EventArgs args);

        public event ProgressBarEventHandler UpdateProgress;
         
        //Builds the Assembly, Part and Sheetmetal part objects using recursion
        public void TraverseAssembly(AssemblyDocument currentAsmDocument, int parentID)
        {
            int currentID = GetAssemblyID();

            //to stop instantiating a new instance of Assembly with a null AssemblyDocument - should never happen anyway
            if (currentAsmDocument == null)
                return;

            Assembly assembly = NewAssembly(currentAsmDocument, parentID, currentID);

            AssemblyList.Add(assembly);

            ComponentOccurrences occurrences = currentAsmDocument.ComponentDefinition.Occurrences;

            noOccurrences += occurrences.Count;

            foreach (ComponentOccurrence occurrence in occurrences)
            {
                //the UI layer is listening for this Event to increment the progress bar
                IncrementProgressBar();

                if (DocumentInfo.IsPartDocument(occurrence.DefinitionDocumentType))
                {
                    PartDocument partDocument = (PartDocument)occurrence.Definition.Document;

                    if (DocumentInfo.IsSheetMetalPart(partDocument.SubType))
                        assembly.sheetmetalPartList.Add(NewSheetMetalPart(partDocument));

                    else
                        assembly.partList.Add(NewPart(partDocument));
                }

                if (DocumentInfo.IsAssemblyDocument(occurrence.DefinitionDocumentType))
                {
                    AssemblyDocument subAssemblyDocument = (AssemblyDocument)occurrence.Definition.Document;

                    TraverseAssembly(subAssemblyDocument, assembly.ID);
                }
            }
        }

        private int GetAssemblyID()
        {
            if (IDlist.Any())
                IDlist.Add(IDlist.Last() + 1);

            else
                IDlist.Add(1);
   
                return IDlist.Last();
        }

        protected virtual void IncrementProgressBar()
        {
            if (UpdateProgress != null)
                UpdateProgress(this, EventArgs.Empty);
        }

        //this will be chagned out with dependency injection once code is running correctly/concrete implementations are only temporary

        private static Assembly NewAssembly(AssemblyDocument assemblyDocument, int parentID, int currentID)
        {
            return new Assembly(assemblyDocument, parentID,currentID);
        }

        private static SheetmetalPart NewSheetMetalPart(PartDocument partDocument)
        {
            return new SheetmetalPart(partDocument);
        }

        private static Part NewPart(PartDocument partDocument)
        {
            return new Part(partDocument);
        }
    }
}
