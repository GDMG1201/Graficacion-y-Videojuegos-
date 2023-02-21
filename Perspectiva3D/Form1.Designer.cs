namespace Demo3D
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
            this.components = new System.ComponentModel.Container();
            this.PCT_CANVAS = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ejeX = new System.Windows.Forms.Button();
            this.ejeY = new System.Windows.Forms.Button();
            this.ejeZ = new System.Windows.Forms.Button();
            this.ejeall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).BeginInit();
            this.SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            this.PCT_CANVAS.Location = new System.Drawing.Point(40, 45);
            this.PCT_CANVAS.Margin = new System.Windows.Forms.Padding(2);
            this.PCT_CANVAS.Name = "PCT_CANVAS";
            this.PCT_CANVAS.Size = new System.Drawing.Size(692, 346);
            this.PCT_CANVAS.TabIndex = 0;
            this.PCT_CANVAS.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ejeX
            // 
            this.ejeX.Location = new System.Drawing.Point(40, 452);
            this.ejeX.Name = "ejeX";
            this.ejeX.Size = new System.Drawing.Size(137, 34);
            this.ejeX.TabIndex = 1;
            this.ejeX.Text = "Girar eje X";
            this.ejeX.UseVisualStyleBackColor = true;
            this.ejeX.Click += new System.EventHandler(this.ejeX_Click);
            // 
            // ejeY
            // 
            this.ejeY.Location = new System.Drawing.Point(222, 452);
            this.ejeY.Name = "ejeY";
            this.ejeY.Size = new System.Drawing.Size(144, 34);
            this.ejeY.TabIndex = 2;
            this.ejeY.Text = "Girar eje Y";
            this.ejeY.UseVisualStyleBackColor = true;
            this.ejeY.Click += new System.EventHandler(this.ejeY_Click);
            // 
            // ejeZ
            // 
            this.ejeZ.Location = new System.Drawing.Point(401, 452);
            this.ejeZ.Name = "ejeZ";
            this.ejeZ.Size = new System.Drawing.Size(147, 34);
            this.ejeZ.TabIndex = 3;
            this.ejeZ.Text = "Girar eje Z";
            this.ejeZ.UseVisualStyleBackColor = true;
            this.ejeZ.Click += new System.EventHandler(this.ejeZ_Click);
            // 
            // ejeall
            // 
            this.ejeall.Location = new System.Drawing.Point(585, 452);
            this.ejeall.Name = "ejeall";
            this.ejeall.Size = new System.Drawing.Size(147, 34);
            this.ejeall.TabIndex = 4;
            this.ejeall.Text = "Girar sobre XYZ";
            this.ejeall.UseVisualStyleBackColor = true;
            this.ejeall.Click += new System.EventHandler(this.ejeall_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 538);
            this.Controls.Add(this.ejeall);
            this.Controls.Add(this.ejeZ);
            this.Controls.Add(this.ejeY);
            this.Controls.Add(this.ejeX);
            this.Controls.Add(this.PCT_CANVAS);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_CANVAS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        
        private System.Windows.Forms.Timer timer1;
        private PictureBox PCT_CANVAS;
        private Button ejeX;
        private Button ejeY;
        private Button ejeZ;
        private Button ejeall;
    }
}