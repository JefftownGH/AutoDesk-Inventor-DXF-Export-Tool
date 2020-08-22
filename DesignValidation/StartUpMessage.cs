using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProgramUtilities;

namespace DesignValidation
{
    public static class StartUpMessage
    {
        public static void Generate()
        {
            EventLogger.CreateLogEntry("***WELCOME TO DXF EXPORT WIZARD :)***");
            EventLogger.CreateLogEntry("This application will allow you to automatically extract DXFs");
            EventLogger.CreateLogEntry("----------------------------------------------------------------------------------------------------------------------");
            EventLogger.CreateLogEntry("**INSTRUCTIONS**:");
            EventLogger.CreateLogEntry("1. Ensure AutoDesk Inventor is running and an Assembly Document is open");
            EventLogger.CreateLogEntry("2. Click 'Import'");
            EventLogger.CreateLogEntry("3. Select the parts you would like to export to DXF");
            EventLogger.CreateLogEntry("4. Click 'Settings' to change your export preferences");
            EventLogger.CreateLogEntry("5. Click 'Export DXF' to automatically generate and save the DXF files");
        }
    }
}
