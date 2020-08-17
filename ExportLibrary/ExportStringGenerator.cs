using ExportLibrary.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportLibrary
{
    public static class ExportStringGenerator
    {
        public static string GenerateExportString(List<DXFLayerItem> dXFLayerItems)
        {
            List<string> dXFLayerItemsDashedLine = new List<string>();

            List<string> dXFLayerItemsNoLine = new List<string>();

            StringBuilder exportStringBuilder = new StringBuilder();

            exportStringBuilder.Append("FLAT PATTERN DXF?");

            exportStringBuilder.Append(Settings.Default["AutoCadVersion"].ToString());

            BuildLayerLists(ref dXFLayerItemsDashedLine, ref dXFLayerItemsNoLine, dXFLayerItems);

            if (dXFLayerItemsNoLine.Any() || dXFLayerItemsDashedLine.Any())
                exportStringBuilder.Append("&");

            exportStringBuilder.Append(AssignLayerNamesToNoLineList(dXFLayerItemsNoLine));

            exportStringBuilder.Append(BuildInvisibleLayers(dXFLayerItemsNoLine));

            exportStringBuilder.Append(BuildDashedLayers(dXFLayerItemsDashedLine));

            return exportStringBuilder.ToString();
        }

        public static void BuildLayerLists(ref List<string> dXFLayerItemsDashedLine, ref List<string> dXFLayerItemsNoLine, List<DXFLayerItem> dXFLayerItems)
        {
            foreach (DXFLayerItem dXFLayerItem in dXFLayerItems)
            {
                if (dXFLayerItem.DashedLine)
                    dXFLayerItemsDashedLine.Add(dXFLayerItem.Name);

                else if (dXFLayerItem.NoLine)
                    dXFLayerItemsNoLine.Add(dXFLayerItem.Name);
            }
        }

        private static string AssignLayerNamesToNoLineList(List<string> dXFLayerItemsNoLine)
        {
            StringBuilder layerNames = new StringBuilder();

            if (dXFLayerItemsNoLine.Any())
            {
                string lastEntry = dXFLayerItemsNoLine.Last();

                foreach (string dXFLayerItemNoLine in dXFLayerItemsNoLine)
                {
                    layerNames.Append(dXFLayerItemNoLine + "=" + dXFLayerItemNoLine);

                    if (!dXFLayerItemNoLine.Equals(lastEntry))
                    {
                        layerNames.Append("&");
                    }
                }
            }
            return layerNames.ToString();
        }

        private static string BuildInvisibleLayers(List<string> dXFLayerItemsNoLine)
        {
            StringBuilder invisibleLayers = new StringBuilder();

            if (dXFLayerItemsNoLine.Any())
            {
                invisibleLayers.Append("&InvisibleLayers=");

                string lastEntry = dXFLayerItemsNoLine.Last();

                foreach (string dXFLayerItemNoLine in dXFLayerItemsNoLine)
                {
                    invisibleLayers.Append(dXFLayerItemNoLine);

                    if (!dXFLayerItemNoLine.Equals(lastEntry))
                    {
                        invisibleLayers.Append(";");
                    }
                }
            }
            return invisibleLayers.ToString();
        }

        private static string BuildDashedLayers(List<string> dXFLayerItemsDashedLine)
        {
            StringBuilder dashedLayers = new StringBuilder("layerLineType=37644");

            if (dXFLayerItemsDashedLine.Any())
            {
                string lineStyle = "LayerLineType=37644";

                foreach (string dXFLayerItemDashedLine in dXFLayerItemsDashedLine)
                {
                    dashedLayers.Append("&");
                    dashedLayers.Append(dXFLayerItemDashedLine);
                    dashedLayers.Append(lineStyle);
                }
            }
            return dashedLayers.ToString();
        }
    }
}
