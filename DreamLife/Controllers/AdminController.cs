using DreamLife.Data;
using DreamLife.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamLife.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly ApplicationDbContext _context;

        public AdminController(ILogger<AdminController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Registrations()
        {
            List<Registration> registrations = _context.Registrations.ToList();

            return View(registrations);
        }

        public IActionResult Users()
        {
            List<User> users = _context.Users.ToList();

            return View(users);
        }

        public IActionResult Transactions()
        {
            List<Transaction> transactions = _context.Transactions.ToList();

            return View(transactions);
        }
    }
}
