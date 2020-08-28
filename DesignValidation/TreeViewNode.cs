using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventor;
using DesignValidationLibrary;
using BrightIdeasSoftware;
using System.ComponentModel;

namespace DesignValidation
{
    public class TreeViewNode 
    {
        public string Name { get; }
        public string Column1 { get; }
        public string Column2 { get; }
        public string Column3 { get; }

        public int ID { get; }
        public int parentID { get; }
        public int ImageIndex { get; }

        public bool AssemblyNode { get; }

        public List<TreeViewNode> Children { get; } = new List<TreeViewNode>();
        public bool Ticked { get; set; } = false;

        //TreeViewList Assembly constructor
        public TreeViewNode(string name,string col1, int ID, int parentID)
        {
            Name = name;
            Column1 = col1;
            this.ID = ID;
            this.parentID = parentID;
            AssemblyNode = true;
            ImageIndex = 0;
        }

        //TreeViewList Part Constructor
        public TreeViewNode(string name, string col1, bool sheetMetalPart)
        {
            Name = name;
            Column1 = col1;
            AssemblyNode = false;

            if (sheetMetalPart)
                ImageIndex = 2;

            else
                ImageIndex = 1;
        }

        //SheetmetalListView Constructor
        public TreeViewNode(string name, string col1, string col2, string col3)
        {
            Name = name;
            Column1 = col1;
            Column2 = col2;
            Column3 = col3;
            AssemblyNode = false;
            ImageIndex = 2;
        }
    }
}
