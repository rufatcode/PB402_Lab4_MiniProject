using Lab4_MiniProject.Entities;

namespace Lab4_MiniProject.Repositories.Interfaces;

public interface IUserRepository
{
    void Create(User user);
    void Delete(int id);
    void Update(User user);
    User GetById(int id);
    User[] GetAll();
}