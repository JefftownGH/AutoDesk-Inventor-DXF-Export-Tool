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

        public bool assemblyNode { get; }

        public List<TreeViewNode> Children { get; } = new List<TreeViewNode>();

        private bool ticked = false;
        public bool Ticked
        {
            get { return ticked; }

            set
            {
                ticked = value;
            }
        }
        //TreeViewList Assembly constructor
        public TreeViewNode(string name,string col1, int ID, int parentID)
        {
            Name = name;
            Column1 = col1;
            this.ID = ID;
            this.parentID = parentID;
            assemblyNode = true;
        }

        //TreeViewList Part Constructor
        public TreeViewNode(string name, string col1)
        {
            Name = name;
            Column1 = col1;
        }

        //SheetmetalListView Constructor
        public TreeViewNode(string name, string col1, string col2, string col3)
        {
            Name = name;
            Column1 = col1;
            Column2 = col2;
            Column3 = col3;
            assemblyNode = false;
        }
    }
}
