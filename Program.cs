﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace ASCII
{
    class Program
    {
        private const string FILE_PATH = " ";

        private const int MAX_WIDTH = 700;
        private const double WIDTH_OFFSET = 1.5;
        

        [STAThread]
        private static void Main(string[] args)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG "
            };

            while (true)
            {
                Console.ReadLine();

                if (openFileDialog.ShowDialog() != DialogResult.OK)
                    continue;

                Console.Clear();

                var bitmap = new Bitmap(openFileDialog.FileName);
                bitmap = ResizeBitmap(bitmap);
                bitmap.BitmapToGray();

                ASCIIConverter converter = new ASCIIConverter(bitmap);
                var rows = converter.Convert();

                foreach (var row in rows)
                {
                    Console.WriteLine(row);
                }

                Console.SetCursorPosition(0, 0);

                using (var stream = new FileStream())
                {

                }
            }    
        }
        
        private static Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var newHeight = bitmap.Height / WIDTH_OFFSET * MAX_WIDTH / bitmap.Width;

            if (bitmap.Width > MAX_WIDTH || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(MAX_WIDTH, (int)newHeight));

            return bitmap;
        }
        
    }
}
