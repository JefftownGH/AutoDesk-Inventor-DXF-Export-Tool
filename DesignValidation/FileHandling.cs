using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace DesignValidation
{
    public static class FileHandling
    {
        public static bool CheckIfFileExists(string filePath)
        {
            if (File.Exists(filePath)) return true;

            else return false;
        }
        public static bool SaveStringToFile(string InputString, string filePath,bool deleteExistingFile)
        {
            bool success;

            try
            {
                if (deleteExistingFile)
                    if (CheckIfFileExists(filePath))
                        File.Delete(filePath);

                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine(InputString);
                    streamWriter.Close();
                    success = true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
                success = false;
            }
            return success;
        }
    }
}
