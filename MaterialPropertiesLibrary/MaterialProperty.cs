using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialPropertiesLibrary
{
    public class MaterialProperty
    {
        public string materialName { get; set; }
        public string materialDescription { get; set; }
        public decimal costPerKilogram { get; set; }
        public double maxSheetLength { get; set; }
        public double maxSheetWidth { get; set; }
        public double kFactor { get; set; }
    }
}
