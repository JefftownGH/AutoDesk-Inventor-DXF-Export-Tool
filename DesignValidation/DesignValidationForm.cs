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
using ApplicationLogic;
using BrightIdeasSoftware;

namespace DesignValidation
{
    public partial class DesignValidationForm : Form
    {
        private TopLevel topLevel = new TopLevel();

        private BindingSource errorList = new BindingSource();

        private List<TreeViewNode> treeViewNodeData = new List<TreeViewNode>();

        private BrightIdeasSoftware.TreeListView treeListView;

        public InventorImportProcess inventorImportProcess = new InventorImportProcess();

        public DesignValidationForm()
        {
            InitializeComponent();
            AddTree();
        }

        private void SubScribeToEvent(TopLevel topLevel) => topLevel.UpdateProgress += OnProgressBarIncrement;

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

            var nameCol = new OLVColumn("Part Name", "Part Name");
            nameCol.AspectGetter = x => (x as TreeViewNode).Name;
            nameCol.Width = 200;

            var col1 = new OLVColumn("Flat Pattern", "Flat Pattern");
            col1.AspectGetter = x => (x as TreeViewNode).Column1;
            col1.Width = 100;

            var col2 = new OLVColumn("Bend No.", "Bend No.");
            col2.AspectGetter = x => (x as TreeViewNode).Column2;
            col2.Width = 100;

            var col3 = new OLVColumn("Info", "Column3");
            col3.AspectGetter = x => (x as TreeViewNode).Column3;
            col3.Width = 100;

            treeListView.Columns.Add(nameCol);
            treeListView.Columns.Add(col1);
            treeListView.Columns.Add(col2);
            treeListView.Columns.Add(col3);

            //Generator.GenerateColumns(treeListView, typeof(TreeViewNode), true);

            treeListView.Roots = treeViewNodeData; 
        }

        public void Import_Click(object sender, EventArgs e)
        {
            //retrieves a null instance of the TopLevel class
            topLevel = inventorImportProcess.GetToplevel();

            //subscribes to the event in the TopLevel class to update the progress bar
            SubScribeToEvent(topLevel);

            //begins the import process
            inventorImportProcess.ImportANewInventorModel(InventorConnectionStatus, ValidDocumentType, UpdateProgressBar);

            //creates the TreeListView once the import process is completed
            //treeViewNodeData =TreeListView.BuildTreeViewNodeData(topLevel.AssemblyList);

            //add logic here to determine the structure of TreeViewNodeData ie, either flat or nested

            //this is only for testing purposes
            treeViewNodeData = TreeListView.BuildTreeViewNodeDataNested(topLevel.AssemblyList);

            FillTree();

            List<SheetmetalPart> tempSheetmetalPartList = new List<SheetmetalPart>();

            foreach (Assembly assembly in topLevel.AssemblyList)
                foreach (SheetmetalPart sheetmetalpart in assembly.sheetmetalPartList)
                    tempSheetmetalPartList.Add(sheetmetalpart);
        }

        //this need to be re-writen so that it no longer takes a button click to inspect list box items in the ListBox
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

        //recieves an event from the topLevel class
        public void OnProgressBarIncrement(object source, EventArgs e)
        {
            //method that increments the progress bar
            UpdateProgressBar(false);
        }

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

        //the add material functionality is not going to be included for the initial release
        //the Json functionality will be reused to allow for program properties to be saved

        private void AddMaterial_Click(object sender, EventArgs e)
        {
            MaterialProperties materialProperties = new MaterialProperties();
            materialProperties.Show();
        }

        public void InventorConnectionStatus(bool successfulConnectionEstablished)
        {
            if (!successfulConnectionEstablished)
                MessageBox.Show("Unable to esablish a connection with Autodesk Inventor, please ensure the program is running");
        }

        public void ValidDocumentType(bool validDocumentType)
        {
            if (!validDocumentType)
                MessageBox.Show("Unable to process the current active document, please make sure an Inventor model is open");
        }

        private void EditDXFExport_Click(object sender, EventArgs e)
        {
            DXFExportSettings dXFExportSettings = new DXFExportSettings();

            dXFExportSettings.Show();
        }
    }
}
