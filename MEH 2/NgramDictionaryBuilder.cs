using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEHv2
{
    class NgramDictionaryBuilder
    {



        private MEH2.TextConversionClass Converter = new MEH2.TextConversionClass();


        public void SetConverterMode(bool TextConversionLookupMethod, string ConversionListString, bool LowerCaseMode)
        {

            Converter.LookupMethod = TextConversionLookupMethod;

            if (TextConversionLookupMethod)
            {
                Converter.InitializeConversionList_Lookup(ConversionListString, LowerCaseMode);
            }
            else
            {
                Converter.InitializeConversionList_Regex(ConversionListString, LowerCaseMode);
            }
        }


        public string RunRegexConversions(string InputText)
        {
            return (Converter.RunConversions(InputText));
        }



        public Dictionary<string, Dictionary<string, long>> BuildNgramDictionary(string[] TokenizedText_For_Ngrams,
                                                                                 Dictionary<string, Dictionary<string, long>> FileTokenData,
                                                                                 int Ngram_N_Min, int Ngram_N_Max)
        {


            for (long i = 0; i < TokenizedText_For_Ngrams.Length; i++)
            {
                //builds our ngrams...
                for (int j = Ngram_N_Max; j > Ngram_N_Min - 1; j--)
                {
                    if (i + j <= TokenizedText_For_Ngrams.Length)
                    {
                        string[] token_builder = new string[j];
                        Array.Copy(TokenizedText_For_Ngrams, i, token_builder, 0, j);

                        string token = string.Join(" ", token_builder);





                        //if we're using the "lookup" method for conversions, we want to do those here
                        if (Converter.LookupMethod && Converter.ConversionList_NoRegex.Count > 0 && Converter.ConversionList_NoRegex.ContainsKey(token))
                        {
                            token = Converter.ConversionList_NoRegex[token];

                        }





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


            return (FileTokenData);


        }





    }
}
