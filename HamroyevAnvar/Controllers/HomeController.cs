using Microsoft.AspNetCore.Mvc;

namespace HamroyevAnvar.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
