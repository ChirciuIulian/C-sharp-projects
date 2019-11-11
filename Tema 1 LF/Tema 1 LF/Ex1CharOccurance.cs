using System;
using System.Collections.Generic;
using System.Text;

namespace Tema_1_LF
{
    class Ex1CharOccurance
    {
        public void charOccurance()
        {
            Console.WriteLine("Introduceti cuvantul: ");
            string cuvant = Console.ReadLine();
            var unique = new HashSet<char>(cuvant);
            char[] caractere = cuvant.ToCharArray();
            int count = 0;

            foreach (char c in unique)
            {
                for (int i = 0; i < caractere.Length; i++)
                {
                    if (c == caractere[i])
                        count++;
                }
                Console.WriteLine("Caracterul --> " + c + " <--apare de " + count + "ori");
                count = 0;
            }

            Console.ReadLine();
        }
    }
}
