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
using ExportLibrary;

namespace DesignValidation
{
    
    public partial class DesignValidationForm : Form 
    {
        private TopLevel topLevel = new TopLevel();

        private BindingSource errorList = new BindingSource();

        private List<TreeViewNode> treeViewNodeData = new List<TreeViewNode>();

        private List<TreeViewNode> sheetMetalListData = new List<TreeViewNode>();

        private BrightIdeasSoftware.TreeListView treeListView;

        private BrightIdeasSoftware.TreeListView sheetMetalListView;

        public InventorImportProcess inventorImportProcess = new InventorImportProcess();

        public DesignValidationForm()
        {
            InitializeComponent();
            AddTreeListView();
            AddSheetMetalListView();
        }

        private void SubScribeToEvent(TopLevel topLevel) => topLevel.UpdateProgress += OnProgressBarIncrement;

        private void AddTreeListView()
        {
            treeListView = TreeListView.CreateTreeListView();
            treeListView.ItemChecked += UpdateTreeListViewCheckboxes;
            Controls.Add(treeListView);
        }

        private void AddSheetMetalListView()
        {
            sheetMetalListView = SheetMetalListView.CreateTreeListView();
            //sheetMetalListView.ItemChecked
            Controls.Add(sheetMetalListView);
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

            treeListView.Columns.Add(nameCol);
            treeListView.Columns.Add(col1);
            treeListView.ExpandAll();

            treeListView.Roots = treeViewNodeData; 
        }

        private void FillSheetMetalList()
        {
            sheetMetalListView.Clear();
            sheetMetalListView.CanExpandGetter = x => (x as TreeViewNode).Children.Count > 0;
            sheetMetalListView.ChildrenGetter = x => (x as TreeViewNode).Children;

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

            sheetMetalListView.Columns.Add(nameCol);
            sheetMetalListView.Columns.Add(col1);
            sheetMetalListView.Columns.Add(col2);
            sheetMetalListView.Columns.Add(col3);

            sheetMetalListView.Roots = sheetMetalListData;
        }

        public void Import_Click(object sender, EventArgs e)
        {
            //retrieves a null instance of the TopLevel class
            topLevel = inventorImportProcess.GetToplevel();

            //subscribes to the event in the TopLevel class to update the progress bar
            SubScribeToEvent(topLevel);

            //begins the import process
            inventorImportProcess.ImportANewInventorModel(InventorConnectionStatus, ValidDocumentType, UpdateProgressBar);

            treeViewNodeData = TreeListView.BuildTreeViewNodeDataNested(topLevel.AssemblyList);

            sheetMetalListData = SheetMetalListView.BuildSheetMetalNodeData(topLevel.AssemblyList);

            FillTree();

            FillSheetMetalList();
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

            //PictureBoxTestMethod(part);
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

        private void ExportDXFButton_Click(object sender, EventArgs e)
        {
            //temporary logic until method for using checkbox to build the sheetmetal part list

            List<SheetmetalPart> sheetMetalPartList = new List<SheetmetalPart>();

            foreach(Assembly subAssembly in topLevel.AssemblyList)
            {
                foreach(SheetmetalPart sheetMetalPart in subAssembly.sheetmetalPartList)
                {
                    sheetMetalPartList.Add(sheetMetalPart);
                }
            }

            ExportDXF exportDXF = ExportDXF.CreateExportDXFObject();

            exportDXF.ImportJsonFile();

            exportDXF.ExportSheetMetalPartsToDXF(sheetMetalPartList);
        }

        public void UpdateTreeListViewCheckboxes(object sender, ItemCheckedEventArgs e)
        {
            MessageBox.Show(e.Item.Checked.ToString() + "  " + e.Item.Name.ToString());
        }

        //problem with the api
        public void PictureBoxTestMethod(Part part)
        {
            stdole.IPictureDisp thumbNail = part.partDocument.Thumbnail;

            Image image = IconTools.GetImage(thumbNail);

            //PictureBoxTest.Image = image;
        }
    }
}
