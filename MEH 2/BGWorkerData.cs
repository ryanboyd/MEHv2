using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Text.RegularExpressions;

namespace MEH2
{
    public class BGWorkerData
    {

        //from the input file tab
        public string TextFileFolder { get; set; }
        public bool AnalyzingSpreadsheet { get; set; }
        public string CSVFilePath { get; set; }
        public char CSVDelimiter { get; set; }
        public char CSVQuote { get; set; }
        public bool CSVSeparateColumns { get; set; }
        public int[] CSV_Text_Indices { get; set; }
        public int[] CSV_ID_Indices { get; set; }
        public Encoding SelectedEncoding { get; set; }
        public System.IO.SearchOption FolderSearchDepth { get; set; }

        //Output and Processing Power Tab
        public string OutputFileLocation { get; set; }
        public int ProcessingPower { get; set; }

        //segmentation tab
        public string SegmentationType { get; set; }
        public string SegmentationParameter { get; set; }

        //conversions tab
        public string ConversionListString { get; set; }
        public bool ConversionList_LookupMethod { get; set; }

        //stop list tab
        public string StopListString { get; set; }

        //dictionary list tab
        public string DictionaryListString { get; set; }
        public bool RetainOnlyDictionaryWords { get; set; }

        //lemmatization tab
        public string Tokenizer { get; set; }
        public bool ConvertToLowerCase { get; set; }
        public bool UseLemmatization { get; set; }
        public string LemmatizationModel { get; set; }

        //output file types tab
        public bool GenerateDWL { get; set; }
        public bool GenerateFreqList { get; set; }
        public bool PruneFreqList { get; set; }
        public double FreqListPruneCycle {get; set; }
        public bool GenerateBinary { get; set; }
        public bool GenerateVerbose { get; set; }
        public bool GenerateRawDTM { get; set; }
        public bool GenerateTFIDF { get; set; }

        public string PreExistingDWL_Location { get; set; }

        //n-gram / output thresholds tab
        public int MinWC { get; set; }
        public int Ngram_N_Min { get; set; }
        public int Ngram_N_Max { get; set; }
        public string ThresholdType { get; set; }
        public double NgramThresholdParameter { get; set; }



        public List<Tuple<string, bool, Color>> Validations_Uncontested()
        {
            List<Tuple<string, bool, Color>> ValidationList = new List<Tuple<string, bool, Color>>();

            ValidationList.Add(new Tuple<string, bool, Color> ("Checking encoding selection: OK", true, Color.Green) );
            ValidationList.Add(new Tuple<string, bool, Color>("Checking subfolder selection: OK", true, Color.Green));
            ValidationList.Add(new Tuple<string, bool, Color>("Checking lowercase selection: OK", true, Color.Green));
            ValidationList.Add(new Tuple<string, bool, Color>("Checking lemmatization selection: OK", true, Color.Green));
            ValidationList.Add(new Tuple<string, bool, Color>("Checking stoplist: OK", true, Color.Green));
            ValidationList.Add(new Tuple<string, bool, Color>("Checking dictionary list: OK", true, Color.Green));
            ValidationList.Add(new Tuple<string, bool, Color>("Checking output type selections: OK", true, Color.Green));

            return ValidationList;

        }






        public Tuple<string, bool, Color> ValidateInputFolder(string inputfolder)
        {

            if (AnalyzingSpreadsheet)
            {
                return new Tuple<string, bool, Color>("Input data selection: Spreadsheet: OK", true, Color.Green);
            }
            else if (inputfolder != "")
            {
                return new Tuple<string, bool, Color>("Input data selection: Folder/.txt: OK", true, Color.Green);
            }
            else if (PreExistingDWL_Location != "")
            {
                return new Tuple<string, bool, Color>("Checking input folder: Skipping... Pre-generated DWL will be used.", true, Color.HotPink);
            }
            else
            {
                return new Tuple<string, bool, Color>("Checking input folder: Error." + Environment.NewLine + "Please choose an input folder or spreadsheet file from the \"Input File Settings\" tab.", false, Color.Red);
            }
        }






        public Tuple<string, bool, Color> ValidateOutputFolder(string outputfolder)
        {
            if (outputfolder != "")
            {
                return new Tuple<string, bool, Color>("Checking output folder: OK", true, Color.Green);
            }
            else
            {
                return new Tuple<string, bool, Color>("Checking output folder: Error." + System.Environment.NewLine + "Please choose an output folder from the \"Output File Settings\" tab.", false, Color.Red);

            }
        }






