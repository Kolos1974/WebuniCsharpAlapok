using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlakzatokKT
{

    /// <summary>
    /// A kör objektum ter/ker számításhoz
    /// </summary>
    sealed public class Kor : Alakzat
    {
        double sug;

        /// <summary>
        /// A kör létrehozása
        /// </summary>
        /// <param name="s">kör sugara</param>
        public Kor(double s)
        {
            sug = s;
        }

        /// <summary>
        /// Kör kerület kiszámítása
        /// </summary>
        /// <returns>kiszámított kerület érték</returns>
        public override double Ker()
        {
            return 2 * sug * Math.PI;
        }

        public override double Ter()
        {
            return sug * sug * Math.PI;
        }
    }
}
