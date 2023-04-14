using System;
using System.Collections.Generic;

namespace Dialogusfa
{
    class Program
    {
        static void Main(string[] args)
        {
            string? nev = null;
            Console.Write("Üdv! ");
            while (string.IsNullOrWhiteSpace(nev))
            {
                Console.WriteLine("Add meg a neved:");
                nev = Console.ReadLine();
            }
            Console.WriteLine("\nA kalandod elkezdődik...\n");

            var jatekos = new Jatekos(nev);
            var aGoblinNapja = new AGoblinNapja(jatekos);
            aGoblinNapja.Futtatas();
        }
    }
}

class Jatekos
{
    public Jatekos(string nev)
    {
        Nev = nev;
    }

    public string Nev { get; }
    public int Eletero { get; set; } = 90;
    public bool Kalapacs { get; set; }
}

abstract class Tortenet
{
    public Tortenet(Jatekos jatekos)
    {
        Jatekos = jatekos;
    }

    public Jatekos Jatekos { get; }

    public abstract void Futtatas();
}

class AGoblinNapja : Tortenet
{
    public AGoblinNapja(Jatekos jatekos) : base(jatekos)
    {
        ValaszLehetosegek = new();
        ValaszLehetosegek.Add(new(1, "Felébredsz", $"Egy bárban ébredsz, egyik kezedben egy félig megrágcsált sajttömböt szorongatva, mire a melletted ülő, jóvágású goblin felteszi a kérdést, ami életed hátralevő részét megváltoztatta:\n- Merre tovább, {jatekos.Nev}? És mi lesz a sajttal?", new List<int> { 2, 3 }));
        ValaszLehetosegek.Add(new(2, "Megeszed a sajtot", $"Bár a sajt első ízlelésre finomnak tűnt, utólag ezt megbántad, mert úgy tűnik, jelentősen elmúlt a lejárati dátuma. Az is lehet, hogy sosem volt ettől jobb...\n- ", new List<int> { 4 }));
        ValaszLehetosegek.Add(new(3, "Odaadod a goblinnak a sajtot", "- Tessék. Neked nagyobb szükséged lesz rá, mint nekem.\nA goblin kétlőn néz, majd egyben lenyeli az egész sajttömböt.", new List<int> { 4 }));
        ValaszLehetosegek.Add(new(4, "Eltöprengsz a lehetőségeiden", "Elgondolkodsz, hogy mit is keresel itt. Nem tudod, miért aludtál el a bárban, és nem emlékszel pontosan, hogy ismered-e a melletted ülő goblint vagy sem. Valószínűleg kifárasztott a háromfülű robot felkutatása. Felébredsz, és körbenézve két lehetőség áll előtted, hogy elérd a robot házát: a hosszabb utat választod (amerre tudod, hogy Blovir is indult a minap), vagy a rövidebbet, ami a közeli sötét sikátoron át vezet?", new List<int> { 5, 6 }));
        ValaszLehetosegek.Add(new(5, "A rövidebb utat választod (a sikátoron át)", "A rövidebb út a sikátoron át vezet a robot házához. A sikátoron át haladva egy szakadtfülű troll állja az utatokat. A troll kezében egy törött kalapácsot veszel észre, épp, amikor ő is meglát téged, de goblin társad szerencsére nem látja az árnyékokban.", new List<int> { 7, 8 }));
        ValaszLehetosegek.Add(new(6, "A hosszabb utat választod (amerre Blovir is ment)", "Goblin társaddal útnak indultok a kerülőúton. Biztosan nem választhatsz rosszul, mert Blovir, a fejvadász is erre indult tegnap.\nAmikor megpillantod Blovir holttestét az út mellett, úgy döntesz, mégiscsak a rövidebb út lett volna a jó választás.", new List<int> { 5 }));
        ValaszLehetosegek.Add(new(7, "Útbaigazítást kérsz a trolltól (amíg goblin társad agyoncsapja a trollt)", "Csendben intesz goblin társadnak, hogy maradjon az árnyékban, de kacsintasz is neki jelezvén, hogy álljon készen.\nKözelebb kerülsz a trollhoz, és megkérdezed\n- Merre találom a háromfülű robot házát?\nEzután goblin társad - eszedbe jutott, 'Grom' - hangtalanul és észrevétlenül a troll mögé fut, kikapja a kezéből a törött kalapácsot, és agyoncsap... téged.", new List<int> { 1 }));
        ValaszLehetosegek.Add(new(6, "A hosszabb utat választod (amerre Blovir is ment)", "Goblin társaddal útnak indultok a kerülőúton. Biztosan nem választhatsz rosszul, mert Blovir, a fejvadász is erre indult tegnap.\nAmikor megpillantod Blovir holttestét az út mellett, úgy döntesz, mégiscsak a rövidebb út lett volna a jó választás.", new List<int> { 5 }));
        ValaszLehetosegek.Add(new(8, "Leveszed a maszkod", "Leveszed maszkod, a troll pedig az arcod láttán elszörnyülködve elfut. Maga mögött hagyja a törött kalapácsot, amit elteszel a tarsolyodba.", new List<int> { 9 })); 
    }

    private List<ValaszLehetoseg> ValaszLehetosegek { get; }

    public override void Futtatas()
    {
        var aktualisValasztas = ValaszLehetosegek[0];

        while (true)
        {
            Console.WriteLine($"{Jatekos.Nev} | HP: {Jatekos.Eletero}");
            Console.WriteLine(aktualisValasztas.Cimke);
            Console.WriteLine(aktualisValasztas.Szoveg);

            if (aktualisValasztas.TovabbiLehetosegek.Count > 0 && Jatekos.Eletero > 0)
            {
                Console.WriteLine("\nVálassz!");
                foreach (var sorszam in aktualisValasztas.TovabbiLehetosegek)
                {
                    var lehetoseg = GetValaszLehetoseg(sorszam);
                    Console.WriteLine($"{sorszam}: {lehetoseg?.Cimke ?? "-ismeretlen lehetőség-"}");
                }

                ValaszLehetoseg? kovetkezoValasztas;
                while (!int.TryParse(Console.ReadLine(), out var sorszam) ||
                    ((kovetkezoValasztas = GetValaszLehetoseg(sorszam)) == null) ||
                    !aktualisValasztas.TovabbiLehetosegek.Contains(sorszam)) { }

                aktualisValasztas = kovetkezoValasztas;

                switch (aktualisValasztas.Sorszam)
                {
                    case 2:
                        Console.WriteLine("Sajnos a sajt az ellenkező hatását váltotta ki, mint vártad.");
                        Jatekos.Eletero -= 20;
                        break;
                    case 7:
                        Jatekos.Kalapacs = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("A történeted itt véget ért.");
                break;
            }
        }
    }

    private ValaszLehetoseg? GetValaszLehetoseg(int sorszam)
    {
        foreach (var lehetoseg in ValaszLehetosegek)
        {
            if (lehetoseg.Sorszam == sorszam)
            {
                return lehetoseg;
            }
        }
        return null;
    }
}

class ValaszLehetoseg
{
    public ValaszLehetoseg(int sorszam, string cimke, string szoveg, List<int> tovabbiLehetosegek)
    {
        Sorszam = sorszam;
        Cimke = cimke;
        Szoveg = szoveg;
        TovabbiLehetosegek = tovabbiLehetosegek;
    }

    public int Sorszam { get; }
    public string Cimke { get; }
    public string Szoveg { get; }
    public List<int> TovabbiLehetosegek { get; }
}