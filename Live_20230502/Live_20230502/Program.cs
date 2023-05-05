
namespace Live_20230502
{

    internal class Program
    {
        static void Main(string[] args)
        {
            FB(0, 100);
        }

        static void FB(int a, int f)
        {
            Enumerable.Range(a, f)
                .ToList()
                .ForEach(i => Console.WriteLine((i % 15 == 0) ? "FizzBuzz" : (i % 3 == 0) ? "Buzz" : (i % 5 == 0) ?
                "Fizz" : i.ToString()));
        }


    }


}