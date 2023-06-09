using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlakzatokKT
{
    public class Negyzet : Alakzat
    {

        double oldal;

        public Negyzet(double o)
        {
            oldal = o;
        }
        public override double Ker()
        {
            return 4 * oldal;
        }

        public override double Ter()
        {
            return oldal * oldal;
        }
    }
}
