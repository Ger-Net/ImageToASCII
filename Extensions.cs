using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCII
{
    public static class Extensions
    {
        public static void BitmapToGray(this Bitmap bitmap)
        {
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var color = bitmap.GetPixel(x, y);
                    int average = (color.R + color.G + color.B) / 3; 
                    var newColor = Color.FromArgb(color.A,average,average,average);
                    bitmap.SetPixel(x, y, newColor);
                }
            }
        }
    }
}
