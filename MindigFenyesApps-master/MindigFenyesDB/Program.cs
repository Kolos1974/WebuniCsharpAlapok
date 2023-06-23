using MindigFenyesDB.Data;
using MindigFenyesDB.Models;

namespace MindigFenyesDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddWorker("Alma Aladár");
            AddWorker("Banán Bála");
            //AddWorker("Citrom Cecil");
            //AddWorker("Dió Dániel");
            //AddWorker("Eper Elemér");

            /* 2023.06.22.
            using (var context = new MindigFenyesContext())
            {
                var ticketToDel = context.Addresses.Find(1002);
                context.Addresses.Remove(ticketToDel);
                context.SaveChanges();
            }
            */

            void AddWorker(string name)
            {
                using (var context = new MindigFenyesContext())
                {
                    var worker = new Worker { Name = name };

                    // 2023.06.21.
                    // context.Workers.Add(worker);
                    
                    context.Add(worker);
                    context.SaveChanges();
                }
            }
        }
    }
}