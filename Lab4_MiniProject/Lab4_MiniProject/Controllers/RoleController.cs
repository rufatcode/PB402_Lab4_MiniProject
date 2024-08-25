using Lab4_MiniProject.Entities;
using Lab4_MiniProject.Helpers;
using Lab4_MiniProject.Services;

namespace Lab4_MiniProject.Controllers;

public class RoleController:IRoleController
{
    private readonly IRoleService _roleService ;

    public RoleController()
    {
        _roleService = new RoleService();
    }
    public bool Create()
    {
        ConsoleColorExtention.Writeline(ConsoleColor.Green, "Enter Role Name");
        string roleName = Console.ReadLine();
        ResponseObj responseObj = _roleService.Create(new Role(roleName));
        if (responseObj.StatusCode==400)
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Red,responseObj.Message);
            return false;
        }
        ConsoleColorExtention.Writeline(ConsoleColor.Cyan,responseObj.Message);
        return true;
    }

    public bool Delete()
    {
        ConsoleColorExtention.Writeline(ConsoleColor.Green, "Enter Role Id");
        string roleIdStr = Console.ReadLine();
        if (!int.TryParse(roleIdStr,out int roleId))
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Red, "Something went wrong");
            return false;
        }

        ResponseObj responseObj = _roleService.Delete(roleId);
        if (responseObj.StatusCode==400)
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Red,responseObj.Message);
            return false;
        }
        ConsoleColorExtention.Writeline(ConsoleColor.Cyan,responseObj.Message);
        return true;
    }

    public bool Update()
    {
        ConsoleColorExtention.Writeline(ConsoleColor.Green, "Enter Role Id");
        string roleIdStr = Console.ReadLine();
        if (!int.TryParse(roleIdStr,out  int roleId))
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Red, "Something went wrong");
            return false;
        }

        Role role = _roleService.GetById(roleId);
        if (role==null)
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Red, "role does not exist");
            return false;
        }
        ConsoleColorExtention.Writeline(ConsoleColor.Green, "Enter new Role Name");
        role.Name = Console.ReadLine();
        ResponseObj responseObj = _roleService.Update(role);
        if (responseObj.StatusCode==400)
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Red,responseObj.Message);
            return false;
        }
        ConsoleColorExtention.Writeline(ConsoleColor.Cyan,responseObj.Message);
        return true;
    }

    public bool GetById()
    {
        ConsoleColorExtention.Writeline(ConsoleColor.Green, "Enter Role Id");
        string roleIdStr = Console.ReadLine();
        if (!int.TryParse(roleIdStr,out  int roleId))
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Red, "Something went wrong");
            return false;
        }

        var roleData = _roleService.GetById(roleId);
        if (roleData==null)
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Red, "Role does not exist");
            return false;
        }
        ConsoleColorExtention.Writeline(ConsoleColor.Red, $"{roleData.Id}.{roleData.Name}->Created:{roleData.CreatedAt}->Deleted:{roleData.DeletedAt}->Updated:{roleData.UpdatedAt}");
        return true;
    }

    public void GetAllByAdmin()
    {
        Role[] roles = _roleService.GetAllByAdmin();
        foreach (Role role in roles)
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Green,$"{role.Id}.{role.Name},CreatedAt->{role.CreatedAt},Deleted->{role.DeletedAt},Updated->{role.UpdatedAt} ");
        }
    }

    public void GetAll()
    {
        Role[] roles = _roleService.GetAll();
        foreach (Role role in roles)
        {
            ConsoleColorExtention.Writeline(ConsoleColor.Green,$"{role.Id}.{role.Name},CreatedAt->{role.CreatedAt} ");
        }
    }
}