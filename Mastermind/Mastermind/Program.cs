using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            var random = new Random();
            var titkosSzam = random.Next(0, 1000);
            var titklosString = "";
            var tippString = "";

            titklosString = "000"+ titkosSzam.ToString();
            titklosString = titklosString.Substring(titklosString.Length - 3, 3);

            var leadottTippek = 0;
            int tipp;

            do
            {
                Console.WriteLine("Adj meg egy számot 0 és 999 között!");

                var joTipp = false;
                do
                {
                    while (!int.TryParse(Console.ReadLine(), out tipp))
                    {
                        Console.WriteLine("Hibás formátum, add meg újra!");
                    }

                    if (tipp>= 0 && tipp <=999)
                    {
                        joTipp = true;
                    } else
                    {
                        Console.WriteLine("Rossz értéket adtál meg!! Add meg újra!");
                    }
                }
                while (!joTipp);

                leadottTippek++;

                tippString = "000" + tipp.ToString();
                tippString = tippString.Substring(tippString.Length - 3, 3);
                Console.WriteLine("A tipped: {0}", tippString);

                for (int i = 0; i < 3; i++)
                {
                    if (int.Parse(titklosString.Substring(i,1)) < int.Parse(tippString.Substring(i,1)))
                    {
                        Console.WriteLine($"Az {i+1} pozícióra többet tippeltél!");
                    }
                    else if (int.Parse(titklosString.Substring(i, 1)) > int.Parse(tippString.Substring(i, 1)))
                    {
                        Console.WriteLine($"Az {i+1} pozícióra kevesebbet tippeltél!");
                    } else
                    {
                        Console.WriteLine($"Az {i+1} pozícióra jól tippeltél!");
                    }
                }

            }
            while (tipp != titkosSzam);

            Console.WriteLine("Gratulálok nyertél!");
            Console.ReadLine();
        }
    }
}
