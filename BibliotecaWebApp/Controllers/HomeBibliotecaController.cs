using Microsoft.AspNetCore.Mvc;

namespace BibliotecaWebApp.Controllers
{
    public class HomeBibliotecaController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
