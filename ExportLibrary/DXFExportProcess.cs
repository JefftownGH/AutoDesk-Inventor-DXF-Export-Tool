using DesignValidationLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using ProgramUtilities;

namespace ExportLibrary
{
    public static class DXFExportProcess
    {
        public static List<string> ExportSheetmetalPartsToDXF(List<SheetmetalPart> sheetmetalPartList, ExportDXFSettings exportDXFSettings)
        {
            List<string> exportLog = new List<string>();

            string exportString = ExportStringGenerator.GenerateExportString(exportDXFSettings.importExportDXFLayers.dXFLayerItems);

            foreach(SheetmetalPart sheetmetalPart in sheetmetalPartList)
            {
                string exportFileName = GenerateExportFileName(sheetmetalPart, exportDXFSettings);

                try
                {
                    SheetMetalComponentDefinition sheetMetalCompDef = (SheetMetalComponentDefinition)sheetmetalPart.PartDocument.ComponentDefinition;

                    DataIO dataIO = sheetMetalCompDef.FlatPattern.DataIO;

                    dataIO.WriteDataToFile(exportString, exportFileName);

                    exportLog.Add(sheetmetalPart.Name + " DXF was successfully exported");

                    EventLogger.CreateLogEntry(sheetmetalPart.Name + " DXF was successfully exported");
                }
                catch (Exception e)
                {
                    exportLog.Add(sheetmetalPart.Name + " DXF export encountered an error");
                    exportLog.Add(e.Message + "_______" + e.StackTrace);

                    EventLogger.CreateLogEntry(sheetmetalPart.Name + " DXF export encountered an error");
                    EventLogger.CreateLogEntry(e.Message + "_______" + e.StackTrace);

                    continue;
                }
            }
            return exportLog;
        }

        public static string GenerateExportFileName(SheetmetalPart sheetmetalPart, ExportDXFSettings exportDXFSettings)
        {
            StringBuilder exportFileName = new StringBuilder();

            exportFileName.Append(exportDXFSettings.saveLocationFilePath);

            exportFileName.Append(sheetmetalPart.PartDocument.DisplayName);

            if (exportDXFSettings.appendMaterialThickness)
                exportFileName.Append("_" + sheetmetalPart.Thickness);

            if (exportDXFSettings.appendFoldedStatus)
                if (sheetmetalPart.NumberOfBends > 0)
                    exportFileName.Append("_Folded");

                else
                    exportFileName.Append("_NotFolded");

            exportFileName.Append(".DXF");

            return exportFileName.ToString();
        }
    }
}
