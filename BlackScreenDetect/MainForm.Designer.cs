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
            this.components = new System.ComponentModel.Container();
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
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._btAbout = new System.Windows.Forms.ToolStripDropDownButton();
            this._miCheckForUpdates = new System.Windows.Forms.ToolStripMenuItem();
            this._miTechnicalDetails = new System.Windows.Forms.ToolStripMenuItem();
            this._bwProcess = new System.ComponentModel.BackgroundWorker();
            this._bwLoading = new System.ComponentModel.BackgroundWorker();
            this._bwUpdate = new System.ComponentModel.BackgroundWorker();
            this._cmsListBox = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this._tsMain.SuspendLayout();
            this._cmsListBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // _rtbLog
            // 
            this._rtbLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(36)))), ((int)(((byte)(86)))));
            this._rtbLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._rtbLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._rtbLog.ForeColor = System.Drawing.Color.White;
            this._rtbLog.Location = new System.Drawing.Point(0, 185);
            this._rtbLog.Name = "_rtbLog";
            this._rtbLog.Size = new System.Drawing.Size(946, 232);
            this._rtbLog.TabIndex = 1;
            this._rtbLog.Text = "";
            this._rtbLog.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this._rtbLog_LinkClicked);
            this._rtbLog.MouseDown += new System.Windows.Forms.MouseEventHandler(this._rtbLog_MouseDown);
            // 
            // _listBoxWatchedItems
            // 
            this._listBoxWatchedItems.AllowDrop = true;
            this._listBoxWatchedItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this._listBoxWatchedItems.FormattingEnabled = true;
            this._listBoxWatchedItems.Location = new System.Drawing.Point(0, 25);
            this._listBoxWatchedItems.Name = "_listBoxWatchedItems";
            this._listBoxWatchedItems.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this._listBoxWatchedItems.Size = new System.Drawing.Size(946, 160);
            this._listBoxWatchedItems.TabIndex = 0;
            this._listBoxWatchedItems.DragDrop += new System.Windows.Forms.DragEventHandler(this._listBoxWatchedItems_DragDrop);
            this._listBoxWatchedItems.DragEnter += new System.Windows.Forms.DragEventHandler(this._listBoxWatchedItems_DragEnter);
            this._listBoxWatchedItems.KeyDown += new System.Windows.Forms.KeyEventHandler(this._listBoxWatchedItems_KeyDown);
            this._listBoxWatchedItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this._listBoxWatchedItems_MouseDown);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._listBoxWatchedItems);
            this.panel1.Controls.Add(this._rtbLog);
            this.panel1.Controls.Add(this._tsMain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(946, 417);
            this.panel1.TabIndex = 2;
            // 
            // _tsMain
            // 
            this._tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processToolStripButton,
            this._tsBtnRemoveFolder,
            this._tsBtnAddFolder,
            this.toolStripSeparator1,
            this._tsBtnProgramSettings,
            this.toolStripSeparator2,
            this._btAbout});
            this._tsMain.Location = new System.Drawing.Point(0, 0);
            this._tsMain.Name = "_tsMain";
            this._tsMain.Size = new System.Drawing.Size(946, 25);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // _btAbout
            // 
            this._btAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._btAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._miCheckForUpdates,
            this._miTechnicalDetails});
            this._btAbout.Image = ((System.Drawing.Image)(resources.GetObject("_btAbout.Image")));
            this._btAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._btAbout.Name = "_btAbout";
            this._btAbout.Size = new System.Drawing.Size(53, 22);
            this._btAbout.Text = "About";
            // 
            // _miCheckForUpdates
            // 
            this._miCheckForUpdates.Name = "_miCheckForUpdates";
            this._miCheckForUpdates.Size = new System.Drawing.Size(173, 22);
            this._miCheckForUpdates.Text = "Check For Updates";
            this._miCheckForUpdates.Click += new System.EventHandler(this._miCheckForUpdates_Click);
            // 
            // _miTechnicalDetails
            // 
            this._miTechnicalDetails.Name = "_miTechnicalDetails";
            this._miTechnicalDetails.Size = new System.Drawing.Size(173, 22);
            this._miTechnicalDetails.Text = "Technical Details";
            this._miTechnicalDetails.Click += new System.EventHandler(this._miTechnicalDetails_Click);
            // 
            // _bwProcess
            // 
            this._bwProcess.WorkerSupportsCancellation = true;
            this._bwProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bwProcess_DoWork);
            this._bwProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._bwProcess_RunWorkerCompleted);
            // 
            // _bwLoading
            // 
            this._bwLoading.WorkerSupportsCancellation = true;
            this._bwLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bwLoading_DoWork);
            // 
            // _bwUpdate
            // 
            this._bwUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bwUpdate_DoWork);
            // 
            // _cmsListBox
            // 
            this._cmsListBox.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFolderToolStripMenuItem});
            this._cmsListBox.Name = "_cmListBox";
            this._cmsListBox.Size = new System.Drawing.Size(140, 26);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.openFolderToolStripMenuItem.Text = "Open Folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.Open);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 417);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "BlackScreenDetect";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._tsMain.ResumeLayout(false);
            this._tsMain.PerformLayout();
            this._cmsListBox.ResumeLayout(false);
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
        private System.ComponentModel.BackgroundWorker _bwUpdate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton _btAbout;
        private System.Windows.Forms.ToolStripMenuItem _miCheckForUpdates;
        private System.Windows.Forms.ToolStripMenuItem _miTechnicalDetails;
        private System.Windows.Forms.ContextMenuStrip _cmsListBox;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
    }
}

