using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesignValidation
{
    public class TreeViewNode
    {
        public string Name { get; set; }
        public string Column1 { get; set; }
        public string Column2 { get; set; }
        public string Column3 { get; set; }
        public List<TreeViewNode> Children { get; set; }
        public TreeViewNode(string name,string col1, string col2, string col3)
        {
            this.Name = name;
            this.Column1 = col1;
            this.Column2 = col2;
            this.Column3 = col3;
            this.Children = new List<TreeViewNode>();
        }

        public BrightIdeasSoftware.TreeListView CreateTreeListView()
        {
            BrightIdeasSoftware.TreeListView treeListView = new BrightIdeasSoftware.TreeListView();

            treeListView.Location = new System.Drawing.Point(20, 100);
            treeListView.Size = new System.Drawing.Size(650, 325);
            treeListView.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            treeListView.UseAlternatingBackColors = true;
            treeListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(204, 229, 255);

            return treeListView;
        }
    }
}
