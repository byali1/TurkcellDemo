using Microsoft.EntityFrameworkCore;

namespace TurkcellDemo.Web.Models
{
    public class TurkcellDbContext:DbContext
    {

        public TurkcellDbContext(DbContextOptions<TurkcellDbContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
