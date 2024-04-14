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
        public IActionResult Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                var name = new UserViewModel
                {
                    Name = model.Name,
                    Password = model.Password
              
                };
                _context.SaveChanges();
                if (user.Role == "Admin")
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
                else
                {
                    return RedirectToAction("Dashboard", "User");
                }
            }

            return View(model);
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                var registration = new Registration
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Gender = model.Gender,
                    DateOfBirth = model.DateofBirth,
                    Email = model.Email,
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
