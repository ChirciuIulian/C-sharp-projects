using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Markov
{
    class Program
    {
        static void Main(string[] args)
        {
            string cuv = "y";
            while (cuv.Equals("y"))
            {
                FileReadHelper help = new FileReadHelper();
                Markov markov = new Markov(help.TrimVocabularStrings(), help.TrimSeTransformaStrings(), help.TrimTransformariStrings());

                Console.WriteLine("Introduceti cuvantul");
                string cuvant = Console.ReadLine();

                if (help.IsInVocabulary(cuvant, markov.vocabular))
                {
                    string[] cuvSeTransforma = markov.splitWord(markov.SeTransforma);
                    string[] cuvTransformari = markov.splitWord(markov.Transformari);
                    string[] vocabular = markov.splitWord(markov.vocabular);

                    if (markov.existsWord(vocabular, cuvant))
                    {
                        while (markov.existsWord(cuvSeTransforma, cuvant))
                        {
                            cuvant = markov.MarkovAlg(cuvant, cuvSeTransforma, cuvTransformari);
                            Console.WriteLine(cuvant);
                        }
                    }
                    Console.WriteLine("Doriti sa continuati? (Y / N)");
                    cuv = Console.ReadLine();
                }
                else
                    Console.WriteLine("Cuvantul nu este in vocabular!!!");
            }
        }
    }
}
