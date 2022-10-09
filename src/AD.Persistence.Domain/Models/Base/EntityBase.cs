namespace AD.Persistence.Domain.Models.Base;

public class EntityBase<TPK>
{
    public EntityBase() { }
    
    public TPK Id { get; set; }
    
    public DateTime DateTimeCreation { get; set; } = DateTime.UtcNow;

    public DateTime DateTimeUpdate { get; set; }
}


public class EntityBase:EntityBase<int> { }