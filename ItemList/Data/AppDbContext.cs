using ItemList.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItemList.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }
        public DbSet<ItemModel> ItemModels { get; set; }
        public DbSet<Owner> OwnerModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Owner>(entity =>
            //{
            //    entity.has
            //});
        }

    }
}
