using Inventor;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace DesignValidationLibrary
{
    public class Assembly 
    {
        //assembly is simply a "bucket" for the list of sheetmetal parts and parts

        public string Name { get; }

        public int ParentID { get;} 
        public int ID { get; }

        public List<Part> partList { get;} = new List<Part>();
        public List<SheetmetalPart> sheetmetalPartList { get; } = new List<SheetmetalPart>();

        public AssemblyDocument assemblyDocument { get; }

        public Assembly(AssemblyDocument assemblyDocument, int ParentID, int ID)
        {
            this.ParentID = ParentID;

            this.ID = ID;

            //check if code contract is required, more for testing purposes at the moment
            Contract.Requires(assemblyDocument != null,"something went wrong... assemblyDocument is null");

            this.assemblyDocument = assemblyDocument;

            Name = assemblyDocument.DisplayName;
        }
    }
}

