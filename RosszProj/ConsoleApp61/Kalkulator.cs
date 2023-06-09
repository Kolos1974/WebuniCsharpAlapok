namespace ConsoleApp61
{
    public class Kalkulator
    {
        public int Kalkulalas(string muv)
        {
            Szeparator s = new (muv);
            int eredmeny = 0;
            if (s.Valid)
            {
                Szamolo k = new ();
                
                switch (s.Muv)
                {
                    case '+':
                        eredmeny = k.Osszad(s.Op1, s.Op2);
                        break;
                    case '-':
                        eredmeny = k.Kivon(s.Op1, s.Op2);
                        break;
                    case '*':
                        eredmeny = k.Szoroz(s.Op1, s.Op2);
                        break;
                    case '/':
                        eredmeny = k.Oszt(s.Op1, s.Op2);
                        break;
                }
                
            }
            return eredmeny;
        }
    }
}