        public Tuple<string, bool, Color> ValidateSegmentationOptions (string segmentationtype, string segmentationparameter)
        {
            if (segmentationtype != "NoSegmentation")
            {
                if (segmentationtype == "Regex")
                {
                    try
                    {
                        Regex.Match("", segmentationparameter);
                        return new Tuple<string, bool, Color>("Checking Segmentation Options: OK", true, Color.Green);
                    }
                    catch
                    {
                        return new Tuple<string, bool, Color>("Checking Segmentation Options: Error." + Environment.NewLine + "The regular expression that is being used in your Segmentation Options does not appear to be valid.", false, Color.Red);
                    }
                }
                else if (segmentationtype == "N_Equal_Segments")
                {
                    bool isNumeric = int.TryParse(segmentationparameter.Trim(), out int n);
                    if (isNumeric)
                    {
                        return new Tuple<string, bool, Color>("Checking Segmentation Options: OK", true, Color.Green);
                    }
                    else
                    {
                        return new Tuple<string, bool, Color>("Checking Segmentation Options: Error." + Environment.NewLine + "The number that is being used in your Segmentation Options needs to be an integer.", false, Color.Red);
                    }
                }
                else
                {
                    //this is if segmentation type is "Words_Per_Segment"
                    bool isNumeric = int.TryParse(segmentationparameter.Trim(), out int n);
                    if (isNumeric)
                    {
                        return new Tuple<string, bool, Color>("Checking Segmentation Options: OK", true, Color.Green);
                    }
                    else
                    {
                        return new Tuple<string, bool, Color>("Checking Segmentation Options: Error." + Environment.NewLine + "The number that is being used in your Segmentation Options needs to be an integer.", false, Color.Red);
                    }
                }
            }
            else
            {
                return new Tuple<string, bool, Color>("Checking Segmentation Options: OK", true, Color.Green);
            }
        }






        public Tuple<string, bool, Color> ValidateThresholdOptions(string thresholdtype, string thresholdparameter)
        {
            if (thresholdtype == "TopNDocumentFrequency" || thresholdtype == "TopNRawFrequency")
            {
                if (int.TryParse(thresholdparameter.Trim(), out int n))
                {
                    return new Tuple<string, bool, Color>("Checking Threshold Options: OK", true, Color.Green);
                }
                else
                {
                    return new Tuple<string, bool, Color>("Checking Threshold Options: Error." + Environment.NewLine + "For the threshold option that you have chosen, you must use an integer as your parameter. For example, if you want to retain the 1000 most frequent n-grams, you must use 1000 as your \"X\" value on the N-gram Settings tab.", false, Color.Red);
                }
            }
            else
            {
                //for when thresholdtype == "PercentOfDocs" || "GreaterThanRawFrequencyX"
                if (double.TryParse(thresholdparameter.Trim(), out double n) && double.Parse(thresholdparameter) >= 0 && double.Parse(thresholdparameter) <= 100)
                {
                    return new Tuple<string, bool, Color>("Checking Threshold Options: OK", true, Color.Green);
                }
                else
                {
                    return new Tuple<string, bool, Color>("Checking Threshold Options: Error." + Environment.NewLine + "For the threshold option that you have chosen, you must use a number between 0 and 100 as your parameter. For example, if you want to retain N-grams that appear in at least 7.5% of all documents, you must use 7.5 as your \"X\" value on the N-gram Settings tab.", false, Color.Red);
                }
            }
        }






        public Tuple<string, bool, Color> ValidateWC(string WC)
        {
            if (int.TryParse(WC.Trim(), out int n))
            {
                return new Tuple<string, bool, Color>("Checking Minimum Word Count Options: OK", true, Color.Green);
            }
            else
            {
                return new Tuple<string, bool, Color>("Checking Minimum Word Count Options: Error." + Environment.NewLine + "Your minimum Word Count setting on the N-gram Settings tab must be an integer (e.g., 50, 100, 1234, etc.).", false, Color.Red);
            }
        }




        public Tuple<string, bool, Color> ValidateNGramN(string NgramMin, string NgramMax)
        {
            if (int.TryParse(NgramMax.Trim(), out int n) && int.TryParse(NgramMin.Trim(), out int m))
            {
                if (int.Parse(NgramMax.Trim()) <= 0 || int.Parse(NgramMin.Trim()) <= 0)
                {
                    return new Tuple<string, bool, Color>("Checking N-gram Options: Error." + Environment.NewLine + "Your N-gram settings must both be positive integers (i.e., a whole number > 0).", false, Color.Red);
                }
                else if (int.Parse(NgramMax.Trim()) < int.Parse(NgramMin.Trim()))
                {
                    return new Tuple<string, bool, Color>("Checking N-gram Options: Error." + Environment.NewLine + "Your N-gram settings must have \"A\" (min) set to less than or equal to \"B\" (max).", false, Color.Red);
                }
                else if (int.Parse(NgramMax) <= 3)
                {
                    return new Tuple<string, bool, Color>("Checking N-gram Selection: OK", true, Color.Green);
                }
                else
                {
                    return new Tuple<string, bool, Color>("Checking N-gram Selection: Warning. Extracting N-grams > (N=3) can be extremely slow / resource-intensive. You may want to reduce this value to ensure that your system can handle this process.", true, Color.Yellow);
                }
            }
            else
            {
                return new Tuple<string, bool, Color>("Checking N-gram Options: Error." + Environment.NewLine + "Your N-gram settings must both be positive integers (i.e., a whole number > 0).", false, Color.Red);
            }
        }


        public Tuple<string, bool, Color> ValidateFreqListPrune(string inputvalue)
        {
            if (int.TryParse(inputvalue.Trim(), out int n) && int.Parse(inputvalue.Trim()) > 0)
            {
                return new Tuple<string, bool, Color>("Checking frequency list pruning settings: OK", true, Color.Green);
            }
            else
            {
                return new Tuple<string, bool, Color>("Checking frequency list pruning settings: List pruning settings: Error." + Environment.NewLine + "Your Frequency List pruning \"X\" value must be a positive integer.", false, Color.Red);
            }
        }







    }
}
