using System.Collections;

namespace Live_20230502_4
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Emberek e = new();
            e.Bovit("Peti");
            e.Bovit("Kati");
            e.Bovit("Peti");

            Console.WriteLine(e.nevek[0]);
            Console.WriteLine("--------");



            foreach (string nev in e.nevek)
            {
                Console.WriteLine(nev); 
            }
            Console.WriteLine("--------");


            foreach (string nev in e)
            {
                Console.WriteLine(nev);
            }
            Console.WriteLine("--------");


        }
    }



    public class Emberek : IEnumerable
    {
        public List<string> nevek;

        public Emberek()
        {
            nevek = new();
        }

        public bool Hozzaad(string nev)
        {
            if (nevek.Contains(nev))
            {
                return false;
            }
            nevek.Add(nev);
            return true;

        }

        public void Bovit(string nev)
        {
            if (Hozzaad(nev))
            {
                Console.WriteLine($"{nev} - Sikeres hozzáadás");
            }
            else
            {
                Console.WriteLine($"{nev} - Sikertelen hozzáadás");
            }



        }

        public IEnumerator GetEnumerator()
        {
            return new EmberEnumerator(nevek);
        }
    }


    public class EmberEnumerator : IEnumerator
    {
        List<string> lokalisadatok;
        int i = -1;

        public EmberEnumerator(List<string> adatok)
        {
            lokalisadatok = adatok;
        }


        public object Current => lokalisadatok[i];

        public bool MoveNext()
        {
            if (i < lokalisadatok.Count - 1)
            {
                i++;
                return true;
            }
            else
            { return false; }

        }

        public void Reset()
        {
            i = -1;
        }
    }

}

