namespace LAB2
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ClearTheCanvas = new System.Windows.Forms.Button();
            this.SaveImage = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.Color1 = new System.Windows.Forms.Button();
            this.Color2 = new System.Windows.Forms.Button();
            this.Color3 = new System.Windows.Forms.Button();
            this.Color4 = new System.Windows.Forms.Button();
            this.Color5 = new System.Windows.Forms.Button();
            this.Color6 = new System.Windows.Forms.Button();
            this.Color7 = new System.Windows.Forms.Button();
            this.Color8 = new System.Windows.Forms.Button();
            this.Color9 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.PenWidth = new System.Windows.Forms.TrackBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.FreeFormat = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenWidth)).BeginInit();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(854, 450);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // ClearTheCanvas
            // 
            this.ClearTheCanvas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ClearTheCanvas.Location = new System.Drawing.Point(0, 427);
            this.ClearTheCanvas.Name = "ClearTheCanvas";
            this.ClearTheCanvas.Size = new System.Drawing.Size(149, 23);
            this.ClearTheCanvas.TabIndex = 1;
            this.ClearTheCanvas.Text = "Clear";
            this.ClearTheCanvas.UseVisualStyleBackColor = true;
            this.ClearTheCanvas.Click += new System.EventHandler(this.ClearTheCanvas_Click);
            // 
            // SaveImage
            // 
            this.SaveImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SaveImage.Location = new System.Drawing.Point(0, 404);
            this.SaveImage.Name = "SaveImage";
            this.SaveImage.Size = new System.Drawing.Size(149, 23);
            this.SaveImage.TabIndex = 2;
            this.SaveImage.Text = "Save Image";
            this.SaveImage.UseVisualStyleBackColor = true;
            this.SaveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel1.Controls.Add(this.Color1);
            this.flowLayoutPanel1.Controls.Add(this.Color2);
            this.flowLayoutPanel1.Controls.Add(this.Color3);
            this.flowLayoutPanel1.Controls.Add(this.Color4);
            this.flowLayoutPanel1.Controls.Add(this.Color5);
            this.flowLayoutPanel1.Controls.Add(this.Color6);
            this.flowLayoutPanel1.Controls.Add(this.Color7);
            this.flowLayoutPanel1.Controls.Add(this.Color8);
            this.flowLayoutPanel1.Controls.Add(this.Color9);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(149, 139);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // Color1
            // 
            this.Color1.BackColor = System.Drawing.Color.White;
            this.Color1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color1.Location = new System.Drawing.Point(3, 3);
            this.Color1.Name = "Color1";
            this.Color1.Size = new System.Drawing.Size(30, 30);
            this.Color1.TabIndex = 0;
            this.Color1.UseVisualStyleBackColor = false;
            this.Color1.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color2
            // 
            this.Color2.BackColor = System.Drawing.Color.Red;
            this.Color2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color2.Location = new System.Drawing.Point(39, 3);
            this.Color2.Name = "Color2";
            this.Color2.Size = new System.Drawing.Size(30, 30);
            this.Color2.TabIndex = 1;
            this.Color2.UseVisualStyleBackColor = false;
            this.Color2.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color3
            // 
            this.Color3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Color3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color3.Location = new System.Drawing.Point(75, 3);
            this.Color3.Name = "Color3";
            this.Color3.Size = new System.Drawing.Size(30, 30);
            this.Color3.TabIndex = 2;
            this.Color3.UseVisualStyleBackColor = false;
            this.Color3.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color4
            // 
            this.Color4.BackColor = System.Drawing.Color.Yellow;
            this.Color4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color4.Location = new System.Drawing.Point(111, 3);
            this.Color4.Name = "Color4";
            this.Color4.Size = new System.Drawing.Size(30, 30);
            this.Color4.TabIndex = 3;
            this.Color4.UseVisualStyleBackColor = false;
            this.Color4.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color5
            // 
            this.Color5.BackColor = System.Drawing.Color.Lime;
            this.Color5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color5.Location = new System.Drawing.Point(3, 39);
            this.Color5.Name = "Color5";
            this.Color5.Size = new System.Drawing.Size(30, 30);
            this.Color5.TabIndex = 4;
            this.Color5.UseVisualStyleBackColor = false;
            this.Color5.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color6
            // 
            this.Color6.BackColor = System.Drawing.Color.Cyan;
            this.Color6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color6.Location = new System.Drawing.Point(39, 39);
            this.Color6.Name = "Color6";
            this.Color6.Size = new System.Drawing.Size(30, 30);
            this.Color6.TabIndex = 5;
            this.Color6.UseVisualStyleBackColor = false;
            this.Color6.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color7
            // 
            this.Color7.BackColor = System.Drawing.Color.Blue;
            this.Color7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color7.Location = new System.Drawing.Point(75, 39);
            this.Color7.Name = "Color7";
            this.Color7.Size = new System.Drawing.Size(30, 30);
            this.Color7.TabIndex = 6;
            this.Color7.UseVisualStyleBackColor = false;
            this.Color7.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color8
            // 
            this.Color8.BackColor = System.Drawing.Color.Fuchsia;
            this.Color8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color8.Location = new System.Drawing.Point(111, 39);
            this.Color8.Name = "Color8";
            this.Color8.Size = new System.Drawing.Size(30, 30);
            this.Color8.TabIndex = 7;
            this.Color8.UseVisualStyleBackColor = false;
            this.Color8.Click += new System.EventHandler(this.Color1_Click);
            // 
            // Color9
            // 
            this.Color9.BackColor = System.Drawing.Color.Black;
            this.Color9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Color9.Location = new System.Drawing.Point(3, 75);
            this.Color9.Name = "Color9";
            this.Color9.Size = new System.Drawing.Size(30, 30);
            this.Color9.TabIndex = 8;
            this.Color9.UseVisualStyleBackColor = false;
            this.Color9.Click += new System.EventHandler(this.Color1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.Control;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(39, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 11;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.RGB_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(75, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(66, 30);
            this.button1.TabIndex = 10;
            this.button1.Text = "ERASER";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Color1_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel2.Controls.Add(this.PenWidth);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 139);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(149, 44);
            this.flowLayoutPanel2.TabIndex = 4;
            // 
            // PenWidth
            // 
            this.PenWidth.Location = new System.Drawing.Point(3, 3);
            this.PenWidth.Maximum = 20;
            this.PenWidth.Name = "PenWidth";
            this.PenWidth.Size = new System.Drawing.Size(138, 45);
            this.PenWidth.TabIndex = 1;
            this.PenWidth.ValueChanged += new System.EventHandler(this.trackBar2_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.flowLayoutPanel3);
            this.panel1.Controls.Add(this.flowLayoutPanel2);
            this.panel1.Controls.Add(this.SaveImage);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.ClearTheCanvas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(705, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(149, 450);
            this.panel1.TabIndex = 5;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flowLayoutPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLayoutPanel3.Controls.Add(this.FreeFormat);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(0, 183);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(149, 100);
            this.flowLayoutPanel3.TabIndex = 5;
            // 
            // FreeFormat
            // 
            this.FreeFormat.AutoSize = true;
            this.FreeFormat.Location = new System.Drawing.Point(3, 3);
            this.FreeFormat.Name = "FreeFormat";
            this.FreeFormat.Size = new System.Drawing.Size(88, 19);
            this.FreeFormat.TabIndex = 0;
            this.FreeFormat.TabStop = true;
            this.FreeFormat.Text = "Free Format";
            this.FreeFormat.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(854, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PenWidth)).EndInit();
            this.panel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private PictureBox pictureBox1;
        private Button ClearTheCanvas;
        private Button SaveImage;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button Color1;
        private Button Color2;
        private Button Color3;
        private Button Color4;
        private Button Color5;
        private Button Color6;
        private Button Color7;
        private Button Color8;
        private Button Color9;
        private FlowLayoutPanel flowLayoutPanel2;
        private TrackBar PenWidth;
        private Button button1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private ColorDialog colorDialog1;
        private Button button2;
        private SaveFileDialog saveFileDialog1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel3;
        private RadioButton FreeFormat;
    }
}