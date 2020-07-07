using System;
using System.Collections.Generic;
using System.Text;
using Inventor;
using MaterialPropertiesLibrary;

namespace DesignValidationLibrary
{
    public class SheetmetalPart : Part
    {
        public double sheetMetalLength { get; set; }
        public double sheetMetalWidth { get; set; }
        public double kFactor { get; set; }
        private SheetMetalComponentDefinition SheetMetalCompDef { get; set; }

        public void ImportMaterialProperties()
        {
            //this method is intended to work as follows: it imports the data from the json file/material properties object, then runs it through the "UnitConversionEngine" static class so the document units are the same. Then assigns these values to the sheetmetalPart class properties       
        }
        public void FlatPatternArea()
        {
            //Code is for testing purposes.. not intended for use

            SheetMetalCompDef = (SheetMetalComponentDefinition)partDocument.ComponentDefinition;

            Box tempBox;
            double width;
            double length;

            if (SheetMetalCompDef.HasFlatPattern)
            {

                errorList.Add("FlatPatternExists");

                errorList.Add(SheetMetalCompDef.ActiveSheetMetalStyle.Thickness);

                SheetMetalCompDef.Unfold();

                tempBox = SheetMetalCompDef.FlatPattern.Body.RangeBox;

                sheetMetalLength = tempBox.MaxPoint.X - tempBox.MinPoint.X;
                sheetMetalWidth = tempBox.MaxPoint.Y - tempBox.MinPoint.Y;

                errorList.Add(sheetMetalWidth.ToString());
                errorList.Add(sheetMetalWidth.ToString());

                errorList.Add(partDocument.UnitsOfMeasure.LengthUnits.ToString());
            }
            else
            {
                errorList.Add("No flat pattern");

                tempBox = SheetMetalCompDef.FlatPattern.Body.RangeBox;

                width = tempBox.MaxPoint.X - tempBox.MinPoint.X;
                length = tempBox.MaxPoint.Y - tempBox.MinPoint.Y;

                errorList.Add(width.ToString());
                errorList.Add(length.ToString());
            }
        }

        public void UnitConversion()
        {
            partDocument.UnitsOfMeasure.LengthUnits.ToString();

        }
    }
}
