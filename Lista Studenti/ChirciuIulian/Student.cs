using System;
using System.Collections.Generic;
using System.Text;

namespace ChirciuIulian
{

    class Student
    {
        public string nume { get; set; }
        public string prenume { get; set; }
        public Grupa grupa { get; set; }

        public Student()
        {

        }

        public Student(string nume, string prenume, Grupa grupa)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.grupa = grupa;
        }

        public LinkedList<Student> GetAllStudents(LinkedList<Student> studenti, int grupInput)
        {
            LinkedList<Student> selectedStudenti = new LinkedList<Student>();
            foreach(Student student in studenti)
            {
                if(grupInput == student.grupa.numar)
                {
                    selectedStudenti.AddLast(student);
                }
            }
            return selectedStudenti;
        }
    }
}
