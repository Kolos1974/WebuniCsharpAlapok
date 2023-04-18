using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBook
{
    abstract class Adventure
    {
        public Adventure(Gamer gamer)
        {
            Gamer = gamer;
        }

        public Gamer Gamer { get; }

        public abstract void Run();
    }
}
