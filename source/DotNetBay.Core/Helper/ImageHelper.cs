using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DotNetBay.Core.Helper
{
    public static class ImageHelper
    {
        public static ImageSource ByteToImage(byte[] imageData)
        {
            BitmapImage biImg = new BitmapImage();
            MemoryStream ms = new MemoryStream(imageData);
            biImg.BeginInit();
            biImg.StreamSource = ms;
            biImg.EndInit();

            ImageSource imgSrc = (ImageSource)biImg;

            return imgSrc;
        }
    }
}