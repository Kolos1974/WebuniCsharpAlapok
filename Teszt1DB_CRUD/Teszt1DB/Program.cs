
using System.Reflection.Metadata.Ecma335;
using Teszt1DB;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Teszt1DB !");

        Adatok ad = new();
        foreach (var e in ad.Embers)
        {
            Console.WriteLine(e.Nev);
        }

        // Create
        Ember uj = new();
        uj.Nev = "Imre";
        uj.Szev = 1965;
        ad.Embers.Add(uj);
        ad.SaveChanges();

        // Read
        Console.WriteLine("");
        Console.WriteLine("Lekért ember:");
        Console.WriteLine(GetEmber(2).Nev.ToString());

        // Update
        using var ad2 = new Adatok();
        var EmberUpdate = ad2.Embers.Find(1);
        EmberUpdate.Nev = "Kati";
        ad2.SaveChanges();


        // Delete
        using var ad3 = new Adatok();

        // Ez csak akkor jó, ha biztosan megtalálná!!
        // ad3.Embers.Remove(new() {Id = 5});
        var emberDele = GetEmber(4);
        if (emberDele != null)
        {
            ad3.Embers.Remove(emberDele);
        }
        ad3.SaveChanges();


    }

    public static Ember GetEmber(int id)
    {
        Ember result = null;
        
        // Adatok ad = new();
        using var ad = new Adatok();

        foreach (var e in ad.Embers)
        {
            if (e.Id == id)
            {
                result = e; 
            }
        }
        return result;
    }



}

