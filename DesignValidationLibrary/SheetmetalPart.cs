using Inventor;
using System.Collections.Generic;
using MaterialPropertiesLibrary;
using System.Linq;
using ProgramUtilities;

namespace DesignValidationLibrary
{
    public class SheetmetalPart : Part
    {
        public double sheetMetalLength { get; private set; }
        public double sheetMetalWidth { get; private set; }
        public double maxSheetMetalLength { get; private set; }
        public double maxSheetMetalWidth { get; private set; }
        public double componentMass { get; set; }
        public double totalCuttingLength { get; private set; }
        public double kFactor { get; private set; }
        private SheetMetalComponentDefinition sheetMetalCompDef { get; set; }
        private MaterialProperty materialProperty { get; set; }

        public void AssignMaterialProperties(List<MaterialProperty> materialPropertiesList)
        {
            material = partDocument.ActiveMaterial.DisplayName;
            materialProperty = materialPropertiesList.FirstOrDefault(x => x.materialName == material);

            if(materialProperty == null)
                materialProperty = materialPropertiesList.First(x => x.materialName == "Default");

            RetrieveDocumentUnits();
        }

        private void RetrieveDocumentUnits()
        {
            //this method may be deleted just for testing at the moment!!!!
            //Inventor Internally uses CM for everything... so anything received from the 

            UnitsTypeEnum documentUnits = partDocument.UnitsOfMeasure.LengthUnits;

            UnitConversionEngine.ConvertLengthUnits(documentUnits, UnitsTypeEnum.kMillimeterLengthUnits, materialProperty.maxSheetLength);
            UnitConversionEngine.ConvertLengthUnits(documentUnits, UnitsTypeEnum.kMillimeterLengthUnits, materialProperty.maxSheetWidth);

            //convert maxSheetMetalLength, maxSheetMetalWidth
        }

        public void FlatPatternCutLength()
        {
            sheetMetalCompDef = (SheetMetalComponentDefinition)partDocument.ComponentDefinition;
            if (!sheetMetalCompDef.HasFlatPattern)
                if (!CreateFlatPattern())
                {
                    errorList.Add("Error in part file, unabled to generate flat pattern");
                    return;
                }
            TotalLengthFlatPatternLoops();
        }

        private bool CreateFlatPattern()
        {
            try
            {
                sheetMetalCompDef.Unfold();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        private void TotalLengthFlatPatternLoops()
        {
            InventorConnection inventorConnection = new InventorConnection();
            MeasureTools measureTools = inventorConnection.GetMeasureTools();
            Face flatPatternFace = sheetMetalCompDef.FlatPattern.BottomFace;
            totalCuttingLength = 0;

            foreach(EdgeLoop edgeLoop in flatPatternFace.EdgeLoops)
                totalCuttingLength += measureTools.GetLoopLength(edgeLoop);
     
            errorList.Add($"{totalCuttingLength} is the total loop length");
        }

        private void GetMassOfPart()
        {
            componentMass = partDocument.ComponentDefinition.MassProperties.Mass;
        }

        public void FlatPatternArea()
        {
            FlatPatternCutLength();

            //Code is for testing purposes.. not intended for use

            sheetMetalCompDef.Unfold();
            sheetMetalCompDef.FlatPattern.ExitEdit();

            int i = sheetMetalCompDef.Bends.Count;

            Face flatPatternFace = sheetMetalCompDef.FlatPattern.BottomFace;

            Box tempBox;
            double width;
            double length;

            if (sheetMetalCompDef.HasFlatPattern)
            {

                errorList.Add("FlatPatternExists");

                errorList.Add(sheetMetalCompDef.ActiveSheetMetalStyle.Thickness);

                sheetMetalCompDef.Unfold();

                tempBox = sheetMetalCompDef.FlatPattern.Body.RangeBox;

                sheetMetalLength = tempBox.MaxPoint.X - tempBox.MinPoint.X;
                sheetMetalWidth = tempBox.MaxPoint.Y - tempBox.MinPoint.Y;

                errorList.Add(sheetMetalWidth.ToString());
                errorList.Add(sheetMetalWidth.ToString());

                errorList.Add(partDocument.UnitsOfMeasure.LengthUnits.ToString());
            }
            else
            {
                errorList.Add("No flat pattern");

                tempBox = sheetMetalCompDef.FlatPattern.Body.RangeBox;

                width = tempBox.MaxPoint.X - tempBox.MinPoint.X;
                length = tempBox.MaxPoint.Y - tempBox.MinPoint.Y;

                errorList.Add(width.ToString());
                errorList.Add(length.ToString());
            }
        }
    }
}
