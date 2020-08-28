using DesignValidationLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using Inventor;
using ProgramUtilities;

namespace ExportLibrary
{
    public static class DXFExportProcess
    {
        public static List<string> ExportSheetmetalPartsToDXF(List<SheetmetalPart> sheetmetalPartList, ExportDXFSettings exportDXFSettings)
        {
            List<string> exportLog = new List<string>();

            string exportString = ExportStringGenerator.GenerateExportString(exportDXFSettings.ImportExportDXFLayers.dXFLayerItems);

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
                    exportLog.Add(e.Message + "   " + e.StackTrace);

                    EventLogger.CreateLogEntry(sheetmetalPart.Name + " DXF export encountered an error");
                    EventLogger.CreateLogEntry(e.Message + "   " + e.StackTrace);

                    continue;
                }
            }
            return exportLog;
        }

        public static string GenerateExportFileName(SheetmetalPart sheetmetalPart, ExportDXFSettings exportDXFSettings)
        {
            StringBuilder exportFileName = new StringBuilder();

            exportFileName.Append(exportDXFSettings.SaveLocationFilePath);

            exportFileName.Append(sheetmetalPart.PartDocument.DisplayName);

            if (exportDXFSettings.AppendMaterialThickness)
                exportFileName.Append("_" + sheetmetalPart.Thickness);

            if (exportDXFSettings.AppendFoldedStatus)
                if (sheetmetalPart.NumberOfBends > 0)
                    exportFileName.Append("_Folded");

                else
                    exportFileName.Append("_NotFolded");

            exportFileName.Append(".DXF");

            return exportFileName.ToString();
        }
    }
}
