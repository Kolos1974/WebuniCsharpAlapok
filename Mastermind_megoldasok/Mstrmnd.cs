using System;

class Mstrmnd : IVegrehajthato
{
    public void Vegrehajt()
    {
        int titkosSzam = new Random().Next(0, 1000), leadottTippek = 0, tipp;
        do
        {
            leadottTippek++;
            Console.WriteLine("Add meg a tipped!");
            while (!int.TryParse(Console.ReadLine(), out tipp) || tipp < 0 || tipp > 999)
                Console.WriteLine("Hibás formátum! Csak 000 és 999 közötti számot adhatsz meg!");
            Tipp("Az első", tipp / 100 % 10, titkosSzam / 100 % 10);
            Tipp("A második", tipp / 10 % 10, titkosSzam / 10 % 10);
            Tipp("A harmadik", tipp % 10, titkosSzam % 10);
            static void Tipp(string hanyadikSzam, int tipp, int titkosSzam) => Console.WriteLine($" {hanyadikSzam} szám {(tipp == titkosSzam ? $"helyes: {tipp}!" : tipp > titkosSzam ? "kisebb" : "nagyobb")}.");
        }
        while (tipp != titkosSzam);

        Console.WriteLine($"Gratulálok, {leadottTippek} lépésből nyertél!");
    }
}
