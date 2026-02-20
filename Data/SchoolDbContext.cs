using Microsoft.EntityFrameworkCore;
using Project.Models;

namespace Project.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<FeeRecord> FeeRecords { get; set; }
    }
}
