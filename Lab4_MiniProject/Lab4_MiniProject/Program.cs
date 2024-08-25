// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using Lab4_MiniProject.Controllers;
using Lab4_MiniProject.Entities;
using Lab4_MiniProject.Helpers;
using Lab4_MiniProject.Repositories;
using Lab4_MiniProject.Services;

IRoleController roleController = new RoleController();


while (true)
{
    ConsoleColorExtention.Writeline(ConsoleColor.DarkYellow,@"
    0.Exist
    1.Add Role
    2.Remove Role
    3.Get Role By Id
    4.Get All Roles
    5.Get Roles By Admin
    6.Update Role
    
");
    AddOption:ConsoleColorExtention.Writeline(ConsoleColor.Yellow,"Select option");
    string optionStr = Console.ReadLine();
    string roleIdStr;
    int roleId = 0;
    if (!int.TryParse(optionStr,out int option))
    {
        ConsoleColorExtention.Writeline(ConsoleColor.Red,"Please select correct option");
        goto AddOption;
    }
    ResponseObj responseObj;
    switch (option)
    { 
        case 0:
            ConsoleColorExtention.Writeline(ConsoleColor.Cyan,"Proses finshed");
            return ;
        case 1:
            if (!roleController.Create())
            {
               goto AddOption;
            }
            break;
        case 2:
            if(!roleController.Delete())goto AddOption;
            break;
        case 3:
            if(!roleController.GetById())goto AddOption;
            break;
        case 4:
            roleController.GetAll();
            break;
        case 5:
           roleController.GetAllByAdmin();
            break;
        case 6:
            if(!roleController.Update())goto AddOption;
            break;
        default:
            ConsoleColorExtention.Writeline(ConsoleColor.Red,"Option does not exist");
            goto AddOption;
    }
}

