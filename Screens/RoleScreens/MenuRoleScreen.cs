using Blog.Models;
using Blog.Repositories;
using Blog.Services;

namespace Blog.Screens.RoleScreens
{
  public static class MenuRoleScreen
  {
    public static void Load()
    {
      Menu.MenuLoad("Pefil");

      if (!short.TryParse(Console.ReadLine(), out var option))
      {
        Program.ShowInvalidOption();
        Load();
        return;
      }

      var repository = new Repository<Role>(Database.Connection!);
      var service = new RoleService(repository);

      switch (option)
      {
        case 1:
          ListRoleScreen.Load(service);
          break;
        case 2:
          CreateRoleScreen.Load(service);
          break;
        case 3:
          UpdateRoleScreen.Load(service);
          break;
        case 4:
          DeleteRoleScreen.Load(service);
          break;
        default:
          Program.ShowInvalidOption();
          Load();
          return;
      }
    }
  }
}