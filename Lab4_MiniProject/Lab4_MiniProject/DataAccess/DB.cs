using Lab4_MiniProject.Entities;

namespace Lab4_MiniProject.DataAccess;

public class DB
{
    public static  User[] Users { get; set; } = new User[0];

    public static  Role[] Roles { get; set; } = new Role[0];
}