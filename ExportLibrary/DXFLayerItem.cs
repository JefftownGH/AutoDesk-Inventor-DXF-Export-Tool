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
        ToolCenterUpLayer,
        ToolCenterDownLayer,
        FeatureProfilesUpLayer,
        FeatureProfilesDownLayer,
    }

    public class DXFLayerItem
    {
        public string layerName { get; set; }

        private bool _noLine;
        public bool noLine
        {
            //testing some logic
            get
            {
                if (dashedLine == true || solidLine == true)
                    return _noLine = false;

                else
                    return _noLine = true;
            }
            set
            {
                _noLine = value;
            }
        }

        private bool _dashedLine;
        public bool dashedLine
        {
            //testing some logic
            get
            {
                if (noLine == true || solidLine == true)
                    return _dashedLine = false;

                else
                    return _dashedLine = true;
            }
            set
            {
                _dashedLine = value;
            }
        }

        private bool _solidLine;
        public bool solidLine
        {
            get
            {
                if (noLine == true || dashedLine == true)
                    return _solidLine = false;

                else
                    return _solidLine = true;
            }
            set
            {
                _solidLine = value;
            }
        }

        public DXFLayerItem(string layerName)
        {
            solidLine = true;
            this.layerName = layerName;
        }

        
    }
}
