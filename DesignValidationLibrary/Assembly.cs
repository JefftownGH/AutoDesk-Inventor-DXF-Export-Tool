using Inventor;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace DesignValidationLibrary
{
    public class Assembly 
    {
        public string Name { get; set; }
        public int ParentID { get; set; }
        public int ID { get; set; }
        public List<Part> partList { get;} = new List<Part>();
        public List<SheetmetalPart> sheetmetalPartList { get; } = new List<SheetmetalPart>();
        public List<Part> ComponentList { get;} = new List<Part>();
        public AssemblyDocument assemblyDocument { get; set; }

        public Assembly(AssemblyDocument assemblyDocument, int ParentID, int ID)
        {
            this.ParentID = ParentID;
            this.ID = ID;

            Contract.Requires(assemblyDocument != null,"something went wrong... assemblyDocument is null");

            this.assemblyDocument = assemblyDocument;
            Name = assemblyDocument.DisplayName;
        }
    }
}

