using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tema_1_LF
{
    class Ex5Split
    {

        public void split()
        {
            Console.WriteLine("Introduceti propozitia: ");
            string propozitie = Console.ReadLine();

            string[] rezultat = Regex.Split(propozitie, " ");

            for (int i = 0; i < rezultat.Length; i++)
            {
                string rezult = Regex.Replace(rezultat[i], @"[^\w\s]", "");
                Console.WriteLine((i+1) + "." +rezult);
            }
            Console.ReadLine();
        }
    }
}
