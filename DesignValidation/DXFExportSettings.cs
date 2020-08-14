using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExportLibrary;
using ProgramUtilities;

namespace DesignValidation
{
    public partial class DXFExportSettings : Form
    {
        BindingSource bindingSourceDXFLayer = new BindingSource();

        ExportDXF exportDXF = ExportDXF.CreateExportDXFObject();
        
        string saveLocationFilePath = "";
        
        public DXFExportSettings()
        {
            InitializeComponent();

            CreateDXFLayerObjects();
        }

        public void CreateDXFLayerObjects()
        {
            exportDXF.ImportJsonFile();

            bindingSourceDXFLayer.DataSource = exportDXF.dXFLayerItems;

            dataGridDXFLayers.DataSource = bindingSourceDXFLayer;
        }

        public bool FilePathCheck()
        {
            //check that a save directory has been provided

            if (string.IsNullOrEmpty(saveLocationFilePath))
            {
                MessageBox.Show("Please select a save directory", "DXF export error");
                return false;
            }

            //check that the save directory exists

            if (!FileHandling.CheckIfDirectoryExists(saveLocationFilePath))
            {
                MessageBox.Show("Cannot find the directory, DXF export has been aborted", "DXF export error");
                return false;
            }

            return true;
        }

        private void DirectoryBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogue = new FolderBrowserDialog();
            folderBrowserDialogue.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialogue.Description = "+++Select Folder+++";
            folderBrowserDialogue.ShowNewFolderButton = false;

            if (folderBrowserDialogue.ShowDialog() == DialogResult.OK)
            {
                FilePathTextBox.Text = folderBrowserDialogue.SelectedPath;

                saveLocationFilePath = FilePathTextBox.Text;
            }
        }

        private void ExportDXFButton_Click(object sender, EventArgs e)
        {
            if (!FilePathCheck())
                return;

            MessageBox.Show(exportDXF.GenerateExportString());

            //pass the List<DXFlayerItem> dXFLayerItems to the ExportLibrary

            //may need to instantiate a new isntance of the ExportDXF class.

            //this instance then has the custom "string" for the DXF export assigned to it.
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Reserealise the new new List<DXFLayerItem>();

            exportDXF.SerialiseJson(exportDXF.dXFLayerItems);

            MessageBox.Show("Changes have been saved", "Save Settings");
        }
    }
}
