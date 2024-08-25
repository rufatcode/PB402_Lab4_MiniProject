namespace Lab4_MiniProject.Controllers;

public interface IRoleController
{
    bool Create();
    bool Delete();
    bool Update();
    bool GetById();
    void GetAllByAdmin();
    
    void GetAll();
}