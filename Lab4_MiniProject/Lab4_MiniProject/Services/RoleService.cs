using Lab4_MiniProject.Entities;
using Lab4_MiniProject.Helpers;
using Lab4_MiniProject.Repositories;
using Lab4_MiniProject.Repositories.Interfaces;

namespace Lab4_MiniProject.Services;

public class RoleService:IRoleService
{
    private IRoleRepository _roleRepository;

    public RoleService()
    {
        _roleRepository = new RoleRepository();
    }
    public ResponseObj Create(Role role)
    {
        if (_roleRepository.GetByName(role.Name)!=null)
        {
            return new ResponseObj()
            {
                StatusCode = 400,
                Message = $"{role.Name}-> role already has created"
            };
        }
        _roleRepository.Create(role);

        return new ResponseObj()
        {
            StatusCode = 200,
            Message = $"{role.Name}-> role successfully  created"
        };
    }

    public ResponseObj Delete(int id)
    {
        if (_roleRepository.GetById(id)==null)
        {
            return new ResponseObj()
            {
                StatusCode = 400,
                Message = $" role does not exist "
            };
        }

        string deletedRoleName = _roleRepository.Delete(id);
        return new ResponseObj()
        {
            StatusCode = 200,
            Message = $"{deletedRoleName} role successfully  created"
        };
    }

    public ResponseObj Update(Role role)
    {
        
        Role testRole = _roleRepository.GetByName(role.Name);
        if (testRole.Id!=role.Id)
        {
            return new ResponseObj()
            {
                StatusCode = 400,
                Message = $"{testRole.Name} has already exist"
            };
        }
        _roleRepository.Update(role);
        return new ResponseObj()
        {
            StatusCode = 200,
            Message = $"{role.Name} successfully updated"
        };
    }

    public Role GetById(int id)
    {
        return _roleRepository.GetById(id);
    }

    public Role[] GetAllByAdmin()
    {
        return _roleRepository.GetAllByAdmin();
    }

    public Role[] GetAll()
    {
        return _roleRepository.GetAll();
    }
}