namespace Billar
{
    partial class Billar
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
            this.panelBackground = new System.Windows.Forms.Panel();
            this.panelCenter = new System.Windows.Forms.Panel();
            this.PCT_Canvas2 = new System.Windows.Forms.PictureBox();
            this.PCT_Canvas1 = new System.Windows.Forms.PictureBox();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.reload = new System.Windows.Forms.Button();
            this.score2LBL = new System.Windows.Forms.Label();
            this.sLBL1 = new System.Windows.Forms.Label();
            this.scoreLBL = new System.Windows.Forms.Label();
            this.sLBL = new System.Windows.Forms.Label();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.winner1 = new System.Windows.Forms.Label();
            this.panelBackground.SuspendLayout();
            this.panelCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas1)).BeginInit();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBackground
            // 
            this.panelBackground.BackColor = System.Drawing.Color.Transparent;
            this.panelBackground.Controls.Add(this.panelCenter);
            this.panelBackground.Controls.Add(this.panelBottom);
            this.panelBackground.Controls.Add(this.panelTop);
            this.panelBackground.Controls.Add(this.panelRight);
            this.panelBackground.Controls.Add(this.panelLeft);
            this.panelBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBackground.Location = new System.Drawing.Point(0, 0);
            this.panelBackground.Margin = new System.Windows.Forms.Padding(4);
            this.panelBackground.Name = "panelBackground";
            this.panelBackground.Size = new System.Drawing.Size(1978, 1066);
            this.panelBackground.TabIndex = 0;
            // 
            // panelCenter
            // 
            this.panelCenter.Controls.Add(this.PCT_Canvas2);
            this.panelCenter.Controls.Add(this.PCT_Canvas1);
            this.panelCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenter.Location = new System.Drawing.Point(100, 62);
            this.panelCenter.Margin = new System.Windows.Forms.Padding(4);
            this.panelCenter.Name = "panelCenter";
            this.panelCenter.Size = new System.Drawing.Size(1778, 942);
            this.panelCenter.TabIndex = 4;
            this.panelCenter.SizeChanged += new System.EventHandler(this.panelCenter_SizeChanged);
            // 
            // PCT_Canvas2
            // 
            this.PCT_Canvas2.BackColor = System.Drawing.Color.Transparent;
            this.PCT_Canvas2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_Canvas2.Location = new System.Drawing.Point(0, 0);
            this.PCT_Canvas2.Margin = new System.Windows.Forms.Padding(4);
            this.PCT_Canvas2.Name = "PCT_Canvas2";
            this.PCT_Canvas2.Size = new System.Drawing.Size(1778, 942);
            this.PCT_Canvas2.TabIndex = 1;
            this.PCT_Canvas2.TabStop = false;
            this.PCT_Canvas2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PCT_Canvas2_MouseClick);
            this.PCT_Canvas2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PCT_Canvas2_MouseDown);
            this.PCT_Canvas2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PCT_Canvas2_MouseMove);
            this.PCT_Canvas2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PCT_Canvas2_MouseUp);
            // 
            // PCT_Canvas1
            // 
            this.PCT_Canvas1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PCT_Canvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PCT_Canvas1.Location = new System.Drawing.Point(0, 0);
            this.PCT_Canvas1.Margin = new System.Windows.Forms.Padding(4);
            this.PCT_Canvas1.Name = "PCT_Canvas1";
            this.PCT_Canvas1.Size = new System.Drawing.Size(1778, 942);
            this.PCT_Canvas1.TabIndex = 0;
            this.PCT_Canvas1.TabStop = false;
            // 
            // panelBottom
            // 
            this.panelBottom.BackColor = System.Drawing.Color.Transparent;
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(100, 1004);
            this.panelBottom.Margin = new System.Windows.Forms.Padding(4);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(1778, 62);
            this.panelBottom.TabIndex = 3;
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Transparent;
            this.panelTop.Controls.Add(this.winner1);
            this.panelTop.Controls.Add(this.reload);

            this.panelTop.Controls.Add(this.score2LBL);
            this.panelTop.Controls.Add(this.sLBL1);
            this.panelTop.Controls.Add(this.scoreLBL);
            this.panelTop.Controls.Add(this.sLBL);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(100, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1778, 62);
            this.panelTop.TabIndex = 2;
            // 
            // reload
            // 
            this.reload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.reload.ForeColor = System.Drawing.SystemColors.MenuText;
            this.reload.Location = new System.Drawing.Point(1617, 16);
            this.reload.Name = "reload";
            this.reload.Size = new System.Drawing.Size(112, 34);
            this.reload.TabIndex = 5;
            this.reload.Text = "Reload";
            this.reload.UseVisualStyleBackColor = true;
            this.reload.Click += new System.EventHandler(this.reload_Click);
            // 

            // 
            // score2LBL
            // 
            this.score2LBL.AutoSize = true;
            this.score2LBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.score2LBL.ForeColor = System.Drawing.SystemColors.Control;
            this.score2LBL.Location = new System.Drawing.Point(951, 16);
            this.score2LBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.score2LBL.Name = "score2LBL";
            this.score2LBL.Size = new System.Drawing.Size(28, 32);
            this.score2LBL.TabIndex = 3;
            this.score2LBL.Text = "0";
            // 
            // sLBL1
            // 
            this.sLBL1.AutoSize = true;
            this.sLBL1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sLBL1.ForeColor = System.Drawing.SystemColors.Control;
            this.sLBL1.Location = new System.Drawing.Point(738, 16);
            this.sLBL1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sLBL1.Name = "sLBL1";
            this.sLBL1.Size = new System.Drawing.Size(183, 32);
            this.sLBL1.TabIndex = 2;
            this.sLBL1.Text = "Player 2 Score:";
            // 
            // scoreLBL
            // 
            this.scoreLBL.AutoSize = true;
            this.scoreLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.scoreLBL.ForeColor = System.Drawing.SystemColors.Control;
            this.scoreLBL.Location = new System.Drawing.Point(401, 16);
            this.scoreLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.scoreLBL.Name = "scoreLBL";
            this.scoreLBL.Size = new System.Drawing.Size(28, 32);
            this.scoreLBL.TabIndex = 1;
            this.scoreLBL.Text = "0";
            // 
            // sLBL
            // 
            this.sLBL.AutoSize = true;
            this.sLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.sLBL.ForeColor = System.Drawing.SystemColors.Control;
            this.sLBL.Location = new System.Drawing.Point(199, 16);
            this.sLBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sLBL.Name = "sLBL";
            this.sLBL.Size = new System.Drawing.Size(183, 32);
            this.sLBL.TabIndex = 0;
            this.sLBL.Text = "Player 1 Score:";
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.Transparent;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(1878, 0);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(100, 1066);
            this.panelRight.TabIndex = 1;
            // 
            // panelLeft
            // 
            this.panelLeft.BackColor = System.Drawing.Color.Transparent;
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Margin = new System.Windows.Forms.Padding(4);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(100, 1066);
            this.panelLeft.TabIndex = 0;
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Interval = 10;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // winner1
            // 
            this.winner1.AutoSize = true;
            this.winner1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.winner1.ForeColor = System.Drawing.SystemColors.Control;
            this.winner1.Location = new System.Drawing.Point(1240, 5);
            this.winner1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.winner1.Name = "winner1";
            this.winner1.Size = new System.Drawing.Size(143, 48);
            this.winner1.TabIndex = 6;
            this.winner1.Text = "Winner";
            // 
            // Billar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Billar.Properties.Resources.wooden_floor;
            this.ClientSize = new System.Drawing.Size(1978, 1066);
            this.Controls.Add(this.panelBackground);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1591, 1004);
            this.Name = "Billar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Billar_Load);
            this.panelBackground.ResumeLayout(false);
            this.panelCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PCT_Canvas1)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panelBackground;
        private Panel panelCenter;
        private PictureBox PCT_Canvas1;
        private Panel panelBottom;
        private Panel panelTop;
        private Panel panelRight;
        private Panel panelLeft;
        private System.Windows.Forms.Timer Timer;
        private PictureBox PCT_Canvas2;
        public  Label sLBL;
        private Label scoreLBL;
        private Label score2LBL;
        public Label sLBL1;
        private Button reload;
        public Label winner1;
    }
}