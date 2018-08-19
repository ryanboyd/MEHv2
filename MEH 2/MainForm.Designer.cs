namespace MEH2
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
            this.TabControlObject = new System.Windows.Forms.TabControl();
            this.InputOutputTab = new System.Windows.Forms.TabPage();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.OutputFileTextbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChooseOutputFolderButton = new System.Windows.Forms.Button();
            this.SubfolderCheckbox = new System.Windows.Forms.CheckBox();
            this.InputFolderTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ChooseInputFolderButton = new System.Windows.Forms.Button();
            this.EncodingDropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TextSegmentationTab = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SegmentationParameterTextbox = new System.Windows.Forms.TextBox();
            this.SegmentationOptionRegex = new System.Windows.Forms.RadioButton();
            this.SegmentationOptionEqualSegments = new System.Windows.Forms.RadioButton();
            this.SegmentationOptionWordsPerSegment = new System.Windows.Forms.RadioButton();
            this.SegmentationOptionNone = new System.Windows.Forms.RadioButton();
            this.ConversionListTab = new System.Windows.Forms.TabPage();
            this.ClearConversionsButton = new System.Windows.Forms.Button();
            this.LoadConversionsButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.ConversionSelectionBox = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ConversionsTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.StopListTab = new System.Windows.Forms.TabPage();
            this.ClearStopListButton = new System.Windows.Forms.Button();
            this.LoadStopListButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.StopListLanguageSelector = new System.Windows.Forms.ComboBox();
            this.StopListTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DictionaryListTab = new System.Windows.Forms.TabPage();
            this.DictionaryListTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.LemmatizationTab = new System.Windows.Forms.TabPage();
            this.label22 = new System.Windows.Forms.Label();
            this.ConvertToLowercaseCheckbox = new System.Windows.Forms.CheckBox();
            this.LemmatizerLanguageSelector = new System.Windows.Forms.ComboBox();
            this.UseLemmatizationCheckbox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ChooseOutputTypesTab = new System.Windows.Forms.TabPage();
            this.PruneFreqListParameterTextbox = new System.Windows.Forms.TextBox();
            this.PruneFreqListCheckbox = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ClearDWLSelectionButton = new System.Windows.Forms.Button();
            this.label25 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.PregeneratedDWLTextbox = new System.Windows.Forms.TextBox();
            this.ChooseDWLButton = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.DocumentWordListsOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.TFIDFOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.RawOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.VerboseOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.BinaryOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.FrequencyListCheckbox = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NgramSettingsTab = new System.Windows.Forms.TabPage();
            this.ThresholdOptionRawFreq = new System.Windows.Forms.RadioButton();
            this.label28 = new System.Windows.Forms.Label();
            this.NgramTextbox = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.MinimumWCTextbox = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ThresholdParameterTextbox = new System.Windows.Forms.TextBox();
            this.ThresholdOptionMostFrequentByPercentOfDocuments = new System.Windows.Forms.RadioButton();
            this.ThresholdOptionMostFrequentByRawFrequency = new System.Windows.Forms.RadioButton();
            this.ThresholdOptionPercentOfDocuments = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.BeginAnalysisTab = new System.Windows.Forms.TabPage();
            this.CancelAnalysisButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.RichTextboxLog = new System.Windows.Forms.RichTextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.label23 = new System.Windows.Forms.Label();
            this.AboutMEHTab = new System.Windows.Forms.TabPage();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.AboutMEHPictureBox = new System.Windows.Forms.PictureBox();
            this.label24 = new System.Windows.Forms.Label();
            this.BGWorker = new System.ComponentModel.BackgroundWorker();
            this.TabControlObject.SuspendLayout();
            this.InputOutputTab.SuspendLayout();
            this.TextSegmentationTab.SuspendLayout();
            this.ConversionListTab.SuspendLayout();
            this.StopListTab.SuspendLayout();
            this.DictionaryListTab.SuspendLayout();
            this.LemmatizationTab.SuspendLayout();
            this.ChooseOutputTypesTab.SuspendLayout();
            this.NgramSettingsTab.SuspendLayout();
            this.BeginAnalysisTab.SuspendLayout();
            this.AboutMEHTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutMEHPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TabControlObject
            // 
            this.TabControlObject.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.TabControlObject.Controls.Add(this.InputOutputTab);
            this.TabControlObject.Controls.Add(this.TextSegmentationTab);
            this.TabControlObject.Controls.Add(this.ConversionListTab);
            this.TabControlObject.Controls.Add(this.StopListTab);
            this.TabControlObject.Controls.Add(this.DictionaryListTab);
            this.TabControlObject.Controls.Add(this.LemmatizationTab);
            this.TabControlObject.Controls.Add(this.ChooseOutputTypesTab);
            this.TabControlObject.Controls.Add(this.NgramSettingsTab);
            this.TabControlObject.Controls.Add(this.BeginAnalysisTab);
            this.TabControlObject.Controls.Add(this.AboutMEHTab);
            this.TabControlObject.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.TabControlObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabControlObject.ItemSize = new System.Drawing.Size(30, 225);
            this.TabControlObject.Location = new System.Drawing.Point(13, 13);
            this.TabControlObject.Margin = new System.Windows.Forms.Padding(4);
            this.TabControlObject.Multiline = true;
            this.TabControlObject.Name = "TabControlObject";
            this.TabControlObject.SelectedIndex = 0;
            this.TabControlObject.Size = new System.Drawing.Size(1193, 569);
            this.TabControlObject.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabControlObject.TabIndex = 0;
            this.TabControlObject.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl_DrawItem);
            // 
            // InputOutputTab
            // 
            this.InputOutputTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.InputOutputTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputOutputTab.Controls.Add(this.label30);
            this.InputOutputTab.Controls.Add(this.label29);
            this.InputOutputTab.Controls.Add(this.label9);
            this.InputOutputTab.Controls.Add(this.OutputFileTextbox);
            this.InputOutputTab.Controls.Add(this.label3);
            this.InputOutputTab.Controls.Add(this.ChooseOutputFolderButton);
            this.InputOutputTab.Controls.Add(this.SubfolderCheckbox);
            this.InputOutputTab.Controls.Add(this.InputFolderTextbox);
            this.InputOutputTab.Controls.Add(this.label2);
            this.InputOutputTab.Controls.Add(this.ChooseInputFolderButton);
            this.InputOutputTab.Controls.Add(this.EncodingDropdown);
            this.InputOutputTab.Controls.Add(this.label1);
            this.InputOutputTab.Location = new System.Drawing.Point(229, 4);
            this.InputOutputTab.Margin = new System.Windows.Forms.Padding(4);
            this.InputOutputTab.Name = "InputOutputTab";
            this.InputOutputTab.Padding = new System.Windows.Forms.Padding(4);
            this.InputOutputTab.Size = new System.Drawing.Size(960, 561);
            this.InputOutputTab.TabIndex = 0;
            this.InputOutputTab.Text = "Input/Output File Settings";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(16, 299);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(888, 18);
            this.label30.TabIndex = 11;
            this.label30.Text = "_________________________________________________________________________________" +
    "_____________________________";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(13, 120);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(888, 18);
            this.label29.TabIndex = 10;
            this.label29.Text = "_________________________________________________________________________________" +
    "_____________________________";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 4);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(258, 25);
            this.label9.TabIndex = 9;
            this.label9.Text = "Input/Output File Settings";
            // 
            // OutputFileTextbox
            // 
            this.OutputFileTextbox.Enabled = false;
            this.OutputFileTextbox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OutputFileTextbox.Location = new System.Drawing.Point(14, 398);
            this.OutputFileTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.OutputFileTextbox.MaxLength = 2147483647;
            this.OutputFileTextbox.Name = "OutputFileTextbox";
            this.OutputFileTextbox.Size = new System.Drawing.Size(619, 24);
            this.OutputFileTextbox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 338);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Output Location";
            // 
            // ChooseOutputFolderButton
            // 
            this.ChooseOutputFolderButton.Location = new System.Drawing.Point(14, 362);
            this.ChooseOutputFolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseOutputFolderButton.Name = "ChooseOutputFolderButton";
            this.ChooseOutputFolderButton.Size = new System.Drawing.Size(180, 28);
            this.ChooseOutputFolderButton.TabIndex = 6;
            this.ChooseOutputFolderButton.Text = "Choose Folder";
            this.ChooseOutputFolderButton.UseVisualStyleBackColor = true;
            this.ChooseOutputFolderButton.Click += new System.EventHandler(this.ChooseOutputFolderButton_Click);
            // 
            // SubfolderCheckbox
            // 
            this.SubfolderCheckbox.AutoSize = true;
            this.SubfolderCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubfolderCheckbox.Location = new System.Drawing.Point(14, 258);
            this.SubfolderCheckbox.Margin = new System.Windows.Forms.Padding(4);
            this.SubfolderCheckbox.Name = "SubfolderCheckbox";
            this.SubfolderCheckbox.Size = new System.Drawing.Size(169, 24);
            this.SubfolderCheckbox.TabIndex = 5;
            this.SubfolderCheckbox.Text = "Include Subfolders";
            this.SubfolderCheckbox.UseVisualStyleBackColor = true;
            // 
            // InputFolderTextbox
            // 
            this.InputFolderTextbox.Enabled = false;
            this.InputFolderTextbox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputFolderTextbox.Location = new System.Drawing.Point(13, 226);
            this.InputFolderTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.InputFolderTextbox.MaxLength = 2147483647;
            this.InputFolderTextbox.Name = "InputFolderTextbox";
            this.InputFolderTextbox.Size = new System.Drawing.Size(619, 24);
            this.InputFolderTextbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 166);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Select Folder with .txt Files:";
            // 
            // ChooseInputFolderButton
            // 
            this.ChooseInputFolderButton.Location = new System.Drawing.Point(13, 190);
            this.ChooseInputFolderButton.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseInputFolderButton.Name = "ChooseInputFolderButton";
            this.ChooseInputFolderButton.Size = new System.Drawing.Size(180, 28);
            this.ChooseInputFolderButton.TabIndex = 2;
            this.ChooseInputFolderButton.Text = "Choose Folder";
            this.ChooseInputFolderButton.UseVisualStyleBackColor = true;
            this.ChooseInputFolderButton.Click += new System.EventHandler(this.SelectInputFolderButtonClick);
            // 
            // EncodingDropdown
            // 
            this.EncodingDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EncodingDropdown.DropDownWidth = 300;
            this.EncodingDropdown.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EncodingDropdown.FormattingEnabled = true;
            this.EncodingDropdown.Location = new System.Drawing.Point(13, 73);
            this.EncodingDropdown.Margin = new System.Windows.Forms.Padding(4);
            this.EncodingDropdown.MaxDropDownItems = 20;
            this.EncodingDropdown.Name = "EncodingDropdown";
            this.EncodingDropdown.Size = new System.Drawing.Size(252, 28);
            this.EncodingDropdown.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 49);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text Encoding of Input File(s):";
            // 
            // TextSegmentationTab
            // 
            this.TextSegmentationTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.TextSegmentationTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextSegmentationTab.Controls.Add(this.label17);
            this.TextSegmentationTab.Controls.Add(this.label10);
            this.TextSegmentationTab.Controls.Add(this.SegmentationParameterTextbox);
            this.TextSegmentationTab.Controls.Add(this.SegmentationOptionRegex);
            this.TextSegmentationTab.Controls.Add(this.SegmentationOptionEqualSegments);
            this.TextSegmentationTab.Controls.Add(this.SegmentationOptionWordsPerSegment);
            this.TextSegmentationTab.Controls.Add(this.SegmentationOptionNone);
            this.TextSegmentationTab.Location = new System.Drawing.Point(229, 4);
            this.TextSegmentationTab.Margin = new System.Windows.Forms.Padding(4);
            this.TextSegmentationTab.Name = "TextSegmentationTab";
            this.TextSegmentationTab.Padding = new System.Windows.Forms.Padding(4);
            this.TextSegmentationTab.Size = new System.Drawing.Size(960, 561);
            this.TextSegmentationTab.TabIndex = 1;
            this.TextSegmentationTab.Text = "Text Segmentation";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(13, 238);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(379, 20);
            this.label17.TabIndex = 6;
            this.label17.Text = "Input your selected segmentation parameter here:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(8, 4);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(257, 25);
            this.label10.TabIndex = 5;
            this.label10.Text = "Segmentation (by Token)";
            // 
            // SegmentationParameterTextbox
            // 
            this.SegmentationParameterTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationParameterTextbox.Location = new System.Drawing.Point(17, 262);
            this.SegmentationParameterTextbox.Margin = new System.Windows.Forms.Padding(4);
            this.SegmentationParameterTextbox.MaxLength = 999999999;
            this.SegmentationParameterTextbox.Name = "SegmentationParameterTextbox";
            this.SegmentationParameterTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.SegmentationParameterTextbox.Size = new System.Drawing.Size(577, 27);
            this.SegmentationParameterTextbox.TabIndex = 4;
            // 
            // SegmentationOptionRegex
            // 
            this.SegmentationOptionRegex.AutoSize = true;
            this.SegmentationOptionRegex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionRegex.Location = new System.Drawing.Point(12, 175);
            this.SegmentationOptionRegex.Margin = new System.Windows.Forms.Padding(4);
            this.SegmentationOptionRegex.Name = "SegmentationOptionRegex";
            this.SegmentationOptionRegex.Size = new System.Drawing.Size(471, 24);
            this.SegmentationOptionRegex.TabIndex = 3;
            this.SegmentationOptionRegex.Text = "(Currently Hidden) Segment Texts with Regular Expression";
            this.SegmentationOptionRegex.UseVisualStyleBackColor = true;
            this.SegmentationOptionRegex.Visible = false;
            // 
            // SegmentationOptionEqualSegments
            // 
            this.SegmentationOptionEqualSegments.AutoSize = true;
            this.SegmentationOptionEqualSegments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionEqualSegments.Location = new System.Drawing.Point(12, 94);
            this.SegmentationOptionEqualSegments.Margin = new System.Windows.Forms.Padding(4);
            this.SegmentationOptionEqualSegments.Name = "SegmentationOptionEqualSegments";
            this.SegmentationOptionEqualSegments.Size = new System.Drawing.Size(345, 24);
            this.SegmentationOptionEqualSegments.TabIndex = 2;
            this.SegmentationOptionEqualSegments.Text = "Split Texts into N Equally-Sized Segments";
            this.SegmentationOptionEqualSegments.UseVisualStyleBackColor = true;
            // 
            // SegmentationOptionWordsPerSegment
            // 
            this.SegmentationOptionWordsPerSegment.AutoSize = true;
            this.SegmentationOptionWordsPerSegment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionWordsPerSegment.Location = new System.Drawing.Point(12, 134);
            this.SegmentationOptionWordsPerSegment.Margin = new System.Windows.Forms.Padding(4);
            this.SegmentationOptionWordsPerSegment.Name = "SegmentationOptionWordsPerSegment";
            this.SegmentationOptionWordsPerSegment.Size = new System.Drawing.Size(371, 24);
            this.SegmentationOptionWordsPerSegment.TabIndex = 1;
            this.SegmentationOptionWordsPerSegment.Text = "Desired Segment Size (Tokens Per Segment)";
            this.SegmentationOptionWordsPerSegment.UseVisualStyleBackColor = true;
            // 
            // SegmentationOptionNone
            // 
            this.SegmentationOptionNone.AutoSize = true;
            this.SegmentationOptionNone.Checked = true;
            this.SegmentationOptionNone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SegmentationOptionNone.Location = new System.Drawing.Point(12, 53);
            this.SegmentationOptionNone.Margin = new System.Windows.Forms.Padding(4);
            this.SegmentationOptionNone.Name = "SegmentationOptionNone";
            this.SegmentationOptionNone.Size = new System.Drawing.Size(158, 24);
            this.SegmentationOptionNone.TabIndex = 0;
            this.SegmentationOptionNone.TabStop = true;
            this.SegmentationOptionNone.Text = "No Segmentation";
            this.SegmentationOptionNone.UseVisualStyleBackColor = true;
            // 
            // ConversionListTab
            // 
            this.ConversionListTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ConversionListTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ConversionListTab.Controls.Add(this.ClearConversionsButton);
            this.ConversionListTab.Controls.Add(this.LoadConversionsButton);
            this.ConversionListTab.Controls.Add(this.label14);
            this.ConversionListTab.Controls.Add(this.ConversionSelectionBox);
            this.ConversionListTab.Controls.Add(this.label13);
            this.ConversionListTab.Controls.Add(this.ConversionsTextbox);
            this.ConversionListTab.Controls.Add(this.label4);
            this.ConversionListTab.Location = new System.Drawing.Point(229, 4);
            this.ConversionListTab.Margin = new System.Windows.Forms.Padding(4);
            this.ConversionListTab.Name = "ConversionListTab";
            this.ConversionListTab.Size = new System.Drawing.Size(960, 561);
            this.ConversionListTab.TabIndex = 2;
            this.ConversionListTab.Text = "Conversion List";
            // 
            // ClearConversionsButton
            // 
            this.ClearConversionsButton.Location = new System.Drawing.Point(562, 202);
            this.ClearConversionsButton.Name = "ClearConversionsButton";
            this.ClearConversionsButton.Size = new System.Drawing.Size(210, 28);
            this.ClearConversionsButton.TabIndex = 6;
            this.ClearConversionsButton.Text = "Clear Conversions List";
            this.ClearConversionsButton.UseVisualStyleBackColor = true;
            this.ClearConversionsButton.Click += new System.EventHandler(this.ClearConversionsButton_Click);
            // 
            // LoadConversionsButton
            // 
            this.LoadConversionsButton.Location = new System.Drawing.Point(562, 147);
            this.LoadConversionsButton.Name = "LoadConversionsButton";
            this.LoadConversionsButton.Size = new System.Drawing.Size(210, 28);
            this.LoadConversionsButton.TabIndex = 5;
            this.LoadConversionsButton.Text = "Load Default Conversions";
            this.LoadConversionsButton.UseVisualStyleBackColor = true;
            this.LoadConversionsButton.Click += new System.EventHandler(this.LoadConversionsButton_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(486, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 4;
            this.label14.Text = "Language:";
            // 
            // ConversionSelectionBox
            // 
            this.ConversionSelectionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ConversionSelectionBox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConversionSelectionBox.FormattingEnabled = true;
            this.ConversionSelectionBox.Location = new System.Drawing.Point(490, 97);
            this.ConversionSelectionBox.Name = "ConversionSelectionBox";
            this.ConversionSelectionBox.Size = new System.Drawing.Size(354, 28);
            this.ConversionSelectionBox.TabIndex = 3;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(486, 34);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(261, 20);
            this.label13.TabIndex = 2;
            this.label13.Text = "Load Default Conversion List:";
            // 
            // ConversionsTextbox
            // 
            this.ConversionsTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConversionsTextbox.Location = new System.Drawing.Point(13, 34);
            this.ConversionsTextbox.MaxLength = 2147483647;
            this.ConversionsTextbox.Multiline = true;
            this.ConversionsTextbox.Name = "ConversionsTextbox";
            this.ConversionsTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConversionsTextbox.Size = new System.Drawing.Size(422, 465);
            this.ConversionsTextbox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 4);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(162, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Conversion List";
            // 
            // StopListTab
            // 
            this.StopListTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.StopListTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StopListTab.Controls.Add(this.ClearStopListButton);
            this.StopListTab.Controls.Add(this.LoadStopListButton);
            this.StopListTab.Controls.Add(this.label12);
            this.StopListTab.Controls.Add(this.label11);
            this.StopListTab.Controls.Add(this.StopListLanguageSelector);
            this.StopListTab.Controls.Add(this.StopListTextbox);
            this.StopListTab.Controls.Add(this.label5);
            this.StopListTab.Location = new System.Drawing.Point(229, 4);
            this.StopListTab.Margin = new System.Windows.Forms.Padding(4);
            this.StopListTab.Name = "StopListTab";
            this.StopListTab.Size = new System.Drawing.Size(960, 561);
            this.StopListTab.TabIndex = 3;
            this.StopListTab.Text = "Stop List";
            // 
            // ClearStopListButton
            // 
            this.ClearStopListButton.Location = new System.Drawing.Point(595, 202);
            this.ClearStopListButton.Name = "ClearStopListButton";
            this.ClearStopListButton.Size = new System.Drawing.Size(142, 28);
            this.ClearStopListButton.TabIndex = 6;
            this.ClearStopListButton.Text = "Clear Stop List";
            this.ClearStopListButton.UseVisualStyleBackColor = true;
            this.ClearStopListButton.Click += new System.EventHandler(this.ClearStopListButton_Click);
            // 
            // LoadStopListButton
            // 
            this.LoadStopListButton.Location = new System.Drawing.Point(595, 147);
            this.LoadStopListButton.Name = "LoadStopListButton";
            this.LoadStopListButton.Size = new System.Drawing.Size(142, 28);
            this.LoadStopListButton.TabIndex = 5;
            this.LoadStopListButton.Text = "Load Stop List";
            this.LoadStopListButton.UseVisualStyleBackColor = true;
            this.LoadStopListButton.Click += new System.EventHandler(this.LoadStoplistButton_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(486, 74);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 20);
            this.label12.TabIndex = 4;
            this.label12.Text = "Language:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(486, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(205, 20);
            this.label11.TabIndex = 3;
            this.label11.Text = "Load Default Stop List:";
            // 
            // StopListLanguageSelector
            // 
            this.StopListLanguageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StopListLanguageSelector.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopListLanguageSelector.FormattingEnabled = true;
            this.StopListLanguageSelector.Location = new System.Drawing.Point(490, 97);
            this.StopListLanguageSelector.MaxDropDownItems = 20;
            this.StopListLanguageSelector.Name = "StopListLanguageSelector";
            this.StopListLanguageSelector.Size = new System.Drawing.Size(354, 28);
            this.StopListLanguageSelector.TabIndex = 2;
            // 
            // StopListTextbox
            // 
            this.StopListTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StopListTextbox.Location = new System.Drawing.Point(13, 34);
            this.StopListTextbox.MaxLength = 2147483647;
            this.StopListTextbox.Multiline = true;
            this.StopListTextbox.Name = "StopListTextbox";
            this.StopListTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.StopListTextbox.Size = new System.Drawing.Size(420, 465);
            this.StopListTextbox.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 4);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "Stop List";
            // 
            // DictionaryListTab
            // 
            this.DictionaryListTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.DictionaryListTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DictionaryListTab.Controls.Add(this.DictionaryListTextbox);
            this.DictionaryListTab.Controls.Add(this.label6);
            this.DictionaryListTab.Location = new System.Drawing.Point(229, 4);
            this.DictionaryListTab.Margin = new System.Windows.Forms.Padding(4);
            this.DictionaryListTab.Name = "DictionaryListTab";
            this.DictionaryListTab.Size = new System.Drawing.Size(960, 561);
            this.DictionaryListTab.TabIndex = 4;
            this.DictionaryListTab.Text = "Dictionary List";
            // 
            // DictionaryListTextbox
            // 
            this.DictionaryListTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DictionaryListTextbox.Location = new System.Drawing.Point(13, 32);
            this.DictionaryListTextbox.MaxLength = 2147483647;
            this.DictionaryListTextbox.Multiline = true;
            this.DictionaryListTextbox.Name = "DictionaryListTextbox";
            this.DictionaryListTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DictionaryListTextbox.Size = new System.Drawing.Size(468, 465);
            this.DictionaryListTextbox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 4);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(148, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Dictionary List";
            // 
            // LemmatizationTab
            // 
            this.LemmatizationTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.LemmatizationTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LemmatizationTab.Controls.Add(this.label22);
            this.LemmatizationTab.Controls.Add(this.ConvertToLowercaseCheckbox);
            this.LemmatizationTab.Controls.Add(this.LemmatizerLanguageSelector);
            this.LemmatizationTab.Controls.Add(this.UseLemmatizationCheckbox);
            this.LemmatizationTab.Controls.Add(this.label7);
            this.LemmatizationTab.Location = new System.Drawing.Point(229, 4);
            this.LemmatizationTab.Margin = new System.Windows.Forms.Padding(4);
            this.LemmatizationTab.Name = "LemmatizationTab";
            this.LemmatizationTab.Size = new System.Drawing.Size(960, 561);
            this.LemmatizationTab.TabIndex = 5;
            this.LemmatizationTab.Text = "Lemmatization";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(13, 77);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(556, 60);
            this.label22.TabIndex = 4;
            this.label22.Text = "Note that the LemmaGen lemmatizer requires texts to be converted to\r\nlowercase in" +
    " order to function properly. If you uncheck this box, your texts\r\nwill not be le" +
    "mmatized by MEH.";
            // 
            // ConvertToLowercaseCheckbox
            // 
            this.ConvertToLowercaseCheckbox.AutoSize = true;
            this.ConvertToLowercaseCheckbox.Checked = true;
            this.ConvertToLowercaseCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ConvertToLowercaseCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConvertToLowercaseCheckbox.Location = new System.Drawing.Point(13, 46);
            this.ConvertToLowercaseCheckbox.Name = "ConvertToLowercaseCheckbox";
            this.ConvertToLowercaseCheckbox.Size = new System.Drawing.Size(241, 24);
            this.ConvertToLowercaseCheckbox.TabIndex = 3;
            this.ConvertToLowercaseCheckbox.Text = "Convert Texts to Lowercase";
            this.ConvertToLowercaseCheckbox.UseVisualStyleBackColor = true;
            // 
            // LemmatizerLanguageSelector
            // 
            this.LemmatizerLanguageSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LemmatizerLanguageSelector.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LemmatizerLanguageSelector.FormattingEnabled = true;
            this.LemmatizerLanguageSelector.Location = new System.Drawing.Point(13, 196);
            this.LemmatizerLanguageSelector.Name = "LemmatizerLanguageSelector";
            this.LemmatizerLanguageSelector.Size = new System.Drawing.Size(407, 28);
            this.LemmatizerLanguageSelector.TabIndex = 2;
            // 
            // UseLemmatizationCheckbox
            // 
            this.UseLemmatizationCheckbox.AutoSize = true;
            this.UseLemmatizationCheckbox.Checked = true;
            this.UseLemmatizationCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseLemmatizationCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseLemmatizationCheckbox.Location = new System.Drawing.Point(13, 166);
            this.UseLemmatizationCheckbox.Name = "UseLemmatizationCheckbox";
            this.UseLemmatizationCheckbox.Size = new System.Drawing.Size(176, 24);
            this.UseLemmatizationCheckbox.TabIndex = 1;
            this.UseLemmatizationCheckbox.Text = "Use Lemmatization";
            this.UseLemmatizationCheckbox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 4);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 25);
            this.label7.TabIndex = 0;
            this.label7.Text = "Lemmatization";
            // 
            // ChooseOutputTypesTab
            // 
            this.ChooseOutputTypesTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ChooseOutputTypesTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ChooseOutputTypesTab.Controls.Add(this.PruneFreqListParameterTextbox);
            this.ChooseOutputTypesTab.Controls.Add(this.PruneFreqListCheckbox);
            this.ChooseOutputTypesTab.Controls.Add(this.label21);
            this.ChooseOutputTypesTab.Controls.Add(this.ClearDWLSelectionButton);
            this.ChooseOutputTypesTab.Controls.Add(this.label25);
            this.ChooseOutputTypesTab.Controls.Add(this.label16);
            this.ChooseOutputTypesTab.Controls.Add(this.PregeneratedDWLTextbox);
            this.ChooseOutputTypesTab.Controls.Add(this.ChooseDWLButton);
            this.ChooseOutputTypesTab.Controls.Add(this.label15);
            this.ChooseOutputTypesTab.Controls.Add(this.DocumentWordListsOutputCheckbox);
            this.ChooseOutputTypesTab.Controls.Add(this.TFIDFOutputCheckbox);
            this.ChooseOutputTypesTab.Controls.Add(this.RawOutputCheckbox);
            this.ChooseOutputTypesTab.Controls.Add(this.VerboseOutputCheckbox);
            this.ChooseOutputTypesTab.Controls.Add(this.BinaryOutputCheckbox);
            this.ChooseOutputTypesTab.Controls.Add(this.FrequencyListCheckbox);
            this.ChooseOutputTypesTab.Controls.Add(this.label8);
            this.ChooseOutputTypesTab.Location = new System.Drawing.Point(229, 4);
            this.ChooseOutputTypesTab.Margin = new System.Windows.Forms.Padding(4);
            this.ChooseOutputTypesTab.Name = "ChooseOutputTypesTab";
            this.ChooseOutputTypesTab.Size = new System.Drawing.Size(960, 561);
            this.ChooseOutputTypesTab.TabIndex = 6;
            this.ChooseOutputTypesTab.Text = "Choose Output Types";
            // 
            // PruneFreqListParameterTextbox
            // 
            this.PruneFreqListParameterTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PruneFreqListParameterTextbox.Location = new System.Drawing.Point(555, 345);
            this.PruneFreqListParameterTextbox.Name = "PruneFreqListParameterTextbox";
            this.PruneFreqListParameterTextbox.Size = new System.Drawing.Size(125, 27);
            this.PruneFreqListParameterTextbox.TabIndex = 15;
            this.PruneFreqListParameterTextbox.Text = "10000";
            // 
            // PruneFreqListCheckbox
            // 
            this.PruneFreqListCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PruneFreqListCheckbox.AutoSize = true;
            this.PruneFreqListCheckbox.Checked = true;
            this.PruneFreqListCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PruneFreqListCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PruneFreqListCheckbox.Location = new System.Drawing.Point(101, 347);
            this.PruneFreqListCheckbox.Name = "PruneFreqListCheckbox";
            this.PruneFreqListCheckbox.Size = new System.Drawing.Size(441, 24);
            this.PruneFreqListCheckbox.TabIndex = 14;
            this.PruneFreqListCheckbox.Text = "Prune Frequency List; Prune after every X Documents:";
            this.PruneFreqListCheckbox.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Crimson;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label21.Location = new System.Drawing.Point(417, 515);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(185, 20);
            this.label21.TabIndex = 13;
            this.label21.Text = "Not Currently Implemented";
            this.label21.Visible = false;
            // 
            // ClearDWLSelectionButton
            // 
            this.ClearDWLSelectionButton.Location = new System.Drawing.Point(220, 115);
            this.ClearDWLSelectionButton.Name = "ClearDWLSelectionButton";
            this.ClearDWLSelectionButton.Size = new System.Drawing.Size(196, 53);
            this.ClearDWLSelectionButton.TabIndex = 12;
            this.ClearDWLSelectionButton.Text = "Clear DWL Selection";
            this.ClearDWLSelectionButton.UseVisualStyleBackColor = true;
            this.ClearDWLSelectionButton.Click += new System.EventHandler(this.ClearDWLSelectionButton_Click);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(10, 371);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(896, 18);
            this.label25.TabIndex = 11;
            this.label25.Text = "_________________________________________________________________________________" +
    "______________________________\r\n";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(10, 235);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(896, 18);
            this.label16.TabIndex = 10;
            this.label16.Text = "_________________________________________________________________________________" +
    "______________________________\r\n";
            // 
            // PregeneratedDWLTextbox
            // 
            this.PregeneratedDWLTextbox.Enabled = false;
            this.PregeneratedDWLTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PregeneratedDWLTextbox.Location = new System.Drawing.Point(13, 186);
            this.PregeneratedDWLTextbox.Name = "PregeneratedDWLTextbox";
            this.PregeneratedDWLTextbox.Size = new System.Drawing.Size(722, 27);
            this.PregeneratedDWLTextbox.TabIndex = 9;
            // 
            // ChooseDWLButton
            // 
            this.ChooseDWLButton.Location = new System.Drawing.Point(13, 115);
            this.ChooseDWLButton.Name = "ChooseDWLButton";
            this.ChooseDWLButton.Size = new System.Drawing.Size(196, 53);
            this.ChooseDWLButton.TabIndex = 8;
            this.ChooseDWLButton.Text = "Choose Pre-Existing\r\nDocument Word List";
            this.ChooseDWLButton.UseVisualStyleBackColor = true;
            this.ChooseDWLButton.Click += new System.EventHandler(this.ChooseDWLButton_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(9, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(441, 40);
            this.label15.TabIndex = 7;
            this.label15.Text = "If you have already generated the \"Document Word Lists\" \r\n.ndjson file, you can r" +
    "eload it here to bypass regeneration:";
            // 
            // DocumentWordListsOutputCheckbox
            // 
            this.DocumentWordListsOutputCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.DocumentWordListsOutputCheckbox.AutoSize = true;
            this.DocumentWordListsOutputCheckbox.Checked = true;
            this.DocumentWordListsOutputCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.DocumentWordListsOutputCheckbox.Enabled = false;
            this.DocumentWordListsOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentWordListsOutputCheckbox.Location = new System.Drawing.Point(53, 279);
            this.DocumentWordListsOutputCheckbox.Name = "DocumentWordListsOutputCheckbox";
            this.DocumentWordListsOutputCheckbox.Size = new System.Drawing.Size(315, 24);
            this.DocumentWordListsOutputCheckbox.TabIndex = 6;
            this.DocumentWordListsOutputCheckbox.Text = "Document Word Lists (as .ndjson file)";
            this.DocumentWordListsOutputCheckbox.UseVisualStyleBackColor = true;
            // 
            // TFIDFOutputCheckbox
            // 
            this.TFIDFOutputCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TFIDFOutputCheckbox.AutoSize = true;
            this.TFIDFOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TFIDFOutputCheckbox.Location = new System.Drawing.Point(53, 513);
            this.TFIDFOutputCheckbox.Name = "TFIDFOutputCheckbox";
            this.TFIDFOutputCheckbox.Size = new System.Drawing.Size(358, 24);
            this.TFIDFOutputCheckbox.TabIndex = 5;
            this.TFIDFOutputCheckbox.Text = "TF-IDF Weighted Document by Term Matrix";
            this.TFIDFOutputCheckbox.UseVisualStyleBackColor = true;
            this.TFIDFOutputCheckbox.Visible = false;
            // 
            // RawOutputCheckbox
            // 
            this.RawOutputCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.RawOutputCheckbox.AutoSize = true;
            this.RawOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RawOutputCheckbox.Location = new System.Drawing.Point(53, 478);
            this.RawOutputCheckbox.Name = "RawOutputCheckbox";
            this.RawOutputCheckbox.Size = new System.Drawing.Size(363, 24);
            this.RawOutputCheckbox.TabIndex = 4;
            this.RawOutputCheckbox.Text = "Raw Count (Sum) Document by Term Matrix";
            this.RawOutputCheckbox.UseVisualStyleBackColor = true;
            // 
            // VerboseOutputCheckbox
            // 
            this.VerboseOutputCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.VerboseOutputCheckbox.AutoSize = true;
            this.VerboseOutputCheckbox.Checked = true;
            this.VerboseOutputCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.VerboseOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VerboseOutputCheckbox.Location = new System.Drawing.Point(53, 443);
            this.VerboseOutputCheckbox.Name = "VerboseOutputCheckbox";
            this.VerboseOutputCheckbox.Size = new System.Drawing.Size(403, 24);
            this.VerboseOutputCheckbox.TabIndex = 3;
            this.VerboseOutputCheckbox.Text = "Verbose (Percentages) Document by Term Matrix";
            this.VerboseOutputCheckbox.UseVisualStyleBackColor = true;
            // 
            // BinaryOutputCheckbox
            // 
            this.BinaryOutputCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.BinaryOutputCheckbox.AutoSize = true;
            this.BinaryOutputCheckbox.Checked = true;
            this.BinaryOutputCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BinaryOutputCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BinaryOutputCheckbox.Location = new System.Drawing.Point(53, 408);
            this.BinaryOutputCheckbox.Name = "BinaryOutputCheckbox";
            this.BinaryOutputCheckbox.Size = new System.Drawing.Size(359, 24);
            this.BinaryOutputCheckbox.TabIndex = 2;
            this.BinaryOutputCheckbox.Text = "Binary (One-Hot) Document by Term Matrix";
            this.BinaryOutputCheckbox.UseVisualStyleBackColor = true;
            // 
            // FrequencyListCheckbox
            // 
            this.FrequencyListCheckbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.FrequencyListCheckbox.AutoSize = true;
            this.FrequencyListCheckbox.Checked = true;
            this.FrequencyListCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.FrequencyListCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FrequencyListCheckbox.Location = new System.Drawing.Point(53, 314);
            this.FrequencyListCheckbox.Name = "FrequencyListCheckbox";
            this.FrequencyListCheckbox.Size = new System.Drawing.Size(142, 24);
            this.FrequencyListCheckbox.TabIndex = 1;
            this.FrequencyListCheckbox.Text = "Frequency List";
            this.FrequencyListCheckbox.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(8, 4);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Output File Types";
            // 
            // NgramSettingsTab
            // 
            this.NgramSettingsTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.NgramSettingsTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NgramSettingsTab.Controls.Add(this.ThresholdOptionRawFreq);
            this.NgramSettingsTab.Controls.Add(this.label28);
            this.NgramSettingsTab.Controls.Add(this.NgramTextbox);
            this.NgramSettingsTab.Controls.Add(this.label27);
            this.NgramSettingsTab.Controls.Add(this.label26);
            this.NgramSettingsTab.Controls.Add(this.MinimumWCTextbox);
            this.NgramSettingsTab.Controls.Add(this.label20);
            this.NgramSettingsTab.Controls.Add(this.label19);
            this.NgramSettingsTab.Controls.Add(this.ThresholdParameterTextbox);
            this.NgramSettingsTab.Controls.Add(this.ThresholdOptionMostFrequentByPercentOfDocuments);
            this.NgramSettingsTab.Controls.Add(this.ThresholdOptionMostFrequentByRawFrequency);
            this.NgramSettingsTab.Controls.Add(this.ThresholdOptionPercentOfDocuments);
            this.NgramSettingsTab.Controls.Add(this.label18);
            this.NgramSettingsTab.Location = new System.Drawing.Point(229, 4);
            this.NgramSettingsTab.Name = "NgramSettingsTab";
            this.NgramSettingsTab.Size = new System.Drawing.Size(960, 561);
            this.NgramSettingsTab.TabIndex = 7;
            this.NgramSettingsTab.Text = "N-gram Settings";
            // 
            // ThresholdOptionRawFreq
            // 
            this.ThresholdOptionRawFreq.AutoSize = true;
            this.ThresholdOptionRawFreq.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdOptionRawFreq.Location = new System.Drawing.Point(14, 342);
            this.ThresholdOptionRawFreq.Name = "ThresholdOptionRawFreq";
            this.ThresholdOptionRawFreq.Size = new System.Drawing.Size(340, 24);
            this.ThresholdOptionRawFreq.TabIndex = 13;
            this.ThresholdOptionRawFreq.Text = "Retain N-grams that with Frequency >= X";
            this.ThresholdOptionRawFreq.UseVisualStyleBackColor = true;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(13, 133);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(464, 18);
            this.label28.TabIndex = 12;
            this.label28.Text = "_________________________________________________________";
            // 
            // NgramTextbox
            // 
            this.NgramTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NgramTextbox.Location = new System.Drawing.Point(16, 208);
            this.NgramTextbox.MaxLength = 999999999;
            this.NgramTextbox.Name = "NgramTextbox";
            this.NgramTextbox.Size = new System.Drawing.Size(450, 27);
            this.NgramTextbox.TabIndex = 11;
            this.NgramTextbox.Text = "1";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(12, 185);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(429, 20);
            this.label27.TabIndex = 10;
            this.label27.Text = "Please choose the \"N\" in N-grams (e.g., 1 for unigrams):";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(15, 256);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(464, 18);
            this.label26.TabIndex = 9;
            this.label26.Text = "_________________________________________________________";
            // 
            // MinimumWCTextbox
            // 
            this.MinimumWCTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumWCTextbox.Location = new System.Drawing.Point(16, 77);
            this.MinimumWCTextbox.MaxLength = 999999999;
            this.MinimumWCTextbox.Name = "MinimumWCTextbox";
            this.MinimumWCTextbox.Size = new System.Drawing.Size(450, 27);
            this.MinimumWCTextbox.TabIndex = 7;
            this.MinimumWCTextbox.Text = "100";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 54);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(367, 20);
            this.label20.TabIndex = 6;
            this.label20.Text = "Ignore Documents with a Word Count less than:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(14, 480);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(376, 20);
            this.label19.TabIndex = 5;
            this.label19.Text = "Input your selected threshold parameter (X) here:";
            // 
            // ThresholdParameterTextbox
            // 
            this.ThresholdParameterTextbox.Font = new System.Drawing.Font("Consolas", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdParameterTextbox.Location = new System.Drawing.Point(18, 503);
            this.ThresholdParameterTextbox.MaxLength = 999999999;
            this.ThresholdParameterTextbox.Name = "ThresholdParameterTextbox";
            this.ThresholdParameterTextbox.Size = new System.Drawing.Size(450, 27);
            this.ThresholdParameterTextbox.TabIndex = 4;
            this.ThresholdParameterTextbox.Text = "5";
            // 
            // ThresholdOptionMostFrequentByPercentOfDocuments
            // 
            this.ThresholdOptionMostFrequentByPercentOfDocuments.AutoSize = true;
            this.ThresholdOptionMostFrequentByPercentOfDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdOptionMostFrequentByPercentOfDocuments.Location = new System.Drawing.Point(14, 422);
            this.ThresholdOptionMostFrequentByPercentOfDocuments.Name = "ThresholdOptionMostFrequentByPercentOfDocuments";
            this.ThresholdOptionMostFrequentByPercentOfDocuments.Size = new System.Drawing.Size(469, 24);
            this.ThresholdOptionMostFrequentByPercentOfDocuments.TabIndex = 3;
            this.ThresholdOptionMostFrequentByPercentOfDocuments.Text = "Retain the X most Frequent N-grams (by % of Documents)";
            this.ThresholdOptionMostFrequentByPercentOfDocuments.UseVisualStyleBackColor = true;
            // 
            // ThresholdOptionMostFrequentByRawFrequency
            // 
            this.ThresholdOptionMostFrequentByRawFrequency.AutoSize = true;
            this.ThresholdOptionMostFrequentByRawFrequency.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdOptionMostFrequentByRawFrequency.Location = new System.Drawing.Point(14, 382);
            this.ThresholdOptionMostFrequentByRawFrequency.Name = "ThresholdOptionMostFrequentByRawFrequency";
            this.ThresholdOptionMostFrequentByRawFrequency.Size = new System.Drawing.Size(449, 24);
            this.ThresholdOptionMostFrequentByRawFrequency.TabIndex = 2;
            this.ThresholdOptionMostFrequentByRawFrequency.Text = "Retain the X most Frequent N-grams (by raw frequency)";
            this.ThresholdOptionMostFrequentByRawFrequency.UseVisualStyleBackColor = true;
            // 
            // ThresholdOptionPercentOfDocuments
            // 
            this.ThresholdOptionPercentOfDocuments.AutoSize = true;
            this.ThresholdOptionPercentOfDocuments.Checked = true;
            this.ThresholdOptionPercentOfDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThresholdOptionPercentOfDocuments.Location = new System.Drawing.Point(14, 302);
            this.ThresholdOptionPercentOfDocuments.Name = "ThresholdOptionPercentOfDocuments";
            this.ThresholdOptionPercentOfDocuments.Size = new System.Drawing.Size(421, 24);
            this.ThresholdOptionPercentOfDocuments.TabIndex = 1;
            this.ThresholdOptionPercentOfDocuments.TabStop = true;
            this.ThresholdOptionPercentOfDocuments.Text = "Retain N-grams that appear in >= X% of Documents";
            this.ThresholdOptionPercentOfDocuments.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(8, 4);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(168, 25);
            this.label18.TabIndex = 0;
            this.label18.Text = "N-gram Settings";
            // 
            // BeginAnalysisTab
            // 
            this.BeginAnalysisTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.BeginAnalysisTab.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BeginAnalysisTab.Controls.Add(this.CancelAnalysisButton);
            this.BeginAnalysisTab.Controls.Add(this.StartButton);
            this.BeginAnalysisTab.Controls.Add(this.RichTextboxLog);
            this.BeginAnalysisTab.Controls.Add(this.ProgressBar);
            this.BeginAnalysisTab.Controls.Add(this.label23);
            this.BeginAnalysisTab.Location = new System.Drawing.Point(229, 4);
            this.BeginAnalysisTab.Name = "BeginAnalysisTab";
            this.BeginAnalysisTab.Size = new System.Drawing.Size(960, 561);
            this.BeginAnalysisTab.TabIndex = 8;
            this.BeginAnalysisTab.Text = "Begin Analysis";
            // 
            // CancelAnalysisButton
            // 
            this.CancelAnalysisButton.Location = new System.Drawing.Point(472, 463);
            this.CancelAnalysisButton.Name = "CancelAnalysisButton";
            this.CancelAnalysisButton.Size = new System.Drawing.Size(165, 43);
            this.CancelAnalysisButton.TabIndex = 4;
            this.CancelAnalysisButton.Text = "Cancel";
            this.CancelAnalysisButton.UseVisualStyleBackColor = true;
            this.CancelAnalysisButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(235, 463);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(165, 43);
            this.StartButton.TabIndex = 3;
            this.StartButton.Text = "Start!";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // RichTextboxLog
            // 
            this.RichTextboxLog.BackColor = System.Drawing.Color.Black;
            this.RichTextboxLog.DetectUrls = false;
            this.RichTextboxLog.Font = new System.Drawing.Font("Consolas", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RichTextboxLog.ForeColor = System.Drawing.Color.LimeGreen;
            this.RichTextboxLog.Location = new System.Drawing.Point(13, 41);
            this.RichTextboxLog.Name = "RichTextboxLog";
            this.RichTextboxLog.ReadOnly = true;
            this.RichTextboxLog.Size = new System.Drawing.Size(851, 411);
            this.RichTextboxLog.TabIndex = 2;
            this.RichTextboxLog.Text = "<Log>";
            // 
            // ProgressBar
            // 
            this.ProgressBar.ForeColor = System.Drawing.Color.Lime;
            this.ProgressBar.Location = new System.Drawing.Point(13, 517);
            this.ProgressBar.MarqueeAnimationSpeed = 3000;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(851, 30);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 1;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(8, 4);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(155, 25);
            this.label23.TabIndex = 0;
            this.label23.Text = "Begin Analysis";
            // 
            // AboutMEHTab
            // 
            this.AboutMEHTab.BackColor = System.Drawing.Color.PaleTurquoise;
            this.AboutMEHTab.Controls.Add(this.label34);
            this.AboutMEHTab.Controls.Add(this.label33);
            this.AboutMEHTab.Controls.Add(this.label32);
            this.AboutMEHTab.Controls.Add(this.label31);
            this.AboutMEHTab.Controls.Add(this.AboutMEHPictureBox);
            this.AboutMEHTab.Controls.Add(this.label24);
            this.AboutMEHTab.Location = new System.Drawing.Point(229, 4);
            this.AboutMEHTab.Name = "AboutMEHTab";
            this.AboutMEHTab.Size = new System.Drawing.Size(960, 561);
            this.AboutMEHTab.TabIndex = 9;
            this.AboutMEHTab.Text = "About MEH";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(443, 374);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(380, 40);
            this.label34.TabIndex = 5;
            this.label34.Text = "This software is *completely free* and\r\nopen source software.";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("Verdana", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(443, 225);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(91, 20);
            this.label33.TabIndex = 4;
            this.label33.Text = "Citation:";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(443, 265);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(398, 60);
            this.label32.TabIndex = 3;
            this.label32.Text = "Boyd, R. L. (2018). MEH: Meaning Extraction\r\n      Helper (version 2.0.2b) [Softw" +
    "are].\r\n      Available from https://meh.ryanb.cc";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(443, 141);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(302, 40);
            this.label31.TabIndex = 2;
            this.label31.Text = "The Meaning Extraction Helper\r\nby Ryan L. Boyd, Ph.D.";
            // 
            // AboutMEHPictureBox
            // 
            this.AboutMEHPictureBox.BackColor = System.Drawing.Color.White;
            this.AboutMEHPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AboutMEHPictureBox.ErrorImage = global::MEHv2.Properties.Resources.MEHSplash;
            this.AboutMEHPictureBox.Image = global::MEHv2.Properties.Resources.MEHSplash;
            this.AboutMEHPictureBox.InitialImage = global::MEHv2.Properties.Resources.MEHSplash;
            this.AboutMEHPictureBox.Location = new System.Drawing.Point(16, 86);
            this.AboutMEHPictureBox.Margin = new System.Windows.Forms.Padding(0);
            this.AboutMEHPictureBox.MaximumSize = new System.Drawing.Size(400, 400);
            this.AboutMEHPictureBox.MinimumSize = new System.Drawing.Size(400, 400);
            this.AboutMEHPictureBox.Name = "AboutMEHPictureBox";
            this.AboutMEHPictureBox.Size = new System.Drawing.Size(400, 400);
            this.AboutMEHPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AboutMEHPictureBox.TabIndex = 1;
            this.AboutMEHPictureBox.TabStop = false;
            this.AboutMEHPictureBox.DoubleClick += new System.EventHandler(this.AboutMEHPictureBox_DoubleClick);
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(8, 4);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(122, 25);
            this.label24.TabIndex = 0;
            this.label24.Text = "About MEH";
            // 
            // BGWorker
            // 
            this.BGWorker.WorkerReportsProgress = true;
            this.BGWorker.WorkerSupportsCancellation = true;
            this.BGWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorker_DoWork);
            this.BGWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorker_ProgressChanged);
            this.BGWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 595);
            this.Controls.Add(this.TabControlObject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1237, 642);
            this.MinimumSize = new System.Drawing.Size(1237, 642);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meaning Extraction Helper";
            this.TabControlObject.ResumeLayout(false);
            this.InputOutputTab.ResumeLayout(false);
            this.InputOutputTab.PerformLayout();
            this.TextSegmentationTab.ResumeLayout(false);
            this.TextSegmentationTab.PerformLayout();
            this.ConversionListTab.ResumeLayout(false);
            this.ConversionListTab.PerformLayout();
            this.StopListTab.ResumeLayout(false);
            this.StopListTab.PerformLayout();
            this.DictionaryListTab.ResumeLayout(false);
            this.DictionaryListTab.PerformLayout();
            this.LemmatizationTab.ResumeLayout(false);
            this.LemmatizationTab.PerformLayout();
            this.ChooseOutputTypesTab.ResumeLayout(false);
            this.ChooseOutputTypesTab.PerformLayout();
            this.NgramSettingsTab.ResumeLayout(false);
            this.NgramSettingsTab.PerformLayout();
            this.BeginAnalysisTab.ResumeLayout(false);
            this.BeginAnalysisTab.PerformLayout();
            this.AboutMEHTab.ResumeLayout(false);
            this.AboutMEHTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AboutMEHPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabControlObject;
        private System.Windows.Forms.TabPage InputOutputTab;
        private System.Windows.Forms.TabPage TextSegmentationTab;
        private System.Windows.Forms.ComboBox EncodingDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputFolderTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChooseInputFolderButton;
        private System.Windows.Forms.CheckBox SubfolderCheckbox;
        private System.Windows.Forms.TextBox SegmentationParameterTextbox;
        private System.Windows.Forms.RadioButton SegmentationOptionRegex;
        private System.Windows.Forms.RadioButton SegmentationOptionEqualSegments;
        private System.Windows.Forms.RadioButton SegmentationOptionWordsPerSegment;
        private System.Windows.Forms.RadioButton SegmentationOptionNone;
        private System.Windows.Forms.TextBox OutputFileTextbox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ChooseOutputFolderButton;
        private System.Windows.Forms.TabPage ConversionListTab;
        private System.Windows.Forms.TabPage StopListTab;
        private System.Windows.Forms.TabPage DictionaryListTab;
        private System.Windows.Forms.TabPage LemmatizationTab;
        private System.Windows.Forms.TabPage ChooseOutputTypesTab;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ConversionsTextbox;
        private System.Windows.Forms.TextBox StopListTextbox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox StopListLanguageSelector;
        private System.Windows.Forms.Button LoadStopListButton;
        private System.Windows.Forms.TextBox DictionaryListTextbox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox ConversionSelectionBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button LoadConversionsButton;
        private System.Windows.Forms.ComboBox LemmatizerLanguageSelector;
        private System.Windows.Forms.CheckBox UseLemmatizationCheckbox;
        private System.Windows.Forms.CheckBox FrequencyListCheckbox;
        private System.Windows.Forms.CheckBox TFIDFOutputCheckbox;
        private System.Windows.Forms.CheckBox RawOutputCheckbox;
        private System.Windows.Forms.CheckBox VerboseOutputCheckbox;
        private System.Windows.Forms.CheckBox BinaryOutputCheckbox;
        private System.Windows.Forms.CheckBox DocumentWordListsOutputCheckbox;
        private System.Windows.Forms.TextBox PregeneratedDWLTextbox;
        private System.Windows.Forms.Button ChooseDWLButton;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TabPage NgramSettingsTab;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton ThresholdOptionMostFrequentByPercentOfDocuments;
        private System.Windows.Forms.RadioButton ThresholdOptionMostFrequentByRawFrequency;
        private System.Windows.Forms.RadioButton ThresholdOptionPercentOfDocuments;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox ThresholdParameterTextbox;
        private System.Windows.Forms.TextBox MinimumWCTextbox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage BeginAnalysisTab;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.CheckBox ConvertToLowercaseCheckbox;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.RichTextBox RichTextboxLog;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TabPage AboutMEHTab;
        private System.Windows.Forms.Label label24;
        private System.ComponentModel.BackgroundWorker BGWorker;
        private System.Windows.Forms.Button ClearConversionsButton;
        private System.Windows.Forms.Button ClearStopListButton;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.TextBox NgramTextbox;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button CancelAnalysisButton;
        private System.Windows.Forms.RadioButton ThresholdOptionRawFreq;
        private System.Windows.Forms.Button ClearDWLSelectionButton;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.PictureBox AboutMEHPictureBox;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox PruneFreqListParameterTextbox;
        private System.Windows.Forms.CheckBox PruneFreqListCheckbox;
    }
}

