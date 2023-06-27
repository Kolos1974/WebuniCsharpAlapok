using FinalExam.DB;
using FinalExam.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.Web.Controllers
{
    public class TroubleAddController : Controller
    {

        private readonly FinalExamDataDB fedbcontext;

        
        public TroubleAddController(FinalExamDataDB fedbcontext)
        {
            this.fedbcontext = fedbcontext;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        /*
        public IActionResult TroubleAdd()
        {
            TroubleViewModel tm = new TroubleViewModel();
            tm.PostalCode = int.Parse(Request.Form["postalcode"]);
            tm.Street = Request.Form["street"];
            tm.Number = Request.Form["number"];
            tm.TroubleDate = DateTime.Now;
            return View(tm);

        }
        */

        
        //public IActionResult Submit(TroubleViewModel troubleRequest)
        public IActionResult TroubleAdd(TroubleViewModel troubleRequest)
        {

            Trouble trouble = new FinalExam.DB.Trouble()
            {
                PostalCode = troubleRequest.PostalCode,
                Street = troubleRequest.Street,
                Number = troubleRequest.Number,
                TroubleDate = DateTime.Now
            };

            fedbcontext.Troubles.Add(trouble);
            fedbcontext.SaveChanges();

            /*
            TroubleViewModel tm = new TroubleViewModel();
            tm.PostalCode = int.Parse(Request.Form["postalcode"]);
            tm.Street = Request.Form["street"];
            tm.Number = Request.Form["number"];
            tm.TroubleDate = DateTime.Now;
            */
            troubleRequest.TroubleDate = (DateTime)trouble.TroubleDate;

            return View(troubleRequest);
        }
        

    }
}
