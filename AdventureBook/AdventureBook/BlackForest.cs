using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureBook
{
    class BlackForest : Adventure
    {
        public BlackForest(Gamer gamer) : base(gamer)
        {
            Answers = new();
            Answers.Add(new(1, "Megérkeztéel", $"Egy sötét erdőben találod magad, egy útelágazásnál. \nMerre tovább, {gamer.Name}? ", new List<int> { 2, 3 }, 0));
            Answers.Add(new(2, "Piros kereszt", $"Az utadba kerül egy törpe, aki segítséget kér. Mit teszel? ", new List<int> { 4, 5 }, 1));
            Answers.Add(new(3, "Kék csík", $"Az utadba kerül egy gödör. Megpróbálod átudrani, vagy kikerülöd?", new List<int> { 6, 7 }, 1));
            Answers.Add(new(4, "Otthagyod a törpét", $"Mivel nem segítettél, ezért megátkoz. Ez az életerődön is megmutatkozik!", new List<int> { 8 }, 2));
            Answers.Add(new(5, "Segítesz a törpének", $"Mivel segítettél a törpének, jutalmul javít az életerődön!", new List<int> { 8 }, 4));
            Answers.Add(new(6, "Ugrás", $"Mivel rosszul mérted fel a távolságot, beleestél a gödörbe. Az életerőd megcsappant.", new List<int> { 8 }, 3));
            Answers.Add(new(7, "Kikerülés", $"Sikeresen kikerülted a gödröt, haladhatsz tovább.", new List<int> { 8 }, 3));
            Answers.Add(new(8, "Kérdés", $"Mennyi egy töketlen fecske maximális repülési sebessége?", new List<int> { 9, 10 }, 0));
            Answers.Add(new(9, "Annyi mint a tökösé", $"Sajons ez rossz válasz, elfogyott az életerőd!", new List<int> { }, 0));
            Answers.Add(new(10, "Afrikai vagy erurópai fecske?", "", new List<int> { }, 0));
        }

        private List<Answer> Answers { get; }

        public override void Run()
        {
            var currentAnswer = Answers[0];

            while (true)
            {

                if (currentAnswer.Level > 0)
                {
                    var random = new Random();
                    if (random.Next(1, 5 - currentAnswer.Level) == 1)
                    {
                        Fight();

                    }
                }

                Console.WriteLine($"{Gamer.Name} | HP: {Gamer.Vitality}");
                Console.WriteLine(currentAnswer.Label);
                Console.WriteLine(currentAnswer.Text);

                if (currentAnswer.Paths.Count > 0 && Gamer.Vitality > 0)
                {
                    Console.WriteLine("\nVálassz!");
                    foreach (var choosenNumber in currentAnswer.Paths)
                    {
                        var path = GetAnswer(choosenNumber);
                        Console.WriteLine($"{choosenNumber}: {path?.Label ?? "-ismeretlen lehetőség-"}");
                    }

                    Answer? nextAnswer;
                    while (!int.TryParse(Console.ReadLine(), out var sNumber) ||
                        ((nextAnswer = GetAnswer(sNumber)) == null) ||
                        !currentAnswer.Paths.Contains(sNumber)) { }

                    currentAnswer = nextAnswer;

                    switch (currentAnswer.Number)
                    {
                        case 2:
                            Console.WriteLine("  ");
                            Gamer.Vitality -= 20;
                            break;
                        case 7:

                            break;

                        case 10:
                            Console.WriteLine("Elérted a célod, kijutottál az erdőből!\n ");
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("A történeted itt véget ért.");
                    break;
                }
            }


        }

        private void Fight()
        {

            var monster = new Monster("Dragon", 50);
            Console.WriteLine("");
            Console.WriteLine($"Az utad során találkoztál a {monster.Name} szörnnyel, akivel meg kell küzdened! Az ő életereje:  {monster.Vitality} ");
            Console.WriteLine("Mindketen dobókockával dobtok:");
            var random = new Random();
            int selfResult = 0;
            int monsterResult = 0;

            do
            {
                selfResult = random.Next(1, 7);
                monsterResult = random.Next(1, 7);
                if (selfResult > monsterResult)
                {
                    monster.Vitality = monster.Vitality - (selfResult - monsterResult);
                }
                else
                {
                    Gamer.Vitality = Gamer.Vitality - (monsterResult - selfResult);
                }

                Console.WriteLine($"A Te dobásod értéke: {selfResult} , a rendelkezésre álló életerőd: {Gamer.Vitality}, a szörny dobása: {monsterResult}, életereje:{monster.Vitality}");
            } while (Gamer.Vitality > 0 && monster.Vitality > 0);

        }

        private Answer? GetAnswer(int number)
        {
            foreach (var answer in Answers)
            {
                if (answer.Number == number)
                {
                    return answer;
                }
            }
            return null;
        }
    }
}