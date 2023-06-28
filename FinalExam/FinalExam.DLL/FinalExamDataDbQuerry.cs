using FinalExam.DB;
using System.Net.Sockets;

namespace FinalExam.DLL
{
    public class FinalExamDataDbQuerry
    {

        private readonly FinalExamDataDB _context;
        public FinalExamDataDbQuerry()
        {
            _context = new FinalExamDataDB();
        }


        public List<RepairType> AllOfRepairType()
        {
            List<RepairType> results = _context.RepairTypes.ToList();
            return results;
        }

        public List<Worker> AllOfWorkers()
        {
            List<Worker> results = _context.Workers.ToList();
            return results;
        }

        public Worker GetWorker (int id)
        {
            return _context.Workers.Find (id);
        }

        public RepairType GetRepairType (int id)
        {
            return _context.RepairTypes.Find (id);
        }

        public List<Trouble> OpenTroubleOlderThan(int days)
        {
            List<Trouble> results = new();
            foreach (var tr in _context.Troubles)
            {
                if (!(tr.RepairDate.HasValue))
                {
                    if (tr.TroubleDate < DateTime.Now.AddDays(days * -1))
                    {
                        results.Add(tr);
                    }
                }
            }
            return results;
        }

        public List<Trouble> OpenTroubleFromDistrict(int dist)
        {
            List<Trouble> results = new();
            foreach (var tr in _context.Troubles)
            {
                if (!(tr.RepairDate.HasValue))
                {
                    if (tr.PostalCode >= dist * 10 && tr.PostalCode < (dist + 10) * 10) 
                    {
                        results.Add(tr);
                    }
                }
            }
            return results;
        }


        public List<Trouble> OpenTroubleFromPostalCode(int postc)
        {
            List<Trouble> results = new();
            foreach (var tr in _context.Troubles)
            {
                if (!(tr.RepairDate.HasValue))
                {
                    if (tr.PostalCode == postc)  
                    {
                        results.Add(tr);
                    }
                }
            }
            return results;
        }


    }
}