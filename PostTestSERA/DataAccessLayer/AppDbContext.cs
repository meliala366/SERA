using Microsoft.EntityFrameworkCore;
using PostTestSERA.Model;

namespace PostTestSERA.DataAccessLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> customer { get; set; }
    }
}
