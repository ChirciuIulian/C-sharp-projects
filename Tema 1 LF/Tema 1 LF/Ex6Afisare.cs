using System;
using System.Collections.Generic;
using System.Text;

namespace Tema_1_LF
{
    class Ex6Afisare
    {

        public void print()
        {
            Console.WriteLine("Introduceti cuvantul");
            string cuvant = Console.ReadLine();
            cuvant.ToCharArray();
            var builder = new StringBuilder();

            for(int i = 0; i < cuvant.Length; i++)
            {
                builder.Append(cuvant[i]);
                Console.WriteLine(builder);
            }
            Console.ReadLine();
        }
    }
}
