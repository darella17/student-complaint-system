using Microsoft.EntityFrameworkCore;
using StudentComplaintSystem.Models;

namespace StudentComplaintSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Complaint> Complaints { get; set; }
    }
}