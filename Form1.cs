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

            int ladoIndividual = int.Parse(txtAlto.Text),
               anchoTotal = int.Parse(txtAncho.Text),
               separacion = int.Parse(txtSep.Text);

            if (ladoIndividual <= 0 || anchoTotal <= 0 || separacion < 0)
                throw new FormatException();

            var files = Directory.GetFiles(txtDir.Text);

            if (!files.Any())
                throw new CustomException("No se encontro ningun archivo en el directorio.");

            var imgs = files.Select(f => new Imagen(f, Image.FromFile(f))).ToList();
            imgs.ForEach(img => img.ChangeSize(ladoIndividual));

            var overSized = imgs.Where(img => img.Data.Width > anchoTotal);
            if (overSized.Any())
                throw new CustomException($"Las siguientes imagenes no caben en el ancho especificado:\n" +
                    $"{string.Join('\n', overSized.Select(img => Path.GetFileName(img.Path)))}");

            //double rows = (double)imgs.Sum(img => img.Data.Width + separacion) / (anchoTotal + separacion);

            var currentRow = new List<Imagen>();
            var grid = new List<List<Imagen>> { currentRow };

            int x = 0;
            foreach (var img in imgs)
            {
                if (x + img.Data.Width > anchoTotal)
                {
                    x = 0;
                    currentRow = new List<Imagen>();
                    grid.Add(currentRow);
                }
                currentRow.Add(img);
                x += img.Data.Width + separacion;
            }

            int altoTotal = grid.Sum(row => row.Max(item => item.Data.Height) + separacion) - separacion;
            //(grid.Count * (ladoIndividual + separacion)) - separacion;

            var res = new Bitmap(anchoTotal, altoTotal);
            using var graphics = Graphics.FromImage(res);

            if (!checkBoxFondoTransparente.Checked)
                graphics.Clear(Color.White);

            int y = 0;
            foreach (var row in grid)
            {
                x = (anchoTotal - (row.Sum(img => img.Data.Width + separacion) - separacion)) / 2;
                int rowHeight = row.Max(item => item.Data.Height);
                foreach (var img in row)
                {
                    double yCentrado = y + rowHeight / 2d - img.Data.Height / 2d;
                    graphics.DrawImage(img.Data, new Point(x, (int)yCentrado));
                    x += img.Data.Width + separacion;
                    img.Data.Dispose();
                }
                y += rowHeight + separacion;
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
                btnGuardar.Enabled = btnVer.Enabled = true; 
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

        private void Txt_TextChanged(object sender, EventArgs e) => btnGuardar.Enabled = btnVer.Enabled = false;

        private void btnVerMas_Click(object sender, EventArgs e)
        {
            var form = new FormVerMas(ImagenCreada, this);
            Hide();
            form.Show();
        }
    }
}
