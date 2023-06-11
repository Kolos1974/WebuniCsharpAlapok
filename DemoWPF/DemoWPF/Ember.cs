using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWPF
{
    public  class Ember
    {

        public string Nev { get; set; }

        public int Szev { get; set; }

        public Ember(string n, int s)
        {
            this.Nev = n;
            this.Szev = s;
            
        }
        /*
        public override string ToString()
        {
            return $"{Nev} - {Szev}";
        }
        */

    }

    public class Embers
    {
        public ObservableCollection<Ember> Emberek { get; set; }


        public Embers()
        {
            Emberek = new ObservableCollection<Ember>()
            {
                new Ember("Peti", 1999),
                new Ember("KAti", 2022),
                new Ember("Laci", 2001)

            };




        }
    }

}
