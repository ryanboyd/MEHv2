using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LemmaSharp;

namespace MEH2
{
    class LemmatizerChooser
    {

        public LemmaSharp.LemmatizerPrebuiltCompact LemmaGenChoice(string LemmatizerDropdownSelection)
        {

            LemmaSharp.LemmatizerPrebuiltCompact Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.English);

            switch (LemmatizerDropdownSelection)
            {
                case "Беларуская (Bulgarian)":
                    Lemmatizer = new LemmaSharp.LemmatizerPrebuiltCompact(LanguagePrebuilt.Bulgarian); break;
                case "čeština (Czech)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Czech); break;
                case "English":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.English); break;
                case "Eesti (Estonian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Estonian); break;
                case "فارسی (Persian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Persian); break;
                case "français (French)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.French); break;
                case "Magyar (Hungarian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Hungarian); break;
                case "Македонски (Macedonian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Macedonian); break;
                case "polski (Polish)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Polish); break;
                case "Română (Romanian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Romanian); break;
                case "Pyccĸий (Russian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Russian); break;
                case "Slovenčina (Slovak)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Slovak); break;
                case "Slovene":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Slovene); break;
                case "Srpski / Српски (Serbian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Serbian); break;
                case "Українська (Ukranian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Ukrainian); break;
                case "EnglishMT":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.EnglishMT); break;
                case "françaisMT":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.FrenchMT); break;
                case "Deutsch (German)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.German); break;
                case "italiano (Italian)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Italian); break;
                case "Español (Spanish)":
                    Lemmatizer = new LemmatizerPrebuiltCompact(LanguagePrebuilt.Spanish); break;
            }

            return Lemmatizer;
                        


        }

    }
}
