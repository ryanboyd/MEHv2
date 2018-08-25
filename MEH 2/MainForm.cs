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


namespace MEH2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


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
            "Türkçe (Turkish)"});

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

            StopListLanguageSelector.SelectedIndex = 0;
            ConversionSelectionBox.SelectedIndex = 0;
            LemmatizerLanguageSelector.SelectedIndex = 0;

            StopListTextbox.Text += MEHv2.Properties.Resources.StopListCharacters + Environment.NewLine + MEHv2.Properties.Resources.stoplist_english.ToLower();
            ConversionsTextbox.Text = MEHv2.Properties.Resources.conversions.ToLower();

        }







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


            using (var dialog = new FolderBrowserDialog())
            {
                if (OutputFileTextbox.Text != "") dialog.SelectedPath = OutputFileTextbox.Text;
                dialog.ShowNewFolderButton = false;
                dialog.Description = "Please choose the folder where your output will be saved";
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
                if (InputFolderTextbox.Text != "") dialog.SelectedPath = InputFolderTextbox.Text;
                dialog.ShowNewFolderButton = true;
                dialog.Description = "Please choose the location of your .txt files to analyze";
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
                    StopListTextbox.Text = MEHv2.Properties.Resources.bulgarianST.ToLower();
                    break;

                case "čeština (Czech)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.czechstoplist.ToLower();
                    break;

                case "français (French)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.frenchstoplist.ToLower();
                    break;

                case "Deutsch (German)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.germanstoplist.ToLower();
                    break;

                case "Magyar (Hungarian)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.hungarianST.ToLower();
                    break;

                case "italiano (Italian)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.italianstoplist.ToLower();
                    break;

                case "فارسی (Persian)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.persianST.ToLower();
                    break;

                case "polski (Polish)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.polishST.ToLower();
                    break;

                case "Pyccĸий (Russian)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.russianstoplist.ToLower();
                    break;

                case "Español (Spanish)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.spanishstoplist.ToLower();
                    break;

                case "Türkçe (Turkish)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.turkishstoplist.ToLower();
                    break;

                case "English (Mallet Stop List)":
                    StopListTextbox.Text = MEHv2.Properties.Resources.stoplist_mallet_en.ToLower();
                    break;

            }
        }

        private void LoadConversionsButton_Click(object sender, EventArgs e)
        {
            switch (StopListLanguageSelector.SelectedItem.ToString())
            {
                case "English":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.conversions.ToLower();
                    break;

                case "Türkçe (Turkish)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.default_conversions_turkish.ToLower();
                    break;

                case "italiano (Italian)":
                    ConversionsTextbox.Text = MEHv2.Properties.Resources.default_conversions_italian.ToLower();
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
                BGData.OutputFileLocation = OutputFileTextbox.Text;
                BGData.SelectedEncoding = Encoding.GetEncoding(EncodingDropdown.SelectedItem.ToString());
                BGData.RetainOnlyDictionaryWords = KeepOnlyDictionaryWordsCheckbox.Checked;

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
                BGData.SegmentationParameter = SegmentationParameterTextbox.Text;

                BGData.ConvertToLowerCase = ConvertToLowercaseCheckbox.Checked;
                BGData.UseLemmatization = UseLemmatizationCheckbox.Checked;
                BGData.LemmatizationModel = LemmatizerLanguageSelector.SelectedItem.ToString();

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


                int NumberOfFiles = 0;

                //make sure that we set up the progressbar

                if (BGData.PreExistingDWL_Location == "")
                {

                    this.Invoke((MethodInvoker)delegate ()
                    {

                        var files = Directory.EnumerateFiles(BGData.TextFileFolder, "*.txt", BGData.FolderSearchDepth);

                        RichTextboxLog.SelectionColor = Color.White;
                        RichTextboxLog.AppendText(Environment.NewLine + "Counting number of files... please wait..." + Environment.NewLine);
                        ProgressBar.Minimum = 0;


                        foreach (string filecount in files) {
                            NumberOfFiles++;
                            if (NumberOfFiles % 10000 == 0)
                            {

                                int BoxStart = RichTextboxLog.Text.Length;
                                RichTextboxLog.AppendText("Counting number of files... " + NumberOfFiles.ToString() + Environment.NewLine);
                                int BoxEnd = RichTextboxLog.Text.Length;
                                RichTextboxLog.Select(BoxStart, BoxEnd - BoxStart);
                                RichTextboxLog.SelectionColor = Color.White;
                                RichTextboxLog.Select(BoxEnd, 0);
                                RichTextboxLog.ScrollToCaret();
                            }
                        }

                        RichTextboxLog.SelectionColor = Color.White;
                        RichTextboxLog.AppendText("Found " + NumberOfFiles.ToString() + " files... " + Environment.NewLine);
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
                //                                                                    |___/                   



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



                //report that we're getting ready to start
                LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + "Initializing / validating all items in Conversions box...", Color.Orange);
                TextConversionClass Converter = new TextConversionClass();
                Converter.InitializeConversionList(BGData.ConversionListString, BGData.ConvertToLowerCase);



                //temporary list used for finding words that the lemmatizer converts into "token+not"
               //List<string> notlist = new List<string>();




                //  ____             _         _____     _              _          _   _             
                // | __ )  ___  __ _(_)_ __   |_   _|__ | | _____ _ __ (_)______ _| |_(_) ___  _ __  
                // |  _ \ / _ \/ _` | | '_ \    | |/ _ \| |/ / _ \ '_ \| |_  / _` | __| |/ _ \| '_ \ 
                // | |_) |  __/ (_| | | | | |   | | (_) |   <  __/ | | | |/ / (_| | |_| | (_) | | | |
                // |____/ \___|\__, |_|_| |_|   |_|\___/|_|\_\___|_| |_|_/___\__,_|\__|_|\___/|_| |_|
                //             |___/                                                                 

                if (BGData.PreExistingDWL_Location == "") {

                    ThreadsafeOutputWriter OutputWriter = new ThreadsafeOutputWriter(DWL_Output_Location, BGData.SelectedEncoding);

                    var files = Directory.EnumerateFiles(BGData.TextFileFolder, "*.txt", BGData.FolderSearchDepth);

                    //report that we're getting ready to start
                    LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + "Preprocessing and Tokenizing all texts...", Color.LightBlue);



                    Parallel.ForEach(files, new ParallelOptions { MaxDegreeOfParallelism = (int)System.Math.Floor((double)(Environment.ProcessorCount / 1.25)) }, (inputfile, state) =>
                    {

                        if (BGWorker.CancellationPending) state.Break();

                        var currIndex = Interlocked.Increment(ref filecounter);







                        //read our input
                        string readText = File.ReadAllText(inputfile, BGData.SelectedEncoding).Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ");
                        if (BGData.ConvertToLowerCase) readText = readText.ToLower();

                        //run the conversions from the converter
                        readText = Converter.RunConversions(readText);






                        //tokenize the text
                        string[] TokenizedText = Tokenizer.tokenize(readText, preserve_case: BGData.ConvertToLowerCase == false, reduce_lengthening: true);



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

                        for (int segment_number = 0; segment_number < SegmentedTokenText.Length; segment_number++) {


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


                            //General nested look to fill out our dictionary with ngrams
                            for (long i = 0; i < TokenizedText_For_Ngrams.Length; i++)
                            {
                                //builds our ngrams...
                                for (int j = BGData.Ngram_N_Max; j > BGData.Ngram_N_Min - 1; j--)
                                {
                                    if (i + j <= TokenizedText_For_Ngrams.Length)
                                    {
                                        string[] token_builder = new string[j];
                                        Array.Copy(TokenizedText_For_Ngrams, i, token_builder, 0, j);

                                        string token = string.Join(" ", token_builder);



                                        if (FileTokenData["TokenInfo"].ContainsKey(token))
                                        {
                                            FileTokenData["TokenInfo"][token]++;
                                        }
                                        else
                                        {
                                            FileTokenData["TokenInfo"].Add(token, 1);
                                        }

                                    }
                                }


                            }


                            //write output to ndjson file
                            string outputline = JsonConvert.SerializeObject(FileTokenData);
                            OutputWriter.WriteString(outputline);
                        }


                        BGWorker.ReportProgress((int)filecounter);


                    });

                    OutputWriter.Dispose();
                    LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Tokenization Complete.", Color.Green);
                }
                //if we have a pre-generated DWL, we do this instead:
                else
                {

                    DWL_Output_Location = BGData.PreExistingDWL_Location;
                    LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + "Skipping Document-Word List (DWL) generation and using the pre-generated DWL instead.", Color.HotPink);

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

                if (BGData.GenerateFreqList)
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

                            if (NumberOfRows % 1000 == 0) LogWriter.WriteToLog(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Reading DWL row #" + NumberOfRows.ToString(), Color.White);

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


                    LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": Finished writing Document × Term output...", Color.Green);


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
            catch
            {
                LogWindowWriter LogWriter = new LogWindowWriter();
                LogWriter.setmainform(this);
                LogWriter.WriteToLog(Environment.NewLine + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": MEH encountered an error while processing your texts. " +
                    "Currently, MEH is in active development; forthcoming versions of this software will provide additional information on the likely causes of any given error that you receive. The most common causes of errors are:", color: Color.Red);
                LogWriter.WriteToLog("\t-Opening a file that MEH is currently reading/writing", Color.Red);
                LogWriter.WriteToLog("\t-Moving/deleting a file during use", Color.Red);

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
            if (e.ProgressPercentage > ProgressBar.Value) ProgressBar.Value = e.ProgressPercentage;


            try
            {

                if (e.ProgressPercentage % 1000 == 0)
                {
                    int BoxStart = RichTextboxLog.Text.Length;
                    RichTextboxLog.AppendText(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss tt") + ": " + " ~" + e.ProgressPercentage.ToString() + " items processed thus far" + Environment.NewLine);
                    int BoxEnd = RichTextboxLog.Text.Length;
                    RichTextboxLog.Select(BoxStart, BoxEnd - BoxStart);
                    RichTextboxLog.SelectionColor = Color.White;
                    RichTextboxLog.Select(BoxEnd, 0);
                    RichTextboxLog.ScrollToCaret();
                }
            }
            catch
            {
                //do nothing if there's an issue here, it's not that central that the log be updated
            }
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
                                                             "PregeneratedDWLTextbox", "DocumentWordListsOutputCheckbox" };
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


    }
}

