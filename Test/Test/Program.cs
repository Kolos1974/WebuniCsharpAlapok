


using System;

class Program
{

    public string prName = "Test program";


    static void Main(string[] args)
    {
        string s1 = "Szöveg1";
        String s2 = "Szöveg2";


        // Console.WriteLine("Hello, World!");
        Console.WriteLine(s1);
        Console.WriteLine(s2);

        Console.WriteLine(s1.Length);
        Console.WriteLine(s2.Length);

        var pr = new Program();
        pr.prName = "Más nevű program";
        //pr.Main(new string[2]);

        // Meg tudom hívni a statikus metódust! A program futásából hívom a programot.. 
        // Rekurzív hívás lett!!
        // Program.Main(args);


    }

}


class Tortenet
{
    public Tortenet(int Param)
    {
        this.Param = Param;
    }

    public int Param { get; }
}


