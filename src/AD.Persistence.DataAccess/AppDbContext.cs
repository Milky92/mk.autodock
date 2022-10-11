using AD.Persistence.DataAccess.Seed;
using AD.Persistence.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AD.Persistence.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<BusinessTask> BusinessTasks { get; set; }
    public DbSet<BusinessTaskAttachment> Attachments { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("db_public");
        
        modelBuilder.Setup(this);
        
        base.OnModelCreating(modelBuilder);
    }
    
}