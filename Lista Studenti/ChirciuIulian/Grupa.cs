using System;
using System.Collections.Generic;
using System.Text;

namespace ChirciuIulian
{
    class Grupa
    {
        public int numar { get; set; }
        public int numarStudenti { get; set; }

        public Grupa()
        {

        }

        public Grupa(int numar, int numarStudenti)
        {
            this.numar = numar;
            this.numarStudenti = numarStudenti;
        }

    }
}
