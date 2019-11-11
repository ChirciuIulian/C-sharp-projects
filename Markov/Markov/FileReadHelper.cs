using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Markov
{
    class FileReadHelper
    {
        public string[] ReadFileLines()
        {
            var lines = File.ReadAllLines("C:\\Users\\IulianChirciu\\source\\repos\\Markov\\Markov\\MarkovFile.txt");

            return lines;
        }

        public string TrimVocabularStrings()
        {
            //Remove Vocabular:(
            string [] word = ReadFileLines();
            string finalword = word[0].Replace("Vocabular:(", "");
            //Remove );
            char[] charsToTrim = {')', ';'};
            finalword = finalword.Trim(charsToTrim);

            return finalword;
        }

        public string TrimSeTransformaStrings()
        {
            //Remove SeTransforma:(
            string[] word = ReadFileLines();
            string finalword = word[1].Replace("SeTransforma:(", "");
            //Remove );
            char[] charsToTrim = { ')', ';' };
            finalword = finalword.Trim(charsToTrim);

            return finalword;
        }

        public string TrimTransformariStrings()
        {
            //Remove Transformari:(
            string[] word = ReadFileLines();
            string finalword = word[2].Replace("Transformari:(", "");
            //Remove );
            char[] charsToTrim = { ')', ';' };
            finalword = finalword.Trim(charsToTrim);

            return finalword;
        }

        public bool IsInVocabulary(string word, string vocabular)
        {
            char[] chars = word.ToCharArray();

            foreach(char characters in chars)
            {
                if (!vocabular.Contains(characters))
                    return false;
            }
            return true;
        }
    }
}
