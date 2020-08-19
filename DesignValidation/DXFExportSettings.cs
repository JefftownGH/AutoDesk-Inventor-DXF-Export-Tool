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
using DesignValidation.Properties;

namespace DesignValidation
{
    public partial class DXFExportSettings : Form
    {
        BindingSource bindingSourceDXFLayer = new BindingSource();
 
        ExportDXFSettings exportDXFSettings = new ExportDXFSettings();

        ExportDXF exportDXF = new ExportDXF();

        public DXFExportSettings()
        {
            InitializeComponent();
            
            CreateDXFLayerObjects();

            SetupDataBinding();
        }

        private void SetupDataBinding()
        {
            FilePathTextBox.DataBindings.Add(new Binding("Text", exportDXFSettings, "saveLocationFilePath", true, DataSourceUpdateMode.OnPropertyChanged));
            AppendMaterialThicknessCheckbox.DataBindings.Add(new Binding("Checked", exportDXFSettings, "appendMaterialThickness", true, DataSourceUpdateMode.OnPropertyChanged));
            AppendFoldedCheckbox.DataBindings.Add(new Binding("Checked", exportDXFSettings, "appendFoldedStatus", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        public void CreateDXFLayerObjects()
        {
            exportDXF.ImportJsonFile();
            bindingSourceDXFLayer.DataSource = exportDXF.dXFLayerItems;
            dataGridDXFLayers.DataSource = bindingSourceDXFLayer;
        }

        private void DirectoryBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogue = new FolderBrowserDialog();
            folderBrowserDialogue.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialogue.Description = "+++Select Folder+++";
            folderBrowserDialogue.ShowNewFolderButton = false;

            if (folderBrowserDialogue.ShowDialog() == DialogResult.OK)
            {
                exportDXFSettings.saveLocationFilePath = folderBrowserDialogue.SelectedPath + "\\";

                //a limitation of windows forms - does not realise the value has changed if done programmatically
                FilePathTextBox.Text = exportDXFSettings.saveLocationFilePath;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            exportDXF.SerialiseJson(exportDXF.dXFLayerItems);

            MessageBox.Show("Changes have been saved", "Save Settings");
        }
    }
}
