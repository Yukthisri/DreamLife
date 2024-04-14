using Microsoft.AspNetCore.Mvc;

namespace DreamLife.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
