using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MEH2
{
    class TextConversionClass
    { 

        private List<Tuple<Regex, string>> ConversionList { get; set; }



        //  ____        _ _     _    ____                              _               _     _     _   
        // | __ ) _   _(_) | __| |  / ___|___  _ ____   _____ _ __ ___(_) ___  _ __   | |   (_)___| |_ 
        // |  _ \| | | | | |/ _` | | |   / _ \| '_ \ \ / / _ \ '__/ __| |/ _ \| '_ \  | |   | / __| __|
        // | |_) | |_| | | | (_| | | |__| (_) | | | \ V /  __/ |  \__ \ | (_) | | | | | |___| \__ \ |_ 
        // |____/ \__,_|_|_|\__,_|  \____\___/|_| |_|\_/ \___|_|  |___/_|\___/|_| |_| |_____|_|___/\__|
        //                                                                                             
        public void InitializeConversionList(string RawConversionText, bool LowerCaseConversion)
        {

            List<Tuple<Regex, string>> ConversionListCompiled = new List<Tuple<Regex, string>>();

            string[] ConversionListArray = RawConversionText.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < ConversionListArray.Length; i++)
            {
                string[] ConversionItemSplit = ConversionListArray[i].Split(new[] { '^' }, StringSplitOptions.RemoveEmptyEntries);

                //we have to have the length be 2, otherwise we know that something is horribly wrong with the input
                if (ConversionItemSplit.Length == 2)
                {

                    //we have to first validate the regex on the first side of things

                    Regex CompiledRegex = new Regex("");
                    try
                    {
                        if (LowerCaseConversion)
                        {
                            CompiledRegex = new Regex(@"(?<=\s|^)" + Regex.Escape(ConversionItemSplit[0]).Replace(@"\*", @"\S+") + @"(?=\s|$)", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
                        }
                        else
                        {
                            CompiledRegex = new Regex(@"(?<=\s|^)" + Regex.Escape(ConversionItemSplit[0]).Replace(@"\*", @"\S+") + @"(?=\s|$)", RegexOptions.Compiled | RegexOptions.Multiline);
                        }

                        ConversionListCompiled.Add(new Tuple<Regex, string>(CompiledRegex, ConversionItemSplit[1]));

                    }
                    catch
                    {
                        continue;
                    }


                }

            }

            ConversionList = ConversionListCompiled;

        }



        //this will sequentially run all conversions on the text and return the processed string
        public string RunConversions(string inputtext)
        {

            string modifiedtext = string.Copy(inputtext);

            for(int i = 0; i < ConversionList.Count(); i++)
            {
                modifiedtext = ConversionList[i].Item1.Replace(modifiedtext, ConversionList[i].Item2);
            }

            return modifiedtext;


        }




    }
}
