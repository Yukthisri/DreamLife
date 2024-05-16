using DreamLife.Data;
using DreamLife.Models;
using DreamLife.Models.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace DreamLife.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;

        public AccountController(ILogger<AccountController> logger, ApplicationDbContext context, IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContext;
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
                var user = _context.Users.Where(u => u.UserName == model.Name && u.Password == model.Password).FirstOrDefault();

                if (user != null)
                {
                    _httpContext.HttpContext.Session.SetString("LOGINID", user.UserName);
                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("Dashboard", "Admin");
                    }
                    else if(user.Role == "User")
                    {
                        var member = _context.MemberLevels.Where(u => u.UserId == model.Name).FirstOrDefault();
                        if (member != null)
                        {
                            _httpContext.HttpContext.Session.SetString("LevelID", member.LevelId);
                            return RedirectToAction("Dashboard", "User");
                        }
                        else
                        {
                            ViewBag.IsFailed = true;
                        }
                    }
                    else 
                    {
                        ViewBag.IsFailed = true;
                    }
                }
                else
                {
                    ViewBag.IsFailed = true;
                }
            }
            return View(model);
        }

        public IActionResult Register(string ReferalId)
        {
            if (!string.IsNullOrEmpty(ReferalId))
            {
                return View(new RegistrationViewModel { ReferalCode = ReferalId });
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Register(RegistrationViewModel model)
        {            
            if (ModelState.IsValid)
            {
                var registration = new Registration
                {
                    FullName = model.FullName,
                    Gender = model.Gender,
                    DateOfBirth = model.DateofBirth,
                    Email = model.Email,
                    Country = model.Country,
                    Phone = Convert.ToInt32(model.Phone),
                    City = model.City,
                    Address = string.Empty
                };

                _context.Registrations.Add(registration);
                _context.SaveChanges();
                ViewBag.IsSuccess = true;
            }
            return View(model);
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult Logout()
        {
            _httpContext.HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
