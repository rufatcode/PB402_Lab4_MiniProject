using Lab4_MiniProject.Entities.Common;

namespace Lab4_MiniProject.Entities;

public class Role:BaseEntity
{
    public string Name { get; set; }

    public Role(string name)
    {
        Name = name;
    }
    
}