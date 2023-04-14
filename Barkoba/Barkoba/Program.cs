

using System;

namespace Barkoba
{


    class Program
    {

        static void Main(string[] args)
        {
            // var random = new Random();
            // 
            // Random random = new();

            var random = new Random();
            var titkosSzam = random.Next(1, 101);

            var leadottTippek = 0;
            int tipp;

            // Console.WriteLine(titkosSzam);

            do
            {
                // leadottTippek += 1;
                leadottTippek++;
                if (leadottTippek >= 8)
                {
                    Console.WriteLine($"Veszítettél! Ennyire gondoltam: {titkosSzam}");
                    return;
                }



                Console.WriteLine("Add meg a tipped!");

                //var tipp = Console.ReadLine();
                // if (int.TryParse(Console.ReadLine(), out int tipp) == false)

                /*
                int tipp2 = 0;
                while (!int.TryParse(Console.ReadLine(), out int tipp))
                {
                    tipp2 = tipp;
                    Console.WriteLine("Hibás formátum, add meg újra!");
                }
                */


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

            Console.WriteLine("Gratulálok nyertél!");

        }


    }

}