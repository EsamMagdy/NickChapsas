using MediatR_CQRS.Data;
using Microsoft.EntityFrameworkCore;

namespace MediatR_CQRS.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Order> Orders{ get; set; }
        public DbSet<Product> Products{ get; set; }
    }
}
