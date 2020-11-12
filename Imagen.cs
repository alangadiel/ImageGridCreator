using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ImageGridCreator
{
    public class Imagen
    {
        public Imagen(string path, Image data)
        {
            Path = path;
            Data = data;
        }

        public string Path { get; set; }
        public Image Data { get; set; }

        public void ChangeSize(int lado)
        {
            double relacionDeAspecto = (double)Data.Height / Data.Width;
            int area = lado * lado;
            double nuevoAncho = Math.Sqrt(area / relacionDeAspecto);
            double nuevoAlto = nuevoAncho * relacionDeAspecto;

            var anterior = Data;
            Data = Data.GetThumbnailImage((int)nuevoAncho, (int)nuevoAlto, null, IntPtr.Zero);
            anterior.Dispose();
        }
    }
}
