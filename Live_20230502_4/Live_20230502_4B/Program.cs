using System.Collections;

namespace Live_20230502_4B
{
    internal class Program
    {

        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>();

            autok.Add(new Auto("AAA-123", "Ford"));
            autok.Add(new Auto("BBB-123", "Porsche"));

            foreach (Auto auto in autok)
            {
                Console.WriteLine(auto.PlateNumber + " - " + auto.Brand);
                //Console.WriteLine(auto);

            }


            Console.WriteLine("--------");

            Jarmuvek jm = new Jarmuvek();
            jm.addAuto(new Auto("AAA-123", "Ford"));
            jm.addAuto(new Auto("BBB-123", "Porsche"));
            foreach (Auto a in jm)
            {
                Console.WriteLine(a.PlateNumber + " - "+ a.Brand);
            }


        }
    }


    public class Auto
    {
        public String PlateNumber { get; set; }
        public String Brand { get; set; }

        public Auto(String PlateNumber, String Brand)
        {
            this.PlateNumber = PlateNumber;
            this.Brand = Brand;
        }

    }

    public class Jarmuvek : IEnumerable
    {
        List<Auto> autok;

        public Jarmuvek()
        {
            autok = new();
        }


        public void addAuto(Auto auto)
        {
            autok.Add(auto);
        }

        public IEnumerator GetEnumerator()
        {
            return new JarmuvekEnumerator(autok);
        }
    }


    public class JarmuvekEnumerator : IEnumerator
    {
        List<Auto> localAutok;
        int i = -1;

        public JarmuvekEnumerator(List<Auto> autok)
        {
            localAutok = autok;
        }


        public object Current => localAutok[i];

        public bool MoveNext()
        {
            if (i < localAutok.Count - 1)
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

