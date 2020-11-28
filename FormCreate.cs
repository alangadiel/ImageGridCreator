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
    public partial class FormCreate : Form
    {
        ImageCreator imageCreator;
        FormLoad FormLoad;

        public FormCreate(List<MyImage> images, FormLoad formLoad)
        {
            InitializeComponent();
            imageCreator = new ImageCreator(images);
            FormLoad = formLoad;
        }

        private async void btnCrear_Click(object sender, EventArgs e)
        {
            Loading = true;
            try
            {
                await Task.Run(() => imageCreator.Create((int)numAncho.Value, (int)numPadding.Value, checkBoxFondoTransparente.Checked));

                pictureBox1.Image = imageCreator.NewImage;
                pictureBox1.Height = imageCreator.NewImage.Height;
                pictureBox1.Width = imageCreator.NewImage.Width;
                panel1.AutoScroll = true;
                btnGuardar.Enabled = btnVer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.CustomMessage(), "Error");
            }
            finally
            {
                Loading = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Loading = true;
            try
            {
                var dialog = new SaveFileDialog
                {
                    DefaultExt = ".png",
                };
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                imageCreator.NewImage.Save(dialog.FileName, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.CustomMessage(), "Error");
            }
            finally
            {
                Loading = false;
            }
        }

        private void Txt_TextChangedCreate(object sender, EventArgs e) => btnGuardar.Enabled = btnVer.Enabled = false;

        private void btnVerMas_Click(object sender, EventArgs e)
        {
            var form = new FormViewMore(imageCreator.NewImage, this);
            Hide();
            form.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool Loading
        {
            set
            {
                btnGuardar.Enabled = 
                    btnVer.Enabled = 
                    btnCrear.Enabled = 
                    numAncho.Enabled = 
                    numPadding.Enabled = 
                    checkBoxFondoTransparente.Enabled = !value;

                lblCargando.Visible = value;
            }

            get
            {
                return lblCargando.Visible;
            }
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            imageCreator.Dispose();
            FormLoad.Show();
        }
    }
}
