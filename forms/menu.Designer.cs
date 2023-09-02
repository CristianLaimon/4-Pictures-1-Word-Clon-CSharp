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
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(113, 20);
            label1.Name = "label1";
            label1.Size = new Size(136, 20);
            label1.TabIndex = 0;
            label1.Text = "4 Pictures 1 Answer";
            // 
            // buttonJugar
            // 
            buttonJugar.Location = new Point(137, 206);
            buttonJugar.Name = "buttonJugar";
            buttonJugar.Size = new Size(94, 29);
            buttonJugar.TabIndex = 1;
            buttonJugar.Text = "Jugar";
            buttonJugar.UseVisualStyleBackColor = true;
            buttonJugar.Click += buttonJugar_Click;
            // 
            // buttonSalir
            // 
            buttonSalir.Location = new Point(137, 254);
            buttonSalir.Name = "buttonSalir";
            buttonSalir.Size = new Size(94, 29);
            buttonSalir.TabIndex = 7;
            buttonSalir.Text = "Salir";
            buttonSalir.UseVisualStyleBackColor = true;
            buttonSalir.Click += buttonSalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(113, 60);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(138, 124);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 348);
            label2.Name = "label2";
            label2.Size = new Size(205, 20);
            label2.TabIndex = 9;
            label2.Text = "Hecho por: Kristan Ruíz limón";
            // 
            // menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 378);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(buttonSalir);
            Controls.Add(buttonJugar);
            Controls.Add(label1);
            Name = "menu";
            Text = "menu";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button buttonJugar;
        private Button buttonSalir;
        private PictureBox pictureBox1;
        private Label label2;
    }
}