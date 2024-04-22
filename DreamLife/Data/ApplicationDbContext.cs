using DreamLife.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DreamLife.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }

        public DbSet<Registration> Registrations { get; set; }

        public DbSet<MemberLevel> MemberLevels { get; set; }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Holiday> Holidays { get; set; }
    }
}
