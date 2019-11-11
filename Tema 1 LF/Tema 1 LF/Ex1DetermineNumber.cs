using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tema_1_LF
{
    class Ex1DetermineNumber
    {
        public void determineNumber()
        {
            Console.WriteLine("Introduceti caracterele");
            string caractere = Console.ReadLine();
            bool success = Int32.TryParse(caractere, out int numbers);
            bool success1 = Double.TryParse(caractere, out double number);
            Parse(success1, success, caractere);
            Console.ReadLine();
        }

        private void Parse(bool parsed,bool parse, string word)
        {
            if (parse)
                Console.WriteLine("Numarul este un intreg");
            else if (parsed)
                Console.WriteLine("Numarul este real");
            else if (!Regex.IsMatch(word, @"^-?\d+$"))
                Console.WriteLine("Nu este numar");
        }
    }
}
