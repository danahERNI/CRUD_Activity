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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemModel>()
                .HasOne(i => i.Owner)
                .WithMany(o => o.OwnerId)
                .HasForeignKey(i => i.OwnerId);
        }

    }
}
