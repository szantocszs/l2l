
using Microsoft.EntityFrameworkCore;

namespace l2l.Data.Model
{
    public class L2lDbContext : DbContext
    {
        public L2lDbContext(DbContextOptions options) : base(options)
        {
        }

        protected L2lDbContext()
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}