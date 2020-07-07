using System;
using System.Collections.Generic;
using System.Text;
using Inventor;

namespace Utilities
{
    public static class UnitConversionEngine
    {
        public static Tuple<double, bool> ConvertLengthUnits(UnitsTypeEnum inputUnits, UnitsTypeEnum outputUnits, double inputValue)
        {
            #region Notes

            //this method is able to convert between any two length units supported by Enum Inventor.UnitTypesEnum

            //it returns a Tuple, whith a) the converted value b) a bool to signal if the conversion was sucessfull or not

            //if the conversion was not successfull the returned Tuple will be <inputUnits, false>
            #endregion

            double outputValue;
            double intermediateValue;
            bool successfulConversion = true;

            //converts the input units to mm

            #region inputValue to IntermediateValue unit conversion

            switch (inputUnits)
            {
                case UnitsTypeEnum.kMicronLengthUnits:
                    {
                        intermediateValue = inputValue / 1000;
                        break;
                    }
                case UnitsTypeEnum.kMillimeterLengthUnits:
                    {
                        intermediateValue = inputValue;
                        break;
                    }
                case UnitsTypeEnum.kCentimeterLengthUnits:
                    {
                        intermediateValue = inputValue * 10;
                        break;
                    }
                case UnitsTypeEnum.kMeterLengthUnits:
                    {
                        intermediateValue = inputValue * 1000;
                        break;
                    }
                case UnitsTypeEnum.kMilLengthUnits:
                    {
                        intermediateValue = inputValue * 0.0254;
                        break;
                    }
                case UnitsTypeEnum.kInchLengthUnits:
                    {
                        intermediateValue = inputValue * 25.4;
                        break;
                    }
                case UnitsTypeEnum.kFootLengthUnits:
                    {
                        intermediateValue = inputValue * 304.8;
                        break;
                    }
                case UnitsTypeEnum.kYardLengthUnits:
                    {
                        intermediateValue = inputValue * 914.4;
                        break;
                    }
                case UnitsTypeEnum.kMileLengthUnits:
                    {
                        intermediateValue = inputValue * 1609344;
                        break;
                    }
                case UnitsTypeEnum.kNauticalMileLengthUnits:
                    {
                        intermediateValue = inputValue * 1852000;
                        break;
                    }
                default:
                    {
                        intermediateValue = inputValue;
                        successfulConversion = false;

                        //Terminates the method as the unit conversion has not been successfull
                        return new Tuple<double, bool>(intermediateValue, successfulConversion);
                    }
            }
            #endregion

            //the intermediateValue should now be the inputValue converted to mm

            //converts the intermediateValue to the required outputUnits to create the outputValue

            #region Intermediate value to output value conversion

            switch (outputUnits)
            {
                case UnitsTypeEnum.kMicronLengthUnits:
                    {
                        outputValue = intermediateValue * 1000;
                        break;
                    }
                case UnitsTypeEnum.kMillimeterLengthUnits:
                    {
                        outputValue = intermediateValue;
                        break;
                    }
                case UnitsTypeEnum.kCentimeterLengthUnits:
                    {
                        outputValue = intermediateValue / 10;
                        break;
                    }
                case UnitsTypeEnum.kMeterLengthUnits:
                    {
                        outputValue = intermediateValue / 1000;
                        break;
                    }
                case UnitsTypeEnum.kMilLengthUnits:
                    {
                        outputValue = intermediateValue * 39.3701;
                        break;
                    }
                case UnitsTypeEnum.kInchLengthUnits:
                    {
                        outputValue = intermediateValue / 25.4;
                        break;
                    }
                case UnitsTypeEnum.kFootLengthUnits:
                    {
                        outputValue = intermediateValue / 304.8;
                        break;
                    }
                case UnitsTypeEnum.kYardLengthUnits:
                    {
                        outputValue = intermediateValue / 914.4;
                        break;
                    }
                case UnitsTypeEnum.kMileLengthUnits:
                    {
                        outputValue = intermediateValue / 1609344;
                        break;
                    }
                case UnitsTypeEnum.kNauticalMileLengthUnits:
                    {
                        outputValue = intermediateValue / 1852000;
                        break;
                    }
                default:
                    {
                        outputValue = intermediateValue;
                        successfulConversion = false;
                        break;
                    }
            }

            #endregion

            return new Tuple<double, bool>(outputValue, successfulConversion);
        }
    }
}
