namespace Live_20230502_2
{

    /* Ha B osztály A osztályból származik le, és
     * Mindkét osztálynak van statikus, és dinamikus konstruktora,
     * ekkor a lefutási sorrend:
     * 
     * 1., B osztály statikus konstruktora
     * 2., A osztály statikus konstruktora
     * 3., A osztály konstruktora
     * 4., B osztály konstruktora
     * 
     * 
     */




    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            A a1 = new A();
            A a2 = new A();
            a2.Kiir();
            */

            B b1 = new B();
        }
    }


    public class B : A
    {
        public B()
        {
            Console.WriteLine("B Public konstruktor");
        }

        // A static konstruktor, csak akkor fut le, egyszer, mikor az osztályból az első példányt létrehozzuk!!
        static B()
        {
            Console.WriteLine("B Static konstruktor");
        }
    }


    public class A
    {
        int x;

        // A static változót minden példányosított osztály látja!!
        static int y;

        public A()
        {
            Console.WriteLine("A Public konstruktor");
            x++;
        }

        // A static konstruktor, csak akkor fut le, egyszer, mikor az osztályból az első példányt létrehozzuk!!
        static A()
        {
            Console.WriteLine("A Static konstruktor");
            y++;
        }

        public void Kiir()
        {
            Console.WriteLine($"x: {x} , y: {y}");
        }
    }

}