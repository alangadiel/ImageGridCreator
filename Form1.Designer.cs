namespace ImageGridCreator
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDir = new System.Windows.Forms.TextBox();
            this.checkBoxFondoTransparente = new System.Windows.Forms.CheckBox();
            this.btnExaminar = new System.Windows.Forms.Button();
            this.lblCargando = new System.Windows.Forms.Label();
            this.txtAlto = new System.Windows.Forms.TextBox();
            this.txtSep = new System.Windows.Forms.TextBox();
            this.txtAncho = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Directorio: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Separación:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 30);
            this.label3.TabIndex = 0;
            this.label3.Text = "Alto individual: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(132, 30);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ancho total: ";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(513, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(83, 52);
            this.button1.TabIndex = 1;
            this.button1.Text = "Crear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDir
            // 
            this.txtDir.Location = new System.Drawing.Point(135, 17);
            this.txtDir.Name = "txtDir";
            this.txtDir.Size = new System.Drawing.Size(356, 25);
            this.txtDir.TabIndex = 2;
            // 
            // checkBoxFondoTransparente
            // 
            this.checkBoxFondoTransparente.AutoSize = true;
            this.checkBoxFondoTransparente.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxFondoTransparente.Location = new System.Drawing.Point(19, 207);
            this.checkBoxFondoTransparente.Name = "checkBoxFondoTransparente";
            this.checkBoxFondoTransparente.Size = new System.Drawing.Size(215, 34);
            this.checkBoxFondoTransparente.TabIndex = 4;
            this.checkBoxFondoTransparente.Text = "Fondo Transparente";
            this.checkBoxFondoTransparente.UseVisualStyleBackColor = true;
            // 
            // btnExaminar
            // 
            this.btnExaminar.Location = new System.Drawing.Point(497, 15);
            this.btnExaminar.Name = "btnExaminar";
            this.btnExaminar.Size = new System.Drawing.Size(75, 28);
            this.btnExaminar.TabIndex = 6;
            this.btnExaminar.Text = "Examinar";
            this.btnExaminar.UseVisualStyleBackColor = true;
            this.btnExaminar.Click += new System.EventHandler(this.btnExaminar_Click);
            // 
            // lblCargando
            // 
            this.lblCargando.AutoSize = true;
            this.lblCargando.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCargando.Location = new System.Drawing.Point(19, 260);
            this.lblCargando.Name = "lblCargando";
            this.lblCargando.Size = new System.Drawing.Size(118, 30);
            this.lblCargando.TabIndex = 0;
            this.lblCargando.Text = "Cargando...";
            this.lblCargando.Visible = false;
            // 
            // txtAlto
            // 
            this.txtAlto.Location = new System.Drawing.Point(173, 63);
            this.txtAlto.Name = "txtAlto";
            this.txtAlto.Size = new System.Drawing.Size(100, 25);
            this.txtAlto.TabIndex = 8;
            // 
            // txtSep
            // 
            this.txtSep.Location = new System.Drawing.Point(138, 163);
            this.txtSep.Name = "txtSep";
            this.txtSep.Size = new System.Drawing.Size(100, 25);
            this.txtSep.TabIndex = 8;
            // 
            // txtAncho
            // 
            this.txtAncho.Location = new System.Drawing.Point(150, 112);
            this.txtAncho.Name = "txtAncho";
            this.txtAncho.Size = new System.Drawing.Size(100, 25);
            this.txtAncho.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 324);
            this.Controls.Add(this.txtAncho);
            this.Controls.Add(this.txtSep);
            this.Controls.Add(this.txtAlto);
            this.Controls.Add(this.btnExaminar);
            this.Controls.Add(this.checkBoxFondoTransparente);
            this.Controls.Add(this.txtDir);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCargando);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "ImageGridCreator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDir;
        private System.Windows.Forms.CheckBox checkBoxFondoTransparente;
        private System.Windows.Forms.Button btnExaminar;
        private System.Windows.Forms.Label lblCargando;
        private System.Windows.Forms.TextBox txtAlto;
        private System.Windows.Forms.TextBox txtSep;
        private System.Windows.Forms.TextBox txtAncho;
    }
}

