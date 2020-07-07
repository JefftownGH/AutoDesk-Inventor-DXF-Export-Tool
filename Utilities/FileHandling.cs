using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Utilities
{
    public static class FileHandling
    {
        public static bool CheckIfFilesExists(string filePath)
        {
            if (File.Exists(filePath)) return true;
            else return false;
        }

        public static bool SaveStringToFile(string inputString, string filePath, bool deleExistingFile)
        {
            if (deleExistingFile)
                if (CheckIfFilesExists(filePath))
                    File.Delete(filePath);
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath, true))
                {
                    streamWriter.WriteLine(inputString);
                    streamWriter.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}
