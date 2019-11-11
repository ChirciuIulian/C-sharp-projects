using System;
using System.Collections.Generic;

namespace Tema_1_LF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ce exercitiu doriti sa porniti?");
            int number = Convert.ToInt32(Console.ReadLine());

            switch (number)
            {
                case 1:
                    Ex1CharOccurance exercitiul1 = new Ex1CharOccurance();
                    exercitiul1.charOccurance();
                    break;
                case 2:
                    Ex1DetermineNumber exercitiul2 = new Ex1DetermineNumber();
                    exercitiul2.determineNumber();
                    break;
                case 3:
                    Ex3Alphabet exercitiul3 = new Ex3Alphabet();
                    exercitiul3.alphabet();
                    break;
                case 4:
                    Ex4SubString exercitiul4 = new Ex4SubString();
                    exercitiul4.subString();
                    break;
                case 5:
                    Ex5Split exercitiul5 = new Ex5Split();
                    exercitiul5.split();
                    break;
                case 6:
                    Ex6Afisare exercitiul6 = new Ex6Afisare();
                    exercitiul6.print();
                    break;
            }
        }
    }
}

