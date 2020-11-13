using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using PathClass = System.IO.Path;

namespace ImageGridCreator
{
    public class MyImage : IDisposable
    {
        public MyImage(string path, Image data, bool cutBorder, int area)
        {
            Path = path;
            Data = data;
            Frame = GetFrame(cutBorder);
            Size = GetSize(area);
        }

        public string Path { get; }
        public Image Data { get; }
        public Rectangle Frame { get; }
        public Size Size { get; }

        private Rectangle GetFrame(bool cutBorder)
        {
            if (cutBorder)
            {
                using var bmp = new Bitmap(Data);
                var color = GetMatchedBackColor(bmp);
                if (color != null)
                {
                    var bounds = GetImageBounds(bmp, color.Value);
                    return new Rectangle(x: bounds[0].X,
                                         y: bounds[0].Y,
                                         width: bounds[1].X - bounds[0].X,
                                         height: bounds[1].Y - bounds[0].Y);
                }
            }

            return new Rectangle(Point.Empty, Data.Size);
        }

        private Size GetSize(int area)
        {
            double aspectRatio = (double)Frame.Height / Frame.Width;
            double newWith = Math.Sqrt(area / aspectRatio);
            double newHeight = newWith * aspectRatio;

            return new Size(
                Convert.ToInt32(Math.Ceiling(newWith)),
                Convert.ToInt32(Math.Ceiling(newHeight)));
        }

        public void Dispose() => Data.Dispose();

        #region CropUnwantedBackground

        private static Point[] GetImageBounds(Bitmap bmp, Color backColor)
        {
            // Finding the Bounds of Crop Area
            Color c;
            int width = bmp.Width, height = bmp.Height;
            bool upperLeftPointFounded = false;
            var bounds = new Point[2];

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    c = bmp.GetPixel(x, y);
                    if (!AlmostSameColor(backColor, c))
                    {
                        if (!upperLeftPointFounded)
                        {
                            bounds[0] = new Point(x, y);
                            bounds[1] = new Point(x, y);
                            upperLeftPointFounded = true;
                        }
                        else
                        {
                            if (x > bounds[1].X)
                                bounds[1].X = x;
                            else if (x < bounds[0].X)
                                bounds[0].X = x;
                            if (y > bounds[1].Y)
                                bounds[1].Y = y;
                        }
                    }
                }
            }

            return bounds;
        }

        private static Color? GetMatchedBackColor(Bitmap bmp)
        {
            // Getting The Background Color by checking Corners of Original Image
            // four corners (Top, Left), (Top, Right), (Bottom, Left), (Bottom, Right)
            var corners = new Point[]
            {
                new Point(0, 0),
                new Point(0, bmp.Height - 1),
                new Point(bmp.Width - 1, 0),
                new Point(bmp.Width - 1, bmp.Height - 1)
            };

            for (int i = 0; i < 4; i++)
            {
                var cornerMatched = 0;
                var backColor = bmp.GetPixel(corners[i].X, corners[i].Y);

                for (int j = 0; j < 4; j++)
                {
                    var cornerColor = bmp.GetPixel(corners[j].X, corners[j].Y);
                    if (AlmostSameColor(backColor, cornerColor))
                    {
                        cornerMatched++;
                    }
                }

                if (cornerMatched > 2)
                    return backColor;
            }

            return null;
        }

        private static bool AlmostSameColor(Color a, Color b)
            => AlmostSameNumber(a.R, b.R)
            && AlmostSameNumber(a.G, b.G)
            && AlmostSameNumber(a.B, b.B);

        private static decimal Range => 0.1m;

        private static bool AlmostSameNumber(decimal a, decimal b)
        => Math.Abs(a - b) <= Range;
        #endregion

        #region ExtensionValidation
        private static readonly HashSet<string> ImageExtensions = new HashSet<string> { "JPG", "JPEG", "BMP", "GIF", "PNG" };

        public static bool IsImage(string file)
        {
            var ext = PathClass.GetExtension(file)?
                .ToUpperInvariant()
                .Replace(".", "");
            return ImageExtensions.Contains(ext);
        }
        #endregion
    }
}
