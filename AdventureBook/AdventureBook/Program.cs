﻿

namespace AdventureBook
{
    class Program
    {
        static void Main(string[] args)
        {
            string? name = null;
            Console.Write("Üdv! ");
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Add meg a neved:");
                name = Console.ReadLine();
            }
            Console.WriteLine("\nA kalandod elkezdődik...\n");

            var gamer = new Gamer(name);
            // var aGoblinNapja = new AGoblinNapja(jatekos);
            // aGoblinNapja.Futtatas();
        }
    }
}

