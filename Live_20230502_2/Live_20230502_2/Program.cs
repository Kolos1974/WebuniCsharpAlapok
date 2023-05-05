namespace Live_20230502_2
{

    internal class Program
    {
        static void Main(string[] args)
        {
            A a1 = new A();
            A a2 = new A();
            a2.Kiir();

        }


    }

    public class A
    {
        int x;
        
        // A static változót minden példányosított osztály látja!!
        static int y;


        public A()
        {
            Console.WriteLine("Public konstruktor");
            x++;
        }


        // A static konstruktor, csak akkor fut le, egyszer, mikor az osztályból az első példányt létrehozzuk!!
        static A()
        {
            Console.WriteLine("Static konstruktor");
            y++;

        }

        public void Kiir()
        {
            Console.WriteLine($"x: {x} , y: {y}");
        }


    }



}