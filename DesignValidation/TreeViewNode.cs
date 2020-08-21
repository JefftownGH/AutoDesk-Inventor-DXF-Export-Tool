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

        public List<TreeViewNode> Children { get;}

        //no need for getter and setter to be explicitly type like this... why did i do it?

        private bool ticked = false;
        public bool Ticked
        {
            get { return ticked; }

            set
            {
                ticked = value;
            }
        }

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
