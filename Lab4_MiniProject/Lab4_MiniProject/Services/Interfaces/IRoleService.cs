using Lab4_MiniProject.Entities;
using Lab4_MiniProject.Helpers;

namespace Lab4_MiniProject.Services;

public interface IRoleService
{
    ResponseObj Create(Role role);
    ResponseObj Delete(int id);
    ResponseObj Update(Role role);
    Role GetById(int id);
    Role[] GetAllByAdmin();
    
    Role[] GetAll();
}