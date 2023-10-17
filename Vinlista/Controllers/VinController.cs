using Microsoft.AspNetCore.Mvc;
using Vinlista.Models;

namespace Vinlista.Controllers
{
    public class VinController : Controller
    {
        private readonly VinMetod _vinMetod;

        public VinController()
        {
            _vinMetod = new VinMetod();
        }

        public IActionResult Index()
        {
            var vinList = _vinMetod.GetVin();
            return View(vinList);
        }
    }
}
