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
using ProgramUtilities;
using ApplicationLogic;
using BrightIdeasSoftware;
using ExportLibrary;

namespace DesignValidation
{
    public partial class DesignValidationForm : Form 
    {
        private TopLevel topLevel = new TopLevel();
        private List<TreeViewNode> treeViewNodeData = new List<TreeViewNode>();
        private List<TreeViewNode> sheetMetalListData = new List<TreeViewNode>();
        private BrightIdeasSoftware.TreeListView treeListView;
        private BrightIdeasSoftware.TreeListView sheetMetalListView;
        private InventorImportProcess inventorImportProcess = new InventorImportProcess();

        public DesignValidationForm()
        {
            InitializeComponent();
            AddTreeListViews();
            AddSheetMetalListView();
            SubscribeToLoggerEvent();
            StartUpMessage.Generate();
        }

        private void SubscribeToTopLevelEvent(TopLevel topLevel) => topLevel.UpdateProgress += OnProgressBarIncrement;

        private void SubscribeToLoggerEvent() => EventLogger.LogEntryAdded += EventLoggerOutput;

        private void EventLoggerOutput(object source, string Input) => LogOutputListBox.Items.Add(Input);

        private void AddTreeListViews()
        {
            treeListView = TreeListView.CreateTreeListView();
            treeListView.ItemChecked += UpdateTreeListViewCheckboxes;
            Controls.Add(treeListView);
        }

        private void AddSheetMetalListView()
        {
            sheetMetalListView = SheetMetalListView.CreateTreeListView();
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
            SubscribeToTopLevelEvent(topLevel);

            //begins the import process
            inventorImportProcess.ImportANewInventorModel(InventorConnectionStatus, ValidDocumentType, UpdateProgressBar);

            treeViewNodeData = TreeListView.BuildTreeViewNodeDataNested(topLevel.AssemblyList);

            sheetMetalListData = SheetMetalListView.BuildSheetMetalNodeData(topLevel.AssemblyList);

            FillTree();

            FillSheetMetalList();
        }

        //recieves an event from the topLevel class
        public void OnProgressBarIncrement(object source, EventArgs e)
        {
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
                ProgressBar.Visible = true;
            }
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
            List<SheetmetalPart> sheetMetalPartList = SheetMetalExportList.BuildSheetMetalExportList(sheetMetalListData, topLevel.AssemblyList);
            ExportDXFSettings exportDXFSettings = new ExportDXFSettings();
            List<string> exportLog = DXFExportProcess.ExportSheetmetalPartsToDXF(sheetMetalPartList, exportDXFSettings);
            DXFExportLog dXFExportLog = new DXFExportLog(exportLog);
            dXFExportLog.Show();
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
