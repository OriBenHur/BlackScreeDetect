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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loading));
            this._cmsSizes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this._tsLarge = new System.Windows.Forms.RadioButton();
            this._tsMedium = new System.Windows.Forms.RadioButton();
            this._tsSmall = new System.Windows.Forms.RadioButton();
            this._tsAbort = new System.Windows.Forms.ToolStripMenuItem();
            this._tsAbortAll = new System.Windows.Forms.ToolStripMenuItem();
            this._tsOpacity = new System.Windows.Forms.TrackBar();
            this._lbPrograss = new System.Windows.Forms.Label();
            this._niLoading = new System.Windows.Forms.NotifyIcon(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._tsOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _cmsSizes
            // 
            this._cmsSizes.Name = "_cmsSizes";
            this._cmsSizes.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this._cmsSizes.ShowImageMargin = false;
            this._cmsSizes.Size = new System.Drawing.Size(36, 4);
            // 
            // _tsLarge
            // 
            this._tsLarge.BackColor = System.Drawing.Color.White;
            this._tsLarge.Location = new System.Drawing.Point(0, 0);
            this._tsLarge.Name = "_tsLarge";
            this._tsLarge.Size = new System.Drawing.Size(94, 80);
            this._tsLarge.TabIndex = 0;
            this._tsLarge.Text = "Large";
            this._tsLarge.UseVisualStyleBackColor = false;
            this._tsLarge.CheckedChanged += new System.EventHandler(this._tsLarge_CheckedChanged);
            // 
            // _tsMedium
            // 
            this._tsMedium.BackColor = System.Drawing.Color.White;
            this._tsMedium.Location = new System.Drawing.Point(0, 0);
            this._tsMedium.Name = "_tsMedium";
            this._tsMedium.Size = new System.Drawing.Size(94, 80);
            this._tsMedium.TabIndex = 0;
            this._tsMedium.Text = "Medium";
            this._tsMedium.UseVisualStyleBackColor = false;
            this._tsMedium.CheckedChanged += new System.EventHandler(this._tsMedium_CheckedChanged);
            // 
            // _tsSmall
            // 
            this._tsSmall.BackColor = System.Drawing.Color.White;
            this._tsSmall.Location = new System.Drawing.Point(0, 0);
            this._tsSmall.Name = "_tsSmall";
            this._tsSmall.Size = new System.Drawing.Size(94, 80);
            this._tsSmall.TabIndex = 0;
            this._tsSmall.Text = "Small";
            this._tsSmall.UseVisualStyleBackColor = false;
            this._tsSmall.CheckedChanged += new System.EventHandler(this._tsSmall_CheckedChanged);
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
            this._tsOpacity.Size = new System.Drawing.Size(120, 45);
            this._tsOpacity.TabIndex = 0;
            this._tsOpacity.Text = "Opacity";
            this._tsOpacity.Value = 15;
            this._tsOpacity.Scroll += new System.EventHandler(this.opacity_Scroll);
            // 
            // _lbPrograss
            // 
            this._lbPrograss.AutoSize = true;
            this._lbPrograss.Location = new System.Drawing.Point(8, 8);
            this._lbPrograss.Name = "_lbPrograss";
            this._lbPrograss.Size = new System.Drawing.Size(0, 13);
            this._lbPrograss.TabIndex = 1;
            // 
            // _niLoading
            // 
            this._niLoading.ContextMenuStrip = this._cmsSizes;
            this._niLoading.Icon = ((System.Drawing.Icon)(resources.GetObject("_niLoading.Icon")));
            this._niLoading.BalloonTipShown += new System.EventHandler(this._niLoading_BalloonTipShown);
            this._niLoading.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._niLoading_MouseDoubleClick);
            this._niLoading.MouseMove += new System.Windows.Forms.MouseEventHandler(this._niLoading_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::BlackScreenDetect.Properties.Resources.New_Loading;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Loading
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(80, 80);
            this.Controls.Add(this._lbPrograss);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Loading";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.Loading_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Loading_FormClosing);
            this.Load += new System.EventHandler(this.Loading_Load);
            this.LocationChanged += new System.EventHandler(this.Loading_LocationChanged);
            this.Move += new System.EventHandler(this.Loading_Move);
            ((System.ComponentModel.ISupportInitialize)(this._tsOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ContextMenuStrip _cmsSizes;
        private System.Windows.Forms.RadioButton _tsLarge;
        private System.Windows.Forms.RadioButton _tsMedium;
        private System.Windows.Forms.RadioButton _tsSmall;
        private System.Windows.Forms.ToolStripMenuItem _tsAbort;
        private System.Windows.Forms.ToolStripMenuItem _tsAbortAll;
        private System.Windows.Forms.TrackBar _tsOpacity;
        public System.Windows.Forms.Label _lbPrograss;
        private System.Windows.Forms.ToolStripControlHost _tsh256;
        private System.Windows.Forms.ToolStripControlHost _tsh128;
        private System.Windows.Forms.ToolStripControlHost _tsh64;
        private System.Windows.Forms.ToolStripControlHost _tshOpacity;
        public System.Windows.Forms.NotifyIcon _niLoading;

    }
}