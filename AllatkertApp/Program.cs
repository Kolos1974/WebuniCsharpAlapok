using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var allatkert = new Allatkert("Fővárosi Állat- és Növénykert");
        allatkert.JegyEladasa("Gábor", 2800, 3000, "Felnőtt");

        foreach (var jegy in allatkert.jegyek)
        {
            Console.WriteLine(jegy);
        }

        // Így is lehet végigmenni a listán:
        foreach (Jegy jegy in allatkert.jegyek)
        {
            Console.WriteLine(jegy);
        }

        var elefant1 = new Elefant();
        // vagy.. 
        Elefant elefant2 = new Elefant();

        allatkert.Allatok.Add(elefant1);
        allatkert.Allatok.Add(elefant2);
        // Console.WriteLine(allatkert.Nev);

        // Ez lehetséges
        var allatok = new List<Allat>();

        // Ez nem megengedett, mert az Allatok tulajdonság csak olvasható!
        // allatkert.Allatok = new List<Allat>();


    }
}

class Allatkert
{
    public Allatkert(string nev)
    {
        Nev = nev;
        jegyek = new List<Jegy>();
    }
    public string Nev { get; }
    public List<Jegy> jegyek;
    public List<Allat> Allatok { get;  } = new();


    public void JegyEladasa(string eladoPenztaros, decimal eladasiAr, decimal eredetiAr, string tipus)
    {
        var jegy = new Jegy();
        jegy.eladasDatuma = DateTime.Now;
        jegy.eladoPenztarosNeve = eladoPenztaros;
        jegy.eladasiAr = eladasiAr;
        jegy.eredetiAr = eredetiAr;
        jegy.tipus = tipus;

        jegyek.Add(jegy);
    }
}

class Jegy
{
    public DateTime eladasDatuma;
    public string eladoPenztarosNeve;
    public string tipus;
    public decimal eredetiAr;
    public decimal eladasiAr;

    public override string ToString() => $"{tipus} eladva {eladoPenztarosNeve} által {eladasiAr} áron ({eredetiAr} helyett) {eladasDatuma}-kor";
}

abstract class Allat
{
    public Allat()
    {
        
    }

    public string Nev { get; set; }
    public virtual void Koszon() { Console.WriteLine("Szia! Én egy állat vagyok."); }
}

class Elefant : Allat
{
    public override void Koszon()
    {
        Console.WriteLine($"Szia! Én {Nev} vagyok, elefánt.");
    }
}

class Vaddiszno : Allat
{

}