using DreamLife.Models;
using Microsoft.EntityFrameworkCore;

namespace DreamLife.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserViewModel> Users { get; set; }

        public DbSet<AdminViewModel> Admin { get; set; }

        public DbSet<RegistrationViewModel> Registrations { get; set; }
    }
}
