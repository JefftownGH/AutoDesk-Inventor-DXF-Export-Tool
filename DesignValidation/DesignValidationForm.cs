using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inventor;
using System.Diagnostics;
using DesignValidationLibrary;
using MaterialPropertiesLibrary;
using ProgramUtilities;

namespace DesignValidation
{
    public partial class DesignValidationForm : Form
    {
        public InventorConnection inventorConnection = new InventorConnection();
        private Inventor.Application ThisApplication = null;

        private TopLevel topLevel = new TopLevel();
        private BindingSource errorList = new BindingSource();
        private List<TreeViewNode> treeViewNodeData = new List<TreeViewNode>();
        private BrightIdeasSoftware.TreeListView treeListView;

        public DesignValidationForm()
        {
            InitializeComponent();
            InventorConnection();
            AddTree();
            FillTree();
        }

        private void AddTree()
        {
            treeListView = TreeListView.CreateTreeListView();
            Controls.Add(treeListView);
        }

        private void FillTree()
        {
            treeListView.Clear();
            treeListView.CanExpandGetter = x => (x as TreeViewNode).Children.Count > 0;
            treeListView.ChildrenGetter = x => (x as TreeViewNode).Children;

            var nameCol = new BrightIdeasSoftware.OLVColumn("Name", "Name");
            nameCol.AspectGetter = x => (x as TreeViewNode).Name;

            var col1 = new BrightIdeasSoftware.OLVColumn("Column1", "Column1");
            col1.AspectGetter = x => (x as TreeViewNode).Column1;

            var col2 = new BrightIdeasSoftware.OLVColumn("Column2", "Column2");
            col2.AspectGetter = x => (x as TreeViewNode).Column2;

            var col3 = new BrightIdeasSoftware.OLVColumn("Column3", "Column3");
            col3.AspectGetter = x => (x as TreeViewNode).Column3;

            treeListView.Columns.Add(nameCol);
            treeListView.Columns.Add(col1);
            treeListView.Columns.Add(col2);
            treeListView.Columns.Add(col3);

            treeListView.Roots = treeViewNodeData;

            
        }

        private void InventorConnection()
        {
            ThisApplication = inventorConnection.CreateInventorConnection();
            if (ThisApplication == null)
                MessageBox.Show("Unable to establish a connection with Inventor");
        }

        private void DetermineDocumentType()
        {
            if (DocumentInfo.IsAssemblyDocument(ThisApplication.ActiveDocument.DocumentType))
                topLevel.TraverseAssembly((AssemblyDocument)ThisApplication.ActiveDocument, 0);

            else if (DocumentInfo.IsPartDocument(ThisApplication.ActiveDocument.DocumentType))
                MessageBox.Show("This is a part document, currently only assembly documents are supported");
        }

        private void Import_Click(object sender, EventArgs e)
        {
            DetermineDocumentType();
            UpdateProgressBar(true);
            DesignCheck();
            UpdateProgressBar(true);
            treeViewNodeData =TreeListView.BuildTreeViewNodeData(topLevel.AssemblyList);
            FillTree();
        }

        private void InspectComponent_Click(object sender, EventArgs e)
        {
            foreach(TreeViewNode treeListViewNode in treeListView.SelectedObjects)
            {
                string selectedNode = treeListViewNode.Name;

                foreach (Assembly assembly in topLevel.AssemblyList)
                {
                    if(selectedNode == assembly.Name)
                        MessageBox.Show("Please select a component");

                    foreach (Part part in assembly.partList)
                    {
                        if(selectedNode == part.Name)
                            InspectPartView(part);
                    }

                    foreach (SheetmetalPart sheetmetalPart in assembly.sheetmetalPartList)
                    {
                        if (selectedNode == sheetmetalPart.Name)
                            InspectPartView(sheetmetalPart);
                    }
                }
            }
        }

        private void InspectPartView(Part part)
        {
            errorList.ResetBindings(false);
            errorList.DataSource = part.errorList;
            ComponentErrors.DataSource = errorList;
        }

        public void DesignCheck()
        {
            UpdateProgressBar(false);
            foreach(Assembly asm in topLevel.AssemblyList)
            {
                foreach (SheetmetalPart sheetmetalPart in asm.sheetmetalPartList)
                {
                    sheetmetalPart.GetFlatPatternProperties();
                    UpdateProgressBar(false);
                }
            }
        }

        //public void SelectionChange(object sender, treeListView.SelectionChanged arg)
        //{

        //}

        public void UpdateProgressBar(bool processComplete)
        {
            ProgressBar.Visible = true;
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = topLevel.noOccurrences;
            ProgressBar.Step = 1;
            ProgressBar.PerformStep();

            if(processComplete)
            {
                ProgressBar.Value = 0;
                ProgressBar.Visible = false;
            }
        }

        private void AddMaterial_Click(object sender, EventArgs e)
        {
            MaterialProperties materialProperties = new MaterialProperties();
            materialProperties.Show();
        }
    }
}
