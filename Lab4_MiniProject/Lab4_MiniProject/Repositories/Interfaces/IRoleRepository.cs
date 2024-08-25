using Lab4_MiniProject.Entities;

namespace Lab4_MiniProject.Repositories.Interfaces;

public interface IRoleRepository
{
    void Create(Role role);
    string Delete(int id);
    void Update(Role role);
    Role GetById(int id);
    Role GetByName(string  name);
    Role[] GetAllByAdmin();
    
    Role[] GetAll();
}