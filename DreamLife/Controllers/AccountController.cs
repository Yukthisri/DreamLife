using DreamLife.Data;
using DreamLife.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamLife.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _context;

        public AccountController(ILogger<AccountController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var name = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password
              
                };
                _context.SaveChanges();

                return RedirectToAction("Dashboard", "User");
            }

            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Registration model)
        {
            if (ModelState.IsValid)
            {
                var registration = new Registration
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    DateofBirth = model.DateofBirth,
                    Email = model.Email,
                    Password = model.Password,
                    Country = model.Country,
                    Phone = model.Phone,
                    City = model.City
                };

                _context.Registrations.Add(registration);
                _context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
