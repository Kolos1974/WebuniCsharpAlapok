using FinalExam.DB;
using FinalExam.DLL;
using System.Net.Sockets;

internal class Program
{
    static void Main(string[] args)
    {
        
        var context = new FinalExamDataDB();
        FinalExamDataDbQuerry fedq = new FinalExamDataDbQuerry();

        Console.WriteLine("Kérlek add meg az azonosítószámod!");
        int workerId;
        List<Worker> workers = context.Workers.ToList();
        while (!int.TryParse(Console.ReadLine(), out workerId) || workers.SingleOrDefault(m => m.Id == workerId) is null)
        {
            Console.WriteLine("Rossz azonosítót adtál meg, próbálja újra!");
        }
        var worker = context.Workers.SingleOrDefault(m => m.Id == workerId);
        Console.WriteLine($"Tisztelt {worker!.Name}, adja meg az elvégzett javítás sorszámát!");
        int troubleId;
        while (true)
        {
            List<Trouble> openTroubles = context.Troubles.Where(t => t.RepairTypeId == null).ToList();
            while (!int.TryParse(Console.ReadLine(), out troubleId) || openTroubles.SingleOrDefault(m => m.Id == troubleId) is null && troubleId != 0)
            {
                Console.WriteLine("Rossz sorszámot adtál meg, kérlek próbáld újra!");
            }
            if (troubleId == 0) //kilépés
            {
                break;
            }
            Console.WriteLine("Aja meg a meghibásodás okát:");
            foreach (var rt in fedq.AllOfRepairType())
            {
                Console.WriteLine($"{rt.Id}. {rt.Description}");
            }

            int repairId;

            while (!int.TryParse(Console.ReadLine(), out repairId) || repairId < 0 || repairId > 3)
            {
                Console.WriteLine("Ez a javítási azonosító nem léztezik!");
            }
            var troubleToRepaired = openTroubles.Find(t => t.Id == troubleId);
            troubleToRepaired!.WorkerId = workerId;
            troubleToRepaired!.RepairDate = DateTime.Now;
            troubleToRepaired!.RepairTypeId = repairId;
            context.SaveChanges();
            Console.WriteLine($"A {troubleId} sorszámú hibajegy lezárásra került!");
            Console.WriteLine("További hiba lezárásához adja meg a sorszámát, vagy kilépés 0 megadásával:");
        }
    }
}
