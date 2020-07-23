using System.Drawing;
using System.IO;
using System.Reflection;

namespace Connections
{
    public class ImageExtension
    {
        public static string GetImageName(string styleno)
        {
            return string.Concat(styleno, ".", Constants.IMAGEFORMAT);
        }

        public static Image ResolveImage(string styleno)
        {
            var filename = new WinSettingProvider().ImageDirectory + "\\" + GetImageName(styleno);

            return File.Exists(filename) ? 
                    Image.FromFile(filename, true) : 
                    Image.FromStream(stream: Assembly.GetExecutingAssembly().GetManifestResourceStream("Connections.JewelLogo.JPG"));
        }
    }
}