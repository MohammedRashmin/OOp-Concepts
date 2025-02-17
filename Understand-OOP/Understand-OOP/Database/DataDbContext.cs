using Microsoft.EntityFrameworkCore;
using Understand_OOP.Database.Entities;

namespace Understand_OOP.Database
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }





    }
}
