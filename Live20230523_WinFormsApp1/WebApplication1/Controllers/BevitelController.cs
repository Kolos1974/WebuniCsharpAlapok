using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BevitelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Bevitel()
        {
            EmberModel em = new EmberModel();
            em.EmberNeve = Request.Form["embernev"];
            em.RogzitesDatuma = DateTime.Now;
            return View(em);
        }

    }
}
