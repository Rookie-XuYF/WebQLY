using Microsoft.EntityFrameworkCore;
using WebQLY.Models;

namespace WebQLY.Helper
{
    public class OracleHelper : DbContext
    {
        public OracleHelper(DbContextOptions<OracleHelper> options) : base(options)
        {
        }

        public DbSet<T_SYS_User> T_SYS_User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}