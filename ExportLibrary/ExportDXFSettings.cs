using System.Windows.Forms;
using ProgramUtilities;
using ExportLibrary.Properties;

namespace ExportLibrary
{
    public class ExportDXFSettings 

        //This class is used to access the Settings.settings file 
        //when a new instance is spun up it retrieves the values
        //need to look at this again with fresh eyes --- the Getter/Setter logic seems wrong.... clunky and hacked together
    {
        private string _saveLocationFilePath;
        public string SaveLocationFilePath 
        {
            get { return _saveLocationFilePath; }

            set
            {
                _saveLocationFilePath = value;

                Settings.Default["FilePathOutput"] = _saveLocationFilePath;
                Settings.Default.Save();

                if (!FilePathCheck())
                    FilePathStatus = false;

                else
                    FilePathStatus = true;
            }
        }

        private bool _appendMaterialThickness;
        public bool AppendMaterialThickness 
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
        public bool AppendFoldedStatus
        {
            get { return _appendFoldedStatus; }

            set
            {
                _appendFoldedStatus = value;

                Settings.Default["AppendFoldedStatus"] = _appendFoldedStatus;
                Settings.Default.Save();
            }
        }

        public bool FilePathStatus { get; private set; }

        public ImportExportDXFLayers ImportExportDXFLayers { get; } = new ImportExportDXFLayers();

        public ExportDXFSettings()
        {
            SaveLocationFilePath = Settings.Default["FilePathOutput"].ToString();
            AppendMaterialThickness = (bool)Settings.Default["AppendMaterialThickness"];
            AppendFoldedStatus = (bool)Settings.Default["AppendFoldedStatus"];
        }

        public bool FilePathCheck()
        {
            if (!FileHandling.CheckIfDirectoryExists(SaveLocationFilePath))
            {
                MessageBox.Show("Cannot find the output directory, please select a valid filepath", "DXF export error");
                return false;
            }
            else
                 return true;
        }
    }
}
