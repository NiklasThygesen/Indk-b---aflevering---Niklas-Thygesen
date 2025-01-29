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
        public IActionResult RegistrerIndkøb(TilføjVarer tilføjVarer)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(tilføjVarer.Category))
                {
                    tilføjVarer.Category = "Ukendt"; // Sæt en standardkategori, hvis ingen kategori vælges
                }
                Repository.AddTilføjVarer(tilføjVarer);
                return RedirectToAction("SlutListe"); // Gå direkte til slutlisten
            }
            return View(tilføjVarer);
        }

        public IActionResult Tilføj()
        {
            return RedirectToAction("RegistrerIndkøb");
        }

        public ViewResult SlutListe()
        {
            var items = Repository.Tilføj ?? new List<TilføjVarer>(); // Garanterer, at items aldrig er null
            return View(items);
        }

        public IActionResult ReturFraSlutListe()
        {
            return RedirectToAction("RegistrerIndkøb");
        }

        public IActionResult FjernVare(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                Repository.RemoveTilføjVarer(name);
            }
            return RedirectToAction("SlutListe");
        }

    }
}
