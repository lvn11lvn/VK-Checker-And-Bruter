namespace VK_Checker_By_MENHERA
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            printPreviewDialog1 = new PrintPreviewDialog();
            buttonCombinations = new Button();
            labelCombinations = new Label();
            textBoxCombinations = new TextBox();
            buttonResetCombinations = new Button();
            buttonResetProxies = new Button();
            textBoxProxies = new TextBox();
            labelProxies = new Label();
            buttonProxies = new Button();
            comboBoxProxiesType = new ComboBox();
            labelProxiesType = new Label();
            labelThreads = new Label();
            numericUpDownThreadsCount = new NumericUpDown();
            buttonSwitch = new Button();
            labelThreadsCount = new Label();
            numericUpDownDebugRequestTimeout = new NumericUpDown();
            labelAdditionalFunctions = new Label();
            labelDebug = new Label();
            checkBoxDebugOutputting = new CheckBox();
            labelDebugRequestTimeout = new Label();
            checkBoxDebugNoUseProxies = new CheckBox();
            labelSettings = new Label();
            textBoxSettingsSeparationSign = new TextBox();
            labelSettingsSeparationSign = new Label();
            labelSettingsPathValid = new Label();
            labelSettingsPathInvalid = new Label();
            labelSettingsPathFrozen = new Label();
            labelSettingsPathTwoFactor = new Label();
            textBoxSettingsPathValid = new TextBox();
            textBoxSettingsPathInvalid = new TextBox();
            textBoxSettingsPathFrozen = new TextBox();
            textBoxSettingsPathTwoFactor = new TextBox();
            richTextBoxLogger = new RichTextBox();
            checkProxyPassword = new CheckBox();
            textBoxUserAgent = new TextBox();
            labelUseragent = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreadsCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDebugRequestTimeout).BeginInit();
            SuspendLayout();
            // 
            // printPreviewDialog1
            // 
            printPreviewDialog1.AutoScrollMargin = new Size(0, 0);
            printPreviewDialog1.AutoScrollMinSize = new Size(0, 0);
            printPreviewDialog1.ClientSize = new Size(400, 300);
            printPreviewDialog1.Enabled = true;
            printPreviewDialog1.Icon = (Icon)resources.GetObject("printPreviewDialog1.Icon");
            printPreviewDialog1.Name = "printPreviewDialog1";
            printPreviewDialog1.Visible = false;
            // 
            // buttonCombinations
            // 
            buttonCombinations.AllowDrop = true;
            buttonCombinations.Location = new Point(213, 45);
            buttonCombinations.Margin = new Padding(3, 4, 3, 4);
            buttonCombinations.Name = "buttonCombinations";
            buttonCombinations.Size = new Size(219, 57);
            buttonCombinations.TabIndex = 0;
            buttonCombinations.Text = "Click or Drag";
            buttonCombinations.UseVisualStyleBackColor = true;
            buttonCombinations.Click += ButtonCombinations_Click;
            buttonCombinations.DragDrop += ButtonCombinations_DragDrop;
            buttonCombinations.DragEnter += ButtonCombinations_DragEnter;
            buttonCombinations.DragLeave += ButtonCombinations_DragLeave;
            // 
            // labelCombinations
            // 
            labelCombinations.BorderStyle = BorderStyle.FixedSingle;
            labelCombinations.Location = new Point(213, 12);
            labelCombinations.Name = "labelCombinations";
            labelCombinations.Size = new Size(399, 30);
            labelCombinations.TabIndex = 1;
            labelCombinations.Text = "Combinations";
            labelCombinations.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxCombinations
            // 
            textBoxCombinations.Location = new Point(438, 46);
            textBoxCombinations.Margin = new Padding(3, 4, 3, 4);
            textBoxCombinations.Multiline = true;
            textBoxCombinations.Name = "textBoxCombinations";
            textBoxCombinations.ReadOnly = true;
            textBoxCombinations.ScrollBars = ScrollBars.Both;
            textBoxCombinations.Size = new Size(174, 95);
            textBoxCombinations.TabIndex = 2;
            textBoxCombinations.TextChanged += TextBoxCombinations_TextChanged;
            // 
            // buttonResetCombinations
            // 
            buttonResetCombinations.Location = new Point(213, 108);
            buttonResetCombinations.Margin = new Padding(3, 4, 3, 4);
            buttonResetCombinations.Name = "buttonResetCombinations";
            buttonResetCombinations.Size = new Size(219, 31);
            buttonResetCombinations.TabIndex = 3;
            buttonResetCombinations.Text = "reset";
            buttonResetCombinations.UseVisualStyleBackColor = true;
            buttonResetCombinations.Click += ButtonResetCombinations_Click;
            // 
            // buttonResetProxies
            // 
            buttonResetProxies.Location = new Point(623, 108);
            buttonResetProxies.Margin = new Padding(3, 4, 3, 4);
            buttonResetProxies.Name = "buttonResetProxies";
            buttonResetProxies.Size = new Size(175, 31);
            buttonResetProxies.TabIndex = 7;
            buttonResetProxies.Text = "reset";
            buttonResetProxies.UseVisualStyleBackColor = true;
            buttonResetProxies.Click += ButtonResetProxies_Click;
            // 
            // textBoxProxies
            // 
            textBoxProxies.Location = new Point(805, 44);
            textBoxProxies.Margin = new Padding(3, 4, 3, 4);
            textBoxProxies.Multiline = true;
            textBoxProxies.Name = "textBoxProxies";
            textBoxProxies.ReadOnly = true;
            textBoxProxies.ScrollBars = ScrollBars.Both;
            textBoxProxies.Size = new Size(174, 95);
            textBoxProxies.TabIndex = 6;
            textBoxProxies.TextChanged += TextBoxCombinations_TextChanged;
            // 
            // labelProxies
            // 
            labelProxies.BorderStyle = BorderStyle.FixedSingle;
            labelProxies.Location = new Point(623, 12);
            labelProxies.Name = "labelProxies";
            labelProxies.Size = new Size(552, 30);
            labelProxies.TabIndex = 5;
            labelProxies.Text = "Proxies";
            labelProxies.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonProxies
            // 
            buttonProxies.AllowDrop = true;
            buttonProxies.Location = new Point(623, 47);
            buttonProxies.Margin = new Padding(3, 4, 3, 4);
            buttonProxies.Name = "buttonProxies";
            buttonProxies.Size = new Size(175, 57);
            buttonProxies.TabIndex = 4;
            buttonProxies.Text = "Click or Drag";
            buttonProxies.UseVisualStyleBackColor = true;
            buttonProxies.Click += ButtonProxies_Click;
            buttonProxies.DragDrop += ButtonProxies_DragDrop;
            buttonProxies.DragEnter += ButtonProxies_DragEnter;
            buttonProxies.DragLeave += ButtonProxies_DragLeave;
            // 
            // comboBoxProxiesType
            // 
            comboBoxProxiesType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProxiesType.FormattingEnabled = true;
            comboBoxProxiesType.Items.AddRange(new object[] { "HTTP", "SOCKS 4", "SOCKS 5" });
            comboBoxProxiesType.Location = new Point(987, 72);
            comboBoxProxiesType.Margin = new Padding(3, 4, 3, 4);
            comboBoxProxiesType.Name = "comboBoxProxiesType";
            comboBoxProxiesType.Size = new Size(188, 28);
            comboBoxProxiesType.TabIndex = 8;
            // 
            // labelProxiesType
            // 
            labelProxiesType.Location = new Point(986, 44);
            labelProxiesType.Name = "labelProxiesType";
            labelProxiesType.Size = new Size(189, 20);
            labelProxiesType.TabIndex = 9;
            labelProxiesType.Text = "Type";
            labelProxiesType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelThreads
            // 
            labelThreads.BorderStyle = BorderStyle.FixedSingle;
            labelThreads.Location = new Point(623, 151);
            labelThreads.Name = "labelThreads";
            labelThreads.Size = new Size(112, 30);
            labelThreads.TabIndex = 10;
            labelThreads.Text = "Threads";
            labelThreads.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // numericUpDownThreadsCount
            // 
            numericUpDownThreadsCount.Location = new Point(670, 204);
            numericUpDownThreadsCount.Margin = new Padding(3, 4, 3, 4);
            numericUpDownThreadsCount.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDownThreadsCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownThreadsCount.Name = "numericUpDownThreadsCount";
            numericUpDownThreadsCount.Size = new Size(65, 27);
            numericUpDownThreadsCount.TabIndex = 11;
            numericUpDownThreadsCount.TextAlign = HorizontalAlignment.Center;
            numericUpDownThreadsCount.Value = new decimal(new int[] { 500, 0, 0, 0 });
            // 
            // buttonSwitch
            // 
            buttonSwitch.AllowDrop = true;
            buttonSwitch.Location = new Point(922, 189);
            buttonSwitch.Margin = new Padding(3, 4, 3, 4);
            buttonSwitch.Name = "buttonSwitch";
            buttonSwitch.Size = new Size(253, 52);
            buttonSwitch.TabIndex = 12;
            buttonSwitch.Text = "Start";
            buttonSwitch.UseVisualStyleBackColor = true;
            buttonSwitch.Click += ButtonSwitch_Click;
            // 
            // labelThreadsCount
            // 
            labelThreadsCount.Location = new Point(618, 201);
            labelThreadsCount.Name = "labelThreadsCount";
            labelThreadsCount.Size = new Size(50, 31);
            labelThreadsCount.TabIndex = 13;
            labelThreadsCount.Text = "Count";
            labelThreadsCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // numericUpDownDebugRequestTimeout
            // 
            numericUpDownDebugRequestTimeout.Location = new Point(384, 180);
            numericUpDownDebugRequestTimeout.Margin = new Padding(3, 4, 3, 4);
            numericUpDownDebugRequestTimeout.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            numericUpDownDebugRequestTimeout.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownDebugRequestTimeout.Name = "numericUpDownDebugRequestTimeout";
            numericUpDownDebugRequestTimeout.Size = new Size(58, 27);
            numericUpDownDebugRequestTimeout.TabIndex = 17;
            numericUpDownDebugRequestTimeout.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // labelAdditionalFunctions
            // 
            labelAdditionalFunctions.BorderStyle = BorderStyle.FixedSingle;
            labelAdditionalFunctions.Location = new Point(491, 145);
            labelAdditionalFunctions.Name = "labelAdditionalFunctions";
            labelAdditionalFunctions.Size = new Size(121, 94);
            labelAdditionalFunctions.TabIndex = 18;
            labelAdditionalFunctions.Text = "Add. Functions\r\n\r\n---disabled---";
            labelAdditionalFunctions.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelDebug
            // 
            labelDebug.BorderStyle = BorderStyle.FixedSingle;
            labelDebug.Location = new Point(213, 145);
            labelDebug.Name = "labelDebug";
            labelDebug.Size = new Size(272, 30);
            labelDebug.TabIndex = 19;
            labelDebug.Text = "Debug";
            labelDebug.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // checkBoxDebugOutputting
            // 
            checkBoxDebugOutputting.AutoSize = true;
            checkBoxDebugOutputting.Location = new Point(213, 216);
            checkBoxDebugOutputting.Margin = new Padding(3, 4, 3, 4);
            checkBoxDebugOutputting.Name = "checkBoxDebugOutputting";
            checkBoxDebugOutputting.Size = new Size(103, 24);
            checkBoxDebugOutputting.TabIndex = 21;
            checkBoxDebugOutputting.Text = "Outputting";
            checkBoxDebugOutputting.UseVisualStyleBackColor = true;
            // 
            // labelDebugRequestTimeout
            // 
            labelDebugRequestTimeout.ImageAlign = ContentAlignment.MiddleLeft;
            labelDebugRequestTimeout.Location = new Point(213, 177);
            labelDebugRequestTimeout.Name = "labelDebugRequestTimeout";
            labelDebugRequestTimeout.Size = new Size(149, 31);
            labelDebugRequestTimeout.TabIndex = 22;
            labelDebugRequestTimeout.Text = "Request Timeout (secs)";
            labelDebugRequestTimeout.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // checkBoxDebugNoUseProxies
            // 
            checkBoxDebugNoUseProxies.AutoSize = true;
            checkBoxDebugNoUseProxies.Location = new Point(322, 216);
            checkBoxDebugNoUseProxies.Margin = new Padding(3, 4, 3, 4);
            checkBoxDebugNoUseProxies.Name = "checkBoxDebugNoUseProxies";
            checkBoxDebugNoUseProxies.Size = new Size(163, 24);
            checkBoxDebugNoUseProxies.TabIndex = 23;
            checkBoxDebugNoUseProxies.Text = "Выключить прокси";
            checkBoxDebugNoUseProxies.UseVisualStyleBackColor = true;
            // 
            // labelSettings
            // 
            labelSettings.BorderStyle = BorderStyle.FixedSingle;
            labelSettings.Location = new Point(14, 12);
            labelSettings.Name = "labelSettings";
            labelSettings.Size = new Size(192, 30);
            labelSettings.TabIndex = 24;
            labelSettings.Text = "Settings";
            labelSettings.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // textBoxSettingsSeparationSign
            // 
            textBoxSettingsSeparationSign.Location = new Point(168, 57);
            textBoxSettingsSeparationSign.Margin = new Padding(3, 4, 3, 4);
            textBoxSettingsSeparationSign.Name = "textBoxSettingsSeparationSign";
            textBoxSettingsSeparationSign.Size = new Size(37, 27);
            textBoxSettingsSeparationSign.TabIndex = 25;
            textBoxSettingsSeparationSign.Text = ":";
            textBoxSettingsSeparationSign.TextAlign = HorizontalAlignment.Center;
            // 
            // labelSettingsSeparationSign
            // 
            labelSettingsSeparationSign.ImageAlign = ContentAlignment.MiddleLeft;
            labelSettingsSeparationSign.Location = new Point(14, 55);
            labelSettingsSeparationSign.Name = "labelSettingsSeparationSign";
            labelSettingsSeparationSign.Size = new Size(147, 31);
            labelSettingsSeparationSign.TabIndex = 26;
            labelSettingsSeparationSign.Text = "Separation Sign";
            labelSettingsSeparationSign.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSettingsPathValid
            // 
            labelSettingsPathValid.ImageAlign = ContentAlignment.MiddleLeft;
            labelSettingsPathValid.Location = new Point(14, 95);
            labelSettingsPathValid.Name = "labelSettingsPathValid";
            labelSettingsPathValid.Size = new Size(74, 31);
            labelSettingsPathValid.TabIndex = 27;
            labelSettingsPathValid.Text = "Valid";
            labelSettingsPathValid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSettingsPathInvalid
            // 
            labelSettingsPathInvalid.ImageAlign = ContentAlignment.MiddleLeft;
            labelSettingsPathInvalid.Location = new Point(14, 133);
            labelSettingsPathInvalid.Name = "labelSettingsPathInvalid";
            labelSettingsPathInvalid.Size = new Size(74, 31);
            labelSettingsPathInvalid.TabIndex = 28;
            labelSettingsPathInvalid.Text = "Invalid";
            labelSettingsPathInvalid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSettingsPathFrozen
            // 
            labelSettingsPathFrozen.ImageAlign = ContentAlignment.MiddleLeft;
            labelSettingsPathFrozen.Location = new Point(14, 172);
            labelSettingsPathFrozen.Name = "labelSettingsPathFrozen";
            labelSettingsPathFrozen.Size = new Size(74, 31);
            labelSettingsPathFrozen.TabIndex = 29;
            labelSettingsPathFrozen.Text = "Frozen";
            labelSettingsPathFrozen.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // labelSettingsPathTwoFactor
            // 
            labelSettingsPathTwoFactor.ImageAlign = ContentAlignment.MiddleLeft;
            labelSettingsPathTwoFactor.Location = new Point(14, 211);
            labelSettingsPathTwoFactor.Name = "labelSettingsPathTwoFactor";
            labelSettingsPathTwoFactor.Size = new Size(74, 31);
            labelSettingsPathTwoFactor.TabIndex = 30;
            labelSettingsPathTwoFactor.Text = "Two Factor";
            labelSettingsPathTwoFactor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxSettingsPathValid
            // 
            textBoxSettingsPathValid.Location = new Point(95, 96);
            textBoxSettingsPathValid.Margin = new Padding(3, 4, 3, 4);
            textBoxSettingsPathValid.Name = "textBoxSettingsPathValid";
            textBoxSettingsPathValid.Size = new Size(110, 27);
            textBoxSettingsPathValid.TabIndex = 31;
            textBoxSettingsPathValid.Text = "valid.txt";
            textBoxSettingsPathValid.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxSettingsPathInvalid
            // 
            textBoxSettingsPathInvalid.Location = new Point(95, 135);
            textBoxSettingsPathInvalid.Margin = new Padding(3, 4, 3, 4);
            textBoxSettingsPathInvalid.Name = "textBoxSettingsPathInvalid";
            textBoxSettingsPathInvalid.Size = new Size(110, 27);
            textBoxSettingsPathInvalid.TabIndex = 32;
            textBoxSettingsPathInvalid.Text = "invalid.txt";
            textBoxSettingsPathInvalid.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxSettingsPathFrozen
            // 
            textBoxSettingsPathFrozen.Location = new Point(95, 173);
            textBoxSettingsPathFrozen.Margin = new Padding(3, 4, 3, 4);
            textBoxSettingsPathFrozen.Name = "textBoxSettingsPathFrozen";
            textBoxSettingsPathFrozen.Size = new Size(110, 27);
            textBoxSettingsPathFrozen.TabIndex = 33;
            textBoxSettingsPathFrozen.Text = "frozen.txt";
            textBoxSettingsPathFrozen.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxSettingsPathTwoFactor
            // 
            textBoxSettingsPathTwoFactor.Location = new Point(95, 212);
            textBoxSettingsPathTwoFactor.Margin = new Padding(3, 4, 3, 4);
            textBoxSettingsPathTwoFactor.Name = "textBoxSettingsPathTwoFactor";
            textBoxSettingsPathTwoFactor.Size = new Size(110, 27);
            textBoxSettingsPathTwoFactor.TabIndex = 34;
            textBoxSettingsPathTwoFactor.Text = "twofactor.txt";
            textBoxSettingsPathTwoFactor.TextAlign = HorizontalAlignment.Center;
            // 
            // richTextBoxLogger
            // 
            richTextBoxLogger.Location = new Point(14, 253);
            richTextBoxLogger.Margin = new Padding(3, 4, 3, 4);
            richTextBoxLogger.Name = "richTextBoxLogger";
            richTextBoxLogger.ReadOnly = true;
            richTextBoxLogger.Size = new Size(1162, 451);
            richTextBoxLogger.TabIndex = 35;
            richTextBoxLogger.Text = "";
            // 
            // checkProxyPassword
            // 
            checkProxyPassword.AutoSize = true;
            checkProxyPassword.Location = new Point(987, 102);
            checkProxyPassword.Margin = new Padding(3, 4, 3, 4);
            checkProxyPassword.Name = "checkProxyPassword";
            checkProxyPassword.Size = new Size(188, 44);
            checkProxyPassword.TabIndex = 36;
            checkProxyPassword.Text = "Прокси с паролем\r\n(login:password:ip:port)";
            checkProxyPassword.UseVisualStyleBackColor = true;
            // 
            // textBoxUserAgent
            // 
            textBoxUserAgent.Location = new Point(832, 154);
            textBoxUserAgent.Margin = new Padding(3, 4, 3, 4);
            textBoxUserAgent.Name = "textBoxUserAgent";
            textBoxUserAgent.Size = new Size(343, 27);
            textBoxUserAgent.TabIndex = 37;
            textBoxUserAgent.Text = "Mozilla/5.0 (Windows NT 10.0; rv:91.0) Gecko/20100101 Firefox/91.0";
            textBoxUserAgent.TextAlign = HorizontalAlignment.Center;
            // 
            // labelUseragent
            // 
            labelUseragent.ImageAlign = ContentAlignment.MiddleLeft;
            labelUseragent.Location = new Point(741, 150);
            labelUseragent.Name = "labelUseragent";
            labelUseragent.Size = new Size(85, 31);
            labelUseragent.TabIndex = 38;
            labelUseragent.Text = "UserAgent";
            labelUseragent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(1188, 717);
            Controls.Add(labelUseragent);
            Controls.Add(textBoxUserAgent);
            Controls.Add(checkProxyPassword);
            Controls.Add(richTextBoxLogger);
            Controls.Add(textBoxSettingsPathTwoFactor);
            Controls.Add(textBoxSettingsPathFrozen);
            Controls.Add(textBoxSettingsPathInvalid);
            Controls.Add(textBoxSettingsPathValid);
            Controls.Add(labelSettingsPathTwoFactor);
            Controls.Add(labelSettingsPathFrozen);
            Controls.Add(labelSettingsPathInvalid);
            Controls.Add(labelSettingsPathValid);
            Controls.Add(labelSettingsSeparationSign);
            Controls.Add(textBoxSettingsSeparationSign);
            Controls.Add(labelSettings);
            Controls.Add(checkBoxDebugNoUseProxies);
            Controls.Add(labelDebugRequestTimeout);
            Controls.Add(checkBoxDebugOutputting);
            Controls.Add(labelDebug);
            Controls.Add(labelAdditionalFunctions);
            Controls.Add(numericUpDownDebugRequestTimeout);
            Controls.Add(labelThreadsCount);
            Controls.Add(buttonSwitch);
            Controls.Add(numericUpDownThreadsCount);
            Controls.Add(labelThreads);
            Controls.Add(labelProxiesType);
            Controls.Add(comboBoxProxiesType);
            Controls.Add(buttonResetProxies);
            Controls.Add(textBoxProxies);
            Controls.Add(labelProxies);
            Controls.Add(buttonProxies);
            Controls.Add(buttonResetCombinations);
            Controls.Add(textBoxCombinations);
            Controls.Add(labelCombinations);
            Controls.Add(buttonCombinations);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            Name = "MainForm";
            FormClosing += MainForm_FormClosing;
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDownThreadsCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownDebugRequestTimeout).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PrintPreviewDialog printPreviewDialog1;
        private Button buttonCombinations;
        private Label labelCombinations;
        private TextBox textBoxCombinations;
        private Button buttonResetCombinations;
        private Button buttonResetProxies;
        private TextBox textBoxProxies;
        private Label labelProxies;
        private Button buttonProxies;
        private ComboBox comboBoxProxiesType;
        private Label labelProxiesType;
        private Label labelThreads;
        private NumericUpDown numericUpDownThreadsCount;
        private Button buttonSwitch;
        private Label labelThreadsCount;
        private NumericUpDown numericUpDownDebugRequestTimeout;
        private Label labelAdditionalFunctions;
        private Label labelDebug;
        private CheckBox checkBoxDebugOutputting;
        private Label labelDebugRequestTimeout;
        private CheckBox checkBoxDebugNoUseProxies;
        private Label labelSettings;
        private TextBox textBoxSettingsSeparationSign;
        private Label labelSettingsSeparationSign;
        private Label labelSettingsPathValid;
        private Label labelSettingsPathInvalid;
        private Label labelSettingsPathFrozen;
        private Label labelSettingsPathTwoFactor;
        private TextBox textBoxSettingsPathValid;
        private TextBox textBoxSettingsPathInvalid;
        private TextBox textBoxSettingsPathFrozen;
        private TextBox textBoxSettingsPathTwoFactor;
        private RichTextBox richTextBoxLogger;
        private CheckBox checkProxyPassword;
        private TextBox textBox1;
        private Label labelUseragent;
        private TextBox textBoxUserAgent;
    }
}