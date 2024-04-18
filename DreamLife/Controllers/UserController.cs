using DreamLife.Data;
using DreamLife.Models;
using DreamLife.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DreamLife.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContext;
        public UserController(ILogger<UserController> logger, ApplicationDbContext context,IHttpContextAccessor httpContext)
        {
            _logger = logger;
            _context = context;
            _httpContext = httpContext;
        }

        public IActionResult Dashboard()
        {
            decimal totalAmount = 0;
            decimal rOIAmount = 0;
            decimal levelAmount = 0;      
            decimal referalAmount = 0;
            UserDashboard dashboard = new UserDashboard();
            var login = _httpContext.HttpContext.Session.GetString("LOGINID");
            if (string.IsNullOrEmpty(login))
            {
                var trans = _context.Transactions.Where(x => x.UserName == login).ToList();
                if (trans.Count > 0) {
                    totalAmount = trans.Select(x => Convert.ToDecimal(x.Amount)).Sum();
                    rOIAmount = trans.Select(x => Convert.ToDecimal(x.Amount)).Sum();
                    levelAmount = trans.Select(x => Convert.ToDecimal(x.Amount)).Sum();
                    referalAmount = trans.Select(x => Convert.ToDecimal(x.Amount)).Sum();
                }
                dashboard = new UserDashboard()
                {
                    Id = login,
                    TotalAmount = totalAmount,
                    ROIAmount = rOIAmount,
                    LevelAmount = levelAmount,
                    ReferalAmount = referalAmount
                };
            }

            return View(dashboard);
        }

        public IActionResult Profile()
        {
            var userName = _httpContext.HttpContext.Session.GetString("LOGINID");
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            return View(user);
        }

        public IActionResult Package()
        {
            return View();
        }

        public IActionResult PackageHistory()
        {
            var userName = _httpContext.HttpContext.Session.GetString("LOGINID");
            var transactions = _context.Transactions.Where(x => x.UserName == userName).ToList();
            return View(transactions);
        }
    }
}
