using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ImageGridCreator
{
    public partial class FormVerMas : Form
    {
        Form FormAnterior;
        public FormVerMas(Image image, Form formAnterior)
        {
            InitializeComponent();
            pictureBox1.Image = image;
            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;
            panel1.AutoScroll = true;
            WindowState = FormWindowState.Maximized;
            FormAnterior = formAnterior;
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Hide();
            FormAnterior.Show();
        }

        private void formClosed(object sender, FormClosedEventArgs e)
        {
            FormAnterior.Show();
        }
    }
}
