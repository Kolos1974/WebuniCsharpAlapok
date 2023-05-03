using System;
using System.Collections;

class Program
{



    static void Main(string[] args)
    {


        string[] names = { "Tom", "Dick", "Harry", "Mary", "Jay" };
        foreach (string name in names)
        {
            Console.Write(name + " | ");    // Tom | Dick | Harry | Mary | Jay |
        }
        Console.WriteLine();



        IEnumerable filteredNames = Enumerable.Where(names, n => n.Length >= 4);
        foreach (string name in filteredNames)
        {
            Console.Write(name + " | ");            // Dick | Harry | Mary |
        }
        Console.WriteLine();

        IEnumerable filteredNames2 = names.Where(n => n.Length >= 4);
        foreach (string name in filteredNames2)
        {
            Console.Write(name + " | ");           // Dick | Harry | Mary | 
        }
        Console.WriteLine();


        /* query comprehension szintaxis */ 
        IEnumerable filteredNames3 = from n in names 
                                     where n.Length >= 4 
                                     select n;

        foreach (string name in filteredNames3)
        {
            Console.Write(name + " | ");           // Dick | Harry | Mary | 
        }
        Console.WriteLine();


        // 4. sor
        IEnumerable filteredNames4 = names
                                     .Where(n => n.Contains("a"))
                                     .OrderBy(n => n.Length)
                                     .Select(n => n.ToUpper());

        foreach (string name in filteredNames4)
        {
            Console.Write(name + " | ");   // JAY | MARY | HARRY |
        }
        Console.WriteLine();


        Console.WriteLine(names.First());                   // Tom
        Console.WriteLine(names.Last());                    // Jay
        Console.WriteLine(names.ElementAt(1));              // Dick
        Console.WriteLine(names.ElementAt(0));              // Tom
        Console.WriteLine(names.OrderBy(n => n).First());   // Dick

        Console.WriteLine(names.Count());                   // 5
        Console.WriteLine(names.Min());                     // Dick
        Console.WriteLine(names.Max());                     // Tom

        Console.WriteLine(names.Contains("Tom"));           // True
        Console.WriteLine(names.Any());                     // True
        Console.WriteLine(names.Any(n => n.Length == 3));   // True
        Console.WriteLine(names.Any(n => n.Length == 8));   // False




    }

}



