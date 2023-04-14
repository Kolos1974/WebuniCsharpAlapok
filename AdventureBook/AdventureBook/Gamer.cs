using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBook
{
    class Gamer
    {
        public Gamer(string nev)
        {
            Nev = nev;
        }

        public string Nev { get; }
        public int Eletero { get; set; } = 100;



    }
}
