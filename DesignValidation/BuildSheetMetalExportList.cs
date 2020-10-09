using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventor;
using DesignValidationLibrary;

namespace DesignValidation
{
    public static class SheetMetalExportList
    {
        public static List<SheetmetalPart> BuildSheetMetalExportList(List<TreeViewNode> sheetMetalInputNodeList, List<Assembly> assemblyList )
        {
            //retrieve all the sheetmetalparts from the assembly list:

            List<SheetmetalPart> sheetMetalInputList = BuildSheetmetalListFromAssembly(assemblyList);

            //gets all the ticked values:

            List<TreeViewNode> sheetMetalExportNodeList = sheetMetalInputNodeList.Where(x => x.Ticked == true).ToList();

            //find the corresponding Node name in the sheetMetalInputList then return it:

            List<SheetmetalPart> sheetMetalExportList = new List<SheetmetalPart>();

            foreach (TreeViewNode treeViewNode in sheetMetalExportNodeList)
                sheetMetalExportList.Add(sheetMetalInputList.First(x => x.Name == treeViewNode.Name));

            return sheetMetalExportList;
        }

        private static List<SheetmetalPart> BuildSheetmetalListFromAssembly(List<Assembly> assemblyList)
        {
            List<SheetmetalPart> sheetMetalPartList = new List<SheetmetalPart>();

            foreach (Assembly assembly in assemblyList)
                foreach (SheetmetalPart sheetMetalPart in assembly.SheetmetalPartList)
                    sheetMetalPartList.Add(sheetMetalPart);

            return sheetMetalPartList;
        }
    }
}
