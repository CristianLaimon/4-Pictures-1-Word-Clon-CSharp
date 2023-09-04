namespace _4pictures1word.forms
{
    partial class menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            buttonJugar = new Button();
            buttonSalir = new Button();
            pictureBox1 = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            buttonContinuar = new Button();
            labelDineroActual = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(55, 25);
            label1.Name = "label1";
            label1.Size = new Size(255, 38);
            label1.TabIndex = 0;
            label1.Text = "4 Pictures 1 Answer";
            // 
            // buttonJugar
            // 
            buttonJugar.Location = new Point(102, 264);
            buttonJugar.Name = "buttonJugar";
            buttonJugar.Size = new Size(149, 29);
            buttonJugar.TabIndex = 1;
            buttonJugar.Text = "Nueva Partida";
            buttonJugar.UseVisualStyleBackColor = true;
            buttonJugar.Click += buttonJugar_Click_1;
            // 
            // buttonSalir
            // 
            buttonSalir.Location = new Point(130, 386);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(94, 29);
            buttonSalir.TabIndex = 7;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = true;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.R;
            pictureBox1.Location = new Point(102, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 151);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 524);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(370, 26);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(205, 20);
            toolStripStatusLabel1.Text = "Hecho por: Kristan Ruíz limón";
            // 
            // buttonContinuar
            // 
            buttonContinuar.Enabled = false;
            buttonContinuar.Location = new Point(130, 320);
            buttonContinuar.Name = "buttonContinuar";
            buttonContinuar.Size = new Size(94, 29);
            buttonContinuar.TabIndex = 11;
            buttonContinuar.Text = "Continuar";
            buttonContinuar.UseVisualStyleBackColor = true;
            buttonContinuar.Click += buttonJugar_Click;
            // 
            // labelDineroActual
            // 
            labelDineroActual.AutoSize = true;
            labelDineroActual.Location = new Point(22, 488);
            labelDineroActual.Name = "labelDineroActual";
            labelDineroActual.Size = new Size(69, 20);
            labelDineroActual.TabIndex = 12;
            labelDineroActual.Text = "Dinero: 0";
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 550);
            Controls.Add(labelDineroActual);
            Controls.Add(buttonContinuar);
            Controls.Add(statusStrip1);
            Controls.Add(pictureBox1);
            Controls.Add(buttonSalir);
            Controls.Add(buttonJugar);
            Controls.Add(label1);
            Name = "menu";
            Text = "4 Pictures 1 Answer - Game";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonJugar;
        private Button buttonSalir;
        private PictureBox pictureBox1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Button buttonContinuar;
        private Label labelDineroActual;
    }
}