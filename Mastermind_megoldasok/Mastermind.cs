using System;

class Mastermind : IVegrehajthato
{
    public void Vegrehajt()
    {
        var random = new Random();
        var titkosSzam = random.Next(0, 1000);

        var leadottTippek = 0;
        int tipp;

        do
        {
            leadottTippek++;

            Console.WriteLine("Add meg a tipped!");

            while (!int.TryParse(Console.ReadLine(), out tipp) || tipp < 0 || tipp > 999)
                Console.WriteLine("Hibás formátum! Csak 000 és 999 közötti számot adhatsz meg!");

            if (tipp / 100 % 10 > titkosSzam / 100 % 10)
                Console.WriteLine(" Az első szám kisebb.");
            else if (tipp / 100 % 10 < titkosSzam / 100 % 10)
                Console.WriteLine(" Az első szám nagyobb.");
            else
                Console.WriteLine($" Az első szám helyes: {tipp / 100 % 10}!");

            if (tipp / 10 % 10 > titkosSzam / 10 % 10)
                Console.WriteLine(" A második szám kisebb.");
            else if (tipp / 10 % 10 < titkosSzam / 10 % 10)
                Console.WriteLine(" A második szám nagyobb.");
            else
                Console.WriteLine($" A második szám helyes: {tipp / 10 % 10}!");

            if (tipp % 10 > titkosSzam % 10)
                Console.WriteLine(" A harmadik szám kisebb.");
            else if (tipp % 10 < titkosSzam % 10)
                Console.WriteLine(" A harmadik szám nagyobb.");
            else
                Console.WriteLine($" A harmadik szám helyes: {tipp % 10}!");
        }
        while (tipp != titkosSzam);

        Console.WriteLine($"Gratulálok, {leadottTippek} lépésből nyertél!");
    }
}
