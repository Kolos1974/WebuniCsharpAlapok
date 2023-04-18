using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBook
{
    abstract class Creature
    {

        public Creature(string name, int vitality)
        {
            Name = name;
            Vitality = vitality;
        }

        public string Name { get; }
        public int Vitality { get; set; }
    }
}
