using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesignValidationLibrary;

namespace DesignValidation
{
    public static class SheetMetalListView
    {
        //Creating the object list view
        public static BrightIdeasSoftware.TreeListView CreateTreeListView()
        {
            BrightIdeasSoftware.TreeListView treeListView = new BrightIdeasSoftware.TreeListView();

            treeListView.Location = new System.Drawing.Point(310, 100);
            treeListView.Size = new System.Drawing.Size(500, 325);
            treeListView.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            treeListView.UseAlternatingBackColors = true;
            treeListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            treeListView.CheckBoxes = true;
            treeListView.CheckedAspectName = "Ticked";
            
            return treeListView;
        }

        //building the List<TreeViewNode>
        public static List<TreeViewNode> BuildSheetMetalNodeData(List<Assembly> assemblyList) 
        {
            List<TreeViewNode> sheetMetalNodeData = new List<TreeViewNode>();

            //pass along the assembly name as well...

            foreach (Assembly assembly in assemblyList)
                foreach (SheetmetalPart sheetMetalPart in assembly.sheetmetalPartList)
                    sheetMetalNodeData.Add(new TreeViewNode(sheetMetalPart.Name, 
                        sheetMetalPart.hasFlatPattern.ToString(),sheetMetalPart.numberOfBends.ToString(),"-"));

            List<TreeViewNode> distinctSheetMetalNodeDataList = sheetMetalNodeData.GroupBy(x => x.Name).Select(y => y.First()).ToList();

            return distinctSheetMetalNodeDataList;
        }
    }
}
