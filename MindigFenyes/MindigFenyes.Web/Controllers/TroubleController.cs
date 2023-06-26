using Microsoft.AspNetCore.Mvc;
using MindigFenyes.DB;
using MindigFenyes.Web.Models;
using System.Net.Sockets;

namespace MindigFenyes.Web.Controllers
{
    public class TroubleController : Controller
    {

        private readonly MindigFenyesDBData mfcontext;

        public TroubleController(MindigFenyesDBData mfcontext)
        {
            this.mfcontext = mfcontext;
        }


        // public IActionResult Index()
        public IActionResult Trouble()
        {
            return View();
            /*
            TroubleViewModel tvm = new TroubleViewModel();
            tvm.PostalCode = Request.Form["psc"];
            // em.RogzitesDatuma = DateTime.Now;
            return View(tvm);
            */
        }


        public IActionResult Submit(TroubleViewModel ticketAddressRequest)
        {
            // Address? address = mfcontext.Addresses.SingleOrDefault(t => t.PostalCode == taskRequest.PostalCode && t.Street.Equals(ticketAddressRequest.Street) && t.Number == ticketAddressRequest.Number);


            // MindigFenyes.DB.Trouble trouble = new MindigFenyes.DB.Trouble()
            Trouble trouble = new MindigFenyes.DB.Trouble()
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

            mfcontext.Troubles.Add(trouble);
            mfcontext.SaveChanges();

            return View();
        }

    }
}
