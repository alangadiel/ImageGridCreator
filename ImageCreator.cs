using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGridCreator
{
    public class ImageCreator : IDisposable
    {
        public Bitmap NewImage;
        public List<MyImage> Images;

        public ImageCreator(List<MyImage> images)
        {
            if (images == null || !images.Any())
                throw new CustomException("No se cargaron imagenes");

            Images = images;
        }

        public void Dispose()
        {
            NewImage?.Dispose();
            NewImage = null;
        }

        public void Create(int totalWith, int padding, bool fondoTransparente)
        {
            //Verify if any image exeeds the total with
            var overSized = Images.Where(img => img.Size.Width > totalWith);
            if (overSized.Any())
                throw new CustomException($"Las siguientes imagenes no caben en el ancho especificado:\n" +
                    $"{string.Join('\n', overSized.Select(img => Path.GetFileName(img.Path)))}");

            //Dispose NewImage
            Dispose();

            //Create grid
            var currentRow = new List<MyImage>();
            var grid = new List<List<MyImage>> { currentRow };
            int x = 0;
            foreach (var img in Images)
            {
                if (x + img.Size.Width > totalWith)
                {
                    x = 0;
                    currentRow = new List<MyImage>();
                    grid.Add(currentRow);
                }
                currentRow.Add(img);
                x += img.Size.Width + padding;
            }

            int totalHeight = grid.Sum(row => row.Max(item => item.Size.Height) + padding) - padding;

            //Create canvas
            NewImage = new Bitmap(totalWith, totalHeight);

            using var canvas = Graphics.FromImage(NewImage);
            canvas.CompositingMode = CompositingMode.SourceOver;
            canvas.CompositingQuality = CompositingQuality.HighQuality;
            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
            canvas.SmoothingMode = SmoothingMode.HighQuality;
            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (!fondoTransparente)
                canvas.Clear(Color.White);

            using var wrapMode = new ImageAttributes();
            wrapMode.SetWrapMode(WrapMode.TileFlipXY);

            //Draw final image
            int y = 0;
            foreach (var row in grid)
            {
                x = (totalWith - (row.Sum(img => img.Size.Width + padding) - padding)) / 2;
                int rowHeight = row.Max(item => item.Size.Height);
                foreach (var img in row)
                {
                    float yCentrado = y + rowHeight / 2f - img.Size.Height / 2f;
                    int yCentradoInt = Convert.ToInt32(Math.Ceiling(yCentrado));

                    var rect = new Rectangle(x, yCentradoInt, img.Size.Width, img.Size.Height);

                    canvas.DrawImage(image: img.Data,
                                     destRect: rect,
                                     srcX: img.Frame.X,
                                     srcY: img.Frame.Y,
                                     srcWidth: img.Frame.Width,
                                     srcHeight: img.Frame.Height,
                                     srcUnit: GraphicsUnit.Pixel,
                                     imageAttr: wrapMode);

                    x += img.Size.Width + padding;
                }
                y += rowHeight + padding;
            }
        }

    }
}
