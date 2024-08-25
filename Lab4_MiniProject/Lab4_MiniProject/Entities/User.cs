using Lab4_MiniProject.Entities.Common;

namespace Lab4_MiniProject.Entities;

public class User:BaseEntity
{
    public string UserName { get; set; }
    public string  Email { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public string Otp { get; set; }
    public bool IsVerified { get; set; }

    public User()
    {
        IsVerified = false;
        Otp = Guid.NewGuid().ToString().Substring(0,6);
    }

    public User(string userName,string email,string password,int roleId):this()
    {
        UserName = userName;
        Email = email;
        Password = password;
        RoleId = roleId;
    }
}