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
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        }

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            numArea.Enabled = checkBoxBordes.Enabled = txtDir.Enabled = false;
            lblCargando.Show();
            progressBar1.Show();
            progressBar1.Value = 0;
            try
            {
                if (string.IsNullOrWhiteSpace(txtDir.Text))
                    throw new CustomException("Campos incompletos.");

                var imgs = await Task.Run(() => LoadImages(txtDir.Text, (int)numArea.Value, checkBoxBordes.Checked, StepProgress));

                var form = new FormCreate(imgs, this);
                form.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.CustomMessage(), "Error");
            }
            finally
            {
                numArea.Enabled = checkBoxBordes.Enabled = txtDir.Enabled = true;
                lblCargando.Hide();
                progressBar1.Hide();
            }
        }

        private static List<MyImage> LoadImages(string dir, int area, bool cutBorder, Action<int> stepProgress)
        {
            //Load files
            var files = Directory.GetFiles(dir);
            if (!files.Any())
                throw new CustomException("No se encontro ningun archivo en el directorio.");

            var notImages = files.Where(f => !MyImage.IsImage(f));
            if (notImages.Any())
                throw new CustomException($"Los siguientes archivos de la carpeta no son imagenes:\n" +
                    $"{string.Join('\n', notImages.Select(file => Path.GetFileName(file)))}");

            //Convert files to images
            var imgs = new List<MyImage>();
            foreach (var file in files)
            {
                imgs.Add(new MyImage(path: file,
                                     data: Image.FromFile(file),
                                     cutBorder: cutBorder,
                                     area: area));

                stepProgress(files.Length);
            }

            return imgs;
        }

        #region ProgressBar
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
        #endregion

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                txtDir.Text = dialog.SelectedPath;
        }
    }
}
