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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasColumnType("nvarchar(50)");

            modelBuilder.Entity<User>()
                .Property(u => u.DateCreated)
                .HasColumnType("datetime2");

            base.OnModelCreating(modelBuilder);
        }
    }
}
