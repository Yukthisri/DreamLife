﻿using DreamLife.Data;
using DreamLife.Models;
using DreamLife.Models.Entities;
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
            decimal totalAmount = 0;
            decimal rOIAmount = 0;
            decimal levelAmount = 0;
            decimal referalAmount = 0;
            AdminDashboard dashboard = new AdminDashboard();
            var trans = _context.Transactions.ToList();
            if (trans.Count > 0)
            {
                totalAmount = trans.Select(x => Convert.ToDecimal(x.Amount)).Sum();
                rOIAmount = trans.Select(x => Convert.ToDecimal(x.Amount)).Sum();
                levelAmount = trans.Select(x => Convert.ToDecimal(x.Amount)).Sum();
                referalAmount = trans.Select(x => Convert.ToDecimal(x.Amount)).Sum();
            }

            dashboard = new AdminDashboard()
            {
                TotalAmount = totalAmount,
                ROIAmount = rOIAmount,
                LevelAmount = levelAmount,
                ReferalAmount = referalAmount
            };

            return View(dashboard);
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
