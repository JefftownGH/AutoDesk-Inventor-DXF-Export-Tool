using System;
using System.Collections.Generic;
using System.Text;
using Inventor;
using System.Linq;
using ProgramUtilities;

namespace DesignValidationLibrary
{
    public class TopLevel
    {
        public string Name { get; set; }
        public int noOccurrences { get; set; }
        public List<Assembly> AssemblyList { get; set; } = new List<Assembly>();
        public List<int> IDlist { get; set; } = new List<int>();
   
        public void TraverseAssembly(AssemblyDocument currentAsmDocument, int parentID)
        {
            int currentID = GetAssemblyID();

            Assembly assembly = NewAssembly(currentAsmDocument, parentID, currentID);
            AssemblyList.Add(assembly);

            ComponentOccurrences occurrences = currentAsmDocument.ComponentDefinition.Occurrences;
            noOccurrences += occurrences.Count;

            foreach(ComponentOccurrence occurrence in occurrences)
            {
                if (DocumentInfo.IsPartDocument(occurrence.DefinitionDocumentType))
                {
                    PartDocument partDocument = (PartDocument)occurrence.Definition.Document;

                    if (DocumentInfo.IsSheetMetalPart(partDocument.SubType))
                        assembly.ComponentList.Add(NewSheetMetalPart(partDocument));

                    else
                        assembly.ComponentList.Add(NewPart(partDocument));
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

        private static Assembly NewAssembly(AssemblyDocument assemblyDocument, int parentID, int currentID)
        {
            return new Assembly() { Name = assemblyDocument.DisplayName, assemblyDocument = assemblyDocument, ParentID = parentID, ID = currentID };
        }

        private static SheetmetalPart NewSheetMetalPart(PartDocument partDocument)
        {
            return new SheetmetalPart() {Name = partDocument.DisplayName, partDocument = partDocument };
        }

        private static Part NewPart(PartDocument partDocument)
        {
            return new Part() { Name = partDocument.DisplayName, partDocument = partDocument };
        }
    }
}
