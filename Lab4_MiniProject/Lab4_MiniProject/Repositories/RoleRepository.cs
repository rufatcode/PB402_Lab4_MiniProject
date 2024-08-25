using Lab4_MiniProject.DataAccess;
using Lab4_MiniProject.Entities;
using Lab4_MiniProject.Repositories.Interfaces;
using Lab4_MiniProject.Services;

namespace Lab4_MiniProject.Repositories;

public class RoleRepository:IRoleRepository
{
    //DbRoles->{role1,role2,role3,role4}
    //Exist->
    public void Create(Role role)
    {
        Role[] existRoles=new Role[DB.Roles.Length+1];
        for (int i = 0; i < DB.Roles.Length; i++)
        {
            existRoles[i] = DB.Roles[i];
        }
        existRoles[existRoles.Length - 1] = role;
        DB.Roles = existRoles;


    }

    public string Delete(int id)
    {
        foreach (Role role in DB.Roles)
        {
            if (role.Id==id&&role.Active)
            {
                role.Active = false;
                role.DeletedAt=DateTime.Now;
                return role.Name;
            }
        }

        return null;
    }

    public void Update(Role role)
    {
        for (int i = 0; i < DB.Roles.Length; i++)
        {
            if (DB.Roles[i].Id==role.Id)
            {
                DB.Roles[i] = role;
                DB.Roles[i].UpdatedAt=DateTime.Now;
                return;
            }
        }
    }

    public Role GetById(int id)
    {
        foreach (Role role in DB.Roles)
        {
            if (role.Id==id&&role.Active)
            {
                return role;
            }
        }

        return default;
    }
    public Role GetByName(string name)
    {
        foreach (Role role in DB.Roles)
        {
            if (role.Name.ToLower()==name.ToLower()&&role.Active)
            {
                return role;
            }
        }

        return default;
    }

    public Role[] GetAllByAdmin()
    {
        return DB.Roles;
    }
    
    public Role[] GetAll()
    {
        
        int activeRolesCount = 0;
        foreach (Role role in DB.Roles)
        {
            if (role.Active)
            {
                activeRolesCount++;
            }
        }
        Role[] activeRoles = new Role[activeRolesCount];
        //DbRoles->{rol1,rol2:notective,rol3}
        //2->active
        //activeRoles->{null,null}
        int index = 0;
        foreach (Role role in DB.Roles)
        {
            if (role.Active==true)
            {
                activeRoles[index++] = role;
            }
        }
        
        

        
        return activeRoles;
    }
}