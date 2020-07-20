using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventor;
using DesignValidationLibrary;

namespace DesignValidation
{
    public static class TreeListView
    {
        public static BrightIdeasSoftware.TreeListView CreateTreeListView()
        {
            BrightIdeasSoftware.TreeListView treeListView = new BrightIdeasSoftware.TreeListView();

            treeListView.Location = new System.Drawing.Point(20, 100);
            treeListView.Size = new System.Drawing.Size(650, 325);
            treeListView.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
            treeListView.UseAlternatingBackColors = true;
            treeListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(204, 229, 255);

            return treeListView;
        }

        public static List<TreeViewNode> BuildTreeViewNodeData(List<Assembly> assembly)
        {
            List<TreeViewNode> treeViewNodeData = new List<TreeViewNode>();

            foreach (Assembly subAssembly in assembly)
            {
                TreeViewNode subAssemblyNode = new TreeViewNode(subAssembly.Name, "-", "-", "-");
                treeViewNodeData.Add(subAssemblyNode);

                foreach (Part part in subAssembly.partList)
                    subAssemblyNode.Children.Add(new TreeViewNode(part.Name, "-", "-", "-"));

                foreach (SheetmetalPart sheetMetalPart in subAssembly.sheetmetalPartList)
                    subAssemblyNode.Children.Add(new TreeViewNode(sheetMetalPart.Name, 
                        sheetMetalPart.hasFlatPattern.ToString(), sheetMetalPart.numberOfBends.ToString(), "-"));
            }
            return treeViewNodeData;
        }
    }
}
