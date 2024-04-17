using DreamLife.Data;
using DreamLife.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamLife.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;
        public UserController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Profile()
        {
            var userName = "DL2112";
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            return View(user);
        }

        public IActionResult Package()
        {
            return View();
        }

        public IActionResult PackageHistory()
        {
            var userName = "DL2112";
            var transactions = _context.Transactions.Where(x => x.UserName == userName).ToList();
            return View(transactions);
        }
    }
}
