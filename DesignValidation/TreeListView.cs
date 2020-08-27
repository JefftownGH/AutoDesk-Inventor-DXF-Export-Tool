using DesignValidationLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DesignValidation
{
    public static class TreeListView
    {
        public static BrightIdeasSoftware.TreeListView CreateTreeListView()
        {
            BrightIdeasSoftware.TreeListView treeListView = new BrightIdeasSoftware.TreeListView();

            treeListView.Location = new System.Drawing.Point(20, 100);
            treeListView.Size = new System.Drawing.Size(275, 325);
            treeListView.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
            treeListView.UseAlternatingBackColors = true;
            treeListView.AlternateRowBackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            treeListView.CheckBoxes = false;
            treeListView.CheckedAspectName = "Ticked";
            treeListView.ExpandAll();

            //need to create an image list and assign this to "SmallImageList"

            return treeListView;
        }

        public static List<TreeViewNode> BuildTreeViewNodeDataNested(List<Assembly> assemblyList)
        {
            #region Explanation

            //we start off with a list of assemblies that have 1. an ID, 2. a ParentID
            //We Initially loop through each Assembly, if it has a parent ID of 0 we create a new instance of TreeViewNode and add it to the List<TreeViewNode> treeViewNodeData
            //If it has a parent ID > 0, we call the ListSearch method that will return the parent object 
            //a new instance of TreeViewNode is created and added to the List<TreeViewNode> Children of the parent Object 
            //In this way we can build a heirarchical structure of objects from the "flat" List<Assembly> assemblyList

            #endregion

            List<TreeViewNode> treeViewNodeData = new List<TreeViewNode>();

            foreach (Assembly assembly in assemblyList)
            {
                if (assembly.ParentID > 0)
                {
                    TreeViewNode parentAssembly = null;

                    //retrieves the parent TreeViewNode object so a "Child" object can be added to List<TreeViewNode> Children
                    ListSearch(treeViewNodeData, ref parentAssembly, assembly.ParentID);

                    //parentAssembly will be null if a ParentID cannot be found
                    if (parentAssembly == null)
                        continue;

                    //Creates a new TreeViewNode object and adds it to parentAssembly.Children
                    parentAssembly.Children.Add(AddNewTreeViewNode(assembly));
                }
                else
                    treeViewNodeData.Add(AddNewTreeViewNode(assembly));
            }
            return treeViewNodeData;
        }

        public static void ListSearch(List<TreeViewNode> treeViewNodeData, ref TreeViewNode parentNode, int targetID)
        {
            foreach (TreeViewNode subTreeViewNode in treeViewNodeData.Where(x => x.assemblyNode == true))
            {
                #region Explanation

                //iterates through each of the Children of subTreeViewNode
                //recursive function call to loop through each of its children
                //TreeViewNode parentNode is passed by ref to avoid having a return type and dealing with strange behaviour as recursive function
                //unwinds through stackframes

                #endregion

                if (subTreeViewNode.ID == targetID)
                    parentNode = subTreeViewNode;

                ListSearch(subTreeViewNode.Children, ref parentNode, targetID);
            }
        }

        public static TreeViewNode AddNewTreeViewNode(Assembly assembly)
        {
            TreeViewNode assemblyNode = new TreeViewNode(assembly.Name, assembly.ImportStatus, assembly.ID, assembly.ParentID);

            foreach (Part part in assembly.PartList)
                assemblyNode.Children.Add(new TreeViewNode(part.Name, part.ImportStatus));

            foreach (SheetmetalPart sheetMetalPart in assembly.SheetmetalPartList)
                assemblyNode.Children.Add(new TreeViewNode(sheetMetalPart.Name, sheetMetalPart.ImportStatus));

            return assemblyNode;
        }
    }
}
