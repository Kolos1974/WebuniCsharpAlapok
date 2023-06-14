

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

}