using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var appok = new Dictionary<int, IVegrehajthato>
        {
            [1] = new Barkoba(),
            [2] = new Mastermind(),
            [3] = new Mstrmnd(),
            [4] = new M()
        };

        Console.WriteLine($"Válassz!\n\n{string.Join('\n', appok.Select(a => $"{a.Key} - {a.Value}"))}");

        var key = Console.ReadKey().KeyChar.ToString();
        Console.WriteLine();

        if (!int.TryParse(key, out var num) || !appok.TryGetValue(num, out var executable))
        {
            Console.WriteLine("Hibás input.");
        }
        else
        {
            Console.WriteLine($"{executable}...\n{new string('-', Console.BufferWidth - 1)}");
            executable.Vegrehajt();
        }
    }
}
