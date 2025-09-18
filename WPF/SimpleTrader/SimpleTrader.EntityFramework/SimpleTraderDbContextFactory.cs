using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[] args = null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SimpleTraderDB;Trusted_Connection=True;TrustServerCertificate=True");

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
