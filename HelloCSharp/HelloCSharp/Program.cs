
using System;

namespace HelloCSharp
{


    class Program
    {

        static void Main(string[] args)
        {
            var szoveg3 = "Szöveg deklarálás típus nélkül. Implicit típus megadás.";

            string szoveg = "Hello C#!";
            if (false)
            {
                szoveg = "Hello";
            }

            Console.WriteLine(szoveg);
        }

    }

}