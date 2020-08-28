using System.Drawing;
using System.Windows.Forms;

namespace ProgramUtilities
{
    public class IconTools
    {
        private class IconToolsAxHost : AxHost
        {
            private IconToolsAxHost() : base(string.Empty) { }

            public static Image GetImageFromIPicture(object iPicture)
            {
                return GetPictureFromIPicture(iPicture);
            }
        }

        public static Image GetImage(stdole.IPictureDisp iPictureDisp)
        {
            return IconToolsAxHost.GetImageFromIPicture(iPictureDisp);
        }
    }
}
