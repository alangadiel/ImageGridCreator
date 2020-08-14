using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        class Imagen
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

        class CustomException : Exception
        {
            public CustomException(string message) : base(message) { }
        }

        Bitmap ImagenCreada;

        Bitmap Crear()
        {
            var inputs = new[] { txtDir, txtAlto, txtAncho, txtSep };
            if (inputs.Any(i => string.IsNullOrWhiteSpace(i.Text)))
                throw new CustomException("Campos incompletos.");

            int altoIndividual = int.Parse(txtAlto.Text),
               anchoTotal = int.Parse(txtAncho.Text),
               separacion = int.Parse(txtSep.Text);

            if (altoIndividual <= 0 || anchoTotal <= 0 || separacion < 0)
                throw new FormatException();

            var files = Directory.GetFiles(txtDir.Text);

            if (!files.Any())
                throw new CustomException("No se encontro ningun archivo en el directorio.");

            var imgs = files.Select(f => new Imagen(f, Image.FromFile(f))).ToList();
            imgs.ForEach(img => img.ChangeSize(altoIndividual));

            var overSized = imgs.Where(img => img.Data.Width > anchoTotal);
            if (overSized.Any())
                throw new CustomException($"Las siguientes imagenes no caben en el ancho especificado:\n" +
                    $"{string.Join('\n', overSized.Select(img => Path.GetFileName(img.Path)))}");

            double rows = (double)imgs.Sum(img => img.Data.Width + separacion) / (anchoTotal + separacion);
            int altoTotal = ((int)Math.Ceiling(rows) * (altoIndividual + separacion)) - separacion;

            var res = new Bitmap(anchoTotal, altoTotal);
            using var graphics = Graphics.FromImage(res);

            if (!checkBoxFondoTransparente.Checked)
                graphics.Clear(Color.White);

            int x = 0, y = 0;
            foreach (var img in imgs)
            {
                if (x + img.Data.Width > anchoTotal)
                {
                    x = 0;
                    y += altoIndividual + separacion;
                }
                graphics.DrawImage(img.Data, new Point(x, y));
                x += img.Data.Width + separacion;
            }

            foreach (var img in imgs)
            {
                img.Data.Dispose();
            }

            return res;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ImagenCreada != null)
                {
                    ImagenCreada.Dispose();
                    ImagenCreada = null;
                }

                lblCargando.Show();
                ImagenCreada = await Task.Run(Crear);
                lblCargando.Hide();

                pictureBox1.Image = ImagenCreada;
                pictureBox1.Height = ImagenCreada.Height;
                pictureBox1.Width = ImagenCreada.Width;
                panel1.AutoScroll = true;
                btnGuardar.Enabled = true; 
            }
            catch (Exception ex)
            {
                lblCargando.Hide();
                MessageBox.Show(ExceptionMessage(ex), "Error");
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
                lblCargando.Hide();
                MessageBox.Show(ExceptionMessage(ex), "Error");
            }
        }

        private void Txt_TextChanged(object sender, EventArgs e) => btnGuardar.Enabled = false;
        
    }
}
