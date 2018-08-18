using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEH2
{
    class WordCountCalculator
    {

        public long GetWC(string input_text)
        {
            long WC = 0;
            int index = 0;
            //get our word count
            //loop borrowed from https://stackoverflow.com/a/8784654
            while (index < input_text.Length)
            {
                // check if current char is part of a word
                while (index < input_text.Length && !char.IsWhiteSpace(input_text[index]))
                    index++;

                WC++;

                // skip whitespace until next word
                while (index < input_text.Length && char.IsWhiteSpace(input_text[index]))
                    index++;
            }

            return WC;

        }






    }
}
