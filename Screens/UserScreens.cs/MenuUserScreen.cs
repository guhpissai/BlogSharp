using Blog.Repositories;
using Blog.Services;

namespace Blog.Screens.UserScreens
{
  public static class MenuUserScreen
  {
    public static void Load()
    {
      Menu.MenuLoad("Usuário");

      if (!short.TryParse(Console.ReadLine(), out short option))
      {
        Program.ShowInvalidOption();
        Load();
        return;
      }

      var repository = new UserRepository(Database.Connection!);
      var service = new UserService(repository);

      switch (option)
      {
        case 1:
          ListUserScreen.Load(service);
          break;
        case 2:
          CreateUserScreen.Load(service);
          break;
        case 3:
          UpdateUserScreen.Load(service);
          break;
        case 4:
          DeleteUserScreen.Load(service);
          break;
        case 0:
          Program.Menu();
          break;
        default:
          Program.ShowInvalidOption();
          Load();
          break;
      }
    }
  }
}