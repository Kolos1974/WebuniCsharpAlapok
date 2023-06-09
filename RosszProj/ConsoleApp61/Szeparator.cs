namespace ConsoleApp61
{
    public class Szeparator
    {
        public int Op1 { get; }
        public int Op2 { get; }
        public char Muv { get; }

        public bool Valid { get; }

        public Szeparator(string kifejezes)
        {
            bool first = true;
            string s1 = "";
            string s2 = "";

            for (int i = 0; i < kifejezes.Length; i++)
            {
                if (System.Char.IsDigit(kifejezes[i]) && first)
                {
                    s1 += kifejezes[i];
                }
                else if (first)
                {
                    first = false;
                    Muv = kifejezes[i];
                }
                else
                {
                    s2 += kifejezes[i];
                }
            }

            if (s1.Length > 0)
            {
                Op1 = int.Parse(s1);

            }

            if (s2.Length > 0)
            {
                Op2 = int.Parse(s2);
            }


            if (s2.Length > 0)
            {
                Valid = true;
            }
        }
    }
}
