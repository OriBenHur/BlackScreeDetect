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
            this.components = new System.ComponentModel.Container();
            this._ffmpegbinLib = new System.Windows.Forms.Label();
            this._tbFFmpegLocation = new System.Windows.Forms.TextBox();
            this._btBrowes = new System.Windows.Forms.Button();
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
            this._cbPlaySounds = new System.Windows.Forms.CheckBox();
            this._cbNoMB = new System.Windows.Forms.CheckBox();
            this._lbNoMB = new System.Windows.Forms.Label();
            this._lbPlaySounds = new System.Windows.Forms.Label();
            this._lbDebug = new System.Windows.Forms.Label();
            this._cbDebug = new System.Windows.Forms.CheckBox();
            this._gbDirs = new System.Windows.Forms.GroupBox();
            this._btAutoSearch = new System.Windows.Forms.Button();
            this._gbProgramSettings = new System.Windows.Forms.GroupBox();
            this._gbProcessSetting = new System.Windows.Forms.GroupBox();
            this._gbBehavior = new System.Windows.Forms.GroupBox();
            this._gbLooks = new System.Windows.Forms.GroupBox();
            this._gbConsoleColors = new System.Windows.Forms.GroupBox();
            this._lbSuccessTextExp = new System.Windows.Forms.Label();
            this._lbInfoTextExp = new System.Windows.Forms.Label();
            this._lbErrorTextExp = new System.Windows.Forms.Label();
            this._lbWarningTextExp = new System.Windows.Forms.Label();
            this._lbRegularTextExp = new System.Windows.Forms.Label();
            this._btResetRegularColor = new System.Windows.Forms.Button();
            this._btResetInfoColor = new System.Windows.Forms.Button();
            this._btResetErrorColor = new System.Windows.Forms.Button();
            this._btResetWarningColor = new System.Windows.Forms.Button();
            this._btResetSuccessColor = new System.Windows.Forms.Button();
            this._lbConsoleBackgroundColor = new System.Windows.Forms.Label();
            this._pnInfoColor = new System.Windows.Forms.Panel();
            this._pnWarrningColor = new System.Windows.Forms.Panel();
            this._pnErrorColor = new System.Windows.Forms.Panel();
            this._lbInfo = new System.Windows.Forms.Label();
            this._btBackroundReset = new System.Windows.Forms.Button();
            this._lbError = new System.Windows.Forms.Label();
            this._pnRegularColor = new System.Windows.Forms.Panel();
            this._pnSuccessColor = new System.Windows.Forms.Panel();
            this._pnBackColor = new System.Windows.Forms.Panel();
            this._lbSuccess = new System.Windows.Forms.Label();
            this._lbRegularText = new System.Windows.Forms.Label();
            this._lbWarning = new System.Windows.Forms.Label();
            this._gbFont = new System.Windows.Forms.GroupBox();
            this._lbUnderline = new System.Windows.Forms.Label();
            this._lbItalic = new System.Windows.Forms.Label();
            this._lbBold = new System.Windows.Forms.Label();
            this._cbSize = new System.Windows.Forms.ComboBox();
            this._lbTextFont = new System.Windows.Forms.Label();
            this._cbFonts = new System.Windows.Forms.ComboBox();
            this._btResetAll = new System.Windows.Forms.Button();
            this._ttAuto = new System.Windows.Forms.ToolTip(this.components);
            this._bwAutoSearch = new System.ComponentModel.BackgroundWorker();
            this._btRestColors = new System.Windows.Forms.Button();
            this._lbMoreInfo = new System.Windows.Forms.Label();
            this._gbDirs.SuspendLayout();
            this._gbProgramSettings.SuspendLayout();
            this._gbProcessSetting.SuspendLayout();
            this._gbBehavior.SuspendLayout();
            this._gbLooks.SuspendLayout();
            this._gbConsoleColors.SuspendLayout();
            this._gbFont.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ffmpegbinLib
            // 
            this._ffmpegbinLib.AutoSize = true;
            this._ffmpegbinLib.Location = new System.Drawing.Point(12, 22);
            this._ffmpegbinLib.Name = "_ffmpegbinLib";
            this._ffmpegbinLib.Size = new System.Drawing.Size(79, 13);
            this._ffmpegbinLib.TabIndex = 0;
            this._ffmpegbinLib.Text = "FFmpeg bin dir:";
            // 
            // _tbFFmpegLocation
            // 
            this._tbFFmpegLocation.Location = new System.Drawing.Point(92, 18);
            this._tbFFmpegLocation.Name = "_tbFFmpegLocation";
            this._tbFFmpegLocation.Size = new System.Drawing.Size(188, 20);
            this._tbFFmpegLocation.TabIndex = 1;
            // 
            // _btBrowes
            // 
            this._btBrowes.Location = new System.Drawing.Point(286, 17);
            this._btBrowes.Name = "_btBrowes";
            this._btBrowes.Size = new System.Drawing.Size(28, 23);
            this._btBrowes.TabIndex = 2;
            this._btBrowes.Text = "...";
            this._btBrowes.UseVisualStyleBackColor = true;
            this._btBrowes.Click += new System.EventHandler(this._browesButton_Click);
            // 
            // _SaveButton
            // 
            this._SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._SaveButton.Location = new System.Drawing.Point(461, 422);
            this._SaveButton.Name = "_SaveButton";
            this._SaveButton.Size = new System.Drawing.Size(75, 23);
            this._SaveButton.TabIndex = 9;
            this._SaveButton.Text = "Save";
            this._SaveButton.UseVisualStyleBackColor = true;
            this._SaveButton.Click += new System.EventHandler(this._SaveButton_Click);
            // 
            // _btOutputfolder
            // 
            this._btOutputfolder.Location = new System.Drawing.Point(286, 44);
            this._btOutputfolder.Name = "_btOutputfolder";
            this._btOutputfolder.Size = new System.Drawing.Size(28, 23);
            this._btOutputfolder.TabIndex = 5;
            this._btOutputfolder.Text = "...";
            this._btOutputfolder.UseVisualStyleBackColor = true;
            this._btOutputfolder.Click += new System.EventHandler(this._btOutputfolder_Click);
            // 
            // _tbOutputfolder
            // 
            this._tbOutputfolder.Location = new System.Drawing.Point(92, 45);
            this._tbOutputfolder.Name = "_tbOutputfolder";
            this._tbOutputfolder.Size = new System.Drawing.Size(188, 20);
            this._tbOutputfolder.TabIndex = 4;
            // 
            // _lbOutputFolder
            // 
            this._lbOutputFolder.AutoSize = true;
            this._lbOutputFolder.Location = new System.Drawing.Point(12, 49);
            this._lbOutputFolder.Name = "_lbOutputFolder";
            this._lbOutputFolder.Size = new System.Drawing.Size(74, 13);
            this._lbOutputFolder.TabIndex = 4;
            this._lbOutputFolder.Text = "Output Folder:";
            // 
            // _lbduration
            // 
            this._lbduration.AutoSize = true;
            this._lbduration.Location = new System.Drawing.Point(5, 26);
            this._lbduration.Name = "_lbduration";
            this._lbduration.Size = new System.Drawing.Size(94, 13);
            this._lbduration.TabIndex = 104;
            this._lbduration.Text = "Minimum Duration:";
            // 
            // _tbdurtion
            // 
            this._tbdurtion.Location = new System.Drawing.Point(133, 22);
            this._tbdurtion.Name = "_tbdurtion";
            this._tbdurtion.Size = new System.Drawing.Size(28, 20);
            this._tbdurtion.TabIndex = 6;
            this._tbdurtion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _tbtpixthreshold
            // 
            this._tbtpixthreshold.Location = new System.Drawing.Point(133, 72);
            this._tbtpixthreshold.Name = "_tbtpixthreshold";
            this._tbtpixthreshold.Size = new System.Drawing.Size(28, 20);
            this._tbtpixthreshold.TabIndex = 8;
            this._tbtpixthreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _lbpixthreshold
            // 
            this._lbpixthreshold.AutoSize = true;
            this._lbpixthreshold.Location = new System.Drawing.Point(5, 76);
            this._lbpixthreshold.Name = "_lbpixthreshold";
            this._lbpixthreshold.Size = new System.Drawing.Size(118, 13);
            this._lbpixthreshold.TabIndex = 106;
            this._lbpixthreshold.Text = "Minimum Pix Threshold:";
            // 
            // _lbpicthreshold
            // 
            this._lbpicthreshold.AutoSize = true;
            this._lbpicthreshold.Location = new System.Drawing.Point(5, 51);
            this._lbpicthreshold.Name = "_lbpicthreshold";
            this._lbpicthreshold.Size = new System.Drawing.Size(119, 13);
            this._lbpicthreshold.TabIndex = 105;
            this._lbpicthreshold.Text = "Minimum Pic Threshold:";
            // 
            // _tbpicthreshold
            // 
            this._tbpicthreshold.Location = new System.Drawing.Point(133, 47);
            this._tbpicthreshold.Name = "_tbpicthreshold";
            this._tbpicthreshold.Size = new System.Drawing.Size(28, 20);
            this._tbpicthreshold.TabIndex = 7;
            this._tbpicthreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // _cbPlaySounds
            // 
            this._cbPlaySounds.AutoSize = true;
            this._cbPlaySounds.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._cbPlaySounds.Checked = true;
            this._cbPlaySounds.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbPlaySounds.Location = new System.Drawing.Point(149, 18);
            this._cbPlaySounds.Name = "_cbPlaySounds";
            this._cbPlaySounds.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cbPlaySounds.Size = new System.Drawing.Size(15, 14);
            this._cbPlaySounds.TabIndex = 0;
            this._cbPlaySounds.UseVisualStyleBackColor = true;
            // 
            // _cbNoMB
            // 
            this._cbNoMB.AutoSize = true;
            this._cbNoMB.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._cbNoMB.Location = new System.Drawing.Point(149, 41);
            this._cbNoMB.Name = "_cbNoMB";
            this._cbNoMB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cbNoMB.Size = new System.Drawing.Size(15, 14);
            this._cbNoMB.TabIndex = 0;
            this._cbNoMB.UseVisualStyleBackColor = true;
            // 
            // _lbNoMB
            // 
            this._lbNoMB.AutoSize = true;
            this._lbNoMB.Location = new System.Drawing.Point(6, 42);
            this._lbNoMB.Name = "_lbNoMB";
            this._lbNoMB.Size = new System.Drawing.Size(114, 13);
            this._lbNoMB.TabIndex = 0;
            this._lbNoMB.Text = "Disable Message Boxs";
            this._lbNoMB.Click += new System.EventHandler(this._lbNoMS_Click);
            // 
            // _lbPlaySounds
            // 
            this._lbPlaySounds.AutoSize = true;
            this._lbPlaySounds.Location = new System.Drawing.Point(6, 19);
            this._lbPlaySounds.Name = "_lbPlaySounds";
            this._lbPlaySounds.Size = new System.Drawing.Size(66, 13);
            this._lbPlaySounds.TabIndex = 0;
            this._lbPlaySounds.Text = "Play Sounds";
            this._lbPlaySounds.Click += new System.EventHandler(this._lbPlaySounds_Click);
            // 
            // _lbDebug
            // 
            this._lbDebug.AutoSize = true;
            this._lbDebug.Location = new System.Drawing.Point(6, 65);
            this._lbDebug.Name = "_lbDebug";
            this._lbDebug.Size = new System.Drawing.Size(105, 13);
            this._lbDebug.TabIndex = 0;
            this._lbDebug.Text = "Enable Errors Debug";
            this._lbDebug.Click += new System.EventHandler(this._lbDebug_Click);
            // 
            // _cbDebug
            // 
            this._cbDebug.AutoSize = true;
            this._cbDebug.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._cbDebug.Location = new System.Drawing.Point(149, 64);
            this._cbDebug.Name = "_cbDebug";
            this._cbDebug.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cbDebug.Size = new System.Drawing.Size(15, 14);
            this._cbDebug.TabIndex = 0;
            this._cbDebug.UseVisualStyleBackColor = true;
            // 
            // _gbDirs
            // 
            this._gbDirs.Controls.Add(this._btAutoSearch);
            this._gbDirs.Controls.Add(this._lbOutputFolder);
            this._gbDirs.Controls.Add(this._tbOutputfolder);
            this._gbDirs.Controls.Add(this._btOutputfolder);
            this._gbDirs.Controls.Add(this._ffmpegbinLib);
            this._gbDirs.Controls.Add(this._tbFFmpegLocation);
            this._gbDirs.Controls.Add(this._btBrowes);
            this._gbDirs.Location = new System.Drawing.Point(4, 4);
            this._gbDirs.Name = "_gbDirs";
            this._gbDirs.Size = new System.Drawing.Size(532, 86);
            this._gbDirs.TabIndex = 101;
            this._gbDirs.TabStop = false;
            this._gbDirs.Text = "Dir\'s";
            // 
            // _btAutoSearch
            // 
            this._btAutoSearch.Location = new System.Drawing.Point(320, 17);
            this._btAutoSearch.Name = "_btAutoSearch";
            this._btAutoSearch.Size = new System.Drawing.Size(102, 23);
            this._btAutoSearch.TabIndex = 3;
            this._btAutoSearch.Text = "Try Auto Search";
            this._ttAuto.SetToolTip(this._btAutoSearch, "Searches for the ffmpeg bin dir in the path environment variable ");
            this._btAutoSearch.UseVisualStyleBackColor = true;
            this._btAutoSearch.Click += new System.EventHandler(this._btAutoSearch_Click);
            // 
            // _gbProgramSettings
            // 
            this._gbProgramSettings.Controls.Add(this._gbProcessSetting);
            this._gbProgramSettings.Controls.Add(this._gbBehavior);
            this._gbProgramSettings.Controls.Add(this._gbLooks);
            this._gbProgramSettings.Controls.Add(this._btResetAll);
            this._gbProgramSettings.Location = new System.Drawing.Point(4, 98);
            this._gbProgramSettings.Name = "_gbProgramSettings";
            this._gbProgramSettings.Size = new System.Drawing.Size(532, 295);
            this._gbProgramSettings.TabIndex = 102;
            this._gbProgramSettings.TabStop = false;
            this._gbProgramSettings.Text = "Behavior and Appearance Settings";
            // 
            // _gbProcessSetting
            // 
            this._gbProcessSetting.Controls.Add(this._lbMoreInfo);
            this._gbProcessSetting.Controls.Add(this._lbduration);
            this._gbProcessSetting.Controls.Add(this._tbdurtion);
            this._gbProcessSetting.Controls.Add(this._lbpicthreshold);
            this._gbProcessSetting.Controls.Add(this._tbpicthreshold);
            this._gbProcessSetting.Controls.Add(this._tbtpixthreshold);
            this._gbProcessSetting.Controls.Add(this._lbpixthreshold);
            this._gbProcessSetting.Location = new System.Drawing.Point(7, 123);
            this._gbProcessSetting.Name = "_gbProcessSetting";
            this._gbProcessSetting.Size = new System.Drawing.Size(177, 119);
            this._gbProcessSetting.TabIndex = 103;
            this._gbProcessSetting.TabStop = false;
            this._gbProcessSetting.Text = "Proceess Settings";
            // 
            // _gbBehavior
            // 
            this._gbBehavior.Controls.Add(this._lbPlaySounds);
            this._gbBehavior.Controls.Add(this._cbDebug);
            this._gbBehavior.Controls.Add(this._cbPlaySounds);
            this._gbBehavior.Controls.Add(this._lbDebug);
            this._gbBehavior.Controls.Add(this._lbNoMB);
            this._gbBehavior.Controls.Add(this._cbNoMB);
            this._gbBehavior.Location = new System.Drawing.Point(7, 24);
            this._gbBehavior.Name = "_gbBehavior";
            this._gbBehavior.Size = new System.Drawing.Size(177, 90);
            this._gbBehavior.TabIndex = 11;
            this._gbBehavior.TabStop = false;
            this._gbBehavior.Text = "Behavior";
            // 
            // _gbLooks
            // 
            this._gbLooks.Controls.Add(this._gbConsoleColors);
            this._gbLooks.Controls.Add(this._gbFont);
            this._gbLooks.Location = new System.Drawing.Point(192, 24);
            this._gbLooks.Name = "_gbLooks";
            this._gbLooks.Size = new System.Drawing.Size(334, 262);
            this._gbLooks.TabIndex = 10;
            this._gbLooks.TabStop = false;
            this._gbLooks.Text = "Appearance";
            // 
            // _gbConsoleColors
            // 
            this._gbConsoleColors.Controls.Add(this._btRestColors);
            this._gbConsoleColors.Controls.Add(this._lbSuccessTextExp);
            this._gbConsoleColors.Controls.Add(this._lbInfoTextExp);
            this._gbConsoleColors.Controls.Add(this._lbErrorTextExp);
            this._gbConsoleColors.Controls.Add(this._lbWarningTextExp);
            this._gbConsoleColors.Controls.Add(this._lbRegularTextExp);
            this._gbConsoleColors.Controls.Add(this._btResetRegularColor);
            this._gbConsoleColors.Controls.Add(this._btResetInfoColor);
            this._gbConsoleColors.Controls.Add(this._btResetErrorColor);
            this._gbConsoleColors.Controls.Add(this._btResetWarningColor);
            this._gbConsoleColors.Controls.Add(this._btResetSuccessColor);
            this._gbConsoleColors.Controls.Add(this._lbConsoleBackgroundColor);
            this._gbConsoleColors.Controls.Add(this._pnInfoColor);
            this._gbConsoleColors.Controls.Add(this._pnWarrningColor);
            this._gbConsoleColors.Controls.Add(this._pnErrorColor);
            this._gbConsoleColors.Controls.Add(this._lbInfo);
            this._gbConsoleColors.Controls.Add(this._btBackroundReset);
            this._gbConsoleColors.Controls.Add(this._lbError);
            this._gbConsoleColors.Controls.Add(this._pnRegularColor);
            this._gbConsoleColors.Controls.Add(this._pnSuccessColor);
            this._gbConsoleColors.Controls.Add(this._pnBackColor);
            this._gbConsoleColors.Controls.Add(this._lbSuccess);
            this._gbConsoleColors.Controls.Add(this._lbRegularText);
            this._gbConsoleColors.Controls.Add(this._lbWarning);
            this._gbConsoleColors.Location = new System.Drawing.Point(9, 82);
            this._gbConsoleColors.Name = "_gbConsoleColors";
            this._gbConsoleColors.Size = new System.Drawing.Size(317, 168);
            this._gbConsoleColors.TabIndex = 17;
            this._gbConsoleColors.TabStop = false;
            this._gbConsoleColors.Text = "Console Colors";
            // 
            // _lbSuccessTextExp
            // 
            this._lbSuccessTextExp.AutoSize = true;
            this._lbSuccessTextExp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lbSuccessTextExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._lbSuccessTextExp.Location = new System.Drawing.Point(109, 64);
            this._lbSuccessTextExp.Name = "_lbSuccessTextExp";
            this._lbSuccessTextExp.Size = new System.Drawing.Size(68, 20);
            this._lbSuccessTextExp.TabIndex = 23;
            this._lbSuccessTextExp.Text = "Success";
            // 
            // _lbInfoTextExp
            // 
            this._lbInfoTextExp.AutoSize = true;
            this._lbInfoTextExp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lbInfoTextExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._lbInfoTextExp.Location = new System.Drawing.Point(109, 139);
            this._lbInfoTextExp.Name = "_lbInfoTextExp";
            this._lbInfoTextExp.Size = new System.Drawing.Size(34, 20);
            this._lbInfoTextExp.TabIndex = 22;
            this._lbInfoTextExp.Text = "Info";
            // 
            // _lbErrorTextExp
            // 
            this._lbErrorTextExp.AutoSize = true;
            this._lbErrorTextExp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lbErrorTextExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._lbErrorTextExp.Location = new System.Drawing.Point(109, 114);
            this._lbErrorTextExp.Name = "_lbErrorTextExp";
            this._lbErrorTextExp.Size = new System.Drawing.Size(44, 20);
            this._lbErrorTextExp.TabIndex = 21;
            this._lbErrorTextExp.Text = "Error";
            // 
            // _lbWarningTextExp
            // 
            this._lbWarningTextExp.AutoSize = true;
            this._lbWarningTextExp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lbWarningTextExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._lbWarningTextExp.Location = new System.Drawing.Point(109, 89);
            this._lbWarningTextExp.Name = "_lbWarningTextExp";
            this._lbWarningTextExp.Size = new System.Drawing.Size(73, 20);
            this._lbWarningTextExp.TabIndex = 20;
            this._lbWarningTextExp.Text = "Warninng";
            this._lbWarningTextExp.SizeChanged += new System.EventHandler(this._lbWarningTextExp_SizeChanged);
            // 
            // _lbRegularTextExp
            // 
            this._lbRegularTextExp.AutoSize = true;
            this._lbRegularTextExp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lbRegularTextExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._lbRegularTextExp.Location = new System.Drawing.Point(109, 39);
            this._lbRegularTextExp.Name = "_lbRegularTextExp";
            this._lbRegularTextExp.Size = new System.Drawing.Size(61, 20);
            this._lbRegularTextExp.TabIndex = 19;
            this._lbRegularTextExp.Text = "Regular";
            // 
            // _btResetRegularColor
            // 
            this._btResetRegularColor.BackgroundImage = global::BlackScreenDetect.Properties.Resources.Click;
            this._btResetRegularColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btResetRegularColor.Location = new System.Drawing.Point(186, 36);
            this._btResetRegularColor.Name = "_btResetRegularColor";
            this._btResetRegularColor.Size = new System.Drawing.Size(25, 25);
            this._btResetRegularColor.TabIndex = 18;
            this._btResetRegularColor.UseVisualStyleBackColor = true;
            this._btResetRegularColor.Click += new System.EventHandler(this._btResetRegularColor_Click);
            // 
            // _btResetInfoColor
            // 
            this._btResetInfoColor.BackgroundImage = global::BlackScreenDetect.Properties.Resources.Click;
            this._btResetInfoColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btResetInfoColor.Location = new System.Drawing.Point(186, 136);
            this._btResetInfoColor.Name = "_btResetInfoColor";
            this._btResetInfoColor.Size = new System.Drawing.Size(25, 25);
            this._btResetInfoColor.TabIndex = 17;
            this._btResetInfoColor.UseVisualStyleBackColor = true;
            this._btResetInfoColor.Click += new System.EventHandler(this._btResetInfoColor_Click);
            // 
            // _btResetErrorColor
            // 
            this._btResetErrorColor.BackgroundImage = global::BlackScreenDetect.Properties.Resources.Click;
            this._btResetErrorColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btResetErrorColor.Location = new System.Drawing.Point(186, 111);
            this._btResetErrorColor.Name = "_btResetErrorColor";
            this._btResetErrorColor.Size = new System.Drawing.Size(25, 25);
            this._btResetErrorColor.TabIndex = 16;
            this._btResetErrorColor.UseVisualStyleBackColor = true;
            this._btResetErrorColor.Click += new System.EventHandler(this._btResetErrorColor_Click);
            // 
            // _btResetWarningColor
            // 
            this._btResetWarningColor.BackgroundImage = global::BlackScreenDetect.Properties.Resources.Click;
            this._btResetWarningColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btResetWarningColor.Location = new System.Drawing.Point(186, 86);
            this._btResetWarningColor.Name = "_btResetWarningColor";
            this._btResetWarningColor.Size = new System.Drawing.Size(25, 25);
            this._btResetWarningColor.TabIndex = 15;
            this._btResetWarningColor.UseVisualStyleBackColor = true;
            this._btResetWarningColor.LocationChanged += new System.EventHandler(this._btResetWarningColor_LocationChanged);
            this._btResetWarningColor.Click += new System.EventHandler(this._btResetWarningColor_Click);
            // 
            // _btResetSuccessColor
            // 
            this._btResetSuccessColor.BackgroundImage = global::BlackScreenDetect.Properties.Resources.Click;
            this._btResetSuccessColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btResetSuccessColor.Location = new System.Drawing.Point(186, 61);
            this._btResetSuccessColor.Name = "_btResetSuccessColor";
            this._btResetSuccessColor.Size = new System.Drawing.Size(25, 25);
            this._btResetSuccessColor.TabIndex = 14;
            this._btResetSuccessColor.UseVisualStyleBackColor = true;
            this._btResetSuccessColor.Click += new System.EventHandler(this._btResetSuccessColor_Click);
            // 
            // _lbConsoleBackgroundColor
            // 
            this._lbConsoleBackgroundColor.AutoSize = true;
            this._lbConsoleBackgroundColor.Location = new System.Drawing.Point(6, 16);
            this._lbConsoleBackgroundColor.Name = "_lbConsoleBackgroundColor";
            this._lbConsoleBackgroundColor.Size = new System.Drawing.Size(68, 13);
            this._lbConsoleBackgroundColor.TabIndex = 4;
            this._lbConsoleBackgroundColor.Text = "Background:";
            // 
            // _pnInfoColor
            // 
            this._pnInfoColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnInfoColor.Location = new System.Drawing.Point(84, 139);
            this._pnInfoColor.Name = "_pnInfoColor";
            this._pnInfoColor.Size = new System.Drawing.Size(19, 19);
            this._pnInfoColor.TabIndex = 7;
            this._pnInfoColor.Click += new System.EventHandler(this._pnInfoColor_Click);
            // 
            // _pnWarrningColor
            // 
            this._pnWarrningColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnWarrningColor.Location = new System.Drawing.Point(84, 89);
            this._pnWarrningColor.Name = "_pnWarrningColor";
            this._pnWarrningColor.Size = new System.Drawing.Size(19, 19);
            this._pnWarrningColor.TabIndex = 9;
            this._pnWarrningColor.Click += new System.EventHandler(this._pnWarrningColor_Click);
            // 
            // _pnErrorColor
            // 
            this._pnErrorColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnErrorColor.Location = new System.Drawing.Point(84, 114);
            this._pnErrorColor.Name = "_pnErrorColor";
            this._pnErrorColor.Size = new System.Drawing.Size(19, 19);
            this._pnErrorColor.TabIndex = 8;
            this._pnErrorColor.Click += new System.EventHandler(this._pnErrorColor_Click);
            // 
            // _lbInfo
            // 
            this._lbInfo.AutoSize = true;
            this._lbInfo.Location = new System.Drawing.Point(6, 142);
            this._lbInfo.Name = "_lbInfo";
            this._lbInfo.Size = new System.Drawing.Size(52, 13);
            this._lbInfo.TabIndex = 12;
            this._lbInfo.Text = "Info Text:";
            // 
            // _btBackroundReset
            // 
            this._btBackroundReset.BackgroundImage = global::BlackScreenDetect.Properties.Resources.Click;
            this._btBackroundReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this._btBackroundReset.Location = new System.Drawing.Point(186, 10);
            this._btBackroundReset.Name = "_btBackroundReset";
            this._btBackroundReset.Size = new System.Drawing.Size(25, 25);
            this._btBackroundReset.TabIndex = 3;
            this._btBackroundReset.UseVisualStyleBackColor = true;
            this._btBackroundReset.Click += new System.EventHandler(this._btBackroundReset_Click);
            // 
            // _lbError
            // 
            this._lbError.AutoSize = true;
            this._lbError.Location = new System.Drawing.Point(6, 117);
            this._lbError.Name = "_lbError";
            this._lbError.Size = new System.Drawing.Size(56, 13);
            this._lbError.TabIndex = 11;
            this._lbError.Text = "Error Text:";
            // 
            // _pnRegularColor
            // 
            this._pnRegularColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnRegularColor.Location = new System.Drawing.Point(84, 39);
            this._pnRegularColor.Name = "_pnRegularColor";
            this._pnRegularColor.Size = new System.Drawing.Size(19, 19);
            this._pnRegularColor.TabIndex = 6;
            this._pnRegularColor.Click += new System.EventHandler(this._pnRegularColor_Click);
            // 
            // _pnSuccessColor
            // 
            this._pnSuccessColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnSuccessColor.Location = new System.Drawing.Point(84, 64);
            this._pnSuccessColor.Name = "_pnSuccessColor";
            this._pnSuccessColor.Size = new System.Drawing.Size(19, 19);
            this._pnSuccessColor.TabIndex = 13;
            this._pnSuccessColor.Click += new System.EventHandler(this._pnSuccessColor_Click);
            // 
            // _pnBackColor
            // 
            this._pnBackColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnBackColor.Location = new System.Drawing.Point(84, 13);
            this._pnBackColor.Name = "_pnBackColor";
            this._pnBackColor.Size = new System.Drawing.Size(19, 19);
            this._pnBackColor.TabIndex = 5;
            this._pnBackColor.Click += new System.EventHandler(this._pnBackColor_Click);
            // 
            // _lbSuccess
            // 
            this._lbSuccess.AutoSize = true;
            this._lbSuccess.Location = new System.Drawing.Point(6, 67);
            this._lbSuccess.Name = "_lbSuccess";
            this._lbSuccess.Size = new System.Drawing.Size(75, 13);
            this._lbSuccess.TabIndex = 10;
            this._lbSuccess.Text = "Success Text:";
            // 
            // _lbRegularText
            // 
            this._lbRegularText.AutoSize = true;
            this._lbRegularText.Location = new System.Drawing.Point(6, 42);
            this._lbRegularText.Name = "_lbRegularText";
            this._lbRegularText.Size = new System.Drawing.Size(71, 13);
            this._lbRegularText.TabIndex = 0;
            this._lbRegularText.Text = "Regular Text:";
            // 
            // _lbWarning
            // 
            this._lbWarning.AutoSize = true;
            this._lbWarning.Location = new System.Drawing.Point(6, 92);
            this._lbWarning.Name = "_lbWarning";
            this._lbWarning.Size = new System.Drawing.Size(74, 13);
            this._lbWarning.TabIndex = 9;
            this._lbWarning.Text = "Warning Text:";
            // 
            // _gbFont
            // 
            this._gbFont.Controls.Add(this._lbUnderline);
            this._gbFont.Controls.Add(this._lbItalic);
            this._gbFont.Controls.Add(this._lbBold);
            this._gbFont.Controls.Add(this._cbSize);
            this._gbFont.Controls.Add(this._lbTextFont);
            this._gbFont.Controls.Add(this._cbFonts);
            this._gbFont.Location = new System.Drawing.Point(9, 19);
            this._gbFont.Name = "_gbFont";
            this._gbFont.Size = new System.Drawing.Size(317, 55);
            this._gbFont.TabIndex = 16;
            this._gbFont.TabStop = false;
            this._gbFont.Text = "Console Font";
            // 
            // _lbUnderline
            // 
            this._lbUnderline.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lbUnderline.Font = new System.Drawing.Font("Times New Roman", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbUnderline.Location = new System.Drawing.Point(293, 21);
            this._lbUnderline.Name = "_lbUnderline";
            this._lbUnderline.Size = new System.Drawing.Size(21, 21);
            this._lbUnderline.TabIndex = 18;
            this._lbUnderline.Text = "U";
            this._lbUnderline.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lbUnderline.Click += new System.EventHandler(this._lbUnderline_Click);
            // 
            // _lbItalic
            // 
            this._lbItalic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lbItalic.Font = new System.Drawing.Font("Times New Roman", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lbItalic.Location = new System.Drawing.Point(268, 21);
            this._lbItalic.Name = "_lbItalic";
            this._lbItalic.Size = new System.Drawing.Size(21, 21);
            this._lbItalic.TabIndex = 17;
            this._lbItalic.Text = "I";
            this._lbItalic.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lbItalic.Click += new System.EventHandler(this._lbItalic_Click);
            // 
            // _lbBold
            // 
            this._lbBold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._lbBold.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this._lbBold.Location = new System.Drawing.Point(243, 21);
            this._lbBold.Name = "_lbBold";
            this._lbBold.Size = new System.Drawing.Size(21, 21);
            this._lbBold.TabIndex = 16;
            this._lbBold.Text = "B";
            this._lbBold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lbBold.Click += new System.EventHandler(this._lbBold_Click);
            // 
            // _cbSize
            // 
            this._cbSize.FormattingEnabled = true;
            this._cbSize.Location = new System.Drawing.Point(199, 21);
            this._cbSize.Name = "_cbSize";
            this._cbSize.Size = new System.Drawing.Size(40, 21);
            this._cbSize.TabIndex = 15;
            // 
            // _lbTextFont
            // 
            this._lbTextFont.AutoSize = true;
            this._lbTextFont.Location = new System.Drawing.Point(6, 25);
            this._lbTextFont.Name = "_lbTextFont";
            this._lbTextFont.Size = new System.Drawing.Size(31, 13);
            this._lbTextFont.TabIndex = 6;
            this._lbTextFont.Text = "Font:";
            // 
            // _cbFonts
            // 
            this._cbFonts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this._cbFonts.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._cbFonts.FormattingEnabled = true;
            this._cbFonts.Location = new System.Drawing.Point(43, 21);
            this._cbFonts.Name = "_cbFonts";
            this._cbFonts.Size = new System.Drawing.Size(152, 21);
            this._cbFonts.TabIndex = 14;
            this._cbFonts.SelectedValueChanged += new System.EventHandler(this._cbFonts_SelectedValueChanged);
            // 
            // _btResetAll
            // 
            this._btResetAll.Location = new System.Drawing.Point(7, 263);
            this._btResetAll.Name = "_btResetAll";
            this._btResetAll.Size = new System.Drawing.Size(75, 23);
            this._btResetAll.TabIndex = 9;
            this._btResetAll.Text = "Reset All";
            this._btResetAll.UseVisualStyleBackColor = true;
            this._btResetAll.Click += new System.EventHandler(this._btResetAll_Click);
            // 
            // _ttAuto
            // 
            this._ttAuto.AutoPopDelay = 10000;
            this._ttAuto.InitialDelay = 500;
            this._ttAuto.ReshowDelay = 100;
            // 
            // _bwAutoSearch
            // 
            this._bwAutoSearch.WorkerSupportsCancellation = true;
            this._bwAutoSearch.DoWork += new System.ComponentModel.DoWorkEventHandler(this._bwAutoSearch_DoWork);
            this._bwAutoSearch.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this._bwAutoSearch_RunWorkerCompleted);
            // 
            // _btRestColors
            // 
            this._btRestColors.Location = new System.Drawing.Point(240, 142);
            this._btRestColors.Name = "_btRestColors";
            this._btRestColors.Size = new System.Drawing.Size(75, 23);
            this._btRestColors.TabIndex = 24;
            this._btRestColors.Text = "Reset Colors";
            this._btRestColors.UseVisualStyleBackColor = true;
            this._btRestColors.Click += new System.EventHandler(this._btRestColors_Click);
            // 
            // _lbMoreInfo
            // 
            this._lbMoreInfo.Cursor = System.Windows.Forms.Cursors.Help;
            this._lbMoreInfo.Location = new System.Drawing.Point(165, 103);
            this._lbMoreInfo.Name = "_lbMoreInfo";
            this._lbMoreInfo.Size = new System.Drawing.Size(10, 13);
            this._lbMoreInfo.TabIndex = 107;
            this._lbMoreInfo.Text = "?";
            this._lbMoreInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._lbMoreInfo.Click += new System.EventHandler(this._lbMoreInfo_Click);
            this._lbMoreInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this._lbMoreInfo_MouseDown);
            this._lbMoreInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this._lbMoreInfo_MouseUp);
            // 
            // ProgramSettings
            // 
            this.AcceptButton = this._SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(554, 451);
            this.Controls.Add(this._gbProgramSettings);
            this.Controls.Add(this._gbDirs);
            this.Controls.Add(this._SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgramSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Program Settings";
            this._gbDirs.ResumeLayout(false);
            this._gbDirs.PerformLayout();
            this._gbProgramSettings.ResumeLayout(false);
            this._gbProcessSetting.ResumeLayout(false);
            this._gbProcessSetting.PerformLayout();
            this._gbBehavior.ResumeLayout(false);
            this._gbBehavior.PerformLayout();
            this._gbLooks.ResumeLayout(false);
            this._gbConsoleColors.ResumeLayout(false);
            this._gbConsoleColors.PerformLayout();
            this._gbFont.ResumeLayout(false);
            this._gbFont.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label _ffmpegbinLib;
        private System.Windows.Forms.TextBox _tbFFmpegLocation;
        private System.Windows.Forms.Button _btBrowes;
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
        private System.Windows.Forms.CheckBox _cbPlaySounds;
        private System.Windows.Forms.CheckBox _cbNoMB;
        private System.Windows.Forms.Label _lbNoMB;
        private System.Windows.Forms.Label _lbPlaySounds;
        private System.Windows.Forms.Label _lbDebug;
        private System.Windows.Forms.CheckBox _cbDebug;
        private System.Windows.Forms.GroupBox _gbDirs;
        private System.Windows.Forms.GroupBox _gbProgramSettings;
        private System.Windows.Forms.GroupBox _gbProcessSetting;
        private System.Windows.Forms.Button _btAutoSearch;
        private System.Windows.Forms.ToolTip _ttAuto;
        private System.Windows.Forms.Button _btBackroundReset;
        private System.Windows.Forms.Label _lbConsoleBackgroundColor;
        private System.Windows.Forms.Panel _pnBackColor;
        private System.ComponentModel.BackgroundWorker _bwAutoSearch;
        private System.Windows.Forms.Label _lbTextFont;
        private System.Windows.Forms.Panel _pnRegularColor;
        private System.Windows.Forms.Button _btResetAll;
        private System.Windows.Forms.GroupBox _gbBehavior;
        private System.Windows.Forms.GroupBox _gbLooks;
        private System.Windows.Forms.Label _lbInfo;
        private System.Windows.Forms.Label _lbError;
        private System.Windows.Forms.Label _lbSuccess;
        private System.Windows.Forms.Label _lbWarning;
        private System.Windows.Forms.Label _lbRegularText;
        private System.Windows.Forms.Panel _pnWarrningColor;
        private System.Windows.Forms.Panel _pnSuccessColor;
        private System.Windows.Forms.Panel _pnErrorColor;
        private System.Windows.Forms.Panel _pnInfoColor;
        private System.Windows.Forms.ComboBox _cbFonts;
        private System.Windows.Forms.GroupBox _gbConsoleColors;
        private System.Windows.Forms.GroupBox _gbFont;
        private System.Windows.Forms.ComboBox _cbSize;
        private System.Windows.Forms.Label _lbItalic;
        private System.Windows.Forms.Label _lbBold;
        private System.Windows.Forms.Label _lbUnderline;
        private System.Windows.Forms.Button _btResetRegularColor;
        private System.Windows.Forms.Button _btResetInfoColor;
        private System.Windows.Forms.Button _btResetErrorColor;
        private System.Windows.Forms.Button _btResetWarningColor;
        private System.Windows.Forms.Button _btResetSuccessColor;
        private System.Windows.Forms.Label _lbSuccessTextExp;
        private System.Windows.Forms.Label _lbInfoTextExp;
        private System.Windows.Forms.Label _lbErrorTextExp;
        private System.Windows.Forms.Label _lbWarningTextExp;
        private System.Windows.Forms.Label _lbRegularTextExp;
        private System.Windows.Forms.Button _btRestColors;
        private System.Windows.Forms.Label _lbMoreInfo;
    }
}