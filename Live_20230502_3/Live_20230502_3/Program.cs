using System.Security.Cryptography;

namespace Live_20230502_3
{
    internal class Prorgam
    {

        static void Main(string[] args)
        {
            A a2 =new A();
            A a = new();
            a.X = 10;
            int i = 10;
            string s = "10";
            int[] ik = new int[2] {10, 20};

            Kiir(a, i, s, ik);
            Console.WriteLine($"{a.X}, {i}, {s}, {ik[0]} ");
            Kiir2(a, out i, s, ik);
            Kiir3(a, ref i, s, ik);

        }


        static void Kiir(A helyia, int helyii, string helyis, int[] helyik)
        {
            Console.WriteLine($"{helyia.X}, {helyii}, {helyis}, {helyik[0]} ");
            helyia.X = 111;
            helyii = 111;
            helyis = "111";
            helyik[0] = 111;
        }

        // "out" kulcsszóval visszaadunk értéket a függvényből a hívónak!
        static void Kiir2(A helyia, out int helyii, string helyis, int[] helyik)
        {
            helyii = 111;
            Console.WriteLine($"{helyia.X}, {helyii}, {helyis}, {helyik[0]} ");
            helyia.X = 111;
            
            helyis = "111";
            helyik[0] = 111;
        }

        // "ref" kulcsszóval az átadott paraméter referenciaként működik.
        static void Kiir3(A helyia, ref int helyii, string helyis, int[] helyik)
        {
            Console.WriteLine($"{helyia.X}, {helyii}, {helyis}, {helyik[0]} ");
            helyia.X = 111;
            helyii = 111;
            helyis = "111";
            helyik[0] = 111;
        }


    }


    class A
    {
        public int X { get; set; }


    }


}
