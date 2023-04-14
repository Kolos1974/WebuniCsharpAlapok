using System;

class Barkoba : IVegrehajthato
{
    public void Vegrehajt()
    {
        var random = new Random();
        var titkosSzam = random.Next(1, 101);

        var leadottTippek = 0;
        int tipp;

        do
        {
            leadottTippek++;
            if (leadottTippek >= 6)
            {
                Console.WriteLine($"Veszítettél! Ennyire gondoltam: {titkosSzam}");
                return;
            }

            Console.WriteLine("Add meg a tipped!");

            while (!int.TryParse(Console.ReadLine(), out tipp))
            {
                Console.WriteLine("Hibás formátum, add meg újra!");
            }

            if (tipp < titkosSzam)
            {
                Console.WriteLine("Többre gondoltam!");
            }
            else if (tipp > titkosSzam)
            {
                Console.WriteLine("Kevesebbre gondoltam!");
            }

        }
        while (tipp != titkosSzam);

        Console.WriteLine("Gratulálok! Nyertél!");
    }
}
