namespace Lab4_MiniProject.Entities.Common;

public abstract class BaseEntity
{
    private static int _count { get; set; } = 0;
    public int Id { get; set; }

    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public DateTime? DeletedAt { get; set; }
    
    public DateTime? UpdatedAt { get; set; }


    public BaseEntity()
    {
        _count++;
        Id = _count;
        CreatedAt=DateTime.Now;
        Active = true;
    }
}