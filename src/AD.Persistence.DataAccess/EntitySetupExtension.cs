using AD.Persistence.Domain.Models;
using AD.Persistence.Domain.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace AD.Persistence.DataAccess;

public static class EntitySetupExtension
{
    public static ModelBuilder Setup(this ModelBuilder modelBuilder, AppDbContext context)
        => modelBuilder.SetupBusinessTask(context)
            .SetupBusinessTaskAttachment(context);

    private static ModelBuilder SetupBusinessTask(this ModelBuilder modelBuilder, AppDbContext context)
    {
        modelBuilder.Entity<BusinessTask>().HasKey(t => t.Id);
        modelBuilder.Entity<BusinessTask>().Property(x => x.Status);

        return modelBuilder;
    }

    private static ModelBuilder SetupBusinessTaskAttachment(this ModelBuilder modelBuilder, AppDbContext context)
    {
        modelBuilder.Entity<BusinessTaskAttachment>().HasKey(t => t.Id);

        modelBuilder.Entity<BusinessTaskAttachment>()
            .HasOne(t=>t.BusinessTask)
            .WithMany(t=>t.Attachments)
            .HasForeignKey(at => at.BusinessTaskId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        return modelBuilder;
    }
}