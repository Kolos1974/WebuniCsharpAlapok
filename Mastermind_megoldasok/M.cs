using System;

class M : IVegrehajthato
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
            foreach (var (hanyadikSzam, tippSzamjegy, titkosSzamjegy) in new[] { ("Az első", tipp / 100 % 10, titkosSzam / 100 % 10), ("A második", tipp / 10 % 10, titkosSzam / 10 % 10), ("A harmadik", tipp % 10, titkosSzam % 10) })
                Console.WriteLine($" {hanyadikSzam} szám {(tippSzamjegy == titkosSzamjegy ? $"helyes: {tippSzamjegy}!" : tippSzamjegy > titkosSzamjegy ? "kisebb" : "nagyobb")}.");
        }
        while (tipp != titkosSzam);

        Console.WriteLine($"Gratulálok, {leadottTippek} lépésből nyertél!");
    }
}
