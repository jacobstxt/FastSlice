using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Domain
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }

        public DbSet<CategoryEntity> Categories { get; set; }

    }
}
