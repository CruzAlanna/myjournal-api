using Microsoft.EntityFrameworkCore;
using MyJournalApi.Models;

namespace MyJournalApi.Data
{
  public class ApplicationDbContext : DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Reflection> Reflections { get; set; }

    public override int SaveChanges()
    {
        UpdateTimestamps();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateTimestamps();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateTimestamps()
    {
      var entries = ChangeTracker.Entries()
          .Where(e => e.Entity is Reflection && (e.State == EntityState.Added || e.State == EntityState.Modified));

      foreach (var entityEntry in entries)
      {
        var reflection = (Reflection)entityEntry.Entity;
        
        if (entityEntry.State == EntityState.Added)
        {
          reflection.CreatedAt = DateTime.UtcNow;
        }
        
        reflection.UpdatedAt = DateTime.UtcNow;
      }
    }
  }
}