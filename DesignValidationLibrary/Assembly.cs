using Inventor;
using System.Collections.Generic;

namespace DesignValidationLibrary
{
    public class Assembly 
    {
        public string Name { get; set; }
        public int ParentID { get; set; }
        public int ID { get; set; }
        public List<Part> ComponentList { get; set; } = new List<Part>();
        public AssemblyDocument assemblyDocument { get; set; }
    }
}

