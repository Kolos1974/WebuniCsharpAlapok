// See https://aka.ms/new-console-template for more information
using AlakzatokKT;
using System.Globalization;
using System.Runtime.CompilerServices;

public class Program
{

    static void Main(string[] args)
    {
        Kor k = new Kor(10);

        Console.WriteLine($"Köröm kerülete: {k.Ker()}");

    }

}