using System.Collections;

namespace Live_20230418_FizzBuzz
{
    internal class Program
    {

        static void Main(string[] args)
        {

            for (int i = 1;  i <31; i++)
            {
                Console.WriteLine($"A szám: {i}");
                Fb(i);
                Console.WriteLine();

                Fb2(i);

                Console.WriteLine();
                Console.WriteLine();
            }

            static void Fb(int i)
            {
                if (i % 3 == 0 && i % 5 == 0) {
                    Console.Write("FizzBuzz");
                } else if (i % 3 == 0)
                {
                    Console.Write("Fizz");
                }
                else if (i % 5 == 0)
                {
                    Console.Write("Buzz");
                } else
                {
                    Console.Write(i);
                }
            }


            static void Fb2(int i)
            {
                string s = "";

                if (i % 3 == 0)
                {
                    s = "Fizz";
                }

                if (i % 5 == 0)
                {
                    s = $"{s}Buzz";
                }

                if (s.Length == 0)
                {
                    s = i.ToString();
                }

                Console.WriteLine(s);

            }

        }
    }
}


