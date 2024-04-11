using DreamLife.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DreamLife.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Registration> Registrations { get; set; }
    }
}
