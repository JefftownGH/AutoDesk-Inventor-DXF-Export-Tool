using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventor;
using DesignValidationLibrary;
using BrightIdeasSoftware;

namespace DesignValidation
{
    public class TreeViewNode
    {
        //[OLVColumn("Part Name", Width = 150, DisplayIndex = 1, TextAlign = HorizontalAlignment.Left)]
        public string Name { get; set; }

        //[OLVColumn("Flat Pattern?", Width = 100, DisplayIndex = 2, TextAlign = HorizontalAlignment.Left)]
        public string Column1 { get; set; }

        //[OLVColumn("Bend No.", Width = 100, DisplayIndex = 3, TextAlign = HorizontalAlignment.Left)]
        public string Column2 { get; set; }

        //[OLVColumn("Export DXF?", Width = 100, DisplayIndex = 4, TextAlign = HorizontalAlignment.Left)]
        public string Column3 { get; set; }

        //[OLVColumn(IsVisible = false)]
        public List<TreeViewNode> Children { get; set; }

        public bool ticked = false;


        public TreeViewNode(string name,string col1, string col2, string col3)
        {
            Name = name;
            Column1 = col1;
            Column2 = col2;
            Column3 = col3;
            Children = new List<TreeViewNode>();
        }
    }
}
