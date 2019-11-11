using System;
using System.Collections.Generic;

namespace ChirciuIulian
{
    class Program
    {

        static void Main(string[] args)
        {
            var lista = new LinkedList<Student>();
            PopulateList(lista);
            PrintList(lista);
            Console.ReadLine();
        }

        private static void PopulateList(LinkedList<Student> lista)
        {
            Console.WriteLine("Cati studenti doriti sa introduceti in Lista? : ");
            int nrStudenti = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < nrStudenti; i++)
            {
                Student student = new Student();
                Console.WriteLine("Introduceti numele studentului " + " :");
                student.nume = Console.ReadLine();
                Console.WriteLine("Introduceti prenumele studentului " + " :");
                student.prenume = Console.ReadLine();
                Console.WriteLine("Introduceti grupa studentului " + " :");
                Grupa grup = new Grupa(Convert.ToInt32(Console.ReadLine()), nrStudenti);
                student.grupa = grup;
                lista.AddLast(student);
            }
        }

        public static void PrintList(LinkedList<Student> lista)
        {
            Console.WriteLine("Din ce grupa doriti sa afisati lista? : ");
            int grupa = Convert.ToInt32(Console.ReadLine());
            Student student = new Student();
            var list = student.GetAllStudents(lista, grupa);
            foreach (var studenti in list)
            {
                Console.WriteLine("Nume: " + studenti.nume + " Prenume: " + studenti.prenume + " Grupa: " + grupa);
            }
        }
    }
}
