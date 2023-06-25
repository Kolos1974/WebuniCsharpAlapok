using Microsoft.AspNetCore.Mvc;
using MindigFenyes.DB;
using MindigFenyes.Web.Models;
using System.Net.Sockets;

namespace MindigFenyes.Web.Controllers
{
    public class TaskController : Controller
    {

        private readonly MindigFenyesDBData mfcontext;

        public TaskController(MindigFenyesDBData mfcontext)
        {
            this.mfcontext = mfcontext;
        }


        // public IActionResult Index()
        public IActionResult Task()
        {
            return View();
        }


        public IActionResult Submit(TaskViewModel ticketAddressRequest)
        {
            // Address? address = mfcontext.Addresses.SingleOrDefault(t => t.PostalCode == taskRequest.PostalCode && t.Street.Equals(ticketAddressRequest.Street) && t.Number == ticketAddressRequest.Number);


            MindigFenyes.DB.Task task = new MindigFenyes.DB.Task()
            { 
                /*
                Address = address ??= new Address
                {
                    PostalCode = taskRequest.ZipCode,
                    Street = taskRequest.Street,
                    Number = taskRequest.Number
                },
                */
                TroubleDate = DateTime.Now,
            };

            mfcontext.Tasks.Add(task);
            mfcontext.SaveChanges();

            return View();
        }

    }
}
