using HamroyevAnvar.Models;
using HamroyevAnvar.Services;
using Microsoft.AspNetCore.Mvc;

namespace HamroyevAnvar.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Contact contact,
            [FromServices] TgBotService _tgBotServoce)
        {
            //if (!ModelState.IsValid)
            //    return View("~/Views/Home/Index.cshtml");
            if (contact is null)
                return RedirectToAction("Index", "Home",
                    new { msg = "Barcha maydonlarni to'ldirish majburiy!" });
            if (string.IsNullOrWhiteSpace(contact.FullName) || contact.FullName?.Length < 5)
                return RedirectToAction("Index", "Home",
                    new { msg = "F.I.O kamida 5 ta belgidan iborat bo'lishi shart!" });
            if (string.IsNullOrWhiteSpace(contact.Tel) || contact.Tel?.Length < 9)
                return RedirectToAction("Index", "Home",
                    new { msg = "Telefon raqam kamida 9 ta raqamdan iborat bo'lishi shart!" });
            if (string.IsNullOrWhiteSpace(contact.Subject) || contact.Subject?.Length < 5)
                return RedirectToAction("Index", "Home",
                    new { msg = "Mavzu kamida 5 ta belgidan iborat bo'lishi shart!" });
            if (string.IsNullOrWhiteSpace(contact.Text) || contact.Text?.Length < 10)
                return RedirectToAction("Index", "Home",
                    new { msg = "Murojaatingiz kamida 10 ta belgidan iborat bo'lishi shart!" });

            string msg = await _tgBotServoce.SendMessageToAdmins(contact);

            return RedirectToAction("Index", "Home",
                new { msg = msg });
        }
    }
}
