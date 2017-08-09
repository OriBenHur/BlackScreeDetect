namespace BlackScreenDetect
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._rtbLog = new System.Windows.Forms.RichTextBox();
            this._listBoxWatchedItems = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this._tsMain = new System.Windows.Forms.ToolStrip();
            this.processToolStripButton = new System.Windows.Forms.ToolStripButton();
            this._tsBtnRemoveFolder = new System.Windows.Forms.ToolStripButton();
            this._tsBtnAddFolder = new System.Windows.Forms.ToolStripDropDownButton();
            this.folderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._tsBtnProgramSettings = new System.Windows.Forms.ToolStripButton();
            this._bwProcess = new System.ComponentModel.BackgroundWorker();
            this._bwLoading = new System.ComponentModel.BackgroundWorker();
            this.panel1.SuspendLayout();
            this._tsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rtbLog
            // 
            this._rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this._rtbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._rtbLog.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._rtbLog.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._rtbLog.Location = new System.Drawing.Point(0, 199);
            this._rtbLog.Name = "_rtbLog";
            this._rtbLog.Size = new System.Drawing.Size(784, 218);
            this._rtbLog.TabIndex = 1;
            this._rtbLog.Text = "";
            // 
            // _listBoxWatchedItems
            // 
            this._listBoxWatchedItems.AllowDrop = true;
            this._listBoxWatchedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listBoxWatchedItems.FormattingEnabled = true;
            this._listBoxWatchedItems.Location = new System.Drawing.Point(0, 25);
            this._listBoxWatchedItems.Name = "_listBoxWatchedItems";
            this._listBoxWatchedItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._listBoxWatchedItems.Size = new System.Drawing.Size(784, 174);
            this._listBoxWatchedItems.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._listBoxWatchedItems);
            this.panel1.Controls.Add(this._rtbLog);
            this.panel1.Controls.Add(this._tsMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 417);
            this.panel1.TabIndex = 2;
            // 
            // _tsMain
            // 
            this._tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processToolStripButton,
            this._tsBtnRemoveFolder,
            this._tsBtnAddFolder,
            this.toolStripSeparator1,
            this._tsBtnProgramSettings});
            this._tsMain.Location = new System.Drawing.Point(0, 0);
            this._tsMain.Name = "_tsMain";
            this._tsMain.Size = new System.Drawing.Size(784, 25);
            this._tsMain.TabIndex = 2;
            this._tsMain.Text = "toolStrip1";
            // 
            // processToolStripButton
            // 
            this.processToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.processToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("processToolStripButton.Image")));
            this.processToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.processToolStripButton.Name = "processToolStripButton";
            this.processToolStripButton.Size = new System.Drawing.Size(51, 22);
            this.processToolStripButton.Text = "Process";
            this.processToolStripButton.Click += new System.EventHandler(this.processToolStripButton_Click);
            // 
            // _tsBtnRemoveFolder
            // 
            this._tsBtnRemoveFolder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._tsBtnRemoveFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsBtnRemoveFolder.Image = global::BlackScreenDetect.Properties.Resources.tsBtnRemoveFolder_Image;
            this._tsBtnRemoveFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsBtnRemoveFolder.Name = "_tsBtnRemoveFolder";
            this._tsBtnRemoveFolder.Size = new System.Drawing.Size(23, 22);
            this._tsBtnRemoveFolder.Text = "Remove";
            this._tsBtnRemoveFolder.Click += new System.EventHandler(this._tsBtnRemoveFolder_Click);
            // 
            // _tsBtnAddFolder
            // 
            this._tsBtnAddFolder.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._tsBtnAddFolder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._tsBtnAddFolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.folderToolStripMenuItem,
            this.fileToolStripMenuItem});
            this._tsBtnAddFolder.Image = global::BlackScreenDetect.Properties.Resources.tsBtnAddFolder_Image;
            this._tsBtnAddFolder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsBtnAddFolder.Name = "_tsBtnAddFolder";
            this._tsBtnAddFolder.Size = new System.Drawing.Size(29, 22);
            this._tsBtnAddFolder.Text = "Add";
            // 
            // folderToolStripMenuItem
            // 
            this.folderToolStripMenuItem.Name = "folderToolStripMenuItem";
            this.folderToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.folderToolStripMenuItem.Text = "Folder";
            this.folderToolStripMenuItem.Click += new System.EventHandler(this.folderToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.fileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // _tsBtnProgramSettings
            // 
            this._tsBtnProgramSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._tsBtnProgramSettings.Image = ((System.Drawing.Image)(resources.GetObject("_tsBtnProgramSettings.Image")));
            this._tsBtnProgramSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._tsBtnProgramSettings.Name = "_tsBtnProgramSettings";
            this._tsBtnProgramSettings.Size = new System.Drawing.Size(133, 22);
            this._tsBtnProgramSettings.Text = "Open program settings";
            this._tsBtnProgramSettings.Click += new System.EventHandler(this._tsBtnProgramSettings_Click);
            // 
            // _bwProcess
            // 
            this._bwProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bwProcess_DoWork);
            this._bwProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._bwProcess_RunWorkerCompleted);
            // 
            // _bwLoading
            // 
            this._bwLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bwLoading_DoWork);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 417);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "BlackScreenDetect";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._tsMain.ResumeLayout(false);
            this._tsMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox _rtbLog;
        private System.Windows.Forms.ListBox _listBoxWatchedItems;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip _tsMain;
        private System.Windows.Forms.ToolStripButton processToolStripButton;
        private System.Windows.Forms.ToolStripButton _tsBtnRemoveFolder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _tsBtnProgramSettings;
        private System.Windows.Forms.ToolStripDropDownButton _tsBtnAddFolder;
        private System.Windows.Forms.ToolStripMenuItem folderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker _bwProcess;
        private System.ComponentModel.BackgroundWorker _bwLoading;
    }
}

