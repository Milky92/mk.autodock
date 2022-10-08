using AD.Persistence.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AD.Persistence.DataAccess;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<BusinessTask> BusinessTasks { get; set; }
    public DbSet<BusinessTaskAttachment> Attachments { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.HasDefaultSchema("public");
        
        modelBuilder.Setup(this);
    }
}