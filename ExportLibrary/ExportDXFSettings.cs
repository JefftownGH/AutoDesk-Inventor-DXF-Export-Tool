using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProgramUtilities;
using ExportLibrary.Properties;

namespace ExportLibrary
{
    public class ExportDXFSettings 
    {
        private string _saveLocationFilePath;
        public string saveLocationFilePath 
        {
            get { return _saveLocationFilePath; }

            set
            {
                _saveLocationFilePath = value;

                Settings.Default["FilePathOutput"] = _saveLocationFilePath;
                Settings.Default.Save();

                if (!FilePathCheck())
                    filePathStatus = false;

                else
                    filePathStatus = true;
            }
        }

        private bool _appendMaterialThickness;
        public bool appendMaterialThickness 
        {
            get { return _appendMaterialThickness; }

            set
            {
                _appendMaterialThickness = value;

                Settings.Default["AppendMaterialThickness"] = _appendMaterialThickness;
                Settings.Default.Save();
            }
        }

        private bool _appendFoldedStatus { get; set; }
        public bool appendFoldedStatus
        {
            get { return _appendFoldedStatus; }

            set
            {
                _appendFoldedStatus = value;

                Settings.Default["AppendFoldedStatus"] = _appendFoldedStatus;
                Settings.Default.Save();
            }
        }

        public bool filePathStatus { get; private set; }


        public ExportDXFSettings()
        {
            saveLocationFilePath = Settings.Default["FilePathOutput"].ToString();
            appendMaterialThickness = (bool)Settings.Default["AppendMaterialThickness"];
            appendFoldedStatus = (bool)Settings.Default["AppendFoldedStatus"];
        }

        public bool FilePathCheck()
        {
            if (!FileHandling.CheckIfDirectoryExists(saveLocationFilePath))
            {
                MessageBox.Show("Cannot find the output directory, please select a valid filepath", "DXF export error");
                return false;
            }
            else
                 return true;
        }
    }
}
