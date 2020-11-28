namespace ImageGridCreator
{
    partial class FormCreate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCrear = new System.Windows.Forms.Button();
            this.checkBoxFondoTransparente = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblCargando = new System.Windows.Forms.Label();
            this.numAncho = new System.Windows.Forms.NumericUpDown();
            this.numPadding = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAncho)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPadding)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Separación:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ancho total: ";
            // 
            // btnCrear
            // 
            this.btnCrear.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCrear.Location = new System.Drawing.Point(290, 155);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(83, 47);
            this.btnCrear.TabIndex = 1;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // checkBoxFondoTransparente
            // 
            this.checkBoxFondoTransparente.AutoSize = true;
            this.checkBoxFondoTransparente.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxFondoTransparente.Location = new System.Drawing.Point(19, 109);
            this.checkBoxFondoTransparente.Name = "checkBoxFondoTransparente";
            this.checkBoxFondoTransparente.Size = new System.Drawing.Size(213, 34);
            this.checkBoxFondoTransparente.TabIndex = 4;
            this.checkBoxFondoTransparente.Text = "Fondo transparente";
            this.checkBoxFondoTransparente.UseVisualStyleBackColor = true;
            this.checkBoxFondoTransparente.CheckedChanged += new System.EventHandler(this.Txt_TextChangedCreate);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(485, 345);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardar.Location = new System.Drawing.Point(465, 155);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(107, 47);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(13, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 407);
            this.panel1.TabIndex = 10;
            // 
            // btnVer
            // 
            this.btnVer.Enabled = false;
            this.btnVer.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVer.Location = new System.Drawing.Point(379, 155);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(80, 47);
            this.btnVer.TabIndex = 1;
            this.btnVer.Text = "Ver+";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVerMas_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnVolver.Location = new System.Drawing.Point(482, 23);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(90, 46);
            this.btnVolver.TabIndex = 1;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCargando.Location = new System.Drawing.Point(19, 163);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(118, 30);
            this.lblCargando.TabIndex = 0;
            this.lblCargando.Text = "Cargando...";
            this.lblCargando.Visible = false;
            // 
            // numAncho
            // 
            this.numAncho.Location = new System.Drawing.Point(150, 26);
            this.numAncho.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.numAncho.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAncho.Name = "numAncho";
            this.numAncho.Size = new System.Drawing.Size(120, 23);
            this.numAncho.TabIndex = 12;
            this.numAncho.ThousandsSeparator = true;
            this.numAncho.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numAncho.ValueChanged += new System.EventHandler(this.Txt_TextChangedCreate);
            // 
            // numPadding
            // 
            this.numPadding.Location = new System.Drawing.Point(138, 71);
            this.numPadding.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numPadding.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numPadding.Name = "numPadding";
            this.numPadding.Size = new System.Drawing.Size(120, 23);
            this.numPadding.TabIndex = 12;
            this.numPadding.ThousandsSeparator = true;
            this.numPadding.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numPadding.ValueChanged += new System.EventHandler(this.Txt_TextChangedCreate);
            // 
            // FormCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 637);
            this.Controls.Add(this.numPadding);
            this.Controls.Add(this.numAncho);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.checkBoxFondoTransparente);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCargando);
            this.Controls.Add(this.panel1);
            this.Name = "FormCreate";
            this.Text = "ImageGridCreator";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numAncho)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPadding)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.CheckBox checkBoxFondoTransparente;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblCargando;
        private System.Windows.Forms.NumericUpDown numAncho;
        private System.Windows.Forms.NumericUpDown numPadding;
    }
}

