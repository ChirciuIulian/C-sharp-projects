using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Markov
{
    class Markov
    {
        public string vocabular { get; set; }
        public string SeTransforma { get; set; }
        public string Transformari { get; set; }

        public Markov(string vocabular, string SeTransforma, string Transformari)
        {
            this.vocabular = vocabular;
            this.SeTransforma = SeTransforma;
            this.Transformari = Transformari;
        }

        public string[] splitWord(string word)
        {
            string[] words = word.Split(' ');

            return words;
        }

        public int[] addSubstringIndex(string[] cuvinte, string cuvant)
        {
            int[] array = new int[cuvinte.Length];

            for(int i = 0; i < cuvinte.Length; i++)
            {
                array[i] = cuvant.IndexOf(cuvinte[i]);
            }

            return array;
        }

        public bool existsWord (string[] cuvinte, string cuvant)
        {
            for(int i = 0; i < cuvinte.Length; i++)
            {
                if (cuvant.Contains(cuvinte[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public int maxIndex(int[] index)
        {
            int max = -10;
            for(int i = 0; i < index.Length; i++)
            {
                if (index[i] > max)
                    max = index[i];
            }
            return max;
        }

        public string MarkovAlg(string cuvant, string[]cuvSeTransforma, string[] cuvTransformari){
            int[] indexString = addSubstringIndex(cuvSeTransforma, cuvant);
            int min = maxIndex(indexString);
            int wordNumber = 0;
            for (int i = 0; i<indexString.Length; i++)
                {
                    if (indexString[i] < min && indexString[i] > -1)
                        {
                            min = indexString[i];
                            wordNumber = i;
                        }
                        if (indexString[i] == min)
                            wordNumber = i;
                    }
            Regex cuv = new Regex(cuvSeTransforma[wordNumber]);
            cuvant = cuv.Replace(cuvant, cuvTransformari[wordNumber], 1);

            return cuvant;
            }
        }

}
