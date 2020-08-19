using Inventor;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace DesignValidationLibrary
{
    public class Part 
    {
        public string Name { get; private set; }
        public string material { get; set; }

        public PartDocument partDocument { get; private set; }

        public List<string> errorList { get;} = new List<string>();

        public Part(PartDocument partDocument)
        {
            Contract.Requires(partDocument != null, "something went wrong... assemblyDocument is null");

            this.partDocument = partDocument;

            Name = partDocument.DisplayName;
        }
    }
}

