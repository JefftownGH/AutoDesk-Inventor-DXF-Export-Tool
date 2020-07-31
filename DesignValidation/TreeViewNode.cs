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
        public string Name { get; set; }

        public string Column1 { get; set; }

        public string Column2 { get; set; }

        public string Column3 { get; set; }

        public int ID { get; set; }

        public int parentID { get; set; }

        public bool assemblyNode { get; set; }

        public List<TreeViewNode> Children { get; set; }

        public TreeViewNode(string name,string col1, string col2, string col3, int ID, int parentID)
        {
            Name = name;
            Column1 = col1;
            Column2 = col2;
            Column3 = col3;
            this.ID = ID;
            this.parentID = parentID;
            Children = new List<TreeViewNode>();
            assemblyNode = true;
        }

        public TreeViewNode(string name, string col1, string col2, string col3)
        {
            Name = name;
            Column1 = col1;
            Column2 = col2;
            Column3 = col3;
            Children = new List<TreeViewNode>();
            assemblyNode = false;
        }
    }
}
