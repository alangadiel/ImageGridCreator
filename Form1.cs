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
using System.Windows.Forms;

namespace ImageGridCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class CustomException : Exception
        {
            public CustomException(string message) : base(message) { }
        }

        Bitmap ImagenCreada;

        Bitmap Crear()
        {
            #region validations
            var inputs = new[] { txtDir, txtAlto, txtAncho, txtSep };
            if (inputs.Any(i => string.IsNullOrWhiteSpace(i.Text)))
                throw new CustomException("Campos incompletos.");

            int itemSize = int.Parse(txtAlto.Text),
               totalWith = int.Parse(txtAncho.Text),
               padding = int.Parse(txtSep.Text);

            if (itemSize <= 0 || totalWith <= 0 || padding < 0)
                throw new FormatException();
            #endregion validations

            //Load files
            var files = Directory.GetFiles(txtDir.Text);
            if (!files.Any())
                throw new CustomException("No se encontro ningun archivo en el directorio.");

            var notImages = files.Where(f => !MyImage.IsImage(f));
            if(notImages.Any())
                throw new CustomException($"Los siguientes archivos de la carpeta no son imagenes:\n" +
                    $"{string.Join('\n', notImages.Select(file => Path.GetFileName(file)))}");

            //Convert files to images
            using var imgs = new DisposableList<MyImage>();
            foreach (var file in files)
            {
                imgs.Add(new MyImage(path: file,
                                     data: Image.FromFile(file),
                                     cutBorder: checkBoxRecortarBordes.Checked,
                                     area: itemSize * itemSize));

                StepProgress(files.Length);
            }

            //Verify if any image exeeds the total with
            var overSized = imgs.Where(img => img.Size.Width > totalWith);
            if (overSized.Any())
                throw new CustomException($"Las siguientes imagenes no caben en el ancho especificado:\n" +
                    $"{string.Join('\n', overSized.Select(img => Path.GetFileName(img.Path)))}");

            //Create grid
            var currentRow = new List<MyImage>();
            var grid = new List<List<MyImage>> { currentRow };
            int x = 0;
            foreach (var img in imgs)
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
            var res = new Bitmap(totalWith, totalHeight);

            using var canvas = Graphics.FromImage(res);
            canvas.CompositingMode = CompositingMode.SourceOver;
            canvas.CompositingQuality = CompositingQuality.HighQuality;
            canvas.InterpolationMode = InterpolationMode.HighQualityBicubic;
            canvas.SmoothingMode = SmoothingMode.HighQuality;
            canvas.PixelOffsetMode = PixelOffsetMode.HighQuality;

            if (!checkBoxFondoTransparente.Checked)
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

            return res;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            lblCargando.Show();
            progressBar1.Show();
            progressBar1.Value = 0;
            try
            {
                if (ImagenCreada != null)
                {
                    ImagenCreada.Dispose();
                    ImagenCreada = null;
                }

                ImagenCreada = await Task.Run(Crear);

                pictureBox1.Image = ImagenCreada;
                pictureBox1.Height = ImagenCreada.Height;
                pictureBox1.Width = ImagenCreada.Width;
                panel1.AutoScroll = true;
                btnGuardar.Enabled = btnVer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ExceptionMessage(ex), "Error");
            }
            finally
            {
                lblCargando.Hide();
                progressBar1.Hide();
            }
        }

        string ExceptionMessage(Exception ex) =>
            ex switch
            {
                CustomException _ => ex.Message,
                FormatException _ => "Numeros no validos.",
                DirectoryNotFoundException _ => "No existe el directorio.",
                Exception _ => ex.ToString(),
            };

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                txtDir.Text = dialog.SelectedPath;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            lblCargando.Show();
            try
            {
                var dialog = new SaveFileDialog
                {
                    DefaultExt = ".png",
                };
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                ImagenCreada.Save(dialog.FileName, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ExceptionMessage(ex), "Error");
            }
            finally
            {
                lblCargando.Hide();
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e) => btnGuardar.Enabled = btnVer.Enabled = false;

        private void btnVerMas_Click(object sender, EventArgs e)
        {
            var form = new FormVerMas(ImagenCreada, this);
            Hide();
            form.Show();
        }

        private delegate void SafeCallDelegate(int length);

        private void StepProgress(int length)
        {
            if (progressBar1.InvokeRequired)
            {
                var d = new SafeCallDelegate(StepProgress);
                progressBar1.Invoke(d, new object[] { length });
            }
            else
            {
                progressBar1.Value += 100 / length;
            }
        }

    }
}
