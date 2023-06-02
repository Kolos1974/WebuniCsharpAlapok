using ConsoleApp61;
using System;

string muv;
do
{
    Console.WriteLine("Kérem a műveletetszóközök nélkül! (pl.253+17) (kilépés Enter)");
    muv = Console.ReadLine();
    Kalkulator k = new();
    Console.WriteLine($"A művelet eredménye: {k.Kalkulalas(muv)}");
    
} while (!string.IsNullOrEmpty(muv));
