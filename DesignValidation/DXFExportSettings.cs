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

namespace DesignValidation
{
    public partial class DXFExportSettings : Form
    {
        BindingSource bindingSourceDXFLayer = new BindingSource();

        List<DXFLayerItem> dXFLayerItems = new List<DXFLayerItem>();

        public DXFExportSettings()
        {
            InitializeComponent();
            CreateDXFLayerObjects();
        }

        public void CreateDXFLayerObjects()
        {
            IEnumerable<LayerNames> layerNames = Enum.GetValues(typeof(LayerNames)).Cast<LayerNames>();

            foreach(Enum layerName in layerNames)
            {
                dXFLayerItems.Add(new DXFLayerItem(layerName.ToString()));
            }

            //List is created first and then added to the BindingSource to make the objects easier to use

            bindingSourceDXFLayer.DataSource = dXFLayerItems;

            dataGridDXFLayers.DataSource = bindingSourceDXFLayer;

            //there will be an export to dxf method passing List<DXFLayerItem> dXFLayerItems
        }

        //this method is currently just for testing to make sure the databinding is working 
        private void dataGridDXFLayers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //var selectedRow = (DXFLayerItem)dataGridDXFLayers.SelectedRows[0].DataBoundItem;

                //var testObject = dXFLayerItems.FirstOrDefault(x => x.Name == "TangentLayer");

                //MessageBox.Show(testObject.NoLine.ToString());

            }
            catch (Exception ex)
            {
                //MessageBox.Show("There was an unexpected error: " + ex.Message + "_" + ex.Source);
            }
        }

        private void DirectoryBrowseButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogue = new FolderBrowserDialog();
            folderBrowserDialogue.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialogue.Description = "+++Select Folder+++";
            folderBrowserDialogue.ShowNewFolderButton = false;

            if (folderBrowserDialogue.ShowDialog() == DialogResult.OK)
                FilePathTextBox.Text = folderBrowserDialogue.SelectedPath;

        }
    }
}
