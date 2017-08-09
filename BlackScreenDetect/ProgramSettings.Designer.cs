namespace BlackScreenDetect
{
    partial class ProgramSettings
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
            this._ffmpegbinLib = new System.Windows.Forms.Label();
            this._tbFFmpegLocation = new System.Windows.Forms.TextBox();
            this._browesButton = new System.Windows.Forms.Button();
            this._SaveButton = new System.Windows.Forms.Button();
            this._btOutputfolder = new System.Windows.Forms.Button();
            this._tbOutputfolder = new System.Windows.Forms.TextBox();
            this._lbOutputFolder = new System.Windows.Forms.Label();
            this._lbduration = new System.Windows.Forms.Label();
            this._tbdurtion = new System.Windows.Forms.TextBox();
            this._tbtpixthreshold = new System.Windows.Forms.TextBox();
            this._lbpixthreshold = new System.Windows.Forms.Label();
            this._lbpicthreshold = new System.Windows.Forms.Label();
            this._tbpicthreshold = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _ffmpegbinLib
            // 
            this._ffmpegbinLib.AutoSize = true;
            this._ffmpegbinLib.Location = new System.Drawing.Point(4, 18);
            this._ffmpegbinLib.Name = "_ffmpegbinLib";
            this._ffmpegbinLib.Size = new System.Drawing.Size(79, 13);
            this._ffmpegbinLib.TabIndex = 0;
            this._ffmpegbinLib.Text = "FFmpeg bin dir:";
            // _tbFFmpegLocation
            // 
            this._tbFFmpegLocation.Location = new System.Drawing.Point(84, 15);
            this._tbFFmpegLocation.Name = "_tbFFmpegLocation";
            this._tbFFmpegLocation.Size = new System.Drawing.Size(188, 20);
            this._tbFFmpegLocation.TabIndex = 1;
            // 
            // _browesButton
            // 
            this._browesButton.Location = new System.Drawing.Point(278, 14);
            this._browesButton.Name = "_browesButton";
            this._browesButton.Size = new System.Drawing.Size(28, 23);
            this._browesButton.TabIndex = 2;
            this._browesButton.Text = "...";
            this._browesButton.UseVisualStyleBackColor = true;
            this._browesButton.Click += new System.EventHandler(this._browesButton_Click);
            // 
            // _SaveButton
            // 
            this._SaveButton.Location = new System.Drawing.Point(231, 175);
            this._SaveButton.Name = "_SaveButton";
            this._SaveButton.Size = new System.Drawing.Size(75, 23);
            this._SaveButton.TabIndex = 3;
            this._SaveButton.Text = "Save";
            this._SaveButton.UseVisualStyleBackColor = true;
            this._SaveButton.Click += new System.EventHandler(this._SaveButton_Click);
            // 
            // _btOutputfolder
            // 
            this._btOutputfolder.Location = new System.Drawing.Point(278, 44);
            this._btOutputfolder.Name = "_btOutputfolder";
            this._btOutputfolder.Size = new System.Drawing.Size(28, 23);
            this._btOutputfolder.TabIndex = 6;
            this._btOutputfolder.Text = "...";
            this._btOutputfolder.UseVisualStyleBackColor = true;
            this._btOutputfolder.Click += new System.EventHandler(this._btOutputfolder_Click);
            // 
            // _tbOutputfolder
            // 
            this._tbOutputfolder.Location = new System.Drawing.Point(84, 45);
            this._tbOutputfolder.Name = "_tbOutputfolder";
            this._tbOutputfolder.Size = new System.Drawing.Size(188, 20);
            this._tbOutputfolder.TabIndex = 5;
            // 
            // _lbOutputFolder
            // 
            this._lbOutputFolder.AutoSize = true;
            this._lbOutputFolder.Location = new System.Drawing.Point(4, 49);
            this._lbOutputFolder.Name = "_lbOutputFolder";
            this._lbOutputFolder.Size = new System.Drawing.Size(74, 13);
            this._lbOutputFolder.TabIndex = 4;
            this._lbOutputFolder.Text = "Output Folder:";
            // 
            // _lbduration
            // 
            this._lbduration.AutoSize = true;
            this._lbduration.Location = new System.Drawing.Point(4, 80);
            this._lbduration.Name = "_lbduration";
            this._lbduration.Size = new System.Drawing.Size(94, 13);
            this._lbduration.TabIndex = 7;
            this._lbduration.Text = "Minimum Duration:";
            // 
            // _tbdurtion
            // 
            this._tbdurtion.Location = new System.Drawing.Point(126, 77);
            this._tbdurtion.Name = "_tbdurtion";
            this._tbdurtion.Size = new System.Drawing.Size(28, 20);
            this._tbdurtion.TabIndex = 8;
            this._tbdurtion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tbtpixthreshold
            // 
            this._tbtpixthreshold.Location = new System.Drawing.Point(126, 139);
            this._tbtpixthreshold.Name = "_tbtpixthreshold";
            this._tbtpixthreshold.Size = new System.Drawing.Size(28, 20);
            this._tbtpixthreshold.TabIndex = 10;
            this._tbtpixthreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _lbpixthreshold
            // 
            this._lbpixthreshold.AutoSize = true;
            this._lbpixthreshold.Location = new System.Drawing.Point(4, 142);
            this._lbpixthreshold.Name = "_lbpixthreshold";
            this._lbpixthreshold.Size = new System.Drawing.Size(118, 13);
            this._lbpixthreshold.TabIndex = 9;
            this._lbpixthreshold.Text = "Minimum Pix Threshold:";
            // 
            // _lbpicthreshold
            // 
            this._lbpicthreshold.AutoSize = true;
            this._lbpicthreshold.Location = new System.Drawing.Point(3, 111);
            this._lbpicthreshold.Name = "_lbpicthreshold";
            this._lbpicthreshold.Size = new System.Drawing.Size(119, 13);
            this._lbpicthreshold.TabIndex = 15;
            this._lbpicthreshold.Text = "Minimum Pic Threshold:";
            // 
            // _tbpicthreshold
            // 
            this._tbpicthreshold.Location = new System.Drawing.Point(126, 109);
            this._tbpicthreshold.Name = "_tbpicthreshold";
            this._tbpicthreshold.Size = new System.Drawing.Size(28, 20);
            this._tbpicthreshold.TabIndex = 14;
            this._tbpicthreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProgramSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 208);
            this.Controls.Add(this._lbpicthreshold);
            this.Controls.Add(this._tbpicthreshold);
            this.Controls.Add(this._tbtpixthreshold);
            this.Controls.Add(this._lbpixthreshold);
            this.Controls.Add(this._tbdurtion);
            this.Controls.Add(this._lbduration);
            this.Controls.Add(this._btOutputfolder);
            this.Controls.Add(this._tbOutputfolder);
            this.Controls.Add(this._lbOutputFolder);
            this.Controls.Add(this._SaveButton);
            this.Controls.Add(this._browesButton);
            this.Controls.Add(this._tbFFmpegLocation);
            this.Controls.Add(this._ffmpegbinLib);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "ProgramSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _ffmpegbinLib;
        private System.Windows.Forms.TextBox _tbFFmpegLocation;
        private System.Windows.Forms.Button _browesButton;
        private System.Windows.Forms.Button _SaveButton;
        private System.Windows.Forms.Button _btOutputfolder;
        private System.Windows.Forms.TextBox _tbOutputfolder;
        private System.Windows.Forms.Label _lbOutputFolder;
        private System.Windows.Forms.Label _lbduration;
        private System.Windows.Forms.TextBox _tbdurtion;
        private System.Windows.Forms.TextBox _tbtpixthreshold;
        private System.Windows.Forms.Label _lbpixthreshold;
        private System.Windows.Forms.Label _lbpicthreshold;
        private System.Windows.Forms.TextBox _tbpicthreshold;
    }
}