using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportLibrary
{
    public enum LayerNames
    {
        TangentLayer,
        OuterProfileLayer,
        ArcCentresLayer,
        InteriorProfilesLayer,
        BendUpLayer,
        BendDownLayer,
        FeatureProfilesUpLayer,
        FeatureProfilesDownLayer,
        AltRepFrontLayer,
        AltRepBackLayer,
        UnconsumedSketchesLayer,
        TangentRollLinesLayer,
        RollLinesLayer
    }

    public class DXFLayerItem
    {
        private string layerName;
        private bool noLine;
        private bool dashedLine;
        private bool solidLine;

        public string Name
        {
            get
            {
                return layerName;
            }
            set
            {
                layerName = value;
            }
        }

        public bool NoLine 
        {
            get
            {
                if (noLine)
                {
                    DashedLine = false;
                    SolidLine = false;
                }

                return noLine;
            }
            set
            {
                noLine = value;
            }
        }

        public bool DashedLine
        {
            get
            {
                if (dashedLine)
                {
                    SolidLine = false;
                    NoLine = false;
                }

                return dashedLine;
            }
            set
            {
                dashedLine = value;
            }
        }

        public bool SolidLine
        {
            get
            {
                if (solidLine)
                {
                    DashedLine = false;
                    NoLine = false;
                }

                if (DashedLine == false && NoLine == false && solidLine == false)
                    solidLine = true;

                return solidLine;
            }
            set
            {
                solidLine = value;
            }
        }

        public DXFLayerItem()
        {
            //parameterless constructor to allow for Json deserialization
        }

        public DXFLayerItem(string layerName)
        {
            this.layerName = layerName;
            noLine = false;
            dashedLine = false;
            solidLine = true;
        }

    }
}
