using CollectionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CollectionApi;
public class ApplicationDBContext(DbContextOptions options) : DbContext(options)
{
    public static string Schema { get; set; } = "Collections";
    public DbSet<Collections> Collections { get; set; }
    public DbSet<Category> Categories { get; set; }

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    base.OnModelCreating(modelBuilder);
    //    modelBuilder.Entity<ItemDetails>().HasKey(d => d.ItemId);
    //    modelBuilder.Entity<Category>().HasKey(l => l.CategoryId);
    //}
}

