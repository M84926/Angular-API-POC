using Microsoft.EntityFrameworkCore;
using AngularPOC.Entities;

namespace AngularPOC.Data
{
    public class AngularPOCDbContext : DbContext
    {
        public AngularPOCDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserMaster> UserMaster { get; set; }
    }

}
