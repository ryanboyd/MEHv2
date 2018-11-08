using System;
using System.Text.RegularExpressions;


namespace MEH2
{
    class TextSegmentor
    {

        private Regex RegexSegmentor { get; set; }

        public string[][] Segment(string[] tokenarray, string SegmentOption, string SegmentationParameter, string raw_text = "")
        {


            


            //Dim NumberOfSegments As ULong = 1
            int NumberOfSegments = 1;

            switch (SegmentOption)
            {
                case "NoSegmentation":
                    break;
                case "N_Equal_Segments":
                    NumberOfSegments = int.Parse(SegmentationParameter);
                    break;
                case "Words_Per_Segment":
                    NumberOfSegments = (int)System.Math.Ceiling((double)tokenarray.Length / int.Parse(SegmentationParameter));
                    break;
                case "Regex":
                    NumberOfSegments = RegexSegmentor.Matches(raw_text).Count + 1;
                    break;
            }

            


            //now we want to actually create a list of separate arrays
            
            return Segment_Chopper(tokenarray, NumberOfSegments);

        }






        public void SetRegex(string regex_segment)
        {
            RegexSegmentor = new Regex(regex_segment, RegexOptions.Compiled | RegexOptions.Multiline);
        }






        private string[][] Segment_Chopper(string[] array_to_split, int number_of_splits)
        {

            if (array_to_split.Length < number_of_splits) number_of_splits = array_to_split.Length;

            string[][] Segmented_Array = new string[number_of_splits][];
            int Segment_Size = (int)System.Math.Ceiling((double)array_to_split.Length / number_of_splits);

            for (int i = 0; i < number_of_splits; i++)
            {

                int SegmentStart = i * Segment_Size;
                int SegmentEnd = ((i + 1) * Segment_Size);
                int SegmentLength = SegmentEnd - SegmentStart;

                if (i != number_of_splits - 1)
                {
                    Segmented_Array[i] = new string[SegmentLength];
                    Array.Copy(array_to_split, SegmentStart, Segmented_Array[i], 0, SegmentLength);
                }
                else
                {
                    SegmentLength = array_to_split.Length - SegmentStart;

                    Segmented_Array[i] = new string[SegmentLength];
                    Array.Copy(array_to_split, SegmentStart, Segmented_Array[i], 0, SegmentLength);
                }

            }

            return Segmented_Array;
        }
        




    }
}
