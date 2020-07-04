using System;
using System.Collections.Generic;
using System.Text;

namespace DesignValidationLibrary
{
    public class TopLevel
    {
        public string Name { get; set; }
        public int noOccurrences { get; set; }
        public List<Assembly> AssemblyList { get; set; }
        public List<int> IDlist { get; set; }
        public TopLevel()
        {
            AssemblyList = new List<Assembly>();
            IDlist = new List<int>();
        }
    }
}
