namespace BlackScreenDetect
{
    partial class Loading
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._cmsSizes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._ts256 = new System.Windows.Forms.RadioButton();
            this._ts128 = new System.Windows.Forms.RadioButton();
            this._ts64 = new System.Windows.Forms.RadioButton();
            this._tsAbort = new System.Windows.Forms.ToolStripMenuItem();
            this._tsAbortAll = new System.Windows.Forms.ToolStripMenuItem();
            this._tsOpacity = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._tsOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BlackScreenDetect.Properties.Resources.Loading;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // _cmsSizes
            // 
            this._cmsSizes.Name = "_cmsSizes";
            this._cmsSizes.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._cmsSizes.ShowImageMargin = false;
            this._cmsSizes.Size = new System.Drawing.Size(36, 4);
            // 
            // _ts256
            // 
            this._ts256.BackColor = System.Drawing.Color.White;
            this._ts256.Location = new System.Drawing.Point(0, 0);
            this._ts256.Name = "_ts256";
            this._ts256.Size = new System.Drawing.Size(70, 22);
            this._ts256.TabIndex = 0;
            this._ts256.Text = "256x256";
            this._ts256.UseVisualStyleBackColor = false;
            this._ts256.CheckedChanged += new System.EventHandler(this.x256_CheckedChanged);
            // 
            // _ts128
            // 
            this._ts128.BackColor = System.Drawing.Color.White;
            this._ts128.Location = new System.Drawing.Point(0, 0);
            this._ts128.Name = "_ts128";
            this._ts128.Size = new System.Drawing.Size(70, 22);
            this._ts128.TabIndex = 0;
            this._ts128.Text = "128x128";
            this._ts128.UseVisualStyleBackColor = false;
            this._ts128.CheckedChanged += new System.EventHandler(this.x128_CheckedChanged);
            // 
            // _ts64
            // 
            this._ts64.BackColor = System.Drawing.Color.White;
            this._ts64.Location = new System.Drawing.Point(0, 0);
            this._ts64.Name = "_ts64";
            this._ts64.Size = new System.Drawing.Size(70, 22);
            this._ts64.TabIndex = 0;
            this._ts64.Text = "64x64";
            this._ts64.UseVisualStyleBackColor = false;
            this._ts64.CheckedChanged += new System.EventHandler(this.x64_CheckedChanged);
            // 
            // _tsAbort
            // 
            this._tsAbort.Name = "_tsAbort";
            this._tsAbort.Size = new System.Drawing.Size(32, 19);
            this._tsAbort.Text = "Abort";
            this._tsAbort.Click += new System.EventHandler(this.Abort_Clicked);
            // 
            // _tsAbortAll
            // 
            this._tsAbortAll.Name = "_tsAbortAll";
            this._tsAbortAll.Size = new System.Drawing.Size(32, 19);
            this._tsAbortAll.Text = "Abort All";
            this._tsAbortAll.Click += new System.EventHandler(this.AbortAll_Clicked);
            // 
            // _tsOpacity
            // 
            this._tsOpacity.BackColor = System.Drawing.Color.White;
            this._tsOpacity.Location = new System.Drawing.Point(0, 0);
            this._tsOpacity.Maximum = 100;
            this._tsOpacity.Minimum = 15;
            this._tsOpacity.Name = "_tsOpacity";
            this._tsOpacity.Size = new System.Drawing.Size(100, 45);
            this._tsOpacity.TabIndex = 0;
            this._tsOpacity.Text = "Opacity";
            this._tsOpacity.Value = 15;
            this._tsOpacity.Scroll += new System.EventHandler(this.opacity_Scroll);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(256, 256);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Loading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.SizeChanged += new System.EventHandler(this.Loading_SizeChanged);
            this.Move += new System.EventHandler(this.Loading_Move);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._tsOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip _cmsSizes;
        private System.Windows.Forms.RadioButton _ts256;
        private System.Windows.Forms.RadioButton _ts128;
        private System.Windows.Forms.RadioButton _ts64;
        private System.Windows.Forms.ToolStripMenuItem _tsAbort;
        private System.Windows.Forms.ToolStripMenuItem _tsAbortAll;
        private System.Windows.Forms.TrackBar _tsOpacity;
        private System.Windows.Forms.ToolStripControlHost _tsh256;
        private System.Windows.Forms.ToolStripControlHost _tsh128;
        private System.Windows.Forms.ToolStripControlHost _tsh64;
        private System.Windows.Forms.ToolStripControlHost _tshOpacity;
    }
}