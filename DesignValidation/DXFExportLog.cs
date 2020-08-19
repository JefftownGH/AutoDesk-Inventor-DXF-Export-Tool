using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignValidation
{
    public partial class DXFExportLog : Form
    {
        private readonly List<string> exportLog = new List<string>();

        private BindingSource exportLogSource = new BindingSource();

        public DXFExportLog(List<string> exportLog)
        {
            InitializeComponent();

            this.exportLog = exportLog;

            exportLogSource.DataSource = exportLog;

            DXFExportListBox.DataSource = exportLogSource;
        }
    }
}
