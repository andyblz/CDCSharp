using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models
{
  public class HomeContext : DbContext
  {
      public HomeContext(DbContextOptions<HomeContext> options) : base(options) {}

      // All the SQL tables here.
      public DbSet<User> users { get; set; }    
      public DbSet<Wedding> weddings { get; set; } 
      public DbSet<WeddingUser> weddings_users { get; set; }                 
  }
}