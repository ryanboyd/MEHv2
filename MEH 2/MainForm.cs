using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using nltk.tokenize.casual.NET;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Media;
using System.Linq;
using System.Diagnostics;


namespace MEH2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {

            

            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string VersionText = version.Major.ToString() + "." + version.Minor.ToString() + "." + version.Build.ToString("D2");



            InitializeComponent();

            DoubleBuffered = true;

            AboutLabel.Text = "Boyd, R. L. (2018). MEH: Meaning Extraction" + Environment.NewLine + 
                              "      Helper(version " + VersionText + ") [Software]." + Environment.NewLine +
                              "      Available from https://meh.ryanb.cc";


            //just testing some stuff -- disregard
            //LemmaSharp.LemmatizerPrebuiltCompact Lemmatizer = new LemmaSharp.LemmatizerPrebuiltCompact(LemmaSharp.LanguagePrebuilt.English);
            //MessageBox.Show(Lemmatizer.Lemmatize("don't"));

            //populate text encoding box
            foreach (var encoding in Encoding.GetEncodings())
            {
                EncodingDropdown.Items.Add(encoding.Name);
            }

            try
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact("utf-8");
            }
            catch
            {
                EncodingDropdown.SelectedIndex = EncodingDropdown.FindStringExact(Encoding.Default.BodyName);
            }

            //populate stop list language box, conversions box, and lemmatization box
            StopListLanguageSelector.Items.AddRange(new string[] { "English",
            "Беларуская (Bulgarian)",
            "čeština (Czech)",
            "français (French)",
            "Deutsch (German)",
            "Magyar (Hungarian)",
            "italiano (Italian)",
            "Македонски (Macedonian)",
            "فارسی (Persian)",
            "polski (Polish)",
            "Pyccĸий (Russian)",
            "Español (Spanish)",
            "Türkçe (Turkish)",
            "English (Mallet Stop List)"});

            ConversionSelectionBox.Items.AddRange(new string[] { "English",
            "italiano (Italian)",
            "Türkçe (Turkish)",
            "---------------------------------",
            "Lemma Lookup List: Asturian (ast)",
            "Lemma Lookup List: Bulgarian (bg)",
            "Lemma Lookup List: Catalan (ca)",
            "Lemma Lookup List: Czech (cs)",
            "Lemma Lookup List: English (en)",
            "Lemma Lookup List: Estonian (et)",
            "Lemma Lookup List: French (fr)",
            "Lemma Lookup List: Galician (gl)",
            "Lemma Lookup List: German (de)",
            "Lemma Lookup List: Hungarian (hu)",
            "Lemma Lookup List: Irish (ga)",
            "Lemma Lookup List: Manx Gaelic (gv)",
            "Lemma Lookup List: Italian (it)",
            "Lemma Lookup List: Persian/Farsi (fa)",
            "Lemma Lookup List: Portuguese (pt)",
            "Lemma Lookup List: Romanian (ro)",
            "Lemma Lookup List: Scottish Gaelic (gd)",
            "Lemma Lookup List: Slovak (sk)",
            "Lemma Lookup List: Slovene (sl)",
            "Lemma Lookup List: Spanish (es)",
            "Lemma Lookup List: Swedish (sv)",
            "Lemma Lookup List: Ukrainian (uk)",
            "Lemma Lookup List: Welsh (cy)",
            });

            LemmatizerLanguageSelector.Items.AddRange(new string[] {
            "English",
            "čeština (Czech)",
            "Eesti (Estonian)",
            "فارسی (Persian)",
            "français (French)",
            "Magyar (Hungarian)",
            "Македонски (Macedonian)",
            "polski (Polish)",
            "Română (Romanian)",
            "Pyccĸий (Russian)",
            "Slovenčina (Slovak)",
            "Slovene",
            "Srpski / Српски (Serbian)",
            "Українська (Ukranian)",
            "Deutsch (German)",
            "italiano (Italian)",
            "Español (Spanish)"
            });

            TokenizerSelectionDropdown.Items.AddRange(new string[] {
            "Twitter-Aware Tokenizer",
            "Whitespace Tokenizer"
             });

            StopListLanguageSelector.SelectedIndex = 0;
            ConversionSelectionBox.SelectedIndex = 0;
            LemmatizerLanguageSelector.SelectedIndex = 0;
            TokenizerSelectionDropdown.SelectedIndex = 0;

            StopListTextbox.Text += MEHv2.Properties.Resources.StopListCharacters + Environment.NewLine + MEHv2.Properties.Resources.stoplist_english.ToLower();
            ConversionsTextbox.Text = MEHv2.Properties.Resources.conversions.ToLower();

        }






        //this gets us our vertical tabs
        //https://stackoverflow.com/a/33100272
        private void tabControl_DrawItem(object sender, DrawItemEventArgs e)
        {
            var g = e.Graphics;
            var text = this.TabControlObject.TabPages[e.Index].Text;
            var sizeText = g.MeasureString(text, this.TabControlObject.Font);

            var x = e.Bounds.Left + 3;
            var y = e.Bounds.Top + (e.Bounds.Height - sizeText.Height) / 2;

            g.DrawString(text, this.TabControlObject.Font, Brushes.Black, x, y);
        }

        private void SelectInputFolderButtonClick(object sender, EventArgs e)
        {
            InputFolderTextbox.Text = "";
            InputSpreadsheetTextbox.Text = "";
            this.CSV_AnalyzingSpreadsheet = false;


            using (var dialog = new FolderBrowserDialog())
            {
                if (OutputFileTextbox.Text != "") dialog.SelectedPath = OutputFileTextbox.Text;
                dialog.ShowNewFolderButton = false;
                dialog.Description = "Please choose the location of your .txt files to analyze";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    InputFolderTextbox.Text = dialog.SelectedPath.ToString();
                    // Move the caret to the end of the text box
                    InputFolderTextbox.Focus();
                    InputFolderTextbox.Select(InputFolderTextbox.Text.Length, 0);
                }
            }

        }

        private void ChooseOutputFolderButton_Click(object sender, EventArgs e)
        {

            OutputFileTextbox.Text = "";


            using (var dialog = new FolderBrowserDialog())
            {
                if (InputFolderTextbox.Text != "")
                {
                    dialog.SelectedPath = InputFolderTextbox.Text;
                }
                else if (InputSpreadsheetTextbox.Text != "")
                {
                    dialog.SelectedPath = Path.GetDirectoryName(InputSpreadsheetTextbox.Text);
                }

                dialog.ShowNewFolderButton = true;

                dialog.Description = "Please choose the folder where your output will be saved";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    OutputFileTextbox.Text = dialog.SelectedPath.ToString();
                    // Move the caret to the end of the text box
                    OutputFileTextbox.Focus();
                    OutputFileTextbox.Select(OutputFileTextbox.Text.Length, 0);
                }

            }
        }
               
        private void ChooseDWLButton_Click(object sender, EventArgs e)
        {

            PregeneratedDWLTextbox.Text = "";
            InputSpreadsheetTextbox.Text = "";
            InputFolderTextbox.Text = "";
            this.CSV_AnalyzingSpreadsheet = false;

            using (var dialog = new OpenFileDialog())
            {
                dialog.FileName = "Document-Word-List.ndjson";
                dialog.Filter = "Document Word List|*.ndjson";
                dialog.RestoreDirectory = true;
                dialog.AddExtension = true;
                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.Multiselect = false;
                dialog.Title = "Please select your pre-generated Document Word List:";


                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PregeneratedDWLTextbox.Text = dialog.FileName.ToString();
                    // Move the caret to the end of the text box
                    PregeneratedDWLTextbox.Focus();
                    PregeneratedDWLTextbox.Select(PregeneratedDWLTextbox.Text.Length, 0);
                }


            }
        }

        private void LoadStoplistButton_Click(object sender, EventArgs e)
        {

            StopListTextbox.Text = MEHv2.Properties.Resources.StopListCharacters + Environment.NewLine;

            switch (StopListLanguageSelector.SelectedItem.ToString())
            {
                case "English":
                    StopListTextbox.Text += MEHv2.Properties.Resources.stoplist_english.ToLower();
                    break;

                case "Беларуская (Bulgarian)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.bulgarianST.ToLower();
                    break;

                case "čeština (Czech)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.czechstoplist.ToLower();
                    break;

                case "français (French)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.frenchstoplist.ToLower();
                    break;

                case "Deutsch (German)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.germanstoplist.ToLower();
                    break;

                case "Magyar (Hungarian)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.hungarianST.ToLower();
                    break;

                case "italiano (Italian)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.italianstoplist.ToLower();
                    break;

                case "فارسی (Persian)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.persianST.ToLower();
                    break;

                case "polski (Polish)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.polishST.ToLower();
                    break;

                case "Pyccĸий (Russian)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.russianstoplist.ToLower();
                    break;

                case "Español (Spanish)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.spanishstoplist.ToLower();
                    break;

                case "Türkçe (Turkish)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.turkishstoplist.ToLower();
                    break;

                case "English (Mallet Stop List)":
                    StopListTextbox.Text += MEHv2.Properties.Resources.stoplist_mallet_en.ToLower();
                    break;

            }
        }

        private void LoadConversionsButton_Click(object sender, EventArgs e)
        {

            ConversionsTextbox.Text = "Loading conversion list..." + Environment.NewLine + "Please wait...";
            ConversionsTextbox.Invalidate();
            ConversionsTextbox.Update();
            ConversionsTextbox.Refresh();
            Application.DoEvents();

            switch (ConversionSelectionBox.SelectedItem.ToString())
            {
                case "English":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.conversions.ToLower();
                    Conversions_Use_Lookup_Checkbox.Checked = false;
                    break;

                case "Türkçe (Turkish)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.default_conversions_turkish.ToLower();
                    Conversions_Use_Lookup_Checkbox.Checked = false;
                    break;

                case "italiano (Italian)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.default_conversions_italian.ToLower();
                    Conversions_Use_Lookup_Checkbox.Checked = false;
                    break;

                case "Lemma Lookup List: Asturian (ast)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_ast;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Bulgarian (bg)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_bg;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Catalan (ca)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_ca;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Czech (cs)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_cs;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: English (en)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_en;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Estonian (et)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_et;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: French (fr)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_fr;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Galician (gl)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_gl;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: German (de)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_de;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Hungarian (hu)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_hu;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Irish (ga)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_ga;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Manx Gaelic (gv)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_gv;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Italian (it)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_it;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Persian/Farsi (fa)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_fa;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Portuguese (pt)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_pt;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Romanian (ro)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_ro;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Scottish Gaelic (gd)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_gd;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Slovak (sk)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_sk;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Slovene (sl)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_sl;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Spanish (es)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_es;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Swedish (sv)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_sv;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Ukrainian (uk)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_uk;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                case "Lemma Lookup List: Welsh (cy)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.manual_lemmatization_cy;
                    Conversions_Use_Lookup_Checkbox.Checked = true;
                    UseLemmatizationCheckbox.Checked = false;
                    break;

                default:
                    ConversionsTextbox.Text = "";
                    break;




            }
        }

        private void ClearConversionsButton_Click(object sender, EventArgs e)
        {
            ConversionsTextbox.Text = "";
        }

        private void ClearStopListButton_Click(object sender, EventArgs e)
        {
            StopListTextbox.Text = "";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!BGWorker.IsBusy) {

                ProgressBar.Value = 0;
                // __     __    _ _     _       _         ____   ______        __         _               ____        _        
                // \ \   / /_ _| (_) __| | __ _| |_ ___  | __ ) / ___\ \      / /__  _ __| | _____ _ __  |  _ \  __ _| |_ __ _ 
                //  \ \ / / _` | | |/ _` |/ _` | __/ _ \ |  _ \| |  _ \ \ /\ / / _ \| '__| |/ / _ \ '__| | | | |/ _` | __/ _` |
                //   \ V / (_| | | | (_| | (_| | ||  __/ | |_) | |_| | \ V  V / (_) | |  |   <  __/ |    | |_| | (_| | || (_| |
                //    \_/ \__,_|_|_|\__,_|\__,_|\__\___| |____/ \____|  \_/\_/ \___/|_|  |_|\_\___|_|    |____/ \__,_|\__\__,_|
                //                                                                                                             

                //Here's the process that we go through when we hit the start button.
                //First, we want to validate all of the user's selections to make sure that nothing will break.
                BGWorkerData BGData = new BGWorkerData();

                BGData.TextFileFolder = InputFolderTextbox.Text;
                BGData.CSVFilePath = InputSpreadsheetTextbox.Text;
                BGData.CSVDelimiter = CSVDelimiterTextbox.Text[0];
                BGData.CSVQuote = CSVQuoteTextbox.Text[0];
                BGData.OutputFileLocation = OutputFileTextbox.Text;
                BGData.SelectedEncoding = Encoding.GetEncoding(EncodingDropdown.SelectedItem.ToString());
                BGData.RetainOnlyDictionaryWords = KeepOnlyDictionaryWordsCheckbox.Checked;
                BGData.AnalyzingSpreadsheet = this.CSV_AnalyzingSpreadsheet;
                BGData.CSV_ID_Indices = this.CSV_ID_Indices;
                BGData.CSV_Text_Indices = this.CSV_Text_Indices;
                BGData.CSVSeparateColumns = this.CSVSeparateColumns;

                BGData.ProcessingPower = ProcessingPowerTrackbar.Value;


                if (SubfolderCheckbox.Checked)
                {
                    BGData.FolderSearchDepth = SearchOption.AllDirectories;
                }
                else
                {
                    BGData.FolderSearchDepth = SearchOption.TopDirectoryOnly;
                }



                if (SegmentationOptionNone.Checked) BGData.SegmentationType = "NoSegmentation";
                if (SegmentationOptionEqualSegments.Checked) BGData.SegmentationType = "N_Equal_Segments";
                if (SegmentationOptionWordsPerSegment.Checked) BGData.SegmentationType = "Words_Per_Segment";
                if (SegmentationOptionRegex.Checked) BGData.SegmentationType = "Regex";
                BGData.Tokenizer = TokenizerSelectionDropdown.SelectedItem.ToString();
                BGData.SegmentationParameter = SegmentationParameterTextbox.Text;

                BGData.ConvertToLowerCase = ConvertToLowercaseCheckbox.Checked;
                BGData.UseLemmatization = UseLemmatizationCheckbox.Checked;
                BGData.LemmatizationModel = LemmatizerLanguageSelector.SelectedItem.ToString();
                BGData.ConversionList_LookupMethod = Conversions_Use_Lookup_Checkbox.Checked;

                if (BGData.ConvertToLowerCase)
                {
                    BGData.ConversionListString = ConversionsTextbox.Text.ToLower();
                    BGData.StopListString = StopListTextbox.Text.ToLower();
                    BGData.DictionaryListString = DictionaryListTextbox.Text.ToLower();
                }
                else
                {
                    BGData.ConversionListString = ConversionsTextbox.Text;
                    BGData.StopListString = StopListTextbox.Text;
                    BGData.DictionaryListString = DictionaryListTextbox.Text;
                }


                BGData.GenerateDWL = true;
                BGData.GenerateFreqList = FrequencyListCheckbox.Checked;
                BGData.GenerateBinary = BinaryOutputCheckbox.Checked;
                BGData.GenerateVerbose = VerboseOutputCheckbox.Checked;
                BGData.GenerateRawDTM = RawOutputCheckbox.Checked;
                BGData.GenerateTFIDF = TFIDFOutputCheckbox.Checked;
                BGData.PreExistingDWL_Location = PregeneratedDWLTextbox.Text;

                

                if (ThresholdOptionMostFrequentByPercentOfDocuments.Checked) BGData.ThresholdType = "TopNDocumentFrequency";
                if (ThresholdOptionMostFrequentByRawFrequency.Checked) BGData.ThresholdType = "TopNRawFrequency";
                if (ThresholdOptionPercentOfDocuments.Checked) BGData.ThresholdType = "PercentOfDocs";
                if (ThresholdOptionRawFreq.Checked) BGData.ThresholdType = "GreaterThanRawFrequencyX";

                //here we have the BGData object filling out its own validation list
                List<Tuple<string, bool, Color>> ValidationList = BGData.Validations_Uncontested();
                ValidationList.Add(BGData.ValidateInputFolder(BGData.TextFileFolder));
                ValidationList.Add(BGData.ValidateOutputFolder(BGData.OutputFileLocation));
                ValidationList.Add(BGData.ValidateSegmentationOptions(BGData.SegmentationType, BGData.SegmentationParameter));
                ValidationList.Add(BGData.ValidateOutputTypes());

                //here are the items that absolutely require validation prior to assignment in the BGData object
                ValidationList.Add(BGData.ValidateThresholdOptions(BGData.ThresholdType, ThresholdParameterTextbox.Text));
                if (ValidationList[ValidationList.Count - 1].Item2) BGData.NgramThresholdParameter = double.Parse(ThresholdParameterTextbox.Text.Trim());
                ValidationList.Add(BGData.ValidateWC(MinimumWCTextbox.Text));
                if (ValidationList[ValidationList.Count - 1].Item2) BGData.MinWC = int.Parse(MinimumWCTextbox.Text.Trim());
                ValidationList.Add(BGData.ValidateNGramN(NgramTextboxMinimum.Text, NgramTextboxMaximum.Text));
                if (ValidationList[ValidationList.Count - 1].Item2)
                {
                    BGData.Ngram_N_Min = int.Parse(NgramTextboxMinimum.Text.Trim());
                    BGData.Ngram_N_Max = int.Parse(NgramTextboxMaximum.Text.Trim());
                }
                ValidationList.Add(BGData.ValidateFreqListPrune(PruneFreqListParameterTextbox.Text));
                if (ValidationList[ValidationList.Count - 1].Item2)
                {
                    BGData.PruneFreqList = PruneFreqListCheckbox.Checked;
                    BGData.FreqListPruneCycle = int.Parse(PruneFreqListParameterTextbox.Text.Trim());
                }
                else
                {
                    BGData.PruneFreqList = PruneFreqListCheckbox.Checked;
                    BGData.FreqListPruneCycle = -1;
                }




                //  ____       _       _    __     __    _ _     _       _   _                   _          _                
                // |  _ \ _ __(_)_ __ | |_  \ \   / /_ _| (_) __| | __ _| |_(_) ___  _ __  ___  | |_ ___   | |    ___   __ _ 
                // | |_) | '__| | '_ \| __|  \ \ / / _` | | |/ _` |/ _` | __| |/ _ \| '_ \/ __| | __/ _ \  | |   / _ \ / _` |
                // |  __/| |  | | | | | |_    \ V / (_| | | | (_| | (_| | |_| | (_) | | | \__ \ | || (_) | | |__| (_) | (_| |
                // |_|   |_|  |_|_| |_|\__|    \_/ \__,_|_|_|\__,_|\__,_|\__|_|\___/|_| |_|___/  \__\___/  |_____\___/ \__, |
                //                                                                                                     |___/ 
                RichTextboxLog.Text = "";

                RichTextboxLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Launching analysis." + Environment.NewLine);

                Random rnd = new Random();
                if (rnd.Next(443556 - 50, 443556 + 50) == 443556) RichTextboxLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": And As It Is Such, So Also As Such Is It Unto You" + Environment.NewLine);


                RichTextboxLog.Select(RichTextboxLog.Text.Length, 0);
                RichTextboxLog.ScrollToCaret();
                
                bool DoesValidationPass = true;

                foreach (Tuple<string, bool, Color> ValidationItem in ValidationList)
                {

                    if (ValidationItem.Item2 == false) RichTextboxLog.AppendText(Environment.NewLine);

                    RichTextboxLog.SelectionColor = ValidationItem.Item3;
                    RichTextboxLog.AppendText(ValidationItem.Item1 + Environment.NewLine);
                    RichTextboxLog.Select(RichTextboxLog.Text.Length, 0);
                    RichTextboxLog.ScrollToCaret();

                    if (ValidationItem.Item2 == false)
                    {
                        DoesValidationPass = false;
                        RichTextboxLog.AppendText(Environment.NewLine);
                    }
                }

                if (DoesValidationPass)
                {
                    DisableAllControls();
                    BGWorker.RunWorkerAsync(BGData);
                }
                else
                {
                    RichTextboxLog.SelectionColor = Color.Red;
                    RichTextboxLog.AppendText("Analysis halted. Please review log to see where the error occurred." + Environment.NewLine);
                    RichTextboxLog.Select(RichTextboxLog.Text.Length, 0);
                    RichTextboxLog.ScrollToCaret();
                }
            }
        }


        //  ____             _                                   _  __        __         _             
        // | __ )  __ _  ___| | ____ _ _ __ ___  _   _ _ __   __| | \ \      / /__  _ __| | _____ _ __ 
        // |  _ \ / _` |/ __| |/ / _` | '__/ _ \| | | | '_ \ / _` |  \ \ /\ / / _ \| '__| |/ / _ \ '__|
        // | |_) | (_| | (__|   < (_| | | | (_) | |_| | | | | (_| |   \ V  V / (_) | |  |   <  __/ |   
        // |____/ \__,_|\___|_|\_\__, |_|  \___/ \__,_|_| |_|\__,_|    \_/\_/ \___/|_|  |_|\_\___|_|   
        //                       |___/                                                                 

        private void BGWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

            try { 
            

                BGWorkerData BGData = (BGWorkerData)e.Argument;

                int ParallelismPower = 1;
                if ((int)System.Math.Floor((double)(Environment.ProcessorCount * ((double)BGData.ProcessingPower / 100.0))) > 1)
                    ParallelismPower = (int)System.Math.Floor((double)(Environment.ProcessorCount * ((double)BGData.ProcessingPower / 100.0)));


                //   ____                  _     ___                   _     ___ _                     
                //  / ___|___  _   _ _ __ | |_  |_ _|_ __  _ __  _   _| |_  |_ _| |_ ___ _ __ ___  ___ 
                // | |   / _ \| | | | '_ \| __|  | || '_ \| '_ \| | | | __|  | || __/ _ \ '_ ` _ \/ __|
                // | |__| (_) | |_| | | | | |_   | || | | | |_) | |_| | |_   | || ||  __/ | | | | \__ \
                //  \____\___/ \__,_|_| |_|\__| |___|_| |_| .__/ \__,_|\__| |___|\__\___|_| |_| |_|___/
                //                                        |_|                                          

                int NumberOfFiles = 0;
                //make sure that we set up the progressbar
                //Each of these sections will count up how much work there is to be done
                if (BGData.PreExistingDWL_Location == "" && !BGData.AnalyzingSpreadsheet)
                {

                   

                    var files = Directory.EnumerateFiles(BGData.TextFileFolder, "*.txt", BGData.FolderSearchDepth);

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        RichTextboxLog.SelectionColor = Color.White;
                        RichTextboxLog.AppendText(Environment.NewLine + "Counting number of files... please wait..." + Environment.NewLine);
                        ProgressBar.Minimum = 0;
                    });


                    foreach (string filecount in files) {
                        NumberOfFiles++;
                        if (NumberOfFiles % 100000 == 0)
                        {

                            if (BGWorker.CancellationPending) break;

                            this.Invoke((MethodInvoker)delegate ()
                            {
                                int BoxStart = RichTextboxLog.Text.Length;
                                RichTextboxLog.AppendText("Counting number of files... " + NumberOfFiles.ToString() + Environment.NewLine);
                                int BoxEnd = RichTextboxLog.Text.Length;
                                RichTextboxLog.Select(BoxStart, BoxEnd - BoxStart);
                                RichTextboxLog.SelectionColor = Color.White;
                                RichTextboxLog.Select(BoxEnd, 0);
                                RichTextboxLog.ScrollToCaret();

                                RichTextboxLog.Invalidate();
                                RichTextboxLog.Update();
                                RichTextboxLog.Refresh();
                                Application.DoEvents();
                            });
                        }
                    }

                }
                else if (BGData.AnalyzingSpreadsheet)
                {

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        RichTextboxLog.SelectionColor = Color.White;
                        RichTextboxLog.AppendText(Environment.NewLine + "Counting number of rows... please wait..." + Environment.NewLine);
                        RichTextboxLog.Invalidate();
                        RichTextboxLog.Update();
                        RichTextboxLog.Refresh();
                        Application.DoEvents();
                    });

                    ProgressBar.Minimum = 0;

                    using (var stream = File.OpenRead(BGData.CSVFilePath))
                    using (var reader = new StreamReader(stream))
                    {
                        var data = MEHv2.CsvParser.ParseHeadAndTail(reader, BGData.CSVDelimiter, BGData.CSVQuote);

                        var header = data.Item1;
                        var lines = data.Item2;

                        foreach (var line in lines)
                        {
                            try
                            {
                                NumberOfFiles++;

                                     
                                if (NumberOfFiles % 100000 == 0)
                                {

                                    if (BGWorker.CancellationPending) break;

                                    this.Invoke((MethodInvoker)delegate ()
                                    {
                                        int BoxStart = RichTextboxLog.Text.Length;
                                        RichTextboxLog.AppendText("Counting number of rows... " + NumberOfFiles.ToString() + Environment.NewLine);
                                        int BoxEnd = RichTextboxLog.Text.Length;
                                        RichTextboxLog.Select(BoxStart, BoxEnd - BoxStart);
                                        RichTextboxLog.SelectionColor = Color.White;
                                        RichTextboxLog.Select(BoxEnd, 0);
                                        RichTextboxLog.ScrollToCaret();

                                        RichTextboxLog.Invalidate();
                                        RichTextboxLog.Update();
                                        RichTextboxLog.Refresh();
                                        Application.DoEvents();
                                    });
                                }
                                
                            }
                            catch
                            {
                                this.Invoke((MethodInvoker)delegate ()
                                {
                                    int BoxStart = RichTextboxLog.Text.Length;
                                    RichTextboxLog.AppendText("There appears to be an error on row " + NumberOfFiles.ToString() + Environment.NewLine);
                                    int BoxEnd = RichTextboxLog.Text.Length;
                                    RichTextboxLog.Select(BoxStart, BoxEnd - BoxStart);
                                    RichTextboxLog.SelectionColor = Color.Red;
                                    RichTextboxLog.Select(BoxEnd, 0);
                                    RichTextboxLog.ScrollToCaret();
                                });
                            }


                        }
                                
                                
                    }
                        

                }
                if (BGData.PreExistingDWL_Location == "" & !BGWorker.CancellationPending)
                {

                    this.Invoke((MethodInvoker)delegate ()
                    {
                        RichTextboxLog.SelectionColor = Color.White;

                        string ItemType = "files";
                        if (BGData.AnalyzingSpreadsheet) ItemType = "rows";

                        RichTextboxLog.AppendText("Found " + NumberOfFiles.ToString() + " " + ItemType + "... " + Environment.NewLine);
                        RichTextboxLog.Select(RichTextboxLog.Text.Length, 0);
                        RichTextboxLog.ScrollToCaret();

                        ProgressBar.Maximum = NumberOfFiles;
                    });
                }


                //  ____        _ _     _   ____  _      _   _                                _     _     _   
                // | __ ) _   _(_) | __| | |  _ \(_) ___| |_(_) ___  _ __   __ _ _ __ _   _  | |   (_)___| |_ 
                // |  _ \| | | | | |/ _` | | | | | |/ __| __| |/ _ \| '_ \ / _` | '__| | | | | |   | / __| __|
                // | |_) | |_| | | | (_| | | |_| | | (__| |_| | (_) | | | | (_| | |  | |_| | | |___| \__ \ |_ 
                // |____/ \__,_|_|_|\__,_| |____/|_|\___|\__|_|\___/|_| |_|\__,_|_|   \__, | |_____|_|___/\__|

                HashSet<string> DictionaryList = new HashSet<string>();
                foreach (string DictionaryWord in BGData.DictionaryListString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (!DictionaryList.Contains(DictionaryWord))
                    {
                        if (BGData.ConvertToLowerCase)
                        {
                            DictionaryList.Add(DictionaryWord.ToLower());
                        }
                        else
                        {
                            DictionaryList.Add(DictionaryWord);
                        }
                    }
                }




                //  ____        _ _     _   ____  _                _     _     _   
                // | __ ) _   _(_) | __| | / ___|| |_ ___  _ __   | |   (_)___| |_ 
                // |  _ \| | | | | |/ _` | \___ \| __/ _ \| '_ \  | |   | / __| __|
                // | |_) | |_| | | | (_| |  ___) | || (_) | |_) | | |___| \__ \ |_ 
                // |____/ \__,_|_|_|\__,_| |____/ \__\___/| .__/  |_____|_|___/\__|
                //                                        |_|                      

                HashSet<string> StopList = new HashSet<string>();
                foreach (string stopword in BGData.StopListString.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    //we want our dictionary list to override our stop list
                    if (!StopList.Contains(stopword) && !DictionaryList.Contains(stopword))
                    {
                        if (BGData.ConvertToLowerCase)
                        {
                            StopList.Add(stopword.ToLower());
                        }
                        else
                        {
                            StopList.Add(stopword);
                        }
                    }
                }






                //set up our output location
                string DWL_Output_Location = BGData.OutputFileLocation + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd_") + "MEH DWL.ndjson";




                //set up all of the things that are going to be used while we're tokenizing
                long filecounter = 0;
                TwitterAwareTokenizer Tokenizer = new TwitterAwareTokenizer();
                Tokenizer.Initialize_Regex();
                //this logger object will allow us to write the output from multiple threads into a single file
                LogWindowWriter LogWriter = new LogWindowWriter();
                LogWriter.setmainform(this);
                WordCountCalculator WC_Calc = new WordCountCalculator();
                TextSegmentor Segmentor = new TextSegmentor();

                if (BGData.SegmentationType == "Regex") Segmentor.SetRegex(BGData.SegmentationParameter);

                LemmatizerChooser LemmaChoose = new LemmatizerChooser();
                LemmaSharp.LemmatizerPrebuiltCompact Lemmatizer = LemmaChoose.LemmaGenChoice(BGData.LemmatizationModel);

                //create a new ngram builder
                MEHv2.NgramDictionaryBuilder NgramBuilder = new MEHv2.NgramDictionaryBuilder();
                //Set the properties for the text conversions within the ngram dictionary builder
                NgramBuilder.SetConverterMode(BGData.ConversionList_LookupMethod, BGData.ConversionListString, BGData.ConvertToLowerCase);



                //report that we're getting ready to start
                if (!BGWorker.CancellationPending) LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + "Initializing / validating all items in Conversions box...", Color.Orange);
                

                



                //temporary list used for finding words that the lemmatizer converts into "token+not"
               //List<string> notlist = new List<string>();




                //  ____             _         _____     _              _          _   _             
                // | __ )  ___  __ _(_)_ __   |_   _|__ | | _____ _ __ (_)______ _| |_(_) ___  _ __  
                // |  _ \ / _ \/ _` | | '_ \    | |/ _ \| |/ / _ \ '_ \| |_  / _` | __| |/ _ \| '_ \ 
                // | |_) |  __/ (_| | | | | |   | | (_) |   <  __/ | | | |/ / (_| | |_| | (_) | | | |
                // |____/ \___|\__, |_|_| |_|   |_|\___/|_|\_\___|_| |_|_/___\__,_|\__|_|\___/|_| |_|
                //             |___/                                                                 

                if (BGData.PreExistingDWL_Location == "" && !BGWorker.CancellationPending) {

                    ThreadsafeOutputWriter OutputWriter = new ThreadsafeOutputWriter(DWL_Output_Location, BGData.SelectedEncoding);




                    //report that we're getting ready to start
                    LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + "Preprocessing and Tokenizing all texts...", Color.LightBlue);

                    //analyze texts from files
                    if (!BGData.AnalyzingSpreadsheet)
                    {
                        var files = Directory.EnumerateFiles(BGData.TextFileFolder, "*.txt", BGData.FolderSearchDepth);
                        Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = ParallelismPower }, (inputfile, state) =>
                        {

                            if (BGWorker.CancellationPending) state.Break();

                            var currIndex = Interlocked.Increment(ref filecounter);

                            //read our input
                            string readText = File.ReadAllText(inputfile, BGData.SelectedEncoding).Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");
                            if (BGData.ConvertToLowerCase) readText = readText.ToLower();


                            //run the conversions from the converter here, but only if we're using the RegEx method (this is the default)
                            if (!BGData.ConversionList_LookupMethod) readText = NgramBuilder.RunRegexConversions(readText);


                            //tokenize the text
                            string[] TokenizedText = new string[] { };

                            switch (BGData.Tokenizer)
                            {
                                case "Twitter-Aware Tokenizer":
                                    TokenizedText = Tokenizer.tokenize(readText, preserve_case: BGData.ConvertToLowerCase == false, reduce_lengthening: true);
                                    break;

                                case "Whitespace Tokenizer":
                                    TokenizedText = Tokenizer.TokenizeWhitespace(text: readText);
                                    break;
                            }




                            //now, we want to remove empty entries (if any)
                            TokenizedText = TokenizedText.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                            //at one point, we were also removing stop list entries here. this has been changed
                            //so that stop words are removed further downstream. this will help keep things sane
                            //TokenizedText = TokenizedText.Where(x => !StopList.Contains(x)).ToArray();


                            if (BGData.UseLemmatization && BGData.ConvertToLowerCase)
                            {
                                for (int i = 0; i < TokenizedText.Length; i++)
                                {
                                    //for some reason, the lemmatizer will occasionally turn a character (e.g., 'd')
                                    //into a blank. so, we really want to remove that behavior. sanity checking to omit
                                    //these cases. I suspect that it's interpreting a floating 'd' as part of something like
                                    //you'd, and so it assumes that since it's a tail it should be dropped. Some specific rule
                                    //that we can certainly bypass
                                    string lemmatized_token = Lemmatizer.Lemmatize(TokenizedText[i]);
                                    //if (lemmatized_token.Contains("+not") && !notlist.Contains(TokenizedText[i])) notlist.Add(TokenizedText[i]);
                                    if (lemmatized_token != "") TokenizedText[i] = lemmatized_token;
                                }
                            }

                            string[][] SegmentedTokenText = Segmentor.Segment(TokenizedText, BGData.SegmentationType, BGData.SegmentationParameter);

                            for (int segment_number = 0; segment_number < SegmentedTokenText.Length; segment_number++)
                            {


                                //We drop the stop words here, prior to the generation of n-grams, to ensure that
                                //everything is removed prior to building higher-order n-grams.
                                string[] TokenizedText_For_Ngrams = SegmentedTokenText[segment_number].Where(x => !StopList.Contains(x)).ToArray();

                                Dictionary<string, Dictionary<string, long>> FileTokenData = new Dictionary<string, Dictionary<string, long>>();

                                //add filename and WC to dictionary
                                FileTokenData.Add("Filename", new Dictionary<string, long> { { Path.GetFileName(inputfile), WC_Calc.GetWC(readText) } });
                                FileTokenData.Add("TokenInfo", new Dictionary<string, long>());

                                //add number of tokens to dictionary
                                FileTokenData.Add("FileInfo", new Dictionary<string, long> { { "RawTokenCount", SegmentedTokenText[segment_number].Length } });
                                FileTokenData["FileInfo"].Add("Segment", segment_number + 1);


                                //Use the NgramBuilder's method to actually iterate through the string array
                                //and return to us a dictionary that is ready to write
                                FileTokenData = NgramBuilder.BuildNgramDictionary(TokenizedText_For_Ngrams,
                                                                                  FileTokenData,
                                                                                  BGData.Ngram_N_Min, BGData.Ngram_N_Max);


                                //write output to ndjson file
                                string outputline = JsonConvert.SerializeObject(FileTokenData);
                                OutputWriter.WriteString(outputline);
                            }


                            BGWorker.ReportProgress((int)filecounter);


                        });
                    }
                    //analyze texts from spreadsheets
                    else
                    {

                        using (var stream = File.OpenRead(BGData.CSVFilePath))
                        using (var reader = new StreamReader(stream))
                        {
                            var data = MEHv2.CsvParser.ParseHeadAndTail(reader, BGData.CSVDelimiter, BGData.CSVQuote);

                            var header = data.Item1;
                            var lines = data.Item2;

                            Parallel.ForEach(lines, new ParallelOptions { MaxDegreeOfParallelism = ParallelismPower}, (line, state) =>
                            {

                                if (BGWorker.CancellationPending) state.Break();

                                var currIndex = Interlocked.Increment(ref filecounter);


                                //Generate a row ID, either by using the spreadsheet or just the row number
                                string RowIdentifier = currIndex.ToString();
                                int RowIDItemCounter = 0;
                                if (BGData.CSV_ID_Indices.Length > 0)
                                {
                                    RowIdentifier = "";
                                    foreach (int IDIndex in BGData.CSV_ID_Indices)
                                    {
                                        if (RowIDItemCounter > 0) RowIdentifier += ";";
                                        RowIdentifier += line[IDIndex];
                                        RowIDItemCounter++;
                                    }
                                }


                                List<string> readTextList = new List<string>();

                                //read our input
                                if (BGData.CSVSeparateColumns)
                                {
                                    foreach (int TextIndex in BGData.CSV_Text_Indices) readTextList.Add(line[TextIndex].Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " "));
                                }
                                else
                                {
                                    StringBuilder readTextBuilder = new StringBuilder();
                                    foreach (int TextIndex in BGData.CSV_Text_Indices) readTextBuilder.Append(line[TextIndex] + Environment.NewLine);
                                    readTextList.Add(readTextBuilder.ToString().Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " "));
                                    readTextBuilder.Clear();
                                }

                                if (BGData.ConvertToLowerCase)
                                    for (int i = 0; i < readTextList.Count(); i++)
                                        readTextList[i] = readTextList[i].ToLower();

                                string[] readTextArray = readTextList.ToArray();



                                for (int i = 0; i < readTextArray.Length; i++)
                                {


                                    string readText = readTextArray[i];

                                    //run the conversions from the converter here, but only if we're using the RegEx method (this is the default)
                                    if (!BGData.ConversionList_LookupMethod) readText = NgramBuilder.RunRegexConversions(readText);

                                    //tokenize the text
                                    string[] TokenizedText = new string[] { };

                                    switch (BGData.Tokenizer)
                                    {
                                        case "Twitter-Aware Tokenizer":
                                            TokenizedText = Tokenizer.tokenize(readText, preserve_case: BGData.ConvertToLowerCase == false, reduce_lengthening: true);
                                            break;

                                        case "Whitespace Tokenizer":
                                            TokenizedText = Tokenizer.TokenizeWhitespace(text: readText);
                                            break;
                                    }

                                    //now, we want to remove empty entries (if any)
                                    TokenizedText = TokenizedText.Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
                                    //at one point, we were also removing stop list entries here. this has been changed
                                    //so that stop words are removed further downstream. this will help keep things sane
                                    //TokenizedText = TokenizedText.Where(x => !StopList.Contains(x)).ToArray();


                                    if (BGData.UseLemmatization && BGData.ConvertToLowerCase)
                                    {
                                        for (int j = 0; j < TokenizedText.Length; j++)
                                        {
                                            //for some reason, the lemmatizer will occasionally turn a character (e.g., 'd')
                                            //into a blank. so, we really want to remove that behavior. sanity checking to omit
                                            //these cases. I suspect that it's interpreting a floating 'd' as part of something like
                                            //you'd, and so it assumes that since it's a tail it should be dropped. Some specific rule
                                            //that we can certainly bypass
                                            string lemmatized_token = Lemmatizer.Lemmatize(TokenizedText[j]);
                                            //if (lemmatized_token.Contains("+not") && !notlist.Contains(TokenizedText[i])) notlist.Add(TokenizedText[i]);
                                            if (lemmatized_token != "") TokenizedText[j] = lemmatized_token;
                                        }
                                    }

                                    string[][] SegmentedTokenText = Segmentor.Segment(TokenizedText, BGData.SegmentationType, BGData.SegmentationParameter);

                                    for (int segment_number = 0; segment_number < SegmentedTokenText.Length; segment_number++)
                                    {


                                        //We drop the stop words here, prior to the generation of n-grams, to ensure that
                                        //everything is removed prior to building higher-order n-grams.
                                        string[] TokenizedText_For_Ngrams = SegmentedTokenText[segment_number].Where(x => !StopList.Contains(x)).ToArray();

                                        Dictionary<string, Dictionary<string, long>> FileTokenData = new Dictionary<string, Dictionary<string, long>>();


                                        string RowIdentifierForOutput = RowIdentifier;
                                        //add filename and WC to dictionary
                                        if (BGData.CSVSeparateColumns) RowIdentifierForOutput += ";" + header[BGData.CSV_Text_Indices[i]];
                                        FileTokenData.Add("Filename", new Dictionary<string, long> { { RowIdentifierForOutput, WC_Calc.GetWC(readText) } });
                                        FileTokenData.Add("TokenInfo", new Dictionary<string, long>());

                                        //add number of tokens to dictionary
                                        FileTokenData.Add("FileInfo", new Dictionary<string, long> { { "RawTokenCount", SegmentedTokenText[segment_number].Length } });
                                        FileTokenData["FileInfo"].Add("Segment", segment_number + 1);


                                        //Use the NgramBuilder's method to actually iterate through the string array
                                        //and return to us a dictionary that is ready to write
                                        FileTokenData = NgramBuilder.BuildNgramDictionary(TokenizedText_For_Ngrams,
                                                                                          FileTokenData,
                                                                                          BGData.Ngram_N_Min, BGData.Ngram_N_Max);


                                        //write output to ndjson file
                                        string outputline = JsonConvert.SerializeObject(FileTokenData);
                                        OutputWriter.WriteString(outputline);
                                    }
                                }

                                


                                BGWorker.ReportProgress((int)filecounter);


                            });
                        }

                     }
                    


                    OutputWriter.Dispose();
                    LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Tokenization Complete.", Color.Green);
                }
                //if we have a pre-generated DWL, we do this instead:
                else
                {

                    DWL_Output_Location = BGData.PreExistingDWL_Location;
                    if (!BGWorker.CancellationPending) LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + "Skipping Document-Word List (DWL) generation and using the pre-generated DWL instead.", Color.HotPink);

                }

            











                //  _____                                             _     _     _      ____                           _   _             
                // |  ___| __ ___  __ _ _   _  ___ _ __   ___ _   _  | |   (_)___| |_   / ___| ___ _ __   ___ _ __ __ _| |_(_) ___  _ __  
                // | |_ | '__/ _ \/ _` | | | |/ _ \ '_ \ / __| | | | | |   | / __| __| | |  _ / _ \ '_ \ / _ \ '__/ _` | __| |/ _ \| '_ \ 
                // |  _|| | |  __/ (_| | |_| |  __/ | | | (__| |_| | | |___| \__ \ |_  | |_| |  __/ | | |  __/ | | (_| | |_| | (_) | | | |
                // |_|  |_|  \___|\__, |\__,_|\___|_| |_|\___|\__, | |_____|_|___/\__|  \____|\___|_| |_|\___|_|  \__,_|\__|_|\___/|_| |_|
                //                   |_|                      |___/                                                                       


                long NumberOfDocuments = 0;
                long NumberOfRows = 0;

                Dictionary<string, long[]> FreqListDictionary = new Dictionary<string, long[]>();

                if (BGData.GenerateFreqList && !BGWorker.CancellationPending)
                {
                    LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Constructing Frequency List...", Color.LightBlue);

                    //the "long" array is being used to store
                    // [0] --> the raw count of the n-gram
                    // [1] --> the number of documents that contain the n-gram
                    string line;

                    using (StreamReader reader = new StreamReader(path: DWL_Output_Location, encoding: BGData.SelectedEncoding))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {

                            if (BGWorker.CancellationPending) break;

                            NumberOfRows++;

                            if (NumberOfRows % 100000 == 0) LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Reading DWL row #" + NumberOfRows.ToString(), Color.White);

                            //this is if we're pruning the ngrams from the frequency list
                            if (BGData.PruneFreqList)
                            {
                                if (NumberOfRows % BGData.FreqListPruneCycle == 0)
                                {

                                LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Pruning rare N-grams...", Color.Yellow);
                                long itemcount = FreqListDictionary.Count;
                                List<string> ItemsToPrune = new List<string>();
                                    foreach (var token in FreqListDictionary)
                                    {
                                        if (token.Value[0] == 1 && !DictionaryList.Contains(token.Key)) ItemsToPrune.Add(token.Key);
                                    }

                                    //do the actual pruning here
                                    for (int prunecounter = 0; prunecounter < ItemsToPrune.Count; prunecounter++) FreqListDictionary.Remove(ItemsToPrune[prunecounter]);

                                    LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + 
                                                         ItemsToPrune.Count.ToString() + " N-grams pruned.", Color.Yellow);

                                }
                            }


                            Dictionary<string, Dictionary<string, long>> JSON_Data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, long>>>(line);
                            Dictionary<string, long> Filename_WC = JSON_Data["Filename"];

                            if (Filename_WC.Values.ToArray()[0] > BGData.MinWC)
                            {
                                NumberOfDocuments++;

                                foreach (var entry in JSON_Data["TokenInfo"])
                                {

                                    //we're doing the stop list removal at this stage
                                    //that way, each document's full text is retained in the DWL.ndjson output
                                    //but, from there, forward, we can remove what we want.
                                    //this way, if we choose to change the stoplist later, we don't have to
                                    //completely reprocess everything. instead, we can just load up the
                                    //DWL.ndjson file and apply the changes downstream

                                    //actually, I've changed my mind on this. It complicates things for
                                    //n-grams > N=1. simplicity is bliss

                                    //if (!StopList.Contains(entry.Key)) { 


                                    //we go this route if we're NOT retaining only dictionary words
                                    if (!BGData.RetainOnlyDictionaryWords) { 

                                        if (FreqListDictionary.ContainsKey(entry.Key))
                                        {
                                            FreqListDictionary[entry.Key][0] += entry.Value;
                                            FreqListDictionary[entry.Key][1]++;
                                        }
                                        else
                                        {
                                            FreqListDictionary.Add(entry.Key, new long[2] { entry.Value, 1 });
                                        }

                                    }
                                    //we go this route if we ARE retaining only dictionary words
                                    else
                                    {
                                        if (DictionaryList.Contains(entry.Key))
                                        {
                                            if (FreqListDictionary.ContainsKey(entry.Key))
                                            {
                                                FreqListDictionary[entry.Key][0] += entry.Value;
                                                FreqListDictionary[entry.Key][1]++;
                                            }
                                            else
                                            {
                                                FreqListDictionary.Add(entry.Key, new long[2] { entry.Value, 1 });
                                            }
                                        }
                                    }

                                    //}
                                }
                            }

                        }
                    }

                    if (!BGWorker.CancellationPending) {


                        //this is if we're pruning the ngrams from the frequency list.
                        //we want to do it one last time prior to writing the output
                        if (BGData.PruneFreqList)
                        {
                            
                            LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Pruning rare N-grams...", Color.Yellow);
                            long itemcount = FreqListDictionary.Count;
                            List<string> ItemsToPrune = new List<string>();
                            foreach (var token in FreqListDictionary)
                            {
                                if (token.Value[0] == 1 && !DictionaryList.Contains(token.Key)) ItemsToPrune.Add(token.Key);
                            }

                            //do the actual pruning here
                            for (int prunecounter = 0; prunecounter < ItemsToPrune.Count; prunecounter++) FreqListDictionary.Remove(ItemsToPrune[prunecounter]);

                            LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " +
                                                    ItemsToPrune.Count.ToString() + " N-grams pruned.", Color.Yellow);
                        
                        }


                        string FrequencyListPath = BGData.OutputFileLocation + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd_") + "MEH Freq List.csv";
                        
                        //at this point, the entire frequency list is assembled
                        //so now we have to write it out
                        using (StreamWriter FreqListFileStream = new StreamWriter(FrequencyListPath, encoding: BGData.SelectedEncoding, append: false))
                        {
                            string[] FreqListHeader = new string[] { "\"Token\"", "\"Frequency\"", "\"Docs_With_Token\"", "\"ObservationPct\"", "\"IDF\"" };
                            FreqListFileStream.Write(string.Join(",", FreqListHeader) + Environment.NewLine);

                            foreach (var token in FreqListDictionary)
                            {
                                string[] RowToWrite = new string[] { "\"" + token.Key.Replace("\"", "\"\"") + "\"", token.Value[0].ToString(),
                                    token.Value[1].ToString(),
                                    Math.Round(((double)token.Value[1] / NumberOfDocuments) * 100.0, 5, mode: MidpointRounding.AwayFromZero).ToString(),
                                     Math.Round(Math.Log(NumberOfDocuments / (double)token.Value[1]), 5, mode: MidpointRounding.AwayFromZero).ToString() };

                                //write the output line
                                FreqListFileStream.Write(string.Join(",", RowToWrite) + Environment.NewLine);
                            }
                        }
                        LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Frequency List has been saved...", Color.Green);
                    }

                    

            }

                





                //  ____       _                      _              ____      _             _   _               _____ _                   _           _     _     
                // |  _ \  ___| |_ ___ _ __ _ __ ___ (_)_ __   ___  |  _ \ ___| |_ ___ _ __ | |_(_) ___  _ __   |_   _| |__  _ __ ___  ___| |__   ___ | | __| |___ 
                // | | | |/ _ \ __/ _ \ '__| '_ ` _ \| | '_ \ / _ \ | |_) / _ \ __/ _ \ '_ \| __| |/ _ \| '_ \    | | | '_ \| '__/ _ \/ __| '_ \ / _ \| |/ _` / __|
                // | |_| |  __/ ||  __/ |  | | | | | | | | | |  __/ |  _ <  __/ ||  __/ | | | |_| | (_) | | | |   | | | | | | | |  __/\__ \ | | | (_) | | (_| \__ \
                // |____/ \___|\__\___|_|  |_| |_| |_|_|_| |_|\___| |_| \_\___|\__\___|_| |_|\__|_|\___/|_| |_|   |_| |_| |_|_|  \___||___/_| |_|\___/|_|\__,_|___/
                //                                                                                                                                                 




                Dictionary<string, int> RetainedWords = new Dictionary<string, int>();


                if (!BGWorker.CancellationPending && (BGData.GenerateBinary | BGData.GenerateVerbose | BGData.GenerateRawDTM | BGData.GenerateTFIDF)) {

                    LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Applying n-gram retention thresholds...", Color.LightBlue);

                    double TopNCutoff = 0;

                    //if we're using one of these two types of cutoffs, we actually want to go through and
                    //figure out what the cutoff point is for including words
                    if (BGData.ThresholdType == "TopNDocumentFrequency" || BGData.ThresholdType == "TopNRawFrequency")
                    {

                        if (BGData.NgramThresholdParameter >= FreqListDictionary.Count)
                        {
                            //if the threshold is larger than the number of words we have, we'll just keep all the words
                            TopNCutoff = 0;
                        }
                        else
                        {
                            double[] TopN_Cutoff_Array = new double[FreqListDictionary.Count];

                            int itemcount = 0;
                            foreach (var token in FreqListDictionary)
                            {
                                switch (BGData.ThresholdType)
                                {
                                    case "TopNDocumentFrequency":
                                        TopN_Cutoff_Array[itemcount] = token.Value[1];
                                        break;
                                    case "TopNRawFrequency":
                                        TopN_Cutoff_Array[itemcount] = token.Value[0];
                                        break;
                                }
                                itemcount++;
                            }


                            //https://stackoverflow.com/a/5430059
                            Array.Sort<double>(TopN_Cutoff_Array,
                                new Comparison<double>(
                                    (i1, i2) => i2.CompareTo(i1)
                                    ));

                            TopNCutoff = TopN_Cutoff_Array[(int)BGData.NgramThresholdParameter - 1];

                        }             

                    }


                

                    //this allows us to build a dictionary that contains the words, as well as what index
                    //they are going to occupy in the future output array. smart.
                    int index_counter = 0;

                    foreach (var token in FreqListDictionary)
                    {


                        if (DictionaryList.Contains(token.Key))
                        {
                            RetainedWords.Add(token.Key, index_counter);
                            index_counter++;
                        }
                        else
                        {

                            switch (BGData.ThresholdType)
                            {
                                case "TopNDocumentFrequency":
                                    if (token.Value[1] >= TopNCutoff)
                                    {
                                        RetainedWords.Add(token.Key, index_counter);
                                        index_counter++;
                                    }
                                    break;
                                case "TopNRawFrequency":
                                    if (token.Value[0] >= TopNCutoff)
                                    {
                                        RetainedWords.Add(token.Key, index_counter);
                                        index_counter++;
                                    }
                                    break;
                                case "PercentOfDocs":
                                    double PctObs = (((double)token.Value[1] / NumberOfDocuments) * 100);
                                    if (PctObs >= BGData.NgramThresholdParameter)
                                    {
                                        RetainedWords.Add(token.Key, index_counter);
                                        index_counter++;
                                    }
                                    break;
                                case "GreaterThanRawFrequencyX":
                                    if (token.Value[0] >= BGData.NgramThresholdParameter)
                                    {
                                        RetainedWords.Add(token.Key, index_counter);
                                        index_counter++;
                                    }
                                    break;
                            }

                        }

                    }


                    LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Retention thresholds applied...", Color.Green);
                
                //end of "if we're going to generate DTM Output, we have to set the thresholds" section    
                }

                //free up some (maybe*) much needed space
                //*maybe, if they're doing a ram-intensive analysis
                //but, good to free up anyways
                FreqListDictionary = new Dictionary<string, long[]>();


                //   ____                           _         ____ _____ __  __    ___        _               _   
                //  / ___| ___ _ __   ___ _ __ __ _| |_ ___  |  _ \_   _|  \/  |  / _ \ _   _| |_ _ __  _   _| |_ 
                // | |  _ / _ \ '_ \ / _ \ '__/ _` | __/ _ \ | | | || | | |\/| | | | | | | | | __| '_ \| | | | __|
                // | |_| |  __/ | | |  __/ | | (_| | ||  __/ | |_| || | | |  | | | |_| | |_| | |_| |_) | |_| | |_ 
                //  \____|\___|_| |_|\___|_|  \__,_|\__\___| |____/ |_| |_|  |_|  \___/ \__,_|\__| .__/ \__,_|\__|
                //                                                                               |_|              
            
                this.Invoke((MethodInvoker)delegate ()
                {
                    ProgressBar.Maximum = (int)NumberOfRows;
                    ProgressBar.Value = 0;
                });

                filecounter = 0;


                if (!BGWorker.CancellationPending && (BGData.GenerateBinary | BGData.GenerateVerbose | BGData.GenerateRawDTM | BGData.GenerateTFIDF))
                {

                    LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Writing Document × Term output...", Color.LightBlue);

                    List<string> WritersToUse = new List<string>();
            
                    //setting up our writers
                    Dictionary<string, ThreadsafeOutputWriter> DTM_Loggers = new Dictionary<string, ThreadsafeOutputWriter>();
                    if (BGData.GenerateBinary) DTM_Loggers.Add("Binary", new ThreadsafeOutputWriter(BGData.OutputFileLocation + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd_") + "MEH_DTM_Binary.csv", BGData.SelectedEncoding));
                    if (BGData.GenerateVerbose) DTM_Loggers.Add("Verbose", new ThreadsafeOutputWriter(BGData.OutputFileLocation + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd_") + "MEH_DTM_Verbose.csv", BGData.SelectedEncoding));
                    if (BGData.GenerateRawDTM) DTM_Loggers.Add("DTM", new ThreadsafeOutputWriter(BGData.OutputFileLocation + Path.DirectorySeparatorChar + DateTime.Now.ToString("yyyy-MM-dd_") + "MEH_DTM_RawCount.csv", BGData.SelectedEncoding));


                    short HeaderLead = 4;
                    int NGramCount = RetainedWords.Count;
                    string[] HeaderString = new string[HeaderLead + NGramCount];
                    HeaderString[0] = "\"Filename\"";
                    HeaderString[1] = "\"Segment\"";
                    HeaderString[2] = "\"WC\"";
                    HeaderString[3] = "\"RawTokenCount\"";

                    foreach(var token in RetainedWords)
                    {
                        HeaderString[token.Value + HeaderLead] = "\"" + token.Key.Replace("\"", "\"\"") + "\"";
                    }

                    //write all of the headers
                    foreach (var Logger in DTM_Loggers)
                    {
                        Logger.Value.WriteString(string.Join(",", HeaderString));
                    }


                    Parallel.ForEach(File.ReadLines(DWL_Output_Location, BGData.SelectedEncoding), (line, state) =>
                    {

                        if (BGWorker.CancellationPending) state.Break();

                        //read the line and convert into JSON object
                        Dictionary<string, Dictionary<string, long>> JSON_Data = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, long>>>(line);
                        Dictionary<string, long> Filename_WC = JSON_Data["Filename"];
                        Dictionary<string, long> FileInfo = JSON_Data["FileInfo"];
                        Dictionary<string, long> TokenInfo = JSON_Data["TokenInfo"];

                        if (Filename_WC.Values.ToArray()[0] > BGData.MinWC)
                        {

                            string[] BinaryOutputString = new string[HeaderLead + NGramCount];
                            BinaryOutputString[0] = "\"" + Filename_WC.Keys.ToArray()[0].ToString().Replace("\"", "\"\"") + "\"";
                            BinaryOutputString[1] = FileInfo["Segment"].ToString();
                            BinaryOutputString[2] = Filename_WC.Values.ToArray()[0].ToString();
                            BinaryOutputString[3] = FileInfo["RawTokenCount"].ToString();

                            string[] VerboseOutputString = new string[HeaderLead + NGramCount];
                            VerboseOutputString[0] = "\"" + Filename_WC.Keys.ToArray()[0].ToString().Replace("\"", "\"\"") + "\"";
                            VerboseOutputString[1] = FileInfo["Segment"].ToString();
                            VerboseOutputString[2] = Filename_WC.Values.ToArray()[0].ToString();
                            VerboseOutputString[3] = FileInfo["RawTokenCount"].ToString();

                            string[] RawDTMOutputString = new string[HeaderLead + NGramCount];
                            RawDTMOutputString[0] = "\"" + Filename_WC.Keys.ToArray()[0].ToString().Replace("\"", "\"\"") + "\"";
                            RawDTMOutputString[1] = FileInfo["Segment"].ToString();
                            RawDTMOutputString[2] = Filename_WC.Values.ToArray()[0].ToString();
                            RawDTMOutputString[3] = FileInfo["RawTokenCount"].ToString();


                            for (int i = 0; i < NGramCount; i++)
                            {
                                BinaryOutputString[i + HeaderLead] = "0";
                                VerboseOutputString[i + HeaderLead] = "0";
                                RawDTMOutputString[i + HeaderLead] = "0";
                            }

                            foreach(var token in TokenInfo)
                            {
                                if (RetainedWords.ContainsKey(token.Key))
                                {
                                    if (BGData.GenerateBinary) BinaryOutputString[HeaderLead + RetainedWords[token.Key]] = "1";
                                    if (BGData.GenerateRawDTM) RawDTMOutputString[HeaderLead + RetainedWords[token.Key]] = token.Value.ToString();
                                    if (BGData.GenerateVerbose) VerboseOutputString[HeaderLead + RetainedWords[token.Key]] = Math.Round((token.Value / (double)FileInfo["RawTokenCount"]) * 100, 5, mode: MidpointRounding.AwayFromZero).ToString();
                                }
                            }

                            if (BGData.GenerateBinary) DTM_Loggers["Binary"].WriteString(string.Join(",", BinaryOutputString));
                            if (BGData.GenerateRawDTM) DTM_Loggers["DTM"].WriteString(string.Join(",", RawDTMOutputString));
                            if (BGData.GenerateVerbose) DTM_Loggers["Verbose"].WriteString(string.Join(",", VerboseOutputString));

                        }

                        var currIndex = Interlocked.Increment(ref filecounter);
                        BGWorker.ReportProgress((int)filecounter);


                    });

                    foreach(var DTM_Logger in DTM_Loggers)
                    {
                        DTM_Logger.Value.Dispose();
                    }

                    BGWorker.ReportProgress((int)NumberOfRows);

                    LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Finished writing Document × Term output...", Color.Green);


                }



            }
            catch (OutOfMemoryException OOMexception)
            {
                LogWindowWriter LogWriter = new LogWindowWriter();
                LogWriter.setmainform(this);
                LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Your system does not have enough memory to continue. " +
                    "If you are processing a high number of N-grams (e.g., 5-grams or higher), this is the most common cause of running out of memory. You can try " +
                    "lowering your N-gram selection, or perhaps make sure that Frequency List Pruning is enabled.", Color.Red);

                MessageBox.Show("Your system does not have enough memory to continue. Please check the log for additional details.", "Out of Memory Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            catch (Exception ex)
            {
                LogWindowWriter LogWriter = new LogWindowWriter();
                LogWriter.setmainform(this);
                LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": MEH encountered an error while processing your texts. ", color: Color.Red);
                LogWriter.WriteToLog(Environment.NewLine + ex.Message, color: Color.Red);
                LogWriter.WriteToLog(Environment.NewLine + ex.ToString(), color: Color.Red);
                    //"" +
                    //"The most common causes of errors are:", color: Color.Red);
                //LogWriter.WriteToLog("\t-Opening a file that MEH is currently reading/writing", Color.Red);
                //LogWriter.WriteToLog("\t-Moving/deleting a file during use", Color.Red);

                MessageBox.Show("MEH encountered a problem while analyzing your texts. Please check the log for additional details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            //end of bgworker.dowork()
        }









        //  ____                       _     ____                                    
        // |  _ \ ___ _ __   ___  _ __| |_  |  _ \ _ __ ___   __ _ _ __ ___  ___ ___ 
        // | |_) / _ \ '_ \ / _ \| '__| __| | |_) | '__/ _ \ / _` | '__/ _ \/ __/ __|
        // |  _ <  __/ |_) | (_) | |  | |_  |  __/| | | (_) | (_| | | |  __/\__ \__ \
        // |_| \_\___| .__/ \___/|_|   \__| |_|   |_|  \___/ \__, |_|  \___||___/___/
        //           |_|                                     |___/                   

        private void BGWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //since the threads aren't being completed in a specific order, we really only want to update the bar
            //if the current value is greater than what has already been reported
            if ((e.ProgressPercentage > ProgressBar.Value) && (e.ProgressPercentage > ((ProgressBar.Maximum / 1000.00) + ProgressBar.Value))) ProgressBar.Value = e.ProgressPercentage;


            //going to remove these reports so that we can avoid the DisconnectedContext exception that keeps getting tossed
            //particularly since this exception isn't being handled by anything, apparently. probably flooding something
            //with the richtextbox, but I'm not actually sure at the moment
            //try
            //{

            //    if (e.ProgressPercentage % 10000 == 0)
            //    {
            //        int BoxStart = RichTextboxLog.Text.Length;
            //        RichTextboxLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + " ~" + e.ProgressPercentage.ToString() + " items processed thus far" + Environment.NewLine);
            //        int BoxEnd = RichTextboxLog.Text.Length;
            //        RichTextboxLog.Select(BoxStart, BoxEnd - BoxStart);
            //        RichTextboxLog.SelectionColor = Color.White;
            //        RichTextboxLog.Select(BoxEnd, 0);
            //        RichTextboxLog.ScrollToCaret();
            //    }
            //}
            //catch
            //{
            //    //do nothing if there's an issue here, it's not that central that the log be updated
            //}
        }


        //  ____   ______        __         _                ____                      _      _       
        // | __ ) / ___\ \      / /__  _ __| | _____ _ __   / ___|___  _ __ ___  _ __ | | ___| |_ ___ 
        // |  _ \| |  _ \ \ /\ / / _ \| '__| |/ / _ \ '__| | |   / _ \| '_ ` _ \| '_ \| |/ _ \ __/ _ \
        // | |_) | |_| | \ V  V / (_) | |  |   <  __/ |    | |__| (_) | | | | | | |_) | |  __/ ||  __/
        // |____/ \____|  \_/\_/ \___/|_|  |_|\_\___|_|     \____\___/|_| |_| |_| .__/|_|\___|\__\___|
        //                                                                      |_|                   

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (BGWorker.IsBusy)
            {
                if (!BGWorker.CancellationPending) BGWorker.CancelAsync();

                LogWindowWriter LogWriter = new LogWindowWriter();
                LogWriter.setmainform(this);
                LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Cancellation button has been clicked. Cancelling...", Color.Yellow);
            }
            else
            {
                var result = MessageBox.Show("Are you sure that you want to clear the output window?", "Clear Output Window?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) RichTextboxLog.Text = "";
            }

        }




        //  ____  _           _     _         _______             _     _         ____            _             _     
        // |  _ \(_)___  __ _| |__ | | ___   / / ____|_ __   __ _| |__ | | ___   / ___|___  _ __ | |_ _ __ ___ | |___ 
        // | | | | / __|/ _` | '_ \| |/ _ \ / /|  _| | '_ \ / _` | '_ \| |/ _ \ | |   / _ \| '_ \| __| '__/ _ \| / __|
        // | |_| | \__ \ (_| | |_) | |  __// / | |___| | | | (_| | |_) | |  __/ | |__| (_) | | | | |_| | | (_) | \__ \
        // |____/|_|___/\__,_|_.__/|_|\___/_/  |_____|_| |_|\__,_|_.__/|_|\___|  \____\___/|_| |_|\__|_|  \___/|_|___/
        //                                                                                                            


        public void DisableAllControls()
        {
            StartButton.Enabled = false;
            foreach (TabPage Tab in TabControlObject.TabPages)
            {
                if (Tab.Name != "BeginAnalysisTab" && Tab.Name != "AboutMEHTab")
                {
                    foreach (Control control in Tab.Controls)
                    {
                        control.Enabled = false;
                    }
                }
            }
        }

        public void EnableAllControls()
        {
            StartButton.Enabled = true;

            string[] ControlsToKeepDisabled = new string[] { "InputFolderTextbox", "OutputFileTextbox",
                                                             "PregeneratedDWLTextbox", "DocumentWordListsOutputCheckbox", "InputSpreadsheetTextbox" };
            foreach (TabPage Tab in TabControlObject.TabPages)
            {
                if (Tab.Name != "BeginAnalysisTab" && Tab.Name != "AboutMEHTab")
                {
                    foreach (Control control in Tab.Controls)
                    {
                        if (!ControlsToKeepDisabled.Contains(control.Name)) control.Enabled = true;
                    }
                }
            }
        }



        //  ____   ______        __         _               ____               ____                      _      _           _ 
        // | __ ) / ___\ \      / /__  _ __| | _____ _ __  |  _ \ _   _ _ __  / ___|___  _ __ ___  _ __ | | ___| |_ ___  __| |
        // |  _ \| |  _ \ \ /\ / / _ \| '__| |/ / _ \ '__| | |_) | | | | '_ \| |   / _ \| '_ ` _ \| '_ \| |/ _ \ __/ _ \/ _` |
        // | |_) | |_| | \ V  V / (_) | |  |   <  __/ |    |  _ <| |_| | | | | |__| (_) | | | | | | |_) | |  __/ ||  __/ (_| |
        // |____/ \____|  \_/\_/ \___/|_|  |_|\_\___|_|    |_| \_\\__,_|_| |_|\____\___/|_| |_| |_| .__/|_|\___|\__\___|\__,_|
        //                                                                                        |_|                         


        private void BGWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            RichTextboxLog.SelectionColor = Color.LimeGreen;
            RichTextboxLog.AppendText(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + "--> Finished processing all data." + Environment.NewLine);
            RichTextboxLog.Select(RichTextboxLog.Text.Length, 0);
            RichTextboxLog.ScrollToCaret();
            MessageBox.Show("MEH has finished processing your texts.", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Information);
            EnableAllControls();

        }

        private void AboutMEHPictureBox_DoubleClick(object sender, EventArgs e)
        {

            SoundPlayer simpleSound = new SoundPlayer(MEHv2.Properties.Resources._switch);
            simpleSound.Play();
        }

        // __        __    _ _         _          _                 __        ___           _               
        // \ \      / / __(_) |_ ___  | |_ ___   | |    ___   __ _  \ \      / (_)_ __   __| | _____      __
        //  \ \ /\ / / '__| | __/ _ \ | __/ _ \  | |   / _ \ / _` |  \ \ /\ / /| | '_ \ / _` |/ _ \ \ /\ / /
        //   \ V  V /| |  | | ||  __/ | || (_) | | |__| (_) | (_| |   \ V  V / | | | | | (_| | (_) \ V  V / 
        //    \_/\_/ |_|  |_|\__\___|  \__\___/  |_____\___/ \__, |    \_/\_/  |_|_| |_|\__,_|\___/ \_/\_/  
        //                                                   |___/                                          

        public class LogWindowWriter
        {

            MainForm mainform { get; set; }

            public void setmainform(MainForm form)
            {
                mainform = form;
            }

            public void WriteToLog(string text_to_log, Color color)
            {

                    //report that we're getting ready to start
                    mainform.Invoke((MethodInvoker)delegate ()
                    {
                        int BoxStart = mainform.RichTextboxLog.Text.Length;
                        mainform.RichTextboxLog.AppendText(text_to_log + Environment.NewLine);
                        int BoxEnd = mainform.RichTextboxLog.Text.Length;
                        mainform.RichTextboxLog.Select(BoxStart, BoxEnd - BoxStart);
                        mainform.RichTextboxLog.SelectionColor = color;
                        mainform.RichTextboxLog.Select(BoxEnd, 0);
                        mainform.RichTextboxLog.ScrollToCaret();
                    });


            }

        }

        private void ClearDWLSelectionButton_Click(object sender, EventArgs e)
        {
            PregeneratedDWLTextbox.Text = "";
        }






        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {


            //this can be used to store what the last state was -- all of the user changes to the forms, etc.
            //currently not going to implement, but maybe at a later date

            //MEHv2.Properties.Settings.Default["SelectedEncoding"] = EncodingDropdown.SelectedItem.ToString();

            ////segmentation tab
            //if (SegmentationOptionNone.Checked) MEHv2.Properties.Settings.Default["SegmentationType"] = "NoSegmentation";
            //if (SegmentationOptionEqualSegments.Checked) MEHv2.Properties.Settings.Default["SegmentationType"] = "N_Equal_Segments";
            //if (SegmentationOptionWordsPerSegment.Checked) MEHv2.Properties.Settings.Default["SegmentationType"] = "Words_Per_Segment";
            //if (SegmentationOptionRegex.Checked) MEHv2.Properties.Settings.Default["SegmentationType"] = "Regex";
            
            //MEHv2.Properties.Settings.Default["SegmentationParameter"] = SegmentationParameterTextbox.Text;

            ////conversions tab
            //MEHv2.Properties.Settings.Default["ConversionListString"] = ConversionsTextbox.Text;
            //MEHv2.Properties.Settings.Default["ConversionList_LookupMethod"] = Conversions_Use_Lookup_Checkbox.Checked;

            ////stop list tab
            //MEHv2.Properties.Settings.Default["StopListString"] = StopListTextbox.Text;

            ////dictionary list tab
            //MEHv2.Properties.Settings.Default["DictionaryListString"] = DictionaryListTextbox.Text;
            //MEHv2.Properties.Settings.Default["RetainOnlyDictionaryWords"] = KeepOnlyDictionaryWordsCheckbox.Checked;

            ////lemmatization tab
            //MEHv2.Properties.Settings.Default["Tokenizer"] = TokenizerSelectionDropdown.SelectedItem.ToString();
            //MEHv2.Properties.Settings.Default["ConvertToLowerCase"] = ConvertToLowercaseCheckbox.Checked;
            //MEHv2.Properties.Settings.Default["UseLemmatization"] = UseLemmatizationCheckbox.Checked;
            //MEHv2.Properties.Settings.Default["LemmatizationModel"] = LemmatizerLanguageSelector.SelectedItem.ToString();

            ////output file types tab
            //MEHv2.Properties.Settings.Default["GenerateDWL"] = DocumentWordListsOutputCheckbox.Checked;
            //MEHv2.Properties.Settings.Default["GenerateFreqList"] = FrequencyListCheckbox.Checked;
            //MEHv2.Properties.Settings.Default["PruneFreqList"] = PruneFreqListCheckbox.Checked;
            //MEHv2.Properties.Settings.Default["FreqListPruneCycle"] = PruneFreqListParameterTextbox.Text;
            //MEHv2.Properties.Settings.Default["GenerateBinary"] = BinaryOutputCheckbox.Checked;
            //MEHv2.Properties.Settings.Default["GenerateVerbose"] = VerboseOutputCheckbox.Checked;
            //MEHv2.Properties.Settings.Default["GenerateRawDTM"] = RawOutputCheckbox.Checked;
            //MEHv2.Properties.Settings.Default["GenerateTFIDF"] = TFIDFOutputCheckbox.Checked;

            ////n-gram / output thresholds tab
            //MEHv2.Properties.Settings.Default["MinWC"] = MinimumWCTextbox.Text;
            //MEHv2.Properties.Settings.Default["Ngram_N_Min"] = NgramTextboxMinimum.Text;
            //MEHv2.Properties.Settings.Default["Ngram_N_Max"] = NgramTextboxMaximum.Text;

            //if (ThresholdOptionMostFrequentByPercentOfDocuments.Checked) MEHv2.Properties.Settings.Default["ThresholdType"] = "TopNDocumentFrequency";
            //if (ThresholdOptionMostFrequentByRawFrequency.Checked) MEHv2.Properties.Settings.Default["ThresholdType"] = "TopNRawFrequency";
            //if (ThresholdOptionPercentOfDocuments.Checked) MEHv2.Properties.Settings.Default["ThresholdType"] = "PercentOfDocs";
            //if (ThresholdOptionRawFreq.Checked) MEHv2.Properties.Settings.Default["ThresholdType"] = "GreaterThanRawFrequencyX";

            
            //MEHv2.Properties.Settings.Default["NgramThresholdParameter"] = ThresholdParameterTextbox.Text;

            //MEHv2.Properties.Settings.Default.Save();

        }








        private int[] CSV_ID_Indices = new int[0];
        private int[] CSV_Text_Indices = new int[0];
        private bool CSV_AnalyzingSpreadsheet = false;
        private bool CSVSeparateColumns = false;


        private void ChooseSpreadsheetButton_Click(object sender, EventArgs e)
        {

            this.CSV_AnalyzingSpreadsheet = false;
            CSV_ID_Indices = new int[0];
            CSV_Text_Indices = new int[0];

            InputSpreadsheetTextbox.Text = "";
            InputFolderTextbox.Text = "";

            if (CSVDelimiterTextbox.TextLength < 1 || CSVQuoteTextbox.TextLength < 1)
            {
                MessageBox.Show("You must enter characters for your delimiter and quotes, respectively. MEH does not know how to read a delimited spreadsheet without this information.", "I need details for your spreadsheet!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            OpenFileDialog SpreadsheetChooser = new OpenFileDialog();
            SpreadsheetChooser.FileName = "Dataset.csv";
            SpreadsheetChooser.Multiselect = false;
            SpreadsheetChooser.RestoreDirectory = true;
            SpreadsheetChooser.Filter = "Delimited Spreadsheet | *.txt; *.csv; *.tsv";
            SpreadsheetChooser.Title = "Please select the spreadsheet that you would like to analyze";

            string filename = "";

            if (SpreadsheetChooser.ShowDialog() == DialogResult.OK)
            {
                filename = SpreadsheetChooser.FileName;




                try
                {
                    using (var stream = File.OpenRead(filename))
                    using (var reader = new StreamReader(stream))
                    {
                        var data = MEHv2.CsvParser.ParseHeadAndTail(reader, CSVDelimiterTextbox.Text[0], CSVQuoteTextbox.Text[0]);

                        var header = data.Item1;
                        var lines = data.Item2;

                        MEHv2.CSVDetailsForm CSVDetails = new MEHv2.CSVDetailsForm(header.ToArray<string>());

                        var CSVDetailsResults = CSVDetails.ShowDialog();

                        if (CSVDetailsResults == DialogResult.OK)
                        {

                            if (CSVDetails.CSVDetailsDialogResult["Text"].Length >= 1) { 

                                InputSpreadsheetTextbox.Text = filename;
                                CSV_AnalyzingSpreadsheet = true;
                                this.CSV_ID_Indices = CSVDetails.CSVDetailsDialogResult["ID"];
                                this.CSV_Text_Indices = CSVDetails.CSVDetailsDialogResult["Text"];
                                this.CSVSeparateColumns = CSVDetails.ColumnsAsSeparateTexts;
                            }
                            else
                            {
                                MessageBox.Show("It does not appear as though you have selected any columns for your Texts. MEH needs at least one Text column before it can analyze your spreadsheet.", "No selections made!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            CSV_AnalyzingSpreadsheet = false;
                        }


                    }

                }
                catch
                {
                    CSV_AnalyzingSpreadsheet = false;
                    MessageBox.Show("There was an error while trying to read your spreadsheet file. It is possible that your spreadsheet is not correctly formatted, or that your selections for delimiters and quotes are not the same as what is used in your spreadsheet.", "Error reading spreadsheet", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                
            }


        }

        private void ProcessingPowerTrackbar_Scroll(object sender, EventArgs e)
        {
            if (ProcessingPowerTrackbar.Value > 75)
            {
                ProcessingPowerLabel.ForeColor = Color.Red;
                ProcessingPowerLabel.Text = ProcessingPowerTrackbar.Value.ToString() + "% (NOT RECOMMENDED)";
            }
            else if (ProcessingPowerTrackbar.Value == 75)
            {
                ProcessingPowerLabel.ForeColor = Color.Black;
                ProcessingPowerLabel.Text = ProcessingPowerTrackbar.Value.ToString() + "% (Recommended)";
            }
            else
            {
                ProcessingPowerLabel.ForeColor = Color.Black;
                ProcessingPowerLabel.Text = ProcessingPowerTrackbar.Value.ToString() + "%";
            }
        }



    }

}

