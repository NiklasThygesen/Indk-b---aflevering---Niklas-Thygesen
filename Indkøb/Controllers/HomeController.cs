using Indkøb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Indkøb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RegistrerIndkøb()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RegistrerIndkøb(TilføjVarer tilføjVarer)
        {

            if (ModelState.IsValid)
            {
                Repository.AddTilføjVarer(tilføjVarer);
                return View("Tilføjet", tilføjVarer);
            } else
            {
                return View(tilføjVarer);
            }
            
        }

        public IActionResult Tilføj()
        {
            return RedirectToAction("RegistrerIndkøb");
        }

        public ViewResult SlutListe()
        {
            var items = Repository.Tilføj; // Henter listen fra repository
            return View(items); // Sender data til viewet
        }

        public IActionResult ReturFraSlutListe()
        {
            return RedirectToAction("RegistrerIndkøb");
        }

        public IActionResult FjernVare(string name)
        {
            Repository.RemoveTilføjVarer(name);
            return RedirectToAction("SlutListe");
        }

    }
}
