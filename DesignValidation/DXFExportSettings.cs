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
        public DXFExportSettings()
        {
            InitializeComponent();
            BuildDXFLayerObjects();
        }

        List<DXFLayerItem> dXFLayerItems = new List<DXFLayerItem>();

        public void BuildDXFLayerObjects()
        {
            IEnumerable<LayerNames> layerNames = Enum.GetValues(typeof(LayerNames)).Cast<LayerNames>();

            foreach(Enum layerName in layerNames)
            {
                dXFLayerItems.Add(new DXFLayerItem(layerName.ToString()));

                //MessageBox.Show((layerName.ToString()));
            }
        }
    }
}
