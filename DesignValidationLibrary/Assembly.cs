using System;
using System.Collections.Generic;
using System.Text;
using Inventor;
using System.Diagnostics;

namespace DesignValidationLibrary
{
    public class Assembly
    {
        public string Name { get; set; }
        public int ParentID { get; set; }
        public int ID { get; set; }
        public List<Part> ComponentList { get; set; }
        public AssemblyDocument assemblyDocument { get; set; }
        public Assembly()
        {
            ComponentList = new List<Part>();
        }
    }
}

