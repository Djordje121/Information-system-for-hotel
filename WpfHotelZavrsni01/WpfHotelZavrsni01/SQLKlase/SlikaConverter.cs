using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;

namespace WpfHotelZavrsni01
{
    class SlikaConverter
    {

        public static BitmapImage ConvertToBitmap(byte[] byteArray)
        {
            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.StreamSource = new MemoryStream(byteArray);
            bmp.EndInit();
            return bmp;            
        }

        public static byte[] ConvertToByte(string imgPath)
        {
            JpegBitmapEncoder enc = new JpegBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(new Uri(imgPath)));
            using (MemoryStream ms=new MemoryStream())
            {
                enc.Save(ms);
                return ms.ToArray();
            }
        }
    }
}
