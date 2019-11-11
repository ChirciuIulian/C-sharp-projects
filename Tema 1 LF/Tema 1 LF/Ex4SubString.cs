using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tema_1_LF
{
    class Ex4SubString
    {
        public void subString()
        {
            Console.WriteLine("Introduceti cuvantul: ");
            string cuvant = Console.ReadLine();
            cuvant.ToCharArray();

            Console.WriteLine("Introduceti subcuvantul pe care vreti sa il inlocuiti: ");
            string subCuvant = Console.ReadLine();

            Console.WriteLine("Introduceti cuvantul inlocuitor: ");
            string inlocuitor = Console.ReadLine();

            Regex regReplace = new Regex(subCuvant);

            string res = regReplace.Replace(cuvant, inlocuitor, 1);

            Console.WriteLine(res);

            Console.ReadLine();

        }
    }
}
