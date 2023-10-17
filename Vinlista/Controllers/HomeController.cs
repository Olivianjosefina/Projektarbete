using Microsoft.AspNetCore.Mvc;
using Vinlista.Models; // Uppdatera detta till den faktiska sökvägen till dina modeller

namespace YourProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly VinMetod _vinMetod;

        public HomeController()
        {
            _vinMetod = new VinMetod(); // Se till att du har en instans av din VinMetod-klass
        }

        public IActionResult Index()
        {
            // Ditt nuvarande Index action-innehåll här
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Här kan du lägga till logiken för att spara användaren i databasen
                // Exempelvis: _vinMetod.RegisterUser(model);
                // Efter registrering kan du omdirigera användaren till en bekräftelsesida eller logga in användaren.
                return RedirectToAction("RegistrationConfirmation");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Här kan du lägga till logiken för att verifiera användaren från databasen
                // Exempelvis: if (_vinMetod.ValidateUser(model))
                //               return RedirectToAction("Dashboard");
                //           else
                //               ModelState.AddModelError(string.Empty, "Felaktigt användarnamn eller lösenord.");
            }
            return View(model);
        }

        public IActionResult RegistrationConfirmation()
        {
            return View();
        }
    }
}
