using Blog.Models;
using Blog.Repositories;
using Blog.Services;
using Blog.Utils;

namespace Blog.Screens.UserScreens
{
  public static class MenuUserScreen
  {
    public static void Load()
    {
      MenuBlog.Load("Usuário");

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        ConsoleHelper.ShowInvalidOption();
        Load();
        return;
      }

      var repository = new UserRepository(Database.Connection!);
      var userService = new UserService(repository);
      var roleService = new RoleService(new Repository<Role>(Database.Connection!));
      var userRoleService = new UserRoleService(new UserRoleRepository(Database.Connection!));

      switch (option)
      {
        case 1:
          ListUserScreen.Load(userService);
          break;
        case 2:
          CreateUserScreen.Load(userService, roleService, userRoleService);
          break;
        case 3:
          UpdateUserScreen.Load(userService);
          break;
        case 4:
          DeleteUserScreen.Load(userService);
          break;
        case 0:
          MenuScreen.Load();
          break;
        default:
          ConsoleHelper.ShowInvalidOption();
          Load();
          break;
      }
    }
  }
}