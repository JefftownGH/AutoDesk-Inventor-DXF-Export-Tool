using Inventor;
using ProgramUtilities;
using System.Collections.Generic;
using System.Linq;

namespace DesignValidationLibrary
{
    public class TopLevel 
    {
        public string Name { get; set; }
        public int noOccurrences { get; set; }
        public List<Assembly> AssemblyList { get; } = new List<Assembly>();
        public List<int> IDlist { get; } = new List<int>();

        //Builds the Assembly, Part and Sheetmetal part objects
        public void TraverseAssembly(AssemblyDocument currentAsmDocument, int parentID)
        {
            int currentID = GetAssemblyID();

            if (currentAsmDocument == null)
                return;

            Assembly assembly = NewAssembly(currentAsmDocument, parentID, currentID);

            AssemblyList.Add(assembly);

            ComponentOccurrences occurrences = currentAsmDocument.ComponentDefinition.Occurrences;

            noOccurrences += occurrences.Count;

            foreach (ComponentOccurrence occurrence in occurrences)
            {
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
                return IDlist.Last() + 1;

            else return 1;
        }

        //this will be chagned out with dependency injection once code is running correctly
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
