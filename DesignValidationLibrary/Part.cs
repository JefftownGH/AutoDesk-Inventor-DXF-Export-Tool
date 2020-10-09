using Inventor;
using System;
using System.Diagnostics.Contracts;

namespace DesignValidationLibrary
{
    public class Part 
    {
        public string Name { get; }
        public string Material { get; }

        public string ImportStatus{ get; set;}

        //do as inheritance??
        public PartDocument PartDocument { get; }

        public Part(PartDocument partDocument)
        {
            Contract.Requires(partDocument != null, "something went wrong... assemblyDocument is null");

            PartDocument = partDocument;
            Name = partDocument.DisplayName;
            Material = partDocument.ActiveMaterial.Name;
            ImportStatus= "Success";
        }
    }
}

