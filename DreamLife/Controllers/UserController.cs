using Azure.Core.GeoJson;
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
        public UserController(ILogger<UserController> logger, ApplicationDbContext context, IHttpContextAccessor httpContext)
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
            if (!string.IsNullOrEmpty(login))
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

                return View(dashboard);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        public IActionResult Profile()
        {
            var userId = _httpContext.HttpContext.Session.GetString("LOGINID");
            if (string.IsNullOrEmpty(userId)) { return RedirectToAction("Login", "Account"); }
            var user = _context.Users.FirstOrDefault(u => u.UserName == userId);

            return View(user);
        }

        public IActionResult Package()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Package(PackageViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = _httpContext.HttpContext.Session.GetString("LOGINID");
                if (string.IsNullOrEmpty(userId)) { return RedirectToAction("Login", "Account"); }
                    Transaction transaction = new Transaction {
                    UserName = userId,
                    Amount = model.Amount.ToString(),
                    UpdatedDate = DateTime.Now

                };
                _context.Transactions.Add(transaction);
                _context.SaveChanges();

                ModelState.AddModelError(string.Empty, "Package Successfully Added...");
            }
            return View(model);
        }

        public IActionResult PackageHistory()
        {
            var userId = _httpContext.HttpContext.Session.GetString("LOGINID");
            if (string.IsNullOrEmpty(userId)) { return RedirectToAction("Login", "Account"); }
            var transactions = _context.Transactions.Where(x => x.UserName == userId).ToList();
            return View(transactions);
        }

        public IActionResult Member()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Member(MemberViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userId = _httpContext.HttpContext.Session.GetString("LOGINID");
                if (string.IsNullOrEmpty(userId)) { return RedirectToAction("Login", "Account"); }
                string levelId = _httpContext.HttpContext.Session.GetString("LevelID");
                string childLevelId;
                string newLevelId;
                string newParentId;
                string newPosition;
                string newUserId;
                var memberLevels = _context.MemberLevels.Where(x => x.ParentId == userId).ToList();
                int members = memberLevels.Count();
                if (members >= 2)
                {
                    newPosition = model.Position;
                    childLevelId = newPosition == "Left" ? (levelId + 1) : (levelId + 2);
                    var newMemberLevels = _context.MemberLevels.Where(x => x.LevelId.Contains(childLevelId)).ToList();
                    var newMemberLevel = newMemberLevels.Where(x => x.Position == newPosition).OrderByDescending(x => x.LevelId).FirstOrDefault();
                    newLevelId = newPosition == "Left" ? (newMemberLevel.LevelId + 1) : (newMemberLevel.LevelId + 2);
                    newParentId = newMemberLevel.UserId;
                }
                else
                {
                    if (members == 0) {
                        newLevelId = model.Position == "Left" ? (levelId + 1) : (levelId + 2);
                        newPosition = model.Position;
                    }
                    else
                    {
                        newLevelId = memberLevels[0].Position == "Left" ? (levelId + 2) : (levelId + 1);
                        newPosition = memberLevels[0].Position == "Left" ? "Right" : "Left";
                    }
                    newParentId = userId;
                }
                newUserId = GenerateUserId();
                User user = new User {
                    UserName = newUserId,
                    Password="Abc@123",
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Role = "User",
                    Gender = model.Gender,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    Country = model.Country,
                    Phone = model.Phone,
                    City = model.City,
                    Address = model.Address,
                    CreatedDate = DateTime.Now
                };

                _context.Users.Add(user);
                _context.SaveChanges();

                MemberLevel memberLevel = new MemberLevel {
                    UserId = newUserId,
                    LevelId = newLevelId,
                    ParentId= newParentId,
                    GrandParentId = userId,
                    Position = newPosition,
                    UpdatedDate = DateTime.Now
                };
                _context.MemberLevels.Add(memberLevel);
                _context.SaveChanges();
                ModelState.AddModelError(string.Empty, "Member Successfully Added...");
            }
            return View(model);
        }

        public IActionResult Network()
        {
            var userId = _httpContext.HttpContext.Session.GetString("LOGINID");
            if (string.IsNullOrEmpty(userId)) { return RedirectToAction("Login", "Account"); }
            string levelId = _httpContext.HttpContext.Session.GetString("LevelID");
            var newMemberLevels = _context.MemberLevels.Where(x => x.LevelId.Contains(levelId)).ToList();
            ViewBag.UserId = userId;
            if (newMemberLevels.Any())
            {
                ViewBag.Left = newMemberLevels.Where(x => x.LevelId.Contains(levelId + 1)).Count();
                ViewBag.Right = newMemberLevels.Where(x => x.LevelId.Contains(levelId + 2)).Count();
            }
            else
            {
                ViewBag.Left = 0;
                ViewBag.Right = 0;
            }
            return View();
        }

        private string GenerateUserId()
        {
            string newId = string.Empty;
            var userId = _httpContext.HttpContext.Session.GetString("LOGINID");
            if (!string.IsNullOrEmpty(userId))
            {
                var lastId = _context.Users.Select(x => x.UserName).OrderByDescending(x => x).FirstOrDefault();
                if (!string.IsNullOrEmpty(lastId)){
                    newId = "DL" + (Convert.ToInt32(lastId.Substring(2)) + 1);
                }
            }
            return newId;
        } 
    }
}
