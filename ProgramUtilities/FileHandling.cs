using System;
using System.IO;

namespace ProgramUtilities
{
    public static class FileHandling
    {
        public static bool CheckIfFilesExists(string filePath)
        {
            if (File.Exists(filePath)) 
                return true;

            else return false;
        }

        public static bool CheckIfDirectoryExists(string filePath)
        {
            if (Directory.Exists(filePath)) 
                return true;

            else return false;
        }

        public static bool SaveStringToFile(string inputString, string filePath, bool deleteExistingFile)
        {
            if (deleteExistingFile)
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
            }
        }
    }
}
