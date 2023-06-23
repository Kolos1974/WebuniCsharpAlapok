

internal class Program
{
    static void Main(string[] args)
    {
        List<int> ints = new();

        string?  ures = null;

        int x = 10;
        int y = 20;

        Csere1(ref x, ref y);
        Console.WriteLine($"{x}, {y}");

        double xd = 10;
        double yd = 20;
        Csere2(ref xd, ref yd);

        Console.WriteLine($"{xd}, {yd}");


        Console.WriteLine();
        Console.WriteLine("CsereGenerikus:");

        Console.WriteLine($"{x}, {y}");
        CsereGenerikus(ref x, ref y);
        Console.WriteLine($"{x}, {y}");

        Console.WriteLine($"{xd}, {yd}");
        CsereGenerikus(ref xd, ref yd);
        Console.WriteLine($"{xd}, {yd}");

        
        
        Console.WriteLine();
        Console.WriteLine("CsereGenerikus Osztály:");

        //CsereOsztaly<T> cs = new();
        // cs.


        // Factory - Design Pattern
        Console.WriteLine();
        HEFactory<Pohar> pohargyar = new();
        HEFactory<Edeny> edenygyar = new();

        List<HaztartasiEszkoz> eszkozok = new();

        Pohar p;
        p = pohargyar.GetEszkoz();

        Edeny e;
        e = edenygyar.GetEszkoz();

        eszkozok.Add(p);
        eszkozok.Add(e);
        eszkozok.Sort();



        Pohar p1;
        p1 = pohargyar.GetEszkoz();
        p1.Meret = 33;

        Pohar p2;
        p2 = pohargyar.GetEszkoz();
        p2.Meret = 33;


        if (p1==p2)
        {
            Console.WriteLine("A poharam azonos");
        }
        else
        {
            Console.WriteLine("A poharam nem azonos");
        }


        if (p1.Equals(p2))
        {
            Console.WriteLine("A poharam azonos");
        }
        else
        {
            Console.WriteLine("A poharam nem azonos");
        }

    }

  

    private static void Csere1(ref int a, ref int b)  // out
    {
        int temp = a;
        a = b;
        b = temp;
    }

    private static void Csere2(ref double a, ref double b)
    {
        double temp = a;    
        a = b;
        b = temp;
    }

    public static void CsereGenerikus<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }


    public class CsereOsztaly<T>
    {

        public  void CsereGenerikus<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }

    }


    // Factory
    public abstract class HaztartasiEszkoz : IComparable
    {
        public int Meret { get; set; }

        public int CompareTo(object? obj)
        {
            if (((HaztartasiEszkoz)obj).Meret == Meret)
            {
                return 0;
            }

            if (((HaztartasiEszkoz)obj).Meret < Meret)
            {
                return -1;
            }

            return 1;
        }
    }


    public class Edeny : HaztartasiEszkoz
    {

    }

    public class Pohar : HaztartasiEszkoz, IEquatable<Pohar>
    {
        public bool Equals(Pohar? other)
        {
            if (Meret == other.Meret)
            {
                return true;
            }
            return false;
        }


        public static bool operator == (Pohar p1,  Pohar p2)
        {
            if (p1.Meret == p2.Meret)
            {
                return true;
            }
            return false;

        }

        public static bool operator !=(Pohar p1, Pohar p2)
        {
            if (p1.Meret != p2.Meret)
            {
                return true;
            }
            return false;

        }



    }

    public class HEFactory<T> where T : new() 
    {

        public T GetEszkoz()
        {
            return new T();
        }

    }



}