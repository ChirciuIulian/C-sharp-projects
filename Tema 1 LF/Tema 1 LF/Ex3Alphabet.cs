using System;
using System.Collections.Generic;
using System.Text;

namespace Tema_1_LF
{
    class Ex3Alphabet
    {
        public void alphabet()
        {
            Console.WriteLine("Introduceti alfabetul: ");
            string alfabet = Console.ReadLine();
            Console.WriteLine("Introduceti cuvantul: ");
            string cuvant = Console.ReadLine();

            if (isWordInAlfabet(cuvant, alfabet))
                Console.WriteLine("Cuvantul face parte din alfabet");
            else
                Console.WriteLine("Cuvantul nu face parte din alfabet");
            Console.ReadLine();
        }

        private bool isWordInAlfabet(string word, string alfabet)
        {
            char[] charArr = word.ToCharArray();

            foreach(char caracter in charArr)
            {
                if (!alfabet.Contains(caracter.ToString()))
                    return false;
            }
            return true;
        }
    }
}
