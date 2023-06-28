using FinalExam.DB;
using FinalExam.DLL;
using System.Net.Sockets;

internal class Program
{
    static void Main(string[] args)
    {
        // FinalExamDataDB fedq = new FinalExamDataDB();
        FinalExamDataDbQuerry fedq = new FinalExamDataDbQuerry();
        int findingNumber;
        List<Trouble> result = new List<Trouble>();

        Console.WriteLine("Lekérdezések típusai:");
        Console.WriteLine("- lekérdezés irányítószámra 4 jegyű szám megadásával");
        Console.WriteLine("- lekérdezés kerületre 3 jegyű szám megadásával");
        Console.WriteLine("- lekérdezés x napnál régebbi hibajegyekre 100-nál kisebb szám megadásával");
        Console.WriteLine("- kilépés 0 megadásával");
        Console.WriteLine();
        Console.WriteLine("Add meg a számot a lekérdezéshez!");

        while (true)
        {
            while (!int.TryParse(Console.ReadLine(), out findingNumber))
            {
                Console.WriteLine("Add meg a számot a lekérdezéshez!");
            }
            if (findingNumber == 0)
            {
                break;
            }
            else if (findingNumber < 100)
            {
               result = fedq.OpenTroubleOlderThan(findingNumber);
            }
            else if (findingNumber > 100 && findingNumber < 1000)
            {
                result = fedq.OpenTroubleFromDistrict(findingNumber);
            }
            else if (findingNumber >= 1000 && findingNumber < 10000)
            {
               result = fedq.OpenTroubleFromPostalCode(findingNumber);
            }
            if (result.Count > 0)
            {
                foreach (var tr in result)
                {
                    ShowTroubleDetails(tr);
                }
            }
            else
            {
                Console.WriteLine("Sajnos nem találtunk a lekérdezésnek megfelelő elemet!");
            }

        }

    }

    public static void ShowTroubleDetails(Trouble tr)
    {
        Console.WriteLine();
        Console.WriteLine($"Az irányítószám: {tr.PostalCode}");
        Console.WriteLine($"Az utca:  {tr.Street}");
        Console.WriteLine($"A házszám: {tr.Number}");
        Console.WriteLine($"A rögzítés dátuma: {tr.TroubleDate}");
    }

}