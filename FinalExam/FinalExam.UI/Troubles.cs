using FinalExam.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam.UI
{
    public class Troubles
    {

        public List<Trouble> TroubleList { get; set; }

        public Troubles()
        {
            TroubleList = new List<Trouble>();
        }
    }
}
