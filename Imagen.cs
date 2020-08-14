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

        public void ChangeSize(int alto)
        {
            var anterior = Data;
            Data = Data.GetThumbnailImage((alto * Data.Width) / Data.Height, alto, null, IntPtr.Zero);
            anterior.Dispose();
        }
    }
}
