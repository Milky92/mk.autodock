using AD.Persistence.Domain.Enums;
using AD.Persistence.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AD.Persistence.DataAccess.Seed;

public static class DbInitializer
{
    public static ModelBuilder Seed(this ModelBuilder modelBuilder)
    {
        var bag = new List<BusinessTask>();

        for (int i = 1; i < 256; i++)
            bag.Add(new BusinessTask() { Id = i, Name = $"task-{i}" });
        
        modelBuilder.Entity<BusinessTask>().HasData(bag);
        return modelBuilder;
    }
}