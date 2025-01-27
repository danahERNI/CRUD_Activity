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
        
    }
}
